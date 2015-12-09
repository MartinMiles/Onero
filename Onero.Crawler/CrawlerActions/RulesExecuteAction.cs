using System;
using System.Collections.Generic;
using Onero.Crawler.Results;
using OpenQA.Selenium.Remote;

namespace Onero.Crawler.CrawlerActions
{
    public class RulesExecuteAction : BaseCrawlerAction
    {
        private readonly Dictionary<Rule, ResultCode> result;

        public RulesExecuteAction(RemoteWebDriver driver, CrawlerSettings settings) : base(driver, settings)
        {
            result = new Dictionary<Rule, ResultCode>();
        }

        public override dynamic Execute()
        {
            foreach (var rule in settings.Rules)
            {
                var code = new ResultCode();

                if (!rule.ShouldRunOnThePage(driver.Url))
                {
                    continue;
                }

                try
                {
                    var returnedJSobject = driver.ExecuteScript(rule.Condition);

                    int jquerySelectorObjectCount;
                    int.TryParse(returnedJSobject.ToString(), out jquerySelectorObjectCount);
                    code = jquerySelectorObjectCount > 0 ? ResultCode.Successfull : ResultCode.RuleFailed;
                }
                catch (InvalidOperationException e)
                {
                    if (e.Message.Contains("$ is not defined"))
                    {
                        code = ResultCode.NoJquery;
                    }
                    else if (e.Message.Contains("Parse error"))
                    {
                        code = ResultCode.RuleParseError;
                    }
                }

                result.Add(rule, code);
            }

            return result;
        }
    }
}
