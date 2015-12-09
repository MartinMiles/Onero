using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Onero.Crawler
{
    public class Rule : INameable
    {
        public List<string> Urls { get; set; }

        #region Constructors

        private Rule()
        {
            RuleExecutionScope = RuleExecutionScope.Everywhere;
        }

        public Rule(string name, string condition) : this()
        {
        }

        public Rule(XmlNode node) : this()
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
        }

        #endregion

        #region Properties

        public RuleExecutionScope RuleExecutionScope { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Condition { get; set; }

        #endregion

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

        public XElement Save()
        {
            var node = new XElement("rule");
            node.SetAttributeValue("name", Name);
            node.SetAttributeValue("type", RuleExecutionScope == RuleExecutionScope.Include ? "include" : "exclude");
            node.SetAttributeValue("enabled", Enabled);
            node.Add(new XElement("condition", Condition));

            if (RuleExecutionScope == RuleExecutionScope.Include || RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                foreach (string url in Urls)
                {
                    node.Add(new XElement("url", url));
                }
            }

            return node;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
