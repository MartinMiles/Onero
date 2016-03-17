using System;
using System.Collections.Generic;
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
    #region This is a walkaround 'man-in-the-middle' classes to support inherritance for WinForms

    public class BaseRulesList_Rule : BaseRulesList<Rule>
    {
        protected void InitializeComponent()
        {
            base.InitializeComponent();
        }
    }

    public class BaseRulesList_DataExtractItem : BaseRulesList<DataExtractItem>
    {
        protected void InitializeComponent()
        {
            base.InitializeComponent();
        }
    }

    #endregion

    public class BaseRulesList<T> : Form where T : Rule
    {
        const string IMPLEMENT_ERROR = "Should be implemented in the derived class";
        const string SUCCESSFULLY_SAVED = " - Successfully saved";

        protected IEnumerable<T> rules;
        public IProfile CurrentProfile { get; internal set; }

        #region Form properties to inherit

        public virtual CheckedListBox RulesCheckList
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual Button ButtonSave
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual Button ButtonAdd
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }
        public virtual Button ButtonCancel
        {
            get { throw new NotImplementedException(IMPLEMENT_ERROR); }
        }

        #endregion

        protected void Form_Load()
        {
            DrawRulesList();

            ButtonSave.Enabled = false;            
            
            // CheckedListBox support
            RulesCheckList.MouseDown += CheckedListExtensions.MouseDownClick;
            RulesCheckList.ItemCheck += CheckedListExtensions.ItemChecked;
        }

        protected void InitializeComponent()
        {
        }

        private void DrawRulesList()
        {
            RulesCheckList.Items.Clear();

            for (int i = 0; i < rules.Count(); i++)
            {
                var rule = rules.ElementAt(i);
                RulesCheckList.Items.Add(rule.NameWithPrefix, rule.Enabled);
            }
        }

        #region EventHandlers: Just to make designer work

        protected void Save_Click(object sender, EventArgs e)
        {
            var checkedRulesNames = RulesCheckList.CheckedItems;
            foreach (T rule in rules)
            {
                rule.Enabled = checkedRulesNames.Contains(rule.NameWithPrefix);
            }

            try
            {
                new CollectionOf<T>(CurrentProfile.Name).Save(rules);

                ButtonSave.Enabled = false;
                Text += SUCCESSFULLY_SAVED;
                ButtonCancel.Text = "Close";
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void AddNew_Click(object sender, EventArgs e)
        {
            var editorForm = FormsFactory.GetChildForm<T>();

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                rules = rules.Concat(new[] { editorForm.Entity as T });
                DrawRulesList();

                ButtonSave.Enabled = true;
            }

            editorForm.Dispose();
        }

        protected virtual void CheckedListBox_SingleClick(object sender, EventArgs e)
        {
            ButtonSave.Enabled = true;
        }

        protected virtual void CheckedListBox_DoubleClick(object sender, EventArgs e)
        {
            if (!(sender as CheckedListBox).MouseHitsItemText())
            {
                return;
            }

            var rule = rules.FirstOrDefault(r => r.NameWithPrefix == (sender as CheckedListBox).GetSelectedString());
            if (rule == null)
            {
                return;
            }

            var editorForm = FormsFactory.GetChildForm<T>();
            editorForm.Title = $"Rule: {rule.Name} ({(rule.Enabled ? "enabled" : "disabled")})";
            editorForm.Entity = rule;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rule = editorForm.Entity as T;
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
            ButtonSave.Enabled = true;
        }

        #endregion
    }
}
