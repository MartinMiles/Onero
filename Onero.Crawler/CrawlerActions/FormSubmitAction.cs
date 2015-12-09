using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Onero.Crawler.Results;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Crawler.CrawlerActions
{
    public class FormSubmitAction : BaseCrawlerAction
    {
        private readonly Dictionary<WebForm, ResultCode> result;

        public FormSubmitAction(RemoteWebDriver driver, CrawlerSettings settings) : base(driver, settings)
        {
            result = new Dictionary<WebForm, ResultCode>();
        }

        public override dynamic Execute()
        {
            // for the moment we can submit only one form per page as it redirects to result
            // thus find first form that matches current url and process it if found

            if (settings.Forms != null)
            {
                foreach (WebForm pageForm in settings.Forms)
                {
                    foreach (string url in pageForm.Urls)
                    {
                        var regexUrl = new Regex(url, RegexOptions.IgnoreCase);

                        if (regexUrl.IsMatch(driver.Url.TrimEnd('/')))
                        {
                            var resultCode = ResultCode.NotFinished;

                            try
                            {
                                foreach (var field in pageForm.Fields)
                                {
                                    var element = driver.FindElement(BySelector(field.Id));
                                    element.SendKeys(field.Value);
                                }

                                if (!string.IsNullOrEmpty(pageForm.SubmitId))
                                {
                                    var element = driver.FindElement(BySelector(pageForm.SubmitId));
                                    element.Click();
                                }

                                if (pageForm.ResultParameters.ResultType == FormResultType.Redirect)
                                {
                                    var regexResultUrl = new Regex(pageForm.ResultParameters.Url.Trim('/'), RegexOptions.IgnoreCase);
                                    resultCode = regexResultUrl.IsMatch(driver.Url) ? ResultCode.Successfull : ResultCode.RedirectUrlMismatch;
                                }
                                else if (pageForm.ResultParameters.ResultType == FormResultType.Message)
                                {
                                    // that one works OK
                                    driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

                                    resultCode = driver.FindElement(By.Id(pageForm.ResultParameters.Id)).Text.Contains(pageForm.ResultParameters.Message)
                                        ? ResultCode.Successfull
                                        : ResultCode.ElementNotFound;

                                    if(!string.IsNullOrWhiteSpace(pageForm.ResultParameters.Url) && driver.Url.Trim('/').ToLower() != pageForm.ResultParameters.Url.ToLower().Trim('/'))
                                    {
                                        resultCode = ResultCode.FormResultUrlMissmatch;
                                    }
                                }
                            }
                            catch (NoSuchElementException e)
                            {
                                resultCode = ResultCode.ElementNotFound;
                            }

                            result.Add(pageForm, resultCode);
                        }
                    }
                }
            }

            return result;
        }

        private By BySelector(string selector)
        {
            switch (selector.First())
            {
                case '#': return By.Id(selector.TrimStart('#'));
                case '.': return By.ClassName(selector.TrimStart('.'));
                default: return By.TagName(selector);
            }
        }
    }
}
