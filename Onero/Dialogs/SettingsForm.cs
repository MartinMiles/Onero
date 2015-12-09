using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Onero.Crawler;

namespace Onero.Dialogs
{
    public partial class SettingsForm : Form
    {
        private const string ERROR = "Error";
        private const string RESULTS_DIR_REMOVED = "Results directory removed";
        private const string RESULT_FOLDER_MISSING = "Result folder does not exist. Run tests first.";
        private const string OUTPUT_PATH_NOT_SET = "Output path is not set";
        private const string INVALID_TIMEOUT = "Please input valid TimeOut value";
        private const string TIMEOUT_RANGE_INVALID = "TimeOut value should be an integer value more that zero";

        public CrawlerSettings Settings { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            createScreenshots.Checked = Settings.CreateScreenshots;
            verbose.Checked = Settings.Verbose;
            showFirefox.Checked = Settings.ShowFirefox;
            outputPath.Text = Settings.OutputPath;
            timeOut.Text = Settings.TimeOut.ToString();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            // timeout value is already set in validation method below.
            Settings.ShowFirefox = showFirefox.Checked;
            Settings.Verbose = verbose.Checked;
            Settings.OutputPath = outputPath.Text.Trim();
            Settings.CreateScreenshots = createScreenshots.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInputs()
        {
            string outputPathValue = outputPath.Text.Trim();
            if (!outputPathValue.Any())
            {
                MessageBox.Show(OUTPUT_PATH_NOT_SET, ERROR);
                return false;
            }

            int timeOutSeconds;
            if (int.TryParse(timeOut.Text, out timeOutSeconds))
            {
                if (timeOutSeconds > 0)
                {
                    Settings.TimeOut = timeOutSeconds;
                }
                else
                {
                    MessageBox.Show(TIMEOUT_RANGE_INVALID);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(INVALID_TIMEOUT);
                return false;
            }
            return true;
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
    }
}
