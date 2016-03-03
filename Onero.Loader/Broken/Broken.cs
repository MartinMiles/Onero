using System.Text.RegularExpressions;
using System.Xml;

namespace Onero.Loader.Broken
{
    //TODO: Consider get rid of Broken class as the man in the middle between BrokenLink / BrokenImage and Rule
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

        // TODO: Move to base (for Rule and Broken class) as it is shared

        public bool ShouldRunOnThePage(string url)
        {
            if (!Enabled)
                return false;

            if (RuleExecutionScope == RuleExecutionScope.Include)
            {
                foreach (var includePath in Urls)
                {
                    var includeRegex = new Regex(includePath, RegexOptions.IgnoreCase);
                    if (includeRegex.IsMatch(url.TrimEnd('/')))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (RuleExecutionScope == RuleExecutionScope.Exclude)
            {
                foreach (var excludePath in Urls)
                {
                    var includeRegex = new Regex(excludePath, RegexOptions.IgnoreCase);
                    if (includeRegex.IsMatch(url.TrimEnd('/')))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
