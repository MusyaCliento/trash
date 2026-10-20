using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class RhtwDGQpZaUZVHbFDHmQaykKTsygA : REYJaDSdDqBpROueuJhqXXpeIXgr
{
	[CompilerGenerated]
	private hXWNLjfvEurhyFoQbzwoguEGVaLG[] VkjjKqEtSuAbtyLUcBKyLJfTVyLh;

	public hXWNLjfvEurhyFoQbzwoguEGVaLG[] MrkfDGOBZcjSijXCsUyvKMDXSNlv
	{
		[CompilerGenerated]
		get
		{
			return VkjjKqEtSuAbtyLUcBKyLJfTVyLh;
		}
		[CompilerGenerated]
		set
		{
			VkjjKqEtSuAbtyLUcBKyLJfTVyLh = vkjjKqEtSuAbtyLUcBKyLJfTVyLh;
		}
	}

	unsafe int REYJaDSdDqBpROueuJhqXXpeIXgr.rSTkUSzzjrwGclYIqAQbcnCcgaOl
	{
		get
		{
			if (MrkfDGOBZcjSijXCsUyvKMDXSNlv == null)
			{
				return 0;
			}
			return MrkfDGOBZcjSijXCsUyvKMDXSNlv.Length * sizeof(hXWNLjfvEurhyFoQbzwoguEGVaLG);
		}
	}

	protected unsafe virtual REYJaDSdDqBpROueuJhqXXpeIXgr eqfvzDZjoeHxnOjgOcMgIBJEGsPkA(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(hXWNLjfvEurhyFoQbzwoguEGVaLG) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(hXWNLjfvEurhyFoQbzwoguEGVaLG);
		MrkfDGOBZcjSijXCsUyvKMDXSNlv = new hXWNLjfvEurhyFoQbzwoguEGVaLG[num];
		fixed (hXWNLjfvEurhyFoQbzwoguEGVaLG* ptr = MrkfDGOBZcjSijXCsUyvKMDXSNlv)
		{
			hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.LoGxypjLRcGaXLdHUzHpqphkLtMN((IntPtr)ptr, P_1, hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.mEwPgRNNMPvZMwAMACZigplGyyfDA<hXWNLjfvEurhyFoQbzwoguEGVaLG>() * MrkfDGOBZcjSijXCsUyvKMDXSNlv.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr bmigKVJagVNXiFyyWBjYhqzTsryZ()
	{
		if (rSTkUSzzjrwGclYIqAQbcnCcgaOl == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(rSTkUSzzjrwGclYIqAQbcnCcgaOl);
		fixed (hXWNLjfvEurhyFoQbzwoguEGVaLG* ptr = MrkfDGOBZcjSijXCsUyvKMDXSNlv)
		{
			hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.LoGxypjLRcGaXLdHUzHpqphkLtMN(intPtr, (IntPtr)ptr, hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.mEwPgRNNMPvZMwAMACZigplGyyfDA<hXWNLjfvEurhyFoQbzwoguEGVaLG>() * MrkfDGOBZcjSijXCsUyvKMDXSNlv.Length);
		}
		return intPtr;
	}
}
