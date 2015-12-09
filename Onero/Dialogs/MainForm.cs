using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using Onero.Crawler;
using Onero.Crawler.Results;

namespace Onero.Dialogs
{
    public partial class MainForm : Form
    {
        #region Strings and constants

        private const string RESULTS_DIRECTORY = "Results";
        private const int DEFAULT_TIMEOUT = 60;

        private const string PROGRESS_COMPLETED = "Progress: completed {0} pages";
        private const string INVALID_CRAWLING_MODE = "Crawling mode not specified correctly";

        private const string START_BUTTON = "Start";
        private const string CANCEL_BUTTON = "Cancel";
        private const string CANCELLING_BUTTON = "Cancelling...";

        #endregion

        private Loader loader;
        private static CrawlerSettings settings;
        private List<Result> results;

        private static string DefaultOutputPath
        {
            get
            {
                string directory = Environment.CurrentDirectory;

                #if (DEBUG)
                    directory = Directory.GetParent(directory).ToString();
                #endif

                return string.Format("{0}\\{1}", directory, RESULTS_DIRECTORY);
            }
        }

        private static string PathPrefix
        {
            get
            {
                string prefix = String.Empty;

                #if (DEBUG)
                    prefix = "..\\..\\";
                #endif

                return prefix;
            }
        }

        public Dictionary<string, DisplayResult> UrlToProcess { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            startButton.Enabled = true;
            startButton.Text = START_BUTTON;

            InitSettings();

            ShowTestButton();
        }

        private void ShowTestButton()
        {
            #if (DEBUG)
                testButton.Visible = true;
            #endif
        }

        private void InitSettings()
        {
            // set initial defaults below
            settings = new CrawlerSettings
            {
                OutputPath = DefaultOutputPath,
                TimeOut = DEFAULT_TIMEOUT,
                ShowFirefox = false,
                Verbose = false,
                CreateScreenshots = true
            };
        }

        #region Crawling Mode features

        public CrawlingMode CurrentCrawlingMode
        {
            get
            {
                if (radioButtonSitemap.Checked)
                {
                    return CrawlingMode.Sitemap;
                }

                if (radioButtonWebAPI.Checked)
                {
                    return CrawlingMode.WebAPI;
                }

                if (radioButtonLinks.Checked)
                {
                    return CrawlingMode.Manual;
                }

                throw new ArgumentOutOfRangeException(INVALID_CRAWLING_MODE);
            }
        }

        private IParseable GetLinksClient()
        {
            switch (CurrentCrawlingMode)
            {
                case CrawlingMode.Sitemap: return new SitemapClient(string.Format("{0}/{1}", sitemapHost.Text, sitemapFilename.Text));
                case CrawlingMode.WebAPI: return new WebApiClient(apiEndpoint.Text, apiLogin.Text, apiPassword.Text);
                case CrawlingMode.Manual: return new EmptyClient(environmentLinksItems.Text);
            }

            throw new ArgumentOutOfRangeException(INVALID_CRAWLING_MODE);
        }

        private IEnumerable<string> LinksFromTextbox
        {
            get { return environmentLinksItems.Text.Trim().Split('\n'); }
        }

        #endregion

        #region BackgroungWorker functions

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            loader.Start(sender as BackgroundWorker);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var result = (Result)e.UserState;
            
            results.Add(result);

            environmentLinksItems.ReplaceLine(result.Url, result.IsSuccessful ? DisplayResult.Successful : DisplayResult.Failed);

            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Text = START_BUTTON;
            startButton.Enabled = true;
            resultLabel.Text = string.Format(PROGRESS_COMPLETED, results.Count);

            BlockUserInterfaceOnRun(false);

            Results.WriteCSV(results, settings);
        }

        #endregion

        private void BlockUserInterfaceOnRun(bool isBlocked)
        {
            environmentLinksItems.ReadOnly = isBlocked;
            radioButtonLinks.Enabled = !isBlocked;
            radioButtonSitemap.Enabled = !isBlocked;
            radioButtonWebAPI.Enabled = !isBlocked;

            resultLabel.Visible = !isBlocked;

            progressBar1.Visible = isBlocked;
            loadLinksButton.Enabled = !isBlocked;
        }

