using System;
using System.Windows.Forms;

namespace Onero.Dialogs
{
    public partial class RulesEditor : BaseRuleEditor_Rule, IEditorForm //Form
    {
        #region Override properties
        public override TextBox NameTextBox => nameTextbox;
        public override TextBox EditBox => editBox;
        public override TextBox UrlTextBox => urlTextbox;
        public override ComboBox RuleScopeComboBox => ruleScopeCombobox;

        public override Button ButtonSave => saveButton;
        public override Button ButtonDelete => deleteButton;
        public override Button ButtonCancel => cancelButton;

        #endregion

        public RulesEditor()
        {
            InitializeComponent();
        }

        #region EventHandlers: Just to make designer work

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                base.Save_Click(sender, e);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            base.Delete_Click(sender, e);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            base.Cancel_Click(sender, e);
        }

        protected void RulesScopeCombobox_Changed(object sender, EventArgs e)
        {
            base.RulesScopeCombobox_Changed(sender, e);
        }

        #endregion
    }
}
