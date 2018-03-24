using System.Web;
using Onero.Demo.Collections.Inerfaces;

namespace Onero.Demo.Collections
{
    public class Configuration : IConfiguration
    {
        public string LicensesFilePath => MapPath("/App_Data/licenses.xml");

        private static string MapPath(string relaivePath)
        {
            return HttpContext.Current.Server.MapPath(relaivePath);
        }
    }
}