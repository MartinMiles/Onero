using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader;
using Onero.Loader.Results;

namespace Onero.Tests.Tests
{
    [TestClass]
    public class Loader_Tests : BaseTest
    {
        [TestMethod]
        public void Loader_Default()
        {
            int order = 1;
            string page = "http://localhost:8540/Home/DataExtract";

            using (Driver = PhantomDriver)
            {
                var loader = new Loader.Loader(Settings.Loader.Universal);
                PrivateObject obj = new PrivateObject(loader);
                var result = obj.Invoke("RunThePage", new object[] { page, Driver, order }) as Result;

                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsSuccessful);
                Assert.IsTrue(result.PageLoadTime > 0);
            }
        }
    }
}
