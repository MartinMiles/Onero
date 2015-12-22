namespace Onero.Dialogs
{
    partial class SettingsForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deleteResultsButton = new System.Windows.Forms.Button();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeOut = new System.Windows.Forms.TextBox();
            this.verbose = new System.Windows.Forms.CheckBox();
            this.createScreenshots = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createErrorLog = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.browserCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.newProfileName = new System.Windows.Forms.TextBox();
            this.addProfileButton = new System.Windows.Forms.Button();
            this.profileCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deleteResultsButton);
            this.groupBox3.Controls.Add(this.openFolderButton);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.outputPath);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(11, 113);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 99);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output directory";
            // 
            // deleteResultsButton
            // 
            this.deleteResultsButton.Location = new System.Drawing.Point(210, 61);
            this.deleteResultsButton.Name = "deleteResultsButton";
            this.deleteResultsButton.Size = new System.Drawing.Size(95, 23);
            this.deleteResultsButton.TabIndex = 4;
            this.deleteResultsButton.Text = "Delete results folder";
            this.deleteResultsButton.UseVisualStyleBackColor = true;
            this.deleteResultsButton.Click += new System.EventHandler(this.ClearClick);
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(109, 61);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(85, 23);
            this.openFolderButton.TabIndex = 3;
            this.openFolderButton.Text = "Open folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.OpenInExplorerButtonClick);
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.browseButton.Location = new System.Drawing.Point(9, 61);
            this.browseButton.Margin = new System.Windows.Forms.Padding(0);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(85, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Change folder";
            this.browseButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.ChangeButtonClick);
            // 
            // outputPath
            // 
            this.outputPath.Location = new System.Drawing.Point(9, 38);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(296, 20);
            this.outputPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Results folder path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Timeout (seconds):";
            // 
            // timeOut
            // 
            this.timeOut.Location = new System.Drawing.Point(9, 36);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(85, 20);
            this.timeOut.TabIndex = 8;
            this.timeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // verbose
            // 
            this.verbose.AutoSize = true;
            this.verbose.Checked = true;
            this.verbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.verbose.Location = new System.Drawing.Point(8, 48);
            this.verbose.Name = "verbose";
            this.verbose.Size = new System.Drawing.Size(117, 17);
            this.verbose.TabIndex = 6;
            this.verbose.Text = "Verbose (all results)";
            this.verbose.UseVisualStyleBackColor = true;
            // 
            // createScreenshots
            // 
            this.createScreenshots.AutoSize = true;
            this.createScreenshots.Checked = true;
            this.createScreenshots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createScreenshots.Location = new System.Drawing.Point(8, 25);
            this.createScreenshots.Name = "createScreenshots";
            this.createScreenshots.Size = new System.Drawing.Size(111, 17);
            this.createScreenshots.TabIndex = 5;
            this.createScreenshots.Text = "Create screeshots";
            this.createScreenshots.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(179, 335);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createErrorLog);
            this.groupBox1.Controls.Add(this.createScreenshots);
            this.groupBox1.Controls.Add(this.verbose);
            this.groupBox1.Location = new System.Drawing.Point(11, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Binary switches";
            // 
            // createErrorLog
            // 
            this.createErrorLog.AutoSize = true;
            this.createErrorLog.Location = new System.Drawing.Point(8, 71);
            this.createErrorLog.Name = "createErrorLog";
            this.createErrorLog.Size = new System.Drawing.Size(98, 17);
            this.createErrorLog.TabIndex = 7;
            this.createErrorLog.Text = "Create error log";
            this.createErrorLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.browserCombobox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.timeOut);
            this.groupBox2.Location = new System.Drawing.Point(179, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 112);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // browserCombobox
            // 
            this.browserCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.browserCombobox.FormattingEnabled = true;
            this.browserCombobox.Location = new System.Drawing.Point(9, 75);
            this.browserCombobox.Name = "browserCombobox";
            this.browserCombobox.Size = new System.Drawing.Size(128, 21);
            this.browserCombobox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Run in browser:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(258, 335);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.deleteProfileButton);
            this.groupBox4.Controls.Add(this.newProfileName);
            this.groupBox4.Controls.Add(this.addProfileButton);
            this.groupBox4.Controls.Add(this.profileCombobox);
            this.groupBox4.Location = new System.Drawing.Point(11, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 96);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Testing profile";
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Enabled = false;
            this.deleteProfileButton.Location = new System.Drawing.Point(230, 19);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(75, 23);
            this.deleteProfileButton.TabIndex = 32;
            this.deleteProfileButton.Text = "Delete";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.DeleteProfileClick);
            // 
            // newProfileName
            // 
            this.newProfileName.Location = new System.Drawing.Point(10, 59);
            this.newProfileName.Name = "newProfileName";
            this.newProfileName.Size = new System.Drawing.Size(214, 20);
            this.newProfileName.TabIndex = 33;
            this.newProfileName.TextChanged += new System.EventHandler(this.NewProfileTextChanged);
            // 
            // addProfileButton
            // 
            this.addProfileButton.Enabled = false;
            this.addProfileButton.Location = new System.Drawing.Point(230, 57);
            this.addProfileButton.Name = "addProfileButton";
            this.addProfileButton.Size = new System.Drawing.Size(75, 23);
            this.addProfileButton.TabIndex = 34;
            this.addProfileButton.Text = "Add new";
            this.addProfileButton.UseVisualStyleBackColor = true;
            this.addProfileButton.Click += new System.EventHandler(this.AddProfileClick);
            // 
            // profileCombobox
            // 
            this.profileCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileCombobox.FormattingEnabled = true;
            this.profileCombobox.Location = new System.Drawing.Point(10, 21);
            this.profileCombobox.Name = "profileCombobox";
            this.profileCombobox.Size = new System.Drawing.Size(214, 21);
            this.profileCombobox.TabIndex = 31;
            this.profileCombobox.SelectedIndexChanged += new System.EventHandler(this.ProfileComboboxChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(345, 366);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Application settings";
            this.Load += new System.EventHandler(this.FormLoad);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox timeOut;
        private System.Windows.Forms.Button deleteResultsButton;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.CheckBox verbose;
        private System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox outputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox createScreenshots;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button addProfileButton;
        private System.Windows.Forms.ComboBox profileCombobox;
        private System.Windows.Forms.Button deleteProfileButton;
        public System.Windows.Forms.TextBox newProfileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox browserCombobox;
        private System.Windows.Forms.CheckBox createErrorLog;
    }
}