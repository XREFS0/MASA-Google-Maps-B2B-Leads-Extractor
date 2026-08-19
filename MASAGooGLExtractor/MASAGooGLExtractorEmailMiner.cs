using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace MASAGooGLExtractor
{
	// Token: 0x02000008 RID: 8
	public static class EmailMiner
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002EF0 File Offset: 0x000010F0
		public static string GetEmail(string url, string[] contactPageMarkers, int maxMilliseconds = 3000)
		{
			if (string.IsNullOrWhiteSpace(url))
			{
				return string.Empty;
			}
			Stopwatch sw = Stopwatch.StartNew();
			string baseUrl = EmailMiner.NormalizeBaseUrl(url);
			if (string.IsNullOrEmpty(baseUrl))
			{
				return string.Empty;
			}
			string page = HTTPScraper.GetPage(baseUrl, null);
			if (sw.ElapsedMilliseconds > (long)maxMilliseconds)
			{
				return string.Empty;
			}
			string clearPage = HTTPScraper.ClearString(page);
			string email = EmailMiner.ExtractFirstValidEmail(clearPage, baseUrl);
			if (!string.IsNullOrEmpty(email))
			{
				return email;
			}
			string contactsPattern = "href=(\"|'|)(.*?)(\"|'|)[>|\\s]";
			foreach (string contactLink in (from href in (from a in HTTPScraper.ParseHTML(clearPage, contactsPattern)
					where a.Length > 2 && !string.IsNullOrWhiteSpace(a[2])
					select a[2]).Distinct<string>(StringComparer.InvariantCultureIgnoreCase).ToList<string>()
				where contactPageMarkers.Any<string>((string cp) => href.IndexOf(cp, StringComparison.InvariantCultureIgnoreCase) >= 0)
				select href).Take<string>(3).ToList<string>())
			{
				if (sw.ElapsedMilliseconds > (long)maxMilliseconds)
				{
					break;
				}
				string contactUrl = EmailMiner.BuildAbsoluteUrl(baseUrl, contactLink);
				if (!string.IsNullOrEmpty(contactUrl))
				{
					string contactPage = HTTPScraper.GetPage(contactUrl, null);
					if (sw.ElapsedMilliseconds > (long)maxMilliseconds)
					{
						break;
					}
					email = EmailMiner.ExtractFirstValidEmail(HTTPScraper.ClearString(contactPage), baseUrl);
					if (!string.IsNullOrEmpty(email))
					{
						return email;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003084 File Offset: 0x00001284
		private static string NormalizeBaseUrl(string url)
		{
			url = url.Trim();
			if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
			{
				url = "http://" + url;
			}
			string text;
			try
			{
				Uri uri = new Uri(url);
				text = uri.Scheme + "://" + uri.Host;
			}
			catch
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000030F0 File Offset: 0x000012F0
		private static string BuildAbsoluteUrl(string baseUrl, string href)
		{
			string text;
			try
			{
				if (string.IsNullOrWhiteSpace(href))
				{
					text = string.Empty;
				}
				else if (href.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
				{
					text = string.Empty;
				}
				else if (href.StartsWith("http", StringComparison.OrdinalIgnoreCase))
				{
					text = href;
				}
				else
				{
					text = new Uri(new Uri(baseUrl), href).ToString();
				}
			}
			catch
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003164 File Offset: 0x00001364
		private static string ExtractFirstValidEmail(string text, string baseUrl)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			string baseDomain = EmailMiner.GetDomain(baseUrl);
			foreach (object obj in EmailMiner.EmailRegex.Matches(text))
			{
				string raw = ((Match)obj).Value;
				if (raw.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
				{
					raw = raw.Substring("mailto:".Length);
				}
				if (EmailMiner.IsValidEmail(raw))
				{
					string emailDomain = EmailMiner.GetDomainFromEmail(raw);
					if (!string.IsNullOrEmpty(baseDomain) && !string.IsNullOrEmpty(emailDomain))
					{
						emailDomain.EndsWith(baseDomain, StringComparison.OrdinalIgnoreCase);
					}
					return raw;
				}
			}
			return string.Empty;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000322C File Offset: 0x0000142C
		private static bool IsValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
			{
				return false;
			}
			string e = email.ToLowerInvariant();
			return !e.Contains("example") && !e.Contains("sentry") && !e.Contains("tripadvisor") && !e.EndsWith(".jpg") && !e.EndsWith(".jpeg") && !e.EndsWith(".png") && !e.EndsWith(".gif") && !e.Contains(".wix") && !e.Contains("@mail.com");
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000032C8 File Offset: 0x000014C8
		private static string GetDomain(string url)
		{
			string text;
			try
			{
				string host = new Uri(url).Host.ToLowerInvariant();
				if (host.StartsWith("www."))
				{
					host = host.Substring(4);
				}
				text = host;
			}
			catch
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000331C File Offset: 0x0000151C
		private static string GetDomainFromEmail(string email)
		{
			int at = email.IndexOf('@');
			if (at < 0 || at == email.Length - 1)
			{
				return string.Empty;
			}
			string domain = email.Substring(at + 1).ToLowerInvariant();
			if (domain.StartsWith("www."))
			{
				domain = domain.Substring(4);
			}
			return domain;
		}

		// Token: 0x04000011 RID: 17
		private static readonly Regex EmailRegex = new Regex("(mailto:)?([\\w\\.\\-]+)@((([\\-\\w]+\\.)+[a-zA-Z]{2,})|(([0-9]{1,3}\\.){3}[0-9]{1,3}))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
	}
}
