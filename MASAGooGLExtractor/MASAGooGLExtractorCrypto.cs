using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000003 RID: 3
internal class Crypto
{
	// Token: 0x06000005 RID: 5 RVA: 0x000020E8 File Offset: 0x000002E8
	public static string BuildKey()
	{
		byte[] r_key = new byte[12];
		Random rnd = new Random(DateTime.Now.Millisecond);
		for (int i = 0; i < r_key.Length; i++)
		{
			r_key[i] = Convert.ToByte(rnd.Next(97, 122));
		}
		return Encoding.UTF8.GetString(r_key);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000213C File Offset: 0x0000033C
	public static string Encrypt(string toEncrypt, string key, bool useHashing)
	{
		byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
		new AppSettingsReader();
		byte[] keyArray;
		if (useHashing)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			keyArray = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
			md5CryptoServiceProvider.Clear();
		}
		else
		{
			keyArray = Encoding.UTF8.GetBytes(key);
		}
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = keyArray;
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] resultArray = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
		tripleDESCryptoServiceProvider.Clear();
		return Convert.ToBase64String(resultArray, 0, resultArray.Length);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000021C4 File Offset: 0x000003C4
	public static string Decrypt(string cipherString, string key, bool useHashing)
	{
		byte[] toEncryptArray = Convert.FromBase64String(cipherString);
		new AppSettingsReader();
		byte[] keyArray;
		if (useHashing)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			keyArray = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
			md5CryptoServiceProvider.Clear();
		}
		else
		{
			keyArray = Encoding.UTF8.GetBytes(key);
		}
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = keyArray;
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] resultArray = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
		tripleDESCryptoServiceProvider.Clear();
		return Encoding.UTF8.GetString(resultArray);
	}
}
