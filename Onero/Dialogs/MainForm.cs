using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Onero.Collections;
using Onero.Extensions;
using Onero.Loader;
using Onero.Loader.Results;

namespace Onero.Dialogs
{
    public partial class MainForm : Form
    {
        #region Strings and constants

        private const string PROGRESS_COMPLETED = "Progress: completed {0} pages";
        private const string INVALID_CRAWLING_MODE = "Crawling mode not specified correctly";

        private const string START_BUTTON = "Start";
        private const string CANCEL_BUTTON = "Cancel";
        private const string CANCELLING_BUTTON = "Cancelling...";
        private const string PROGRESS_LABEL = "Progress: {0} of {1}";

        #endregion

        private Loader.Loader loader;
        internal static LoaderSettings settings;
        private List<Result> results;

        public Dictionary<string, DisplayResult> UrlToProcess { get; private set; }

        public MainForm(LoaderSettings _settings)
        {
            InitializeComponent();
            
            settings = _settings;

            ShowTestButton();
            SetFormName();
            LoadLinksFromProfile();

            startButton.Enabled = !string.IsNullOrWhiteSpace(environmentLinksItems.Text);
            startButton.Text = START_BUTTON;

            resultsFolderToolStripMenuItem.Enabled = Directory.Exists(settings.Profile.OutputDirectory);

            DrawProfilesMenu();
        }

        private void SetFormName()
        {
            Text = string.Format("Onero Page Runner - {0}", CurrentProfileName);
        }

        private void ShowTestButton()
        {
            #if (DEBUG)
                testButton.Visible = true;
            #endif
        }

        internal string CurrentProfileName
        {
            get { return settings.Profile.Name; }
            private set { settings.Profile.Name = value; }
        }

        #region Load links features

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
                case CrawlingMode.Sitemap: return new SitemapClient($"{sitemapHost.Text}/{sitemapFilename.Text}");
                case CrawlingMode.WebAPI: return new WebApiClient(apiEndpoint.Text, apiLogin.Text, apiPassword.Text);
                case CrawlingMode.Manual: return new EmptyClient(environmentLinksItems.Text);
            }

