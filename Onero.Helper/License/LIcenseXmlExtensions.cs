using System;
using System.Globalization;
using System.Xml.Linq;

namespace Onero.Helper.License
{
    public static class LicenseXmlExtensions
    {
        public static XElement XmlNode(this License license)
        {
            var node = new XElement("lic", license.SerialNumber);
            node.SetAttributeValue("firstname", license.FirstName);
            node.SetAttributeValue("lastname", license.LastName);
            node.SetAttributeValue("email", license.Email);
            node.SetAttributeValue("organization", license.Organization);
            node.SetAttributeValue("machineId", license.MachineId);
            node.SetAttributeValue("created", license.Created.ToString("yyyy/MM/dd"));
            return node;
        }

        public static License FromXmlLicense(this XElement lic)
        {
            var license = new License
            {
                FirstName = lic.Attribute("firstname")?.Value ?? String.Empty,
                LastName = lic.Attribute("lastname")?.Value ?? String.Empty,
                Email = lic.Attribute("email")?.Value ?? String.Empty,
                Organization = lic.Attribute("organization")?.Value ?? String.Empty,
                MachineId = lic.Attribute("machineId")?.Value ?? String.Empty,
                SerialNumber = lic.Value
            };

            if (lic.Attribute("created") != null)
            {
                license.Created = DateTime.ParseExact(lic.Attribute("created").Value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }

            return license;
        }
    }
}
