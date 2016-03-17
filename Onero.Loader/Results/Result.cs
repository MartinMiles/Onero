using System;
using System.Collections.Generic;
using System.Linq;
using Onero.Loader.Actions;

namespace Onero.Loader.Results
{
    public class Result
    {
        public string Url { get; set; }
        public ResultCode PageResult { get; set; }
        public long PageLoadTime { get; set; }
        public Dictionary<Rule, ResultCode> RuleResults { get; set; }
        public Dictionary<WebForm, ResultCode> FormResults { get; set; }
        public Dictionary<DataExtractItem, string> DataExtracts { get; set; }
        public BrokenLinksResult BrokenLinksResult { get; set; }

        public Dictionary<Type, dynamic> GenericResults { get; set; }

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

            GenericResults = new Dictionary<Type, dynamic>();
        }

        public Result(string url) : this()
        {
            Url = url;
        }

        public override string ToString()
        {
            return $"{Url} - {IsSuccessful}";
        }
    }
}
