using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MASAGooGLExtractor;
using Newtonsoft.Json.Linq;

namespace MASAGooGLExtractor
{
	// Token: 0x0200001C RID: 28
	public class BingMapsScraper
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x0000E7D8 File Offset: 0x0000C9D8
		public BingMapsScraper(int TaskIndex, MainForm MainForm, bool EmailMining = false)
		{
			this._MainForm = MainForm;
			this._TaskIndex = TaskIndex;
			this._TaskId = MainForm.dgvTasks.Rows[TaskIndex].Cells[0].Value.ToString();
			Thread.Sleep(500);
			this._q = this.BuildSearchRequest(MainForm.dgvTasks.Rows[TaskIndex]);
			this._Category = MainForm.dgvTasks.Rows[TaskIndex].Cells[1].Value.ToString();
			this._State = MainForm.dgvTasks.Rows[TaskIndex].Cells[4].Value.ToString();
			if (Program.AppSettings.IsRandomDelay)
			{
				this.UpdateUIThreadSafe(string.Format("Bing Maps | Random Delay. Working on task {0}. Searching...", this._TaskId), 0);
			}
			else
			{
				this.UpdateUIThreadSafe(string.Format("Bing Maps | Working on task {0}. Searching...", this._TaskId), 0);
			}
			int Iterations = 0;
			bool gotResults = false;
			for (;;)
			{
				string ResponseData = this.GetLinksData(this._q);
				if (Program.StopDataCollection)
				{
					break;
				}
				if (!string.IsNullOrEmpty(ResponseData) && this.ParseBingResults(ResponseData, EmailMining) > 0)
				{
					gotResults = true;
				}
				if (!gotResults)
				{
					Iterations++;
					if (Iterations >= 3)
					{
						goto IL_01C4;
					}
					string[] q_parts = this._q.Split(new char[] { '+' });
					this._q = "";
					for (int i = 0; i < q_parts.Length - 1; i++)
					{
						this._q = this._q + q_parts[i] + "+";
					}
					if (this._q.Length > 1)
					{
						this._q = this._q.Substring(0, this._q.Length - 1);
					}
				}
				if (gotResults || Program.StopDataCollection)
				{
					goto IL_01C4;
				}
			}
			return;
			IL_01C4:
			if (Program.AppSettings.IsRandomDelay)
			{
				Program.RequestDelay();
				return;
			}
			Thread.Sleep(750);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
		private void UpdateUIThreadSafe(string text, int progress)
		{
			if (this._MainForm == null || this._MainForm.IsDisposed || !this._MainForm.IsHandleCreated)
			{
				return;
			}
			if (this._MainForm.InvokeRequired)
			{
				this._MainForm.BeginInvoke(new BingMapsScraper.UpdateUIDelegate(this.UpdateUIThreadSafe), new object[] { text, progress });
				return;
			}
			if (!string.IsNullOrEmpty(text))
			{
				this._MainForm.lblInfo.Text = text;
			}
			if (progress >= 0 && progress <= 100)
			{
				this._MainForm.tspProgress.Value = progress;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000EA64 File Offset: 0x0000CC64
		private int ParseBingResults(string html, bool emailMining)
		{
			if (string.IsNullOrEmpty(html))
			{
				return 0;
			}
			int totalExtracted = 0;
			MatchCollection matches = Regex.Matches(html, "data-entity=\\\"(\\{.*?\\})\\\"", RegexOptions.Singleline);
			int totalMatches = matches.Count;
			if (totalMatches == 0)
			{
				return 0;
			}
			int updateInterval = Math.Max(1, totalMatches / 20);
			int nextUpdateAt = updateInterval;
			foreach (object obj in matches)
			{
				Match i = (Match)obj;
				Thread.Sleep(50);
				if (Program.StopDataCollection)
				{
					break;
				}
				if (i.Success)
				{
					string encodedJson = i.Groups[1].Value;
					if (!string.IsNullOrEmpty(encodedJson))
					{
						string json = WebUtility.HtmlDecode(encodedJson);
						try
						{
							JObject root = JObject.Parse(json);
							JObject entity = root["entity"] as JObject;
							if (entity != null)
							{
								GeoData dataItem = new GeoData();
								dataItem.Category = this._Category;
								dataItem.RealCategory = ((string)entity["primaryCategoryName"]) ?? this._Category;
								dataItem.BusinessName = ((string)entity["title"]) ?? "";
								dataItem.Address = ((string)entity["address"]) ?? "";
								dataItem.City = "";
								dataItem.PostalCode = "";
								if (!string.IsNullOrEmpty(dataItem.Address))
								{
									List<string[]> StrParse = HTTPScraper.ParseHTML(dataItem.Address, "(\\d{5,6}) ([^,]+),");
									if (StrParse.Count > 0)
									{
										dataItem.PostalCode = StrParse[0][1];
										dataItem.City = StrParse[0][2];
									}
									else
									{
										StrParse = HTTPScraper.ParseHTML(dataItem.Address, "(\\d{5,6}) (.*)");
										if (StrParse.Count > 0)
										{
											dataItem.PostalCode = StrParse[0][1];
											dataItem.City = WebUtility.HtmlDecode(StrParse[0][2]);
										}
										else
										{
											StrParse = HTTPScraper.ParseHTML(dataItem.Address, ", ([^\\d]+)\\s(\\d{5,6}), (.*)");
											if (StrParse.Count > 0)
											{
												dataItem.City = StrParse[0][1];
												dataItem.PostalCode = StrParse[0][2];
											}
											else
											{
												StrParse = HTTPScraper.ParseHTML(dataItem.Address, ", (.*), (.*) (\\d{5,6})");
												if (StrParse.Count > 0)
												{
													dataItem.City = StrParse[0][1];
													dataItem.PostalCode = StrParse[0][3];
												}
											}
										}
									}
								}
								dataItem.State = this._State;
								dataItem.Phone = ((string)entity["phone"]) ?? "";
								string website = ((string)entity["website"]) ?? "";
								if (!string.IsNullOrEmpty(website))
								{
									website = website.Trim();
									if (!website.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
									{
										website = "http://" + website;
									}
								}
								dataItem.Website = website;
								string lat = "";
								string lon = "";
								JObject routable = root["routablePoint"] as JObject;
								JObject geometry = root["geometry"] as JObject;
								if (routable != null)
								{
									lat = BingMapsScraper.ConvertToString(routable["latitude"] ?? routable["y"]);
									lon = BingMapsScraper.ConvertToString(routable["longitude"] ?? routable["x"]);
								}
								else if (geometry != null)
								{
									lat = BingMapsScraper.ConvertToString(geometry["y"] ?? geometry["latitude"]);
									lon = BingMapsScraper.ConvertToString(geometry["x"] ?? geometry["longitude"]);
								}
								dataItem.Latitude = lat;
								dataItem.Longitude = lon;
								dataItem.MapLink = this.BuildBingMapLink(lat, lon, dataItem.BusinessName, dataItem.Address);
								dataItem.DetailsLink = "";
								string infoboxHtmlEncoded = (string)entity["infoboxHtml"];
								if (!string.IsNullOrEmpty(infoboxHtmlEncoded))
								{
									string infoboxHtml = WebUtility.HtmlDecode(infoboxHtmlEncoded);
									string rating = "";
									Match ratingMatch = Regex.Match(infoboxHtml, "aria-label=\"[^\"]*?([0-9]+(?:[.,][0-9]+)?)\\s*(?:su|out of|sur|de|von)\\s*5", RegexOptions.IgnoreCase);
									if (!ratingMatch.Success)
									{
										ratingMatch = Regex.Match(infoboxHtml, "([0-9]+(?:[.,][0-9]+)?)\\s*/\\s*5", RegexOptions.IgnoreCase);
									}
									if (ratingMatch.Success)
									{
										rating = ratingMatch.Groups[1].Value.Replace(',', '.');
									}
									if (!string.IsNullOrEmpty(rating))
									{
										dataItem.DetailsLink = rating + " avg rating";
									}
								}
								dataItem.Email = "";
								if (emailMining && Program.AppSettings.ExtractEmails)
								{
									try
									{
										string[] contactPages = new string[] { "conta" };
										string websiteToUse = dataItem.Website;
										bool noWebsite = string.IsNullOrWhiteSpace(websiteToUse);
										bool isFacebook = !noWebsite && websiteToUse.IndexOf("facebook.com", StringComparison.InvariantCultureIgnoreCase) >= 0;
										if (noWebsite || isFacebook)
										{
											try
											{
												string externalWebsite = WebMiner.SearchWebOnStartpage(dataItem.BusinessName, dataItem.City, dataItem.PostalCode);
												if (!string.IsNullOrWhiteSpace(externalWebsite))
												{
													websiteToUse = externalWebsite;
													if (noWebsite)
													{
														dataItem.Website = externalWebsite;
													}
												}
											}
											catch
											{
											}
										}
										if (!string.IsNullOrWhiteSpace(websiteToUse))
										{
											dataItem.Email = EmailMiner.GetEmail(websiteToUse, contactPages, 3000);
										}
										BingMapsScraper.WriteToFile(new string[]
									{
										dataItem.Category, dataItem.RealCategory, dataItem.BusinessName, dataItem.Address, dataItem.City, dataItem.PostalCode, dataItem.State, dataItem.Phone, dataItem.Website, dataItem.Email,
										dataItem.DetailsLink
									});
									}
									catch
									{
									}
								}
								this.OutputData(dataItem);
								totalExtracted++;
								if (totalExtracted >= nextUpdateAt || totalExtracted == totalMatches)
								{
									string infoText = (Program.AppSettings.IsRandomDelay ? string.Format("Bing Maps | Random Delay. Task {0}. Extracted {1} results.", this._TaskId, totalExtracted) : string.Format("Bing Maps | Task {0}. Extracted {1} results.", this._TaskId, totalExtracted));
									int progress = (int)Math.Round(100.0 * (double)totalExtracted / (double)totalMatches);
									if (progress < 0)
									{
										progress = 0;
									}
									if (progress > 100)
									{
										progress = 100;
									}
									this.UpdateUIThreadSafe(infoText, progress);
									nextUpdateAt += updateInterval;
								}
							}
						}
						catch (Exception ex)
						{
							BingMapsScraper.Log("Error parsing Bing data-entity: " + ex.Message);
						}
					}
				}
			}
			return totalExtracted;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000F170 File Offset: 0x0000D370
		private static string ConvertToString(JToken token)
		{
			if (token == null)
			{
				return "";
			}
			if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
			{
				return token.Value<double>().ToString(CultureInfo.InvariantCulture);
			}
			return token.ToString();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000F1B4 File Offset: 0x0000D3B4
		private string BuildBingMapLink(string latitude, string longitude, string title, string address)
		{
			if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
			{
				return "";
			}
			string cp = string.Format(CultureInfo.InvariantCulture, "{0}~{1}", latitude, longitude);
			string q = Uri.EscapeDataString((title + " ").Trim());
			return "https://www.bing.com/maps?cp=" + cp + "&q=" + q;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000F210 File Offset: 0x0000D410
		private string GetLinksData(string Request)
		{
			PhantomJSBing phantomJS = new PhantomJSBing(Request);
			int Iter = 0;
			while (!phantomJS.Completed && !Program.StopDataCollection)
			{
				Iter++;
				int v = (int)Math.Round((double)(100f * (float)Iter / 75f));
				if (v < 100)
				{
					this.UpdateUIThreadSafe(null, v);
				}
				Thread.Sleep(100);
			}
			if (Program.StopDataCollection)
			{
				return "";
			}
			return phantomJS.Response;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F278 File Offset: 0x0000D478
		private void OutputData(GeoData DataItem)
		{
			object[] row = new object[]
			{
				DataItem.Category,
				DataItem.RealCategory,
				DataItem.BusinessName,
				DataItem.Address,
				DataItem.City,
				DataItem.State,
				DataItem.PostalCode,
				this._MainForm.dgvTasks.Rows[this._TaskIndex].Cells[3].Value.ToString(),
				DataItem.Phone,
				DataItem.Email,
				DataItem.Website,
				DataItem.Latitude,
				DataItem.Longitude,
				DataItem.MapLink,
				DataItem.DetailsLink
			};
			try
			{
				if (this._MainForm != null && !this._MainForm.IsDisposed && this._MainForm.IsHandleCreated)
				{
					if (this._MainForm.dgvResults.InvokeRequired)
					{
						this._MainForm.dgvResults.BeginInvoke(new MethodInvoker(delegate
						{
							try
							{
								if (!this._MainForm.IsDisposed)
								{
									this._MainForm.dgvResults.Rows.Add(row);
								}
							}
							catch
							{
							}
						}));
					}
					else
					{
						this._MainForm.dgvResults.Rows.Add(row);
					}
				}
			}
			catch
			{
			}
			try
			{
				Application.DoEvents();
			}
			catch
			{
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F428 File Offset: 0x0000D628
		private bool IsInList(List<string> Urls, string Url)
		{
			using (List<string>.Enumerator enumerator = Urls.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == Url)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F480 File Offset: 0x0000D680
		public static void WriteToFile(string s)
		{
			string path = Program.ExportFile;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read))
					{
						using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
						{
							sw.WriteLine(s);
							break;
						}
					}
				}
				catch
				{
					Thread.Sleep(30);
				}
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000F508 File Offset: 0x0000D708
		public static void WriteToFile(string[] fields)
		{
			string path = Program.ExportFile;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read))
					{
						using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true)))
						{
							string line = string.Join(";", fields.Select<string, string>(new Func<string, string>(BingMapsScraper.ToCsvField)));
							sw.WriteLine(line);
							break;
						}
					}
				}
				catch
				{
					Thread.Sleep(30);
				}
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
		private static string ToCsvField(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return "";
			}
			bool flag = value.Contains(';') || value.Contains('"') || value.Contains('\r') || value.Contains('\n');
			string escaped = value.Replace("\"", "\"\"");
			if (!flag)
			{
				return escaped;
			}
			return "\"" + escaped + "\"";
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F61C File Offset: 0x0000D81C
		private string BuildSearchRequest(DataGridViewRow Row)
		{
			string q = Uri.EscapeDataString(Row.Cells[1].Value.ToString()) + " in ";
			string Loc = "";
			for (int i = 6; i >= 3; i--)
			{
				if (Row.Cells[i].Value != null && Row.Cells[i].Value.ToString().IndexOf("All") == -1)
				{
					Loc += string.Format("+{0}", Uri.EscapeDataString(Row.Cells[i].Value.ToString()));
				}
			}
			if (Loc == "")
			{
				Loc = "+" + Uri.EscapeDataString(Row.Cells[2].Value.ToString());
			}
			return q + Loc;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000F700 File Offset: 0x0000D900
		private static void Log(string Msg)
		{
			try
			{
				File.AppendAllText(Path.Combine(Path.GetTempPath(), "BingMapsScraper.log"), string.Format("{0}: {1}{2}", DateTime.Now, Msg, Environment.NewLine));
			}
			catch
			{
			}
		}

		// Token: 0x040000D3 RID: 211
		private int _TaskIndex;

		// Token: 0x040000D4 RID: 212
		private string _TaskId;

		// Token: 0x040000D5 RID: 213
		private string _Category;

		// Token: 0x040000D6 RID: 214
		private string _State;

		// Token: 0x040000D7 RID: 215
		private string _q;

		// Token: 0x040000D8 RID: 216
		private MainForm _MainForm;

		// Token: 0x040000D9 RID: 217
		public static Random Rnd1;

		// Token: 0x040000DA RID: 218
		private List<string> PageUrls;

		// Token: 0x0200004B RID: 75
		// (Invoke) Token: 0x06000179 RID: 377
		private delegate void UpdateUIDelegate(string text, int progress);
	}
}
