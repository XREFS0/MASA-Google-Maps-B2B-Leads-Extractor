using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
	// Token: 0x0200002B RID: 43
	[CompilerGenerated]
	[InterfaceType(2)]
	[DefaultMember("_Default")]
	[Guid("00020846-0000-0000-C000-000000000046")]
	[TypeIdentifier]
	[ComImport]
	public interface Range : IEnumerable
	{
		// Token: 0x06000132 RID: 306
		void _VtblGap1_164();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000133 RID: 307
		[DispId(138)]
		object Text
		{
			[DispId(138)]
			[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		// Token: 0x06000134 RID: 308
		void _VtblGap2_8();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000135 RID: 309
		// (set) Token: 0x06000136 RID: 310
		[DispId(6)]
		object Value
		{
			[DispId(6)]
			[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(6)]
			[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[param: MarshalAs(UnmanagedType.Struct)]
			[param: In]
			[param: Optional]
			set;
		}
	}
}
