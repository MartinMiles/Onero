using System.IO;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader.Interfaces;
using Onero.Loader;

namespace Onero
{
    public class Profile : IProfile
    {
        private const string ENABLED_ATTRIBUTE_NAME = "enabled";
        private const string VALUE_ATTRIBUTE_NAME = "value";

        // TODO: This duplicates another profile or smth having DEFAULT_WIDTH - investigate why and remove redundancy
        private const int TIMEOUT = 60;
        private const int WIDTH = 1920;
        private const int HEIGHT = 1080;
        
        #region Constructors

        public Profile(string name)
        {
            Name = name;

            OutputDirectory = $"{Directory.GetCurrentDirectory()}\\Results\\{Name}";
            Timeout = TIMEOUT;
            Width = WIDTH;
            Height = HEIGHT;
            CreateErrorLog = true;
            Browser = Browser.Firefox;
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
                if (node.Name == "Width")
                {
                    Width = node.IntAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "Height")
                {
                    Height = node.IntAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "OutputDirectory")
                {
                    OutputDirectory = node.StringAttribute(VALUE_ATTRIBUTE_NAME);
                }
                if (node.Name == "FindAllBrokenLinks")
                {
                    FindAllBrokenLinks = node.BoolAttribute(VALUE_ATTRIBUTE_NAME, true);
                }
                if (node.Name == "FindAllBrokenImages")
                {
                    FindAllBrokenImages = node.BoolAttribute(VALUE_ATTRIBUTE_NAME, true);
                }
            }
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Timeout { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool CreateScreenshots { get; set; }

        public bool VerboseMode { get; set; }

        public bool CreateErrorLog { get; set; }

        public Browser Browser { get; set; }

        public string OutputDirectory { get; set; }

        public bool FindAllBrokenLinks { get; set; }

        public bool FindAllBrokenImages { get; set; }

        public bool FindAllBrokenScripts { get; set; }

        public bool FindAllBrokenStyles { get; set; }

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

            var width = new XElement("Width");
            width.SetAttributeValue("value", Width);
            root.Add(width);

            var height = new XElement("Height");
            height.SetAttributeValue("value", Height);
            root.Add(height);

            var testAllLinks = new XElement("FindAllBrokenLinks");
            testAllLinks.SetAttributeValue("value", FindAllBrokenLinks);
            root.Add(testAllLinks);

            var testAllImages = new XElement("FindAllBrokenImages");
            testAllImages.SetAttributeValue("value", FindAllBrokenImages);
            root.Add(testAllImages);

            var testAllScripts = new XElement("FindAllBrokenScripts");
            testAllScripts.SetAttributeValue("value", FindAllBrokenScripts);
            root.Add(testAllScripts);

            var testAllStyles = new XElement("FindAllBrokenStyles");
            testAllStyles.SetAttributeValue("value", FindAllBrokenStyles);
            root.Add(testAllStyles);

            doc.Add(root);
            doc.Save(fileName); 
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
