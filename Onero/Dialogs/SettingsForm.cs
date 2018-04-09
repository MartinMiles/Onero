using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Loader;
using Onero.Extensions;
using Onero.Helper.Browsers;
using Onero.Helper.Extensions;

namespace Onero.Dialogs
{
    public partial class SettingsForm : Form
    {
        private const string RESULTS_DIR_REMOVED = "Results directory removed";
        private const string RESULT_FOLDER_MISSING = "Result folder does not exist. Run tests first.";

        private const string RESULTS_DIRECTORY = "Results";

        //private const int DEFAULT_TIMEOUT = 60;
        //private const int DEFAULT_WIDTH = 1920;
        //private const int DEFAULT_HEIGHT = 1080;

        public LoaderSettings Settings { get; set; }

        public BindingList<Profile> profiles; 

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            profiles = new BindingList<Profile>(Profiles.Read());

            SetBrowserCombobox();
            SetProfileCombobox();
            SetForm();
        }

        private void SetBrowserCombobox()
        {
            var currentlySupportedBrowsers = typeof(SupportedBrowser).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(field => !field.IsDefined(typeof(IgnoreBrowserAttribute), false))
                .Select(field => (SupportedBrowser)field.GetValue(null)).ToArray();

            // display only those Browsers that do not have [IgnoreBrowser] attribute. Prevoiusly was: foreach (Browser item in Enum.GetValues(typeof (Browser)))
            foreach (SupportedBrowser item in currentlySupportedBrowsers)
            {
                browserCombobox.Items.Add(item.GetDescription());
            }
        }

        private void SetForm()
        {
            createScreenshots.Checked = CurrentProfile.CreateScreenshots;
            verbose.Checked = CurrentProfile.VerboseMode;
            createErrorLog.Checked = CurrentProfile.CreateErrorLog;
            sendErrorsAndStats.Checked = CurrentProfile.SendErrorsAndStats;
            outputPath.Text = CurrentProfile.OutputDirectory;
            timeOut.Text = CurrentProfile.Timeout.ToString();
            widthBox.Text = CurrentProfile.Width.ToString();
            heightBox.Text = CurrentProfile.Height.ToString();

            browserCombobox.SelectedItem = CurrentProfile.Browser.GetDescription();
        }

        private static string DefaultOutputPath
        {
            get
            {
                string directory = Environment.CurrentDirectory;

                //#if (DEBUG)
                //    directory = Directory.GetParent(directory).ToString();
                //#endif

                return $"{directory}\\{RESULTS_DIRECTORY}";
            }
        }

        private Profile CurrentProfile => profileCombobox.SelectedItem as Profile;

        private Profile DefaultProfile
        {
            get { return profiles.First(p => p.Name == "Default"); }
        }

        private void SetProfileCombobox()
        {
            var enabledProfile = profiles.FirstOrDefault(p => p.Enabled);

            profileCombobox.DataSource = profiles;
            profileCombobox.DisplayMember = "Name";
            profileCombobox.ValueMember = "Name";

            if (enabledProfile != null)
            {
                profileCombobox.SelectedItem = enabledProfile;
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (!this.IsValid()) // validate name (to be as dirname)
            {
                return;
            }

            bool isExistingProfile = Profiles.Read().Any(p => p.Name == CurrentProfile.Name);

            CurrentProfile.Timeout = timeOut.Text.Parse(0);
            CurrentProfile.Width = widthBox.Text.Parse(0);
            CurrentProfile.Height = heightBox.Text.Parse(0);
            CurrentProfile.OutputDirectory = outputPath.Text.Trim();
            CurrentProfile.VerboseMode = verbose.Checked;
            CurrentProfile.CreateErrorLog = createErrorLog.Checked;
            CurrentProfile.SendErrorsAndStats = sendErrorsAndStats.Checked;
            CurrentProfile.CreateScreenshots = createScreenshots.Checked;
            CurrentProfile.Browser = SelectedBrowser;

            profiles.EnableProfile(CurrentProfile);
            Profiles.Save(profiles);

            if (!isExistingProfile)
            {
                // TODO: What about others?
                new CollectionOf<Rule>(CurrentProfile.Name).Create<Rule>();
                new CollectionOf<WebForm>(CurrentProfile.Name).Create<WebForm>();
            }

            Settings.Profile = CurrentProfile;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClearClick(object sender, EventArgs e)
        {
            string resultDirectory = outputPath.Text;
            if (Directory.Exists(resultDirectory))
            {
                Directory.Delete(resultDirectory, true);
                MessageBox.Show(RESULTS_DIR_REMOVED);
                deleteResultsButton.Enabled = false;
            }
        }

        private void OpenInExplorerButtonClick(object sender, EventArgs e)
        {
            string resultDirectory = outputPath.Text;
            if (Directory.Exists(resultDirectory))
            {
                Process.Start(resultDirectory);
            }
            else
            {
                MessageBox.Show(RESULT_FOLDER_MISSING);
            }
        }

        private void ChangeButtonClick(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            var result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                outputPath.Text = folderDialog.SelectedPath;
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ProfileComboboxChanged(object sender, EventArgs e)
        {
            deleteProfileButton.Enabled = CurrentProfile != DefaultProfile;

            profiles.EnableProfile(CurrentProfile);

            SetForm();
        }


        private void AddProfileClick(object sender, EventArgs e)
        {
            if (!this.IsValidAddProfile())
            {
                return;
            }

            string name = newProfileName.Text.Trim();

            var newProfile = new Profile(name)
            {
                //Timeout = DEFAULT_TIMEOUT,
                //Width = DEFAULT_WIDTH,
                //Height = DEFAULT_HEIGHT,
                OutputDirectory = $"{DefaultOutputPath}\\{name}"
            };

            profiles.Add(newProfile);
            profiles.EnableProfile(newProfile);

            SetProfileCombobox();

            newProfileName.Text = String.Empty;
            addProfileButton.Enabled = false;
        }

        private void DeleteProfileClick(object sender, EventArgs e)
        {
            string derectoryName = $"{Profiles.SETTINGS_DIRECTORY}\\{CurrentProfile.Name}";
            if (Directory.Exists(derectoryName))
            {
                Directory.Delete(derectoryName, true);
            }
            
            profiles.Remove(CurrentProfile);

            DefaultProfile.Enabled = true;

            SetForm();
        }

        private void NewProfileTextChanged(object sender, EventArgs e)
        {
            addProfileButton.Enabled = !string.IsNullOrWhiteSpace(newProfileName.Text);
        }

        private SupportedBrowser SelectedBrowser =>
            EnumExtensions.GetValueFromDescription<SupportedBrowser>((string)browserCombobox.SelectedItem);
    }
}
