using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public class MakeScreenshotAction : BaseAction
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

                var screnshotsDir = $"{settings.Profile.OutputDirectory}\\Screenshots";
                if (!Directory.Exists(screnshotsDir))
                {
                    Directory.CreateDirectory(screnshotsDir);
                }

                string fileFullPath = $"{settings.Profile.OutputDirectory}\\Screenshots\\{Order}.jpg";
                if (driver is RemoteWebDriver)
                {
                    (driver as RemoteWebDriver).GetScreenshot().SaveAsFile(fileFullPath, ImageFormat.Png);

                    LogUrl($"{Order}. {driver.Url}{Environment.NewLine}");
                }
            }

            return true;
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

        private string LogFileName => $"{settings.Profile.OutputDirectory}\\{SCREENSHOT_URL_LIST_FILE}";
    }
}
