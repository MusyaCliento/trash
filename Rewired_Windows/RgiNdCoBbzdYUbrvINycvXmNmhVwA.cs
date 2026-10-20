using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class RgiNdCoBbzdYUbrvINycvXmNmhVwA : TWYqwsMBlQVsaEdinQLMfvcVpSSr
{
	private readonly Dictionary<Guid, GwVyGxyzvxDGqtMfMizVHmPhOvMj> GuixBxoSrwTOAbemaGgCXPNKlNht = new Dictionary<Guid, GwVyGxyzvxDGqtMfMizVHmPhOvMj>();

	private static readonly Dictionary<Type, List<Type>> OGCEJqAHlfjbwmGugWGsKkSJHHkEb = new Dictionary<Type, List<Type>>();

	private IntPtr HvsrQnQWmQpQFcbTLOvzXkDIDaIz;

	[CompilerGenerated]
	private IntPtr[] WxYhJCNOmxETKBNkfgwhBSjIvkLo;

	public IntPtr[] UGSgiyAbdbkivRDKGzPEJWMcQsaIA
	{
		[CompilerGenerated]
		get
		{
			return WxYhJCNOmxETKBNkfgwhBSjIvkLo;
		}
		[CompilerGenerated]
		private set
		{
			WxYhJCNOmxETKBNkfgwhBSjIvkLo = wxYhJCNOmxETKBNkfgwhBSjIvkLo;
		}
	}

	public void jwrKPVYlpBvMDYCMkttgsCGdEMdn(ecJDfCJXiRmIcfcafmnTxhmIeuyJ P_0)
	{
		P_0.dRJUaKtTCekuevryAKUrstEtArMo = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (OGCEJqAHlfjbwmGugWGsKkSJHHkEb)
		{
			if (!OGCEJqAHlfjbwmGugWGsKkSJHHkEb.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				OGCEJqAHlfjbwmGugWGsKkSJHHkEb.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (fznKCAuiqyNCMrtQvOeVLEbOKSYP.aTieVQygQFzooQmxoUfKgsBZRZFo(type2) == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					foreach (Type item in interfaces2)
					{
						value.Remove(item);
					}
				}
			}
		}
		GwVyGxyzvxDGqtMfMizVHmPhOvMj gwVyGxyzvxDGqtMfMizVHmPhOvMj = null;
		foreach (Type item2 in value)
		{
			GwVyGxyzvxDGqtMfMizVHmPhOvMj gwVyGxyzvxDGqtMfMizVHmPhOvMj2 = (GwVyGxyzvxDGqtMfMizVHmPhOvMj)Activator.CreateInstance(fznKCAuiqyNCMrtQvOeVLEbOKSYP.aTieVQygQFzooQmxoUfKgsBZRZFo(item2).UvaiVhDTcbmlDKaDXqAWEhsdgSnY);
			gwVyGxyzvxDGqtMfMizVHmPhOvMj2.wbElmFIiNMjYFcvCzdIGlfekLZCq(P_0);
			if (gwVyGxyzvxDGqtMfMizVHmPhOvMj == null)
			{
				gwVyGxyzvxDGqtMfMizVHmPhOvMj = gwVyGxyzvxDGqtMfMizVHmPhOvMj2;
				GuixBxoSrwTOAbemaGgCXPNKlNht.Add(soEeMRblAQxDboGbfEEWuWthcwST.VTCXLrrVjARCJMCMSoKzmlsYpVKp, gwVyGxyzvxDGqtMfMizVHmPhOvMj);
			}
			GuixBxoSrwTOAbemaGgCXPNKlNht.Add(hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.aVvZpkHAjhRytXPLrQnEebesqRSj(item2), gwVyGxyzvxDGqtMfMizVHmPhOvMj2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (fznKCAuiqyNCMrtQvOeVLEbOKSYP.aTieVQygQFzooQmxoUfKgsBZRZFo(type3) != null)
				{
					GuixBxoSrwTOAbemaGgCXPNKlNht.Add(hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.aVvZpkHAjhRytXPLrQnEebesqRSj(type3), gwVyGxyzvxDGqtMfMizVHmPhOvMj2);
				}
			}
		}
	}

	internal IntPtr zTVLYENQEenyMnbTexZicEQzQqhM(Type P_0)
	{
		return pozPetUPSvwJbADKxDnyHRtJpJaAb(hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.aVvZpkHAjhRytXPLrQnEebesqRSj(P_0));
	}

	internal IntPtr pozPetUPSvwJbADKxDnyHRtJpJaAb(Guid P_0)
	{
		return YViLsFpmSIdGfgPKyjEwcWyCavOIb(P_0)?.jZMLhMmNWgZQKiIdvGxNhEuSjsYr ?? IntPtr.Zero;
	}

	internal GwVyGxyzvxDGqtMfMizVHmPhOvMj YViLsFpmSIdGfgPKyjEwcWyCavOIb(Guid P_0)
	{
		GuixBxoSrwTOAbemaGgCXPNKlNht.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void DmXCaldACtMFktIgaRiRTxfKkgqpA(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (GwVyGxyzvxDGqtMfMizVHmPhOvMj value in GuixBxoSrwTOAbemaGgCXPNKlNht.Values)
		{
			value.Dispose();
		}
		GuixBxoSrwTOAbemaGgCXPNKlNht.Clear();
		if (HvsrQnQWmQpQFcbTLOvzXkDIDaIz != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(HvsrQnQWmQpQFcbTLOvzXkDIDaIz);
			HvsrQnQWmQpQFcbTLOvzXkDIDaIz = IntPtr.Zero;
		}
	}
}
