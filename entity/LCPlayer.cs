using System.IO;

namespace LethalSaveManager.entity
{
	public class LCPlayer : SaveFile
	{
		#region SaveAttributes
		// attributes of the player file
		public static readonly string LastSelectedFile = "SelectedFile"; //int
		public static readonly string LastPlayedVersion = "LastVerPlayed"; //int
		public static readonly string PlayerXP = "PlayerXPNum"; //int
		public static readonly string PlayerLevel = "PlayerLevel"; //int
		public static readonly string PlayerFinishedSetup = "PlayerFinishedSetup"; //bool
		public static readonly string HasUsedTerminal = "HasUsedTerminal"; //bool

		// Player stats
		public static readonly string FinishedShockMinigame = "FinishedShockMinigame"; // int
		public static readonly string TimesLanded = "TimesLanded"; //int
		#endregion

		#region SaveProperties
		public int lastSelectedFile { get; private set; }
		public int lastPlayedVersion { get; private set; }
		public int playerXP { get; private set; }
		public int playerLevel { get; private set; }
		public bool playerFinishedSetup { get; private set; }
		public bool hasUsedTerminal { get; private set; }
		public int finishedShockMinigame { get; private set; }
		public int timesLanded { get; private set; }
		#endregion

		public LCPlayer()
		{
			Load();
		}

		private void Load()
		{
			string playerSavePath = MainForm.GameSavePath + MainForm.PlayerSave;
			if (!File.Exists(playerSavePath))
				return;

			saveData = LCSecurity.Decrypt(File.ReadAllBytes(playerSavePath));

			lastSelectedFile = ReadInt(LastSelectedFile, 1);
			lastPlayedVersion = ReadInt(LastPlayedVersion, 45);
			playerXP = ReadInt(PlayerXP, 0);
			playerLevel = ReadInt(PlayerLevel, 0);
			playerFinishedSetup = ReadBool(PlayerFinishedSetup);
			hasUsedTerminal = ReadBool(HasUsedTerminal);
			finishedShockMinigame = ReadInt(FinishedShockMinigame, 0);
			timesLanded = ReadInt(TimesLanded, 0);
		}
	}
}
