using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Web;
using System.Net;

namespace WotModCopy
{
    public partial class MainWindow : Form
    {
        private string version = "Alpha 4";
        private PleaseWait wait;
        private UpdateWindow uw;
        private ProfileInfo pInfo;
        private string tanksModsPath;
        private string startupPath;
        private string settingsFile;
        private string profileFile;
        private string profileDesc;
        private string profilePath;
        private string profileName;
        private string tempPath;
        private string lockFile;
        bool createdThisTime = true;
        private double numFilesToCopy;
        private double numFilesCopied;
        private int percentComplete;
        private string source;
        private string dest;
        private object theObject;
        bool debug = false;
        private WebClient client;
        bool createMode = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //parse strings
            startupPath = Application.StartupPath;
            tempPath = Path.GetTempPath();
            lockFile = tempPath + "\\WotModLock.lck";
            this.Text = "Wot Mod Profile version " + version;
            //check for single instance
            if (File.Exists(lockFile))
            {
                MessageBox.Show("Only one single instance of the program can be run at once");
                createdThisTime = false;
                this.Close();
                return;
            }

            ///////////////////////////////////////////////////////////
            //comment out the line below for debug
            File.WriteAllText(lockFile, "lockFile. do not delete");
            ///////////////////////////////////////////////////////////

