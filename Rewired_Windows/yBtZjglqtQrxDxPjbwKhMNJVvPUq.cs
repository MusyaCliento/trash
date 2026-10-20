using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class yBtZjglqtQrxDxPjbwKhMNJVvPUq
{
	public const int DTlWUEgNGgxHvBEttzZaxNOfltZS = 2048;

	public unsafe static void QtXeiIbpUmZeUGejSVnLItzolZUp(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, JEPfEYCraEjyIblcOXJPfjvhhVibb P_4)
	{
		ODBkpHGZcyWAItrLDpQFFHyigEXy oDBkpHGZcyWAItrLDpQFFHyigEXy;
		fixed (IntPtr* ptr = &P_3)
		{
			void* ptr2 = ptr;
			oDBkpHGZcyWAItrLDpQFFHyigEXy = ODBkpHGZcyWAItrLDpQFFHyigEXy.yLXqJgCeluFvRuFNRWXmEMXKjPZN(RhtpvMQoQhvBitbdSCsXqflFaRdcA((void*)P_0, P_1, &P_2, ptr2, (void*)(P_4?.jZMLhMmNWgZQKiIdvGxNhEuSjsYr ?? IntPtr.Zero)));
		}
		oDBkpHGZcyWAItrLDpQFFHyigEXy.KedPhLHboCNMpIFBtgFPavTMyGuq();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RhtpvMQoQhvBitbdSCsXqflFaRdcA(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
