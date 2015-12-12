using System;
using System.ComponentModel;
using System.Diagnostics;
using Onero.Loader.Actions;
using Onero.Loader.Results;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Onero.Loader
{
    public class Loader
    {
        private readonly LoaderSettings settings;
        private const string ABOUT_BLANK = "about:blank";

        #region Constructors

        public Loader()
        {
        }

        public Loader(LoaderSettings settings)
        {
            this.settings = settings;
        }

        #endregion

        #region Selenium properties

        private RemoteWebDriver _driver;

        public RemoteWebDriver Driver
        {
            get
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.SetPreference("browser.startup.homepage", ABOUT_BLANK);
                profile.SetPreference("startup.homepage_welcome_url", ABOUT_BLANK);
                profile.SetPreference("startup.homepage_welcome_url.additional", ABOUT_BLANK);

                return _driver ?? (_driver = settings.Profile.RunInBrowser ? (RemoteWebDriver)new FirefoxDriver(profile) : PhantomDriver);
            }
        }

        public RemoteWebDriver ChromeDriver
        {
            get
            {
                ChromeOptions profile = new ChromeOptions();
                //profile.SetPreference("browser.startup.homepage", ABOUT_BLANK);
                //profile.SetPreference("startup.homepage_welcome_url", ABOUT_BLANK);
                //profile.SetPreference("startup.homepage_welcome_url.additional", ABOUT_BLANK);

                return _driver ?? (_driver = settings.Profile.RunInBrowser ? (RemoteWebDriver)new ChromeDriver(profile) : PhantomDriver);
            }
        }

        private PhantomJSDriver PhantomDriver
        {
            get
            {
                var driverService = PhantomJSDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                return new PhantomJSDriver(driverService);                
            }
        }

        #endregion



        public void Start(BackgroundWorker backgroundWorker)
        {
            try
            {
                int order = 1;

                settings.CleanOutputDirectory();

                using (var driver = Driver)
                {
                    driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, settings.Profile.Timeout));

                    var timer = new Stopwatch();

                    foreach (var page in settings.PagesToCrawl)
                    {
                        if (backgroundWorker.CancellationPending)
                            break;

                        var _newResult = new Result(page);

                        try
                        {
                            timer.Reset();
                            timer.Start();
                            driver.Navigate().GoToUrl(page);
                            timer.Stop();

                            _newResult.PageLoadTime = timer.ElapsedMilliseconds;

                            bool urlResult = true;

                            //TODO: Later move to actions factory
                            if (settings.Profile.CreateScreenshots)
                            {
                                var screenshotAction = new MakeScreenshotAction(driver, settings)  { Order = order };
                                screenshotAction.Execute();
                            }

                            var rulesAction = new RulesExecuteAction(driver, settings);
                            _newResult.RuleResults = rulesAction.Execute();

                            var formsAction = new FormSubmitAction(driver, settings);
                            _newResult.FormResults = formsAction.Execute();

                            _newResult.PageResult = ResultCode.Successfull;
                        }
                        catch (WebDriverException e)
                        {
                            var errorMsg = e.Message.ToLower();

                            _newResult.PageResult = errorMsg.Contains("timeout") || errorMsg.Contains("timed out")
                                ? ResultCode.PageFailedFromTimeout 
                                : ResultCode.PageFailed;
                        }

                        backgroundWorker.ReportProgress(order, _newResult);
                        order++;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
        }
    }
}