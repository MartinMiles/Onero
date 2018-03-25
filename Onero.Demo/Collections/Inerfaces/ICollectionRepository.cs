using System.Collections.Generic;
using Onero.Helper.ErrorHandling;
using Onero.Helper.Feedback;
using Onero.Helper.License;

namespace Onero.Demo.Collections.Inerfaces
{
    public interface ICollectionRepository
    {
        List<License> ReadLicenses();
        List<Feedback> ReadFeedbacks();
        List<ReportableError> ReadReportableErrors();
        
        void SaveLicenses(List<License> Licenses);
        void SaveFeedbacks(List<Feedback> Feedbacks);
        void SaveReportableErrors(List<ReportableError> ReportableErrors);
    }
}