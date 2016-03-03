using System.Xml;

namespace Onero.Loader.Broken
{
    public class BrokenImage : Broken
    {
        #region Constructors

        public BrokenImage() : base()
        {
        }

        public BrokenImage(XmlNode node) : base(node)
        {
        }

        public BrokenImage(string name, string condition) : this()
        {
        }

        #endregion
    }
}
