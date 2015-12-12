namespace Onero.Dialogs
{
    partial class PageResultViewForms
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
            this.urlLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pageResult = new System.Windows.Forms.Label();
            this.rulesBox = new System.Windows.Forms.RichTextBox();
            this.formsBox = new System.Windows.Forms.RichTextBox();
            this.formsLabel = new System.Windows.Forms.Label();
            this.rulesLabel = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(44, 27);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(47, 13);
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "<empty>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pageResult);
            this.groupBox1.Controls.Add(this.rulesBox);
            this.groupBox1.Controls.Add(this.formsBox);
            this.groupBox1.Controls.Add(this.formsLabel);
            this.groupBox1.Controls.Add(this.rulesLabel);
            this.groupBox1.Controls.Add(this.time);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.urlLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 337);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Result:";
            // 
            // pageResult
            // 
            this.pageResult.AutoSize = true;
            this.pageResult.Location = new System.Drawing.Point(44, 71);
            this.pageResult.Name = "pageResult";
            this.pageResult.Size = new System.Drawing.Size(47, 13);
            this.pageResult.TabIndex = 10;
            this.pageResult.Text = "<empty>";
            // 
            // rulesBox
            // 
            this.rulesBox.Location = new System.Drawing.Point(9, 127);
            this.rulesBox.Name = "rulesBox";
            this.rulesBox.ReadOnly = true;
            this.rulesBox.Size = new System.Drawing.Size(485, 94);
            this.rulesBox.TabIndex = 9;
            this.rulesBox.Text = "";
            this.rulesBox.DoubleClick += new System.EventHandler(this.RulesDoubleClick);
            // 
            // formsBox
            // 
            this.formsBox.BackColor = System.Drawing.SystemColors.Control;
            this.formsBox.Location = new System.Drawing.Point(6, 249);
            this.formsBox.Name = "formsBox";
            this.formsBox.ReadOnly = true;
            this.formsBox.Size = new System.Drawing.Size(485, 80);
            this.formsBox.TabIndex = 8;
            this.formsBox.Text = "";
            this.formsBox.DoubleClick += new System.EventHandler(this.FormsDoubleClick);
            // 
            // formsLabel
            // 
            this.formsLabel.AutoSize = true;
            this.formsLabel.Location = new System.Drawing.Point(5, 233);
            this.formsLabel.Name = "formsLabel";
            this.formsLabel.Size = new System.Drawing.Size(38, 13);
            this.formsLabel.TabIndex = 6;
            this.formsLabel.Text = "Forms:";
            // 
            // rulesLabel
            // 
            this.rulesLabel.AutoSize = true;
            this.rulesLabel.Location = new System.Drawing.Point(6, 111);
            this.rulesLabel.Name = "rulesLabel";
            this.rulesLabel.Size = new System.Drawing.Size(37, 13);
            this.rulesLabel.TabIndex = 5;
            this.rulesLabel.Text = "Rules:";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(44, 49);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(47, 13);
            this.time.TabIndex = 3;
            this.time.Text = "<empty>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(428, 355);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkClick);
            // 
            // PageResultViewForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(524, 383);
            this.ControlBox = false;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PageResultViewForms";
            this.Text = "Page result";
            this.Load += new System.EventHandler(this.PageResultViewForms_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rulesLabel;
        private System.Windows.Forms.Label formsLabel;
        private System.Windows.Forms.RichTextBox rulesBox;
        private System.Windows.Forms.RichTextBox formsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label pageResult;
        private System.Windows.Forms.Button okButton;

    }
}