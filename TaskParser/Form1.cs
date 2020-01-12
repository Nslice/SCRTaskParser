using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var date = DateTime.Now;
            beginDateTimePicker.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            endDateTimePicker.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 0);
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "*.desc |*.desc";
            saveFileDialog.FileName = $"Tasks_{DateTime.Now.ToString("yyyyMMdd")}.desc";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, Encoding.UTF8.GetBytes(richTextBox1.Text));
            }
        }

        private void doItButton_Click(object sender, System.EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            List<ReplicationInfo> linkList = GetUriList();
            List<Issue> issueList = GetIssueList(linkList);
            List<string> taskList = GetTaskCaptionList(issueList);
            richTextBox1.Text = string.Join(Environment.NewLine, taskList.Select(n => n));
        }

        private List<Issue> GetIssueList(List<ReplicationInfo> linkList)
        {
            List<Issue> result = new List<Issue>();
            if (linkList.Count == 0) return result;

            var jira = Jira.CreateRestClient(jiraAddressTextBox.Text, loginTextBox.Text, passwordTextBox.Text);
            var quearable = jira.Issues.Queryable;

            progressBar1.Value = 0;
            progressBar1.Maximum = linkList.Count;
            foreach (ReplicationInfo replic in linkList)
            {
                progressBar1.Value++;
                foreach (string task in replic.TaskList)
                {
                    try
                    {
                        var issue = quearable.FirstOrDefault(n => n.Key == task);
                        if (issue == null || (resolvedCheckBox.Checked && !(issue.Status.Name == "Resolved" || issue.Status.Name == "Решено"))) continue;
                        if (result.Any(n => n.Key.Equals(issue.Key)) == false)
                            result.Add(issue);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(string.Format("Произошла ошибка при выборке информации по номеру задачи - {0}, номер которой указал в комментарии - {1}.\n\nError-{2},\nStackTrace-{3}",
                                             task, replic.Creator, e.Message, e.StackTrace));
                    }
                }
            }
            progressBar1.Value = 0;

            return result;
        }

        private List<string> GetTaskCaptionList(List<Issue> issueList)
        {
            List<string> result = new List<string>();
            if (issueList.Count == 0) return result;

            var tmpIssueList = issueList.Select(n => new ParserIssue
            {
                Key = n.Key.ToString(),
                Summary = n.Summary,
                Status = n.Status,
                Priority = n.Priority,
                Parent = n,
                AsHtml = checkBox_asHtml.Checked,
                NeedShowPriority = checkBox_NeedShowPriority.Checked,
                FixVersions = checkBox_FIxVersion.Checked ? n.FixVersions : null
            })
            .GroupBy(n => n.Status.Name == "Resolved" || n.Status.Name == "Решено" || n.Status.Name == "Closed" || n.Status.Name == "Закрыто", n => n)
            .OrderBy(n => n.Key);

            foreach (var tasklist in tmpIssueList)
            {
                if (tasklist.Key)
                    result.Add(string.Format("{0}Resolved:", Environment.NewLine));
                else
                    result.Add(string.Format("{0}Not resolved:", Environment.NewLine));

                foreach (var task in tasklist.OrderBy(n => n.Key))
                    result.Add(task.ToString());
            }

            return result;
        }

        private List<ReplicationInfo> GetUriList()
        {
            List<ReplicationInfo> result = new List<ReplicationInfo>();

            EleedServiceFactory service = new EleedServiceFactory(loginTextBox.Text, passwordTextBox.Text);
            var client = service.Create();

            var replicList = client.GetReplicsInfo(beginDateTimePicker.Value, endDateTimePicker.Value);

            foreach (var replic in replicList)
            {
                ReplicationInfo info = new ReplicationInfo();
                info.Creator = replic.UserName;

                string[] taskList = replic.Comment.Split(',');
                foreach (string task in taskList)
                {
                    var trimmedtask = task.Trim();
                    if (trimmedtask == string.Empty) continue;
                    if (info.TaskList.Contains(trimmedtask) == false)
                        info.TaskList.Add(trimmedtask);
                }
                result.Add(info);
            }

            return result;
        }
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}