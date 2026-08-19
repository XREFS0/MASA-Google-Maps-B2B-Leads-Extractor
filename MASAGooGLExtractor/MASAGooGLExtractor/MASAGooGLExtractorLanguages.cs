using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x02000016 RID: 22
	public class Languages
	{
		// Token: 0x0600007B RID: 123 RVA: 0x000075B4 File Offset: 0x000057B4
		public void InitFields(string FileName)
		{
			string[] Lines = File.ReadAllLines(FileName);
			this.ExitMessage = Lines[0].Split(new char[] { '*' })[1];
			this.NoFreeProxiesMessage = Lines[1].Split(new char[] { '*' })[1];
			this.DeleteSomeRows = Lines[2].Split(new char[] { '*' })[1];
			this.DeleteAllRows = Lines[3].Split(new char[] { '*' })[1];
			this.TotalProxiesMessage = Lines[4].Split(new char[] { '*' })[1];
			this.WrongCodeMessage = Lines[5].Split(new char[] { '*' })[1];
			this.FullVersionMessage = Lines[6].Split(new char[] { '*' })[1];
			this.MakeSearchFirst = Lines[7].Split(new char[] { '*' })[1];
			this.NoDataToExport = Lines[8].Split(new char[] { '*' })[1];
			this.NoDataSelectedToExport = Lines[9].Split(new char[] { '*' })[1];
			this.WorkIsDone = Lines[10].Split(new char[] { '*' })[1];
			this.StoppedByUser = Lines[11].Split(new char[] { '*' })[1];
			this.FieldsData = new List<string[]>();
			for (int i = this.NbrStaticMessages; i < Lines.Length; i++)
			{
				this.FieldsData.Add(Lines[i].Split(new char[] { '*' }));
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000774C File Offset: 0x0000594C
		public void InitControl(Form Form, Control.ControlCollection Controls)
		{
			foreach (object obj in Controls)
			{
				Control Ctrl = (Control)obj;
				this.SetControlText(Form.Name, Ctrl);
				this.InitControl(Form, Ctrl.Controls);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000077B4 File Offset: 0x000059B4
		private void SetControlText(string FormName, Control Ctrl)
		{
			for (int i = 0; i < this.FieldsData.Count; i++)
			{
				if (this.FieldsData[i][0] == FormName && this.FieldsData[i][1] == Ctrl.Name)
				{
					try
					{
						Ctrl.Text = this.FieldsData[i][2];
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00007834 File Offset: 0x00005A34
		public void InitMenu(MainForm mf)
		{
			foreach (object obj in mf.menuStrip.Items)
			{
				ToolStripItem Item = (ToolStripItem)obj;
				foreach (ToolStripItem tsi in this.GetAllChildren(Item))
				{
					for (int i = 0; i < this.FieldsData.Count; i++)
					{
						if (this.FieldsData[i][0] == "Menu" && tsi.Name == this.FieldsData[i][1])
						{
							tsi.Text = this.FieldsData[i][2];
						}
					}
				}
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00007918 File Offset: 0x00005B18
		public void InitTableColumns(DataGridView dgv)
		{
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn col = (DataGridViewColumn)obj;
				for (int i = 0; i < this.FieldsData.Count; i++)
				{
					if (this.FieldsData[i][0] == "DataGridView" && col.Name == this.FieldsData[i][1])
					{
						col.HeaderText = this.FieldsData[i][2];
					}
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000079CC File Offset: 0x00005BCC
		public void ExportFields(string ExportFileName)
		{
			File.WriteAllText(ExportFileName, "");
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.ExitMessage, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.NoFreeProxiesMessage, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.DeleteSomeRows, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.DeleteAllRows, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.TotalProxiesMessage, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.WrongCodeMessage, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.FullVersionMessage, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.MakeSearchFirst, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.NoDataToExport, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.NoDataSelectedToExport, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.WorkIsDone, Environment.NewLine));
			File.AppendAllText(ExportFileName, string.Format("Messages*{0}*{1}", this.StoppedByUser, Environment.NewLine));
			MainForm mf = new MainForm();
			this.SaveControls(ExportFileName, "MainForm", mf.Controls);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007B40 File Offset: 0x00005D40
		public void SaveControls(string ExportFileName, string FormName, Control.ControlCollection Controls)
		{
			foreach (object obj in Controls)
			{
				Control Ctrl = (Control)obj;
				File.AppendAllText(ExportFileName, string.Format("{0}*{1}*{2}{3}", new object[]
				{
					FormName,
					Ctrl.Name,
					Ctrl.Text,
					Environment.NewLine
				}));
				this.SaveControls(ExportFileName, FormName, Ctrl.Controls);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007BD0 File Offset: 0x00005DD0
		private ToolStripItem[] GetAllChildren(ToolStripItem item)
		{
			List<ToolStripItem> Items = new List<ToolStripItem> { item };
			if (item is ToolStripMenuItem)
			{
				foreach (object obj in ((ToolStripMenuItem)item).DropDownItems)
				{
					ToolStripItem i = (ToolStripItem)obj;
					Items.AddRange(this.GetAllChildren(i));
				}
			}
			if (item is ToolStripSplitButton)
			{
				foreach (object obj2 in ((ToolStripSplitButton)item).DropDownItems)
				{
					ToolStripItem j = (ToolStripItem)obj2;
					Items.AddRange(this.GetAllChildren(j));
				}
			}
			if (item is ToolStripDropDownButton)
			{
				foreach (object obj3 in ((ToolStripDropDownButton)item).DropDownItems)
				{
					ToolStripItem k = (ToolStripItem)obj3;
					Items.AddRange(this.GetAllChildren(k));
				}
			}
			IL_0101:
			return Items.ToArray();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007D0C File Offset: 0x00005F0C
		public void SaveMenuItems(string ExportFileName, ToolStripItemCollection ItemsCollection)
		{
			foreach (object obj in ItemsCollection)
			{
				ToolStripItem Item = (ToolStripItem)obj;
				foreach (ToolStripItem tsi in this.GetAllChildren(Item))
				{
					File.AppendAllText(ExportFileName, string.Format("{0}*{1}*{2}{3}", new object[]
					{
						"Menu",
						tsi.Name,
						tsi.Text,
						Environment.NewLine
					}));
				}
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00007DB4 File Offset: 0x00005FB4
		public void SaveTableColumns(string ExportFileName, DataGridView dgv)
		{
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn col = (DataGridViewColumn)obj;
				File.AppendAllText(ExportFileName, string.Format("{0}*{1}*{2}{3}", new object[]
				{
					"DataGridView",
					col.Name,
					col.HeaderText,
					Environment.NewLine
				}));
			}
		}

		// Token: 0x04000054 RID: 84
		public string ExitMessage = "Do you really want to exit?";

		// Token: 0x04000055 RID: 85
		public string NoFreeProxiesMessage = "No one working free proxy server available!";

		// Token: 0x04000056 RID: 86
		public string DeleteSomeRows = "Do you really want to delete {0} rows from list?";

		// Token: 0x04000057 RID: 87
		public string DeleteAllRows = "Do you really want to delete all rows from list?";

		// Token: 0x04000058 RID: 88
		public string TotalProxiesMessage = "Total proxies {0}, checked {1}, available {2}";

		// Token: 0x04000059 RID: 89
		public string WrongCodeMessage = "Wrong code or email. Please try again!";

		// Token: 0x0400005A RID: 90
		public string FullVersionMessage = "To extract unlimited data upgrade to the full version of MASA GooGle Extractor. Do you want to buy the full version now?";

		// Token: 0x0400005B RID: 91
		public string MakeSearchFirst = "Please make first the search you want and click on GET DATA only after the results appears in the page";

		// Token: 0x0400005C RID: 92
		public string NoDataToExport = "No data to export. Please make first the search and then click on GET DATA";

		// Token: 0x0400005D RID: 93
		public string NoDataSelectedToExport = "No data is selected to export. Please make first the selection and then click on Export";

		// Token: 0x0400005E RID: 94
		public string WorkIsDone = "Processing is done!";

		// Token: 0x0400005F RID: 95
		public string StoppedByUser = "Stopped by user!";

		// Token: 0x04000060 RID: 96
		public string SelectCategory = "Please select category!";

		// Token: 0x04000061 RID: 97
		public string DeleteCategory = "Do you really want to delete '{0}'?";

		// Token: 0x04000062 RID: 98
		private int NbrStaticMessages = 12;

		// Token: 0x04000063 RID: 99
		public List<string[]> FieldsData;
	}
}
