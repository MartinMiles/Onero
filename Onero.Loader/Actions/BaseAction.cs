using OpenQA.Selenium.Remote;

namespace Onero.Loader.Actions
{
    public interface IAction
    {
        dynamic Execute();
    }

    public abstract class BaseAction : IAction
    {
        protected RemoteWebDriver driver;
        protected LoaderSettings settings;

        protected BaseAction(RemoteWebDriver driver, LoaderSettings settings)
        {
            this.driver = driver;
            this.settings = settings;
        }

        public abstract dynamic Execute();
    }
}
