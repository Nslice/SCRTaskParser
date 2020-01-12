using System.Collections.Generic;

namespace TaskParser
{
    internal class ReplicationInfo
    {
        private List<string> tasks;
        public string Creator { get; set; }
        public List<string> TaskList { get { return tasks; } }

        public ReplicationInfo()
        {
            tasks = new List<string>();
        }
    }
}