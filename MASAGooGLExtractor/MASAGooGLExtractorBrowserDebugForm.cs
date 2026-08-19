using System;
using System.Windows.Forms;
using EO.WebBrowser;
using EO.WinForm;

// Token: 0x02000002 RID: 2
public class BrowserDebugForm : Form
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public WebControl WebControl { get; private set; }

	// Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
	public BrowserDebugForm()
	{
		this.Text = "EO Debug Browser";
		base.Width = 1300;
		base.Height = 900;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.WebControl = new WebControl();
		this.WebControl.Dock = DockStyle.Fill;
		base.Controls.Add(this.WebControl);
		IntPtr handle = base.Handle;
		IntPtr handle2 = this.WebControl.Handle;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020DA File Offset: 0x000002DA
	public void Attach(WebView wv)
	{
		this.WebControl.WebView = wv;
	}
}
