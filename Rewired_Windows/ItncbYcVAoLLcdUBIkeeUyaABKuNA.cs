using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ItncbYcVAoLLcdUBIkeeUyaABKuNA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int dAEMvHSyKvfXYxkxWdYNfepZBYaG(void* deviceInstance, IntPtr data);

	private readonly IntPtr nWDzDCeDvkiOSoyzpPzPOOPkfRWR;

	private readonly dAEMvHSyKvfXYxkxWdYNfepZBYaG vMFiScfiOgnutLSceuxDMqIGQKRt;

	[CompilerGenerated]
	private List<UTyQEMVineRQmjtixsdHzIMSbUZe> wbVjGZCKitphdtzgHjDXwHijNcc;

	public IntPtr OmMTEqgDvnbTXjWsTXodbiXkyORN => nWDzDCeDvkiOSoyzpPzPOOPkfRWR;

	public List<UTyQEMVineRQmjtixsdHzIMSbUZe> acDfpRDhtsPCnzcocHJDEFbkNncFB
	{
		[CompilerGenerated]
		get
		{
			return wbVjGZCKitphdtzgHjDXwHijNcc;
		}
		[CompilerGenerated]
		private set
		{
			wbVjGZCKitphdtzgHjDXwHijNcc = list;
		}
	}

	public unsafe ItncbYcVAoLLcdUBIkeeUyaABKuNA()
	{
		vMFiScfiOgnutLSceuxDMqIGQKRt = LXAZqKobXVEHrhFGAkkZluXiMrYG;
		nWDzDCeDvkiOSoyzpPzPOOPkfRWR = Marshal.GetFunctionPointerForDelegate(vMFiScfiOgnutLSceuxDMqIGQKRt);
		acDfpRDhtsPCnzcocHJDEFbkNncFB = new List<UTyQEMVineRQmjtixsdHzIMSbUZe>();
	}

	[MonoPInvokeCallback(typeof(dAEMvHSyKvfXYxkxWdYNfepZBYaG))]
	private unsafe static int LXAZqKobXVEHrhFGAkkZluXiMrYG(void* P_0, IntPtr P_1)
	{
		uint num = (uint)P_1.ToInt64();
		if (!ObjectInstanceTracker.Default.TryGetInstance<ItncbYcVAoLLcdUBIkeeUyaABKuNA>(num, out var instance))
		{
			return 1;
		}
		UTyQEMVineRQmjtixsdHzIMSbUZe uTyQEMVineRQmjtixsdHzIMSbUZe = new UTyQEMVineRQmjtixsdHzIMSbUZe();
		uTyQEMVineRQmjtixsdHzIMSbUZe.CeZExzHxoXeGRmWOyDWobJRELzDzA(ref *(UTyQEMVineRQmjtixsdHzIMSbUZe.DkKByMeFaNJenggqpnONDMcJYEabA*)P_0);
		instance.acDfpRDhtsPCnzcocHJDEFbkNncFB.Add(uTyQEMVineRQmjtixsdHzIMSbUZe);
		return 1;
	}
}
