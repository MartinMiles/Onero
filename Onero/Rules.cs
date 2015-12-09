using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Onero.Crawler;

namespace Onero
{
    public static class Rules
    {
        public static string FilePath
        {
            get { return string.Format("{0}Settings\\JavascriptRules.xml", PathPrefix); }
        }

        private static string PathPrefix
        {
            get
            {
                string prefix = String.Empty;

                #if (DEBUG)
                    prefix = "..\\..\\";
                #endif

                return prefix;
            }
        }

        public static IEnumerable<Rule> Read()
        {
            var doc = new XmlDocument();
            doc.Load(FilePath);

            var rules = new List<Rule>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                rules.Add(new Rule(node));
            }

            return rules;
        }

        public static void Save(IEnumerable<Rule> rules)
        {
            var doc = new XDocument();
            var root = new XElement("rules");
            doc.Add(root);

            foreach (Rule rule in rules)
            {
                root.Add(rule.Save());
            }

            doc.Save(FilePath);
        }
    }
}
