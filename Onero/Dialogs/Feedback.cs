using System;
using System.Collections.Generic;
using System.Web;
using System.Windows.Forms;
using Onero.Helper.Models;
using Onero.Helper.Request;
using Onero.License;

namespace Onero.Dialogs
{
    public partial class Feedback : Form
    {
        const string URL = "http://demo.onero.net/feedbacks/send";

        private readonly LicenseManager _licenseManager;

        public Feedback()
        {
            _licenseManager = new LicenseManager();

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            feedbackTextbox.Enabled = false;
            button1.Enabled = false;

            // TODO: Validate input
            var license = _licenseManager.CheckLicense();

            var values = new Dictionary<string, string>
            {
                { "firstname", license?.FirstName ?? String.Empty },
                { "lastname", license?.LastName ?? String.Empty  },
                { "email", license?.Email ?? String.Empty  },
                { "message", HttpUtility.HtmlEncode(feedbackTextbox.Text) }
            };

            // Example: correct async workswith UI
            //var result = await PostRequester.DownloadPageAsync(URL, values);
            var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);

            // this occurs after result is back, but parent UI is NOT locked
            feedbackTextbox.Text = String.Empty;
            MessageBox.Show("Your feedback has been delivered", "Thank you");
            feedbackTextbox.Enabled = true;
            button1.Enabled = true;
        }
    }
}
