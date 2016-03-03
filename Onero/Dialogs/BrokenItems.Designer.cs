﻿namespace Onero.Dialogs
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
            this.linksCheckList = new System.Windows.Forms.CheckedListBox();
            this.addNewLinkItem = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imagesCheckList = new System.Windows.Forms.CheckedListBox();
            this.addNewImageItem = new System.Windows.Forms.Button();
            this.rulesGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulesGroupBox
            // 
            this.rulesGroupBox.Controls.Add(this.linksCheckList);
            this.rulesGroupBox.Location = new System.Drawing.Point(5, 5);
            this.rulesGroupBox.Name = "rulesGroupBox";
            this.rulesGroupBox.Size = new System.Drawing.Size(301, 349);
            this.rulesGroupBox.TabIndex = 11;
            this.rulesGroupBox.TabStop = false;
            this.rulesGroupBox.Text = "Broken links (double-click to edit)";
            // 
            // linksCheckList
            // 
            this.linksCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.linksCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linksCheckList.CheckOnClick = true;
            this.linksCheckList.FormattingEnabled = true;
            this.linksCheckList.Location = new System.Drawing.Point(20, 26);
            this.linksCheckList.Name = "linksCheckList";
            this.linksCheckList.Size = new System.Drawing.Size(275, 315);
            this.linksCheckList.TabIndex = 1;
            this.linksCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.linksCheckList.DoubleClick += new System.EventHandler(this.LinksCheckListDoubleCLick);
            // 
            // addNewLinkItem
            // 
            this.addNewLinkItem.Location = new System.Drawing.Point(5, 360);
            this.addNewLinkItem.Name = "addNewLinkItem";
            this.addNewLinkItem.Size = new System.Drawing.Size(61, 23);
            this.addNewLinkItem.TabIndex = 12;
            this.addNewLinkItem.Text = "Add new";
            this.addNewLinkItem.UseVisualStyleBackColor = true;
            this.addNewLinkItem.Click += new System.EventHandler(this.AddNewLinkItemClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(538, 360);
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
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveButton.Location = new System.Drawing.Point(457, 360);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imagesCheckList);
            this.groupBox1.Location = new System.Drawing.Point(312, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 349);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Broken images (double-click to edit)";
            // 
            // imagesCheckList
            // 
            this.imagesCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.imagesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imagesCheckList.CheckOnClick = true;
            this.imagesCheckList.FormattingEnabled = true;
            this.imagesCheckList.Location = new System.Drawing.Point(20, 26);
            this.imagesCheckList.Name = "imagesCheckList";
            this.imagesCheckList.Size = new System.Drawing.Size(275, 315);
            this.imagesCheckList.TabIndex = 1;
            this.imagesCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.imagesCheckList.DoubleClick += new System.EventHandler(this.ImagesCheckListDoubleCLick);
            // 
            // addNewImageItem
            // 
            this.addNewImageItem.Location = new System.Drawing.Point(312, 360);
            this.addNewImageItem.Name = "addNewImageItem";
            this.addNewImageItem.Size = new System.Drawing.Size(61, 23);
            this.addNewImageItem.TabIndex = 17;
            this.addNewImageItem.Text = "Add new";
            this.addNewImageItem.UseVisualStyleBackColor = true;
            this.addNewImageItem.Click += new System.EventHandler(this.AddNewImageItemClicked);
            // 
            // BrokenItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(621, 394);
            this.ControlBox = false;
            this.Controls.Add(this.addNewImageItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rulesGroupBox);
            this.Controls.Add(this.addNewLinkItem);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrokenItems";
            this.Text = "Find broken items";
            this.Load += new System.EventHandler(this.BrokenItems_Load);
            this.rulesGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox rulesGroupBox;
        private System.Windows.Forms.CheckedListBox linksCheckList;
        private System.Windows.Forms.Button addNewLinkItem;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckedListBox imagesCheckList;
        private System.Windows.Forms.Button addNewImageItem;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}