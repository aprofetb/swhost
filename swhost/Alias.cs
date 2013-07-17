using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace swhost
{
    internal enum Status { unknown = 0, devel = 1, test = 2, prod = 3, mixed = 4 };
    internal class Alias
    {
        #region statics
        public static Regex AliasRegex = new Regex(@"^[\s\t]*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?[\s\t]+([^\s\t]+?)[\s\t]*#[\s\t]*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?[\s\t]*;[\s\t]*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?[\s\t]*;[\s\t]*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?[\s\t]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static Alias GetInstance(string line, int lineNumber)
        {
            Match m = AliasRegex.Match(line);
            string currIp = m.Groups[1].Value;
            string dns = m.Groups[2].Value;
            string develIp = m.Groups[3].Value;
            string testIp = m.Groups[4].Value;
            string prodIp = m.Groups[5].Value;
            return m.Success ? new Alias(dns, currIp, develIp, testIp, prodIp, lineNumber) : null;
        }
        #endregion

        private string dns;
        private string currIp;
        private string develIp;
        private string testIp;
        private string prodIp;
        private int lineNumber;
        private bool deleted;

        public Alias(string dns, string currIp, string develIp, string testIp, string prodIp, int lineNumber)
        {
            this.dns = dns;
            this.currIp = currIp;
            this.develIp = develIp;
            this.testIp = testIp;
            this.prodIp = prodIp;
            this.lineNumber = lineNumber;
            this.deleted = false;
        }

        public string Dns
        {
            get { return dns; }
            set { dns = value; }
        }

        public string CurrIp
        {
            get { return currIp; }
            set { currIp = value; }
        }

        public string DevelIp
        {
            get { return develIp; }
            set { develIp = value; }
        }

        public string TestIp
        {
            get { return testIp; }
            set { testIp = value; }
        }

        public string ProdIp
        {
            get { return prodIp; }
            set { prodIp = value; }
        }

        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        public Status Status
        {
            get { return currIp == develIp ? Status.devel : currIp == testIp ? Status.test : currIp == prodIp ? Status.prod : Status.unknown; }
            set { currIp = value == Status.devel ? develIp : value == Status.test ? testIp : prodIp; }
        }

        public string[] ListViewSubItems
        {
            get { return new string[] { dns, currIp, develIp, testIp, prodIp, Status.ToString() }; }
        }

        public string Line
        {
            get { return String.Format("{0}{1}#{2};{3};{4}", (Status == Status.devel ? develIp : Status == Status.test ? testIp : Status == Status.prod ? prodIp : "").PadRight(23), dns.PadRight(40), develIp, testIp, prodIp); }
        }
    }
}
