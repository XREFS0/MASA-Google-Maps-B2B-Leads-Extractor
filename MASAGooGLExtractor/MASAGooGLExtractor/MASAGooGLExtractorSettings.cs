using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace MASAGooGLExtractor
{
	// Token: 0x0200001F RID: 31
	public class Settings
	{
		// Token: 0x06000104 RID: 260
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern uint VerLanguageName(uint wLang, [Out] char[] szLang, int nSize);

		// Token: 0x06000105 RID: 261 RVA: 0x000105C8 File Offset: 0x0000E7C8
		public Settings()
		{
			this.NumberOfResultsPerZipCode = 20;
			this.AutoRestart = false;
			this.numthreads = 3;
			this.DataSource = 0;
			CultureInfo Culture = CultureInfo.CurrentCulture;
			if (Culture.Name.IndexOf("it") > -1)
			{
				this.Language = 1;
			}
			else if (Culture.Name.IndexOf("de") > -1)
			{
				this.Language = 2;
			}
			else if (Culture.Name.IndexOf("fr") > -1)
			{
				this.Language = 3;
			}
			else if (Culture.Name.IndexOf("es") > -1)
			{
				this.Language = 4;
			}
			else
			{
				this.Language = 0;
			}
			this.ColumnsToShow = new bool[15];
			this.ColumnsToExport = new bool[15];
			for (int i = 0; i < 15; i++)
			{
				this.ColumnsToShow[i] = true;
				this.ColumnsToExport[i] = true;
			}
			this.ExtractEmails = true;
			this.AutoExport = false;
			this.ProxySourcesList = new string[]
			{
				"http://gatherproxy.com/proxylist/country/?c=United%20States", "http://gatherproxy.com/proxylist/country/?c=Canada", "http://txt.proxyspy.net/proxy.txt", "http://dogdev.net/Proxy/US?port=8080", "", "", "", "", "", "",
				"", "", "", ""
			};
			this.CSVDelimiter = 1;
			this.CSVEncoding = 2;
			this.Categories = new List<string>();
			this.Locations = new List<Location>();
			this.Tasks = new List<Task>();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00010770 File Offset: 0x0000E970
		public bool Save(string FName)
		{
			XmlSerializer writer = new XmlSerializer(typeof(Settings));
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

		// Token: 0x06000107 RID: 263 RVA: 0x000107BC File Offset: 0x0000E9BC
		public static Settings Load(string FName)
		{
			XmlSerializer reader = new XmlSerializer(typeof(Settings));
			Settings settings2;
			try
			{
				StreamReader file = new StreamReader(FName);
				Settings settings = (Settings)reader.Deserialize(file);
				file.Close();
				settings2 = settings;
			}
			catch
			{
				settings2 = new Settings();
			}
			return settings2;
		}

		// Token: 0x040000F7 RID: 247
		public int Language;

		// Token: 0x040000FB RID: 251
		public bool[] ColumnsToShow;

		// Token: 0x040000FC RID: 252
		public bool[] ColumnsToExport;

		// Token: 0x040000FD RID: 253
		public bool AutoExport;

		// Token: 0x040000FE RID: 254
		public string AutoExportPath;

		// Token: 0x040000FF RID: 255
		public bool ExtractEmails;

		// Token: 0x04000100 RID: 256
		public int NumberOfResultsPerZipCode;

		// Token: 0x04000101 RID: 257
		public bool AutoRestart;

		// Token: 0x04000102 RID: 258
		public int numthreads;

		// Token: 0x04000103 RID: 259
		public int DataSource;

		// Token: 0x04000104 RID: 260
		public int ExportType;

		// Token: 0x04000105 RID: 261
		public int CSVDelimiter;

		// Token: 0x04000106 RID: 262
		public int CSVEncoding;

		// Token: 0x04000107 RID: 263
		public int ConnectionType;

		// Token: 0x04000108 RID: 264
		public string ProxyServer;

		// Token: 0x04000109 RID: 265
		public int ProxyPort;

		// Token: 0x0400010A RID: 266
		public bool ProxyAuthentification;

		// Token: 0x0400010B RID: 267
		public string ProxyAuthLogin;

		// Token: 0x0400010C RID: 268
		public int Numeric;

		// Token: 0x0400010D RID: 269
		public string ProxyAuthPassword;

		// Token: 0x0400010E RID: 270
		public string[] ProxyList;

		// Token: 0x0400010F RID: 271
		public string[] ProxySourcesList;

		// Token: 0x04000110 RID: 272
		public bool IsRandomDelay;

		// Token: 0x04000111 RID: 273
		public int DelayFrom;

		// Token: 0x04000112 RID: 274
		public int DelayTo;

		// Token: 0x04000113 RID: 275
		public List<string> Categories;

		// Token: 0x04000114 RID: 276
		public List<Location> Locations;

		// Token: 0x04000115 RID: 277
		public List<Task> Tasks;
	}
}
