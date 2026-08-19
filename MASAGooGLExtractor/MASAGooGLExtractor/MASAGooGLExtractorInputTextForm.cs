using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x02000015 RID: 21
	public partial class InputTextForm : Form
	{
		// Token: 0x06000075 RID: 117 RVA: 0x00007188 File Offset: 0x00005388
		public InputTextForm(string Value, string Title, string Prompt)
		{
			this.InitializeComponent();
			this.lblPrompt.Text = Prompt;
			this.Text = Title;
			this.tbValue.Text = Value;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000071B8 File Offset: 0x000053B8
		private void btnApply_Click(object sender, EventArgs e)
		{
			this.OkPressed = true;
			this.Value = this.tbValue.Text;
			string[] w = this.tbValue.Text.Trim().Split(new char[] { ' ' });
			if (w.Length <= 3)
			{
				base.Close();
				return;
			}
			MessageBox.Show("Please use keywords not longer than three words!");
			this.tbValue.Text = string.Format("{0} {1}", w[0], w[1]);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00007231 File Offset: 0x00005431
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.OkPressed = false;
			this.Value = "";
			base.Close();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000724B File Offset: 0x0000544B
		private void tbValue_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.btnApply_Click(null, null);
			}
		}

		// Token: 0x0400004D RID: 77
		public bool OkPressed;

		// Token: 0x0400004E RID: 78
		public string Value;
	}
}
