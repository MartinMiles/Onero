using System;
using System.Linq;
using System.Windows.Forms;
using Onero.Loader;

namespace Onero.Dialogs
{
    public partial class RulesEditor : Form
    {
        public RulesEditor()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        #region Properties

        public string Title
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        #endregion

        public RuleExecutionScope RuleScope
        {
            get
            {
                RuleExecutionScope scope;
                RuleExecutionScope.TryParse(ruleScopeCombobox.SelectedItem as string, true, out scope);
                return scope;
            }
        }

        private void RulesScopeComboboxChanged(object sender, EventArgs e)
        {
            var combobox = sender as ComboBox;
            urlTextbox.Enabled = combobox.SelectedIndex > 0;
        }

        private Rule _rule;
        public Rule Rule
        {
            get { return GetRule(); }
            set { SetRule(value); }
        }

        private Rule GetRule()
        {
            _rule.Name = nameTextbox.Text.Trim();
            _rule.Condition = editBox.Text.Trim();

            _rule.RuleExecutionScope = RuleScope;

            if (_rule.RuleExecutionScope != RuleExecutionScope.Everywhere)
            {
                _rule.Urls = urlTextbox.Text.Split(',').Select(r => r.Trim()).ToList();
            }

            return _rule;
        }

        private void SetRule(Rule rule)
        {
            _rule = rule;

            nameTextbox.Text = rule.Name;
            editBox.Text = rule.Condition;

            ruleScopeCombobox.SelectedItem = rule.RuleExecutionScope.ToString();

            if ((rule.RuleExecutionScope == RuleExecutionScope.Include || rule.RuleExecutionScope == RuleExecutionScope.Exclude) && rule.Urls != null)
            {
                urlTextbox.Text = string.Join(", ", rule.Urls);
            }

            urlTextbox.Enabled = ruleScopeCombobox.SelectedIndex > 0;
        }
    }
}