            throw new ArgumentOutOfRangeException(INVALID_CRAWLING_MODE);
        }

        private IEnumerable<string> LinksFromTextbox => environmentLinksItems.Text.Trim().Split('\n');

        #endregion

        #region Main Background Worker

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            loader.Start(sender as BackgroundWorker);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var result = (Result)e.UserState;
            
            results.Add(result);

            resultLabel.Text = string.Format(PROGRESS_LABEL, results.Count, LinksFromTextbox.Count());

            environmentLinksItems.ReplaceLine(result.Url, result.IsSuccessful ? DisplayResult.Successful : DisplayResult.Failed);

            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Text = START_BUTTON;
            startButton.Enabled = true;
            startToolStripMenuItem.Text = START_BUTTON;
            startToolStripMenuItem.Enabled = true;

            resultLabel.Text = string.Format(PROGRESS_COMPLETED, results.Count);

            resultsFolderToolStripMenuItem.Enabled = Directory.Exists(settings.Profile.OutputDirectory);

            BlockUserInterfaceOnRun(false);

            Results.WriteCSV(results, settings);
        }

        #endregion

        #region Load links background worker functions

        private void LoadLinksDoWork(object sender, DoWorkEventArgs e)
        {
            PopulateLinksTextbox();
        }

        private void LoadLinksCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            environmentLinksItems.FillValuesWithColor(UrlToProcess);

            loadLinksButton.Enabled = true;
            startButton.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            environmentLinksItems.Enabled = true;

            linksGroupbox.Text = string.Format("Pages to process ({0})", UrlToProcess.Count);
        }

        #endregion

        private void OnStartButonClick(object sender, EventArgs e)
        {
            Run();
        }

        private void Run()
        {
            if (startButton.Text == CANCEL_BUTTON)
            {
                backgroundWorker.CancelAsync();
                startButton.Text = CANCELLING_BUTTON;
                startButton.Enabled = false;

                startToolStripMenuItem.Text = CANCELLING_BUTTON;
                startToolStripMenuItem.Enabled = false;

                return;
            }

            try
            {
                if (!this.IsValid())
                    return;

                settings.Rules = new CollectionOf<Rule>(CurrentProfileName).Read<Rule>().Where(r => r.Enabled);
                settings.Forms = new CollectionOf<Form>(CurrentProfileName).Read<WebForm>().Where(f => f.Enabled);
                settings.PagesToCrawl = LinksFromTextbox;

                SaveLinksFile(CurrentProfileName);

                loader = new Loader.Loader(settings);

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
                startToolStripMenuItem.Text = CANCEL_BUTTON;
                resultLabel.Text = string.Format(PROGRESS_LABEL, 0, LinksFromTextbox.Count());

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
                form.CurrentProfileName = settings.Profile.Name;
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

        private void LoadLinksClick(object sender, EventArgs e)
        {
            if (!this.IsValidInit())
                return;

            if (!loadLinksBackgroundWorker.IsBusy)
            {
                loadLinksButton.Enabled = false;
                startButton.Enabled = false;
                startToolStripMenuItem.Enabled = false;
                environmentLinksItems.Enabled = false;

                loadLinksBackgroundWorker.RunWorkerAsync();                
            }
        }

        private void PopulateLinksTextbox()
        {
            try
            {
                UrlToProcess = GetLinksClient().Parse().ToDictionary(i => i, i => DisplayResult.Unprocessed);
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

        private void BlockUserInterfaceOnRun(bool isBlocked)
        {
            environmentLinksItems.ReadOnly = isBlocked;
            radioButtonLinks.Enabled = !isBlocked;
            radioButtonSitemap.Enabled = !isBlocked;
            radioButtonWebAPI.Enabled = !isBlocked;

            //resultLabel.Visible = !isBlocked;

            progressBar1.Visible = isBlocked;
            loadLinksButton.Enabled = !isBlocked;
        }

        #region Store links with profile

        private string GetLinksFileName(string profileName)
        {
            return CollectionOf<string>.GetFilePath(profileName, "links");
        }

        private void LoadLinksFromProfile()
        {
            var links = new List<string>();

            if (File.Exists(GetLinksFileName(CurrentProfileName)))
            {
                try
                {
                    var doc = new XmlDocument();
                    doc.Load(GetLinksFileName(CurrentProfileName));

                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        if (node.Attributes["url"] != null)
                        {
                            links.Add(node.Attributes["url"].Value);
                        }
                    }
                }
                catch (XmlException)
                {
                }
            }

            environmentLinksItems.Text = string.Join("\n", links);
        }

        private void SaveLinksFile(string profileName)
        {
            var items = environmentLinksItems.Text.Trim().Split('\n');

            var doc = new XDocument();
            var root = new XElement("items");
            doc.Add(root);

            foreach (string url in items)
            {
                var linkElement = new XElement("link");
                linkElement.SetAttributeValue("url", url);
                root.Add(linkElement);
            }

            doc.Save(GetLinksFileName(profileName));
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLinksFile(CurrentProfileName);
        }

        #endregion

        private void LinksTextChanged(object sender, EventArgs e)
        {
            startButton.Enabled = !string.IsNullOrWhiteSpace(environmentLinksItems.Text);
            startToolStripMenuItem.Enabled = startButton.Enabled;
        }

        private void TestClick(object sender, EventArgs e)
        {
            //ReadWebApi("http://test01/sitecore/api/ssc/item/0DE95AE4-41AB-4D01-9EB0-67441B7C2450/children?database=master");

            //ParseWebApi(apiEndpoint.Text, apiLogin.Text);

            const string WebApi = "http://test02/?sc_itemid={110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}";
            const string URL1 = "https://tfl.gov.uk/\nhttp://tfl.gov.uk/plan-a-journey/\nhttp://tfl.gov.uk/plan-a-journey/results";

            //webApiMode.Checked = true;
            apiEndpoint.Text = "http://test02/-/item/v1/?query=/sitecore/content/*";
            apiLogin.Text = "sitecore\\admin";
            apiPassword.Text = "b";
            sitemapHost.Text = "https://tfl.gov.uk";
            sitemapFilename.Text = "sitemap.xml";

            var doc = new XmlDocument();
            doc.Load(string.Format(new CollectionOf<Rule>(CurrentProfileName).FilePath));

            environmentLinksItems.Clear();
            environmentLinksItems.Text = WebApi;
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

        #region Menu items

        

        private void DrawProfilesMenu()
        {
            var profiles = new BindingList<Profile>(Profiles.Read());

            profilesToolStripMenuItem.DropDownItems.Clear();

            foreach (var profile in profiles)
            {
                var item = new ToolStripMenuItem { Name = profile.Name, Text = profile.Name, Checked = profiles.EnabledOrDefault().Name == profile.Name };
                item.Click += ProfileSelected;
                profilesToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void ProfileSelected(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            if (menuItem == null)
            {
                return;
            }

            var previousProfileName = CurrentProfileName;
            SaveLinksFile(previousProfileName);

            var profiles = new BindingList<Profile>(Profiles.Read());
            profiles.EnableProfile(profiles.First(p => p.Name == menuItem.Name));
            CurrentProfileName = menuItem.Name;
            Profiles.Save(profiles);

            SetFormName();
            LoadLinksFromProfile();
            DrawProfilesMenu();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm { StartPosition = FormStartPosition.CenterParent };
            settingsForm.Settings = settings;

            var previousProfileName = CurrentProfileName;

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settings = settingsForm.Settings;
                SetFormName();

                if (previousProfileName != CurrentProfileName)
                {
                    var profiles = new BindingList<Profile>(Profiles.Read());

                    profiles.EnableProfile(profiles.First(p => p.Name == CurrentProfileName));
                    Profiles.Save(profiles);

                    SaveLinksFile(previousProfileName);

                    LoadLinksFromProfile();
                    DrawProfilesMenu();
                }

                resultsFolderToolStripMenuItem.Enabled = Directory.Exists(settings.Profile.OutputDirectory);
            }
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            var form = new RulesList { StartPosition = FormStartPosition.CenterParent };
            form.CurrentProfileName = settings.Profile.Name;
            form.ShowDialog();
            form.Dispose();
        }

        private void Forms_Click(object sender, EventArgs e)
        {
            var form = new FormsList { StartPosition = FormStartPosition.CenterParent };
            form.CurrentProfileName = settings.Profile.Name;
            form.ShowDialog();
            form.Dispose();
        }

        private void About_Click(object sender, EventArgs e)
        {
            var form = new About { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Run();
        }

        #endregion

        private void resultsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(settings.Profile.OutputDirectory))
            {
                Process.Start(settings.Profile.OutputDirectory);
            }
            else
            {
                // MessageBox.Show(RESULT_FOLDER_MISSING);
            }
        }
    }
}