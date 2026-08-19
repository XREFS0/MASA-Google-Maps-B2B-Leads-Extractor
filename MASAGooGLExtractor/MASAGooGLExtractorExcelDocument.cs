using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;

// Token: 0x02000005 RID: 5
public class ExcelDocument
{
	// Token: 0x0600000E RID: 14 RVA: 0x000023E4 File Offset: 0x000005E4
	public ExcelDocument()
	{
		this.excelApp = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		this.excelApp.Visible = false;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002418 File Offset: 0x00000618
	public void Open(string FileName)
	{
		this.excelWorkbook = this.excelApp.Workbooks.Open(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
		this.excelWorksheet = (Worksheet)((dynamic)this.excelWorkbook.Worksheets)[1];
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000024E0 File Offset: 0x000006E0
	public void Create()
	{
		this.excelWorkbook = this.excelApp.Workbooks.Add(Type.Missing);
		this.excelWorksheet = (Worksheet)((dynamic)this.excelWorkbook.Worksheets)[1];
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002564 File Offset: 0x00000764
	public void Save(string FileName)
	{
		try
		{
			this.excelWorkbook.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
		}
		catch
		{
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000025C8 File Offset: 0x000007C8
	public string GetCellValue(int Row, int Col)
	{
		string Value = "error";
		try
		{
			string CellName = string.Format("{0}{1}", (char)(65 + Col), 1 + Row);
			dynamic Range = ((dynamic)this.excelWorksheet).Range[CellName];
			object textValue = Range.Text;
			if (textValue != null)
			{
				Value = textValue.ToString().Trim();
			}
		}
		catch
		{
		}
		return Value;
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000026B4 File Offset: 0x000008B4
	public void SetCellValue(int Row, int Col, string Value)
	{
		string CellName = string.Format("{0}{1}", (char)(65 + Col), 1 + Row);
		Range range = ((dynamic)this.excelWorksheet).Range[CellName];
		if (Value.Length < 10)
		{
			Value = Value.Replace(",", ".");
		}
		range.Value = Value;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002716 File Offset: 0x00000916
	public Range GetUsedRange()
	{
		return this.excelWorksheet.UsedRange;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002724 File Offset: 0x00000924
	public void SetWorksheet(int Index)
	{
		this.excelWorksheet = (Worksheet)((dynamic)this.excelWorkbook.Worksheets)[Index];
	}

	// Token: 0x06000016 RID: 22 RVA: 0x0000278C File Offset: 0x0000098C
	public void Close()
	{
		this.excelWorkbook.Close(true, Missing.Value, Missing.Value);
		this.excelApp.Quit();
		this.ReleaseObject(this.excelWorksheet);
		this.ReleaseObject(this.excelWorkbook);
		this.ReleaseObject(this.excelApp);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000027E4 File Offset: 0x000009E4
	private void ReleaseObject(object obj)
	{
		try
		{
			Marshal.ReleaseComObject(obj);
			obj = null;
		}
		catch
		{
			obj = null;
		}
		finally
		{
			GC.Collect();
		}
	}

	// Token: 0x04000008 RID: 8
	private Application excelApp;

	// Token: 0x04000009 RID: 9
	private Workbook excelWorkbook;

	// Token: 0x0400000A RID: 10
	private Worksheet excelWorksheet;
}
