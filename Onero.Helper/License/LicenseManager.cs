using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Xml.Linq;

namespace Onero.Helper.License
{
    public class LicenseManager
    {
        public Helper.License.License CheckLicense()
        {
            if (File.Exists("license.xml"))
            {
                string licenseXml = File.ReadAllText("license.xml");
                var element = XElement.Parse(licenseXml);
                return element.FromXmlLicense();
            }

            return null;
        }

        public string MachineId
        {
            get
            {
                var os = new ManagementObject("Win32_OperatingSystem=@");
                return (string)os["SerialNumber"];
            }
        }

        internal string OS
        {
            get
            {
                var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                select x.GetPropertyValue("Caption")).FirstOrDefault();
                return name?.ToString() ?? "Unknown";
            }
        }

        public void SaveLicense(Helper.License.License license)
        {
            try
            {
                string xml = license.XmlNode().ToString();
                File.WriteAllText("license.xml", xml);
            }
            catch (Exception e)
            {
                // TODO: processany faulty behavior
                throw;
            }
        }
    }
}
