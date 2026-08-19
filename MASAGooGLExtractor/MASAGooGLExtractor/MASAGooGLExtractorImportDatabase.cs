using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace MASAGooGLExtractor
{
	// Token: 0x02000014 RID: 20
	public static class ImportDatabase
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00006AA0 File Offset: 0x00004CA0
		public static void ImportCountries()
		{
			string[] Data = File.ReadAllLines("geo\\world.sql");
			int Counter = 0;
			string ValuesBlock = "";
			int BlockCounter = 0;
			foreach (string Item in Data)
			{
				if (Item.Trim() != "")
				{
					string[] Values = Item.Replace("\\'", "`").Split(new char[] { ',' });
					ValuesBlock += string.Format("({0}, {1}, {2}, '{3}'),", new object[]
					{
						Values[0].Trim(),
						Values[1].Trim(),
						Values[2].Trim(),
						Values[5].Replace("'", "").Trim()
					});
					BlockCounter++;
					if (BlockCounter % 1000 == 0)
					{
						Program.AppDatabase.DoRequest("INSERT INTO city VALUES " + ValuesBlock.Substring(0, ValuesBlock.Length - 1));
						BlockCounter = 0;
						ValuesBlock = "";
					}
				}
				Counter++;
				float num = 100f * (float)Counter / (float)Data.Length;
			}
			if (ValuesBlock != "")
			{
				Program.AppDatabase.DoRequest("INSERT INTO city VALUES " + ValuesBlock.Substring(0, ValuesBlock.Length - 1));
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00006BF0 File Offset: 0x00004DF0
		public static void ImportZipCodes()
		{
			File.WriteAllText(ImportDatabase.LogFileName, "Country,State,City,CityId,ZipCode" + Environment.NewLine);
			string[] Data = File.ReadAllLines("geo\\zip-code.csv");
			string ValuesBlock = "";
			for (int ItemIndex = 0; ItemIndex < Data.Length; ItemIndex++)
			{
				string[] Values = Data[ItemIndex].Replace("\"", "").Split(new char[] { ',' });
				if (Values.Length > 4 && Values[1] != "" && Values[2] != "" && Values[3] != "" && Values[4] != "")
				{
					List<object[]> City = LocationEditForm.AppDatabase.Select(string.Format("SELECT * FROM city AS t1 LEFT OUTER JOIN country AS t2 ON t1.country_id=t2.Id LEFT OUTER JOIN region AS t3 ON t1.region_id=t3.Id WHERE t1.name='{0}' AND t2.code='{1}' AND t3.code='{2}'", Values[3].Trim(), Values[1].ToLower().Trim(), Values[2].Trim()));
					if (City.Count > 0)
					{
						try
						{
							Program.AppDatabase.DoRequest(string.Format("INSERT INTO zip_codes VALUES (null, '{0}', '{1}')", City[0][0], Values[4].Trim()));
							File.AppendAllText(ImportDatabase.LogFileName, string.Format("{0},{1},{2},{3},{4}{5}", new object[]
							{
								Values[1],
								Values[2],
								Values[3],
								City[0][0],
								Values[4],
								Environment.NewLine
							}));
						}
						catch (Exception ex)
						{
							File.AppendAllText(ImportDatabase.LogFileName, string.Format("{0},{1},{2},{3},{4},{5}{6}", new object[]
							{
								Values[1],
								Values[2],
								Values[3],
								City[0][0],
								Values[4],
								ex.Message,
								Environment.NewLine
							}));
						}
					}
				}
				float num = 100f * (float)ItemIndex / (float)Data.Length;
			}
			if (ValuesBlock != "")
			{
				Program.AppDatabase.DoRequest("INSERT INTO city VALUES " + ValuesBlock.Substring(0, ValuesBlock.Length - 1));
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00006E04 File Offset: 0x00005004
		public static void ImportZipCodesFromFile()
		{
			string ZipCodesData = File.ReadAllText("geo\\allCountries.txt");
			List<string> Requests = new List<string>();
			List<object[]> Countries = LocationEditForm.AppDatabase.Select("SELECT * FROM `country` WHERE Id in (51, 62, 69, 100, 230)");
			int CountryCounter = 0;
			foreach (object[] Country in Countries)
			{
				CountryCounter++;
				List<object[]> CountryData = ImportDatabase.GetCountryData(Country[0].ToString());
				int Cntr = 0;
				foreach (object[] item in CountryData)
				{
					string Template = string.Format("{0}\t(.*?)\t{1}\t{2}", item[2].ToString().ToUpper(), item[10].ToString().Replace(";", "").Replace(")", "")
						.Replace("(", ""), item[4].ToString().Replace(";", "").Replace(")", "")
						.Replace("(", ""));
					List<string[]> ZipData = HTTPScraper.ParseHTML(ZipCodesData, Template);
					if (ZipData.Count > 0)
					{
						foreach (string[] zData in ZipData)
						{
							Requests.Add(string.Format("INSERT INTO zip_codes VALUES ('{0}', '{1}')", item[7], zData[1]));
							if (Requests.Count >= 100)
							{
								ImportDatabase.SaveData(ref Requests);
							}
						}
					}
					Cntr++;
					Console.WriteLine(string.Format("{0}/{1}... ({2:n2}%) - {3} {4}/{5}", new object[]
					{
						Cntr,
						CountryData.Count,
						100f * (float)Cntr / (float)CountryData.Count,
						Country[1],
						CountryCounter,
						Countries.Count
					}));
				}
				ImportDatabase.SaveData(ref Requests);
				Console.WriteLine(string.Format("Done for {0}!", Country[1]));
			}
			Console.WriteLine("Absolutely all done!");
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007080 File Offset: 0x00005280
		public static List<object[]> GetCountryData(string Id)
		{
			return LocationEditForm.AppDatabase.Select(string.Format("SELECT * FROM `country` AS t1 RIGHT JOIN `region` AS t2 ON t2.country_id=t1.Id RIGHT JOIN `city` AS t3 ON t3.region_id=t2.Id WHERE t1.Id={0}", Id));
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007098 File Offset: 0x00005298
		public static void SaveData(ref List<string> Requests)
		{
			string request = "";
			foreach (string rqst in Requests)
			{
				request += string.Format("{0};{1}", rqst, Environment.NewLine);
			}
			if (LocationEditForm.AppDatabase.Connection.State != ConnectionState.Open)
			{
				LocationEditForm.AppDatabase.Connection.Open();
			}
			MySqlCommand cmd = new MySqlCommand(request, LocationEditForm.AppDatabase.Connection);
			cmd.CommandTimeout = 600;
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				File.AppendAllText(ImportDatabase.LogFileName, string.Format("{0}{1}{2}{1}", ex.Message, Environment.NewLine, request));
			}
			Requests.Clear();
		}

		// Token: 0x0400004C RID: 76
		private static string LogFileName = "post-codes.log";
	}
}
