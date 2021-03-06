﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Dialogs;
using Onero.Loader;
using Onero.Loader.Forms;
using Onero.Loader.Results;

namespace Onero.Extensions
{
    public static class Validation
    {
        #region Constants

        private const string ERROR = "Error";
        private const string VALIDATION_ERROR = "Validation error";

        // regex
        private const string NAME_REGEX = "^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$";
        private const string URL_SUBSET_REGEX = "^[a-zA-Z:/?.=&+!*'(), 0-9$_-]*$";

        // messages
        private const string NAME_SHOULD_NOT_BE_EMPTY = "Name should not be empty";
        private const string NAME_CONTAINS_INVALID_CHARS = "Name contains invalid characters";
        private const string TEXT_SHOULD_NOT_BE_EMPTY = "Text should not be empty";

        private const string URL_PATTERN_SHOULD_NOT_BE_EMTY = "ULR pattern should not be empty";
        private const string URL_PATTERN_WRONG_MODE = "ULR pattern(s) should be set if you are using Include or Exclude mode";

        private const string URL_PATTERN_WRONG_CHARS = "URL pattern contains invalid characters";

        private const string URL_PATTERN_MISSING = "Please enter at least one URL match patter for the form";
        private const string SUBMIT_BUTTON_EMPTY = "Submit button ID should not be empty";
        private const string ID_AND_VALUE_INVALID = "ID and value should be both filled and valid";
        private const string REDIRECT_URL_EMPTY = "Redirect URL should not be empty when using Redirect result type";
        private const string ID_EMPTY_WHEN_MESSAGE_RESULT_TYPE = "ID should not be empty when using Message result type";

        private const string HOSTNAME_NOT_SELECTED = "Hostname is not selected";
        private const string SITEMAP_NOT_SET = "Sitemap file is not set";
        private const string NO_LINKS_ARE_SET = "No links are set";
        //private const string RULES_FILE_NOT_EXISTS_AT = "Rules file does not exist at: {0}";
        //private const string FORMS_FILE_NOT_EXISTS_AT = "Forms file does not exist at: {0}";

        private const string SITEMAP_MODE_HOST_AND_FILE_EMPTY = "Sitemap host / filenames fields should not be empty when running Sitemap mode";
        private const string WEBAPI_MODE_ENDPOINT_EMPTY = "Endpoint URL should not be empty when running Sitecore WebAPI mode";

        // settings form
        private const string OUTPUT_PATH_NOT_SET = "Output path is not set";
        private const string INVALID_TIMEOUT = "Please input valid TimeOut value";

        private const string PROFILE_ALREADY_EXISTS = "Profile with this name already exists";
        private const string PROFILE_NAME_MISMATCH = "Profile name mismatch";

        private const string COFIRMATION_REQURIED = "Confirmation requried";
        private const string LOOSE_SELECTOR = "At least one of selectors on this form does not start with '.' or '#'. Is that correct?";

        private const string OUTPUT_DIRECTORY_UNDEFINED = "Output directory is undefined. Navigate to Configuration -> Settings to set it.";

        // broken links
        private const string CHECK_ALL_OR_ADD_NEW_LINKS = "Please check 'Test all the pages for broken links' or enter at least one testing pattern";
        private const string CHECK_ALL_OR_ADD_NEW_IMAGES = "Please check 'Test all the pages for broken images' or enter at least one testing pattern";
        private const string CHECK_PATTER_OR_ALL_LINKS = "Please enable at least one testing pattern or check 'Test all the pages for broken links'";
        private const string CHECK_PATTER_OR_ALL_IMAGES = "Please enable at least one testing pattern or check 'Test all the pages for broken images'";

        #endregion

        public static bool IsValid(this SettingsForm formEditor)
        {
            string outputPathValue = formEditor.outputPath.Text.Trim();
            if (!outputPathValue.Any())
            {
                MessageBox.Show(OUTPUT_PATH_NOT_SET, ERROR);
                return false;
            }

            int timeout = formEditor.timeOut.Text.Parse(0);
            if (timeout < 1)
            {
                MessageBox.Show(INVALID_TIMEOUT);
                return false;
            }
            
            return true;
        }

        public static bool IsValidAddProfile(this SettingsForm formEditor)
        {
            if (formEditor.profiles.Any(i => i.Name == formEditor.newProfileName.Text))
            {
                MessageBox.Show(PROFILE_ALREADY_EXISTS);
                return false;
            }

            if (!new Regex(NAME_REGEX).IsMatch(formEditor.newProfileName.Text))
            {
                MessageBox.Show(PROFILE_NAME_MISMATCH);
                return false;
            }

            return true;
        }

