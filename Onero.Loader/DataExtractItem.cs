using System.Xml;
using System.Xml.Linq;

namespace Onero.Loader
{
    public class DataExtractItem : Rule
    {
        #region Constructors

        public DataExtractItem()
        {
        }

        public DataExtractItem(XmlNode node) : base(node)
        {
        }

        public DataExtractItem(string name, string condition) : this()
        {
        }

        #endregion

        public bool RemoveWhitespaces { get; set; }

        // TODO: Create multiple data extractor types extending DataExtractorType enum
        //public DataExtractorType DataExtractorType { get; set; }

        protected override void Parse()
        {
            base.Parse();

            if (node.Attributes["whitespaces"] != null)
            {
                RemoveWhitespaces = bool.Parse(node.Attributes["whitespaces"].Value);
            }
        }

        public override XElement Save()
        {
            var node =  base.Save();
            node.SetAttributeValue("whitespaces", RemoveWhitespaces);
            return node;
        }
    }
}
