﻿using System.Windows.Forms;

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
            this.loadLinksBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brokenLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataExtractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutOneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.linksGroupbox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(1126, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(526, 567);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source of links to process:";
            // 
            // loadLinksButton
            // 
            this.loadLinksButton.Enabled = false;
            this.loadLinksButton.Location = new System.Drawing.Point(358, 490);
            this.loadLinksButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadLinksButton.Name = "loadLinksButton";
            this.loadLinksButton.Size = new System.Drawing.Size(150, 44);
            this.loadLinksButton.TabIndex = 10;
            this.loadLinksButton.Text = "Load Links";
            this.loadLinksButton.UseVisualStyleBackColor = true;
            this.loadLinksButton.Click += new System.EventHandler(this.LoadLinksClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 388);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Password:";
            // 
            // apiPassword
            // 
            this.apiPassword.Enabled = false;
            this.apiPassword.Location = new System.Drawing.Point(310, 419);
            this.apiPassword.Margin = new System.Windows.Forms.Padding(6);
            this.apiPassword.Name = "apiPassword";
            this.apiPassword.Size = new System.Drawing.Size(190, 31);
            this.apiPassword.TabIndex = 9;
            this.apiPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 388);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Account login:";
            // 
            // apiLogin
            // 
            this.apiLogin.Enabled = false;
            this.apiLogin.Location = new System.Drawing.Point(48, 419);
            this.apiLogin.Margin = new System.Windows.Forms.Padding(6);
            this.apiLogin.Name = "apiLogin";
            this.apiLogin.Size = new System.Drawing.Size(218, 31);
            this.apiLogin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 294);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Endpoint URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "/";
            // 
            // sitemapHost
            // 
            this.sitemapHost.Enabled = false;
            this.sitemapHost.Location = new System.Drawing.Point(48, 165);
            this.sitemapHost.Margin = new System.Windows.Forms.Padding(6);
            this.sitemapHost.Name = "sitemapHost";
            this.sitemapHost.Size = new System.Drawing.Size(284, 31);
            this.sitemapHost.TabIndex = 4;
            // 
            // apiEndpoint
            // 
            this.apiEndpoint.Enabled = false;
            this.apiEndpoint.Location = new System.Drawing.Point(48, 325);
            this.apiEndpoint.Margin = new System.Windows.Forms.Padding(6);
            this.apiEndpoint.Name = "apiEndpoint";
            this.apiEndpoint.Size = new System.Drawing.Size(452, 31);
            this.apiEndpoint.TabIndex = 7;
            // 
            // radioButtonWebAPI
            // 
            this.radioButtonWebAPI.AutoSize = true;
            this.radioButtonWebAPI.Location = new System.Drawing.Point(18, 238);
            this.radioButtonWebAPI.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonWebAPI.Name = "radioButtonWebAPI";
            this.radioButtonWebAPI.Size = new System.Drawing.Size(299, 29);
            this.radioButtonWebAPI.TabIndex = 6;
            this.radioButtonWebAPI.Text = "Get from Sitecore WebAPI:";
            this.radioButtonWebAPI.UseVisualStyleBackColor = true;
            this.radioButtonWebAPI.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // sitemapFilename
            // 
            this.sitemapFilename.Enabled = false;
            this.sitemapFilename.Location = new System.Drawing.Point(362, 165);
            this.sitemapFilename.Margin = new System.Windows.Forms.Padding(6);
            this.sitemapFilename.Name = "sitemapFilename";
            this.sitemapFilename.Size = new System.Drawing.Size(138, 31);
            this.sitemapFilename.TabIndex = 5;
            // 
            // radioButtonLinks
            // 
            this.radioButtonLinks.AutoSize = true;
            this.radioButtonLinks.Checked = true;
            this.radioButtonLinks.Location = new System.Drawing.Point(18, 46);
            this.radioButtonLinks.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonLinks.Name = "radioButtonLinks";
            this.radioButtonLinks.Size = new System.Drawing.Size(249, 29);
            this.radioButtonLinks.TabIndex = 2;
            this.radioButtonLinks.TabStop = true;
            this.radioButtonLinks.Text = "Paste URLs manually";
            this.radioButtonLinks.UseVisualStyleBackColor = true;
            this.radioButtonLinks.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // radioButtonSitemap
            // 
            this.radioButtonSitemap.AutoSize = true;
            this.radioButtonSitemap.Location = new System.Drawing.Point(18, 117);
            this.radioButtonSitemap.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonSitemap.Name = "radioButtonSitemap";
            this.radioButtonSitemap.Size = new System.Drawing.Size(265, 29);
            this.radioButtonSitemap.TabIndex = 3;
            this.radioButtonSitemap.Text = "Load from xml sitemap:";
            this.radioButtonSitemap.UseVisualStyleBackColor = true;
            this.radioButtonSitemap.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(1484, 648);
            this.startButton.Margin = new System.Windows.Forms.Padding(6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 44);
            this.startButton.TabIndex = 15;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.OnStartButonClick);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(1120, 658);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 25);
            this.resultLabel.TabIndex = 4;
            // 
            // linksGroupbox
            // 
            this.linksGroupbox.Controls.Add(this.environmentLinksItems);
            this.linksGroupbox.Location = new System.Drawing.Point(22, 52);
            this.linksGroupbox.Margin = new System.Windows.Forms.Padding(6);
            this.linksGroupbox.Name = "linksGroupbox";
            this.linksGroupbox.Padding = new System.Windows.Forms.Padding(6);
            this.linksGroupbox.Size = new System.Drawing.Size(1086, 717);
            this.linksGroupbox.TabIndex = 1;
            this.linksGroupbox.TabStop = false;
            this.linksGroupbox.Text = "Pages to process";
            // 
            // environmentLinksItems
            // 
            this.environmentLinksItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.environmentLinksItems.DetectUrls = false;
            this.environmentLinksItems.Location = new System.Drawing.Point(20, 37);
            this.environmentLinksItems.Margin = new System.Windows.Forms.Padding(6);
            this.environmentLinksItems.Name = "environmentLinksItems";
            this.environmentLinksItems.Size = new System.Drawing.Size(1040, 658);
            this.environmentLinksItems.TabIndex = 1;
            this.environmentLinksItems.Text = "";
            this.environmentLinksItems.TextChanged += new System.EventHandler(this.LinksTextChanged);
            this.environmentLinksItems.DoubleClick += new System.EventHandler(this.TextboxDoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1126, 721);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(526, 44);
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
            this.testButton.Location = new System.Drawing.Point(1332, 648);
            this.testButton.Margin = new System.Windows.Forms.Padding(6);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(136, 44);
            this.testButton.TabIndex = 999;
            this.testButton.Text = "Test data";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Visible = false;
            this.testButton.Click += new System.EventHandler(this.TestClick);
            // 
            // loadLinksBackgroundWorker
            // 
            this.loadLinksBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadLinksDoWork);
            this.loadLinksBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadLinksCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.runToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1672, 44);
            this.menuStrip1.TabIndex = 1000;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(105, 36);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem,
            this.formsToolStripMenuItem,
            this.exportsToolStripMenuItem,
            this.brokenLinksToolStripMenuItem,
            this.dataExtractorToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(174, 36);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.Rules_Click);
            // 
            // formsToolStripMenuItem
            // 
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.formsToolStripMenuItem.Text = "Forms";
            this.formsToolStripMenuItem.Click += new System.EventHandler(this.Forms_Click);
            // 
            // exportsToolStripMenuItem
            // 
            this.exportsToolStripMenuItem.Enabled = false;
            this.exportsToolStripMenuItem.Name = "exportsToolStripMenuItem";
            this.exportsToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.exportsToolStripMenuItem.Text = "Exports";
            // 
            // brokenLinksToolStripMenuItem
            // 
            this.brokenLinksToolStripMenuItem.Name = "brokenLinksToolStripMenuItem";
            this.brokenLinksToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.brokenLinksToolStripMenuItem.Text = "Broken links";
            this.brokenLinksToolStripMenuItem.Click += new System.EventHandler(this.BrokenLinks_Click);
            // 
            // dataExtractorToolStripMenuItem
            // 
            this.dataExtractorToolStripMenuItem.Name = "dataExtractorToolStripMenuItem";
            this.dataExtractorToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.dataExtractorToolStripMenuItem.Text = "Data extractor";
            this.dataExtractorToolStripMenuItem.Click += new System.EventHandler(this.DataExtractor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(263, 38);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.Settings_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.resultsFolderToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(69, 36);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(258, 38);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.Start_Click);
            // 
            // resultsFolderToolStripMenuItem
            // 
            this.resultsFolderToolStripMenuItem.Enabled = false;
            this.resultsFolderToolStripMenuItem.Name = "resultsFolderToolStripMenuItem";
            this.resultsFolderToolStripMenuItem.Size = new System.Drawing.Size(258, 38);
            this.resultsFolderToolStripMenuItem.Text = "Results folder";
            this.resultsFolderToolStripMenuItem.Click += new System.EventHandler(this.resultsFolderToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutOneroToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.sendFeedbackToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutOneroToolStripMenuItem
            // 
            this.aboutOneroToolStripMenuItem.Name = "aboutOneroToolStripMenuItem";
            this.aboutOneroToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.aboutOneroToolStripMenuItem.Text = "About Onero";
            this.aboutOneroToolStripMenuItem.Click += new System.EventHandler(this.About_Click);
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.registrationToolStripMenuItem.Text = "Registration";
            this.registrationToolStripMenuItem.Click += new System.EventHandler(this.registrationToolStripMenuItem_Click);
            // 
            // sendFeedbackToolStripMenuItem
            // 
            this.sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            this.sendFeedbackToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.sendFeedbackToolStripMenuItem.Text = "Send feedback";
            this.sendFeedbackToolStripMenuItem.Click += new System.EventHandler(this.sendFeedbackToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 788);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.linksGroupbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Onero Page Runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.linksGroupbox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private Label label3;
        private TextBox apiLogin;
        private Label label1;
        private Label label4;
        private TextBox apiPassword;
        private Button loadLinksButton;
        private System.ComponentModel.BackgroundWorker loadLinksBackgroundWorker;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profilesToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem rulesToolStripMenuItem;
        private ToolStripMenuItem exportsToolStripMenuItem;
        private ToolStripMenuItem formsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutOneroToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem resultsFolderToolStripMenuItem;
        private ToolStripMenuItem brokenLinksToolStripMenuItem;
        private ToolStripMenuItem dataExtractorToolStripMenuItem;
        private ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private ToolStripMenuItem registrationToolStripMenuItem;
    }
}

