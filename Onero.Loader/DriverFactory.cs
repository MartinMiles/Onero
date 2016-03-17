using System;
using System.IO;
using Onero.Loader.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Onero.Loader
{
    public class DriverFactory
    {
        private const string ABOUT_BLANK = "about:blank";

        private const string DRIVERS_FOLDER_NAME = "Drivers";
        private const string CHROME_DRIVER = "chromedriver.exe";
        private const string OPERA_DRIVER = "operadriver.exe";

        private string DriversFolder => $"{Directory.GetCurrentDirectory()}\\{DRIVERS_FOLDER_NAME}";

        private RemoteWebDriver _driver;
        private readonly IProfile _profile;

        public DriverFactory(IProfile profile)
        {
            _profile = profile;
        }

        public RemoteWebDriver Driver => _driver ?? ResolveDriver();

        private RemoteWebDriver ResolveDriver()
        {
            switch (_profile.Browser)
            {
                case Browser.BrowserHidden : return PhantomDriver;
                case Browser.IE : return InternetExplorerDriver;
                case Browser.Edge : return EdgeDriver;
                case Browser.Firefox : return FirefoxDriver;
                case Browser.Chrome : return ChromeDriver;
                case Browser.Opera : return OperaDriver;
            }

            throw new NotImplementedException($"Unknown Remote Web Driver: {_profile.Browser}");
        }

        #region Vendor-specific driver properties

        public RemoteWebDriver InternetExplorerDriver
        {
            get
            {
                var driverService = InternetExplorerDriverService.CreateDefaultService(DriversFolder);
                driverService.HideCommandPromptWindow = true;

                return new InternetExplorerDriver(driverService, new InternetExplorerOptions { InitialBrowserUrl = ABOUT_BLANK });
            }
        }

        public RemoteWebDriver EdgeDriver
        {
            get
            {
                EdgeOptions options = new EdgeOptions { PageLoadStrategy = EdgePageLoadStrategy.Eager };
                return new EdgeDriver(DriversFolder, options);
            }
        }

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
                var options = new ChromeOptions { LeaveBrowserRunning = false };
                var service = ChromeDriverService.CreateDefaultService(DriversFolder, CHROME_DRIVER);
                service.HideCommandPromptWindow = true;
                return new ChromeDriver(service, options);
            }
        }

        public RemoteWebDriver OperaDriver
        {
            get
            {
                var options = new OperaOptions { LeaveBrowserRunning = false };
                var service = OperaDriverService.CreateDefaultService(DriversFolder, OPERA_DRIVER);
                service.HideCommandPromptWindow = true;
                return new OperaDriver(service, options);
            }
        }

        private PhantomJSDriver PhantomDriver
        {
            get
            {
                var driverService = PhantomJSDriverService.CreateDefaultService(DriversFolder);
                driverService.HideCommandPromptWindow = true;
                return new PhantomJSDriver(driverService);
            }
        }

        #endregion
    }
}