using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;

namespace LethalSaveManager.entity
{
	public class LCSave : SaveFile
	{
		#region SaveAttributes
		// attributes of the save files, do not modify unless the savedata changes
		public static readonly string Credits = "GroupCredits"; // Social credits
		public static readonly string PlanetSeed = "RandomSeed";
		public static readonly string Deadline = "DeadlineTime";
		public static readonly string Planet = "CurrentPlanetID";
		public static readonly string Quota = "ProfitQuota";
		public static readonly string QuotasPassed = "QuotasPassed";
		public static readonly string QuotaFulfilled = "QuotaFulfilled";
		public static readonly string Time = "GlobalTime";
		public static readonly string GameVer = "FileGameVers";
		public static readonly string ShipScrapValues = "shipScrapValues"; // Multiple IDs values

		//Stats
		public static readonly string ValueCollected = "Stats_ValueCollected";
		public static readonly string DaySpent = "Stats_DaysSpent";

		//Ship unlocked assets
		public static readonly string UnlockedShipObjects = "UnlockedShipObjects"; // Multiple IDs values
		public static readonly string ShipGrabbableItems = "shipGrabbableItemIDs"; // Multiple IDs values
		public static readonly string ShipGrabbableItemPos = "shipGrabbableItemPos"; // Mutiple Unity Engine Vector3 values
		#endregion

		#region Save Properties
		public bool isModded { get { return gameVer == 9999; } }

		#region Single values
		public int credits { get; private set; }
		public int planetSeed { get; private set; }
		public int deadline { get; private set; }
		public int planet { get; private set; }
		public int quota { get; private set; }
		public int quotasPassed { get; private set; }
		public int quotaFulfilled { get; private set; }
		public int time { get; private set; }
		public int gameVer { get; private set; }
		public int valueCollected { get; private set; }
		public int daySpent { get; private set; }
		#endregion

		#region Array values
		public int[] shipScrapValues { get; private set; } = [];
		public int[] unlockedShipObjects { get; private set; } = [];
		public int[] shipGrabbableItems { get; private set; } = [];
		public UnityVector[] shipGrabbableItemPos { get; private set; } = [];
		#endregion
		#endregion

		public LCSave(string savePath)
		{
			Load(savePath);
		}

		public static bool TryLoad(string savePath, [NotNullWhen(true)] out LCSave? save)
		{
			save = null;
			if (!File.Exists(savePath))
				return false;

			try
			{
				save = new LCSave(savePath);
				return true;
			}
			catch (Exception)
			{
				save = null;
				return false;
			}
		}

		private void Load(string savePath)
		{
			saveData = LCSecurity.Decrypt(File.ReadAllBytes(savePath));

			#region Single Value Get
			credits = ReadInt(Credits, 60);
			planetSeed = ReadInt(PlanetSeed, 0);
			deadline = ReadInt(Deadline, 3);
			planet = ReadInt(Planet, 8);
			quota = ReadInt(Quota, 130);
			quotasPassed = ReadInt(QuotasPassed, 0);
			quotaFulfilled = ReadInt(QuotaFulfilled, 0);
			time = ReadInt(Time, 3000);
			gameVer = ReadInt(GameVer, 45);
			valueCollected = ReadInt(ValueCollected, 0);
			daySpent = ReadInt(DaySpent, 0);
			#endregion

			#region Multiple Value Get
			shipScrapValues = ReadIds(ShipScrapValues);
			unlockedShipObjects = ReadIds(UnlockedShipObjects);
			shipGrabbableItems = ReadIds(ShipGrabbableItems);
			shipGrabbableItemPos = ReadVectors(ShipGrabbableItemPos);
			#endregion
		}

		private int[] ReadIds(string attribute)
		{
			List<int> ids = new List<int>();

			foreach (string value in ReadAttribute(attribute).Trim('[', ']').Split(',', StringSplitOptions.RemoveEmptyEntries))
			{
				if (int.TryParse(value, out int id))
					ids.Add(id);
			}

			return ids.ToArray();
		}

		// The vectors sit inside braces of their own, so ReadAttribute stops short of the closing bracket
		//"value":[{"x":6.69129372,"y":2.10340214,"z":-11.4520636},{"x":4.01256371,"y":0.341714382,"z":-13.9975548}]
		private UnityVector[] ReadVectors(string attribute)
		{
			int attributeStart = saveData.IndexOf(attribute);
			if (attributeStart < 0)
				return [];

			int arrayStart = saveData.IndexOf('[', attributeStart);
			int arrayEnd = saveData.IndexOf(']', attributeStart);
			if (arrayStart < 0 || arrayEnd < arrayStart)
				return [];

			List<UnityVector> vectors = new List<UnityVector>();

			foreach (string entry in saveData.Substring(arrayStart + 1, arrayEnd - arrayStart - 1).Split('}', StringSplitOptions.RemoveEmptyEntries))
			{
				string[] components = entry.Trim(',', '{').Split(',');
				UnityVector vector = new UnityVector();

				if (components.Length == 3
					&& TryReadComponent(components[0], out vector.x)
					&& TryReadComponent(components[1], out vector.y)
					&& TryReadComponent(components[2], out vector.z))
					vectors.Add(vector);
			}

			return vectors.ToArray();
		}

		private static bool TryReadComponent(string component, out float value)
		{
			value = 0;
			int separator = component.IndexOf(':');

			return separator >= 0
				&& float.TryParse(component.Substring(separator + 1), NumberStyles.Float, CultureInfo.InvariantCulture, out value);
		}
	}
}
