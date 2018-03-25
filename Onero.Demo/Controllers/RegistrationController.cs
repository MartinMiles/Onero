using System.Web.Mvc;
using Onero.Demo.Services;

namespace Onero.Demo.Controllers
{
    public class RegistrationController : Controller
    {
        // TODO:
        // 1. Validate serial
        // 2. Register new and return serial
        // 3. Retrieve serial by email

        private readonly RegistrationService _registrationService;
        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        
        public JsonResult Index()
        {
            return Json(true);
        }

        [HttpPost]
        public ContentResult New(string firstname, string lastname, string email, string organisation, string machineId)
        {
            string licenseXml = _registrationService.Register(firstname, lastname, email, organisation, machineId);
            return Content(licenseXml, "text/xml");
        }

        [HttpPost]
        public ContentResult Check(string serialNubmer)
        {
            string licenseXml = _registrationService.Check(serialNubmer);
            return Content(licenseXml, "text/xml");
        }
        [HttpPost]
        public ContentResult Retrieve(string firstname, string lastname, string email)
        {
            string licenseXml = _registrationService.Retrieve(firstname, lastname, email);
            return Content(licenseXml, "text/xml");
        }

        [HttpPost]
        public ContentResult Update(string firstname, string lastname, string email, string organisation, string serialNubmer)
        {
            string licenseXml = _registrationService.Update(firstname, lastname, email, organisation, serialNubmer);
            return Content(licenseXml, "text/xml");
        }
    }
}