        private void OnStartButonClick(object sender, EventArgs e)
        {
            if (startButton.Text == CANCEL_BUTTON)
            {
                backgroundWorker.CancelAsync();
                startButton.Text = CANCELLING_BUTTON;
                startButton.Enabled = false;
                return;
            }

            try
            {
                if (!this.IsValid())
                    return;

                settings.Rules = Rules.Read();
                settings.Forms = Forms.Read();
                settings.PagesToCrawl = LinksFromTextbox;

                loader = new Loader(settings);

                if (results != null || CurrentCrawlingMode == CrawlingMode.Manual)
                {
                    PopulateLinksTextbox();
                }

                results = new List<Result>();

                BlockUserInterfaceOnRun(true);

                progressBar1.Step = 1;
                progressBar1.Value = 0;
                progressBar1.Maximum = LinksFromTextbox.Count();
                startButton.Text = CANCEL_BUTTON;
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton.Checked)
            {
                switch (CurrentCrawlingMode)
                {
                    case CrawlingMode.Sitemap:
                    {
                        apiEndpoint.Enabled = false;
                        apiLogin.Enabled = false;
                        apiPassword.Enabled = false;
                        sitemapHost.Enabled = true;
                        sitemapFilename.Enabled = true;
                        loadLinksButton.Enabled = true;
                        results = null;
                        break;
                    }
                    case CrawlingMode.WebAPI:
                    {
                        apiEndpoint.Enabled = true;
                        apiLogin.Enabled = true;
                        apiPassword.Enabled = true;
                        sitemapHost.Enabled = false;
                        sitemapFilename.Enabled = false;
                        loadLinksButton.Enabled = true;
                        results = null;
                        break;
                    }
                    case CrawlingMode.Manual:
                    {
                        apiEndpoint.Enabled = false;
                        apiLogin.Enabled = false;
                        apiPassword.Enabled = false;
                        sitemapHost.Enabled = false;
                        sitemapFilename.Enabled = false;
                        loadLinksButton.Enabled = false;
                        break;
                    }
                }

                linksGroupbox.Text = "Pages to process";
            }
        }

        private void TextboxDoubleClick(object sender, EventArgs e)
        {
            var richTextBox1 = sender as RichTextBox;
            var clickedLine = richTextBox1.GetClickedString(e as MouseEventArgs);

            if (string.IsNullOrWhiteSpace(clickedLine) || results == null) return;

            var clickedPageResult = results.FirstOrDefault(r => r.Url == clickedLine);
            if (clickedPageResult != null)
            {
                var form = new PageResultViewForms {StartPosition = FormStartPosition.CenterParent};
                form.PageResult = clickedPageResult;
                form.RulesCollection = settings.Rules;
                form.FormsCollection = settings.Forms;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // do we need to save rules from here?
                    settings.Rules = form.RulesCollection;
                    settings.Forms = form.FormsCollection;
                }

                form.Dispose();
            }
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm { StartPosition = FormStartPosition.CenterParent };
            settingsForm.Settings = settings;
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settings = settingsForm.Settings;
            }
        }

        private void SetRulesButtonClick(object sender, EventArgs e)
        {
            var form = new RulesList { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void SetFormsButtonClick(object sender, EventArgs e)
        {
            var form = new FormsList { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void AboutClick(object sender, EventArgs e)
        {
            var form = new About { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void LoadLinksClick(object sender, EventArgs e)
        {
            if (!this.IsValidInit())
                return;

            PopulateLinksTextbox();
        }

        private void PopulateLinksTextbox()
        {
            try
            {
                UrlToProcess = GetLinksClient().Parse().ToDictionary(i => i, i => DisplayResult.Unprocessed);
                environmentLinksItems.FillValuesWithColor(UrlToProcess);

                linksGroupbox.Text = string.Format("Pages to process ({0})", UrlToProcess.Count);
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("Please enter valid hostname / sitemap values into corresponding boxes");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void TestClick(object sender, EventArgs e)
        {
            //ReadWebApi("http://test01/sitecore/api/ssc/item/0DE95AE4-41AB-4D01-9EB0-67441B7C2450/children?database=master");

            //ParseWebApi(apiEndpoint.Text, apiLogin.Text);

            const string URL1 = "https://tfl.gov.uk/\nhttp://tfl.gov.uk/plan-a-journey/\nhttp://tfl.gov.uk/plan-a-journey/results";

            //webApiMode.Checked = true;
            apiEndpoint.Text = "http://test01/sitecore/api/ssc/item/0DE95AE4-41AB-4D01-9EB0-67441B7C2450/children?database=master";
            apiLogin.Text = "sitecore\\admin";
            apiPassword.Text = "b";
            sitemapHost.Text = "https://tfl.gov.uk/";
            sitemapFilename.Text = "sitemap.xml";

            var doc = new XmlDocument();
            doc.Load(string.Format("{0}Settings\\JavascriptRules.xml", PathPrefix));

            environmentLinksItems.Clear();
            environmentLinksItems.Text = URL1;
            //results = new List<Result>
            //{
            //    new Result(URL1)
            //    {
            //        PageResult = ResultCode.Successfull,
            //        PageLoadTime = 1572,
            //        FormResults = new Dictionary<WebForm, ResultCode>
            //        {
            //            { new WebForm(doc.DocumentElement.ChildNodes[0]), ResultCode.Successfull }  
            //        },
            //        RuleResults = new Dictionary<Rule, ResultCode>
            //        {
            //          { new Rule("Has_top_menu_items", "return $('#top_menu_items').length;"), ResultCode.Successfull }  
            //        }

            //    }
            //};
        }
    }
}