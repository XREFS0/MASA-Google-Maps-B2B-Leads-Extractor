using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

// Token: 0x02000006 RID: 6
public static class HTTPScraper
{
	// Token: 0x06000018 RID: 24 RVA: 0x00002828 File Offset: 0x00000A28
	public static string GetPage(string Url, ProxyServer Proxy)
	{
		return HTTPScraper.GetPage(Url, Proxy, 7000);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002838 File Offset: 0x00000A38
	public static string GetPage(string Url, ProxyServer Proxy, int timeoutMs)
	{
		string result = "";
		Exception error = null;
		HttpWebRequest request = null;
		ManualResetEvent done = new ManualResetEvent(false);
		ThreadPool.QueueUserWorkItem(delegate(object _)
		{
			try
			{
				result = HTTPScraper.GetPageInner(Url, Proxy, timeoutMs, out request);
			}
			catch (Exception ex)
			{
				error = ex;
			}
			finally
			{
				done.Set();
			}
		});
		if (!done.WaitOne(timeoutMs))
		{
			try
			{
				HttpWebRequest request2 = request;
				if (request2 != null)
				{
					request2.Abort();
				}
			}
			catch
			{
			}
			return "";
		}
		if (error != null)
		{
			return "";
		}
		return result;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000028EC File Offset: 0x00000AEC
	private static string GetPageInner(string Url, ProxyServer Proxy, int timeoutMs, out HttpWebRequest myHttpWebRequest)
	{
		myHttpWebRequest = null;
		string text;
		try
		{
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.DefaultConnectionLimit = 7000;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36";
			myHttpWebRequest.KeepAlive = false;
			myHttpWebRequest.MaximumAutomaticRedirections = 15;
			myHttpWebRequest.AllowAutoRedirect = true;
			if (Proxy != null)
			{
				WebProxy myProxy = new WebProxy(string.Format("{0}:{1}", Proxy.IP, Proxy.Port), false);
				myHttpWebRequest.Proxy = myProxy;
			}
			myHttpWebRequest.Timeout = timeoutMs;
			myHttpWebRequest.ReadWriteTimeout = timeoutMs;
			using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
			{
				using (Stream dataStream = myHttpWebResponse.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(dataStream))
					{
						text = reader.ReadToEnd();
					}
				}
			}
		}
		catch (WebException)
		{
			text = "";
		}
		catch (Exception)
		{
			text = "";
		}
		return text;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002A20 File Offset: 0x00000C20
	public static string GetPage(string Url, string PostData, ProxyServer Proxy)
	{
		string text;
		try
		{
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.DefaultConnectionLimit = 7000;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36";
			myHttpWebRequest.KeepAlive = false;
			myHttpWebRequest.MaximumAutomaticRedirections = 15;
			myHttpWebRequest.AllowAutoRedirect = true;
			if (Proxy != null)
			{
				WebProxy myProxy = new WebProxy(string.Format("{0}:{1}", Proxy.IP, Proxy.Port), false);
				myHttpWebRequest.Proxy = myProxy;
			}
			myHttpWebRequest.Timeout = 7000;
			myHttpWebRequest.Method = "POST";
			byte[] byteArray = Encoding.UTF8.GetBytes(PostData);
			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
			myHttpWebRequest.ContentLength = (long)byteArray.Length;
			Stream requestStream = myHttpWebRequest.GetRequestStream();
			requestStream.Write(byteArray, 0, byteArray.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			string responseFromServer = streamReader.ReadToEnd();
			streamReader.Close();
			streamReader.Dispose();
			responseStream.Close();
			responseStream.Dispose();
			httpWebResponse.Close();
			text = responseFromServer;
		}
		catch
		{
			text = "";
		}
		return text;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002B5C File Offset: 0x00000D5C
	public static string GetMarkeredText(string BPMarker, string EPMarker, string HTML, ref int StartPos)
	{
		int BeginPos = HTML.IndexOf(BPMarker, StartPos, StringComparison.InvariantCultureIgnoreCase);
		if (BeginPos <= -1)
		{
			return "";
		}
		int EndPos = HTML.IndexOf(EPMarker, BeginPos, StringComparison.InvariantCultureIgnoreCase);
		if (EndPos > -1)
		{
			StartPos = EndPos + EPMarker.Length;
			string Text = "";
			try
			{
				Text = HTML.Substring(BeginPos + BPMarker.Length, EndPos - BeginPos - BPMarker.Length);
			}
			catch
			{
			}
			return Text;
		}
		StartPos = HTML.Length - 1;
		string Text2 = "";
		try
		{
			Text2 = HTML.Substring(BeginPos + BPMarker.Length, HTML.Length - BeginPos - BPMarker.Length);
		}
		catch
		{
		}
		return Text2;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002C0C File Offset: 0x00000E0C
	public static string ClearTags(string HTML)
	{
		HTML = HTML.Trim().Replace("\n", string.Empty);
		HTML = HTML.Trim().Replace("\r", string.Empty);
		HTML = HTML.Trim().Replace("\t", string.Empty);
		HTML = HTML.Trim().Replace("&nbsp;", " ");
		return Regex.Replace(HTML, "<[^>]*>", " ").Trim();
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002C8C File Offset: 0x00000E8C
	public static List<string[]> ParseHTML(string HTML, string Template)
	{
		List<string[]> Results = new List<string[]>();
		if (string.IsNullOrEmpty(HTML) || string.IsNullOrEmpty(Template))
		{
			return Results;
		}
		try
		{
			foreach (object obj in HTTPScraper._regexCache.GetOrAdd(Template, (string t) => new Regex(t, RegexOptions.Compiled)).Matches(HTML))
			{
				Match match = (Match)obj;
				string[] Values = new string[match.Groups.Count];
				for (int i = 0; i < match.Groups.Count; i++)
				{
					Values[i] = match.Groups[i].Value;
				}
				Results.Add(Values);
			}
		}
		catch (ArgumentException)
		{
		}
		return Results;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002D80 File Offset: 0x00000F80
	public static string ClearString(string Source)
	{
		string text;
		try
		{
			Source = Source.Replace("   ", " ");
			char[] Result = Source.ToCharArray();
			char[] CharsToRemove = new char[] { '\n', '\r', '\t' };
			for (int i = 0; i < Source.Length - 1; i++)
			{
				if (Source[i] == ' ' && Source[i + 1] == ' ')
				{
					Result[i] = '*';
					Result[i + 1] = '*';
				}
				for (int j = 0; j < CharsToRemove.Length; j++)
				{
					if (Result[i] == CharsToRemove[j])
					{
						Result[i] = '*';
					}
				}
			}
			text = new string(Result).Replace("*", "");
		}
		catch
		{
			text = "";
		}
		return text;
	}

	// Token: 0x0400000B RID: 11
	private static ConcurrentDictionary<string, Regex> _regexCache = new ConcurrentDictionary<string, Regex>();

	// Token: 0x0200003A RID: 58
	public struct Brand
	{
		// Token: 0x0400016E RID: 366
		public string Name;

		// Token: 0x0400016F RID: 367
		public string Url;
	}

	// Token: 0x0200003B RID: 59
	public struct Parameter
	{
		// Token: 0x04000170 RID: 368
		public string Name;

		// Token: 0x04000171 RID: 369
		public string Value;
	}
}
