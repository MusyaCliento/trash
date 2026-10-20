using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class GMUDrtaChHLXjxAfEqYMXduSoFXEA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int IiRUIfODTzDREmGAdHtaaHvjDHMEA(void* deviceInstance, IntPtr data);

	private readonly IntPtr MrjmSDqamXvRDXfOkctLcKZAQUyiA;

	private readonly IiRUIfODTzDREmGAdHtaaHvjDHMEA TqcZyCmuLZfwodpWGEVtCzJCHAvI;

	[CompilerGenerated]
	private List<HDSSdntHgkocEHHsUBbJYPhgiSIO> KgyPMnZPyfsQMbVMNyMfTfxBTZiG;

	public IntPtr vPSYAGhagQsiUAsgTTPmHIUIBakl => MrjmSDqamXvRDXfOkctLcKZAQUyiA;

	public List<HDSSdntHgkocEHHsUBbJYPhgiSIO> SwWqBYFNOvSkvMgsbMRbvJWhAEhHA
	{
		[CompilerGenerated]
		get
		{
			return KgyPMnZPyfsQMbVMNyMfTfxBTZiG;
		}
		[CompilerGenerated]
		private set
		{
			KgyPMnZPyfsQMbVMNyMfTfxBTZiG = kgyPMnZPyfsQMbVMNyMfTfxBTZiG;
		}
	}

	public unsafe GMUDrtaChHLXjxAfEqYMXduSoFXEA()
	{
		TqcZyCmuLZfwodpWGEVtCzJCHAvI = zQYZvdNKhNCbuKsYUMDlokObQAvB;
		MrjmSDqamXvRDXfOkctLcKZAQUyiA = Marshal.GetFunctionPointerForDelegate(TqcZyCmuLZfwodpWGEVtCzJCHAvI);
		SwWqBYFNOvSkvMgsbMRbvJWhAEhHA = new List<HDSSdntHgkocEHHsUBbJYPhgiSIO>();
	}

	[MonoPInvokeCallback(typeof(IiRUIfODTzDREmGAdHtaaHvjDHMEA))]
	private unsafe static int zQYZvdNKhNCbuKsYUMDlokObQAvB(void* P_0, IntPtr P_1)
	{
		uint num = (uint)P_1.ToInt64();
		if (!ObjectInstanceTracker.Default.TryGetInstance<GMUDrtaChHLXjxAfEqYMXduSoFXEA>(num, out var instance))
		{
			return 1;
		}
		HDSSdntHgkocEHHsUBbJYPhgiSIO hDSSdntHgkocEHHsUBbJYPhgiSIO = new HDSSdntHgkocEHHsUBbJYPhgiSIO();
		hDSSdntHgkocEHHsUBbJYPhgiSIO.nIitYEQuBiKEIufvBaUCTSgOxEzM(ref *(HDSSdntHgkocEHHsUBbJYPhgiSIO.bqeEnjuCGgaKeMPdbKyJlnsoXlAg*)P_0);
		instance.SwWqBYFNOvSkvMgsbMRbvJWhAEhHA.Add(hDSSdntHgkocEHHsUBbJYPhgiSIO);
		return 1;
	}
}
