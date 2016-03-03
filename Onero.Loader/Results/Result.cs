using System.Collections.Generic;
using System.Linq;

namespace Onero.Loader.Results
{
    public class Result
    {
        public string Url { get; set; }
        public ResultCode PageResult { get; set; }
        public long PageLoadTime { get; set; }
        public Dictionary<Rule, ResultCode> RuleResults { get; set; }
        public Dictionary<WebForm, ResultCode> FormResults { get; set; }

        public BrokenLinksResult BrokenLinksResult { get; set; }

        public bool IsSuccessful
        {
            get
            {
                bool allRules = RuleResults.All(r=>r.Value == ResultCode.Successful);
                bool allForms = FormResults.All(r=>r.Value == ResultCode.Successful);
                bool allLinks = !BrokenLinksResult.Images.Any() && !BrokenLinksResult.Links.Any();
                return allRules && allForms && allLinks;
            }
        }

        public Result()
        {
            PageResult = ResultCode.NotFinished;
            RuleResults = new Dictionary<Rule, ResultCode>();
            FormResults = new Dictionary<WebForm, ResultCode>();
            BrokenLinksResult = new BrokenLinksResult();
        }

        public Result(string url) : this()
        {
            Url = url;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Url, IsSuccessful);
        }
    }
}
