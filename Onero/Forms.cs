using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Onero.Crawler;

namespace Onero
{
    public class Forms
    {
        public static string FilePath
        {
            get { return string.Format("{0}Settings\\WebForms.xml", PathPrefix); }
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

        public static List<WebForm> Read()
        {
            var doc = new XmlDocument();
            doc.Load(FilePath);

            var forms = new List<WebForm>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                forms.Add(new WebForm(node));
            }

            return forms;
        }
        
        public static void Save(IEnumerable<WebForm> forms)
        {
            var doc = new XDocument();
            var root = new XElement("forms");
            doc.Add(root);

            foreach (WebForm form in forms)
            {
                root.Add(form.Save());
            }

            doc.Save(FilePath);
        }
    }
}
