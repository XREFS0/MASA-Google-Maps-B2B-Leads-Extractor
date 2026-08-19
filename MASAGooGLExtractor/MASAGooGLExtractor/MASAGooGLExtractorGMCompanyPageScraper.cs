using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MASAGooGLExtractor
{
	// Token: 0x02000011 RID: 17
	public class GMCompanyPageScraper
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000044C0 File Offset: 0x000026C0
		public GMCompanyPageScraper(string PageUrl)
		{
			this._PageUrl = PageUrl;
			this.CompanyData = new GeoData();
			this.Done = false;
			this.MainThread = new Thread(new ThreadStart(this.GetData));
			this.MainThread.Start();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004510 File Offset: 0x00002710
		public void GetData()
		{
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true,
				FileName = "phantomjs.exe",
				Arguments = string.Format("\"{0}\\{1}\" {2}", Directory.GetCurrentDirectory(), "index_page.js", this._PageUrl)
			};
			process.StartInfo = startInfo;
			process.Start();
			string OutputHtml = process.StandardOutput.ReadToEnd();
			File.WriteAllText("debug_page.html", OutputHtml);
			if (HTTPScraper.ParseHTML(OutputHtml, "").Count > 0)
			{
				this.CompanyData.Category = "";
			}
			this.Done = true;
		}

		// Token: 0x04000032 RID: 50
		private Thread MainThread;

		// Token: 0x04000033 RID: 51
		private string _PageUrl;

		// Token: 0x04000034 RID: 52
		public GeoData CompanyData;

		// Token: 0x04000035 RID: 53
		public bool Done;
	}
}
