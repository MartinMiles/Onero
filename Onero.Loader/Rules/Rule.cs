using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader.Interfaces;

namespace Onero.Loader
{
    public class RuleForm : INameable
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        protected XmlNode node;

        #region Contructors

        protected RuleForm()
        {
        }

        public RuleForm(XmlNode node)
        {
            this.node = node;

            Parse();
        }

        #endregion

        public virtual XElement Save()
        {
            throw new NotImplementedException("Should be implemened in derived class");
        }

        protected virtual void Parse()
        {
            throw new NotImplementedException("Should be implemened in derived class");
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Rule : RuleForm
    {
        private readonly Dictionary<RuleExecutionScope, string> ruleScopePrefixes = new Dictionary<RuleExecutionScope, string>
        {
            {RuleExecutionScope.Everywhere, " -  [ALL]  -  "},
            {RuleExecutionScope.Include, " -  [Incl]   -  "},
            {RuleExecutionScope.Exclude, " -  [Excl]  -  "}
        }; 

        #region Constructors

        public Rule()
        {
            RuleExecutionScope = RuleExecutionScope.Everywhere;
        }

        public Rule(XmlNode node) : base(node)
        {
        }

        public Rule(string name, string condition) : this()
        {
        }

        protected override void Parse()
        {
            Name = node.Attributes["name"].Value;

            if (node.Attributes["enabled"] != null)
            {
                Enabled = bool.Parse(node.Attributes["enabled"].Value);
            }

            Condition = GetTextValue(node.ChildNodes).Trim();

            if (node.Attributes["type"] != null)
            {
                var type = node.Attributes["type"].Value.ToLower().Trim();

                Urls = new List<string>();

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.ToLower() == "url")
                    {
                        Urls.Add(child.InnerText.Trim());
                        RuleExecutionScope = type == "include" ? RuleExecutionScope.Include : RuleExecutionScope.Exclude;
                    }
                }
            }
            else
            {
                RuleExecutionScope = RuleExecutionScope.Everywhere;
            }
        }


        //public Rule(XmlNode node) : this()
        //{
 
        //}

        #endregion

        #region Properties

        public List<string> Urls { get; set; }

        public RuleExecutionScope RuleExecutionScope { get; set; }

        public string Condition { get; set; }

        #endregion

        public string NameWithPrefix
        {
            get { return ruleScopePrefixes[RuleExecutionScope] + Name; }
        }

        public bool ShouldRunOnThePage(string url)
        {
            if (!Enabled)
                return false;

            if (RuleExecutionScope == RuleExecutionScope.Include)
            {
                foreach (var includePath in Urls)
                {
                    var includeRegex = new Regex(includePath, RegexOptions.IgnoreCase);
                    if (includeRegex.IsMatch(url.TrimEnd('/')))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                foreach (var excludePath in Urls)
                {
                    var includeRegex = new Regex(excludePath, RegexOptions.IgnoreCase);
                    if (includeRegex.IsMatch(url.TrimEnd('/')))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string GetTextValue(XmlNodeList list)
        {
            foreach (XmlNode node in list)
            {
                if (node.Name.ToLower() == "condition")
                {
                    return node.InnerText;
                }
            }

            return String.Empty;
        }

        public override XElement Save()
        {
            var node = new XElement("rule");
            node.SetAttributeValue("name", Name);
            node.SetAttributeValue("enabled", Enabled);
            node.Add(new XElement("condition", Condition));

            if (RuleExecutionScope == RuleExecutionScope.Include || RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                node.SetAttributeValue("type", RuleExecutionScope == RuleExecutionScope.Include ? "include" : "exclude");

                foreach (string url in Urls)
                {
                    node.Add(new XElement("url", url));
                }
            }

            return node;
        }
    }
}
