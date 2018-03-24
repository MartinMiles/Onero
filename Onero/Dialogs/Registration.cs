using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using Onero.Helper.License;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Dialogs
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }

        private async void RegisterNewUserClick(object sender, EventArgs e)
        {
            bool isUpdate = !string.IsNullOrWhiteSpace(serialNumber.Text.Trim());
            string URL = isUpdate
                ? "http://demo.onero.net/registration/update"
                : "http://demo.onero.net/registration/new";

            if (true)   // Validate
            {
                EnableUI(false);

                var values = new Dictionary<string, string>
                {
                    { "firstname", firstNameTexbox.Text },
                    { "lastname", lastNameTexbox.Text },
                    { "email", emailTextbox.Text },
                    { "organisation", organizationTextbox.Text },
                    { "serialNubmer", serialNumber.Text.Trim() }
                };

                // Example: correct async workswith UI
                //var result = await PostRequester.DownloadPageAsync(URL, values);
                var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);

                var license = XElement.Parse(result.result).FromXml();

                SaveLicense(license);

                FillUI(license);



                string message = !string.IsNullOrWhiteSpace(serialNumber.Text.Trim())
                    ? "Your details have been updated"
                    : "You have been registered";

                MessageBox.Show(message, "Thank you");

                if (!isUpdate)
                {
                    CleanUI();
                }
                else
                {
                    EnableUI(true);
                }
            }
        }

        private async void retrieveExistingByEmailClick(object sender, EventArgs e)
        {
            EnableRestoreUI(false);

            const string URL = "http://demo.onero.net/registration/retrieve";
            var values = new Dictionary<string, string>
            {
                { "firstname", restoreFirstName.Text },
                { "lastname", restoreLastName.Text },
                { "email", restoreEmail.Text }
            };

            var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);

            if (!string.IsNullOrWhiteSpace(result.result))
            {
                MessageBox.Show("We have found your details", "Success");

                var license = XElement.Parse(result.result).FromXml();

                SaveLicense(license);

                FillUI(license);
                EnableRestoreUI(true);
                CleanRestoreUI();
            }
            else
            {
                MessageBox.Show("We have not found your details", "Failure");
                EnableRestoreUI(true);
            }
        }

        private async void enterSerialExistinguserClick(object sender, EventArgs e)
        {
            EnableUI(false);

            const string URL = "http://demo.onero.net/registration/Check";
            var values = new Dictionary<string, string>
            {
                { "serialNubmer", serialNumber.Text }
            };

            var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);

            if (!string.IsNullOrWhiteSpace(result.result))
            {
                MessageBox.Show("Your serial number is valid", "Success");

                var license = XElement.Parse(result.result).FromXml();

                SaveLicense(license);

                FillUI(license);
                EnableUI(true);
                EnableRestoreUI(false);
            }
            else
            {
                MessageBox.Show("Your serial number is NOT valid", "Failure");
                //EnableRestoreUI(true);
            }
        }

        private void EnableUI(bool enabled)
        {
            firstNameTexbox.Enabled = enabled;
            lastNameTexbox.Enabled = enabled;
            emailTextbox.Enabled = enabled;
            organizationTextbox.Enabled = enabled;
            registerNewButton.Enabled = enabled;
            serialNumber.Enabled = enabled;
        }

        private void FillUI(License license)
        {
            firstNameTexbox.Text = license.FirstName;
            lastNameTexbox.Text = license.LastName;
            emailTextbox.Text = license.Email;
            organizationTextbox.Text = license.Organization;
            serialNumber.Text = license.SerialNumber;

            registerNewButton.Text = "Update";
        }

        private void EnableRestoreUI(bool enabled)
        {
            restoreFirstName.Enabled = enabled;
            restoreLastName.Enabled = enabled;
            restoreEmail.Enabled = enabled;
            retrieveExistingButton.Enabled = enabled;
        }
        private void CleanRestoreUI()
        {
            restoreFirstName.Text = "";
            restoreLastName.Text = "";
            restoreEmail.Text = "";
        }

        private void CleanUI()
        {
            firstNameTexbox.Text = "";
            lastNameTexbox.Text = "";
            emailTextbox.Text = "";
            organizationTextbox.Text = "";
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            CheckLicense();
        }

        private void CheckLicense()
        {
            if (File.Exists("license.xml"))
            {
                string licenseXml = File.ReadAllText("license.xml");
                var element = XElement.Parse(licenseXml);
                var license = element.FromXml();

                if (license != null)
                {
                    // TODO: validate license by decoding it

                    firstNameTexbox.Text = license.FirstName;
                    lastNameTexbox.Text = license.LastName;
                    emailTextbox.Text = license.Email;
                    organizationTextbox.Text = license.Organization;

                    serialNumber.Text = license.SerialNumber;

                    registerNewButton.Text = "Update";
                    EnableRestoreUI(false);
                }
            }

        }

        private void SaveLicense(License license)
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
