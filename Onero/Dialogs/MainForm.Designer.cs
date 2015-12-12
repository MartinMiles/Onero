using System.Windows.Forms;

namespace Onero.Dialogs
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadLinksButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.apiPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apiLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sitemapHost = new System.Windows.Forms.TextBox();
            this.apiEndpoint = new System.Windows.Forms.TextBox();
            this.radioButtonWebAPI = new System.Windows.Forms.RadioButton();
            this.sitemapFilename = new System.Windows.Forms.TextBox();
            this.radioButtonLinks = new System.Windows.Forms.RadioButton();
            this.radioButtonSitemap = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.linksGroupbox = new System.Windows.Forms.GroupBox();
            this.environmentLinksItems = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.testButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rulesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.loadLinksBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.linksGroupbox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadLinksButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.apiPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.apiLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sitemapHost);
            this.groupBox1.Controls.Add(this.apiEndpoint);
            this.groupBox1.Controls.Add(this.radioButtonWebAPI);
            this.groupBox1.Controls.Add(this.sitemapFilename);
            this.groupBox1.Controls.Add(this.radioButtonLinks);
            this.groupBox1.Controls.Add(this.radioButtonSitemap);
            this.groupBox1.Location = new System.Drawing.Point(561, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source of links to process:";
            // 
            // loadLinksButton
            // 
            this.loadLinksButton.Enabled = false;
            this.loadLinksButton.Location = new System.Drawing.Point(179, 255);
            this.loadLinksButton.Name = "loadLinksButton";
            this.loadLinksButton.Size = new System.Drawing.Size(75, 23);
            this.loadLinksButton.TabIndex = 10;
            this.loadLinksButton.Text = "Load Links";
            this.loadLinksButton.UseVisualStyleBackColor = true;
            this.loadLinksButton.Click += new System.EventHandler(this.LoadLinksClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Password:";
            // 
            // apiPassword
            // 
            this.apiPassword.Enabled = false;
            this.apiPassword.Location = new System.Drawing.Point(155, 218);
            this.apiPassword.Name = "apiPassword";
            this.apiPassword.Size = new System.Drawing.Size(97, 20);
            this.apiPassword.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Account login:";
            // 
            // apiLogin
            // 
            this.apiLogin.Enabled = false;
            this.apiLogin.Location = new System.Drawing.Point(24, 218);
            this.apiLogin.Name = "apiLogin";
            this.apiLogin.Size = new System.Drawing.Size(111, 20);
            this.apiLogin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Endpoint URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "/";
            // 
            // sitemapHost
            // 
            this.sitemapHost.Enabled = false;
            this.sitemapHost.Location = new System.Drawing.Point(24, 86);
            this.sitemapHost.Name = "sitemapHost";
            this.sitemapHost.Size = new System.Drawing.Size(144, 20);
            this.sitemapHost.TabIndex = 4;
            // 
            // apiEndpoint
            // 
            this.apiEndpoint.Enabled = false;
            this.apiEndpoint.Location = new System.Drawing.Point(24, 169);
            this.apiEndpoint.Name = "apiEndpoint";
            this.apiEndpoint.Size = new System.Drawing.Size(228, 20);
            this.apiEndpoint.TabIndex = 7;
            // 
            // radioButtonWebAPI
            // 
            this.radioButtonWebAPI.AutoSize = true;
            this.radioButtonWebAPI.Location = new System.Drawing.Point(9, 124);
            this.radioButtonWebAPI.Name = "radioButtonWebAPI";
            this.radioButtonWebAPI.Size = new System.Drawing.Size(153, 17);
            this.radioButtonWebAPI.TabIndex = 6;
            this.radioButtonWebAPI.Text = "Get from Sitecore WebAPI:";
            this.radioButtonWebAPI.UseVisualStyleBackColor = true;
            this.radioButtonWebAPI.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // sitemapFilename
            // 
            this.sitemapFilename.Enabled = false;
            this.sitemapFilename.Location = new System.Drawing.Point(181, 86);
            this.sitemapFilename.Name = "sitemapFilename";
            this.sitemapFilename.Size = new System.Drawing.Size(71, 20);
            this.sitemapFilename.TabIndex = 5;
            // 
            // radioButtonLinks
            // 
            this.radioButtonLinks.AutoSize = true;
            this.radioButtonLinks.Checked = true;
            this.radioButtonLinks.Location = new System.Drawing.Point(9, 24);
            this.radioButtonLinks.Name = "radioButtonLinks";
            this.radioButtonLinks.Size = new System.Drawing.Size(126, 17);
            this.radioButtonLinks.TabIndex = 2;
            this.radioButtonLinks.TabStop = true;
            this.radioButtonLinks.Text = "Paste URLs manually";
            this.radioButtonLinks.UseVisualStyleBackColor = true;
            this.radioButtonLinks.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // radioButtonSitemap
            // 
            this.radioButtonSitemap.AutoSize = true;
            this.radioButtonSitemap.Location = new System.Drawing.Point(9, 61);
            this.radioButtonSitemap.Name = "radioButtonSitemap";
            this.radioButtonSitemap.Size = new System.Drawing.Size(132, 17);
            this.radioButtonSitemap.TabIndex = 3;
            this.radioButtonSitemap.Text = "Load from xml sitemap:";
            this.radioButtonSitemap.UseVisualStyleBackColor = true;
            this.radioButtonSitemap.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(738, 389);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 15;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.OnStartButonClick);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(561, 440);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 4;
            // 
            // linksGroupbox
            // 
            this.linksGroupbox.Controls.Add(this.environmentLinksItems);
            this.linksGroupbox.Location = new System.Drawing.Point(12, 10);
            this.linksGroupbox.Name = "linksGroupbox";
            this.linksGroupbox.Size = new System.Drawing.Size(543, 443);
            this.linksGroupbox.TabIndex = 1;
            this.linksGroupbox.TabStop = false;
            this.linksGroupbox.Text = "Pages to process";
            // 
            // environmentLinksItems
            // 
            this.environmentLinksItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.environmentLinksItems.DetectUrls = false;
            this.environmentLinksItems.Location = new System.Drawing.Point(10, 19);
            this.environmentLinksItems.Name = "environmentLinksItems";
            this.environmentLinksItems.Size = new System.Drawing.Size(522, 418);
            this.environmentLinksItems.TabIndex = 1;
            this.environmentLinksItems.Text = "";
            this.environmentLinksItems.DoubleClick += new System.EventHandler(this.TextboxDoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(561, 430);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(263, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(662, 389);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(68, 23);
            this.testButton.TabIndex = 999;
            this.testButton.Text = "Test data";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Visible = false;
            this.testButton.Click += new System.EventHandler(this.TestClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(132, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SettingsClick);
            // 
            // rulesButton
            // 
            this.rulesButton.Location = new System.Drawing.Point(9, 28);
            this.rulesButton.Name = "rulesButton";
            this.rulesButton.Size = new System.Drawing.Size(56, 23);
            this.rulesButton.TabIndex = 11;
            this.rulesButton.Text = "Rules";
            this.rulesButton.UseVisualStyleBackColor = true;
            this.rulesButton.Click += new System.EventHandler(this.SetRulesButtonClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Forms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SetFormsButtonClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.rulesButton);
            this.groupBox3.Location = new System.Drawing.Point(561, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 70);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AboutClick);
            // 
            // loadLinksBackgroundWorker
            // 
            this.loadLinksBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadLinksDoWork);
            this.loadLinksBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadLinksCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.linksGroupbox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Onero Page Runner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.linksGroupbox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox sitemapFilename;
        public System.Windows.Forms.RadioButton radioButtonLinks;
        public System.Windows.Forms.RadioButton radioButtonSitemap;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label resultLabel;
        private GroupBox linksGroupbox;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        public TextBox apiEndpoint;
        private RadioButton radioButtonWebAPI;
        public TextBox sitemapHost;
        private Label label2;
        public RichTextBox environmentLinksItems;
        private Button testButton;
        private Button button4;
        private Button rulesButton;
        private Button button1;
        private GroupBox groupBox3;
        private Button button2;
        private Label label3;
        private TextBox apiLogin;
        private Label label1;
        private Label label4;
        private TextBox apiPassword;
        private Button loadLinksButton;
        private System.ComponentModel.BackgroundWorker loadLinksBackgroundWorker;
    }
}

