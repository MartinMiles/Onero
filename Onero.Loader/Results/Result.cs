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

        public Dictionary<Rule, ResultCode> RuleResults => GenericResults[typeof (RulesExecuteAction)] as Dictionary<Rule, ResultCode>;
        public Dictionary<WebForm, ResultCode> FormResults => GenericResults[typeof(FormSubmitAction)] as Dictionary<WebForm, ResultCode>;
        public Dictionary<DataExtractItem, string> DataExtracts { get; set; }
        public BrokenLinksResult BrokenLinksResult { get; set; }

        public Dictionary<Type, dynamic> GenericResults { get; set; }

        public bool IsSuccessful => AreValid<RulesExecuteAction, Rule>() 
            && AreValid<FormSubmitAction, WebForm>() 
            && AreValid<BrokenLinksAction, object>();

        private bool AreValid<T, U>()
        {
            if (typeof (T) == typeof (BrokenLinksAction))
            {
                var result = GenericResults[typeof (T)] as BrokenLinksResult;
                return !(result.Links.Any() || result.Images.Any() || result.Scripts.Any() || result.Styles.Any());
            }

            // TODO: Breaks here if forms submission is terminated by exception and forms reulsts do not exist
            return (GenericResults[typeof (T)] as Dictionary<U, ResultCode>).All(r => r.Value == ResultCode.Successful);
        }

        public Result()
        {
            PageResult = ResultCode.NotFinished;
            //RuleResults = new Dictionary<Rule, ResultCode>();
            //FormResults = new Dictionary<WebForm, ResultCode>();
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
