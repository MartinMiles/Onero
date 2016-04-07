using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader;
using Onero.Loader.Actions;
using Onero.Loader.Results;

namespace Onero.Tests.Actions
{
    [TestClass]
    public class BrokenLinks : BaseTest
    {
        [TestMethod]
        public void Broken_Links_Page_Test()
        {
            using (Driver = PhantomDriver)
            {
                Navigate(URL.BrokenLinks);

                var action = new BrokenLinksAction(Driver, Settings.Actions.Broken_Links_Action);
                BrokenLinksResult extracted = action.Execute();

                Assert.IsNotNull(extracted);
                Assert.AreEqual(extracted.Links.Count(), 1);
                Assert.AreEqual(extracted.Images.Count(), 1);
                Assert.AreEqual(extracted.Scripts.Count(), 1);
                Assert.AreEqual(extracted.Styles.Count(), 1);
            }
        }

        [TestMethod]
        public void Parallel_Url_Test()
        {
            List<Uri> uris = new List<Uri>
            {
                new Uri("http://onero.martinmiles.net"),
                new Uri("http://example.com/does_not_exist"),
                new Uri("http://www.bbc.co.uk"),
                new Uri("http://google.com"),
                new Uri("http://localhost")
            };

            HttpStatusCodeReader httpStatusCodeReader = new HttpStatusCodeReader(uris);
            var httpStatusCodes = httpStatusCodeReader.GetHttpStatusCodes();

            Assert.AreEqual(httpStatusCodes.Count, 5);
            Assert.IsTrue(httpStatusCodes.ElementAt(0).Value);
            Assert.IsFalse(httpStatusCodes.ElementAt(1).Value);
            Assert.IsTrue(httpStatusCodes.ElementAt(2).Value);
            Assert.IsTrue(httpStatusCodes.ElementAt(3).Value);
            Assert.IsFalse(httpStatusCodes.ElementAt(4).Value);
        }
    }
}
