using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EO.WebEngine;

namespace MASAGooGLExtractor
{
	// Token: 0x02000012 RID: 18
	public class GoogleMapsScraper
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000045C0 File Offset: 0x000027C0
		public static List<string[]> ParseMapsPlaceUrlsFast(string html)
		{
			List<string[]> results = new List<string[]>();
			if (string.IsNullOrEmpty(html))
			{
				return results;
			}
			int index = 0;
			for (;;)
			{
				int start = html.IndexOf("https://www.google.com/maps/place/", index, StringComparison.Ordinal);
				if (start == -1)
				{
					break;
				}
				int end = html.IndexOf('"', start);
				if (end == -1)
				{
					break;
				}
				string fullUrl = html.Substring(start, end - start);
				string placePart = fullUrl.Substring("https://www.google.com/maps/place/".Length);
				results.Add(new string[] { fullUrl, placePart });
				index = end + 1;
			}
			return results;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000463C File Offset: 0x0000283C
		public GoogleMapsScraper(int TaskIndex, MainForm MainForm, bool EmailMining = false)
		{
			this._TaskIndex = TaskIndex;
			this._TaskId = MainForm.dgvTasks.Rows[TaskIndex].Cells[0].Value.ToString();
			if (this._TaskId == "15" || this._TaskId == "30" || this._TaskId == "70" || this._TaskId == "95" || this._TaskId == "120" || this._TaskId == "140" || this._TaskId == "170" || this._TaskId == "200" || this._TaskId == "230" || this._TaskId == "260" || this._TaskId == "290" || this._TaskId == "320" || this._TaskId == "350" || this._TaskId == "380" || this._TaskId == "410" || this._TaskId == "440" || this._TaskId == "470" || this._TaskId == "500" || this._TaskId == "530" || this._TaskId == "560" || this._TaskId == "590" || this._TaskId == "620" || this._TaskId == "650" || this._TaskId == "680" || this._TaskId == "710" || this._TaskId == "750" || this._TaskId == "800" || this._TaskId == "830" || this._TaskId == "880" || this._TaskId == "920" || this._TaskId == "950" || this._TaskId == "980")
			{
				try
				{
					MainForm.lblInfo.Text = string.Format("Automatic Pause of 60 seconds on task {0}... Please WAIT......", this._TaskId);
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
				Thread.Sleep(60000);
			}
			if (this._TaskId == "50" || this._TaskId == "80" || this._TaskId == "105" || this._TaskId == "155" || this._TaskId == "185" || this._TaskId == "215" || this._TaskId == "245" || this._TaskId == "275" || this._TaskId == "305" || this._TaskId == "335" || this._TaskId == "370" || this._TaskId == "400" || this._TaskId == "455" || this._TaskId == "485" || this._TaskId == "515" || this._TaskId == "545" || this._TaskId == "575" || this._TaskId == "600" || this._TaskId == "635" || this._TaskId == "735" || this._TaskId == "775" || this._TaskId == "815" || this._TaskId == "895" || this._TaskId == "935" || this._TaskId == "965" || this._TaskId == "1000" || this._TaskId == "1050" || this._TaskId == "1100" || this._TaskId == "1140" || this._TaskId == "1170" || this._TaskId == "1200" || this._TaskId == "1250")
			{
				try
				{
					MainForm.lblInfo.Text = string.Format("Automatic Pause of 25 seconds on task {0}... Please WAIT......", this._TaskId);
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
				Thread.Sleep(25000);
			}
			try
			{
				if (Interlocked.Increment(ref GoogleMapsScraper.s_EOCleanupTick) % 2 == 0)
				{
					ThreadPool.QueueUserWorkItem(delegate(object _)
					{
						try
						{
							Engine.CleanUpCacheFolders(null, CacheFolderCleanUpPolicy.AllVersions);
						}
						catch
						{
						}
					});
				}
			}
			catch
			{
			}
			this._q = this.BuildSearchRequest(MainForm.dgvTasks.Rows[TaskIndex]);
			this._Category = MainForm.dgvTasks.Rows[TaskIndex].Cells[1].Value.ToString();
			this._State = MainForm.dgvTasks.Rows[TaskIndex].Cells[4].Value.ToString();
			this._MainForm = MainForm;
			try
			{
				if (Program.AppSettings.IsRandomDelay)
				{
					MainForm.lblInfo.Text = string.Format("Random Delay Enabled... Working on task {0}... Searching for links...", this._TaskId);
				}
				else
				{
					MainForm.lblInfo.Text = string.Format("Working on task {0}... Searching for links...", this._TaskId);
				}
				Application.DoEvents();
			}
			catch
			{
			}
			List<string> DataUrls = new List<string>();
			this.PageUrls = new List<string>();
			int Iterations = 0;
			do
			{
				string ResponseData = this.GetLinksData(this._q);
				int Pos = ResponseData.IndexOf("google");
				try
				{
					if (Pos > -1)
					{
						ResponseData.Substring(0, Pos);
						List<string[]> list = GoogleMapsScraper.ParseMapsPlaceUrlsFast(ResponseData);
						int processedBlocks = 0;
						foreach (string[] array in list)
						{
							processedBlocks++;
							string PageUrl = array[0];
							PageUrl = PageUrl.Replace("\\/", "/");
							int idx = PageUrl.IndexOf("\\\"");
							if (idx > -1)
							{
								PageUrl = PageUrl.Substring(0, idx);
							}
							if (!this.IsInList(this.PageUrls, PageUrl))
							{
								this.PageUrls.Add(PageUrl);
								try
								{
									this._MainForm.lblInfo.Text = string.Format("Working on task {0}... Extracting results {1}/{2}", this._TaskId, this.PageUrls.Count, Program.AppSettings.NumberOfResultsPerZipCode);
									Application.DoEvents();
								}
								catch
								{
								}
								if (this.PageUrls.Count >= Program.AppSettings.NumberOfResultsPerZipCode)
								{
									break;
								}
							}
							if (Program.StopDataCollection)
							{
								break;
							}
						}
						if (this.PageUrls.Count >= Program.AppSettings.NumberOfResultsPerZipCode)
						{
							break;
						}
						try
						{
							this._MainForm.lblInfo.Text = string.Format("Working on task {0}... Extracting results ({1} found)", this._TaskId, this.PageUrls.Count);
							Application.DoEvents();
						}
						catch
						{
						}
						if (Program.StopDataCollection)
						{
							break;
						}
					}
				}
				catch
				{
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
				if (DataUrls.Count == 0)
				{
					Iterations++;
					if (Iterations >= 1)
					{
						break;
					}
				}
			}
			while (DataUrls.Count == 0 && !Program.StopDataCollection);
			if (Program.AppSettings.IsRandomDelay)
			{
				Program.RequestDelay();
			}
			else
			{
				Thread.Sleep(350);
			}
			if (Program.StopDataCollection)
			{
				return;
			}
			int PoolSize = Program.AppSettings.numthreads;
			int PageIndex = 0;
			GooglePageScraper[] Pool = new GooglePageScraper[PoolSize];
			int j = 0;
			while (j < PoolSize && PageIndex < this.PageUrls.Count)
			{
				try
				{
					Pool[j] = new GooglePageScraper(this.PageUrls[PageIndex], this._Category, this._State, EmailMining);
				}
				catch
				{
					Pool[j] = null;
				}
				Thread.Sleep(300);
				PageIndex++;
				j++;
			}
			int Completed = 0;
			int completedSinceLastGC = 0;
			bool anyProgress = false;
			Stopwatch swUi = Stopwatch.StartNew();
			Stopwatch swMem = Stopwatch.StartNew();
			Stopwatch swGc = Stopwatch.StartNew();
			try
			{
				while (Completed < PoolSize && !Program.StopDataCollection)
				{
					Completed = 0;
					anyProgress = false;
					for (int k = 0; k < PoolSize; k++)
					{
						GooglePageScraper worker = Pool[k];
						if (worker != null && worker.Done)
						{
							anyProgress = true;
							if (worker.DataItem != null && worker.DataItem.BusinessName != null)
							{
								try
								{
									this.OutputData(worker.DataItem);
								}
								catch
								{
								}
							}
							try
							{
								worker.Dispose();
							}
							catch
							{
							}
							Pool[k] = null;
							completedSinceLastGC++;
							if (!Program.StopDataCollection && PageIndex < this.PageUrls.Count)
							{
								try
								{
									Pool[k] = new GooglePageScraper(this.PageUrls[PageIndex], this._Category, this._State, EmailMining);
								}
								catch
								{
									Pool[k] = null;
								}
								PageIndex++;
							}
						}
						if (Pool[k] == null)
						{
							Completed++;
						}
					}
					if (swUi.ElapsedMilliseconds >= 300L)
					{
						if (this._MainForm == null || this._MainForm.IsDisposed)
						{
							break;
						}
						if (!this._MainForm.IsHandleCreated)
						{
							break;
						}
						try
						{
							int inProgress = 0;
							for (int l = 0; l < PoolSize; l++)
							{
								if (Pool[l] != null)
								{
									inProgress++;
								}
							}
							int pagesDone = Math.Min(PageIndex, this.PageUrls.Count) - inProgress;
							string msg = (Program.AppSettings.IsRandomDelay ? string.Format("Random Delay enabled...Working on task {0}... Extracting...{1} of {2} | ({3:n2}%)...", new object[]
							{
								this._TaskId,
								pagesDone,
								this.PageUrls.Count,
								(this.PageUrls.Count == 0) ? 0f : (100f * (float)pagesDone / (float)this.PageUrls.Count)
							}) : string.Format("Working on task {0}... Extracting Results...{1} of {2} | ({3:n2}%)...", new object[]
							{
								this._TaskId,
								pagesDone,
								this.PageUrls.Count,
								(this.PageUrls.Count == 0) ? 0f : (100f * (float)pagesDone / (float)this.PageUrls.Count)
							}));
							if (this._MainForm != null && !this._MainForm.IsDisposed && this._MainForm.IsHandleCreated)
							{
								this._MainForm.lblInfo.Text = msg;
								int v = ((this.PageUrls.Count == 0) ? 0 : ((int)Math.Round((double)(100f * (float)pagesDone / (float)this.PageUrls.Count))));
								if (v >= 0 && v <= 100)
								{
									this._MainForm.tspProgress.Value = v;
								}
								Application.DoEvents();
							}
						}
						catch
						{
						}
						swUi.Restart();
					}
					if (completedSinceLastGC >= 80 || swGc.ElapsedMilliseconds >= 60000L)
					{
						try
						{
							GC.Collect(0, GCCollectionMode.Forced, false, false);
						}
						catch
						{
						}
						completedSinceLastGC = 0;
						swGc.Restart();
					}
					if (swMem.ElapsedMilliseconds >= 1000L)
					{
						try
						{
							long priv = Process.GetCurrentProcess().PrivateMemorySize64;
							if (priv > 1000000000L)
							{
								try
								{
									GC.Collect(1, GCCollectionMode.Forced, false, false);
								}
								catch
								{
								}
								if (priv > 1300000000L)
								{
									try
									{
										GC.Collect(2, GCCollectionMode.Forced, true, false);
									}
									catch
									{
									}
									Thread.Sleep(80);
								}
							}
						}
						catch
						{
						}
						swMem.Restart();
					}
					if (!anyProgress)
					{
						Thread.Sleep(10);
					}
				}
			}
			finally
			{
				for (int m = 0; m < PoolSize; m++)
				{
					try
					{
						GooglePageScraper googlePageScraper = Pool[m];
						if (googlePageScraper != null)
						{
							googlePageScraper.Dispose();
						}
					}
					catch
					{
					}
					Pool[m] = null;
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000558C File Offset: 0x0000378C
		private List<string> GetLinks(string Request)
		{
			PhantomJS PhantomJS = new PhantomJS(Request);
			int Iter = 0;
			while (!PhantomJS.Completed && !Program.StopDataCollection)
			{
				Iter++;
				int v = (int)Math.Round((double)(100f * (float)Iter / 75f));
				if (v < 100)
				{
					try
					{
						this._MainForm.tspProgress.Value = v;
					}
					catch
					{
					}
				}
				try
				{
					Application.DoEvents();
				}
				catch
				{
				}
				Thread.Sleep(300);
			}
			List<string> DataUrls = new List<string>();
			if (Program.StopDataCollection)
			{
				return DataUrls;
			}
			string[] _DataUrls = PhantomJS.Response.Split(new char[] { '\r' });
			for (int i = 0; i < _DataUrls.Length; i++)
			{
				DataUrls.Add(_DataUrls[i].Replace("\n", ""));
			}
			return DataUrls;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005670 File Offset: 0x00003870
		private string GetLinksData(string Request)
		{
			int timeoutSeconds = 30;
			DateTime startTime = DateTime.Now;
			PhantomJS PhantomJS = new PhantomJS(Request);
			int Iter = 0;
			while (!PhantomJS.Completed && !Program.StopDataCollection)
			{
				double elapsedSec = (DateTime.Now - startTime).TotalSeconds;
				if (elapsedSec > 45.0)
				{
					this._MainForm.tspProgress.Value = 0;
					Application.DoEvents();
					PhantomJS.Cancel();
					return "[HARD_TIMEOUT]";
				}
				if (elapsedSec > (double)timeoutSeconds)
				{
					this._MainForm.tspProgress.Value = 0;
					Application.DoEvents();
					try
					{
						PhantomJS.Completed = true;
					}
					catch
					{
					}
					PhantomJS.Cancel();
					return "[TIMEOUT]";
				}
				Iter++;
				int v = (int)Math.Round((double)(100f * (float)Iter / 75f));
				if (v < 100)
				{
					this._MainForm.tspProgress.Value = v;
				}
				Application.DoEvents();
				Thread.Sleep(100);
			}
			Application.DoEvents();
			if (Program.StopDataCollection)
			{
				return "";
			}
			return PhantomJS.Response ?? "";
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005790 File Offset: 0x00003990
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

		// Token: 0x0600005C RID: 92 RVA: 0x00005940 File Offset: 0x00003B40
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

		// Token: 0x0600005D RID: 93 RVA: 0x00005998 File Offset: 0x00003B98
		private static string SafeCellText(DataGridViewRow row, int col)
		{
			string text;
			try
			{
				if (row == null)
				{
					text = "";
				}
				else if (col < 0 || col >= row.Cells.Count)
				{
					text = "";
				}
				else
				{
					DataGridViewCell cell = row.Cells[col];
					if (cell == null)
					{
						text = "";
					}
					else
					{
						object v = cell.Value;
						text = ((v == null) ? "" : v.ToString());
					}
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005A18 File Offset: 0x00003C18
		private static string UrlPart(string s)
		{
			if (!string.IsNullOrWhiteSpace(s))
			{
				return Uri.EscapeDataString(s.Trim());
			}
			return "";
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005A34 File Offset: 0x00003C34
		private string BuildSearchRequest(DataGridViewRow Row)
		{
			string q = GoogleMapsScraper.UrlPart(GoogleMapsScraper.SafeCellText(Row, 1)) + ",";
			StringBuilder loc = new StringBuilder();
			for (int i = 6; i >= 3; i--)
			{
				string part = GoogleMapsScraper.SafeCellText(Row, i);
				if (!string.IsNullOrWhiteSpace(part) && part.IndexOf("All", StringComparison.OrdinalIgnoreCase) < 0)
				{
					string enc = GoogleMapsScraper.UrlPart(part);
					if (enc.Length != 0)
					{
						loc.Append("+").Append(enc);
					}
				}
			}
			if (loc.Length == 0)
			{
				string fallbackCity = GoogleMapsScraper.UrlPart(GoogleMapsScraper.SafeCellText(Row, 2));
				if (!string.IsNullOrEmpty(fallbackCity))
				{
					loc.Append("+").Append(fallbackCity);
				}
			}
			return q + loc.ToString();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005AEC File Offset: 0x00003CEC
		private static void Log(string Msg)
		{
			try
			{
				File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt"), string.Format("{0}: {1}{2}", DateTime.Now, Msg, Environment.NewLine));
			}
			catch
			{
			}
		}

		// Token: 0x04000036 RID: 54
		private int _TaskIndex;

		// Token: 0x04000037 RID: 55
		private string _TaskId;

		// Token: 0x04000038 RID: 56
		private string _Category;

		// Token: 0x04000039 RID: 57
		private string _State;

		// Token: 0x0400003A RID: 58
		private string _q;

		// Token: 0x0400003B RID: 59
		private MainForm _MainForm;

		// Token: 0x0400003C RID: 60
		public static Random Rnd1;

		// Token: 0x0400003D RID: 61
		private List<string> PageUrls;

		// Token: 0x0400003E RID: 62
		private static int s_EOCleanupTick;
	}
}
