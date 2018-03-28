using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace Onero.Tests
{
    public class BaseTest
    {
        // USAGE HINT: IF you prefer to work locally (and much quicker) - use localhost-based connection
        public const string WEBSITE_TEST_BASE = "http://demo.onero.net"; // hosts maaped

        #region Web drivers

        const string DriversFolder = @"e:\Projects\Onero\Onero\Drivers\";

        public IWebDriver FirefoxDriver
        {
            get
            {
                var ABOUT_BLANK = "about:blank";
                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.SetPreference("browser.startup.homepage", ABOUT_BLANK);
                firefoxProfile.SetPreference("startup.homepage_welcome_url", ABOUT_BLANK);
                firefoxProfile.SetPreference("startup.homepage_welcome_url.additional", ABOUT_BLANK);
                return new FirefoxDriver(firefoxProfile);
            }
        }

        protected IWebDriver PhantomDriver
        {
            get
            {
                var driverService = PhantomJSDriverService.CreateDefaultService(DriversFolder);
                driverService.HideCommandPromptWindow = true;
                return new PhantomJSDriver(driverService);
            }
        }

        #endregion

        protected IWebDriver Driver { get; set; }

        protected void Navigate(string relativeUrl)
        {
            Driver.Navigate().GoToUrl($"{WEBSITE_TEST_BASE}{relativeUrl}");
        }
    }
}
