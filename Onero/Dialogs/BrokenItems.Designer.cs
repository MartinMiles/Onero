namespace Onero.Dialogs
{
    partial class BrokenItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rulesGroupBox = new System.Windows.Forms.GroupBox();
            this.testAllLinks = new System.Windows.Forms.CheckBox();
            this.linksCheckList = new System.Windows.Forms.CheckedListBox();
            this.addNewLinkItem = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.imagesGroupBox = new System.Windows.Forms.GroupBox();
            this.testAllImages = new System.Windows.Forms.CheckBox();
            this.addNewImageItem = new System.Windows.Forms.Button();
            this.imagesCheckList = new System.Windows.Forms.CheckedListBox();
            this.stylesGroupBox = new System.Windows.Forms.GroupBox();
            this.testAllStyles = new System.Windows.Forms.CheckBox();
            this.addNewStyleItem = new System.Windows.Forms.Button();
            this.stylesCheckList = new System.Windows.Forms.CheckedListBox();
            this.scriptsGroupBox = new System.Windows.Forms.GroupBox();
            this.testAllScripts = new System.Windows.Forms.CheckBox();
            this.scriptsCheckList = new System.Windows.Forms.CheckedListBox();
            this.addNewScriptItem = new System.Windows.Forms.Button();
            this.rulesGroupBox.SuspendLayout();
            this.imagesGroupBox.SuspendLayout();
            this.stylesGroupBox.SuspendLayout();
            this.scriptsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulesGroupBox
            // 
            this.rulesGroupBox.Controls.Add(this.testAllLinks);
            this.rulesGroupBox.Controls.Add(this.linksCheckList);
            this.rulesGroupBox.Controls.Add(this.addNewLinkItem);
            this.rulesGroupBox.Location = new System.Drawing.Point(5, 5);
            this.rulesGroupBox.Name = "rulesGroupBox";
            this.rulesGroupBox.Size = new System.Drawing.Size(265, 349);
            this.rulesGroupBox.TabIndex = 11;
            this.rulesGroupBox.TabStop = false;
            this.rulesGroupBox.Text = "Broken links (double-click to edit)";
            // 
            // testAllLinks
            // 
            this.testAllLinks.AutoSize = true;
            this.testAllLinks.Checked = true;
            this.testAllLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testAllLinks.Location = new System.Drawing.Point(10, 29);
            this.testAllLinks.Name = "testAllLinks";
            this.testAllLinks.Size = new System.Drawing.Size(185, 17);
            this.testAllLinks.TabIndex = 2;
            this.testAllLinks.Text = "Test all the pages for broken links";
            this.testAllLinks.UseVisualStyleBackColor = true;
            this.testAllLinks.CheckedChanged += new System.EventHandler(this.TestAllLinksCheckChanged);
            // 
            // linksCheckList
            // 
            this.linksCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.linksCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linksCheckList.CheckOnClick = true;
            this.linksCheckList.FormattingEnabled = true;
            this.linksCheckList.Location = new System.Drawing.Point(28, 56);
            this.linksCheckList.Name = "linksCheckList";
            this.linksCheckList.Size = new System.Drawing.Size(230, 285);
            this.linksCheckList.TabIndex = 1;
            this.linksCheckList.Visible = false;
            this.linksCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.linksCheckList.DoubleClick += new System.EventHandler(this.LinksCheckListDoubleCLick);
            // 
            // addNewLinkItem
            // 
            this.addNewLinkItem.Location = new System.Drawing.Point(197, 25);
            this.addNewLinkItem.Name = "addNewLinkItem";
            this.addNewLinkItem.Size = new System.Drawing.Size(61, 23);
            this.addNewLinkItem.TabIndex = 12;
            this.addNewLinkItem.Text = "Add new";
            this.addNewLinkItem.UseVisualStyleBackColor = true;
            this.addNewLinkItem.Visible = false;
            this.addNewLinkItem.Click += new System.EventHandler(this.AddNewLinkItemClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1007, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 372);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 13);
            this.messageLabel.TabIndex = 15;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(926, 362);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveClick);
            // 
            // imagesGroupBox
            // 
            this.imagesGroupBox.Controls.Add(this.testAllImages);
            this.imagesGroupBox.Controls.Add(this.addNewImageItem);
            this.imagesGroupBox.Controls.Add(this.imagesCheckList);
            this.imagesGroupBox.Location = new System.Drawing.Point(276, 5);
            this.imagesGroupBox.Name = "imagesGroupBox";
            this.imagesGroupBox.Size = new System.Drawing.Size(265, 349);
            this.imagesGroupBox.TabIndex = 16;
            this.imagesGroupBox.TabStop = false;
            this.imagesGroupBox.Text = "Broken images (double-click to edit)";
            // 
            // testAllImages
            // 
            this.testAllImages.AutoSize = true;
            this.testAllImages.Checked = true;
            this.testAllImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testAllImages.Location = new System.Drawing.Point(10, 29);
            this.testAllImages.Name = "testAllImages";
            this.testAllImages.Size = new System.Drawing.Size(185, 17);
            this.testAllImages.TabIndex = 13;
            this.testAllImages.Text = "Test all the pages for broken links";
            this.testAllImages.UseVisualStyleBackColor = true;
            this.testAllImages.CheckedChanged += new System.EventHandler(this.TestAllImagesCheckChanged);
            // 
            // addNewImageItem
            // 
            this.addNewImageItem.Location = new System.Drawing.Point(197, 25);
            this.addNewImageItem.Name = "addNewImageItem";
            this.addNewImageItem.Size = new System.Drawing.Size(61, 23);
            this.addNewImageItem.TabIndex = 14;
            this.addNewImageItem.Text = "Add new";
            this.addNewImageItem.UseVisualStyleBackColor = true;
            this.addNewImageItem.Visible = false;
            this.addNewImageItem.Click += new System.EventHandler(this.AddNewImageItemClicked);
            // 
            // imagesCheckList
            // 
            this.imagesCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.imagesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imagesCheckList.CheckOnClick = true;
            this.imagesCheckList.FormattingEnabled = true;
            this.imagesCheckList.Location = new System.Drawing.Point(28, 56);
            this.imagesCheckList.Name = "imagesCheckList";
            this.imagesCheckList.Size = new System.Drawing.Size(230, 285);
            this.imagesCheckList.TabIndex = 1;
            this.imagesCheckList.Visible = false;
            this.imagesCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.imagesCheckList.DoubleClick += new System.EventHandler(this.ImagesCheckListDoubleCLick);
            // 
            // stylesGroupBox
            // 
            this.stylesGroupBox.Controls.Add(this.testAllStyles);
            this.stylesGroupBox.Controls.Add(this.addNewStyleItem);
            this.stylesGroupBox.Controls.Add(this.stylesCheckList);
            this.stylesGroupBox.Location = new System.Drawing.Point(818, 5);
            this.stylesGroupBox.Name = "stylesGroupBox";
            this.stylesGroupBox.Size = new System.Drawing.Size(265, 349);
            this.stylesGroupBox.TabIndex = 18;
            this.stylesGroupBox.TabStop = false;
            this.stylesGroupBox.Text = "Broken styles (double-click to edit)";
            // 
            // testAllStyles
            // 
            this.testAllStyles.AutoSize = true;
            this.testAllStyles.Checked = true;
            this.testAllStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testAllStyles.Location = new System.Drawing.Point(10, 29);
            this.testAllStyles.Name = "testAllStyles";
            this.testAllStyles.Size = new System.Drawing.Size(190, 17);
            this.testAllStyles.TabIndex = 13;
            this.testAllStyles.Text = "Test all the pages for broken styles";
            this.testAllStyles.UseVisualStyleBackColor = true;
            this.testAllStyles.CheckedChanged += new System.EventHandler(this.TestAllStylesCheckChanged);
            // 
            // addNewStyleItem
            // 
            this.addNewStyleItem.Location = new System.Drawing.Point(197, 25);
            this.addNewStyleItem.Name = "addNewStyleItem";
            this.addNewStyleItem.Size = new System.Drawing.Size(61, 23);
            this.addNewStyleItem.TabIndex = 14;
            this.addNewStyleItem.Text = "Add new";
            this.addNewStyleItem.UseVisualStyleBackColor = true;
            this.addNewStyleItem.Visible = false;
            this.addNewStyleItem.Click += new System.EventHandler(this.AddNewStyleItemClicked);
            // 
            // stylesCheckList
            // 
            this.stylesCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.stylesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stylesCheckList.CheckOnClick = true;
            this.stylesCheckList.FormattingEnabled = true;
            this.stylesCheckList.Location = new System.Drawing.Point(28, 56);
            this.stylesCheckList.Name = "stylesCheckList";
            this.stylesCheckList.Size = new System.Drawing.Size(230, 285);
            this.stylesCheckList.TabIndex = 1;
            this.stylesCheckList.Visible = false;
            this.stylesCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.stylesCheckList.DoubleClick += new System.EventHandler(this.StylesCheckListDoubleCLick);
            // 
            // scriptsGroupBox
            // 
            this.scriptsGroupBox.Controls.Add(this.testAllScripts);
            this.scriptsGroupBox.Controls.Add(this.scriptsCheckList);
            this.scriptsGroupBox.Controls.Add(this.addNewScriptItem);
            this.scriptsGroupBox.Location = new System.Drawing.Point(547, 5);
            this.scriptsGroupBox.Name = "scriptsGroupBox";
            this.scriptsGroupBox.Size = new System.Drawing.Size(265, 349);
            this.scriptsGroupBox.TabIndex = 17;
            this.scriptsGroupBox.TabStop = false;
            this.scriptsGroupBox.Text = "Broken scripts (double-click to edit)";
            // 
            // testAllScripts
            // 
            this.testAllScripts.AutoSize = true;
            this.testAllScripts.Checked = true;
            this.testAllScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testAllScripts.Location = new System.Drawing.Point(10, 29);
            this.testAllScripts.Name = "testAllScripts";
            this.testAllScripts.Size = new System.Drawing.Size(160, 17);
            this.testAllScripts.TabIndex = 2;
            this.testAllScripts.Text = "Test pages for broken scrips";
            this.testAllScripts.UseVisualStyleBackColor = true;
            this.testAllScripts.CheckedChanged += new System.EventHandler(this.TestAllScriptsCheckChanged);
            // 
            // scriptsCheckList
            // 
            this.scriptsCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.scriptsCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scriptsCheckList.CheckOnClick = true;
            this.scriptsCheckList.FormattingEnabled = true;
            this.scriptsCheckList.Location = new System.Drawing.Point(28, 56);
            this.scriptsCheckList.Name = "scriptsCheckList";
            this.scriptsCheckList.Size = new System.Drawing.Size(230, 285);
            this.scriptsCheckList.TabIndex = 1;
            this.scriptsCheckList.Visible = false;
            this.scriptsCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.scriptsCheckList.DoubleClick += new System.EventHandler(this.ScriptsCheckListDoubleCLick);
            // 
            // addNewScriptItem
            // 
            this.addNewScriptItem.Location = new System.Drawing.Point(197, 25);
            this.addNewScriptItem.Name = "addNewScriptItem";
            this.addNewScriptItem.Size = new System.Drawing.Size(61, 23);
            this.addNewScriptItem.TabIndex = 12;
            this.addNewScriptItem.Text = "Add new";
            this.addNewScriptItem.UseVisualStyleBackColor = true;
            this.addNewScriptItem.Visible = false;
            this.addNewScriptItem.Click += new System.EventHandler(this.AddNewScriptItemClicked);
            // 
            // BrokenItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1090, 395);
            this.ControlBox = false;
            this.Controls.Add(this.stylesGroupBox);
            this.Controls.Add(this.scriptsGroupBox);
            this.Controls.Add(this.imagesGroupBox);
            this.Controls.Add(this.rulesGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrokenItems";
            this.Text = "Find broken items";
            this.Load += new System.EventHandler(this.BrokenItems_Load);
            this.rulesGroupBox.ResumeLayout(false);
            this.rulesGroupBox.PerformLayout();
            this.imagesGroupBox.ResumeLayout(false);
            this.imagesGroupBox.PerformLayout();
            this.stylesGroupBox.ResumeLayout(false);
            this.stylesGroupBox.PerformLayout();
            this.scriptsGroupBox.ResumeLayout(false);
            this.scriptsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox rulesGroupBox;
        public System.Windows.Forms.CheckedListBox linksCheckList;
        private System.Windows.Forms.Button addNewLinkItem;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.CheckedListBox imagesCheckList;
        private System.Windows.Forms.GroupBox imagesGroupBox;
        public System.Windows.Forms.CheckBox testAllLinks;
        public System.Windows.Forms.CheckBox testAllImages;
        private System.Windows.Forms.Button addNewImageItem;
        private System.Windows.Forms.GroupBox stylesGroupBox;
        public System.Windows.Forms.CheckBox testAllStyles;
        private System.Windows.Forms.Button addNewStyleItem;
        public System.Windows.Forms.CheckedListBox stylesCheckList;
        private System.Windows.Forms.GroupBox scriptsGroupBox;
        public System.Windows.Forms.CheckBox testAllScripts;
        public System.Windows.Forms.CheckedListBox scriptsCheckList;
        private System.Windows.Forms.Button addNewScriptItem;
    }
}