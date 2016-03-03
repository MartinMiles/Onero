using System.Collections.Generic;

namespace Onero.Loader.Results
{
    public class BrokenLinksResult
    {
        public IEnumerable<string> Links { get; set; }
        public IEnumerable<string> Images { get; set; }

        public BrokenLinksResult()
        {
            Links = new List<string>();
            Images = new List<string>();
        }
    }
}
