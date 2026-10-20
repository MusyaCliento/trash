using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class gDYdmXcRbRGqzMWytaAjcwbmEdQhA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int lSnsOvLojEqbgcEudaoqeCkozvKD(void* deviceInstance, IntPtr data);

	private readonly IntPtr eEViFCeNrOaxahqAwpnlWbRxfkmzA;

	private readonly lSnsOvLojEqbgcEudaoqeCkozvKD KNHqOgNHQGADoDzJKgEVMjYGzLrd;

	[CompilerGenerated]
	private List<AZqyeRuZfWnySbxPYZDpEXcPZiMi> wqLjNWlzIGelEUwXEwgPwsnyjhlm;

	public IntPtr WiYtXXlgixoLEPFekTUwJtmemuBi => eEViFCeNrOaxahqAwpnlWbRxfkmzA;

	public List<AZqyeRuZfWnySbxPYZDpEXcPZiMi> pzsDhheIGCkjQdeTSKZZOiJiiQVuA
	{
		[CompilerGenerated]
		get
		{
			return wqLjNWlzIGelEUwXEwgPwsnyjhlm;
		}
		[CompilerGenerated]
		private set
		{
			wqLjNWlzIGelEUwXEwgPwsnyjhlm = list;
		}
	}

	public unsafe gDYdmXcRbRGqzMWytaAjcwbmEdQhA()
	{
		KNHqOgNHQGADoDzJKgEVMjYGzLrd = bwYiawjRxgGYqDokpispqaYAAzeU;
		eEViFCeNrOaxahqAwpnlWbRxfkmzA = Marshal.GetFunctionPointerForDelegate(KNHqOgNHQGADoDzJKgEVMjYGzLrd);
		pzsDhheIGCkjQdeTSKZZOiJiiQVuA = new List<AZqyeRuZfWnySbxPYZDpEXcPZiMi>();
	}

	[MonoPInvokeCallback(typeof(lSnsOvLojEqbgcEudaoqeCkozvKD))]
	private unsafe static int bwYiawjRxgGYqDokpispqaYAAzeU(void* P_0, IntPtr P_1)
	{
		uint num = (uint)P_1.ToInt64();
		if (!ObjectInstanceTracker.Default.TryGetInstance<gDYdmXcRbRGqzMWytaAjcwbmEdQhA>(num, out var instance))
		{
			return 1;
		}
		AZqyeRuZfWnySbxPYZDpEXcPZiMi aZqyeRuZfWnySbxPYZDpEXcPZiMi = new AZqyeRuZfWnySbxPYZDpEXcPZiMi();
		aZqyeRuZfWnySbxPYZDpEXcPZiMi.zDQLnzEDDIDJZFIVYnwtsXPpSpZjA(ref *(AZqyeRuZfWnySbxPYZDpEXcPZiMi.NYCIpfFtySkXMztpOCpTOybcOsNs*)P_0);
		instance.pzsDhheIGCkjQdeTSKZZOiJiiQVuA.Add(aZqyeRuZfWnySbxPYZDpEXcPZiMi);
		return 1;
	}
}
