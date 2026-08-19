using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000033 RID: 51
	[CompilerGenerated]
	[DefaultMember("_Default")]
	[Guid("000208D5-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Application
	{
		// Token: 0x0600013D RID: 317
		void _VtblGap1_45();

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600013E RID: 318
		[DispId(572)]
		Workbooks Workbooks
		{
			[DispId(572)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		// Token: 0x0600013F RID: 319
		void _VtblGap2_60();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000140 RID: 320
		[DispId(0)]
		string _Default
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		// Token: 0x06000141 RID: 321
		void _VtblGap3_116();

		// Token: 0x06000142 RID: 322
		[DispId(302)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Quit();

		// Token: 0x06000143 RID: 323
		void _VtblGap4_51();

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000144 RID: 324
		// (set) Token: 0x06000145 RID: 325
		[DispId(558)]
		bool Visible
		{
			[LCIDConversion(0)]
			[DispId(558)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			get;
			[LCIDConversion(0)]
			[DispId(558)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[param: In]
			set;
		}
	}
}
