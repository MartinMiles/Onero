using System;
using System.Web.Mvc;

namespace Onero.Demo.Controllers
{
    public class FeedbacksController : Controller
    {
        // TODO: Add error logs from the app

            //[HttpPost]
        public ContentResult Index(string feedback)
        {
            try
            {
                //TODO: Save feedback

                string result = "Done.";
                return Content(result);
            }
            catch (Exception e)
            {
                int k = 0;
                throw;
            }
        }
    }
}