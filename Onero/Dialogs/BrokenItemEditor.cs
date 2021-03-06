﻿using System;
using System.Linq;
using System.Windows.Forms;
using Onero.Extensions;
using Onero.Loader;
using Onero.Loader.Broken;

namespace Onero.Dialogs
{
    public partial class BrokenItemEditor : Form
    {
        public BrokenItemEditor()
        {
            InitializeComponent();
        }

        private void BrokenItem_Load(object sender, EventArgs e)
        {
            if (RuleScope == 0)
            {
                scopeCombobox.SelectedIndex = 0;
            }
        }

        #region Properties

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        #endregion

        #region Button handlers

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

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Get / set data item

        private Broken _rule;

        public Broken Rule
        {
            get { return GetItem(); }
            set { SetRule(value); }
        }

        private Broken GetItem()
        {
            _rule.Name = nameTextbox.Text.Trim();
            _rule.RuleExecutionScope = RuleScope;
            _rule.Urls = urlTextbox.Text.Split(',').Select(r => r.Trim()).ToList();

            return _rule;
        }

        private void SetRule(Broken rule)
        {
            _rule = rule;

            nameTextbox.Text = rule.Name;
            //editBox.Text = rule.Condition;

            scopeCombobox.SelectedItem = rule.RuleExecutionScope.ToString();

            if ((rule.RuleExecutionScope == RuleExecutionScope.Include ||
                 rule.RuleExecutionScope == RuleExecutionScope.Exclude) && rule.Urls != null)
            {
                urlTextbox.Text = string.Join(", ", rule.Urls);
            }
        }

        #endregion

        public RuleExecutionScope RuleScope
        {
            get
            {
                RuleExecutionScope scope;
                RuleExecutionScope.TryParse(scopeCombobox.SelectedItem as string, true, out scope);
                return scope;
            }
        }
    }
}