        public static bool IsValid(this RulesEditor formEditor)
        {
            if (String.IsNullOrWhiteSpace(formEditor.nameTextbox.Text))
            {
                MessageBox.Show(NAME_SHOULD_NOT_BE_EMPTY, VALIDATION_ERROR);
                return false;
            }

            if (!new Regex(NAME_REGEX).IsMatch(formEditor.nameTextbox.Text))
            {
                MessageBox.Show(NAME_CONTAINS_INVALID_CHARS, VALIDATION_ERROR);
                return false;
            }

            if (String.IsNullOrWhiteSpace(formEditor.editBox.Text))
            {
                MessageBox.Show(TEXT_SHOULD_NOT_BE_EMPTY, VALIDATION_ERROR);
                return false;
            }

            if (formEditor.ruleScopeCombobox.SelectedIndex > 0)
            {
                if (String.IsNullOrWhiteSpace(formEditor.urlTextbox.Text))
                {
                    MessageBox.Show(URL_PATTERN_WRONG_MODE, VALIDATION_ERROR);
                    return false;
                }

                if (!new Regex(URL_SUBSET_REGEX).IsMatch(formEditor.urlTextbox.Text))
                {
                    MessageBox.Show(URL_PATTERN_WRONG_CHARS, VALIDATION_ERROR);
                    return false;
                }
            }

            return true;
        }

        // TODO: Test this functionality
        public static bool IsValid(this BrokenItems editor)
        {
            //if (!editor.testAllLinks.Checked && editor.linksCheckList.Items.Count == 0)
            //{
            //    MessageBox.Show(CHECK_ALL_OR_ADD_NEW_LINKS, VALIDATION_ERROR);
            //    return false;
            //}
            //if (!editor.testAllImages.Checked && editor.imagesCheckList.Items.Count == 0)
            //{
            //    MessageBox.Show(CHECK_ALL_OR_ADD_NEW_IMAGES, VALIDATION_ERROR);
            //    return false;
            //}

            //if (!editor.testAllLinks.Checked && editor.linksCheckList.CheckedItems.Count == 0)
            //{
            //    MessageBox.Show(CHECK_PATTER_OR_ALL_LINKS, VALIDATION_ERROR);
            //    return false;
            //}
            //if (!editor.testAllImages.Checked && editor.imagesCheckList.CheckedItems.Count == 0)
            //{
            //    MessageBox.Show(CHECK_PATTER_OR_ALL_IMAGES, VALIDATION_ERROR);
            //    return false;
            //}

            return true;
        }

        public static bool IsValid(this BrokenItemEditor editor)
        {
            if (String.IsNullOrWhiteSpace(editor.nameTextbox.Text))
            {
                MessageBox.Show(NAME_SHOULD_NOT_BE_EMPTY, VALIDATION_ERROR);
                return false;
            }

            if (String.IsNullOrWhiteSpace(editor.urlTextbox.Text))
            {
                MessageBox.Show(URL_PATTERN_SHOULD_NOT_BE_EMTY, VALIDATION_ERROR);
                return false;
            }

            if (!new Regex(NAME_REGEX).IsMatch(editor.nameTextbox.Text))
            {
                MessageBox.Show(NAME_CONTAINS_INVALID_CHARS, VALIDATION_ERROR);
                return false;
            }

            if (!new Regex(URL_SUBSET_REGEX).IsMatch(editor.urlTextbox.Text))
            {
                MessageBox.Show(URL_PATTERN_WRONG_CHARS, VALIDATION_ERROR);
                return false;
            }

            return true;
        }

