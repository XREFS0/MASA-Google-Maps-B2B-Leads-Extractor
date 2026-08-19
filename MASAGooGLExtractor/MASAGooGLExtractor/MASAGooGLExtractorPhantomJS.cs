using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;

namespace MASAGooGLExtractor
{
	// Token: 0x0200001A RID: 26
	public class PhantomJS
	{
		// Token: 0x060000DD RID: 221 RVA: 0x0000E2B8 File Offset: 0x0000C4B8
		public void Cancel()
		{
			try
			{
				this.Completed = true;
			}
			catch
			{
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000E2E4 File Offset: 0x0000C4E4
		private static void EnsureEOExceptionHook()
		{
			if (PhantomJS._eoExceptionHooked)
			{
				return;
			}
			object eoLock = PhantomJS._eoLock;
			lock (eoLock)
			{
				if (!PhantomJS._eoExceptionHooked)
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
					PhantomJS._eoExceptionHooked = true;
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000E358 File Offset: 0x0000C558
		public PhantomJS(string Request)
		{
			this._Request = Request;
			this.Completed = false;
			try
			{
				this.MainThread = new Thread(new ThreadStart(this.RunProcess));
				this.MainThread.IsBackground = true;
				this.MainThread.SetApartmentState(ApartmentState.STA);
				this.MainThread.Start();
			}
			catch
			{
			}
			EO.WebBrowser.Runtime.AddLicense("t8TbrmuntsXNn6zs5tYj76Lp6QTs83aZtcDer2iptMPgoVnt6QMe6KjlwbPdsluXs8+4iVmXpLHn8qLe8vIf9KvcwsQW6LHvuQXf9aHk7MAE7Ybm0QQj5aC0wc3a8qLe8vIf9Kvcwp61u2jj7fQQ7azcwp61dePt9BDtrNzCnrWfWZekzRfonNzyBBDInbW1xuywcqu9xOzUcau1w9yvg7Oz/RTinuX39vTjd4SOscufWbPw+g7kp+rp9um7aOPt9BDtrNzpz7iJWZeksefgpePzCOmMQ5ekscufWZekzQzjnZf4ChvkdpnJ4NnCoenz/hChWe3pAx7oqOXBs92zZ6emsdq9RoGkscufdabl/RfusLWRm8ufWZfAAB3jnunN/xHuWdvlBRC8W6iz");
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000E3D4 File Offset: 0x0000C5D4
		private void RunProcess()
		{
			Engine engine = null;
			WebView webView = null;
			ThreadRunner runner = null;
			try
			{
				PhantomJS.EnsureEOExceptionHook();
				engine = Engine.Create("maps_crawler");
				engine.Options.DisableGPU = true;
				runner = new ThreadRunner("maps_crawler", engine);
				webView = runner.CreateWebView();
				webView.NewWindow += delegate(object s, NewWindowEventArgs e)
				{
					e.Accepted = false;
				};
				webView.Engine.Options.CustomUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36";
				string url = "https://www.google.com/maps/search/" + this._Request + "/";
				runner.Send(delegate
				{
					webView.ZoomFactor = 0.6;
					webView.LoadUrlAndWait(url);
					try
					{
						object res = null;
						try
						{
							res = webView.EvalScript("\n(function(){\n\n  function clickSecondMainButton() {\n    var buttons = document.querySelectorAll('button.UywwFc-LgbsSe, div.QS5gu.sy4vM');\n    if (buttons && buttons.length >= 2) {\n      buttons[1].click();\n      return 'second_button';\n    }\n    return null;\n  }\n\n  function clickAltButton() {\n    var alt = document.querySelector(\n      'button[id*=\"L2AGLb\"],' +\n      'button[aria-label*=\"Acc\"],' +\n      'button[aria-label*=\"Ace\"],' +\n      'button[aria-label*=\"acz\"],' +\n      'button[aria-label*=\"acc\"]'\n    );\n    if (alt) {\n      alt.click();\n      return 'alt_button';\n    }\n    return null;\n  }\n\n  var r1 = clickSecondMainButton();\n  if (r1) return r1;\n\n  var r2 = clickAltButton();\n  if (r2) return r2;\n\n  var header = document.getElementsByTagName('h1')[0];\n  if (header && header.innerText && header.innerText.indexOf('Google') > -1) {\n    var forms = document.getElementsByTagName('form');\n    if (forms.length > 1) {\n      forms[1].submit();\n      return 'form_submit';\n    }\n  }\n\n  return 'none';\n})();");
						}
						catch (JSInvokeException)
						{
						}
						string text = res as string;
					}
					catch (Exception ex2)
					{
					}
					try
					{
						object locObj = null;
						try
						{
							locObj = webView.EvalScript("window.location.href;");
						}
						catch (JSInvokeException)
						{
						}
						string text2 = locObj as string;
					}
					catch
					{
					}
					Thread.Sleep(3000);
					bool hasResults = false;
					int i = 0;
					while (i < 80 && !Program.StopDataCollection)
					{
						try
						{
							object resObj = null;
							try
							{
								resObj = webView.EvalScript("\n    (function(){\n       var anchors = document.querySelectorAll(\n         'a[href^=\"https://www.google.com/maps/place/\"], a[href^=\"/maps/place/\"]'\n       );\n       var resultsCount = anchors ? anchors.length : 0;\n       var feed = document.querySelector('div[role=\"feed\"]') ? 1 : 0;\n       return resultsCount + '|' + feed;\n    })();\n");
							}
							catch (JSInvokeException)
							{
							}
							string[] parts = ((resObj as string) ?? "0|0").Split(new char[] { '|' });
							int results = 0;
							int feed = 0;
							int.TryParse(parts[0], out results);
							if (parts.Length > 1)
							{
								int.TryParse(parts[1], out feed);
							}
							if (results > 0 || feed == 1)
							{
								hasResults = true;
								break;
							}
						}
						catch
						{
						}
						Thread.Sleep(100);
						i++;
					}
					if (!hasResults)
					{
						this.Response = "<!--NO_RESULTS-->";
						return;
					}
					int target = 100;
					try
					{
						target = Math.Max(1, Program.AppSettings.NumberOfResultsPerZipCode);
					}
					catch
					{
					}
					int lastCount = 0;
					int j = 0;
					while (j < 50 && !Program.StopDataCollection)
					{
						string res2 = "0|0|0";
						try
						{
							object sc = webView.EvalScript("\n(function(){\n  function countCards(){\n    var c1 = document.querySelectorAll('a.hfpxzc').length;\n    var c2 = document.querySelectorAll('a[href^=\"/maps/place/\"],a[href^=\"https://www.google.com/maps/place/\"]').length;\n    return Math.max(c1, c2);\n  }\n\n  var feed = document.querySelector('div[role=\"feed\"]');\n  if (feed){\n    // passo adattivo\n    feed.scrollTop = Math.min(feed.scrollTop + Math.floor(feed.clientHeight * 0.9), feed.scrollHeight);\n    if (feed.scrollTop + feed.clientHeight >= feed.scrollHeight - 4)\n        feed.scrollTop = feed.scrollHeight;\n    return countCards() + '|' + feed.scrollTop + '|' + feed.scrollHeight;\n  } else {\n    var prevY = window.scrollY || window.pageYOffset || 0;\n    window.scrollTo(0, prevY + Math.floor(window.innerHeight * 0.9));\n    return countCards() + '|0|0';\n  }\n})();");
							string text3;
							if ((text3 = sc as string) == null)
							{
								text3 = ((sc != null) ? sc.ToString() : null) ?? "0|0|0";
							}
							res2 = text3;
						}
						catch (JSInvokeException)
						{
						}
						catch
						{
						}
						int cards = 0;
						try
						{
							string[] parts2 = res2.Split(new char[] { '|' });
							if (parts2.Length != 0)
							{
								int.TryParse(parts2[0], out cards);
							}
						}
						catch
						{
						}
						if (cards >= target)
						{
							break;
						}
						lastCount = Math.Max(lastCount, cards);
						Thread.Sleep(100);
						j++;
					}
					Thread.Sleep(600);
					try
					{
						object htmlObj = null;
						try
						{
							htmlObj = webView.EvalScript("\n(function(){\n  var feed = document.querySelector('div[role=\"feed\"]');\n  if (!feed) return '';\n  return feed.outerHTML;\n})();");
						}
						catch (JSInvokeException)
						{
						}
						string html = (htmlObj as string) ?? string.Empty;
						if (string.IsNullOrWhiteSpace(html))
						{
							this.Response = "<!--EMPTY_PAGE_SOURCE-->";
						}
						else
						{
							this.Response = html;
						}
					}
					catch (Exception ex3)
					{
						this.Response = "EO.WebBrowser Error reading HTML: " + ex3.Message;
					}
				});
			}
			catch (Exception ex)
			{
				this.Response = "EO.WebBrowser Init Error: " + ex.Message;
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
				this.Completed = true;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000E528 File Offset: 0x0000C728
		private static void Log2(string Msg)
		{
			try
			{
				File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "response.txt"), string.Format("{0}: {1}{2}", DateTime.Now, Msg, Environment.NewLine));
			}
			catch
			{
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000E57C File Offset: 0x0000C77C
		private void LogTemp(string phase, string msg)
		{
			try
			{
				string logFile = Path.Combine(Path.GetTempPath(), "MASA_MapsPhantom.log");
				string line = string.Format("{0:yyyy-MM-dd HH:mm:ss} | {1} | {2} | {3}", new object[]
				{
					DateTime.Now,
					this._Request,
					phase,
					msg
				});
				object logLock = PhantomJS._logLock;
				lock (logLock)
				{
					string[] existing = Array.Empty<string>();
					if (File.Exists(logFile))
					{
						existing = File.ReadAllLines(logFile);
					}
					List<string> lines = existing.ToList<string>();
					lines.Add(line);
					if (lines.Count > 50)
					{
						lines = lines.Skip<string>(lines.Count - 50).ToList<string>();
					}
					File.WriteAllLines(logFile, lines);
				}
			}
			catch
			{
			}
		}

		// Token: 0x040000C8 RID: 200
		private static readonly object _logLock = new object();

		// Token: 0x040000C9 RID: 201
		public bool Completed;

		// Token: 0x040000CA RID: 202
		public string Response;

		// Token: 0x040000CB RID: 203
		private Thread MainThread;

		// Token: 0x040000CC RID: 204
		private string _Request;

		// Token: 0x040000CD RID: 205
		private static bool _eoExceptionHooked = false;

		// Token: 0x040000CE RID: 206
		private static readonly object _eoLock = new object();
	}
}
