namespace Onero.Dialogs
{
    partial class ExtractorEditor
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
            this.editBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeWhitespacesCheckbox = new System.Windows.Forms.CheckBox();
            this.dataExtractType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.ruleScopeCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.urlTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editBox
            // 
            this.editBox.Location = new System.Drawing.Point(9, 69);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(288, 20);
            this.editBox.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(21, 390);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.Delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeWhitespacesCheckbox);
            this.groupBox1.Controls.Add(this.dataExtractType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nameTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.editBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 201);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule";
            // 
            // removeWhitespacesCheckbox
            // 
            this.removeWhitespacesCheckbox.AutoSize = true;
            this.removeWhitespacesCheckbox.Location = new System.Drawing.Point(177, 116);
            this.removeWhitespacesCheckbox.Name = "removeWhitespacesCheckbox";
            this.removeWhitespacesCheckbox.Size = new System.Drawing.Size(128, 17);
            this.removeWhitespacesCheckbox.TabIndex = 28;
            this.removeWhitespacesCheckbox.Text = "Remove whitespaces";
            this.removeWhitespacesCheckbox.UseVisualStyleBackColor = true;
            // 
            // dataExtractType
            // 
            this.dataExtractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataExtractType.FormattingEnabled = true;
            this.dataExtractType.Items.AddRange(new object[] {
            "Text"});
            this.dataExtractType.Location = new System.Drawing.Point(9, 114);
            this.dataExtractType.Name = "dataExtractType";
            this.dataExtractType.Size = new System.Drawing.Size(158, 21);
            this.dataExtractType.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Element:";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(9, 32);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(288, 20);
            this.nameTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name:";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(15, 275);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 13);
            this.message.TabIndex = 11;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(252, 390);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(57, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(15, 99);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(31, 13);
            this.label.TabIndex = 9;
            this.label.Text = "Text:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(194, 390);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(52, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // ruleScopeCombobox
            // 
            this.ruleScopeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleScopeCombobox.FormattingEnabled = true;
            this.ruleScopeCombobox.Items.AddRange(new object[] {
            "Everywhere",
            "Include",
            "Exclude"});
            this.ruleScopeCombobox.Location = new System.Drawing.Point(9, 35);
            this.ruleScopeCombobox.Name = "ruleScopeCombobox";
            this.ruleScopeCombobox.Size = new System.Drawing.Size(158, 21);
            this.ruleScopeCombobox.TabIndex = 3;
            this.ruleScopeCombobox.SelectedIndexChanged += new System.EventHandler(this.RulesScopeCombobox_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Run this rule:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.urlTextbox);
            this.groupBox2.Controls.Add(this.ruleScopeCombobox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 156);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Execution scope";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "URL patterns to match (comma-seperated):";
            // 
            // urlTextbox
            // 
            this.urlTextbox.Location = new System.Drawing.Point(9, 88);
            this.urlTextbox.Multiline = true;
            this.urlTextbox.Name = "urlTextbox";
            this.urlTextbox.Size = new System.Drawing.Size(288, 56);
            this.urlTextbox.TabIndex = 4;
            // 
            // ExtractorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(334, 423);
            this.ControlBox = false;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExtractorEditor";
            this.Text = "Extractor editor";
            this.Load += new System.EventHandler(this.ExtractorEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox urlTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox ruleScopeCombobox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.TextBox editBox;
        public System.Windows.Forms.ComboBox dataExtractType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox removeWhitespacesCheckbox;
    }
}