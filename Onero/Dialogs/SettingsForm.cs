using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Loader;
using Onero.Extensions;

namespace Onero.Dialogs
{
    public partial class SettingsForm : Form
    {
        private const string RESULTS_DIR_REMOVED = "Results directory removed";
        private const string RESULT_FOLDER_MISSING = "Result folder does not exist. Run tests first.";

        private const string RESULTS_DIRECTORY = "Results";
        private const int DEFAULT_TIMEOUT = 60;

        public LoaderSettings Settings { get; set; }

        public BindingList<Profile> profiles; 

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            profiles = new BindingList<Profile>(Profiles.Read());

            SetProfileCombobox();
            SetForm();
        }

        private void SetForm()
        {
            createScreenshots.Checked = CurrentProfile.CreateScreenshots;
            verbose.Checked = CurrentProfile.VerboseMode;
            showFirefox.Checked = CurrentProfile.RunInBrowser;
            outputPath.Text = CurrentProfile.OutputDirectory;                      //TODO: revise here
            timeOut.Text = CurrentProfile.Timeout.ToString();
        }

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

        private Profile CurrentProfile
        {
            get { return profileCombobox.SelectedItem as Profile; }
        }
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
            CurrentProfile.OutputDirectory = outputPath.Text.Trim();
            CurrentProfile.RunInBrowser = showFirefox.Checked;
            CurrentProfile.VerboseMode = verbose.Checked;
            CurrentProfile.CreateScreenshots = createScreenshots.Checked;
            
            EnableProfile(CurrentProfile);

            Profiles.Save(profiles);

            if (!isExistingProfile)
            {
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
            DialogResult result = folderDialog.ShowDialog();
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

            EnableProfile(CurrentProfile);

            SetForm();
        }

        private void EnableProfile(Profile profileToEnable)
        {
            foreach (var profile in profiles)
            {
                profile.Enabled = false;
            }

            profileToEnable.Enabled = true;            
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
                Timeout = DEFAULT_TIMEOUT,
                OutputDirectory = string.Format("{0}\\{1}", DefaultOutputPath, name)
            };

            profiles.Add(newProfile);
            EnableProfile(newProfile);

            SetProfileCombobox();

            newProfileName.Text = String.Empty;
            addProfileButton.Enabled = false;
        }

        private void DeleteProfileClick(object sender, EventArgs e)
        {
            string derectoryName = string.Format("{0}\\{1}", Profiles.SettingsDirectory, CurrentProfile.Name);
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
    }
}
