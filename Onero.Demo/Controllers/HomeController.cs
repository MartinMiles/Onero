using System.Web.Mvc;

namespace WebsiteTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult BrokenLinks()
        {
            return View();
        }
        public ActionResult SupportedFields()
        {
            return View();
        }
        public ActionResult DataExtract()
        {
            return View();
        }

        public ActionResult ExtractData()
        {
            ViewBag.Message = "Test for data extractor.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}