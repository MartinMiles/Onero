using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Onero.Tests
{
    [TestClass]
    public class Supported_Fields : BaseTest
    {
        const string TEST = "test";

        [TestMethod]
        public void Supported_Fields_Test()
        {
            using (IWebDriver driver = PhantomDriver)
            {
                driver.Navigate().GoToUrl($"{WEBSITE_TEST_BASE}{URL.SupportedPages}");

                var element1 = driver.FindElement(BaseAction.BySelector(SupportedFields.TEXT));
                element1.SendKeys(TEST);

                var element2 = driver.FindElement(BaseAction.BySelector(SupportedFields.PASSWORD));
                element2.SendKeys(TEST);

                // click
                var element3 = driver.FindElement(BaseAction.BySelector(SupportedFields.CHECKBOX));
                element3.Click();

                // click
                var element4 = driver.FindElement(BaseAction.BySelector(SupportedFields.RADIO));
                element4.Click();

                var element5 = driver.FindElement(BaseAction.BySelector(SupportedFields.DATALIST));
                element5.SendKeys(TEST);

                // slisde
                var element6 = driver.FindElement(BaseAction.BySelector(SupportedFields.RANGE));
                for (int i=0; i< 40; i++)
                {
                    element6.SendKeys(Keys.Right);
                }

                // buttons
                var element10 = driver.FindElement(BaseAction.BySelector(SupportedFields.NUMBER));
                for (int i=0; i < 4; i++)
                {
                    element10.SendKeys(Keys.Up);
                }

                // change color picker to yellow
                string selectColorJavascript = $"$('{SupportedFields.COLOR}').val('#ffff00');";
                (driver as RemoteWebDriver).ExecuteScript(selectColorJavascript);

                var elementX = driver.FindElement(BaseAction.BySelector(SupportedFields.SUBMIT));
                elementX.Click();

                var elementY = driver.FindElement(BaseAction.BySelector(SupportedFields.MESSAGE));
                Assert.AreEqual(elementY.Text, "OK");
            }
        }
    }
}
