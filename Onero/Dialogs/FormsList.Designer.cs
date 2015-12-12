namespace Onero.Dialogs
{
    partial class FormsList
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
            this.formsGroupBox = new System.Windows.Forms.GroupBox();
            this.formsCheckList = new System.Windows.Forms.CheckedListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.formsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // formsGroupBox
            // 
            this.formsGroupBox.Controls.Add(this.formsCheckList);
            this.formsGroupBox.Location = new System.Drawing.Point(11, 12);
            this.formsGroupBox.Name = "formsGroupBox";
            this.formsGroupBox.Size = new System.Drawing.Size(300, 105);
            this.formsGroupBox.TabIndex = 9;
            this.formsGroupBox.TabStop = false;
            this.formsGroupBox.Text = "Forms";
            // 
            // formsCheckList
            // 
            this.formsCheckList.BackColor = System.Drawing.SystemColors.Control;
            this.formsCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.formsCheckList.CheckOnClick = true;
            this.formsCheckList.FormattingEnabled = true;
            this.formsCheckList.Location = new System.Drawing.Point(6, 17);
            this.formsCheckList.Name = "formsCheckList";
            this.formsCheckList.Size = new System.Drawing.Size(201, 75);
            this.formsCheckList.TabIndex = 9;
            this.formsCheckList.Click += new System.EventHandler(this.CheckedListBoxSingleClick);
            this.formsCheckList.DoubleClick += new System.EventHandler(this.CheckedListBoxDoubleClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(155, 123);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save forms";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveFormsButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(236, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add new";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewClick);
            // 
            // FormsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(323, 156);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.formsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormsList";
            this.Text = "Forms List";
            this.Load += new System.EventHandler(this.FormLoad);
            this.formsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox formsGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckedListBox formsCheckList;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;
    }
}