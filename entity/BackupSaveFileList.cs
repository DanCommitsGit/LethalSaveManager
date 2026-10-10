using LethalSaveManager.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager.entity
{
    public class BackupSaveFileList
    {
        Control parent; 
        int _selectedSaveFileIndex = 0;
        public int selectedSaveFileIndex
        {
            get { return _selectedSaveFileIndex; }
            set
            {
                _selectedSaveFileIndex = value;
                saveFileButtons.ForEach(saveFile =>
                {
                    saveFile.button.BackColor = Color.FromArgb(55, 1, 21);
                    saveFile.button.ForeColor = Color.FromArgb(211, 63, 35);
                    if (saveFile.creditsLabel != null)
                    {
                        saveFile.creditsLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.quotaLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.daysLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.creditsText.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.quotaText.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.daysText.ForeColor = Color.FromArgb(150, 30, 20);
                    }
                });
                if (value >= 0 && value < saveFileButtons.Count)
                {
                    saveFileButtons[value].button.BackColor = Color.FromArgb(198, 42, 12);
                    saveFileButtons[value].button.ForeColor = Color.Black;
                    if (saveFileButtons[value].creditsLabel != null)
                    {
                        saveFileButtons[value].creditsLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].quotaLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].daysLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].creditsText.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].quotaText.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].daysText.ForeColor = Color.FromArgb(77, 0, 20);
                    }
                }
                LCSMUtility.RefreshActiveButton();
            }
        }
        public bool hasValidSelection
        {
            get { return _selectedSaveFileIndex >= 0 && _selectedSaveFileIndex < saveFileButtons.Count; }
        }
        public List<SaveFileButton> saveFileButtons = [];
        int lastButtonIndex = 0;
        Action refreshListCallback;
        int rightMargin;

        public BackupSaveFileList(Control parent, Action refreshListCallback, int rightMargin = 0)
        {
            this.parent = parent;
            this.refreshListCallback = refreshListCallback;
            this.rightMargin = rightMargin;
        }

        int Scaled(int designPixels) => (int)Math.Round(designPixels * (parent.DeviceDpi / 96f));

        public void AddButton(string filePath, string name, string credits, string days, string quota)
        {
            int lastButtonIndexCopy = lastButtonIndex;

            Button saveFileButton = new Button();
            //saveFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            saveFileButton.BackColor = Color.FromArgb(55, 1, 21);
            saveFileButton.FlatAppearance.BorderColor = Color.Black;
            saveFileButton.FlatAppearance.BorderSize = 0;
            saveFileButton.FlatStyle = FlatStyle.Flat;
            saveFileButton.Font = new Font("Microsoft Sans Serif", 25 - Math.Min(name.Length * 0.5f, 10), FontStyle.Bold, GraphicsUnit.Point, 0);
            saveFileButton.ForeColor = Color.FromArgb(211, 63, 35);
            saveFileButton.ImageAlign = ContentAlignment.TopCenter;
            saveFileButton.Size = new Size(parent.ClientSize.Width - Scaled(100 + rightMargin), Scaled(90));
            saveFileButton.Location = new Point(Scaled(25), Scaled(67) + (Scaled(100) * lastButtonIndex));
            saveFileButton.Name = "saveFileButton";
            saveFileButton.TabIndex = 43;
            saveFileButton.Text = name;
            saveFileButton.TextAlign = ContentAlignment.MiddleLeft;
            saveFileButton.UseVisualStyleBackColor = false;
            saveFileButton.Click += (sender, e) =>
            {
                selectedSaveFileIndex = lastButtonIndexCopy;
            };

            Label saveCreditsLabel = null;
            Label saveQuotaLabel = null;
            Label saveDaysLabel = null;
            Label saveCreditsText = null;
            Label saveQuotaText = null;
            Label saveDaysText = null;
            Button deleteButton = null;
            TableLayoutPanel statsTable = null;

            if (credits != "" && days != "" && quota != "")
            {
                Label NewStatLabel(string text)
                {
                    Label statLabel = new Label();
                    statLabel.Anchor = AnchorStyles.Left;
                    statLabel.AutoSize = true;
                    statLabel.BackColor = Color.Transparent;
                    statLabel.Font = new Font("Segoe UI", 15F);
                    statLabel.ForeColor = Color.FromArgb(77, 0, 20);
                    statLabel.Margin = new Padding(Scaled(3), Scaled(2), Scaled(3), Scaled(2));
                    statLabel.Text = text;
                    statLabel.TextAlign = ContentAlignment.MiddleLeft;
                    return statLabel;
                }

                saveCreditsLabel = NewStatLabel("Credits:");
                saveQuotaLabel = NewStatLabel("Quota:");
                saveDaysLabel = NewStatLabel("Days:");
                saveCreditsText = NewStatLabel(credits);
                saveQuotaText = NewStatLabel(quota);
                saveDaysText = NewStatLabel(days);

                statsTable = new TableLayoutPanel();
                statsTable.AutoSize = true;
                statsTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                statsTable.BackColor = Color.Transparent;
                statsTable.ColumnCount = 2;
                statsTable.RowCount = 3;
                statsTable.Dock = DockStyle.Right;
                statsTable.Padding = new Padding(0, 0, Scaled(20), 0);
                for (int column = 0; column < statsTable.ColumnCount; column++)
                    statsTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int row = 0; row < statsTable.RowCount; row++)
                    statsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / statsTable.RowCount));

                statsTable.Controls.Add(saveCreditsLabel, 0, 0);
                statsTable.Controls.Add(saveCreditsText, 1, 0);
                statsTable.Controls.Add(saveQuotaLabel, 0, 1);
                statsTable.Controls.Add(saveQuotaText, 1, 1);
                statsTable.Controls.Add(saveDaysLabel, 0, 2);
                statsTable.Controls.Add(saveDaysText, 1, 2);

                deleteButton = new Button();
                deleteButton.BackColor = Color.Transparent;
                deleteButton.FlatAppearance.BorderColor = Color.Black;
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.Image = Resources.x_image;
                deleteButton.Size = new Size(Scaled(50), Scaled(50));
                deleteButton.Location = saveFileButton.Location + new Size(saveFileButton.Size.Width + Scaled(10), (saveFileButton.Size.Height / 2) - (deleteButton.Height / 2));
                deleteButton.Name = "deleteButton";
                deleteButton.TabIndex = 48;
                deleteButton.UseVisualStyleBackColor = false;
                deleteButton.Click += (sender, e) =>
                {
                    if (File.Exists(filePath))
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to move this save file to the recycle bin?", "Delete Save File", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                    else
                    {
                        MessageBox.Show("File does not exist.");
                    }
                    RefreshPreservingSelection();
                };

                saveFileButton.Controls.Add(statsTable);
                parent.Controls.Add(deleteButton);
            }
            parent.Controls.Add(saveFileButton);

            LCSMUtility.UseLethalCompanyFont(saveFileButton);

            if (statsTable != null)
                saveFileButton.Padding = new Padding(0, 0, statsTable.GetPreferredSize(Size.Empty).Width - Scaled(10), 0);

            saveFileButtons.Add(new SaveFileButton(filePath, saveFileButton, saveCreditsLabel, saveQuotaLabel, saveDaysLabel, saveCreditsText, saveQuotaText, saveDaysText, deleteButton));

            selectedSaveFileIndex = selectedSaveFileIndex;

            lastButtonIndex++;
        }

        public void RefreshPreservingSelection()
        {
            string selectedFilePath = hasValidSelection ? saveFileButtons[_selectedSaveFileIndex].filePath : "";
            refreshListCallback();
            selectedSaveFileIndex = saveFileButtons.FindIndex(x => x.filePath == selectedFilePath);
        }

        public void Clear()
        {
            foreach (SaveFileButton saveFile in saveFileButtons)
            {
                saveFile.button.Dispose();
                saveFile.deleteButton?.Dispose();
            }
            saveFileButtons.Clear();
            lastButtonIndex = 0;
        }
    }
}
