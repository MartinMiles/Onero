using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader;
using Onero.Loader.Interfaces;

namespace Onero.Collections
{
    public class CollectionOf<T>
    {
        private const string FILE_PATH = "{0}Settings\\{1}\\{2}.xml";

        private readonly string profileName;
        private readonly string fileName;

        public CollectionOf(string profileName)
        {
            this.profileName = profileName;
            this.fileName = GetFilenameFromGenericParameterType();
        }

        private string GetFilenameFromGenericParameterType()
        {
            if (GetType().IsGenericType)
            {
                Type type = GetType().GetGenericArguments().FirstOrDefault();

                if (type == typeof (WebForm))
                {
                    return "Forms";
                }

                return string.Format("{0}s", type.Name);
            }

            return null;
        }

        private T ctor<T>(XmlNode node)
        {
            return (T)Activator.CreateInstance(typeof(T), node);
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

        internal string FilePath
        {
            get { return string.Format(FILE_PATH, PathPrefix, profileName, fileName); }
        }

        public void Create<T>()
        {
            Save(new List<T>());
        }

        public IEnumerable<T> Read<T>() where T : RuleForm, new()
        {
            var items = new List<T>();

            if (File.Exists(FilePath))
            {
                var doc = new XmlDocument();
                doc.Load(FilePath);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    items.Add(ctor<T>(node));
                }
            }

            return items;
        }

        public void Save<T>(IEnumerable<T> items)
        {
            var doc = new XDocument();
            var root = new XElement("items");
            doc.Add(root);

            foreach (INameable rule in items)
            {
                root.Add(rule.Save());
            }

            doc.Save(FilePath);
        }
    }
}
