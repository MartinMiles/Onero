using System.Xml;

namespace Onero.Loader.Broken
{
    public class BrokenStyle : Broken
    {
        #region Constructors

        public BrokenStyle() : base()
        {
        }

        public BrokenStyle(XmlNode node) : base(node)
        {
        }

        public BrokenStyle(string name, string condition) : this()
        {
        }

        #endregion
    }
}

