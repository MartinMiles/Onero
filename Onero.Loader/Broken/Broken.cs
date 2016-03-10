using System.Xml;

namespace Onero.Loader.Broken
{
    public class Broken : Rule
    {
        #region Constructors

        public Broken()
        {
            RuleExecutionScope = RuleExecutionScope.Everywhere;
        }

        public Broken(XmlNode node) : base(node)
        {
        }

        public Broken(string name, string condition) : this()
        {
        }

        #endregion
    }
}
