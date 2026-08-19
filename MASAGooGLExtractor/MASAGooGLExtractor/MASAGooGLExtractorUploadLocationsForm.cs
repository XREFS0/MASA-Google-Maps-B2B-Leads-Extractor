using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x02000023 RID: 35
	public partial class UploadLocationsForm : Form
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00013694 File Offset: 0x00011894
		public UploadLocationsForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000136A4 File Offset: 0x000118A4
		private void btnLoadFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Text files|*.txt",
				InitialDirectory = Application.StartupPath
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.tbUploadLocations.Text = File.ReadAllText(openFileDialog.FileName);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000136EC File Offset: 0x000118EC
		private void btnApply_Click(object sender, EventArgs e)
		{
			this.Ok = true;
			base.Close();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000136FB File Offset: 0x000118FB
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Ok = false;
			base.Close();
		}

		// Token: 0x04000159 RID: 345
		public bool Ok;
	}
}
