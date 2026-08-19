using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MASAGooGLExtractor
{
	// Token: 0x0200000F RID: 15
	public static class ExportManager
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004014 File Offset: 0x00002214
		private static bool CheckSystemResources()
		{
			return true;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000409C File Offset: 0x0000229C
		public static void InitHeader(DataGridView dgv)
		{
			ExportManager.Columns = new List<string>();
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				ExportManager.Columns.Add(dgv.Columns[i].HeaderText);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000040E4 File Offset: 0x000022E4
		public static string BuildCSVLine(Settings AppSettings, DataGridView dgv, int RowIndex)
		{
			string Line = "";
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				string Value = "";
				try
				{
					Value = dgv.Rows[RowIndex].Cells[i].Value.ToString();
				}
				catch
				{
				}
				if (AppSettings.ColumnsToExport[i])
				{
					Line += string.Format("\"{0}\"{1}", Value, ExportManager.CSVDelimiters[AppSettings.CSVDelimiter]);
				}
			}
			if (Line.Length > 0)
			{
				Line = Line.Substring(0, Line.Length - 1) + Environment.NewLine;
			}
			return Line;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004198 File Offset: 0x00002398
		public static void SaveToCSV(Settings AppSettings, string FileName, DataGridView dgv)
		{
			ExportManager.InitHeader(dgv);
			Encoding FileEncoding = Encoding.UTF8;
			if (AppSettings.CSVEncoding == 0)
			{
				FileEncoding = Encoding.ASCII;
			}
			else if (AppSettings.CSVEncoding == 1)
			{
				FileEncoding = Encoding.UTF7;
			}
			else if (AppSettings.CSVEncoding == 2)
			{
				FileEncoding = Encoding.UTF8;
			}
			File.WriteAllText(FileName, "", FileEncoding);
			string Line = "";
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				if (AppSettings.ColumnsToExport[i])
				{
					Line += string.Format("{0}{1}", ExportManager.Columns[i], ExportManager.CSVDelimiters[AppSettings.CSVDelimiter]);
				}
			}
			if (Line.Length > 0)
			{
				Line = Line.Substring(0, Line.Length - 1) + Environment.NewLine;
			}
			File.AppendAllText(FileName, Line);
			if (dgv.SelectedRows.Count > 0)
			{
				for (int j = 0; j < dgv.SelectedRows.Count; j++)
				{
					File.AppendAllText(FileName, ExportManager.BuildCSVLine(AppSettings, dgv, dgv.SelectedRows[dgv.SelectedRows.Count - 1 - j].Index), FileEncoding);
				}
				return;
			}
			for (int k = 0; k < dgv.Rows.Count; k++)
			{
				File.AppendAllText(FileName, ExportManager.BuildCSVLine(AppSettings, dgv, k), FileEncoding);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000042E4 File Offset: 0x000024E4
		public static void SaveToXLS(Settings AppSettings, string FileName, DataGridView dgv)
		{
			ExportManager.InitHeader(dgv);
			ExcelDocument doc = new ExcelDocument();
			doc.Create();
			int ColIndex = 0;
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				if (AppSettings.ColumnsToExport[i])
				{
					doc.SetCellValue(0, ColIndex, ExportManager.Columns[i]);
					ColIndex++;
				}
			}
			if (dgv.SelectedRows.Count > 0)
			{
				for (int j = 0; j < dgv.SelectedRows.Count; j++)
				{
					ColIndex = 0;
					for (int k = 0; k < dgv.Columns.Count; k++)
					{
						if (AppSettings.ColumnsToExport[k])
						{
							string Value = "";
							try
							{
								Value = dgv.Rows[dgv.SelectedRows[dgv.SelectedRows.Count - 1 - j].Index].Cells[k].Value.ToString();
							}
							catch
							{
							}
							doc.SetCellValue(j + 1, ColIndex, Value);
							ColIndex++;
						}
					}
				}
			}
			else
			{
				for (int l = 0; l < dgv.Rows.Count; l++)
				{
					ColIndex = 0;
					for (int m = 0; m < dgv.Columns.Count; m++)
					{
						if (AppSettings.ColumnsToExport[m])
						{
							string Value2 = "";
							try
							{
								Value2 = dgv.Rows[l].Cells[m].Value.ToString();
							}
							catch
							{
							}
							doc.SetCellValue(l + 1, ColIndex, Value2);
							ColIndex++;
						}
					}
				}
			}
			doc.Save(FileName);
			doc.Close();
		}

		// Token: 0x04000020 RID: 32
		private static List<string> Columns;

		// Token: 0x04000021 RID: 33
		private static string[] CSVDelimiters = new string[] { ",", ";" };
	}
}
