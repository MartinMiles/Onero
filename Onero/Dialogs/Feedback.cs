using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Onero.Helper;
using Onero.Helper.Models;
using Onero.Helper.Request;

namespace Onero.Dialogs
{
    public partial class Feedback : Form
    {
        const string URL = "http://demo.onero.net/feedbacks";

        public Feedback()
        {   
            InitializeComponent();
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            feedbackTextbox.Enabled = false;
            button1.Enabled = false;

            var values = new Dictionary<string, string>
            {
                { "feedback", feedbackTextbox.Text },
            };

            // Example: correct async workswith UI
            //var result = await PostRequester.DownloadPageAsync(URL, values);
            var result = await PostRequester.GenericPost<GenericPostResult>(URL, values);

            // this occurs after result is back, but parent UI is NOT locked
            feedbackTextbox.Text = String.Empty;
            MessageBox.Show("Your feedback has been delivered: " + result.result, "Thank you");
            feedbackTextbox.Enabled = true;
            button1.Enabled = true;
        }
    }
}
