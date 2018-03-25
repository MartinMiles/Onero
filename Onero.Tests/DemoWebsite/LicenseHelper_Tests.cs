using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onero.Helper.License;

namespace Onero.Tests.DemoWebsite
{
    [TestClass]
    public class LicenseHelper_Tests
    {
        private readonly LicenseHelper _licenseHelper;

        public LicenseHelper_Tests()
        {
            _licenseHelper = new LicenseHelper();
        }

        [TestMethod]
        public void RegisterNewUser()
        {
            string firstName = "Firstname";
            string lastName = "Lastname";
            string email = "this.email@belongs.to.me";
            string organization = "Micorsoft";

            var newLicense = _licenseHelper.GenerateNewLicense(firstName, lastName, email, organization, "MACHINE_ID");

            Assert.IsNotNull(newLicense);
            Assert.AreEqual(firstName, newLicense.FirstName);
            Assert.AreEqual(lastName, newLicense.LastName);
            Assert.AreEqual(email, newLicense.Email);
            Assert.AreEqual(organization, newLicense.Organization);
            Assert.AreEqual(DateTime.Today, newLicense.Created);
        }
    }
}
