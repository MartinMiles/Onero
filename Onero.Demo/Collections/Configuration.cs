using System.Web;
using Onero.Demo.Collections.Inerfaces;

namespace Onero.Demo.Collections
{
    internal class Configuration : IConfiguration
    {
        public string LicensesFilePath => MapPath("/App_Data/licenses.xml");
        public string FeedbacksFilePath => MapPath("/App_Data/feedbacks.xml");
        public string ErrorsFilePath => MapPath("/App_Data/errors.xml");

        private static string MapPath(string relaivePath)
        {
            return HttpContext.Current.Server.MapPath(relaivePath);
        }
    }
}