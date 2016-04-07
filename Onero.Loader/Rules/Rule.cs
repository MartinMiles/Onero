using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Onero.Loader
{
    public class Rule : BaseItem
    {
        internal static class Attributes
        {
            internal const string NAME = "name";
            internal const string TYPE = "type";
            internal const string ENABLED = "enabled";
            internal const string CONDITION = "condition";
        }

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
            Name = name;
            Condition = condition;
        }

        #endregion

        #region Properties

        public List<string> Urls { get; set; }

        public RuleExecutionScope RuleExecutionScope { get; set; }

        public string Condition { get; set; }

        #endregion

        public string NameWithPrefix => ruleScopePrefixes[RuleExecutionScope] + Name;

        public bool ShouldRunOnThePage(string url)
        {
            if (!Enabled)
                return false;

            if (RuleExecutionScope == RuleExecutionScope.Include)
            {
                return Urls.Select(u => new Regex(u.TrimEnd('/'), RegexOptions.IgnoreCase)).Any(r => r.IsMatch(url.TrimEnd('/')));
            }

            if (RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                return Urls.Select(u => new Regex(u.TrimEnd('/'), RegexOptions.IgnoreCase)).All(r => !r.IsMatch(url.TrimEnd('/')));
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

        protected override void Parse()
        {
            Name = node.StringAttribute(Attributes.NAME);
            Enabled = node.BoolAttribute(Attributes.ENABLED);

            Condition = GetTextValue(node.ChildNodes).Trim();

            var _type = node.ParseEnum<RuleExecutionScope>(Attributes.TYPE);

            if (node.Attributes[Attributes.TYPE] != null)
            {
                var type = node.Attributes[Attributes.TYPE].Value.ToLower().Trim();

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

        public override XElement Save()
        {
            var node = new XElement("rule");
            node.SetAttributeValue(Attributes.NAME, Name);
            node.SetAttributeValue(Attributes.ENABLED, Enabled);
            node.Add(new XElement(Attributes.CONDITION, Condition));

            if (RuleExecutionScope == RuleExecutionScope.Include || RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                node.SetAttributeValue(Attributes.TYPE, RuleExecutionScope == RuleExecutionScope.Include ? "include" : "exclude");

                foreach (string url in Urls)
                {
                    node.Add(new XElement("url", url));
                }
            }

            return node;
        }
    }
}
