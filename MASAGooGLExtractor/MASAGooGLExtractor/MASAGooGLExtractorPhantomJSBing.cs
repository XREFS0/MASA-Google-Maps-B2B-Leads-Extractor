using System;
using System.IO;
using System.Threading;

namespace MASAGooGLExtractor
{
	// Token: 0x0200001B RID: 27
	public class PhantomJSBing
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000E674 File Offset: 0x0000C874
		public PhantomJSBing(string Request)
		{
			this._Request = Request;
			this.Completed = false;
			try
			{
				this.MainThread = new Thread(new ThreadStart(this.RunProcess));
				this.MainThread.IsBackground = true;
				this.MainThread.Start();
			}
			catch
			{
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		private void RunProcess()
		{
			try
			{
				string page = HTTPScraper.GetPage(string.Format("https://www.bing.com/maps/overlaybfpr?q={0}&count={1}", this._Request, Program.AppSettings.NumberOfResultsPerZipCode), null, 5000);
				this.Response = HTTPScraper.ClearString(page);
			}
			catch (Exception ex)
			{
				PhantomJSBing.Log("PhantomJSBing error: " + ex.Message);
				this.Response = "";
			}
			finally
			{
				this.Completed = true;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000E768 File Offset: 0x0000C968
		private static void Log(string Msg)
		{
			try
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GBS";
				string filePath = Path.Combine(folderPath, "bing_log.txt");
				if (!Directory.Exists(folderPath))
				{
					Directory.CreateDirectory(folderPath);
				}
				File.AppendAllText(filePath, string.Format("{0}: {1}{2}", DateTime.Now, Msg, Environment.NewLine));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x040000CF RID: 207
		public bool Completed;

		// Token: 0x040000D0 RID: 208
		public string Response;

		// Token: 0x040000D1 RID: 209
		private Thread MainThread;

		// Token: 0x040000D2 RID: 210
		private string _Request;
	}
}
