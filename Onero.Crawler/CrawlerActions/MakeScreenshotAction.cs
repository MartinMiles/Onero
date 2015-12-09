using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium.Remote;

namespace Onero.Crawler.CrawlerActions
{
    public class MakeScreenshotAction : BaseCrawlerAction, ICrawlerAction
    {
        private const string SCREENSHOT_URL_LIST_FILE = "urls.txt";

        public int Order { get; set; }

        public MakeScreenshotAction(RemoteWebDriver driver, CrawlerSettings settings) : base(driver, settings)
        {
        } 

        public override dynamic Execute()
        {
            string fileFullPath = string.Format("{0}Screenshots\\{1}.jpg", settings.OutputPath, Order);
            driver.GetScreenshot().SaveAsFile(fileFullPath, ImageFormat.Png);

            LogUrl(string.Format("{0}. {1}{2}", Order, driver.Url, Environment.NewLine));

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
            get { return string.Format("{0}{1}", settings.OutputPath, SCREENSHOT_URL_LIST_FILE); }
        }
    }
}
