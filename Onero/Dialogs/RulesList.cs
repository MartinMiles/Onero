using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Crawler;

namespace Onero.Dialogs
{
    public partial class RulesList : Form
    {
        private IEnumerable<Rule> rules;

        public RulesList()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            rules = Rules.Read();
            DrawRulesList();

            saveButton.Enabled = false;
        }

        private void DrawRulesList()
        {
            rulesCheckList.Items.Clear();

            for (int i = 0; i < rules.Count(); i++)
            {
                var rule = rules.ElementAt(i);
                rulesCheckList.Items.Add(rule.Name, rule.Enabled);
            }
        }

        // Runs editor window and saves results once editor is closed.
        private void CheckedListBoxDoubleClick(object sender, EventArgs e)
        {
            var clb = sender as CheckedListBox;
            var clickedItem = clb.SelectedItem;

            var rule = rules.FirstOrDefault(r => r.Name == clickedItem as string);

            var editorForm = new RulesEditor { StartPosition = FormStartPosition.CenterParent };
            //editorForm.Message = "Note: to save rules changes into a file - hit 'Save rules' on the\nprevious screen. This screen only modifies but not saves rules";
            editorForm.Title = string.Format("Rule: {0} ({1})", rule.Name, rule.Enabled ? "enabled" : "disabled");

            editorForm.Rule = rule;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rule = editorForm.Rule;
            }
            else if (dialogResult == DialogResult.Yes)
            {
                rules = rules.Where(r => r != rule);
                DrawRulesList();
            }

            editorForm.Dispose();

            saveButton.Enabled = true;
        }

        private void SaveRulesButtonClick(object sender, EventArgs e)
        {
            var checkedRulesNames = rulesCheckList.CheckedItems;
            foreach (Rule rule in rules)
            {
                rule.Enabled = checkedRulesNames.Contains(rule.Name);
            }

            try
            {
                Rules.Save(rules);

                saveButton.Enabled = false;
                Text = "Rules Editor - Successfully saved";
                cancelButton.Text = "Close";
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckedListBoxSingleClick(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void AddNewClick(object sender, EventArgs e)
        {
            var editorForm = new RulesEditor
            {
                StartPosition = FormStartPosition.CenterParent,
                Title = "Please enter a new rule:",
                Rule = new Rule(String.Empty, String.Empty)
            };

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                rules = rules.Concat(new[] { editorForm.Rule });
                DrawRulesList();

                saveButton.Enabled = true;
            }

            editorForm.Dispose();
        }
    }
}
