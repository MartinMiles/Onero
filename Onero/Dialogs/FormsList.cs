using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Extensions;
using Onero.Loader;

namespace Onero.Dialogs
{
    public partial class FormsList : Form
    {
        private List<WebForm> forms;

        public string CurrentProfileName { get; internal set; }

        public FormsList()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            forms = new CollectionOf<WebForm>(CurrentProfileName).Read<WebForm>().ToList();

            DrawFormsList();

            saveButton.Enabled = false;

            formsCheckList.MouseDown += CheckedListExtensions.MouseDownClick;
            formsCheckList.ItemCheck += CheckedListExtensions.ItemChecked;
        }

        private void DrawFormsList()
        {
            formsCheckList.Items.Clear();

            CheckedListExtensions.AuthorizeCheck = true;
            for (int i = 0; i < forms.Count; i++)
            {
                var rule = forms.ElementAt(i);
                formsCheckList.Items.Add(rule.Name, rule.Enabled);
            }
            CheckedListExtensions.AuthorizeCheck = false;
        }

        private void SaveFormsButtonClick(object sender, EventArgs e)
        {
            var checkedFormsNames = formsCheckList.CheckedItems;
            foreach (WebForm form in forms)
            {
                form.Enabled = checkedFormsNames.Contains(form.Name);
            }

            try
            {
                new CollectionOf<WebForm>(CurrentProfileName).Save(forms);

                saveButton.Enabled = false;
                Text = "Forms Editor - Successfully saved";
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

        private void CheckedListBoxDoubleClick(object sender, EventArgs e)
        {
            if (!(sender as CheckedListBox).MouseHitsItemText())
            {
                return;
            }

            var clb = sender as CheckedListBox;
            var clickedItem = clb.SelectedItem;

            var form = forms.FirstOrDefault(r => r.Name == clickedItem as string);

            var editorForm = new FormsEditor { StartPosition = FormStartPosition.CenterParent };
            editorForm.Form = form;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                form = editorForm.Form;
                DrawFormsList();
            }
            else if (dialogResult == DialogResult.Yes)
            {
                forms = forms.Where(r => r != form).ToList();
                DrawFormsList();
            }

            editorForm.Dispose();

            saveButton.Enabled = true;
        }

        private void AddNewClick(object sender, EventArgs e)
        {
            var editorForm = new FormsEditor { StartPosition = FormStartPosition.CenterParent };
            editorForm.Form = new WebForm();

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                forms.Add(editorForm.Form);
                DrawFormsList();
            }
            else if (dialogResult == DialogResult.Yes)
            {
                //forms = forms.Where(r => r != form);
                //DrawFormsList();
            }

            editorForm.Dispose();
        }
    }
}
