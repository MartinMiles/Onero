using System.Collections.Generic;
using Onero.Helper.ErrorHandling;
using Onero.Helper.Feedback;
using Onero.Helper.License;

namespace Onero.Demo.Collections.Inerfaces
{
    public interface ICollection
    {
        List<License> Licenses { get; set; }
        List<Feedback> Feedbacks { get; set; }
        List<ReportableError> ReportableErrors { get; set; }

        void SaveLicenses();
        void SaveFeedbacks();
        void SaveReportableErrors();
    }
}