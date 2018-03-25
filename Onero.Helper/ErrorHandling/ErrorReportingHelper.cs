using System;
using System.Collections.Generic;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Helper.ErrorHandling
{
    public class ErrorReportingHelper
    {
        public async void Report(Exception exception, License.License license, string os, string comment)
        {
            string URL = "http://demo.onero.net/errors/add";

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
