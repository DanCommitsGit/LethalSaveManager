using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager
{
	public class LCSecurity
	{
		public static readonly string Password = "lcslime14a5";

		public static string Decrypt(byte[] data)
		{
			byte[] IV = new byte[16];
			Array.Copy(data, IV, 16);
			byte[] dataToDecrypt = new byte[data.Length - 16];
			Array.Copy(data, 16, dataToDecrypt, 0, dataToDecrypt.Length);

			using (Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(Password, IV, 100, HashAlgorithmName.SHA1))
			using (Aes decAlg = Aes.Create())
			{
				decAlg.Mode = CipherMode.CBC;
				decAlg.Padding = PaddingMode.PKCS7;
				decAlg.Key = k2.GetBytes(16);
				decAlg.IV = IV;

				using (MemoryStream decryptionStreamBacking = new MemoryStream())
				using (CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write))
				{
					decrypt.Write(dataToDecrypt, 0, dataToDecrypt.Length);
					decrypt.FlushFinalBlock();

					return new UTF8Encoding(true).GetString(decryptionStreamBacking.ToArray());
				}
			}
		}

	}
}