            //check for updates
            this.Hide();
            wait = new PleaseWait("Please wait, checking for Updates...");
            wait.Show();
            Application.DoEvents();
            this.checkForupdates();
            wait.Close();
            this.resetGUI();
            if (this.readPrefrences())
            {
                openProfile(true);
                detectedTanksFolderLabel.ForeColor = Color.DarkGreen;
                detectedTanksFolderPath.Text = tanksModsPath;
            }
            try
            {
                this.Show();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        private void checkForupdates()
        {
            if (debug)
            {

            }
            else
            {
                client = new WebClient();
                uw = new UpdateWindow();
                if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
                //download version.txt
                //"http://willster419.atwebpages.com/Applications/"
                try
                {
                    client.DownloadFile("http://willster419.atwebpages.com/Applications/WotModCopy/version.txt", tempPath + "\\version.txt");
                }
                catch (WebException)
                {
                    MessageBox.Show("Error downloading, eithor you are offline or the update server timmed out");
                    this.Close();
                }
                string newVersion = File.ReadAllText(tempPath + "\\version.txt");
                if (newVersion.Equals(version))
                {
                    //up to date
                }
                else
                {
                    //download updateNotes.txt
                    client.DownloadFile("http://willster419.atwebpages.com/Applications/WotModCopy/updateNotes.txt", tempPath + "\\updateNotes.txt");
                    //prompt user
                    uw.updateNotesRTB.Text = File.ReadAllText(tempPath + "\\updateNotes.txt");
                    uw.updateAvailableLabel.Text = "An update is available: " + newVersion;
                    uw.ShowDialog();
                    if (uw.update)
                    {
                        //download new version
                        string temp = Path.GetFullPath(Application.StartupPath);
                        client.DownloadFile("http://willster419.atwebpages.com/Applications/WotModCopy/WotModCopy.exe", temp + "\\WotModCopy version" + newVersion + ".exe");
                        //open new one
                        try
                        {
                            System.Diagnostics.Process.Start(temp + "\\WotModCopy version" + newVersion + ".exe");
                        }
                        catch (Win32Exception)
                        {
                            MessageBox.Show("Could not start the new version, but it is located in\n" + temp);
                        }
                        //close this one
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void createProfileButton_Click(object sender, EventArgs e)
        {
            this.createProfile();
        }

        private void activateProfileButton_Click(object sender, EventArgs e)
        {
            if (copyWorker.IsBusy)
            {
                MessageBox.Show("currently copying, please wait...");
                return;
            }
            statusInfoLabel.Text = "Deleting current res_mods install...";
            Application.DoEvents();
            if (profileName == null || profileDesc == null)
            {
                MessageBox.Show("no profile selected");
                statusInfoLabel.Text = "Idle";
                return;
            }
            if (tanksModsPath == null)
            {
                MessageBox.Show("tanks path is null");
                statusInfoLabel.Text = "Idle";
                return;
            }
            Directory.Delete(tanksModsPath, true);
            if (!Directory.Exists(tanksModsPath)) Directory.CreateDirectory(tanksModsPath);
            this.copy(profilePath, tanksModsPath);
        }

        private void selectProfileButton_Click(object sender, EventArgs e)
        {
            this.openProfile(false);
        }

        private void detectedTanksFolderButton_Click(object sender, EventArgs e)
        {
            WotResModsBrowser.ShowNewFolderButton = false;
            WotResModsBrowser.Description = "Please find the 'res_mods' forlder for your world of tanks";
            if (WotResModsBrowser.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            //verify it's the res_mods folder
            string temp = WotResModsBrowser.SelectedPath;
            temp = temp.Substring(temp.Length - 9);
            if (temp.Equals("\\res_mods"))
            {
                tanksModsPath = WotResModsBrowser.SelectedPath;
                detectedTanksFolderLabel.ForeColor = Color.DarkGreen;
                detectedTanksFolderPath.Text = WotResModsBrowser.SelectedPath;
            }
            else
            {
                MessageBox.Show("that doesn't seem like the res_mods folder...");
                tanksModsPath = "invalid";
                detectedTanksFolderLabel.ForeColor = Color.Red;
                detectedTanksFolderPath.Text = tanksModsPath;
            }
        }

        private void copyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //do the copying here
            DirectoryCopy(source, dest, true);
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
                copyWorker.ReportProgress(0);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }

        }

        private void copyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //report progress there
            numFilesCopied++;
            statusInfoLabel.Text = "Copying file " + numFilesCopied + " of " + numFilesToCopy;
            double realPercentComplete = numFilesCopied / numFilesToCopy;
            realPercentComplete = realPercentComplete * 100;
            percentComplete = (int)realPercentComplete;
            statusProgressBar.Value = percentComplete;
        }

        private void copyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //report complete here
            statusInfoLabel.Text = "Complete";
            if (createMode)
            {

                StringBuilder sb = new StringBuilder();
                string delim = "\n";
                sb.Append("profileName=" + profileName + delim);
                sb.Append("profileDesc=" + profileDesc + delim);
                if (File.Exists(profileFile))
                {
                    File.Delete(profileFile);
                }
                File.WriteAllText(profileFile, sb.ToString());
                File.WriteAllText(tanksModsPath + "\\profileInfo.wotprofile", sb.ToString());

                activeProfileNameLabel.Text = profileName;
                selectedProfileNameLabel.Text = profileName;

                activeProfileDescLabel.Text = profileDesc;
                selectedProfileDescLabel.Text = profileDesc;

                activeProfilePathLabel.Text = tanksModsPath;
                activeProfileLabel.ForeColor = Color.DarkGreen;

                selectedProfilePathLabel.Text = profilePath;
                selectedProfileLabel.ForeColor = Color.DarkGreen;
                createMode = false;
            }
            else
            {
                string temp = File.ReadAllText(tanksModsPath + "\\profileInfo.wotprofile");
                string[] stringArray = temp.Split('\n');
                foreach (string s in stringArray)
                {
                    string[] anotherArray = s.Split('=');
                    switch (anotherArray[0])
                    {
                        case "profileName":
                            activeProfileNameLabel.Text = anotherArray[1];
                            break;

                        case "profileDesc":
                            activeProfileDescLabel.Text = anotherArray[1];
                            break;

                        default:
                            break;
                    }
                }
                activeProfilePathLabel.Text = tanksModsPath;
                activeProfileLabel.ForeColor = Color.DarkGreen;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(lockFile) && createdThisTime)
                File.Delete(lockFile);
            this.savePrefrences();
            if (resetSettings.Checked)
            {
                if (File.Exists(settingsFile))
                {
                    File.Delete(settingsFile);
                }
            }
        }

        private void savePrefrences()
        {
            if (tanksModsPath == null || profileFile == null || profilePath == null)
            {
                return;
            }
            if (tanksModsPath.Equals("") || profileFile.Equals("") || profilePath.Equals(""))
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            char delim = '\n';
            sb.Append("tanksModsPath=" + tanksModsPath + delim);
            sb.Append("profileFile=" + profileFile + delim);
            sb.Append("profilePath=" + profilePath + delim);
            File.WriteAllText(settingsFile, sb.ToString());
        }

        private bool readPrefrences()
        {
            settingsFile = startupPath + "\\.settings";
            if (!File.Exists(settingsFile))
            {
                return false;
            }
            else
            {
                //read the settings
                string string2Parse = File.ReadAllText(settingsFile);
                string[] stringArray = string2Parse.Split('\n');
                foreach (string s in stringArray)
                {
                    string[] anotherArray = s.Split('=');
                    switch (anotherArray[0])
                    {
                        case "tanksModsPath":
                            tanksModsPath = anotherArray[1];
                            WotResModsBrowser.SelectedPath = tanksModsPath;
                            break;

                        case "profileFile":
                            profileFile = anotherArray[1];
                            break;

                        case "profilePath":
                            profilePath = anotherArray[1];
                            break;

                        default:
                            break;
                    }
                }
            }
            return true;
        }

        private void resetGUI()
        {

        }

        private string detectTanksFolder()
        {
            const string keyName = "HKEY_CURRENT_USER\\Software\\Classes\\.wotreplay\\shell\\open\\command";
            theObject = Registry.GetValue(keyName, "", -1);
            if (theObject == null) return null;
            string temp = (string)theObject;
            temp = temp.Substring(1);
            temp = temp.Substring(0, temp.Length - 22);
            temp = temp + "res_mods";
            if (!Directory.Exists(temp))
            {
                return null;
            }
            return temp;
        }

        private void detectWotModsFolderButton_Click(object sender, EventArgs e)
        {
            tanksModsPath = detectTanksFolder();
            if (tanksModsPath == null)
            {
                MessageBox.Show("Failed to auto detect your Wot res_mods folder\nverify you can open Wot replay files, and then try again\nor, use the manually set res_mods folder button");
            }
            else
            {
                detectedTanksFolderLabel.ForeColor = Color.DarkGreen;
                detectedTanksFolderPath.Text = tanksModsPath;
            }
        }

        private void openProfile(bool fromLoad)
        {
            if (!fromLoad)
            {
                if (profilePath != null)
                {
                    WotResModsBrowser.RootFolder = Environment.SpecialFolder.Desktop;
                    WotResModsBrowser.SelectedPath = profilePath;
                }
                WotResModsBrowser.ShowNewFolderButton = false;
                WotResModsBrowser.Description = "Select profile to open";
                if (WotResModsBrowser.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                profilePath = WotResModsBrowser.SelectedPath;
                profileFile = profilePath + "\\profileInfo.wotprofile";
            }
            if (!File.Exists(profileFile))
            {
                if (!fromLoad) MessageBox.Show("Selected folder is not a profile");
                if (fromLoad)
                {
                    resetSettings.Checked = true;
                    Application.Restart();
                }
                return;
            }
            string temp = File.ReadAllText(profileFile);
            string[] stringArray = temp.Split('\n');
            foreach (string s in stringArray)
            {
                string[] anotherArray = s.Split('=');
                switch (anotherArray[0])
                {
                    case "profileName":
                        profileName = anotherArray[1];
                        selectedProfileNameLabel.Text = anotherArray[1];
                        break;

                    case "profileDesc":
                        profileDesc = anotherArray[1];
                        selectedProfileDescLabel.Text = anotherArray[1];
                        break;

                    default:
                        break;
                }
            }
            selectedProfilePathLabel.Text = profilePath;
            selectedProfileLabel.ForeColor = Color.DarkGreen;
        }

        private void createProfile()
        {
            createMode = true;
            if (tanksModsPath == null)
            {
                MessageBox.Show("you must have your tanks folder selected\nbefore you can create a profile");
                return;
            }
            pInfo = new ProfileInfo();
            pInfo.ShowDialog();
            if (!pInfo.cont)
                return;
            profileName = pInfo.textBox1.Text;
            profileDesc = pInfo.textBox2.Text;
            WotResModsBrowser.ShowNewFolderButton = true;
            WotResModsBrowser.Description = "Select where you would like to save your profile";
            if (WotResModsBrowser.ShowDialog() == DialogResult.Cancel)
            {
                statusInfoLabel.Text = "cancled";
                return;
            }
            statusInfoLabel.Text = "Creating Profile...";
            profilePath = WotResModsBrowser.SelectedPath;
            profileFile = profilePath + "\\profileInfo.wotprofile";
            this.copy(tanksModsPath, profilePath);
        }

        private int copy(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                statusInfoLabel.Text = "Abort code 1";
                return -1;
            }
            numFilesToCopy = 0;
            numFilesCopied = 0;
            percentComplete = 0;
            source = sourceFolder;
            dest = destFolder;
            getNumFiles(source, dest, true);
            copyWorker.RunWorkerAsync();
            return 0;
        }

        private void getNumFiles(string sourceDirName, string destDirName, bool copySubDirs)
        {

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                //Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                numFilesToCopy++;
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    getNumFiles(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void updateSelectedProfileButton_Click(object sender, EventArgs e)
        {
            //check for tanks folder and selected profile path
            //check selected profile is same as active profile
            if (tanksModsPath == null)
            {
                MessageBox.Show("you must have your tanks folder selected\nbefore you can create a profile");
                return;
            }
            if (profilePath == null)
            {
                MessageBox.Show("profile path is null");
                return;
            }
            string temp = File.ReadAllText(tanksModsPath + "\\profileInfo.wotprofile");
            string[] stringArray = temp.Split('\n');
            foreach (string s in stringArray)
            {
                string[] anotherArray = s.Split('=');
                switch (anotherArray[0])
                {
                    case "profileName":
                        if (profileName != anotherArray[1])
                        {
                            MessageBox.Show("Selected Profile is not the same as active profile\nupdate aborted");
                            statusInfoLabel.Text = "Idle";
                            return;
                        }
                        break;

                    case "profileDesc":
                        if (profileDesc != anotherArray[1])
                        {
                            MessageBox.Show("Selected Profile is not the same as active profile\nupdate aborted");
                            statusInfoLabel.Text = "Idle";
                            return;
                        }
                        break;

                    default:
                        break;
                }
            }
            profileFile = profilePath + "\\profileInfo.wotprofile";
            Directory.Delete(profilePath, true);
            if (!Directory.Exists(profilePath)) Directory.CreateDirectory(profilePath);
            this.copy(tanksModsPath, profilePath);
        }

        private void updateOtherProfileButton_Click(object sender, EventArgs e)
        {
            string tempProfileName = "";
            string tempProfileDesc = "";
            string tempPath = "";
            string tempFile = "";
            WotResModsBrowser.ShowNewFolderButton = false;
            WotResModsBrowser.Description = "Select Profile to update";
            if (WotResModsBrowser.ShowDialog() == DialogResult.Cancel)
            {
                statusInfoLabel.Text = "cancled";
                return;
            }
            statusInfoLabel.Text = "Updating Profile...";
            tempPath = WotResModsBrowser.SelectedPath;
            if (tanksModsPath == null)
            {
                MessageBox.Show("you must have your tanks folder selected\nbefore you can create a profile");
                return;
            }
            
            tempFile = tempPath + "\\profileInfo.wotprofile";
            string temp = File.ReadAllText(tempFile);
            string[] stringArray = temp.Split('\n');
            foreach (string s in stringArray)
            {
                string[] anotherArray = s.Split('=');
                switch (anotherArray[0])
                {
                    case "profileName":
                        tempProfileName = anotherArray[1];
                        break;

                    case "profileDesc":
                        tempProfileDesc = anotherArray[1];
                        break;

                    default:
                        break;
                }
            }
            temp = File.ReadAllText(tanksModsPath + "\\profileInfo.wotprofile");
            stringArray = temp.Split('\n');
            foreach (string s in stringArray)
            {
                string[] anotherArray = s.Split('=');
                switch (anotherArray[0])
                {
                    case "profileName":
                        if (tempProfileName != anotherArray[1])
                        {
                            MessageBox.Show("Selected Profile is not the same as active profile\nupdate aborted");
                            statusInfoLabel.Text = "Idle";
                            return;
                        }
                        break;

                    case "profileDesc":
                        if (tempProfileDesc != anotherArray[1])
                        {
                            MessageBox.Show("Selected Profile is not the same as active profile\nupdate aborted");
                            statusInfoLabel.Text = "Idle";
                            return;
                        }
                        break;

                    default:
                        break;
                }
            }
            tempFile = tempPath + "\\profileInfo.wotprofile";
            Directory.Delete(tempPath, true);
            if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
            this.copy(tanksModsPath, tempPath);
        }

        private void checkActiveProfileButton_Click(object sender, EventArgs e)
        {
            if (tanksModsPath == null)
            {
                MessageBox.Show("atnks mods folder must be selected first");
                return;
            }
            if (!File.Exists(tanksModsPath + "\\profileInfo.wotprofile"))
            {
                activeProfileNameLabel.Text = "No profile active";
                return;
            }
            string temp = File.ReadAllText(tanksModsPath + "\\profileInfo.wotprofile");
            string[] stringArray = temp.Split('\n');
            foreach (string s in stringArray)
            {
                string[] anotherArray = s.Split('=');
                switch (anotherArray[0])
                {
                    case "profileName":
                        activeProfileNameLabel.Text = anotherArray[1];
                        break;

                    case "profileDesc":
                        activeProfileDescLabel.Text = anotherArray[1];
                        break;

                    default:
                        break;
                }
            }
            activeProfilePathLabel.Text = tanksModsPath;
            activeProfileLabel.ForeColor = Color.DarkGreen;
        }
    }
}
