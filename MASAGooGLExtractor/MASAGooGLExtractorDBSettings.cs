using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

// Token: 0x02000004 RID: 4
public class DBSettings
{
	// Token: 0x06000009 RID: 9 RVA: 0x00002250 File Offset: 0x00000450
	public bool Save(string FName)
	{
		XmlSerializer writer = new XmlSerializer(typeof(DBSettings));
		bool flag;
		try
		{
			StreamWriter file = new StreamWriter(FName);
			writer.Serialize(file, this);
			file.Close();
			flag = true;
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000229C File Offset: 0x0000049C
	public string GetXML()
	{
		XmlSerializer writer = new XmlSerializer(typeof(DBSettings));
		string text;
		try
		{
			MemoryStream str = new MemoryStream();
			writer.Serialize(str, this);
			byte[] Bytes = str.GetBuffer();
			text = Encoding.UTF8.GetString(Bytes);
		}
		catch
		{
			text = "";
		}
		return text;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000022F8 File Offset: 0x000004F8
	public static DBSettings Load(string FName)
	{
		XmlSerializer reader = new XmlSerializer(typeof(DBSettings));
		DBSettings dbsettings2;
		try
		{
			StreamReader file = new StreamReader(FName);
			DBSettings dbsettings = (DBSettings)reader.Deserialize(file);
			file.Close();
			dbsettings2 = dbsettings;
		}
		catch
		{
			dbsettings2 = new DBSettings();
		}
		return dbsettings2;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x0000234C File Offset: 0x0000054C
	public static DBSettings LoadAndDecript(string Key = "GBE_DB_FIXED_KEY_2026")
	{
		string EncString = "";
		try
		{
			EncString = File.ReadAllText(string.Format("{0}\\db32.dll", Application.StartupPath));
		}
		catch
		{
		}
		if (EncString != "")
		{
			string XML = Crypto.Decrypt(EncString, Key, true);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(DBSettings));
				MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
				return (DBSettings)xmlSerializer.Deserialize(ms);
			}
			catch
			{
			}
		}
		return new DBSettings();
	}

	// Token: 0x04000002 RID: 2
	public const string DefaultEncryptionKey = "GBE_DB_FIXED_KEY_2026";

	// Token: 0x04000003 RID: 3
	public string MySqlServer;

	// Token: 0x04000004 RID: 4
	public string Port;

	// Token: 0x04000005 RID: 5
	public string User;

	// Token: 0x04000006 RID: 6
	public string Password;

	// Token: 0x04000007 RID: 7
	public string Database;
}
