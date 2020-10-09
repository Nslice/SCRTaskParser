using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TaskParser
{
    [DebuggerDisplay("{Key}, {Label}")]
    internal class ParserIssue : IComparable
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public IssueStatus Status { get; set; }
        public string Label { get; set; }
        public Issue Parent { get; set; }
        public IssuePriority Priority { get; set; }
        public ProjectVersionCollection FixVersions { get; set; }

        public bool AsHtml { get; set; }
        public bool NeedShowPriority { get; set; }

        public Uri GetUri(Uri prevUri, int position, params string[] args)
        {
            if (args.Length == 0) return prevUri;

            var array = new List<string>(args);
            array.RemoveAt(1);

            if (prevUri == null)
                return GetUri(new Uri(args[0]), position + 1, array.ToArray());
            else
                return GetUri(prevUri, position + 1, array.ToArray());
        }

        public override string ToString()
        {
            return GetLink();
        }

        private string GetLink()
        {
            Uri link = new Uri(new Uri(new Uri(Parent.Jira.Url), "browse/"), Key);

            string result = string.Empty;
            string priority = GetVersionAdditionalInfo();

            if (this.AsHtml)
            {
                result = string.Format("<a href=\"{0}\">{1} {2}- {3}</a>", link, this.Key, priority, this.Summary);
            }
            else
            {
                result = string.Format("{0} {1}- {2}", link, priority, this.Summary);
            }

            return result;
        }

        private string GetVersionAdditionalInfo()
        {
            List<string> values = new List<string>(2);

            string fixVersions = GetFixVersions();
            if (fixVersions != string.Empty)
               values.Add(fixVersions);

            string priority = this.NeedShowPriority && this.Priority != null ? this.Priority.ToString() : string.Empty;

            if (priority != string.Empty)
               values.Add(priority);


            if (values.Count > 0)
            {
               priority = string.Join(", ", values);
               string tab = this.AsHtml ? "\t" : string.Empty;
               priority = $"({priority}){tab}";
            }

            return priority;
        }

        private string GetFixVersions()
        {
            if (this.FixVersions == null) return string.Empty;

            List<string> result = new List<string>();

            for (int i = 0; i < this.FixVersions.Count; i++)
            {
               ProjectVersion prjVersion = this.FixVersions[i];
               result.Add(prjVersion.Name);
            }

            return string.Join(", ", result);
        }

        public int CompareTo(object obj)
        {
            if (obj as ParserIssue == null) return -1;

            return ((ParserIssue)obj).Key.CompareTo(Key);
        }
    }
}