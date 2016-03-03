using System;
using System.Collections.Generic;
using Onero.Loader.Results;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class RulesExecuteAction : BaseAction
    {
        private readonly Dictionary<Rule, ResultCode> result;

        public RulesExecuteAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
            result = new Dictionary<Rule, ResultCode>();
        }

        public override dynamic Execute()
        {
            foreach (var rule in settings.Rules)
            {
                var resultCode = new ResultCode();

                if (!rule.ShouldRunOnThePage(driver.Url))
                {
                    continue;
                }

                try
                {
                    if (driver is RemoteWebDriver)
                    {
                        string condition = rule.Condition.StartsWith("return") ? rule.Condition : $"return {rule.Condition}";
                        var returnedJSobject = (driver as RemoteWebDriver).ExecuteScript(condition);
                        resultCode = ValidateRule(returnedJSobject) ? ResultCode.Successful : ResultCode.RuleFailed;
                    }
                }
                catch (InvalidOperationException e)
                {
                    if (e.Message.Contains("$ is not defined"))
                    {
                        resultCode = ResultCode.NoJquery;
                    }
                    else if (e.Message.Contains("Parse error"))
                    {
                        resultCode = ResultCode.RuleParseError;
                    }
                }

                result.Add(rule, resultCode);
            }

            return result;
        }

        private bool ValidateRule(object javascriptObject)
        {
            bool b;
            int i;

            if (bool.TryParse(javascriptObject.ToString(), out b))
            {
                return b;
            }

            if (int.TryParse(javascriptObject.ToString(), out i))
            {
                return i > 0;
            }

            return false;
        }
    }
}
