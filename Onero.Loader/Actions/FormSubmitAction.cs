using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Onero.Loader.Results;
using OpenQA.Selenium;

namespace Onero.Loader.Actions
{
    public class FormSubmitAction : BaseAction
    {
        private readonly Dictionary<WebForm, ResultCode> result;

        public FormSubmitAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
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
                            var oldUrl = driver.Url.TrimEnd('/');

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
                                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));                                    
                                    element.Click();
                                }

                                if (pageForm.ResultParameters.ResultType == FormResultType.Redirect)
                                {
                                    var regexResultUrl = new Regex(pageForm.ResultParameters.Url.Trim('/'), RegexOptions.IgnoreCase);

                                    //TODO: Refactor this to somehing properly handling redirect - while URL not changes instead of
                                    int i = 0;
                                    while (i <= settings.Profile.Timeout * 10 && oldUrl == driver.Url.TrimEnd('/'))
                                    {
                                        Thread.Sleep(100);
                                        i++;
                                    }

                                    resultCode = regexResultUrl.IsMatch(driver.Url.TrimEnd('/')) ? ResultCode.Successful : ResultCode.RedirectUrlMismatch;
                                    //if (resultCode == ResultCode.RedirectUrlMismatch)
                                    //{
                                    //    artefact = driver.Url.TrimEnd('/');
                                    //}


                                    // also need to make sure url did not chage
                                    if (resultCode == ResultCode.Successful)
                                    {
                                        driver.Navigate().Back();
                                    }
                                    else
                                    {
                                        //var k = driver.Url;
                                    }
                                }
                                else if (pageForm.ResultParameters.ResultType == FormResultType.Message)
                                {
                                    driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

                                    var element = driver.FindElement(BySelector(pageForm.ResultParameters.Id));
                                    var regex = new Regex(pageForm.ResultParameters.Message, RegexOptions.IgnoreCase);
                                    resultCode = regex.IsMatch(element.Text) ? ResultCode.Successful : ResultCode.ElementNotFound;

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
    }
}
