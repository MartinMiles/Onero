using System.Collections.Generic;

namespace Onero.Loader.Results
{
    public class BrokenLinksResult
    {
        public IEnumerable<string> Links { get; set; }
        public IEnumerable<string> Images { get; set; }
        public IEnumerable<string> Scripts { get; set; }
        public IEnumerable<string> Styles { get; set; }

        public BrokenLinksResult()
        {
            Links = new List<string>();
            Images = new List<string>();
            Scripts = new List<string>();
            Styles = new List<string>();
        }
    }
}
