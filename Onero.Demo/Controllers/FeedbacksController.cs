using System;
using System.Web.Mvc;
using Onero.Demo.Services;

namespace Onero.Demo.Controllers
{
    public class FeedbacksController : Controller
    {
        // TODO: Add error logs from the app
        private readonly FeedbacksService _feedbacksService;
        public FeedbacksController(FeedbacksService feedbacksService)
        {
            _feedbacksService = feedbacksService;
        }

        [HttpPost]
        public ContentResult Send(string firstname, string lastname, string email, string message)
        {
            try
            {
                //TODO: Validate input
                message = _feedbacksService.Send(firstname, lastname, email, message);
                return Content(message);
            }
            catch (Exception e)
            {
                int k = 0;
                throw;
            }
        }
    }
}