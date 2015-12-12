using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Onero.Loader.Results;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class FormSubmitAction : BaseAction
    {
        private readonly Dictionary<WebForm, ResultCode> result;

        public FormSubmitAction(RemoteWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
            result = new Dictionary<WebForm, ResultCode>();
        }

        public override dynamic Execute()
        {
            if (settings.Forms != null)
            {
                foreach (WebForm pageForm in settings.Forms)
                {
                    foreach (string url in pageForm.Urls)
                    {
                        var regexUrl = new Regex(url, RegexOptions.IgnoreCase);

                        var currentUrl = HttpUtility.UrlDecode(driver.Url).TrimEnd('/');

                        if (regexUrl.IsMatch(currentUrl))
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

                                    // also need to make sure url did not chage
                                    if (resultCode == ResultCode.Successfull)
                                    {
                                        driver.Navigate().Back();
                                    }
                                }
                                else if (pageForm.ResultParameters.ResultType == FormResultType.Message)
                                {
                                    driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

                                    var element = driver.FindElement(BySelector(pageForm.ResultParameters.Id));
                                    var regex = new Regex(pageForm.ResultParameters.Message, RegexOptions.IgnoreCase);
                                    resultCode = regex.IsMatch(element.Text) ? ResultCode.Successfull : ResultCode.ElementNotFound;

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
