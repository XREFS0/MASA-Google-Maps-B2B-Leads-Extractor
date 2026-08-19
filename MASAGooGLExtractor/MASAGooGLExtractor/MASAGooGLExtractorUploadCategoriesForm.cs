using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x02000022 RID: 34
	public partial class UploadCategoriesForm : Form
	{
		// Token: 0x06000121 RID: 289 RVA: 0x000131A3 File Offset: 0x000113A3
		public UploadCategoriesForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000131B1 File Offset: 0x000113B1
		private void btnApply_Click(object sender, EventArgs e)
		{
			this.UseThem = true;
			base.Close();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000131C0 File Offset: 0x000113C0
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.UseThem = false;
			base.Close();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000131D0 File Offset: 0x000113D0
		private void btnLoadFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Text files|*.txt",
				InitialDirectory = Application.StartupPath
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.tbUploadCategories.Text = File.ReadAllText(openFileDialog.FileName);
			}
		}

		// Token: 0x04000151 RID: 337
		public bool UseThem;
	}
}
