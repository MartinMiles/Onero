using System;
using System.Linq;
using System.Windows.Forms;
using Onero.Loader;

namespace Onero.Dialogs
{
    #region This is an intermediate walkaround classes to support inherritance for WinForms

    public class BaseRuleEditor_DataExtractItem : BaseRuleEditor<DataExtractItem>
    {
        public BaseRuleEditor_DataExtractItem()
        {
        }

        protected void InitializeComponent()
        {
            base.InitializeComponent();
        }
    }

    #endregion

    public class BaseRuleEditor<T> : Form where T : Rule
    {
        const string IMPLEMENT_ERROR = "Should be implemented in the derived class";

        #region Form properties to inherit


        public virtual TextBox NameTextBox
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual TextBox EditBox
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual TextBox UrlTextBox
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual ComboBox RuleScopeComboBox
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }

        public virtual Button ButtonSave
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual Button ButtonDelete
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual Button ButtonCancel
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }

        #endregion

        protected void InitializeComponent()
        {
            //Button1.Click += button1_Click;
        }

        #region Standard properties to inherit

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public RuleExecutionScope RuleScope
        {
            get
            {
                RuleExecutionScope scope;
                RuleExecutionScope.TryParse(RuleScopeComboBox.SelectedItem as string, true, out scope);
                return scope;
            }
        }

        #endregion

        #region Get or set entity

        private T _entity;

        public T Entity
        {
            get { return GetEntity(); }
            set { SetEntity(value); }
        }

        private T GetEntity()
        {
            _entity.Name = NameTextBox.Text.Trim();
            _entity.Condition = EditBox.Text.Trim();

            _entity.RuleExecutionScope = RuleScope;

            if (_entity.RuleExecutionScope != RuleExecutionScope.Everywhere)
            {
                _entity.Urls = UrlTextBox.Text.Split(',').Select(r => r.Trim()).ToList();
            }

            //TODO: rule type also should be here when more than just 'text' appear
            // TODO: Delegate this to derived
            //_entity.RemoveWhitespaces = removeWhitespacesCheckbox.Checked;

            return _entity;
        }

        private void SetEntity(T rule)
        {
            _entity = rule;

            NameTextBox.Text = rule.Name;
            EditBox.Text = rule.Condition;

            RuleScopeComboBox.SelectedItem = rule.RuleExecutionScope.ToString();

            if ((rule.RuleExecutionScope == RuleExecutionScope.Include ||
                 rule.RuleExecutionScope == RuleExecutionScope.Exclude) && rule.Urls != null)
            {
                UrlTextBox.Text = string.Join(", ", rule.Urls);
            }

            // TODO: Delegate this to derived
            //removeWhitespacesCheckbox.Checked = _entity.RemoveWhitespaces;

            UrlTextBox.Enabled = RuleScopeComboBox.SelectedIndex > 0;
        }

        #endregion

        #region Event handlers to override

        protected void Save_Click(object sender, EventArgs e)
        {
            //if (this.IsValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected void RulesScopeCombobox_Changed(object sender, EventArgs e)
        {
            var combobox = sender as ComboBox;
            UrlTextBox.Enabled = combobox.SelectedIndex > 0;
        }

        #endregion
    }
}
