using System;
using System.Windows.Forms;
using Onero.Loader;

namespace Onero.Dialogs
{
    internal partial class ExtractorEditor : BaseRuleEditor_DataExtractItem, IEditorForm
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

        public ExtractorEditor()
        {
            InitializeComponent();
        }

        private void ExtractorEditor_Load(object sender, EventArgs e)
        {
            dataExtractType.SelectedIndex = 0;
        }

        #region EventHandlers: Just to make designer work

        protected void Save_Click(object sender, EventArgs e)
        {
            //if (this.IsValid())
            {
                base.Save_Click(sender, e);
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            base.Delete_Click(sender, e);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            base.Cancel_Click(sender, e);
        }

        protected void RulesScopeCombobox_Changed(object sender, EventArgs e)
        {
            base.RulesScopeCombobox_Changed(sender, e);
        }

        #endregion

        #region Entity get /set overrides

        protected override DataExtractItem GetEntity(DataExtractItem entity)
        {
            entity.RemoveWhitespaces = removeWhitespacesCheckbox.Checked;
            return entity;
        }

        protected override void SetEntity(Rule entity)
        {
            base.SetEntity(entity);
            removeWhitespacesCheckbox.Checked = (entity as DataExtractItem).RemoveWhitespaces;
        }

        #endregion
    }
}
