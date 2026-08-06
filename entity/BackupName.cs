using System;
using System.Text;

namespace LethalSaveManager.entity
{
    public static class BackupName
    {
        public const int MaxFileNameLength = 255;

        static readonly string[] reservedNames =
        [
            "CON", "PRN", "AUX", "NUL", "CLOCK$",
            "COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        ];

        public static string Encode(string name)
        {
            StringBuilder fileName = new StringBuilder();
            foreach (char character in name)
            {
                if (character == '%' || Array.IndexOf(Path.GetInvalidFileNameChars(), character) >= 0)
                    AppendEscaped(fileName, character);
                else
                    fileName.Append(character);
            }

            // Windows ignores a trailing dot or space
            if (fileName.Length > 0 && (fileName[fileName.Length - 1] == '.' || fileName[fileName.Length - 1] == ' '))
            {
                char last = fileName[fileName.Length - 1];
                fileName.Length--;
                AppendEscaped(fileName, last);
            }

            if (IsReservedName(fileName.ToString()))
            {
                char first = fileName[0];
                fileName.Remove(0, 1);
                fileName.Insert(0, EscapeChar(first));
            }

            return fileName.ToString();
        }

        public static string Decode(string fileName)
        {
            return Uri.UnescapeDataString(fileName);
        }

        static void AppendEscaped(StringBuilder fileName, char character)
        {
            fileName.Append(EscapeChar(character));
        }

        static string EscapeChar(char character)
        {
            return "%" + ((int)character).ToString("X2");
        }

        static bool IsReservedName(string fileName)
        {
            int extension = fileName.IndexOf('.');
            string stem = extension < 0 ? fileName : fileName.Substring(0, extension);
            return Array.Exists(reservedNames, reserved => string.Equals(reserved, stem, StringComparison.OrdinalIgnoreCase));
        }
    }
}
