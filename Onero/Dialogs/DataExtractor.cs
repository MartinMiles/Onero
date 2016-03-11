using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Extensions;
using Onero.Loader;
using Onero.Loader.Interfaces;

namespace Onero.Dialogs
{
    public partial class DataExtractor : Form
    {
        private IEnumerable<DataExtractItem> rules;

        public IProfile CurrentProfile { get; internal set; }

        public DataExtractor()
        {
            InitializeComponent();
        }

        private void DataExtractor_Load(object sender, EventArgs e)
        {
            rules = new CollectionOf<DataExtractItem>(CurrentProfile.Name).Read<DataExtractItem>();
            DrawRulesList();

            //EnsureVisibility();

            //DrawChecklists();

            saveButton.Enabled = false;
        }



        #region To base class move

        private void DrawRulesList() //TODO: Copied from RulesList
        {
            rulesCheckList.Items.Clear();

            for (int i = 0; i < rules.Count(); i++)
            {
                var rule = rules.ElementAt(i);
                rulesCheckList.Items.Add(rule.NameWithPrefix, rule.Enabled);
            }
        }

        private void CheckedListBoxSingleClick(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void CheckedListBoxDoubleClick(object sender, EventArgs e)
        {
            var rule = rules.FirstOrDefault(r => r.NameWithPrefix == (sender as CheckedListBox).GetSelectedString());

            if (rule == null)
            {
                return;
            }

            var editorForm = new ExtractorEditor { StartPosition = FormStartPosition.CenterParent };
            //editorForm.Message = "Note: to save rules changes into a file - hit 'Save rules' on the\nprevious screen. This screen only modifies but not saves rules";
            editorForm.Title = $"Rule: {rule.Name} ({(rule.Enabled ? "enabled" : "disabled")})";

            editorForm.Entity = rule;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rule = editorForm.Entity;
            }
            else if (dialogResult == DialogResult.Yes)
            {
                rules = rules.Where(r => r != rule);
            }
            else
            {
                return;
            }

            DrawRulesList();

            editorForm.Dispose();

            saveButton.Enabled = true;
        }

        #endregion


        private void Save_Click(object sender, EventArgs e)
        {
            var checkedRulesNames = rulesCheckList.CheckedItems;
            foreach (DataExtractItem rule in rules)
            {
                rule.Enabled = checkedRulesNames.Contains(rule.NameWithPrefix);
            }

            try
            {
                new CollectionOf<DataExtractItem>(CurrentProfile.Name).Save(rules);

                saveButton.Enabled = false;
                Text = "Rules Editor - Successfully saved";
                cancelButton.Text = "Close";
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            var editorForm = new ExtractorEditor
            {
                StartPosition = FormStartPosition.CenterParent,
                Title = "Please enter a new data extract:",
                Entity = new DataExtractItem(String.Empty, String.Empty)
            };

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                rules = rules.Concat(new[] { editorForm.Entity });
                DrawRulesList();

                saveButton.Enabled = true;
            }

            editorForm.Dispose();
        }


    }
}
