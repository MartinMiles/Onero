using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.License;

namespace Onero.Demo.Collections
{
    public class CollectionRepository : ICollectionRepository
    {
        readonly IConfiguration _configuration;

        public CollectionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<License> ReadLicenses()
        {
            var doc = XDocument.Load(_configuration.LicensesFilePath);

            var licenses = new List<License>();

            foreach (var licenseNode in doc.Descendants("licenses").Elements())
            {
                licenses.Add(licenseNode.FromXml());
            }

            return licenses;
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
    }
}
