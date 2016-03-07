using System.Xml;

namespace Onero.Loader.Broken
{
    public class BrokenScript : Broken
    {
        #region Constructors

        public BrokenScript() : base()
        {
        }

        public BrokenScript(XmlNode node) : base(node)
        {
        }

        public BrokenScript(string name, string condition) : this()
        {
        }

        #endregion
    }
}
