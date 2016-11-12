namespace WotModCopy
{
    partial class MainWindow
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
            this.selectedProfileLabel = new System.Windows.Forms.Label();
            this.selectedProfileDescLabel = new System.Windows.Forms.Label();
            this.selectedProfilePanel = new System.Windows.Forms.Panel();
            this.updateSelectedProfileButton = new System.Windows.Forms.Button();
            this.updateOtherProfileButton = new System.Windows.Forms.Button();
            this.selectedProfileNameLabel = new System.Windows.Forms.Label();
            this.selectedProfilePathLabel = new System.Windows.Forms.Label();
            this.selectProfileButton = new System.Windows.Forms.Button();
            this.activeProfilePanel = new System.Windows.Forms.Panel();
            this.activeProfileNameLabel = new System.Windows.Forms.Label();
            this.createProfileButton = new System.Windows.Forms.Button();
            this.activeProfilePathLabel = new System.Windows.Forms.Label();
            this.activateProfileButton = new System.Windows.Forms.Button();
            this.activeProfileDescLabel = new System.Windows.Forms.Label();
            this.activeProfileLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusInfoLabel = new System.Windows.Forms.Label();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.copyWorker = new System.ComponentModel.BackgroundWorker();
            this.detectedTanksFolderPanel = new System.Windows.Forms.Panel();
            this.detectWotModsFolderButton = new System.Windows.Forms.Button();
            this.detectedTanksFolderPath = new System.Windows.Forms.Label();
            this.detectedTanksFolderButton = new System.Windows.Forms.Button();
            this.detectedTanksFolderLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.WotResModsBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.resetSettings = new System.Windows.Forms.CheckBox();
            this.checkActiveProfileButton = new System.Windows.Forms.Button();
            this.selectedProfilePanel.SuspendLayout();
            this.activeProfilePanel.SuspendLayout();
            this.detectedTanksFolderPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedProfileLabel
            // 
            this.selectedProfileLabel.AutoSize = true;
            this.selectedProfileLabel.Location = new System.Drawing.Point(3, 10);
            this.selectedProfileLabel.Name = "selectedProfileLabel";
            this.selectedProfileLabel.Size = new System.Drawing.Size(81, 13);
            this.selectedProfileLabel.TabIndex = 0;
            this.selectedProfileLabel.Text = "Selected Profile";
            // 
            // selectedProfileDescLabel
            // 
            this.selectedProfileDescLabel.AutoSize = true;
            this.selectedProfileDescLabel.Location = new System.Drawing.Point(3, 45);
            this.selectedProfileDescLabel.Name = "selectedProfileDescLabel";
            this.selectedProfileDescLabel.Size = new System.Drawing.Size(60, 13);
            this.selectedProfileDescLabel.TabIndex = 1;
            this.selectedProfileDescLabel.Text = "profileDesc";
            // 
            // selectedProfilePanel
            // 
            this.selectedProfilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedProfilePanel.Controls.Add(this.updateSelectedProfileButton);
            this.selectedProfilePanel.Controls.Add(this.updateOtherProfileButton);
            this.selectedProfilePanel.Controls.Add(this.selectedProfileNameLabel);
            this.selectedProfilePanel.Controls.Add(this.selectedProfilePathLabel);
            this.selectedProfilePanel.Controls.Add(this.selectProfileButton);
            this.selectedProfilePanel.Controls.Add(this.selectedProfileLabel);
            this.selectedProfilePanel.Controls.Add(this.selectedProfileDescLabel);
            this.selectedProfilePanel.Location = new System.Drawing.Point(12, 108);
            this.selectedProfilePanel.Name = "selectedProfilePanel";
            this.selectedProfilePanel.Size = new System.Drawing.Size(472, 79);
            this.selectedProfilePanel.TabIndex = 2;
            // 
            // updateSelectedProfileButton
            // 
            this.updateSelectedProfileButton.Location = new System.Drawing.Point(332, 52);
            this.updateSelectedProfileButton.Name = "updateSelectedProfileButton";
            this.updateSelectedProfileButton.Size = new System.Drawing.Size(135, 23);
            this.updateSelectedProfileButton.TabIndex = 5;
            this.updateSelectedProfileButton.Text = "update selected profile...";
            this.updateSelectedProfileButton.UseVisualStyleBackColor = true;
            this.updateSelectedProfileButton.Click += new System.EventHandler(this.updateSelectedProfileButton_Click);
            // 
            // updateOtherProfileButton
            // 
            this.updateOtherProfileButton.Location = new System.Drawing.Point(332, 28);
            this.updateOtherProfileButton.Name = "updateOtherProfileButton";
            this.updateOtherProfileButton.Size = new System.Drawing.Size(135, 23);
            this.updateOtherProfileButton.TabIndex = 5;
            this.updateOtherProfileButton.Text = "update other profile..";
            this.updateOtherProfileButton.UseVisualStyleBackColor = true;
            this.updateOtherProfileButton.Click += new System.EventHandler(this.updateOtherProfileButton_Click);
            // 
            // selectedProfileNameLabel
            // 
            this.selectedProfileNameLabel.AutoSize = true;
            this.selectedProfileNameLabel.Location = new System.Drawing.Point(3, 29);
            this.selectedProfileNameLabel.Name = "selectedProfileNameLabel";
            this.selectedProfileNameLabel.Size = new System.Drawing.Size(63, 13);
            this.selectedProfileNameLabel.TabIndex = 4;
            this.selectedProfileNameLabel.Text = "profileName";
            // 
            // selectedProfilePathLabel
            // 
            this.selectedProfilePathLabel.AutoSize = true;
            this.selectedProfilePathLabel.Location = new System.Drawing.Point(3, 61);
            this.selectedProfilePathLabel.Name = "selectedProfilePathLabel";
            this.selectedProfilePathLabel.Size = new System.Drawing.Size(29, 13);
            this.selectedProfilePathLabel.TabIndex = 3;
            this.selectedProfilePathLabel.Text = "Path";
            // 
            // selectProfileButton
            // 
            this.selectProfileButton.Location = new System.Drawing.Point(332, 3);
            this.selectProfileButton.Name = "selectProfileButton";
            this.selectProfileButton.Size = new System.Drawing.Size(135, 23);
            this.selectProfileButton.TabIndex = 2;
            this.selectProfileButton.Text = "select different profile...";
            this.selectProfileButton.UseVisualStyleBackColor = true;
            this.selectProfileButton.Click += new System.EventHandler(this.selectProfileButton_Click);
            // 
            // activeProfilePanel
            // 
            this.activeProfilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeProfilePanel.Controls.Add(this.checkActiveProfileButton);
            this.activeProfilePanel.Controls.Add(this.activeProfileNameLabel);
            this.activeProfilePanel.Controls.Add(this.createProfileButton);
            this.activeProfilePanel.Controls.Add(this.activeProfilePathLabel);
            this.activeProfilePanel.Controls.Add(this.activateProfileButton);
            this.activeProfilePanel.Controls.Add(this.activeProfileDescLabel);
            this.activeProfilePanel.Controls.Add(this.activeProfileLabel);
            this.activeProfilePanel.Location = new System.Drawing.Point(12, 12);
            this.activeProfilePanel.Name = "activeProfilePanel";
            this.activeProfilePanel.Size = new System.Drawing.Size(472, 90);
            this.activeProfilePanel.TabIndex = 3;
            // 
            // activeProfileNameLabel
            // 
            this.activeProfileNameLabel.AutoSize = true;
            this.activeProfileNameLabel.Location = new System.Drawing.Point(3, 33);
            this.activeProfileNameLabel.Name = "activeProfileNameLabel";
            this.activeProfileNameLabel.Size = new System.Drawing.Size(63, 13);
            this.activeProfileNameLabel.TabIndex = 12;
            this.activeProfileNameLabel.Text = "profileName";
            // 
            // createProfileButton
            // 
            this.createProfileButton.Location = new System.Drawing.Point(319, 4);
            this.createProfileButton.Name = "createProfileButton";
            this.createProfileButton.Size = new System.Drawing.Size(148, 23);
            this.createProfileButton.TabIndex = 11;
            this.createProfileButton.Text = "create new profile...";
            this.createProfileButton.UseVisualStyleBackColor = true;
            this.createProfileButton.Click += new System.EventHandler(this.createProfileButton_Click);
            // 
            // activeProfilePathLabel
            // 
            this.activeProfilePathLabel.AutoSize = true;
            this.activeProfilePathLabel.Location = new System.Drawing.Point(3, 68);
            this.activeProfilePathLabel.Name = "activeProfilePathLabel";
            this.activeProfilePathLabel.Size = new System.Drawing.Size(29, 13);
            this.activeProfilePathLabel.TabIndex = 3;
            this.activeProfilePathLabel.Text = "Path";
            // 
            // activateProfileButton
            // 
            this.activateProfileButton.Location = new System.Drawing.Point(319, 33);
            this.activateProfileButton.Name = "activateProfileButton";
            this.activateProfileButton.Size = new System.Drawing.Size(148, 23);
            this.activateProfileButton.TabIndex = 2;
            this.activateProfileButton.Text = "activate selected provile...";
            this.activateProfileButton.UseVisualStyleBackColor = true;
            this.activateProfileButton.Click += new System.EventHandler(this.activateProfileButton_Click);
            // 
            // activeProfileDescLabel
            // 
            this.activeProfileDescLabel.AutoSize = true;
            this.activeProfileDescLabel.Location = new System.Drawing.Point(3, 50);
            this.activeProfileDescLabel.Name = "activeProfileDescLabel";
            this.activeProfileDescLabel.Size = new System.Drawing.Size(60, 13);
            this.activeProfileDescLabel.TabIndex = 1;
            this.activeProfileDescLabel.Text = "profileDesc";
            // 
            // activeProfileLabel
            // 
            this.activeProfileLabel.AutoSize = true;
            this.activeProfileLabel.Location = new System.Drawing.Point(3, 9);
            this.activeProfileLabel.Name = "activeProfileLabel";
            this.activeProfileLabel.Size = new System.Drawing.Size(69, 13);
            this.activeProfileLabel.TabIndex = 0;
            this.activeProfileLabel.Text = "Active Profile";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 5);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "STATUS";
            // 
            // statusInfoLabel
            // 
            this.statusInfoLabel.AutoSize = true;
            this.statusInfoLabel.Location = new System.Drawing.Point(3, 21);
            this.statusInfoLabel.Name = "statusInfoLabel";
            this.statusInfoLabel.Size = new System.Drawing.Size(24, 13);
            this.statusInfoLabel.TabIndex = 5;
            this.statusInfoLabel.Text = "Idle";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(6, 37);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(461, 23);
            this.statusProgressBar.TabIndex = 6;
            // 
            // copyWorker
            // 
            this.copyWorker.WorkerReportsProgress = true;
            this.copyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.copyWorker_DoWork);
            this.copyWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.copyWorker_ProgressChanged);
            this.copyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.copyWorker_RunWorkerCompleted);
            // 
            // detectedTanksFolderPanel
            // 
            this.detectedTanksFolderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detectedTanksFolderPanel.Controls.Add(this.detectWotModsFolderButton);
            this.detectedTanksFolderPanel.Controls.Add(this.detectedTanksFolderPath);
            this.detectedTanksFolderPanel.Controls.Add(this.detectedTanksFolderButton);
            this.detectedTanksFolderPanel.Controls.Add(this.detectedTanksFolderLabel);
            this.detectedTanksFolderPanel.Location = new System.Drawing.Point(12, 193);
            this.detectedTanksFolderPanel.Name = "detectedTanksFolderPanel";
            this.detectedTanksFolderPanel.Size = new System.Drawing.Size(472, 80);
            this.detectedTanksFolderPanel.TabIndex = 8;
            // 
            // detectWotModsFolderButton
            // 
            this.detectWotModsFolderButton.Location = new System.Drawing.Point(166, 4);
            this.detectWotModsFolderButton.Name = "detectWotModsFolderButton";
            this.detectWotModsFolderButton.Size = new System.Drawing.Size(75, 23);
            this.detectWotModsFolderButton.TabIndex = 11;
            this.detectWotModsFolderButton.Text = "auto-detect...";
            this.detectWotModsFolderButton.UseVisualStyleBackColor = true;
            this.detectWotModsFolderButton.Click += new System.EventHandler(this.detectWotModsFolderButton_Click);
            // 
            // detectedTanksFolderPath
            // 
            this.detectedTanksFolderPath.AutoSize = true;
            this.detectedTanksFolderPath.Location = new System.Drawing.Point(3, 28);
            this.detectedTanksFolderPath.Name = "detectedTanksFolderPath";
            this.detectedTanksFolderPath.Size = new System.Drawing.Size(29, 13);
            this.detectedTanksFolderPath.TabIndex = 10;
            this.detectedTanksFolderPath.Text = "Path";
            // 
            // detectedTanksFolderButton
            // 
            this.detectedTanksFolderButton.Location = new System.Drawing.Point(247, 4);
            this.detectedTanksFolderButton.Name = "detectedTanksFolderButton";
            this.detectedTanksFolderButton.Size = new System.Drawing.Size(157, 23);
            this.detectedTanksFolderButton.TabIndex = 9;
            this.detectedTanksFolderButton.Text = "manualy set res_mods folder...";
            this.detectedTanksFolderButton.UseVisualStyleBackColor = true;
            this.detectedTanksFolderButton.Click += new System.EventHandler(this.detectedTanksFolderButton_Click);
            // 
            // detectedTanksFolderLabel
            // 
            this.detectedTanksFolderLabel.AutoSize = true;
            this.detectedTanksFolderLabel.Location = new System.Drawing.Point(3, 9);
            this.detectedTanksFolderLabel.Name = "detectedTanksFolderLabel";
            this.detectedTanksFolderLabel.Size = new System.Drawing.Size(157, 13);
            this.detectedTanksFolderLabel.TabIndex = 8;
            this.detectedTanksFolderLabel.Text = "World of Tanks res_mods folder";
            // 
            // statusPanel
            // 
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Controls.Add(this.statusInfoLabel);
            this.statusPanel.Controls.Add(this.statusProgressBar);
            this.statusPanel.Location = new System.Drawing.Point(12, 279);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(472, 71);
            this.statusPanel.TabIndex = 9;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(9, 353);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(178, 13);
            this.authorLabel.TabIndex = 10;
            this.authorLabel.Text = "Created by Willster419 of clan REL2";
            // 
            // resetSettings
            // 
            this.resetSettings.AutoSize = true;
            this.resetSettings.Location = new System.Drawing.Point(362, 352);
            this.resetSettings.Name = "resetSettings";
            this.resetSettings.Size = new System.Drawing.Size(122, 17);
            this.resetSettings.TabIndex = 11;
            this.resetSettings.Text = "reset settings on exit";
            this.resetSettings.UseVisualStyleBackColor = true;
            // 
            // checkActiveProfileButton
            // 
            this.checkActiveProfileButton.Location = new System.Drawing.Point(319, 62);
            this.checkActiveProfileButton.Name = "checkActiveProfileButton";
            this.checkActiveProfileButton.Size = new System.Drawing.Size(148, 23);
            this.checkActiveProfileButton.TabIndex = 13;
            this.checkActiveProfileButton.Text = "check for active profile...";
            this.checkActiveProfileButton.UseVisualStyleBackColor = true;
            this.checkActiveProfileButton.Click += new System.EventHandler(this.checkActiveProfileButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 369);
            this.Controls.Add(this.resetSettings);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.detectedTanksFolderPanel);
            this.Controls.Add(this.activeProfilePanel);
            this.Controls.Add(this.selectedProfilePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "WotModCopy v<version>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.selectedProfilePanel.ResumeLayout(false);
            this.selectedProfilePanel.PerformLayout();
            this.activeProfilePanel.ResumeLayout(false);
            this.activeProfilePanel.PerformLayout();
            this.detectedTanksFolderPanel.ResumeLayout(false);
            this.detectedTanksFolderPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectedProfileLabel;
        private System.Windows.Forms.Label selectedProfileDescLabel;
        private System.Windows.Forms.Panel selectedProfilePanel;
        private System.Windows.Forms.Label selectedProfilePathLabel;
        private System.Windows.Forms.Button selectProfileButton;
        private System.Windows.Forms.Panel activeProfilePanel;
        private System.Windows.Forms.Label activeProfilePathLabel;
        private System.Windows.Forms.Button activateProfileButton;
        private System.Windows.Forms.Label activeProfileDescLabel;
        private System.Windows.Forms.Label activeProfileLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusInfoLabel;
        private System.Windows.Forms.ProgressBar statusProgressBar;
        private System.ComponentModel.BackgroundWorker copyWorker;
        private System.Windows.Forms.Panel detectedTanksFolderPanel;
        private System.Windows.Forms.Label detectedTanksFolderPath;
        private System.Windows.Forms.Button detectedTanksFolderButton;
        private System.Windows.Forms.Label detectedTanksFolderLabel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Button createProfileButton;
        private System.Windows.Forms.FolderBrowserDialog WotResModsBrowser;
        private System.Windows.Forms.Button detectWotModsFolderButton;
        private System.Windows.Forms.Label selectedProfileNameLabel;
        private System.Windows.Forms.Label activeProfileNameLabel;
        private System.Windows.Forms.CheckBox resetSettings;
        private System.Windows.Forms.Button updateSelectedProfileButton;
        private System.Windows.Forms.Button updateOtherProfileButton;
        private System.Windows.Forms.Button checkActiveProfileButton;
    }
}

