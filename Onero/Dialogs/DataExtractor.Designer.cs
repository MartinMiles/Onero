namespace Onero.Dialogs
{
    partial class DataExtractor
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
            this.addNew = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.rulesGroupBox = new System.Windows.Forms.GroupBox();
            this.rulesCheckList = new System.Windows.Forms.CheckedListBox();
            this.rulesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addNew
            // 
            this.addNew.Location = new System.Drawing.Point(12, 367);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(61, 23);
            this.addNew.TabIndex = 6;
            this.addNew.Text = "Add new";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(238, 367);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(157, 367);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save rules";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // rulesGroupBox
            // 
            this.rulesGroupBox.Controls.Add(this.rulesCheckList);
            this.rulesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.rulesGroupBox.Name = "rulesGroupBox";
            this.rulesGroupBox.Size = new System.Drawing.Size(301, 349);
            this.rulesGroupBox.TabIndex = 5;
            this.rulesGroupBox.TabStop = false;
            this.rulesGroupBox.Text = "Rules (double-click to edit)";
            // 
            // rulesCheckList
            // 
            this.rulesCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.rulesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rulesCheckList.CheckOnClick = true;
            this.rulesCheckList.FormattingEnabled = true;
            this.rulesCheckList.Location = new System.Drawing.Point(20, 26);
            this.rulesCheckList.Name = "rulesCheckList";
            this.rulesCheckList.Size = new System.Drawing.Size(275, 315);
            this.rulesCheckList.TabIndex = 1;
            this.rulesCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.rulesCheckList.DoubleClick += new System.EventHandler(this.CheckedListBoxDoubleClick);
            // 
            // DataExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(324, 403);
            this.ControlBox = false;
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.rulesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataExtractor";
            this.Text = "Data Extractor";
            this.Load += new System.EventHandler(this.DataExtractor_Load);
            this.rulesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox rulesGroupBox;
        private System.Windows.Forms.CheckedListBox rulesCheckList;
    }
}