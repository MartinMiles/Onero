using System.Collections.Generic;
using System.Xml.Linq;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.ErrorHandling;
using Onero.Helper.Feedback;
using Onero.Helper.License;

namespace Onero.Demo.Collections
{
    public class CollectionRepository : ICollectionRepository
    {
        readonly IConfiguration _configuration;

        internal CollectionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //TODO: Unify calls for read and save into generics. Pass FromXmlLicense as a delegate

        public List<License> ReadLicenses()
        {
            var doc = XDocument.Load(_configuration.LicensesFilePath);

            var licenses = new List<License>();

            foreach (var licenseNode in doc.Descendants("licenses").Elements())
            {
                licenses.Add(licenseNode.FromXmlLicense());
            }

            return licenses;
        }

        public List<Feedback> ReadFeedbacks()
        {
            var doc = XDocument.Load(_configuration.FeedbacksFilePath);

            var licenses = new List<Feedback>();

            foreach (var licenseNode in doc.Descendants("feedbacks").Elements())
            {
                licenses.Add(licenseNode.FromXmlFeedback());
            }

            return licenses;
        }

        public List<ReportableError> ReadReportableErrors()
        {
            var doc = XDocument.Load(_configuration.ErrorsFilePath);

            var errors = new List<ReportableError>();

            foreach (var node in doc.Descendants("errors").Elements())
            {
                errors.Add(node.FromXmlError());
            }

            return errors;
        }

        public void SaveLicenses(List<License> Licenses)
        {
            var doc = new XDocument();
            var root = new XElement("root");
            doc.Add(root);

            var tops = new XElement("licenses");

            root.Add(tops);

            foreach (License license in Licenses/*.OrderBy(a => a.Name)*/)
            {
                tops.Add(license.XmlNode());
            }

            doc.Save(_configuration.LicensesFilePath);
        }

        public void SaveFeedbacks(List<Feedback> Feedbacks)
        {
            var doc = new XDocument();
            var root = new XElement("root");
            doc.Add(root);

            var tops = new XElement("feedbacks");

            root.Add(tops);

            foreach (Feedback feedback in Feedbacks/*.OrderBy(a => a.Name)*/)
            {
                tops.Add(feedback.XmlNode());
            }

            doc.Save(_configuration.FeedbacksFilePath);
        }

        public void SaveReportableErrors(List<ReportableError> ReportableErrors)
        {
            var doc = new XDocument();
            var root = new XElement("root");
            doc.Add(root);

            var tops = new XElement("errors");

            root.Add(tops);

            foreach (ReportableError error in ReportableErrors/*.OrderBy(a => a.Name)*/)
            {
                tops.Add(error.XmlNode());
            }

            doc.Save(_configuration.ErrorsFilePath);
        }
    }
}
