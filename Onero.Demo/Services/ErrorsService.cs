using System;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.ErrorHandling;

namespace Onero.Demo.Services
{
    public class ErrorsService
    {
        private readonly ICollection _collection;

        public ErrorsService(ICollection collection)
        {
            _collection = collection;
        }

        public bool RegisterError(ReportableError reportableError)
        {
            try
            {
                reportableError.Created = DateTime.Today;

                _collection.ReportableErrors.Add(reportableError);
                _collection.SaveReportableErrors();
                return true;
            }
            catch
            {
            }

            return false;
        }
    }
}