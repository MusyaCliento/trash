using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class cIJgGCEhUppLKdHxZeqoRkTiKnWb<_0001> : IDisposable where _0001 : struct
{
	private static readonly int lxmaerBrkbSVdzUvLGGKucNYvUpg = Marshal.SizeOf(typeof(_0001));

	private TLjofzBmfBMLdKYQRjtOpIYGxOeK FAiJNORPxWVJVSVikFsUEaijczbn;

	private bool qAeDGrPcaTRIALHEKEYwedBzLeFCb;

	public TLjofzBmfBMLdKYQRjtOpIYGxOeK oJsyFKLPSMlekgCzKCXFHmehEQXpA => FAiJNORPxWVJVSVikFsUEaijczbn;

	public bool GWQkeuiRtAKQtYBIBUddOTJzEExT
	{
		get
		{
			if (FAiJNORPxWVJVSVikFsUEaijczbn != null)
			{
				return FAiJNORPxWVJVSVikFsUEaijczbn.NviRYhMtJVuAvgdklGfnjFqczibp != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 QkYCmYRuXflOvGNGbdVbrlDqToex
	{
		get
		{
			vLDBqQvwqLZZACdksGcwGjfueBeOA();
			return Unsafe.Read<_0001>((void*)FAiJNORPxWVJVSVikFsUEaijczbn.NviRYhMtJVuAvgdklGfnjFqczibp);
		}
		set
		{
			vLDBqQvwqLZZACdksGcwGjfueBeOA();
			_0001* ptr = &val;
			FAiJNORPxWVJVSVikFsUEaijczbn.qrXLwbvgOWXyBWDNoLaGfQlhvSei((IntPtr)ptr, lxmaerBrkbSVdzUvLGGKucNYvUpg, lxmaerBrkbSVdzUvLGGKucNYvUpg);
		}
	}

	public cIJgGCEhUppLKdHxZeqoRkTiKnWb()
	{
		FAiJNORPxWVJVSVikFsUEaijczbn = new TLjofzBmfBMLdKYQRjtOpIYGxOeK(lxmaerBrkbSVdzUvLGGKucNYvUpg);
	}

	private void tXIACXHqWPAIiRYKMGBdUzehCuAY()
	{
		if (FAiJNORPxWVJVSVikFsUEaijczbn == null)
		{
			FAiJNORPxWVJVSVikFsUEaijczbn.Dispose();
			FAiJNORPxWVJVSVikFsUEaijczbn = null;
		}
	}

	private void vLDBqQvwqLZZACdksGcwGjfueBeOA()
	{
		if (!GWQkeuiRtAKQtYBIBUddOTJzEExT)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void JEpkQZeCenxvphKsSExfVqFKhtQp(bool P_0)
	{
		if (!qAeDGrPcaTRIALHEKEYwedBzLeFCb)
		{
			if (P_0)
			{
				tXIACXHqWPAIiRYKMGBdUzehCuAY();
			}
			qAeDGrPcaTRIALHEKEYwedBzLeFCb = true;
		}
	}

	public void Dispose()
	{
		JEpkQZeCenxvphKsSExfVqFKhtQp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
