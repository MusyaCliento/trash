using System;
using System.Runtime.InteropServices;

internal class djGIyFAZambadUIzIYqbdPzIsGDy : IDisposable
{
	public struct yNarShAWgLCJQgdfBsJSILsppIAD
	{
		private byte XWPGAhaxevJvXAPbPxXjyjXwYLMr;

		private uint xiKcLXCnKWBixUaOisDRGPbynOGHA;

		private int EVSNfNRWTvUIYFHkGcfdRcfdiIAs;

		private static yNarShAWgLCJQgdfBsJSILsppIAD VUMxvJsMGXeGJYeGgBrRfeTBMDer;

		public byte FAnuaAZJqikTFKdwMoeCwVApmvSR => XWPGAhaxevJvXAPbPxXjyjXwYLMr;

		public uint xawZKhQaeEcHOdBfStpjxwjpWuvGA => xiKcLXCnKWBixUaOisDRGPbynOGHA;

		public int cebemMHloeQDscEIBoEJpxrxNFscc => EVSNfNRWTvUIYFHkGcfdRcfdiIAs;

		public static yNarShAWgLCJQgdfBsJSILsppIAD MfblwveOphsUpgdilyXJsmbCdYIq => VUMxvJsMGXeGJYeGgBrRfeTBMDer;

		public yNarShAWgLCJQgdfBsJSILsppIAD(byte P_0, uint P_1, int P_2)
		{
			XWPGAhaxevJvXAPbPxXjyjXwYLMr = P_0;
			xiKcLXCnKWBixUaOisDRGPbynOGHA = P_1;
			EVSNfNRWTvUIYFHkGcfdRcfdiIAs = P_2;
			if (EVSNfNRWTvUIYFHkGcfdRcfdiIAs < 0)
			{
				EVSNfNRWTvUIYFHkGcfdRcfdiIAs = 0;
			}
		}
	}

	private const byte vqasRbvbwihiyTBofiuccpoMaCCeb = 254;

	private uint FNORMbjCdoTCWknxXfKtNZALqVsG;

	private int yOCCUYSsOcdlLWGmGdJGcTZUdzhxA;

	private unsafe byte* qONuvXPllFHUlNoSIEqvIywBSRqbA;

	private byte gluPwDMwLbashGcraOTXCMiYMvfR;

	private bool MSCCOXgtXMALOYliWoDsFfGiaLbHA;

	private bool QqBvuwgKgKKBXgKLObdhASmufypdA;

	public int CKtBuTIWRBXhURpvSwGHxeNNilrx => yOCCUYSsOcdlLWGmGdJGcTZUdzhxA;

	public unsafe djGIyFAZambadUIzIYqbdPzIsGDy(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		yOCCUYSsOcdlLWGmGdJGcTZUdzhxA = P_0;
		FNORMbjCdoTCWknxXfKtNZALqVsG = 0u;
		qONuvXPllFHUlNoSIEqvIywBSRqbA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool ZgvKyRnaIOGcLBQuINcZcIfCVatQc(IntPtr P_0, int P_1, out yNarShAWgLCJQgdfBsJSILsppIAD P_2)
	{
		if (qONuvXPllFHUlNoSIEqvIywBSRqbA == null || P_1 <= 0)
		{
			P_2 = default(yNarShAWgLCJQgdfBsJSILsppIAD);
			return false;
		}
		if (P_1 > yOCCUYSsOcdlLWGmGdJGcTZUdzhxA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)FNORMbjCdoTCWknxXfKtNZALqVsG + P_1) > yOCCUYSsOcdlLWGmGdJGcTZUdzhxA)
		{
			FNORMbjCdoTCWknxXfKtNZALqVsG = 0u;
			if (gluPwDMwLbashGcraOTXCMiYMvfR == 254)
			{
				gluPwDMwLbashGcraOTXCMiYMvfR = 0;
				MSCCOXgtXMALOYliWoDsFfGiaLbHA = true;
			}
			else
			{
				gluPwDMwLbashGcraOTXCMiYMvfR++;
			}
		}
		AmOfVgHMXtIpYGmFoUHcniSRkMulA.PDcaGQwDgjKryvELYKpZfjZpcRoIA(qONuvXPllFHUlNoSIEqvIywBSRqbA + FNORMbjCdoTCWknxXfKtNZALqVsG, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new yNarShAWgLCJQgdfBsJSILsppIAD(gluPwDMwLbashGcraOTXCMiYMvfR, FNORMbjCdoTCWknxXfKtNZALqVsG, P_1);
		FNORMbjCdoTCWknxXfKtNZALqVsG += (uint)P_1;
		return true;
	}

