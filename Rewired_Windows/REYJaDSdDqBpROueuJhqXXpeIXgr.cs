using System;
using System.Runtime.InteropServices;

internal class REYJaDSdDqBpROueuJhqXXpeIXgr
{
	private int tIogMsASmYMALhGyWyVcnehMexXz;

	private byte[] qVaMVWNXzKmMlanFuUTByrPstWRG;

	public virtual int rSTkUSzzjrwGclYIqAQbcnCcgaOl => tIogMsASmYMALhGyWyVcnehMexXz;

	protected REYJaDSdDqBpROueuJhqXXpeIXgr()
	{
	}

	internal REYJaDSdDqBpROueuJhqXXpeIXgr(int P_0, IntPtr P_1)
	{
		cpOSHNeMeyIMioXjfqkyrgpQocCx(P_0, P_1);
	}

	private unsafe void cpOSHNeMeyIMioXjfqkyrgpQocCx(int P_0, IntPtr P_1)
	{
		tIogMsASmYMALhGyWyVcnehMexXz = P_0;
		if (tIogMsASmYMALhGyWyVcnehMexXz > 0 && P_1 != IntPtr.Zero)
		{
			qVaMVWNXzKmMlanFuUTByrPstWRG = new byte[P_0];
			fixed (byte* ptr = qVaMVWNXzKmMlanFuUTByrPstWRG)
			{
				hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.LoGxypjLRcGaXLdHUzHpqphkLtMN((IntPtr)ptr, P_1, tIogMsASmYMALhGyWyVcnehMexXz);
			}
		}
	}

	protected virtual REYJaDSdDqBpROueuJhqXXpeIXgr oyFsjMxnIrfSyCWiTzrMegAPQdscA(int P_0, IntPtr P_1)
	{
		cpOSHNeMeyIMioXjfqkyrgpQocCx(P_0, P_1);
		return this;
	}

	internal virtual void PAlAefIcWqeHfKIQOmoGdADGzSMcA(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr aFpJgQOMaVFeaqIGjFlafsbXictFb()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (tIogMsASmYMALhGyWyVcnehMexXz > 0 && qVaMVWNXzKmMlanFuUTByrPstWRG != null)
		{
			intPtr = Marshal.AllocHGlobal(tIogMsASmYMALhGyWyVcnehMexXz);
			fixed (byte* ptr = qVaMVWNXzKmMlanFuUTByrPstWRG)
			{
				hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.LoGxypjLRcGaXLdHUzHpqphkLtMN(intPtr, (IntPtr)ptr, tIogMsASmYMALhGyWyVcnehMexXz);
			}
		}
		return intPtr;
	}

	public unsafe _0001 ajgeGMrqeUbCGyXWACfUIGfyxmyG<_0001>() where _0001 : REYJaDSdDqBpROueuJhqXXpeIXgr, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(REYJaDSdDqBpROueuJhqXXpeIXgr))
		{
			fixed (byte* ptr = qVaMVWNXzKmMlanFuUTByrPstWRG)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().oyFsjMxnIrfSyCWiTzrMegAPQdscA(tIogMsASmYMALhGyWyVcnehMexXz, (IntPtr)ptr2);
			}
		}
		return null;
	}
}
