using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct eZzfdwqZyuUzjYPZsjwXXEekwhTl : IEquatable<eZzfdwqZyuUzjYPZsjwXXEekwhTl>
{
	public ModifierKey jyaDOENppllrRqGJdSYrvDpcALGu;

	public ModifierKey ACXPfxhxjzjqcIPdDHMFtcPgNyAH;

	public ModifierKey rAROzgepZrkcdFSabHpfrCMHgxh;

	private ModifierKey crHLkmCesJdGHRGnYjrHxDJEuZHC
	{
		get
		{
			if (P_0 <= 0)
			{
				return jyaDOENppllrRqGJdSYrvDpcALGu;
			}
			if (P_0 == 1)
			{
				return ACXPfxhxjzjqcIPdDHMFtcPgNyAH;
			}
			if (P_0 >= 2)
			{
				return rAROzgepZrkcdFSabHpfrCMHgxh;
			}
			return jyaDOENppllrRqGJdSYrvDpcALGu;
		}
		set
		{
			if (num <= 0)
			{
				jyaDOENppllrRqGJdSYrvDpcALGu = aCXPfxhxjzjqcIPdDHMFtcPgNyAH;
			}
			if (num == 1)
			{
				ACXPfxhxjzjqcIPdDHMFtcPgNyAH = aCXPfxhxjzjqcIPdDHMFtcPgNyAH;
			}
			if (num >= 2)
			{
				rAROzgepZrkcdFSabHpfrCMHgxh = aCXPfxhxjzjqcIPdDHMFtcPgNyAH;
			}
		}
	}

	public eZzfdwqZyuUzjYPZsjwXXEekwhTl(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		jyaDOENppllrRqGJdSYrvDpcALGu = P_0;
		ACXPfxhxjzjqcIPdDHMFtcPgNyAH = P_1;
		rAROzgepZrkcdFSabHpfrCMHgxh = P_2;
	}

	public void GyZVaRtWRQWpyxXOlTNJTJzEkiqK()
	{
		if (jyaDOENppllrRqGJdSYrvDpcALGu != ModifierKey.None)
		{
			jyaDOENppllrRqGJdSYrvDpcALGu = ModifierKey.None;
		}
		if (ACXPfxhxjzjqcIPdDHMFtcPgNyAH != ModifierKey.None)
		{
			ACXPfxhxjzjqcIPdDHMFtcPgNyAH = ModifierKey.None;
		}
		if (rAROzgepZrkcdFSabHpfrCMHgxh != ModifierKey.None)
		{
			rAROzgepZrkcdFSabHpfrCMHgxh = ModifierKey.None;
		}
	}

	public static eZzfdwqZyuUzjYPZsjwXXEekwhTl lIkgcbiWVfbZlDtacWOineyqoNyM(ModifierKeyFlags P_0)
	{
		eZzfdwqZyuUzjYPZsjwXXEekwhTl result = default(eZzfdwqZyuUzjYPZsjwXXEekwhTl);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.qeJjIPnSEinWoYHNnNHadKbWjupeA(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.qeJjIPnSEinWoYHNnNHadKbWjupeA(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.qeJjIPnSEinWoYHNnNHadKbWjupeA(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.qeJjIPnSEinWoYHNnNHadKbWjupeA(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(eZzfdwqZyuUzjYPZsjwXXEekwhTl other)
	{
		if (jyaDOENppllrRqGJdSYrvDpcALGu == other.jyaDOENppllrRqGJdSYrvDpcALGu && ACXPfxhxjzjqcIPdDHMFtcPgNyAH == other.ACXPfxhxjzjqcIPdDHMFtcPgNyAH)
		{
			return rAROzgepZrkcdFSabHpfrCMHgxh == other.rAROzgepZrkcdFSabHpfrCMHgxh;
		}
		return false;
	}

	bool IEquatable<eZzfdwqZyuUzjYPZsjwXXEekwhTl>.Equals(eZzfdwqZyuUzjYPZsjwXXEekwhTl other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool iFeTguChLndBPDwcMcJxOyUhhkYE(object P_0)
	{
		if (P_0 == null || !(P_0 is eZzfdwqZyuUzjYPZsjwXXEekwhTl))
		{
			return false;
		}
		return Equals((eZzfdwqZyuUzjYPZsjwXXEekwhTl)P_0);
	}

	public int UNZLHyaIBWCrenNqIrCTmGybfPFA()
	{
		return ((17 * 29 + jyaDOENppllrRqGJdSYrvDpcALGu.GetHashCode()) * 29 + ACXPfxhxjzjqcIPdDHMFtcPgNyAH.GetHashCode()) * 29 + rAROzgepZrkcdFSabHpfrCMHgxh.GetHashCode();
	}

	[SpecialName]
	public static bool mPLSdOamTIdebUQChFBoBAJkfNRO(eZzfdwqZyuUzjYPZsjwXXEekwhTl P_0, eZzfdwqZyuUzjYPZsjwXXEekwhTl P_1)
	{
		if (P_0.jyaDOENppllrRqGJdSYrvDpcALGu == P_1.jyaDOENppllrRqGJdSYrvDpcALGu && P_0.ACXPfxhxjzjqcIPdDHMFtcPgNyAH == P_1.ACXPfxhxjzjqcIPdDHMFtcPgNyAH)
		{
			return P_0.rAROzgepZrkcdFSabHpfrCMHgxh == P_1.rAROzgepZrkcdFSabHpfrCMHgxh;
		}
		return false;
	}

	[SpecialName]
	public static bool ZSliHdwRegewQjTbelXYJeVcVqKN(eZzfdwqZyuUzjYPZsjwXXEekwhTl P_0, eZzfdwqZyuUzjYPZsjwXXEekwhTl P_1)
	{
		return !mPLSdOamTIdebUQChFBoBAJkfNRO(P_0, P_1);
	}
}
