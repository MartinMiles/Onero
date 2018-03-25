using System.Web.Mvc;
using Onero.Demo.Services;
using Onero.Helper.ErrorHandling;

namespace Onero.Demo.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ErrorsService _errorsService;
        public ErrorsController(ErrorsService errorsService)
        {
            _errorsService = errorsService;
        }

        [HttpPost]
        public ContentResult Add(ReportableError reportableError)
        {
            bool result = _errorsService.RegisterError(reportableError);
            return Content(result.ToString(), "text/xml");
        }
    }
}