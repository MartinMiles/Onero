using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class DataExtractAction : BaseAction
    {
        public DataExtractAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
        }

        public override dynamic Execute()
        {
            var results = new Dictionary<DataExtractItem, string>();

            foreach (var rule in settings.DataExtractors)
            {
                if (!rule.ShouldRunOnThePage(driver.Url))
                {
                    continue;
                }

                try
                {
                    if (driver is RemoteWebDriver)
                    {
                        var element = driver.FindElement(BySelector(rule.Condition));
                        results.Add(rule, element.Text);
                    }
                }
                catch (InvalidOperationException e)
                {
                    if (e.Message.Contains("$ is not defined"))
                    {
                        //resultCode = ResultCode.NoJquery;
                    }
                    else if (e.Message.Contains("Parse error"))
                    {
                        //resultCode = ResultCode.RuleParseError;
                    }
                }
            }

            return results;
        }
    }
}
