using System;
using System.Collections.Generic;
using System.Threading;

namespace MASAGooGLExtractor
{
	// Token: 0x02000024 RID: 36
	public static class WebMiner
	{
		// Token: 0x0600012D RID: 301 RVA: 0x00013C74 File Offset: 0x00011E74
		public static string GetWeb(string Url, string[] ContactPageUrls)
		{
			if (string.IsNullOrWhiteSpace(Url))
			{
				return "";
			}
			string result = "";
			bool completed = false;
			Exception error = null;
			string text;
			try
			{
				ManualResetEvent resetEvent = new ManualResetEvent(false);
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					try
					{
						result = WebMiner.GetWebInternal(Url);
						completed = true;
					}
					catch (Exception ex)
					{
						error = ex;
					}
					finally
					{
						resetEvent.Set();
					}
				});
				if ((resetEvent.WaitOne(3000) & completed) && error == null)
				{
					text = result;
				}
				else
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00013D24 File Offset: 0x00011F24
		public static string SearchWebOnStartpage(string businessName, string city, string postalCode)
		{
			if (string.IsNullOrWhiteSpace(businessName))
			{
				return "";
			}
			string result = "";
			bool completed = false;
			string text;
			try
			{
				ManualResetEvent resetEvent = new ManualResetEvent(false);
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					try
					{
						result = WebMiner.SearchWebOnStartpageInternal(businessName, city, postalCode);
						completed = true;
					}
					catch
					{
					}
					finally
					{
						resetEvent.Set();
					}
				});
				if (resetEvent.WaitOne(3000) & completed)
				{
					text = result;
				}
				else
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00013DD4 File Offset: 0x00011FD4
		private static string SearchWebOnStartpageInternal(string businessName, string city, string postalCode)
		{
			try
			{
				string query = businessName;
				if (!string.IsNullOrWhiteSpace(city))
				{
					query = query + " " + city;
				}
				if (!string.IsNullOrWhiteSpace(postalCode))
				{
					query = query + " " + postalCode;
				}
				string encodedQuery = Uri.EscapeDataString(query);
				string page = HTTPScraper.GetPage("https://www.startpage.com/do/dsearch?qsr=it&query=" + encodedQuery, null, 3000);
				if (string.IsNullOrEmpty(page))
				{
					return "";
				}
				List<string[]> results = HTTPScraper.ParseHTML(page, "<div class=\"result(.*?)\">(.*?)</div>");
				if (results.Count > 0)
				{
					List<string[]> links = HTTPScraper.ParseHTML(results[0][2], "<a href=\"(.*?)\"");
					if (links.Count > 0)
					{
						string url = links[0][1];
						if (url.Contains("http"))
						{
							try
							{
								Uri uri = new Uri(url);
								return uri.Scheme + "://" + uri.Host;
							}
							catch
							{
								return url;
							}
						}
					}
				}
				List<string[]> altResults = HTTPScraper.ParseHTML(page, "class=\"result\"(.*?)</div>");
				if (altResults.Count > 0)
				{
					List<string[]> links2 = HTTPScraper.ParseHTML(altResults[0][1], "href=\"(https?://[^\"]+)\"");
					if (links2.Count > 0)
					{
						string url2 = links2[0][1];
						try
						{
							Uri uri2 = new Uri(url2);
							return uri2.Scheme + "://" + uri2.Host;
						}
						catch
						{
							return url2;
						}
					}
				}
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00013F84 File Offset: 0x00012184
		private static string GetWebInternal(string Url)
		{
			string Web = "";
			try
			{
				Url = Url.Replace("https:", "http:");
				string Page = HTTPScraper.GetPage(Url, null, 3000);
				if (string.IsNullOrEmpty(Page))
				{
					return "";
				}
				string ClearPage = HTTPScraper.ClearString(Page);
				List<string[]> ItemsA = HTTPScraper.ParseHTML(ClearPage, "\"(?i:WWW)\"(.*?)href=\"(.*?)\" (.*?)scheda_azienda__cta_sitoweb\"");
				if (ItemsA.Count > 0)
				{
					Web = ItemsA[0][2].Replace(" ", "");
					return Web;
				}
				List<string[]> ItemsB = HTTPScraper.ParseHTML(ClearPage, "data-pag=\"multilink(.*?)\"");
				if (ItemsB.Count > 0)
				{
					Web = ItemsB[0][1].Replace("/http", "http");
					return Web;
				}
				List<string[]> ItemsC = HTTPScraper.ParseHTML(ClearPage, "sito web(.*?)href=\"(.*?)\"");
				if (ItemsC.Count > 0)
				{
					Web = ItemsC[0][1].Replace("/http", "http");
				}
			}
			catch
			{
			}
			return Web;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00014084 File Offset: 0x00012284
		private static string FindCorrectWeb(List<string[]> Items)
		{
			try
			{
				foreach (string[] web in Items)
				{
					if (!string.IsNullOrEmpty(web[0]))
					{
						string webLower = web[0].ToLower();
						if (!webLower.Contains("+100060602430") && !webLower.Contains("@mail.com") && !webLower.Contains("example") && !webLower.Contains(".png"))
						{
							return web[0].Replace(" ", "");
						}
					}
				}
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x04000163 RID: 355
		private const int TIMEOUT_MS = 3000;
	}
}
