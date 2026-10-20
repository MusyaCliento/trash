using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class FwSmjzeEGJTlvIrgEhrMknbMtsVE
{
	public unsafe static int DyZHeDUdcXEgbEavawdzooRyeAajA(kizRvorWUKVAMIsDgNoQcxCBBUhd[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (kizRvorWUKVAMIsDgNoQcxCBBUhd* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = UlNGYMqVahDkWTtMZXDRzDsmPgqG(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UlNGYMqVahDkWTtMZXDRzDsmPgqG(void* P_0, void* P_1, int P_2);

	public unsafe static int JTcfNBfWeVIHjSdzhdKjeyqtRJwiA(eFYwFbrXNDGTxgmbVXqCwcBeDcKK[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (eFYwFbrXNDGTxgmbVXqCwcBeDcKK* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = nUgkRaDAqSEbZEdGOezthSNpealYA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nUgkRaDAqSEbZEdGOezthSNpealYA(void* P_0, void* P_1, int P_2);

	public unsafe static int TfgZIvXhrLGeuAGPYOoDzinImGktA(IntPtr P_0, KqqcAxFbSHuxleQYjwVegYVbNClc P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = tzwEDUEkUZNSWXrLYsfmUwErtNBK((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tzwEDUEkUZNSWXrLYsfmUwErtNBK(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static YtZbTuQWOhHtiIzeVCefDxzcOtoOc IZEtKkljlUiZjksSHATmAtavJWJcb(eFYwFbrXNDGTxgmbVXqCwcBeDcKK[] P_0, int P_1, int P_2)
	{
		YtZbTuQWOhHtiIzeVCefDxzcOtoOc result;
		fixed (eFYwFbrXNDGTxgmbVXqCwcBeDcKK* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = RAxYjCZfmjUXhEwWyOSxuiaFCtbp(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern YtZbTuQWOhHtiIzeVCefDxzcOtoOc RAxYjCZfmjUXhEwWyOSxuiaFCtbp(void* P_0, int P_1, int P_2);

	public unsafe static int rJCaMPGAcnDlbcEHoKEISoBKkaJhb(EltlQhdYLUUxvwYvQKiAkWTaCQme[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (EltlQhdYLUUxvwYvQKiAkWTaCQme* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = HseNMxfhMwValyrRicAuKFFnKmrR(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HseNMxfhMwValyrRicAuKFFnKmrR(void* P_0, void* P_1, int P_2);

	public unsafe static int AEEqUlyIQGRmjfRcPhbiVmPydqWC(IntPtr P_0, PwFeNUIjphRhxULGNtcobSZHFCLOA P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = tFZYNqYIokMBrzIBILQcNdbcubhT((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tFZYNqYIokMBrzIBILQcNdbcubhT(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
