using System;
using System.Collections.Generic;
using Onero.Helper.Interfaces;
using Onero.Helper.License;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Helper.ErrorHandling
{
    public class ErrorManager
    {
        private readonly LicenseManager _licenseManager;
        private readonly IProfile _profile;

        public ErrorManager(IProfile profile)
        {
            _profile = profile;
            _licenseManager = new LicenseManager();
        }


        public void Fix(Exception exception, string message)
        {
            if (_profile.SendErrorsAndStats)
            {
                Report(exception, message);
            }
            if (_profile.CreateErrorLog)
            {
                new Logger(_profile.OutputDirectory).Log(exception);
            }
        }

        private void Report(Exception e, string comment = null)
        {
            var license = _licenseManager.CheckLicense();

            ReportError(e, license, _licenseManager.OS, comment);
        }

        private async void ReportError(Exception exception, License.License license, string os, string comment)
        {
            string URL = $"{GlobalSettings.ServerBase}/errors/add";

            var values = new Dictionary<string, string>
            {
                { "Comment", comment },

                { "Type", exception.GetType().ToString()},
                { "CallStack", exception.StackTrace  ?? String.Empty},
                { "ExceptionMessage", exception.Message ?? String.Empty },

                { "InnerType", exception.InnerException?.GetType().ToString() ?? String.Empty },
                { "InnerCallStack", exception.InnerException?.StackTrace ?? String.Empty },
                { "InnerExceptionMessage", exception.InnerException?.Message ?? String.Empty },

                { "MachineId", license?.MachineId ?? String.Empty },
                { "SerialNumber", license?.SerialNumber ?? String.Empty },
                { "OS", os }
            };

            // Example: correct async workswith UI
            //var result = await PostRequester.DownloadPageAsync(URL, values);
            var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);
        }
    }
}
