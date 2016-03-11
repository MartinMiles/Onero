using System.Linq;
using OpenQA.Selenium;

namespace Onero.Loader.Actions
{
    public interface IAction
    {
        dynamic Execute();
    }

    public abstract class BaseAction : IAction
    {
        protected IWebDriver driver;
        protected LoaderSettings settings;

        protected BaseAction(IWebDriver driver, LoaderSettings settings)
        {
            this.driver = driver;
            this.settings = settings;
        }

        public abstract dynamic Execute();

        protected By BySelector(string selector)
        {
            switch (selector.First())
            {
                case '#': return By.Id(selector.TrimStart('#'));
                case '.': return By.ClassName(selector.TrimStart('.'));
                default: return By.TagName(selector);
            }
        }
    }
}
