using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static HttpClient httpClientInstance;

        [TestMethod]
        public async void HttpClientTest_NOT_ACTUAL_REPLACE()
        {
            var url = "http://demo.onero.net/feedbacks";
            var values = new Dictionary<string, string> { { "feedback", "Test" } };

            var result = await PostRequester.GenericPost<GenericPostResult>(url, values);
            

            Assert.AreEqual(result.result, "Done: feedback");
        }
    }
}
