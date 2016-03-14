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
    public partial class DataExtractor : BaseRulesList_DataExtractItem
    {
        public DataExtractor()
        {
            InitializeComponent();
        }

        private void DataExtractor_Load(object sender, EventArgs e)
        {
            rules = new CollectionOf<DataExtractItem>(CurrentProfile.Name).Read<DataExtractItem>();
            Form_Load();
        }

        #region Override properties

        public override CheckedListBox RulesCheckList => rulesCheckList;
        public override Button ButtonSave => saveButton;
        public override Button ButtonAdd => addNew;
        public override Button ButtonCancel => cancelButton;

        #endregion

        #region EventHandlers: Just to make designer work

        protected void Save_Click(object sender, EventArgs e)
        {
            base.Save_Click(sender, e);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            base.Cancel_Click(sender, e);
        }

        protected void AddNew_Click(object sender, EventArgs e)
        {
            base.AddNew_Click(sender, e);
        }

        protected void CheckedListBox_SingleClick(object sender, EventArgs e)
        {
            base.CheckedListBox_SingleClick(sender, e);
        }

        protected void CheckedListBox_DoubleClick(object sender, EventArgs e)
        {
            base.CheckedListBox_DoubleClick(sender, e);
        }

        #endregion
    }
}
