﻿using System;
using System.Collections.Generic;
using Onero.Loader.Results;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class RulesExecuteAction : BaseAction
    {
        private readonly Dictionary<Rule, ResultCode> result;

        public RulesExecuteAction(RemoteWebDriver driver, LoaderSettings settings) : base(driver, settings)
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
                    string condition = rule.Condition.StartsWith("return") ? rule.Condition : string.Format("return {0}", rule.Condition);
                    var returnedJSobject = driver.ExecuteScript(condition);
                    resultCode = ValidateRule(returnedJSobject) ? ResultCode.Successfull : ResultCode.RuleFailed;
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