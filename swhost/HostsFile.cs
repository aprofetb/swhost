using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace swhost
{
    class HostsFile
    {
        string fullPath;
        List<string> lines;
        List<Alias> aliases;

        public HostsFile(string fullPath)
        {
            this.fullPath = fullPath;
            this.lines = new List<string>();
            this.aliases = new List<Alias>();
        }

        public string FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }

        public List<string> Lines
        {
            get { return lines; }
        }

        public List<Alias> Aliases
        {
            get { return aliases; }
        }

        public Status Load()
        {
            lines.Clear();
            aliases.Clear();
            StreamReader sr = new StreamReader(fullPath);
            Status status = Status.unknown;
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                Alias alias = Alias.GetInstance(line, lines.Count);
                if (alias != null)
                {
                    aliases.Add(alias);
                    status |= alias.Status;
                }
                lines.Add(line);
            }
            sr.Close();
            return status;
        }

        public void Save()
        {
            Save(Status.unknown);
        }

        public void Save(Status status)
        {
            foreach (Alias alias in aliases)
            {
                if (status != Status.unknown)
                    alias.Status = status;
                lines[alias.LineNumber] = alias.Deleted ? "#deleted" : alias.Line;
            }
            StreamWriter sw = new StreamWriter(fullPath, false);
            foreach (string line in lines)
                if (line != "#deleted")
                    sw.WriteLine(line);
            sw.Close();
        }
    }
}
