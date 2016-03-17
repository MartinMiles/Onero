using System.Collections.Generic;
using Onero.Loader.Actions;
using OpenQA.Selenium;

namespace Onero.Loader
{
    public class ActionsFactory
    {
        public static IEnumerable<BaseAction> GetActions(IWebDriver driver, LoaderSettings settings, int order)
        {
            return new List<BaseAction>
            {
                new RulesExecuteAction(driver, settings),
                new FormSubmitAction(driver, settings),
                new MakeScreenshotAction(driver, settings) {Order = order},
                new BrokenLinksAction(driver, settings),
                new DataExtractAction(driver, settings)
            };
        }
    }
}
