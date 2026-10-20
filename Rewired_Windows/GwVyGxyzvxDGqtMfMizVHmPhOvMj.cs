using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class GwVyGxyzvxDGqtMfMizVHmPhOvMj : jcJGjSkbtQDyTmpzTHTatEYHhRqi
{
	[CompilerGenerated]
	private ecJDfCJXiRmIcfcafmnTxhmIeuyJ PuBHAAQGJQKgYOpPdxFZGkNREQabA;

	public ecJDfCJXiRmIcfcafmnTxhmIeuyJ QEufqQjUvXRElIjoMfPwfjlcOGIYB
	{
		[CompilerGenerated]
		get
		{
			return PuBHAAQGJQKgYOpPdxFZGkNREQabA;
		}
		[CompilerGenerated]
		private set
		{
			PuBHAAQGJQKgYOpPdxFZGkNREQabA = puBHAAQGJQKgYOpPdxFZGkNREQabA;
		}
	}

	protected abstract luwANhXFgPwKIAKCSerOycRnmifi BWteKGVkbDiItIdBrvHTTwDnTRUy { get; }

	public unsafe virtual void wbElmFIiNMjYFcvCzdIGlfekLZCq(ecJDfCJXiRmIcfcafmnTxhmIeuyJ P_0)
	{
		QEufqQjUvXRElIjoMfPwfjlcOGIYB = P_0;
		base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr, BWteKGVkbDiItIdBrvHTTwDnTRUy.cFHVDRqRhjxqvoKcvjfhcijUcNPS);
		((IntPtr*)(void*)base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void XowoeurtjhDVSwMYXJCbUErkYBfi(bool P_0)
	{
		if (base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr)[1]).Free();
			Marshal.FreeHGlobal(base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr);
			base.jZMLhMmNWgZQKiIdvGxNhEuSjsYr = IntPtr.Zero;
		}
		QEufqQjUvXRElIjoMfPwfjlcOGIYB = null;
		bHDigdfFMuBqdDfRDUPiuafmjSTgb(P_0);
	}

	internal unsafe static _0001 jdmjNCzWRdMNKznAeMGzOkFehrrZ<_0001>(IntPtr P_0) where _0001 : GwVyGxyzvxDGqtMfMizVHmPhOvMj
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
