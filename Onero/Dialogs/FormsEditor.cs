using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Loader;
using Onero.Loader.Results;

namespace Onero.Dialogs
{
    public partial class FormsEditor : Form
    {
        public FormsEditor()
        {
            InitializeComponent();
        }

        private WebForm _form;
        public WebForm Form 
        {
            get { return GetForm(); }
            set { SetForm(value); } 
        }

        private WebForm GetForm()
        {
            _form.Name = nameTextbox.Text;
            _form.Urls = urlTextbox.Text.Split(',').Select(u => u.Trim());

            _form.Fields = new List<WebFormField>(); 
            for (int i = 0; i < 7; i++)
            {
                var field = fieldsGroupbox.Controls.Find(string.Format("fieldId{0}", i + 1), true).First() as TextBox;
                var value = fieldsGroupbox.Controls.Find(string.Format("fieldValue{0}", i + 1), true).First() as TextBox;

                if (field != null && field.Text.Any() && value != null && value.Text.Any())
                {
                    _form.Fields.Add(new WebFormField(field.Text, value.Text));
                }
            }

            _form.SubmitId = submitButtonId.Text;

            _form.ResultParameters.ResultType = ResultType;
            _form.ResultParameters.Id = resultId.Text;
            _form.ResultParameters.Message = resultMessage.Text;
            _form.ResultParameters.Url = resultUrl.Text;

            return _form;
        }

        public FormResultType ResultType
        {
            get
            {
                FormResultType type;
                FormResultType.TryParse(resultTypeCombobox.SelectedItem as string, true, out type);
                return type;
            } 
        }

        private void SetForm(WebForm form)
        {
            _form = form;

            nameTextbox.Text = form.Name;

            if (form.Urls != null)
            {
                urlTextbox.Text = string.Join(", ", form.Urls);
            }

            if (form.Fields != null)
            {
                for (int i = 0; i < form.Fields.Count; i++)
                {
                    var field = fieldsGroupbox.Controls.Find("fieldId" + (i + 1), true).First() as TextBox;
                    var value = fieldsGroupbox.Controls.Find("fieldValue" + (i + 1), true).First() as TextBox;

                    field.Text = form.Fields.ElementAt(i).Id;
                    value.Text = form.Fields.ElementAt(i).Value;
                }
            }

            submitButtonId.Text = form.SubmitId;

            resultTypeCombobox.SelectedItem = form.ResultParameters.ResultType.ToString();

            resultId.Text = form.ResultParameters.Id;
            resultMessage.Text = form.ResultParameters.Message;
            resultUrl.Text = form.ResultParameters.Url;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (!this.IsValid())
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