	public int ttqNmCvjyoaGgLWgxgsFeqHIrJJKA(yNarShAWgLCJQgdfBsJSILsppIAD P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.cebemMHloeQDscEIBoEJpxrxNFscc)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!KhndMDJAooqcoesThhcFpIDdvBEcD(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(zhlkCdPUojpHajoEXzWLXIhzVUrV(P_0), P_1, 0, P_0.cebemMHloeQDscEIBoEJpxrxNFscc);
		return P_0.cebemMHloeQDscEIBoEJpxrxNFscc;
	}

	public unsafe int VsDeUwgsTJnsFJhzJBSlysdQhqlo(yNarShAWgLCJQgdfBsJSILsppIAD P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.cebemMHloeQDscEIBoEJpxrxNFscc)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!KhndMDJAooqcoesThhcFpIDdvBEcD(ref P_0))
		{
			return -1;
		}
		AmOfVgHMXtIpYGmFoUHcniSRkMulA.PDcaGQwDgjKryvELYKpZfjZpcRoIA((void*)P_1, (void*)zhlkCdPUojpHajoEXzWLXIhzVUrV(P_0), new UIntPtr((uint)P_0.cebemMHloeQDscEIBoEJpxrxNFscc));
		return P_0.cebemMHloeQDscEIBoEJpxrxNFscc;
	}

	public unsafe IntPtr zhlkCdPUojpHajoEXzWLXIhzVUrV(yNarShAWgLCJQgdfBsJSILsppIAD P_0)
	{
		if (qONuvXPllFHUlNoSIEqvIywBSRqbA == null || !KhndMDJAooqcoesThhcFpIDdvBEcD(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(qONuvXPllFHUlNoSIEqvIywBSRqbA + P_0.xawZKhQaeEcHOdBfStpjxwjpWuvGA);
	}

	public unsafe bool aJxsLroZiokRwqwGQLWvcdUnXbfp(yNarShAWgLCJQgdfBsJSILsppIAD P_0, out IntPtr P_1)
	{
		if (qONuvXPllFHUlNoSIEqvIywBSRqbA == null || !KhndMDJAooqcoesThhcFpIDdvBEcD(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(qONuvXPllFHUlNoSIEqvIywBSRqbA + P_0.xawZKhQaeEcHOdBfStpjxwjpWuvGA);
		return true;
	}

	private bool KhndMDJAooqcoesThhcFpIDdvBEcD(ref yNarShAWgLCJQgdfBsJSILsppIAD P_0)
	{
		int num = P_0.cebemMHloeQDscEIBoEJpxrxNFscc;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.FAnuaAZJqikTFKdwMoeCwVApmvSR;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != gluPwDMwLbashGcraOTXCMiYMvfR)
		{
			if (!MSCCOXgtXMALOYliWoDsFfGiaLbHA)
			{
				if (num2 + 1 != gluPwDMwLbashGcraOTXCMiYMvfR)
				{
					return false;
				}
			}
			else if (num2 > gluPwDMwLbashGcraOTXCMiYMvfR)
			{
				if (gluPwDMwLbashGcraOTXCMiYMvfR != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != gluPwDMwLbashGcraOTXCMiYMvfR)
			{
				return false;
			}
			if (P_0.xawZKhQaeEcHOdBfStpjxwjpWuvGA < FNORMbjCdoTCWknxXfKtNZALqVsG)
			{
				return false;
			}
		}
		else if (P_0.xawZKhQaeEcHOdBfStpjxwjpWuvGA + num > FNORMbjCdoTCWknxXfKtNZALqVsG)
		{
			return false;
		}
		if (P_0.xawZKhQaeEcHOdBfStpjxwjpWuvGA + num > yOCCUYSsOcdlLWGmGdJGcTZUdzhxA)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		FiQKAfmOOMszUesGtKCezBDutYZu(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void lEpsmuJWAYhhcVKNXaHCgPLTIsOJA()
	{
		try
		{
			FiQKAfmOOMszUesGtKCezBDutYZu(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void FiQKAfmOOMszUesGtKCezBDutYZu(bool P_0)
	{
		if (!QqBvuwgKgKKBXgKLObdhASmufypdA)
		{
			if (qONuvXPllFHUlNoSIEqvIywBSRqbA != null)
			{
				Marshal.FreeHGlobal((IntPtr)qONuvXPllFHUlNoSIEqvIywBSRqbA);
			}
			QqBvuwgKgKKBXgKLObdhASmufypdA = true;
		}
	}
}
