using LethalSaveManager.forms;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LethalSaveManager.entity;
using Microsoft.VisualBasic.FileIO;

namespace LethalSaveManager
{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static MainForm instance;

        public static readonly string LocalLowPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\LocalLow\\";
        public static string GameSavePath = LocalLowPath + "ZeekerssRBLX\\Lethal Company\\";
        public static readonly string DefaultSaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LethalSaveManager\\GameSaveBackups\\";
        public static string CustomBackupDirectory = DefaultSaveDirectory;

        public static readonly string PlayerSave = "LCGeneralSaveData";

        public static LCPlayer PlayerInfo = new();
        public static LCSave saveInfo = new();
        public static LCSave BackupInfo = new();

        public static BackupSaveFileList backupSaveFileList;
        public static BackupSaveFileList gameSaveFileList;

        public MainForm()
        {
            if (instance == null)
                instance = this;
            else
                throw new Exception("Singleton instance MainForm already exists.");

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gameSaveFileList = new BackupSaveFileList(gameSaveFilesPanel, PopulateSaves);
            backupSaveFileList = new BackupSaveFileList(backupSaveFilesPanel, PopulateBackups, 10);

            //AllocConsole();

            LCSMUtility.UseLethalCompanyFont(this);

            Directory.CreateDirectory(DefaultSaveDirectory);

            PopulateSaves();

            gameSaveFileList.selectedSaveFileIndex = PlayerInfo.lastSelectedFile;

            PopulateBackups();

            Console.WriteLine("Lethal Company Save Manager started");
            backupSaveFilesPanel.VerticalScroll.Visible = false;
            /*string test = LCSecurity.Decrypt(File.ReadAllBytes(GameSavePath + PlayerSave));
			File.WriteAllText("corrupt.txt", test);*/
            /*string test = LCSecurity.Decrypt(File.ReadAllBytes(CustomBackupDirectory + "LCBackup2"));
			File.WriteAllText("backup.txt", test);*/
        }

