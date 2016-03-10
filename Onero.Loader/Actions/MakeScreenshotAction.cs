using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class MakeScreenshotAction : BaseAction, IAction
    {
        private const string SCREENSHOT_URL_LIST_FILE = "urls.txt";

        public int Order { get; set; }

        public MakeScreenshotAction(IWebDriver driver, LoaderSettings settings) : base(driver, settings)
        {
        } 

        public override dynamic Execute()
        {
            if (settings.Profile.CreateScreenshots)
            {
                Directory.CreateDirectory(settings.Profile.OutputDirectory);

                var screnshotsDir = string.Format("{0}\\Screenshots", settings.Profile.OutputDirectory);
                if (!Directory.Exists(screnshotsDir))
                {
                    Directory.CreateDirectory(screnshotsDir);
                }

                string fileFullPath = string.Format("{0}\\Screenshots\\{1}.jpg", settings.Profile.OutputDirectory, Order);
                if (driver is RemoteWebDriver)
                {
                    (driver as RemoteWebDriver).GetScreenshot().SaveAsFile(fileFullPath, ImageFormat.Png);

                    LogUrl(string.Format("{0}. {1}{2}", Order, driver.Url, Environment.NewLine));
                }
            }

            return null;
        }

        private void LogUrl(string line)
        {
            if (!File.Exists(LogFileName))
            {
                File.WriteAllText(LogFileName,
                    string.Format("Screenshots generated: {0} {1}{2}{2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), Environment.NewLine));
            }

            File.AppendAllText(LogFileName, line);
        }

        private string LogFileName
        {
            get { return string.Format("{0}\\{1}", settings.Profile.OutputDirectory, SCREENSHOT_URL_LIST_FILE); }
        }
    }
}
