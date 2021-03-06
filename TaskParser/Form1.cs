﻿using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TaskParser
{
   public partial class Form1 : Form
   {
      public bool IgnoreClosed
      {
         get { return checkBox_IgnoreClosed.Checked; }
      }

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
         ShowResult(taskList);
      }

      private List<ReplicationInfo> GetUriList()
      {
         var result = new List<ReplicationInfo>();

         var service = new EleedServiceFactory(loginTextBox.Text, passwordTextBox.Text);
         var client = service.Create();

         var replicList = client.GetReplicsInfo(beginDateTimePicker.Value, endDateTimePicker.Value);

         foreach (var replic in replicList)
         {
            var info = new ReplicationInfo();
            var uniqueTasks = new HashSet<string>();
            info.Creator = replic.UserName;

            // Формат комментария "НомерЗадачи: описание; НомерЗадачи: описание":
            // LSP-4343: комментарий;
            // LSP-5453: еще комментарий
            IEnumerable<string> taskList = replic.Comment?.Split(';') ?? Enumerable.Empty<string>();
            foreach (string task in taskList)
            {
               string taskKey = Regex.Match(task.Trim(), @".+(?=:)|.+").Groups[0].Value;
               // string taskKey =  Regex.Match(task.Trim(), @"(.+)(?=:)|.+").Groups[0].Value;
               if (string.IsNullOrEmpty(taskKey))
                  continue;
               uniqueTasks.Add(taskKey);
            }

            info.TaskList.AddRange(uniqueTasks);
            result.Add(info);
         }

         return result;
      }

      private List<Issue> GetIssueList(List<ReplicationInfo> linkList)
      {
         var result = new List<Issue>();
         if (linkList.Count == 0)
            return result;

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
                  if (issue == null)
                     continue;

                  if (checkBox_Resolved.Checked
                      && !(issue.Status.Name == "Resolved" || issue.Status.Name == "Решено"))
                     continue;

                  if (this.IgnoreClosed && (issue.Status.Name.ToLower() == "closed" ||
                                            issue.Status.Name.ToLower() == "закрыто"))
                     continue;

                  if (result.Any(n => n.Key.Equals(issue.Key)) == false)
                     result.Add(issue);

               }
               catch (Exception e)
               {
                  string msg =
                     $@"Произошла ошибка при выборке информации по номеру задачи - {task}, номер которой указал в комментарии - {replic.Creator}.\n\nError-{e.Message},\nStackTrace-{e.StackTrace}";
                  this.richTextBox_Log.Text += Environment.NewLine + msg;
               }
            }
         }

         progressBar1.Value = 0;

         return result;
      }

      private List<string> GetTaskCaptionList(List<Issue> issueList)
      {
         var result = new List<string>();
         if (issueList.Count == 0)
            return result;

         var tmpIssueList = issueList.Select(n => new ParserIssue
            {
               Key = n.Key.ToString(),
               Summary = n.Summary,
               Status = n.Status,
               Label = string.Join(", ", n.Labels),
               Priority = n.Priority,
               Parent = n,
               AsHtml = checkBox_asHtml.Checked,
               NeedShowPriority = checkBox_NeedShowPriority.Checked,
               FixVersions = checkBox_FIxVersion.Checked ? n.FixVersions : null
            })
            .GroupBy(n => n.Status.Name == "Resolved" || n.Status.Name == "Решено" || n.Status.Name == "Closed" ||
                          n.Status.Name == "Закрыто", n => n)
            .OrderBy(n => n.Key);

         foreach (IGrouping<bool, ParserIssue> tasklist in tmpIssueList)
         {
            if (tasklist.Key)
               result.Add($"{Environment.NewLine}Resolved:");
            else
               result.Add($"{Environment.NewLine}Not resolved:");

            var groupByLabel = tasklist.GroupBy(x => x.Label)
               .OrderBy(x => string.IsNullOrWhiteSpace(x.Key))
               .ThenBy(x => x.Key.Equals("GENERIC", StringComparison.OrdinalIgnoreCase))
               .ThenBy(x => x.Key);

            foreach (IGrouping<string, ParserIssue> task in groupByLabel)
            {
               string label = string.IsNullOrWhiteSpace(task.Key) ? "None" : task.Key;
               result.Add($"{label}:");

               foreach (ParserIssue line in task.OrderBy(x => x.Key))
                  result.Add($"\t{line}");
            }
         }

         result[0] = result[0].TrimStart();
         return result;
      }

      private void ShowResult(List<string> taskList)
      {
         richTextBox1.Text = taskList.Any()
            ? string.Join(Environment.NewLine, taskList.Select(n => n))
            : @"Not found";
      }

      private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start(e.LinkText);
      }

      private void checkBox_Resolved_CheckedChanged(object sender, EventArgs e)
      {
         if (this.checkBox_Resolved.Checked == true)
            this.checkBox_IgnoreClosed.Checked  = false;
      }

      private void checkBox_IgnoreClosed_CheckedChanged(object sender, EventArgs e)
      {
         if (this.checkBox_IgnoreClosed.Checked == true)
            this.checkBox_Resolved.Checked = false;
      }
   }
}