        #region Loading and data
        private void PopulateSaves()
        {
            Console.WriteLine("Populating saves");
            gameSaveFileList.Clear();

            for (int slot = 1; slot <= 3; slot++)
            {
                string savePath = GameSavePath + "LCSaveFile" + slot;
                string slotName = "File " + slot;

                if (LCSave.TryLoad(savePath, out LCSave? save))
                    gameSaveFileList.AddButton(savePath, slotName, save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
                else
                    gameSaveFileList.AddButton(savePath, slotName, "", "", "");
            }

            LCSMUtility.RefreshActiveButton();
        }

        private void PopulateBackups()
        {
            backupSaveFilesPanel.VerticalScroll.Value = 0;
            Console.WriteLine("Populating backups");
            backupSaveFileList.Clear();

            if (!Directory.Exists(CustomBackupDirectory))
            {
                Directory.CreateDirectory(CustomBackupDirectory);
            }

            DirectoryInfo dir = new DirectoryInfo(CustomBackupDirectory);

            foreach (FileInfo item in dir.GetFiles())
            {
                if (!LCSave.TryLoad(item.FullName, out LCSave? save))
                    continue;

                backupSaveFileList.AddButton(item.FullName, BackupName.Decode(item.Name), save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
            }

            if (backupSaveFileList.saveFileButtons.Count > 0)
                noBackupsFoundLabel.Visible = false;
            else
                noBackupsFoundLabel.Visible = true;

            LCSMUtility.RefreshActiveButton();
        }

        private void LoadPlayerData()
        {
            PlayerInfo.Load();
        }
        #endregion

        private void BackupSelectedGameSaveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Backup selected game save button clicked");

            if (!Directory.Exists(CustomBackupDirectory))
            {
                Directory.CreateDirectory(CustomBackupDirectory);
            }

            DirectoryInfo backupDir = new DirectoryInfo(CustomBackupDirectory);

            // if file is already in the directory, increment the number untill the name is unique
            int backupNumber = backupDir.GetFiles().Length;
            string backupPath;
            do
            {
                backupPath = Path.Combine(CustomBackupDirectory, BackupName.Encode("Backup " + (++backupNumber).ToString()));
            }
            while (File.Exists(backupPath));

            File.Copy(gameSaveFileList.saveFileButtons[gameSaveFileList.selectedSaveFileIndex].filePath, backupPath);

            PopulateBackups();

            backupSaveFileList.selectedSaveFileIndex = backupSaveFileList.saveFileButtons.FindIndex(x => x.filePath == backupPath);
        }

        private void LoadBackupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load backup button clicked");
            string selectedBackup = backupSaveFileList.saveFileButtons[backupSaveFileList.selectedSaveFileIndex].filePath;
            string selectedSave = gameSaveFileList.saveFileButtons[gameSaveFileList.selectedSaveFileIndex].filePath;

            if (File.Exists(selectedBackup))
            {
                if (!Directory.Exists(GameSavePath))
                {
                    Directory.CreateDirectory(GameSavePath);
                }

                DialogResult confirmResult = DialogResult.None;
                if (File.Exists(selectedSave))
                {
                    confirmResult = MessageBox.Show("Are you sure to load this backup? This will overwrite the current selected save slot.", "Confirm Load Backup", MessageBoxButtons.YesNo);
                }

                // Delete the current save file if it exists and the user confirms
                if (File.Exists(selectedSave) && confirmResult == DialogResult.Yes)
                {
                    FileSystem.DeleteFile(selectedSave, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }

                // Copy the backup to the save slot
                if (!File.Exists(selectedSave) || confirmResult == DialogResult.Yes)
                {
                    File.Copy(selectedBackup, selectedSave);
                    PopulateSaves();
                }
            }
        }

        private void RenameBackupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Rename backup button clicked");
            FileInfo backup = new FileInfo(backupSaveFileList.saveFileButtons[backupSaveFileList.selectedSaveFileIndex].filePath);
            if (!backup.Exists)
                return;

            string currentName = BackupName.Decode(backup.Name);
            string newName = currentName;

            while (true)
            {
                using RenameDialog renameDialog = new RenameDialog();
                renameDialog.fileNameTextBox.Text = newName;
                if (renameDialog.ShowDialog(this) != DialogResult.OK)
                    return;

                newName = renameDialog.fileNameTextBox.Text.Trim();
                if (newName == currentName)
                    return;

                if (newName.Length == 0)
                {
                    MessageBox.Show("Enter a name for the backup.", "Rename Backup");
                    continue;
                }

                string fileName = BackupName.Encode(newName);
                if (fileName.Length > BackupName.MaxFileNameLength)
                {
                    MessageBox.Show("Error: Entered name is too long.", "Rename Backup");
                    continue;
                }

                string newPath = Path.Combine(CustomBackupDirectory, fileName);
                bool nameTaken = File.Exists(newPath)
                    && !string.Equals(newPath, backup.FullName, StringComparison.OrdinalIgnoreCase);
                if (nameTaken)
                {
                    MessageBox.Show("A backup named \"" + newName + "\" already exists.", "Rename Backup");
                    continue;
                }

                try
                {
                    File.Move(backup.FullName, newPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not rename the backup. " + ex.Message, "Rename Backup");
                    continue;
                }

                PopulateBackups();
                backupSaveFileList.selectedSaveFileIndex = backupSaveFileList.saveFileButtons.FindIndex(x => x.filePath == newPath);
                return;
            }
        }

        private void openGameSaveDirectory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening game save directory");
            Process.Start("explorer.exe", GameSavePath);
        }

        private void openBackupSaveDirectory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening backup save directory");
            Process.Start("explorer.exe", CustomBackupDirectory);
        }

        private void refreshSaveList_Click(object sender, EventArgs e)
        {
            PopulateSaves();
        }

        private void refreshBackupList_Click(object sender, EventArgs e)
        {
            PopulateBackups();
        }
    }
}
