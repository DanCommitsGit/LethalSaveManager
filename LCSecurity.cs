using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LethalSaveManager
{
	public class LCSecurity
	{
		public static readonly string Password = "lcslime14a5";

		public static string Decrypt(byte[] saveFileData)
		{
			byte[] IV = saveFileData[..16];
			byte[] dataToDecrypt = saveFileData[16..];

			using Aes aes = Aes.Create();
			aes.Key = Rfc2898DeriveBytes.Pbkdf2(Password, IV, 100, HashAlgorithmName.SHA1, 16);

			return new UTF8Encoding(true).GetString(aes.DecryptCbc(dataToDecrypt, IV, PaddingMode.PKCS7));
		}
	}
}
