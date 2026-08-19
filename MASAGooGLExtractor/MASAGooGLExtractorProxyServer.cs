using System;
using System.Threading;

// Token: 0x02000007 RID: 7
public class ProxyServer
{
	// Token: 0x06000021 RID: 33 RVA: 0x00002E4C File Offset: 0x0000104C
	public ProxyServer()
	{
		this.Checked = false;
		this.Processed = false;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002E64 File Offset: 0x00001064
	private void DoCheckProxy()
	{
		string SourcePageHTML = HTTPScraper.GetPage("http://www.equibase.com/profiles/Results.cfm?type=Horse&refno=8685211&registry=T&rbt=TB", this);
		this.CanUse = SourcePageHTML.IndexOf("Aldous Snow") > -1;
		this.Checked = true;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002E98 File Offset: 0x00001098
	public void CheckProxy()
	{
		this.Checked = false;
		this.Processed = false;
		new Thread(new ThreadStart(this.DoCheckProxy)).Start();
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002EC0 File Offset: 0x000010C0
	public void CheckProxyAndWait()
	{
		string SourcePageHTML = HTTPScraper.GetPage("http://www.google.com", this);
		this.CanUse = SourcePageHTML.IndexOf("Google") > -1;
	}

	// Token: 0x0400000C RID: 12
	public string IP;

	// Token: 0x0400000D RID: 13
	public int Port;

	// Token: 0x0400000E RID: 14
	public bool CanUse;

	// Token: 0x0400000F RID: 15
	public bool Checked;

	// Token: 0x04000010 RID: 16
	public bool Processed;
}
