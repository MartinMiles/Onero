using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader.Actions;
using Onero.Loader.Results;

namespace Onero.Tests.Actions
{
    [TestClass]
    public class DataExtracts : BaseTest
    {
        [TestMethod]
        public void Default_Test()
        {
            using (Driver = PhantomDriver)
            {
                Navigate(URL.DataExtract);

                var dataExtractAction = new DataExtractAction(Driver, Settings.Actions.Data_Extract_Action);
                var extracted = dataExtractAction.Execute() as List<DataExtractResult>;

                Assert.AreEqual(extracted.Count, 1);
                Assert.IsTrue(extracted.ElementAt(0).UrlTaken.Contains(URL.DataExtract));
                Assert.IsTrue(extracted.ElementAt(0).ResultCode == ResultCode.Successful);
                Assert.IsTrue(extracted.ElementAt(0).Value.Contains("Our product for Small Business is"));
            }
        }
    }
}
