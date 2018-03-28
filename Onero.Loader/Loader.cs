using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using Onero.Helper.ErrorHandling;
using Onero.Loader.Actions;
using Onero.Loader.Results;
using OpenQA.Selenium;

namespace Onero.Loader
{
    public class Loader
    {
        private readonly LoaderSettings _settings;

        #region Constructors

        public Loader()
        {
        }

        public Loader(LoaderSettings settings)
        {
            _settings = settings;
        }

        #endregion

        public void Start(BackgroundWorker backgroundWorker)
        {
            try
            {
                int order = 1;

                _settings.CleanOutputDirectory();

                var selectedDriver = new DriverFactory(_settings.Profile).Driver;

                selectedDriver.Manage().Window.Size = new Size(_settings.Profile.Width, _settings.Profile.Height);
                selectedDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(_settings.Profile.Timeout);
                //selectedDriver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, settings.Profile.Timeout));

                using (IWebDriver driver = selectedDriver)
                {
                    foreach (var page in _settings.PagesToCrawl)
                    {
                        if (backgroundWorker.CancellationPending)
                            break;

                        backgroundWorker.ReportProgress(order, RunThePage(page, driver, order));
                        order++;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                // TODO: This occurs when I close Firefox before function ends up. Implement proper solution
            }
            catch (Exception e)
            {
                new ErrorManager(_settings.Profile).Fix(e, "Loader failed");

                throw;
            }
        }

        private Result RunThePage(string page, IWebDriver driver, int order)
        {
            var result = new Result(page);
            var timer = new Stopwatch();

            try
            {
                timer.Reset();
                timer.Start();
                driver.Navigate().GoToUrl(page);
                timer.Stop();

                result.PageLoadTime = timer.ElapsedMilliseconds;

                var actions = ActionsFactory.GetActions(driver, _settings, order);
                foreach (BaseAction action in actions)
                {
                    result.GenericResults.Add(action.GetType(), action.Execute());
                }

                result.PageResult = ResultCode.Successful;
            }
            catch (WebDriverException e)
            {
                var errorMsg = e.Message.ToLower();

                result.PageResult = errorMsg.Contains("timeout") || errorMsg.Contains("timed out")
                    ? ResultCode.PageFailedFromTimeout
                    : ResultCode.PageFailed;
            }
            return result;
        }
    }
}