using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Loader.Actions;

namespace Onero.Tests.Actions
{
    [TestClass]
    public class Screenshots : BaseTest
    {
        [TestMethod]
        public void Screenshot_Action_Test()
        {
            const int ORDER = 1;
            string fileFullPath = $"{Directory.GetCurrentDirectory()}\\Screenshots\\{ORDER}.jpg";

            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }

            using (Driver = PhantomDriver)
            {
                Navigate(URL.Home);

                var action = new MakeScreenshotAction(Driver, Settings.Actions.Screenshot_Action_Test) { Order = ORDER };
                var result = action.Execute();

                Assert.IsTrue(result);

                Assert.IsTrue(File.Exists(fileFullPath));
            }

            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }
        }
    }
}
