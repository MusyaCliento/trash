using System;
using System.Runtime.CompilerServices;

internal struct LebHGuCUIJGDebmwMJoZBoPfqjIw
{
	private uint OkTmlpVtIefjylkMZHVyGlTexPgS;

	private ulong zhPvIacpCBaBQgvdEfoskYfzedRCb;

	private static readonly bool tnLeRpmjcPesjJUwqAYQtliCqDNLA;

	public static readonly int BnTJNQrQIWlUvwtVxLoughOnypjF;

	static LebHGuCUIJGDebmwMJoZBoPfqjIw()
	{
		tnLeRpmjcPesjJUwqAYQtliCqDNLA = IntPtr.Size == 8;
		BnTJNQrQIWlUvwtVxLoughOnypjF = (tnLeRpmjcPesjJUwqAYQtliCqDNLA ? 8 : 4);
	}

	public static LebHGuCUIJGDebmwMJoZBoPfqjIw YFKpkxbOMPyIFdbTTSuPJCKyAVjn(byte[] P_0, int P_1)
	{
		LebHGuCUIJGDebmwMJoZBoPfqjIw result = default(LebHGuCUIJGDebmwMJoZBoPfqjIw);
		if (tnLeRpmjcPesjJUwqAYQtliCqDNLA)
		{
			result.zhPvIacpCBaBQgvdEfoskYfzedRCb = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.OkTmlpVtIefjylkMZHVyGlTexPgS = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint cnGEfgKIGCicBDFRhSVBUKTgZJai(LebHGuCUIJGDebmwMJoZBoPfqjIw P_0)
	{
		if (tnLeRpmjcPesjJUwqAYQtliCqDNLA)
		{
			return (uint)P_0.zhPvIacpCBaBQgvdEfoskYfzedRCb;
		}
		return P_0.OkTmlpVtIefjylkMZHVyGlTexPgS;
	}

	[SpecialName]
	public static ulong cnGEfgKIGCicBDFRhSVBUKTgZJai(LebHGuCUIJGDebmwMJoZBoPfqjIw P_0)
	{
		if (tnLeRpmjcPesjJUwqAYQtliCqDNLA)
		{
			return P_0.zhPvIacpCBaBQgvdEfoskYfzedRCb;
		}
		return P_0.OkTmlpVtIefjylkMZHVyGlTexPgS;
	}

	public string qBhpaoyhBcbTSESrVssSpIsTKMnjb()
	{
		if (tnLeRpmjcPesjJUwqAYQtliCqDNLA)
		{
			return zhPvIacpCBaBQgvdEfoskYfzedRCb.ToString();
		}
		return OkTmlpVtIefjylkMZHVyGlTexPgS.ToString();
	}
}
