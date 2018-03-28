using System;
using System.Collections.Generic;
using System.Web;
using System.Windows.Forms;
using Onero.Helper;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Dialogs
{
    public partial class Feedback : Form
    {
        readonly string URL = $"{GlobalSettings.ServerBase}/feedbacks/send";

        private readonly Onero.Helper.License.LicenseManager _licenseManager;

        public Feedback()
        {
            _licenseManager = new Onero.Helper.License.LicenseManager();

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

            Close();
        }
    }
}
