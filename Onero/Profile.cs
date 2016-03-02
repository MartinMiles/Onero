using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader.Interfaces;
using Onero.Extensions;
using Onero.Loader;

namespace Onero
{
    public class Profile : IProfile
    {
        private const string ENABLED_ATTRIBUTE_NAME = "enabled";
        private const string VALUE_ATTRIBUTE_NAME = "value";

        #region Constructors

        public Profile(string name)
        {
            Name = name;
        }

        public Profile(string name, string profileSettingsFile) : this(name)
        {
            var doc = new XmlDocument();
            doc.Load(profileSettingsFile);

            Enabled = doc.DocumentElement.BoolAttribute(ENABLED_ATTRIBUTE_NAME);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name == "Screenshots")
                {
                    CreateScreenshots = node.BoolAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "VerboseMode")
                {
                    VerboseMode = node.BoolAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "CreateErrorLog")
                {
                    CreateErrorLog = node.BoolAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "Browser")
                {
                    Browser = node.ParseEnum<Browser>(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "Timeout")
                {
                    Timeout = node.IntAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "OutputDirectory")
                {
                    OutputDirectory = node.StringAttribute(VALUE_ATTRIBUTE_NAME);
                }
            }
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Timeout { get; set; }

        public bool CreateScreenshots { get; set; }

        public bool VerboseMode { get; set; }

        public bool CreateErrorLog { get; set; }

        public Browser Browser { get; set; }

        public string OutputDirectory { get; set; }

        #endregion

        public void Save(string fileName)
        {
            var doc = new XDocument();

            var root = new XElement("profile");
            if (Enabled)
            {
                root.SetAttributeValue("enabled", true);
            }

            var screenshots = new XElement("Screenshots");
            screenshots.SetAttributeValue("value", CreateScreenshots);
            root.Add(screenshots);

            var verbose = new XElement("VerboseMode");
            verbose.SetAttributeValue("value", VerboseMode);
            root.Add(verbose);

            var createErrorLog = new XElement("CreateErrorLog");
            createErrorLog.SetAttributeValue("value", CreateErrorLog);
            root.Add(createErrorLog);

            var browser = new XElement("Browser");
            browser.SetAttributeValue("value", Browser);
            root.Add(browser);

            var outputDirectory = new XElement("OutputDirectory");
            outputDirectory.SetAttributeValue("value", OutputDirectory);
            root.Add(outputDirectory);

            var timeout = new XElement("Timeout");
            timeout.SetAttributeValue("value", Timeout);
            root.Add(timeout);

            doc.Add(root);
            doc.Save(fileName); 
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
