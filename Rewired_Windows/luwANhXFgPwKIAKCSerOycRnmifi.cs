using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class luwANhXFgPwKIAKCSerOycRnmifi
{
	private readonly List<Delegate> kTEAalyXeRHGKzwejpjJZxLZtAAr;

	private readonly IntPtr NszWabOGwsTSBOmTlZrvWHSKTmQf;

	public IntPtr cFHVDRqRhjxqvoKcvjfhcijUcNPS => NszWabOGwsTSBOmTlZrvWHSKTmQf;

	public luwANhXFgPwKIAKCSerOycRnmifi(int P_0)
	{
		NszWabOGwsTSBOmTlZrvWHSKTmQf = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		kTEAalyXeRHGKzwejpjJZxLZtAAr = new List<Delegate>();
	}

	public unsafe void ApagMbiPegeKMMLwUwNAegnvtwjgA(Delegate P_0)
	{
		int count = kTEAalyXeRHGKzwejpjJZxLZtAAr.Count;
		kTEAalyXeRHGKzwejpjJZxLZtAAr.Add(P_0);
		((IntPtr*)(void*)NszWabOGwsTSBOmTlZrvWHSKTmQf)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
