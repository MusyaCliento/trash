using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class RSYrdLqBRBUWZFsknAbGcjrxavSp
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int LoMPVHIjgsVfvgBAxHXkJiKkHpHe(void* deviceInstance, IntPtr data);

	private readonly IntPtr JMDMekoBDqdJrdGUoQjBFgLbYCDHA;

	private readonly LoMPVHIjgsVfvgBAxHXkJiKkHpHe hbJyoeCSEmPnCQomjGdcFxQxmDXpA;

	[CompilerGenerated]
	private List<dWyxBkIUPMORAuPdNMABdUWdAyFH> kewqbMElkxEqrOKyhFHmIoMlgumCA;

	public IntPtr VaXgVHIHvxlbaqiHdvcCaOMdcmmcA => JMDMekoBDqdJrdGUoQjBFgLbYCDHA;

	public List<dWyxBkIUPMORAuPdNMABdUWdAyFH> iIEjXAiAnRkHxKcieBvCanDAbtYxA
	{
		[CompilerGenerated]
		get
		{
			return kewqbMElkxEqrOKyhFHmIoMlgumCA;
		}
		[CompilerGenerated]
		private set
		{
			kewqbMElkxEqrOKyhFHmIoMlgumCA = list;
		}
	}

	public unsafe RSYrdLqBRBUWZFsknAbGcjrxavSp()
	{
		hbJyoeCSEmPnCQomjGdcFxQxmDXpA = TocGnyAdpQWcLpLybnxudZcGzLIJb;
		JMDMekoBDqdJrdGUoQjBFgLbYCDHA = Marshal.GetFunctionPointerForDelegate(hbJyoeCSEmPnCQomjGdcFxQxmDXpA);
		iIEjXAiAnRkHxKcieBvCanDAbtYxA = new List<dWyxBkIUPMORAuPdNMABdUWdAyFH>();
	}

	[MonoPInvokeCallback(typeof(LoMPVHIjgsVfvgBAxHXkJiKkHpHe))]
	private unsafe static int TocGnyAdpQWcLpLybnxudZcGzLIJb(void* P_0, IntPtr P_1)
	{
		uint num = (uint)P_1.ToInt64();
		if (!ObjectInstanceTracker.Default.TryGetInstance<RSYrdLqBRBUWZFsknAbGcjrxavSp>(num, out var instance))
		{
			return 1;
		}
		dWyxBkIUPMORAuPdNMABdUWdAyFH dWyxBkIUPMORAuPdNMABdUWdAyFH2 = new dWyxBkIUPMORAuPdNMABdUWdAyFH();
		dWyxBkIUPMORAuPdNMABdUWdAyFH2.yIRLgmEYzQxyDsCPDWwvrbtzONtH(ref *(dWyxBkIUPMORAuPdNMABdUWdAyFH.KcdWWfJadrIdKaNXmxjGLFmvgcRm*)P_0);
		instance.iIEjXAiAnRkHxKcieBvCanDAbtYxA.Add(dWyxBkIUPMORAuPdNMABdUWdAyFH2);
		return 1;
	}
}
