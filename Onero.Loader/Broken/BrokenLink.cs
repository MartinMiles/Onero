using System.Xml;

namespace Onero.Loader.Broken
{
    public class BrokenLink : Broken
    {
        #region Constructors

        public BrokenLink()
        {
        }

        public BrokenLink(XmlNode node) : base(node)
        {
        }

        public BrokenLink(string name, string condition) : this()
        {
        }

        #endregion
    }
}
