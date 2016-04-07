using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader;
using Onero.Loader.Actions;
using Onero.Loader.Results;

namespace Onero.Tests.Actions
{
    [TestClass]
    public class Rules : BaseTest
    {
        [TestMethod]
        public void Html_Tag_Everywhere_Test()
        {
            using (Driver = PhantomDriver)
            {
                Navigate(URL.Home);

                var action = new RulesExecuteAction(Driver, Settings.Actions.Rule_Action_Test);
                var result = action.Execute() as Dictionary<Rule, ResultCode>;

                Assert.AreEqual(result.Count, 1);
                Assert.IsTrue(result.First().Value == ResultCode.Successful);
            }
        }
    }
}
