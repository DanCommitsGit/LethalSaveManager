namespace LethalSaveManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            backupSaveButton = new Button();
            loadBackupButton = new Button();
            renameBackupButton = new Button();
            gameSaveFilesPanel = new Panel();
            gameSaveFileSelectionTitle = new Label();
            refreshSaveList = new Button();
            gameSaveFilesPanelBackPanel = new Panel();
            backupSaveFilesPanelBackPanel = new Panel();
            refreshBackupList = new Button();
            backupSaveFilesViewport = new Panel();
            backupSaveFilesPanel = new Panel();
            backupSaveFileSectionTitle = new Label();
            noBackupsFoundLabel = new Label();
            openGameSaveDirectory = new Button();
            openBackupSaveDirectory = new Button();
            openGitHubRepo = new Button();
            appVersionLabel = new Label();
            appTitle = new Label();
            rootLayout = new TableLayoutPanel();
            middleLayout = new TableLayoutPanel();
            gameSaveFilesPanel.SuspendLayout();
            gameSaveFilesPanelBackPanel.SuspendLayout();
            backupSaveFilesPanelBackPanel.SuspendLayout();
            backupSaveFilesViewport.SuspendLayout();
            backupSaveFilesPanel.SuspendLayout();
            rootLayout.SuspendLayout();
            middleLayout.SuspendLayout();
            SuspendLayout();
            // 
            // backupSaveButton
            // 
            backupSaveButton.BackColor = Color.FromArgb(56, 0, 0);
            backupSaveButton.FlatAppearance.BorderSize = 0;
            backupSaveButton.FlatStyle = FlatStyle.Flat;
            backupSaveButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            backupSaveButton.ForeColor = Color.FromArgb(217, 247, 236);
            backupSaveButton.ImageAlign = ContentAlignment.TopCenter;
            backupSaveButton.Dock = DockStyle.Top;
            backupSaveButton.Name = "backupSaveButton";
            backupSaveButton.Size = new Size(275, 75);
            backupSaveButton.Margin = new Padding(15, 0, 15, 15);
            backupSaveButton.TabIndex = 12;
            backupSaveButton.Text = "Backup Selected Game Save";
            backupSaveButton.UseVisualStyleBackColor = false;
            backupSaveButton.Click += BackupSelectedGameSaveButton_Click;
            // 
            // loadBackupButton
            // 
            loadBackupButton.BackColor = Color.FromArgb(56, 0, 0);
            loadBackupButton.FlatAppearance.BorderSize = 0;
            loadBackupButton.FlatStyle = FlatStyle.Flat;
            loadBackupButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            loadBackupButton.ForeColor = Color.FromArgb(217, 247, 236);
            loadBackupButton.ImageAlign = ContentAlignment.TopCenter;
            loadBackupButton.Dock = DockStyle.Top;
            loadBackupButton.Name = "loadBackupButton";
            loadBackupButton.Size = new Size(275, 75);
            loadBackupButton.Margin = new Padding(15, 0, 15, 15);
            loadBackupButton.TabIndex = 11;
            loadBackupButton.Text = "Load Selected Backup into Selected Game Save File";
            loadBackupButton.UseVisualStyleBackColor = false;
            loadBackupButton.Click += LoadBackupButton_Click;
            // 
            // renameBackupButton
            // 
            renameBackupButton.BackColor = Color.FromArgb(56, 0, 0);
            renameBackupButton.FlatAppearance.BorderSize = 0;
            renameBackupButton.FlatStyle = FlatStyle.Flat;
            renameBackupButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            renameBackupButton.ForeColor = Color.FromArgb(217, 247, 236);
            renameBackupButton.ImageAlign = ContentAlignment.TopCenter;
            renameBackupButton.Dock = DockStyle.Top;
            renameBackupButton.Name = "renameBackupButton";
            renameBackupButton.Size = new Size(275, 75);
            renameBackupButton.Margin = new Padding(15, 0, 15, 0);
            renameBackupButton.TabIndex = 21;
            renameBackupButton.Text = "Rename Selected Backup";
            renameBackupButton.UseVisualStyleBackColor = false;
            renameBackupButton.Click += RenameBackupButton_Click;
            // 
            // gameSaveFilesPanel
            // 
            gameSaveFilesPanel.Dock = DockStyle.Fill;
            gameSaveFilesPanel.BackColor = Color.FromArgb(48, 2, 21);
            gameSaveFilesPanel.Controls.Add(gameSaveFileSelectionTitle);
            gameSaveFilesPanel.Name = "gameSaveFilesPanel";
            gameSaveFilesPanel.Size = new Size(435, 400);
            gameSaveFilesPanel.TabIndex = 44;
            // 
            // gameSaveFileSelectionTitle
            // 
            gameSaveFileSelectionTitle.Dock = DockStyle.Top;
            gameSaveFileSelectionTitle.AutoSize = false;
            gameSaveFileSelectionTitle.Font = new Font("Segoe UI", 22F);
            gameSaveFileSelectionTitle.ForeColor = Color.FromArgb(184, 25, 14);
            gameSaveFileSelectionTitle.Name = "gameSaveFileSelectionTitle";
            gameSaveFileSelectionTitle.Size = new Size(435, 62);
            gameSaveFileSelectionTitle.TabIndex = 44;
            gameSaveFileSelectionTitle.Text = "Save File";
            gameSaveFileSelectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // refreshSaveList
            // 
            refreshSaveList.FlatAppearance.BorderSize = 0;
            refreshSaveList.FlatStyle = FlatStyle.Flat;
            refreshSaveList.Image = Properties.Resources.refresh_icon;
            refreshSaveList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshSaveList.Location = new Point(380, 345);
            refreshSaveList.Name = "refreshSaveList";
            refreshSaveList.Size = new Size(50, 50);
            refreshSaveList.TabIndex = 3;
            refreshSaveList.UseVisualStyleBackColor = true;
            refreshSaveList.Click += refreshSaveList_Click;
            // 
            // gameSaveFilesPanelBackPanel
            // 
            gameSaveFilesPanelBackPanel.BackColor = Color.FromArgb(122, 0, 0);
            gameSaveFilesPanelBackPanel.Controls.Add(refreshSaveList);
            gameSaveFilesPanelBackPanel.Controls.Add(gameSaveFilesPanel);
            gameSaveFilesPanelBackPanel.Dock = DockStyle.Fill;
            gameSaveFilesPanelBackPanel.Margin = new Padding(8);
            gameSaveFilesPanelBackPanel.Padding = new Padding(5);
            gameSaveFilesPanelBackPanel.Name = "gameSaveFilesPanelBackPanel";
            gameSaveFilesPanelBackPanel.Size = new Size(445, 410);
            gameSaveFilesPanelBackPanel.TabIndex = 45;
            // 
            // backupSaveFilesPanelBackPanel
            // 
            backupSaveFilesPanelBackPanel.BackColor = Color.FromArgb(122, 0, 0);
            backupSaveFilesPanelBackPanel.Controls.Add(refreshBackupList);
            backupSaveFilesPanelBackPanel.Controls.Add(backupSaveFilesViewport);
            backupSaveFilesPanelBackPanel.Dock = DockStyle.Fill;
            backupSaveFilesPanelBackPanel.Margin = new Padding(8);
            backupSaveFilesPanelBackPanel.Padding = new Padding(5);
            backupSaveFilesPanelBackPanel.Name = "backupSaveFilesPanelBackPanel";
            backupSaveFilesPanelBackPanel.Size = new Size(540, 410);
            backupSaveFilesPanelBackPanel.TabIndex = 46;
            // 
            // refreshBackupList
            // 
            refreshBackupList.FlatAppearance.BorderSize = 0;
            refreshBackupList.FlatStyle = FlatStyle.Flat;
            refreshBackupList.Image = Properties.Resources.refresh_icon;
            refreshBackupList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshBackupList.Location = new Point(475, 345);
            refreshBackupList.Name = "refreshBackupList";
            refreshBackupList.Size = new Size(50, 50);
            refreshBackupList.TabIndex = 45;
            refreshBackupList.UseVisualStyleBackColor = true;
            refreshBackupList.Click += refreshBackupList_Click;
            // 
            // backupSaveFilesViewport
            // 
            backupSaveFilesViewport.BackColor = Color.FromArgb(48, 2, 21);
            backupSaveFilesViewport.Controls.Add(backupSaveFilesPanel);
            backupSaveFilesViewport.Dock = DockStyle.Fill;
            backupSaveFilesViewport.Name = "backupSaveFilesViewport";
            backupSaveFilesViewport.Size = new Size(530, 400);
            backupSaveFilesViewport.TabIndex = 47;
            backupSaveFilesViewport.Resize += FitBackupListToViewport;
            // 
            // backupSaveFilesPanel
            // 
            backupSaveFilesPanel.AutoScroll = true;
            backupSaveFilesPanel.AutoScrollMargin = new Size(0, 100);
            backupSaveFilesPanel.BackColor = Color.FromArgb(48, 2, 21);
            backupSaveFilesPanel.Controls.Add(noBackupsFoundLabel);
            backupSaveFilesPanel.Controls.Add(backupSaveFileSectionTitle);
            backupSaveFilesPanel.Name = "backupSaveFilesPanel";
            backupSaveFilesPanel.Size = new Size(530, 400);
            backupSaveFilesPanel.TabIndex = 44;
            backupSaveFilesPanel.ClientSizeChanged += FitBackupListToViewport;
            // 
            // backupSaveFileSectionTitle
            // 
            backupSaveFileSectionTitle.Dock = DockStyle.Top;
            backupSaveFileSectionTitle.AutoSize = false;
            backupSaveFileSectionTitle.Font = new Font("Segoe UI", 22F);
            backupSaveFileSectionTitle.ForeColor = Color.FromArgb(184, 25, 14);
            backupSaveFileSectionTitle.Name = "backupSaveFileSectionTitle";
            backupSaveFileSectionTitle.Size = new Size(435, 62);
            backupSaveFileSectionTitle.TabIndex = 44;
            backupSaveFileSectionTitle.Text = "Backup Save Files";
            backupSaveFileSectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // noBackupsFoundLabel
            // 
            noBackupsFoundLabel.Dock = DockStyle.Fill;
            noBackupsFoundLabel.AutoSize = false;
            noBackupsFoundLabel.Name = "noBackupsFoundLabel";
            noBackupsFoundLabel.Size = new Size(107, 15);
            noBackupsFoundLabel.TabIndex = 45;
            noBackupsFoundLabel.Text = "No Backups Found";
            noBackupsFoundLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // openGameSaveDirectory
            // 
            openGameSaveDirectory.BackColor = Color.FromArgb(56, 0, 0);
            openGameSaveDirectory.FlatAppearance.BorderSize = 0;
            openGameSaveDirectory.FlatStyle = FlatStyle.Flat;
            openGameSaveDirectory.Font = new Font("Segoe UI", 12F);
            openGameSaveDirectory.ForeColor = Color.FromArgb(254, 101, 22);
            openGameSaveDirectory.Anchor = AnchorStyles.None;
            openGameSaveDirectory.AutoSize = true;
            openGameSaveDirectory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            openGameSaveDirectory.Name = "openGameSaveDirectory";
            openGameSaveDirectory.Padding = new Padding(14, 4, 14, 4);
            openGameSaveDirectory.Margin = new Padding(8);
            openGameSaveDirectory.TabIndex = 49;
            openGameSaveDirectory.Text = "[ Open Game Save Directory ]";
            openGameSaveDirectory.UseVisualStyleBackColor = false;
            openGameSaveDirectory.Click += openGameSaveDirectory_Click;
            // 
            // openBackupSaveDirectory
            // 
            openBackupSaveDirectory.BackColor = Color.FromArgb(56, 0, 0);
            openBackupSaveDirectory.FlatAppearance.BorderSize = 0;
            openBackupSaveDirectory.FlatStyle = FlatStyle.Flat;
            openBackupSaveDirectory.Font = new Font("Segoe UI", 12F);
            openBackupSaveDirectory.ForeColor = Color.FromArgb(254, 101, 22);
            openBackupSaveDirectory.Anchor = AnchorStyles.None;
            openBackupSaveDirectory.AutoSize = true;
            openBackupSaveDirectory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            openBackupSaveDirectory.Name = "openBackupSaveDirectory";
            openBackupSaveDirectory.Padding = new Padding(14, 4, 14, 4);
            openBackupSaveDirectory.Margin = new Padding(8);
            openBackupSaveDirectory.TabIndex = 50;
            openBackupSaveDirectory.Text = "[ Open Backup Save Directory ]";
            openBackupSaveDirectory.UseVisualStyleBackColor = false;
            openBackupSaveDirectory.Click += openBackupSaveDirectory_Click;
            //
            // openGitHubRepo
            //
            openGitHubRepo.BackColor = Color.FromArgb(56, 0, 0);
            openGitHubRepo.FlatAppearance.BorderSize = 0;
            openGitHubRepo.FlatStyle = FlatStyle.Flat;
            openGitHubRepo.Font = new Font("Segoe UI", 12F);
            openGitHubRepo.ForeColor = Color.FromArgb(254, 101, 22);
            openGitHubRepo.Anchor = AnchorStyles.None;
            openGitHubRepo.AutoSize = true;
            openGitHubRepo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            openGitHubRepo.Name = "openGitHubRepo";
            openGitHubRepo.Padding = new Padding(14, 4, 14, 4);
            openGitHubRepo.Margin = new Padding(8);
            openGitHubRepo.TabIndex = 56;
            openGitHubRepo.Text = "[ GitHub ]";
            openGitHubRepo.UseVisualStyleBackColor = false;
            openGitHubRepo.Click += openGitHubRepo_Click;
            //
            // appVersionLabel
            // 
            appVersionLabel.AutoSize = true;
            appVersionLabel.Font = new Font("Segoe UI", 12F);
            appVersionLabel.Anchor = AnchorStyles.None;
            appVersionLabel.Margin = new Padding(0, 0, 0, 30);
            appVersionLabel.Name = "appVersionLabel";
            appVersionLabel.Size = new Size(27, 21);
            appVersionLabel.TabIndex = 52;
            appVersionLabel.Text = "v3";
            // 
            // appTitle
            // 
            appTitle.Anchor = AnchorStyles.None;
            appTitle.AutoSize = true;
            appTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            appTitle.Margin = new Padding(0, 10, 0, 3);
            appTitle.MaximumSize = new Size(315, 0);
            appTitle.Name = "appTitle";
            appTitle.Size = new Size(250, 32);
            appTitle.TabIndex = 53;
            appTitle.Text = "Lethal Save Manager";
            appTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // middleLayout
            // 
            middleLayout.ColumnCount = 1;
            middleLayout.RowCount = 6;
            middleLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middleLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            middleLayout.Controls.Add(appTitle, 0, 0);
            middleLayout.Controls.Add(appVersionLabel, 0, 1);
            middleLayout.Controls.Add(backupSaveButton, 0, 2);
            middleLayout.Controls.Add(loadBackupButton, 0, 3);
            middleLayout.Controls.Add(renameBackupButton, 0, 4);
            middleLayout.Dock = DockStyle.Fill;
            middleLayout.Margin = new Padding(0);
            middleLayout.Name = "middleLayout";
            middleLayout.TabIndex = 54;
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 3;
            rootLayout.RowCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 305F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rootLayout.Controls.Add(gameSaveFilesPanelBackPanel, 0, 0);
            rootLayout.Controls.Add(middleLayout, 1, 0);
            rootLayout.Controls.Add(backupSaveFilesPanelBackPanel, 2, 0);
            rootLayout.Controls.Add(openGameSaveDirectory, 0, 1);
            rootLayout.Controls.Add(openGitHubRepo, 1, 1);
            rootLayout.Controls.Add(openBackupSaveDirectory, 2, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(2);
            rootLayout.TabIndex = 55;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(29, 0, 0);
            ClientSize = new Size(1309, 481);
            Controls.Add(rootLayout);
            ForeColor = Color.FromArgb(147, 177, 166);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(700, 300);
            Name = "MainForm";
            Text = "Lethal Save Manager";
            Load += MainForm_Load;
            gameSaveFilesPanel.ResumeLayout(false);
            gameSaveFilesPanel.PerformLayout();
            gameSaveFilesPanelBackPanel.ResumeLayout(false);
            backupSaveFilesPanelBackPanel.ResumeLayout(false);
            backupSaveFilesViewport.ResumeLayout(false);
            backupSaveFilesPanel.ResumeLayout(false);
            rootLayout.ResumeLayout(false);
            middleLayout.ResumeLayout(false);
            middleLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel gameSaveFilesPanel;
        private Label gameSaveFileSelectionTitle;
        private Panel gameSaveFilesPanelBackPanel;
        private Panel backupSaveFilesPanelBackPanel;
        private Panel backupSaveFilesViewport;
        private Panel backupSaveFilesPanel;
        private Label backupSaveFileSectionTitle;
        private Button openGameSaveDirectory;
        private Button openBackupSaveDirectory;
        private Button openGitHubRepo;
        private Label noBackupsFoundLabel;
        internal Button loadBackupButton;
        internal Button renameBackupButton;
        private Label appVersionLabel;
        private Label appTitle;
        private TableLayoutPanel rootLayout;
        private TableLayoutPanel middleLayout;
        private Button refreshSaveList;
        private Button refreshBackupList;
        internal Button backupSaveButton;
    }
}

