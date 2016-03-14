using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Loader;
using Onero.Loader.Interfaces;
using Onero.Loader.Results;

namespace Onero.Dialogs
{
    public partial class PageResultViewForms : Form
    {
        public Result PageResult { get; set; }

        public string CurrentProfileName { get; internal set; }
        public IEnumerable<Rule> RulesCollection { get; set; }
        public IEnumerable<WebForm> FormsCollection { get; set; }

        public PageResultViewForms()
        {
            InitializeComponent();
        }

        private void PageResultViewForms_Load(object sender, EventArgs e)
        {
            urlLabel.Text = PageResult.Url;

            time.Text = PageResult.PageLoadTime.ToString("#,##0");
            pageResult.Text = PageResult.PageResult.ToString();

            FillRichTextBox(rulesBox, PageResult.RuleResults);
            FillRichTextBox(formsBox, PageResult.FormResults);
            FillRichTextBox(linksBox, PageResult.BrokenLinksResult.Links);
            FillRichTextBox(imagesBox, PageResult.BrokenLinksResult.Images);
        }

        private void FillRichTextBox<T>(RichTextBox box, Dictionary<T, ResultCode> displayResults) where T : INameable
        {
            var displayResultsRule = displayResults.ToDictionary(
                r => $"{r.Key.Name} - {r.Value}",
                r => r.Value == ResultCode.Successful ? DisplayResult.Successful : DisplayResult.Failed);

            box.FillValuesWithColor(displayResultsRule);
        }

        private void FillRichTextBox(RichTextBox box, IEnumerable<string> results)
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

            editorForm.Entity = RulesCollection.First(r => r.Name == ruleName);

            ////editorForm.Message = "Note: to save rules changes into a file - hit 'Save rules' on the\nprevious screen. This screen only modifies but not saves rules";
            //editorForm.Title = string.Format("Rule: {0} ({1})", rule.Name, rule.Enabled ? "enabled" : "disabled");
            //editorForm.NameBox = rule.Name;
            //editorForm.EditBox = rule.Condition;

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                //rule = editorForm.Rule;
                 
                //rule.Name = editorForm.NameBox.Trim();
                //rule.Condition = editorForm.EditBox.Trim();

                new CollectionOf<Rule>(CurrentProfileName).Save(RulesCollection);
                    
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

            var form = FormsCollection.FirstOrDefault(f => f.Name == ruleName);

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
                FormsCollection = FormsCollection.Where(f => f != form);
                //Forms.Save(FormsCollection);
                //forms = forms.Where(r => r != form);
                //DrawFormsList();
                FillRichTextBox(formsBox, PageResult.FormResults);
            }

            editorForm.Dispose();
        }
    }
}
