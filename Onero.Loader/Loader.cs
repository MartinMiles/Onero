using System;
using System.ComponentModel;
using System.Diagnostics;
using Onero.Loader.Actions;
using Onero.Loader.Results;
using OpenQA.Selenium;

namespace Onero.Loader
{
    public class Loader
    {
        private readonly LoaderSettings settings;

        #region Constructors

        public Loader()
        {
        }

        public Loader(LoaderSettings settings)
        {
            this.settings = settings;
        }

        #endregion

        public void Start(BackgroundWorker backgroundWorker)
        {
            try
            {
                int order = 1;

                settings.CleanOutputDirectory();

                using (IWebDriver driver = new DriverFactory(settings.Profile).Driver)
                {
                    driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, settings.Profile.Timeout));

                    var timer = new Stopwatch();

                    foreach (var page in settings.PagesToCrawl)
                    {
                        if (backgroundWorker.CancellationPending)
                            break;

                        var result = new Result(page);

                        try
                        {
                            timer.Reset();
                            timer.Start();
                            driver.Navigate().GoToUrl(page);
                            timer.Stop();

                            result.PageLoadTime = timer.ElapsedMilliseconds;

                            bool urlResult = true;

                            //TODO: Later move to actions factory
                            if (settings.Profile.CreateScreenshots)
                            {
                                var screenshotAction = new MakeScreenshotAction(driver, settings)  { Order = order };
                                screenshotAction.Execute();
                            }

                            var brokenLinksAction = new BrokenLinksAction(driver, settings);
                            result.BrokenLinksResult = brokenLinksAction.Execute();

                            var rulesAction = new RulesExecuteAction(driver, settings);
                            result.RuleResults = rulesAction.Execute();

                            var formsAction = new FormSubmitAction(driver, settings);
                            result.FormResults = formsAction.Execute();

                            result.PageResult = ResultCode.Successful;
                        }
                        catch (WebDriverException e)
                        {
                            var errorMsg = e.Message.ToLower();

                            result.PageResult = errorMsg.Contains("timeout") || errorMsg.Contains("timed out")
                                ? ResultCode.PageFailedFromTimeout 
                                : ResultCode.PageFailed;
                        }

                        backgroundWorker.ReportProgress(order, result);
                        order++;
                    }
                }
            }
            catch (Exception e)
            {
                if (settings.Profile.CreateErrorLog)
                {
                    Logger.Log(e);
                }
            }
        }
    }
}