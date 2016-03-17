using System;
using System.Collections.Generic;
using Onero.Loader.Results;
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
            var _results = new List<DataExtractResult>();

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
                        _results.Add(new DataExtractResult(rule, driver.Url, ResultCode.Successful, element.Text));
                    }
                }
                // TODO: Work out OTHER exceptions and errors; test unusual use-cases
                catch (InvalidOperationException e)
                {
                    if (e.Message.Contains("$ is not defined"))
                    {
                        _results.Add(new DataExtractResult(ResultCode.NoJquery));
                    }
                    else if (e.Message.Contains("Parse error"))
                    {
                        _results.Add(new DataExtractResult(ResultCode.RuleParseError));
                    }
                }
            }

            return _results;
        }
    }
}
