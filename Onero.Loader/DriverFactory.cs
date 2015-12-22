using System;
using Onero.Loader.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Onero.Loader
{
    public class DriverFactory
    {
        private const string ABOUT_BLANK = "about:blank";

        private RemoteWebDriver _driver;
        private readonly IProfile _profile;

        public DriverFactory(IProfile profile)
        {
            _profile = profile;
        }

        public RemoteWebDriver Driver
        {
            get { return _driver ?? (_driver = ResolveDriver()); }
        }

        private RemoteWebDriver ResolveDriver()
        {
            switch (_profile.Browser)
            {
                case Browser.BrowserHidden : return PhantomDriver;
                case Browser.Firefox : return FirefoxDriver;
                case Browser.Chrome : return ChromeDriver;
                case Browser.Opera : return OperaDriver;
            }

            throw new NotImplementedException(string.Format("Unknown Remote Web Driver: {0}", _profile.Browser));
        }

        #region Vendor-specific driver properties

        public RemoteWebDriver FirefoxDriver
        {
            get
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.SetPreference("browser.startup.homepage", ABOUT_BLANK);
                firefoxProfile.SetPreference("startup.homepage_welcome_url", ABOUT_BLANK);
                firefoxProfile.SetPreference("startup.homepage_welcome_url.additional", ABOUT_BLANK);

                return new FirefoxDriver(firefoxProfile);
            }
        }

        public RemoteWebDriver ChromeDriver
        {
            get
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("test-type");
                capabilities.SetCapability("chrome.binary", @"e:\Projects\Onero\Onero\");
                capabilities.SetCapability(ChromeOptions.Capability, options);

                return new ChromeDriver(@"e:\Projects\Onero\Onero", options);
            }
        }

        public RemoteWebDriver OperaDriver
        {
            get
            {
                DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("test-type");
                capabilities.SetCapability("chrome.binary", @"e:\Projects\Onero\Onero\");
                capabilities.SetCapability(ChromeOptions.Capability, options);

                return new OperaDriver(@"e:\Projects\Onero\Onero\");
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
    }
}