        public static bool IsValid(this FormsEditor formEditor)
        {
            if (String.IsNullOrWhiteSpace(formEditor.nameTextbox.Text))
            {
                MessageBox.Show(NAME_SHOULD_NOT_BE_EMPTY, VALIDATION_ERROR);
                return false;
            }

            if (String.IsNullOrWhiteSpace(formEditor.urlTextbox.Text))
            {
                MessageBox.Show(URL_PATTERN_MISSING, VALIDATION_ERROR);
                return false;
            }

            if (String.IsNullOrWhiteSpace(formEditor.submitButtonId.Text))
            {
                MessageBox.Show(SUBMIT_BUTTON_EMPTY, VALIDATION_ERROR);
                return false;
            }

            bool looseSelectorDetected = false;

            for (int i = 0; i < 7; i++)
            {
                var field = formEditor.fieldsGroupbox.Controls.Find("fieldId" + (i + 1), true).First() as TextBox;
                var type = formEditor.fieldsGroupbox.Controls.Find("fieldtype" + (i + 1), true).First() as ComboBox;
                var value = formEditor.fieldsGroupbox.Controls.Find("fieldValue" + (i + 1), true).First() as TextBox;

                if (field != null && value != null && 
                    (!String.IsNullOrWhiteSpace(field.Text) && String.IsNullOrWhiteSpace(value.Text) && (FieldType)type.SelectedItem != FieldType.ClickItem)
                    || 
                    (String.IsNullOrWhiteSpace(field.Text) && !String.IsNullOrWhiteSpace(value.Text))
                    )
                {
                    MessageBox.Show(ID_AND_VALUE_INVALID, VALIDATION_ERROR);
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(field.Text) && !(field.Text.StartsWith("#") || field.Text.StartsWith(".")))
                {
                    looseSelectorDetected = true;
                }
            }

            string submitId = formEditor.submitButtonId.Text;
            looseSelectorDetected = looseSelectorDetected || !(submitId.StartsWith("#") || submitId.StartsWith("."));

            if (formEditor.ResultType == FormResultType.Redirect && String.IsNullOrWhiteSpace(formEditor.resultUrl.Text))
            {
                MessageBox.Show(REDIRECT_URL_EMPTY, VALIDATION_ERROR);
                return false;
            }
            if (formEditor.ResultType == FormResultType.Message && String.IsNullOrWhiteSpace(formEditor.resultId.Text))
            {
                MessageBox.Show(ID_EMPTY_WHEN_MESSAGE_RESULT_TYPE, VALIDATION_ERROR);
                return false;
            }

            if (looseSelectorDetected)
            {
                var dialogResult = MessageBox.Show(LOOSE_SELECTOR, COFIRMATION_REQURIED, MessageBoxButtons.YesNo);
                return dialogResult == DialogResult.Yes;
            }

            return true;
        }

        public static bool IsValid(this MainForm mainForm)
        {
            var rulesCollection = new CollectionOf<Rule>(mainForm.CurrentProfileName);
            if (!File.Exists(rulesCollection.FilePath))
            {
                rulesCollection.Save(new List<Rule>());
            }

            var formsCollection = new CollectionOf<WebForm>(mainForm.CurrentProfileName);
            if (!File.Exists(formsCollection.FilePath))
            {
                formsCollection.Save(new List<WebForm>());
            }

            if (MainForm.settings.Profile.OutputDirectory == null)
            {
                MessageBox.Show(OUTPUT_DIRECTORY_UNDEFINED, ERROR);
                return false;
            }

            if (mainForm.radioButtonSitemap.Checked)
            {
                string hostName = mainForm.sitemapHost.Text.Trim().TrimEnd('/');
                string sitemapFile = mainForm.sitemapFilename.Text.Trim();

                if (!hostName.Any())
                {
                    MessageBox.Show(HOSTNAME_NOT_SELECTED, ERROR);
                    return false;
                }

                if (!sitemapFile.Trim().Any())
                {
                    MessageBox.Show(SITEMAP_NOT_SET, ERROR);
                    return false;
                }
            }
            else if (mainForm.radioButtonLinks.Checked)
            {
                string URLs = mainForm.environmentLinksItems.Text.Trim();

                if (!URLs.Any())
                {
                    MessageBox.Show(NO_LINKS_ARE_SET, ERROR);
                    return false;
                }
            }
            else
            {
                // support WebApi
            }

            return true;
        }

        public static bool IsValidInit(this MainForm mainForm)
        {
            if (mainForm.CurrentCrawlingMode == CrawlingMode.Sitemap 
                && string.IsNullOrWhiteSpace(mainForm.sitemapHost.Text) 
                && string.IsNullOrWhiteSpace(mainForm.sitemapFilename.Text))
            {
                MessageBox.Show(SITEMAP_MODE_HOST_AND_FILE_EMPTY);
                return false;
            }

            if (mainForm.CurrentCrawlingMode == CrawlingMode.WebAPI
                && string.IsNullOrWhiteSpace(mainForm.apiEndpoint.Text))
            {
                MessageBox.Show(WEBAPI_MODE_ENDPOINT_EMPTY);
                return false;
            }

            return true;
        }
    }
}
