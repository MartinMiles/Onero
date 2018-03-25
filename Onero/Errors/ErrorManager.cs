using System;
using Onero.Helper.ErrorHandling;
using Onero.License;

namespace Onero.Errors
{
    internal class ErrorManager
    {
        private readonly LicenseManager _licenseManager;

        public ErrorManager()
        {
            _licenseManager = new LicenseManager();
        }

        //TODO: Respect Profiles.Current.SendErrorsAndStats property and send only when in
        public void Report(Exception e, string comment = null)
        {
            var license = _licenseManager.CheckLicense();

            var errorReportingHelper = new ErrorReportingHelper();
            
             errorReportingHelper.Report(e, license, _licenseManager.OS, comment);
        }
    }
}
