using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ZrQONzGgatNLAtwMcgwdrwLetNOf
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int WzTtTuMzDzNMsENszYfOzTARvvh(void* deviceInstance, IntPtr data);

	private readonly IntPtr DIblsifotwsdUgUNEVWUGHgmULpd;

	private readonly WzTtTuMzDzNMsENszYfOzTARvvh NmuqEfxIFlAvkYTqCmVOplBiFOmD;

	[CompilerGenerated]
	private List<QgrqSMOqqYFSOPQZKTlkfrVCzcS> UzjLldEUJcuATvhVITbAEMaaqajU;

	public IntPtr taSHCnoWRcSNIWKXfIvASjuEBVWv => DIblsifotwsdUgUNEVWUGHgmULpd;

	public List<QgrqSMOqqYFSOPQZKTlkfrVCzcS> WJZBzxsPRMVSEWQYOXfMgVOmJLkb
	{
		[CompilerGenerated]
		get
		{
			return UzjLldEUJcuATvhVITbAEMaaqajU;
		}
		[CompilerGenerated]
		private set
		{
			UzjLldEUJcuATvhVITbAEMaaqajU = uzjLldEUJcuATvhVITbAEMaaqajU;
		}
	}

	public unsafe ZrQONzGgatNLAtwMcgwdrwLetNOf()
	{
		NmuqEfxIFlAvkYTqCmVOplBiFOmD = uXPVQzOinJkWHwjiCaSMCjXDAxOb;
		DIblsifotwsdUgUNEVWUGHgmULpd = Marshal.GetFunctionPointerForDelegate(NmuqEfxIFlAvkYTqCmVOplBiFOmD);
		WJZBzxsPRMVSEWQYOXfMgVOmJLkb = new List<QgrqSMOqqYFSOPQZKTlkfrVCzcS>();
	}

	[MonoPInvokeCallback(typeof(WzTtTuMzDzNMsENszYfOzTARvvh))]
	private unsafe static int uXPVQzOinJkWHwjiCaSMCjXDAxOb(void* P_0, IntPtr P_1)
	{
		uint num = (uint)P_1.ToInt64();
		if (!ObjectInstanceTracker.Default.TryGetInstance<ZrQONzGgatNLAtwMcgwdrwLetNOf>(num, out var instance))
		{
			return 1;
		}
		QgrqSMOqqYFSOPQZKTlkfrVCzcS item = new QgrqSMOqqYFSOPQZKTlkfrVCzcS((IntPtr)P_0);
		instance.WJZBzxsPRMVSEWQYOXfMgVOmJLkb.Add(item);
		return 1;
	}
}
