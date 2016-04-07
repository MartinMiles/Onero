using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader;
using Onero.Loader.Actions;
using Onero.Loader.Results;

namespace Onero.Tests.Actions
{
    [TestClass]
    public class Forms : BaseTest
    {
        [TestMethod]
        public void Test_All_Supported_Types()
        {
            using (Driver = PhantomDriver)
            {
                Navigate(URL.SupportedPages);

                var formsAction = new FormSubmitAction(Driver, Settings.Actions.Form_Sumbission_Action_Test_All_Supported_Types);
                var formResults = formsAction.Execute() as Dictionary<WebForm, ResultCode>;

                var elementY = Driver.FindElement(BaseAction.BySelector(SupportedFields.MESSAGE));
                Assert.AreEqual(elementY.Text, "OK");

                Assert.AreEqual(formResults.Count, 1);
                Assert.AreEqual(formResults.ElementAt(0).Key.Name, "login form");
                Assert.AreEqual(formResults.ElementAt(0).Value, ResultCode.Successful);
            }
        }

        [Ignore]
        [TestMethod]
        public void Login_Form_Submission()
        {
            using (Driver = PhantomDriver)
            {
                Navigate(URL.Login);

                var formsAction = new FormSubmitAction(Driver, Settings.Actions.Form_Sumbission_Login);
                var formResults = formsAction.Execute() as Dictionary<WebForm, ResultCode>;

                Assert.AreEqual(formResults.Count, 1);
                Assert.AreEqual(formResults.ElementAt(0).Key.Name, "login form");
                Assert.AreEqual(formResults.ElementAt(0).Value, ResultCode.Successful);
            }
        }
    }
}
