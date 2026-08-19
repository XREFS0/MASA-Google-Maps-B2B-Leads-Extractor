using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using MASAGooGLExtractor;

namespace MASAGooGLExtractor
{
	// Token: 0x02000013 RID: 19
	public class GooglePageScraper
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00005B40 File Offset: 0x00003D40
		private static void EnsureEOExceptionHook()
		{
			if (GooglePageScraper._eoExceptionHooked)
			{
				return;
			}
			object eoLock = GooglePageScraper._eoLock;
			lock (eoLock)
			{
				if (!GooglePageScraper._eoExceptionHooked)
				{
					EO.Base.Runtime.Exception += delegate(object sender, ExceptionEventArgs e)
					{
						e.ShowExceptionDialog = false;
						if (e.ErrorException is OutOfMemoryException)
						{
							return;
						}
						if (e.ErrorException is StackOverflowException)
						{
							return;
						}
						if (e.ErrorException is ChildProcessOutOfMemoryException)
						{
							return;
						}
						if (e.ErrorException is JSInvokeException)
						{
							return;
						}
						try
						{
							string text = Path.Combine(Path.GetTempPath(), "EO_CriticalErrors.log");
							string text2 = "{0:yyyy-MM-dd HH:mm:ss} | {1} | {2}\r\n";
							object obj = DateTime.Now;
							Exception errorException = e.ErrorException;
							object obj2 = ((errorException != null) ? errorException.GetType().Name : null);
							Exception errorException2 = e.ErrorException;
							File.AppendAllText(text, string.Format(text2, obj, obj2, (errorException2 != null) ? errorException2.Message : null));
						}
						catch
						{
						}
					};
					GooglePageScraper._eoExceptionHooked = true;
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005BB4 File Offset: 0x00003DB4
		public GooglePageScraper(string Url, string Category, string State, bool EmailMining = false)
		{
			this._Url = Url;
			this._Category = Category;
			this._State = State;
			this._EmailMining = EmailMining;
			this.DataItem = new GeoData();
			this.Done = false;
			this._cts = new CancellationTokenSource();
			this._timer = new Timer(delegate(object _)
			{
				this.TimeoutHappens();
			}, null, 30000, -1);
			Thread thread = new Thread(delegate()
			{
				this.GetData(this._cts.Token);
			});
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005C50 File Offset: 0x00003E50
		private void TimeoutHappens()
		{
			try
			{
				CancellationTokenSource cts = this._cts;
				if (cts != null)
				{
					cts.Cancel();
				}
				Timer timer = this._timer;
				if (timer != null)
				{
					timer.Dispose();
				}
			}
			finally
			{
				this.Done = true;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005C9C File Offset: 0x00003E9C
		public void GetData(CancellationToken ct)
		{
			string _OutputHtml = string.Empty;
			Engine engine = null;
			ThreadRunner runner = null;
			WebView webView = null;
			try
			{
				engine = Engine.Create("gpscraper_page");
				engine.Options.DisableGPU = true;
				runner = new ThreadRunner("gpscraper_page", engine);
				webView = runner.CreateWebView();
				EO.WebBrowser.Runtime.AddLicense("t8TbrmuntsXNn6zs5tYj76Lp6QTs83aZtcDer2iptMPgoVnt6QMe6KjlwbPdsluXs8+4iVmXpLHn8qLe8vIf9KvcwsQW6LHvuQXf9aHk7MAE7Ybm0QQj5aC0wc3a8qLe8vIf9Kvcwp61u2jj7fQQ7azcwp61dePt9BDtrNzCnrWfWZekzRfonNzyBBDInbW1xuywcqu9xOzUcau1w9yvg7Oz/RTinuX39vTjd4SOscufWbPw+g7kp+rp9um7aOPt9BDtrNzpz7iJWZeksefgpePzCOmMQ5ekscufWZekzQzjnZf4ChvkdpnJ4NnCoenz/hChWe3pAx7oqOXBs92zZ6emsdq9RoGkscufdabl/RfusLWRm8ufWZfAAB3jnunN/xHuWdvlBRC8W6iz");
				webView.NewWindow += delegate(object s, NewWindowEventArgs e)
				{
					e.Accepted = false;
				};
				webView.Engine.Options.CustomUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36";
				GooglePageScraper.EnsureEOExceptionHook();
				if (ct.IsCancellationRequested)
				{
					this.Done = true;
					return;
				}
				runner.Send(delegate
				{
					if (ct.IsCancellationRequested)
					{
						return;
					}
					try
					{
						webView.ZoomFactor = 0.8;
						webView.LoadUrlAndWait(this._Url);
					}
					catch
					{
					}
					if (ct.IsCancellationRequested)
					{
						return;
					}
					try
					{
						object res = null;
						try
						{
							res = webView.EvalScript("\n(function(){\n\n  function clickSecondMainButton() {\n    var buttons = document.querySelectorAll('button.UywwFc-LgbsSe, div.QS5gu.sy4vM');\n    if (buttons && buttons.length >= 2) {\n      buttons[1].click();\n      return 'second_button';\n    }\n    return null;\n  }\n\n  function clickAltButton() {\n    var alt = document.querySelector(\n      'button[id*=\"L2AGLb\"],' +\n      'button[aria-label*=\"Acc\"],' +\n      'button[aria-label*=\"Ace\"],' +\n      'button[aria-label*=\"acz\"],' +\n      'button[aria-label*=\"acc\"]'\n    );\n    if (alt) {\n      alt.click();\n      return 'alt_button';\n    }\n    return null;\n  }\n\n  // 1) prova il secondo pulsante principale\n  var r1 = clickSecondMainButton();\n  if (r1) return r1;\n\n  // 2) prova pulsanti alternativi\n  var r2 = clickAltButton();\n  if (r2) return r2;\n\n  // 3) fallback: header Google + secondo form\n  var header = document.getElementsByTagName('h1')[0];\n  if (header && header.innerText && header.innerText.indexOf('Google') > -1) {\n    var forms = document.getElementsByTagName('form');\n    if (forms.length > 1) {\n      forms[1].submit();\n      return 'form_submit';\n    }\n  }\n\n  return 'none';\n})();");
						}
						catch (JSInvokeException)
						{
						}
						string text = res as string;
					}
					catch (Exception ex)
					{
					}
					Thread.Sleep(1000);
					if (ct.IsCancellationRequested)
					{
						return;
					}
					int j = 0;
					while (j < 80 && !ct.IsCancellationRequested)
					{
						try
						{
							object resObj = null;
							try
							{
								resObj = webView.EvalScript("\n            (function(){\n                var region = document.querySelector('div[role=\"region\"]');\n                var href   = window.location.href || '';\n\n                // condizione 'pagina dettaglio Maps' : presenza region + url /maps/place/\n                var ok = !!region && href.indexOf('/maps/place/') !== -1;\n\n                return (ok ? '1' : '0');\n            })();\n        ");
							}
							catch (JSInvokeException)
							{
							}
							if (((resObj as string) ?? "0") == "1")
							{
								break;
							}
						}
						catch
						{
						}
						Thread.Sleep(200);
						j++;
					}
					if (ct.IsCancellationRequested)
					{
						return;
					}
					try
					{
						object htmlObj = null;
						try
						{
							htmlObj = webView.EvalScript("document.documentElement.outerHTML;");
						}
						catch (JSInvokeException)
						{
						}
						string html = (htmlObj as string) ?? string.Empty;
						if (html.Length > 2000000)
						{
							html = html.Substring(0, 2000000);
						}
						_OutputHtml = html;
						if (!string.IsNullOrWhiteSpace(html))
						{
							int length = html.Length;
						}
					}
					catch (Exception ex2)
					{
						_OutputHtml = string.Empty;
					}
				});
			}
			catch
			{
			}
			finally
			{
				try
				{
					if (runner != null)
					{
						try
						{
							runner.Dispose();
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
				try
				{
					if (engine != null)
					{
						engine.Stop(false);
					}
				}
				catch
				{
				}
				try
				{
					Timer timer = this._timer;
					if (timer != null)
					{
						timer.Dispose();
					}
				}
				catch
				{
				}
			}
			if (ct.IsCancellationRequested)
			{
				this.Done = true;
				return;
			}
			if (!string.IsNullOrEmpty(_OutputHtml))
			{
				try
				{
					_OutputHtml = GooglePageScraper.RX_STRIP_STYLE.Replace(_OutputHtml, string.Empty);
				}
				catch
				{
				}
				try
				{
					_OutputHtml = GooglePageScraper.RX_STRIP_LINK_CSS.Replace(_OutputHtml, string.Empty);
				}
				catch
				{
				}
			}
			if (string.IsNullOrEmpty(_OutputHtml))
			{
				this.Done = true;
				return;
			}
			try
			{
				if (!string.IsNullOrEmpty(_OutputHtml))
				{
					this.DataItem.Category = this._Category;
					List<string[]> Items = HTTPScraper.ParseHTML(_OutputHtml, ".category\">(.*?)</button>");
					this.DataItem.RealCategory = ((Items.Count > 0) ? Items[0][1] : this.DataItem.Category);
					Items = HTTPScraper.ParseHTML(_OutputHtml, "<span class=\"a5H0ec\"></span>(.*?)<span");
					if (Items.Count > 0)
					{
						this.DataItem.BusinessName = Items[0][1].Replace("&amp;", "&");
					}
					else
					{
						Items = HTTPScraper.ParseHTML(_OutputHtml, ",null,null,null,-null,null,null,>\"(.*?)\",");
						this.DataItem.BusinessName = ((Items.Count > 0) ? Items[0][1].Replace(">>u0026", "").Replace(">", "") : "N/A");
					}
					Match i = Regex.Match(_OutputHtml, "pane\\.blurTooltip\"\\s+aria-label=\"([^\"]+)\"\\s+data-item-id=\"address\"", RegexOptions.IgnoreCase);
					if (i.Success)
					{
						string raw = i.Groups[1].Value;
						raw = Regex.Replace(raw, "^[^:]+:\\s*", "");
						this.DataItem.Address = WebUtility.HtmlDecode(raw.Trim());
					}
					else
					{
						this.DataItem.Address = "";
					}
					List<string[]> StrParse = HTTPScraper.ParseHTML(this.DataItem.Address, "(\\d{5,6}) ([^,]+),");
					if (StrParse.Count > 0)
					{
						this.DataItem.PostalCode = StrParse[0][1];
						this.DataItem.City = StrParse[0][2];
					}
					else
					{
						StrParse = HTTPScraper.ParseHTML(this.DataItem.Address, "(\\d{5,6}) (.*)");
						if (StrParse.Count > 0)
						{
							this.DataItem.PostalCode = StrParse[0][1];
							this.DataItem.City = WebUtility.HtmlDecode(StrParse[0][2]);
						}
						else
						{
							StrParse = HTTPScraper.ParseHTML(this.DataItem.Address, ", ([^\\d]+)\\s(\\d{5,6}), (.*)");
							if (StrParse.Count > 0)
							{
								this.DataItem.City = StrParse[0][1];
								this.DataItem.PostalCode = StrParse[0][2];
							}
							else
							{
								StrParse = HTTPScraper.ParseHTML(this.DataItem.Address, ", (.*), (.*) (\\d{5,6})");
								if (StrParse.Count > 0)
								{
									this.DataItem.City = StrParse[0][1];
									this.DataItem.PostalCode = StrParse[0][3];
								}
							}
						}
					}
					this.DataItem.State = this._State;
					Items = HTTPScraper.ParseHTML(_OutputHtml, "!3d(-?[0-9.]+)!4d(-?[0-9.]+)!");
					if (Items.Count > 0)
					{
						this.DataItem.Latitude = Items[0][1];
						this.DataItem.Longitude = Items[0][2];
					}
					else
					{
						Items = HTTPScraper.ParseHTML(_OutputHtml, "cid(.*?):(.*?)&amp;");
						if (Items.Count > 0)
						{
							this.DataItem.Latitude = Items[0][1];
							this.DataItem.Longitude = Items[0][2];
						}
						else
						{
							this.DataItem.Latitude = "";
							this.DataItem.Longitude = "";
						}
					}
					Items = HTTPScraper.ParseHTML(_OutputHtml, "(?is)<a[^>]*data-item-id=\"authority\"[^>]*href\\s*=\\s*['\"]([^'\"]+)['\"]");
					if (Items.Count > 0)
					{
						string raw2 = Items[0][1].Trim();
						this.DataItem.Website = (raw2.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? raw2.Replace(" ", "") : ("https://" + raw2.Replace(" ", "")));
					}
					else
					{
						this.DataItem.Website = "";
					}
					Items = HTTPScraper.ParseHTML(_OutputHtml, "phone:tel:(.*?)\"");
					this.DataItem.Phone = ((Items.Count > 0) ? (" " + Items[0][1]) : "");
					if (!string.IsNullOrEmpty(this.DataItem.Website) && this._EmailMining)
					{
						string u = this.DataItem.Website.ToLowerInvariant();
						if (!u.Contains("facebook.com") && !u.Contains("instagram.com") && !u.Contains("linkedin.com") && !u.Contains("x.com") && !u.Contains("twitter.com") && !u.Contains("tiktok.com") && !u.Contains("tripadvisor.") && !u.Contains("booking.") && !u.Contains("ebay.") && !u.Contains("amazon."))
						{
							this.DataItem.Email = EmailMiner.GetEmail(this.DataItem.Website, new string[] { "conta" }, 4000);
						}
					}
					if (this._Url.Contains("."))
					{
						try
						{
							this.DataItem.MapLink = "https://www.google.com/maps?q=" + this.DataItem.Latitude + "," + this.DataItem.Longitude;
							goto IL_06F4;
						}
						catch
						{
							goto IL_06F4;
						}
					}
					this.DataItem.MapLink = "";
					IL_06F4:
					Items = HTTPScraper.ParseHTML(_OutputHtml, "aria-label=\\\"([0-9]+(?:[\\.,][0-9])?)(?:\\s|&nbsp;|&#160;|\\u00A0)*(?:stella|stelle|star|stars|étoile|étoiles|Stern|Sterne|estrella|estrellas|estrela|estrelas)\\s*\\\"");
					if (Items.Count > 0)
					{
						this.DataItem.DetailsLink = Items[0][1].Replace(",", ".") + " avg rating";
					}
					else
					{
						List<string[]> Items2 = HTTPScraper.ParseHTML(_OutputHtml, ">\"-,null,null,null,(.*?),(\\d+)-,null,null,");
						if (Items2.Count > 1 && Items2[1][1].IndexOf(">", StringComparison.Ordinal) == -1)
						{
							this.DataItem.DetailsLink = Items2[1][1].Replace("null,", "") + " / " + Items2[1][2] + " reviews";
						}
					}
					GooglePageScraper.WriteToFile(new string[]
					{
						this.DataItem.Category,
						this.DataItem.RealCategory,
						this.DataItem.BusinessName,
						this.DataItem.Address,
						this.DataItem.City,
						this.DataItem.PostalCode,
						this.DataItem.State,
						this.DataItem.Phone,
						this.DataItem.Website,
						this.DataItem.Email,
						this.DataItem.Latitude,
						this.DataItem.Longitude,
						this.DataItem.MapLink,
						this.DataItem.DetailsLink
					});
					this.Done = true;
				}
				else
				{
					this.Done = true;
				}
			}
			catch (Exception)
			{
				this.Done = true;
			}
			finally
			{
				try
				{
					if (runner != null)
					{
						try
						{
							runner.Dispose();
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
				try
				{
					if (engine != null)
					{
						try
						{
							engine.Stop(false);
						}
						catch
						{
						}
						try
						{
							GC.Collect(0, GCCollectionMode.Forced, false, false);
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
				try
				{
					GC.WaitForPendingFinalizers();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006734 File Offset: 0x00004934
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

		// Token: 0x06000066 RID: 102 RVA: 0x000067BC File Offset: 0x000049BC
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
							string line = string.Join(";", fields.Select<string, string>(new Func<string, string>(GooglePageScraper.ToCsvField)));
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

		// Token: 0x06000067 RID: 103 RVA: 0x00006864 File Offset: 0x00004A64
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

		// Token: 0x06000068 RID: 104 RVA: 0x000068D0 File Offset: 0x00004AD0
		public static bool IsAllDigits(string s)
		{
			for (int i = 0; i < s.Length; i++)
			{
				if (!char.IsDigit(s[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00006904 File Offset: 0x00004B04
		public void Dispose()
		{
			try
			{
				CancellationTokenSource cts = this._cts;
				if (cts != null)
				{
					cts.Cancel();
				}
				CancellationTokenSource cts2 = this._cts;
				if (cts2 != null)
				{
					cts2.Dispose();
				}
				Timer timer = this._timer;
				if (timer != null)
				{
					timer.Dispose();
				}
			}
			catch
			{
			}
			this.DataItem = null;
			this.Done = true;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006968 File Offset: 0x00004B68
		private static void Log2(string Msg)
		{
			try
			{
				File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt"), string.Format("{0}: {1}{2}", DateTime.Now, Msg, Environment.NewLine));
			}
			catch
			{
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000069BC File Offset: 0x00004BBC
		private void LogTemp(string phase, string msg)
		{
			try
			{
				File.WriteAllText(Path.Combine(Path.GetTempPath(), "MASA_MapsPage.log"), string.Format("{0:yyyy-MM-dd HH:mm:ss} | {1} | {2} | {3}{4}", new object[]
				{
					DateTime.Now,
					this._Url,
					phase,
					msg,
					Environment.NewLine
				}));
			}
			catch
			{
			}
		}

		// Token: 0x0400003F RID: 63
		private readonly string _Url;

		// Token: 0x04000040 RID: 64
		private readonly string _Category;

		// Token: 0x04000041 RID: 65
		private readonly string _State;

		// Token: 0x04000042 RID: 66
		private readonly bool _EmailMining;

		// Token: 0x04000043 RID: 67
		private CancellationTokenSource _cts;

		// Token: 0x04000044 RID: 68
		private Timer _timer;

		// Token: 0x04000045 RID: 69
		private static bool _eoExceptionHooked = false;

		// Token: 0x04000046 RID: 70
		private static readonly object _eoLock = new object();

		// Token: 0x04000047 RID: 71
		private static readonly TimeSpan RxTO = TimeSpan.FromMilliseconds(400.0);

		// Token: 0x04000048 RID: 72
		private static readonly Regex RX_STRIP_STYLE = new Regex("<style[^>]*?>.*?</style>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline, GooglePageScraper.RxTO);

		// Token: 0x04000049 RID: 73
		private static readonly Regex RX_STRIP_LINK_CSS = new Regex("<link[^>]+rel=[\"']?stylesheet[\"']?[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Compiled, GooglePageScraper.RxTO);

		// Token: 0x0400004A RID: 74
		public GeoData DataItem = new GeoData();

		// Token: 0x0400004B RID: 75
		public bool Done;
	}
}
