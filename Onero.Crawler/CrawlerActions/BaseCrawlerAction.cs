using OpenQA.Selenium.Remote;

namespace Onero.Crawler.CrawlerActions
{
    public interface ICrawlerAction
    {
        dynamic Execute();
    }

    public abstract class BaseCrawlerAction : ICrawlerAction
    {
        protected RemoteWebDriver driver;
        protected CrawlerSettings settings;

        protected BaseCrawlerAction(RemoteWebDriver driver, CrawlerSettings settings)
        {
            this.driver = driver;
            this.settings = settings;
        }

        public abstract dynamic Execute();
    }
}
