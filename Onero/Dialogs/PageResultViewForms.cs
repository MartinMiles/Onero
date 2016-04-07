using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Extensions;
using Onero.Loader;
using Onero.Loader.Actions;
using Onero.Loader.Broken;
using Onero.Loader.Interfaces;
using Onero.Loader.Results;

namespace Onero.Dialogs
{
    public partial class PageResultViewForms : Form
    {
        private const string RESULT_FOLDER_MISSING = "Result folder does not exist. Run tests first.";

        internal static LoaderSettings settings;

        private static Dictionary<Type, RichTextBox> boxes;

        readonly Dictionary<Type, Func<Type, Result, bool>> forms = new Dictionary<Type, Func<Type, Result, bool>> {

                                            { typeof(RulesExecuteAction), (type, result) => Fill(type, result.GenericResults)},
                                            { typeof(FormSubmitAction), (type, result) => Fill(type, result.GenericResults)},
                                            { typeof(BrokenLinksAction), (type, result) => FillBrokenLinks(type, result.GenericResults) },
                                            { typeof(DataExtractAction), (type, result) => DataExtractResult(type, result.GenericResults) }
                                        };

        public Result PageResult { get; set; }

        private static string ExtractDirectory => $"{settings.Profile.OutputDirectory}\\Extracts";

        public PageResultViewForms(LoaderSettings _settings)
        {
            InitializeComponent();
            settings = _settings;
        }

        private void PageResultViewForms_Load(object sender, EventArgs e)
        {
            boxes = new Dictionary<Type, RichTextBox>
            {
                { typeof (RulesExecuteAction), rulesBox },
                { typeof (FormSubmitAction), formsBox },
                { typeof (BrokenLink), linksBox },
                { typeof (BrokenImage), imagesBox },
                { typeof (BrokenScript), scriptsBox },
                { typeof (BrokenStyle), stylesBox }
            };

            urlLabel.Text = PageResult.Url;

            time.Text = PageResult.PageLoadTime.ToString("#,##0");
            pageResult.Text = PageResult.PageResult.ToString();

            foreach (var result in PageResult.GenericResults)
            {
                if (forms.ContainsKey(result.Key))
                {
                    forms[result.Key](result.Key, PageResult);
                }
            }
        }

        private static bool DataExtractResult(Type type, Dictionary<Type, dynamic> results)
        {
            foreach (DataExtractResult result in results[type])
            {
                if (!Directory.Exists(ExtractDirectory))
                {
                    Directory.CreateDirectory(ExtractDirectory);
                }

                var filename = $"{ExtractDirectory}\\{result.DataExtractItem.Name} - {UrlToFilename(result.UrlTaken)}.txt";
                File.WriteAllText(filename, result.Value);
            }

            return true;
        }

        private static string UrlToFilename(string url)
        {
            // TODO: Change filename into smth more friendly
            // Data extractor page - test 1 - http___localhost_8540_Home_ExtractData
            return Path.GetInvalidFileNameChars().Aggregate(url, (current, c) => current.Replace(c, '_'));
        }

        private static bool Fill(Type type, Dictionary<Type, dynamic> results)
        {
            FillRichTextBox(boxes[type], results[type]);
            return true;
        }
        private static bool FillBrokenLinks(Type type, Dictionary<Type, dynamic> results)
        {
            FillRichTextBox(boxes[typeof(BrokenLink)], results[type].Links);
            FillRichTextBox(boxes[typeof(BrokenImage)], results[type].Images);
            FillRichTextBox(boxes[typeof(BrokenScript)], results[type].Scripts);
            FillRichTextBox(boxes[typeof(BrokenStyle)], results[type].Styles);

            return true;
        }

        private static void FillRichTextBox<T>(RichTextBox box, Dictionary<T, ResultCode> displayResults) where T : INameable
        {
            var displayResultsRule = displayResults.ToDictionary(
                r => $"{r.Key.Name} - {r.Value.GetDescription()}",
                r => r.Value == ResultCode.Successful ? DisplayResult.Successful : DisplayResult.Failed);

            box.FillValuesWithColor(displayResultsRule);
        }

        private static void FillRichTextBox(RichTextBox box, IEnumerable<string> results)
        {
            var displayResults = results.ToDictionary(r => r, r => DisplayResult.Failed);
            box.FillValuesWithColor(displayResults); 
        }

        private void RulesDoubleClick(object sender, EventArgs e)
        {
            var clickedLine = rulesBox.GetClickedString(e as MouseEventArgs);
            
            if (string.IsNullOrWhiteSpace(clickedLine))
                return;

            var ruleName = TrimNameFromStatus(clickedLine);

            var editorForm = new RulesEditor { StartPosition = FormStartPosition.CenterParent };

            editorForm.Entity = settings.Rules.First(r => r.Name == ruleName);

            ////editorForm.Message = "Note: to save rules changes into a file - hit 'Save rules' on the\nprevious screen. This screen only modifies but not saves rules";
            //editorForm.Title = string.Format("Rule: {0} ({1})", rule.Name, rule.Enabled ? "enabled" : "disabled");
            //editorForm.NameBox = rule.Name;
            //editorForm.EditBox = rule.Condition;

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                //rule = editorForm.Rule;
                 
                //rule.Name = editorForm.NameBox.Trim();
                //rule.Condition = editorForm.EditBox.Trim();

                //new CollectionOf<Rule>(settings.Profile.Name).Save(RulesCollection);
                    
                FillRichTextBox(rulesBox, PageResult.RuleResults);
            }
            // delete rule?? *.Yes ???

            editorForm.Dispose();
        }

        private string TrimNameFromStatus(string rulenameWithStatus)
        {
            const string separator = " - ";

            var arr = rulenameWithStatus.Split(new[] { separator }, StringSplitOptions.None);

            if (arr.Length > 1)
            {
                return string.Join(separator, arr.Take(arr.Length - 1));
            }

            return arr[0];
        }

        private void OkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void FormsDoubleClick(object sender, EventArgs e)
        {
            var clickedLine = formsBox.GetClickedString(e as MouseEventArgs);

            if(string.IsNullOrWhiteSpace(clickedLine))
                return;

            var ruleName = TrimNameFromStatus(clickedLine);

            var form = settings.Forms.FirstOrDefault(f => f.Name == ruleName);

            var editorForm = new FormsEditor { StartPosition = FormStartPosition.CenterParent };
            //editorForm.Message = "Note: to save rules changes into a file - hit 'Save rules' on the\nprevious screen. This screen only modifies but not saves rules";
            //editorForm.Title = string.Format("Form: {0} ({1})", form.Name, form.Enabled ? "enabled" : "disabled");
            //editorForm.NameBox = form.Name;
            editorForm.Form = form;
            //editorForm.EditBox = form.Condition;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                form = editorForm.Form;
                //form.Condition = editorForm.EditBox;

                //Forms.Save(FormsCollection);
                FillRichTextBox(formsBox, PageResult.FormResults);

            }
            else if (dialogResult == DialogResult.Yes)
            {
                //FormsCollection = FormsCollection.Where(f => f != form);

                //Forms.Save(FormsCollection);
                //forms = forms.Where(r => r != form);
                //DrawFormsList();
                FillRichTextBox(formsBox, PageResult.FormResults);
            }

            editorForm.Dispose();
        }

        private void openExtractFolderButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ExtractDirectory))
            {
                Process.Start(ExtractDirectory);
            }
            else
            {
                MessageBox.Show(RESULT_FOLDER_MISSING);
            }
        }
    }
}
