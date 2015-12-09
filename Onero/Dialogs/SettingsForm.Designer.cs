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
            this.button1 = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeOut = new System.Windows.Forms.TextBox();
            this.showFirefox = new System.Windows.Forms.CheckBox();
            this.verbose = new System.Windows.Forms.CheckBox();
            this.createScreenshots = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deleteResultsButton);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.outputPath);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(11, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 99);
            this.groupBox3.TabIndex = 1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenInExplorerButtonClick);
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.browseButton.Location = new System.Drawing.Point(9, 61);
            this.browseButton.Margin = new System.Windows.Forms.Padding(0);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(85, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Change path";
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
            // showFirefox
            // 
            this.showFirefox.AutoSize = true;
            this.showFirefox.Location = new System.Drawing.Point(8, 72);
            this.showFirefox.Name = "showFirefox";
            this.showFirefox.Size = new System.Drawing.Size(142, 17);
            this.showFirefox.TabIndex = 7;
            this.showFirefox.Text = "Show Firefox (if installed)";
            this.showFirefox.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(179, 221);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createScreenshots);
            this.groupBox1.Controls.Add(this.verbose);
            this.groupBox1.Controls.Add(this.showFirefox);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Binary switches";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.timeOut);
            this.groupBox2.Location = new System.Drawing.Point(179, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CancelClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 252);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeOut;
        private System.Windows.Forms.Button deleteResultsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox showFirefox;
        private System.Windows.Forms.CheckBox verbose;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox outputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox createScreenshots;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
    }
}