namespace LethalSaveManager.entity
{
	// Lethal Company stores every value as {"attributeName":{"value":<value>}}
	public abstract class SaveFile
	{
		public string saveData { get; protected set; } = "";

		protected string ReadAttribute(string attribute)
		{
			int attributeStart = saveData.IndexOf(attribute);
			if (attributeStart < 0)
				return "";

			int valueStart = saveData.IndexOf("\"value\":", attributeStart);
			int valueEnd = saveData.IndexOf('}', attributeStart);
			if (valueStart < 0 || valueEnd < valueStart)
				return "";

			valueStart += "\"value\":".Length;
			return saveData.Substring(valueStart, valueEnd - valueStart);
		}

		protected int ReadInt(string attribute, int fallback)
		{
			return int.TryParse(ReadAttribute(attribute), out int value) ? value : fallback;
		}

		protected bool ReadBool(string attribute)
		{
			return bool.TryParse(ReadAttribute(attribute), out bool value) && value;
		}
	}
}
