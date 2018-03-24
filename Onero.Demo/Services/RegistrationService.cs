using System;
using System.Linq;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.License;

namespace Onero.Demo.Services
{
    public class RegistrationService
    {
        private readonly ICollection _collection;
        private readonly LicenseHelper _licenseHelper;
        
        public RegistrationService(ICollection collection)
        {
            _collection = collection;
            _licenseHelper = new LicenseHelper();
        }

        public string Register(string firstname, string lastname, string email, string organisation)
        {
            string newSerialNumber = String.Empty;

            var newLicense = _licenseHelper.GenerateNewLicense(firstname, lastname, email, organisation);

            _collection.Licenses.Add(newLicense);
            _collection.SaveLicenses();

            return newLicense.XmlNode().ToString();
        }

        public string GetSerialByEmail(string email)
        {
            var license = _collection.Licenses.FirstOrDefault(l => l.Email.ToLower() == email.ToLower());
            return license?.SerialNumber;
        }

        public bool ValidateSerial(string serialNumber)
        {
            var license = _collection.Licenses.FirstOrDefault(l => l.SerialNumber == serialNumber);
            return license != null;
        }

        public string Retrieve(string firstname, string lastname, string email)
        {
            var license = _collection.Licenses.FirstOrDefault(l => 
                l.FirstName.ToLower() == firstname.ToLower() && 
                l.LastName.ToLower() == lastname.ToLower() && 
                l.Email.ToLower() == email.ToLower());

            return license?.XmlNode()?.ToString();
        }

        public string Update(string firstname, string lastname, string email, string organisation, string serialNubmer)
        {
            var license = _collection.Licenses.FirstOrDefault(l => l.SerialNumber == serialNubmer.Trim());

            license.FirstName = firstname;
            license.LastName = lastname;
            license.Email = email;
            license.Organization = organisation;

            //_collection.Licenses.FindIndex()

            _collection.SaveLicenses();

            return license.XmlNode()?.ToString();
        }

        public string Check(string serialNubmer)
        {
            var license = _collection.Licenses.FirstOrDefault(l => l.SerialNumber == serialNubmer.Trim());
            return license.XmlNode()?.ToString();
        }
    }
}