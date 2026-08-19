using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x02000035 RID: 53
	[CompilerGenerated]
	[Guid("000208D8-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface _Worksheet
	{
		// Token: 0x0600014C RID: 332
		void _VtblGap1_93();

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600014D RID: 333
		[DispId(197)]
		Range Range
		{
			[DispId(197)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		// Token: 0x0600014E RID: 334
		void _VtblGap2_16();

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600014F RID: 335
		[DispId(412)]
		Range UsedRange
		{
			[DispId(412)]
			[LCIDConversion(0)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}
}
