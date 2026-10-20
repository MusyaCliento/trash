using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class rwVLDpDqxWJPlwdrjLQNpZOFNoCM : jFvndfajLIsLMxvEcfhFneFXVWss
{
	public class pEYRJfGHWtbWHpMTKEnGnmKcgRzD
	{
		public readonly AxisDirection? VCqxihrrvIBYsYIhLuwXUaBEmOIQ;

		public pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection? P_0)
		{
			VCqxihrrvIBYsYIhLuwXUaBEmOIQ = P_0;
		}
	}

	public class ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA
	{
		private readonly AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD> aIPvrZQQNSHTULzLOQlCZIquqTPm;

		public readonly int TcjTOUeWeWJtkueYuHfKBpJjfTmS;

		public ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA(AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < P_0._count; i++)
			{
				if (P_0._items[i] == null)
				{
					throw new ArgumentNullException();
				}
			}
			aIPvrZQQNSHTULzLOQlCZIquqTPm = P_0;
			TcjTOUeWeWJtkueYuHfKBpJjfTmS = aIPvrZQQNSHTULzLOQlCZIquqTPm._count;
		}

		public pEYRJfGHWtbWHpMTKEnGnmKcgRzD UybBbHKkvhutyVuYQloJQCxzQltJ(int P_0)
		{
			return aIPvrZQQNSHTULzLOQlCZIquqTPm._items[P_0];
		}

		public int IUqQpZQgSxfCuAUgBJEedPxYqQSbA(AxisDirection P_0)
		{
			for (int i = 0; i < aIPvrZQQNSHTULzLOQlCZIquqTPm._count; i++)
			{
				if (aIPvrZQQNSHTULzLOQlCZIquqTPm[i].VCqxihrrvIBYsYIhLuwXUaBEmOIQ.HasValue && aIPvrZQQNSHTULzLOQlCZIquqTPm[i].VCqxihrrvIBYsYIhLuwXUaBEmOIQ.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum UrPbjcfQbpDBnInqPrAWRiTKBvQMA
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum ykNazPVyLsbqwLeFgbkcoskbJrlf
	{
		None = 0,
		DescriptiveName = 1,
		PositiveDescriptiveName = 2,
		NegativeDescriptiveName = 4,
		PositiveKey = 8,
		NegativeKey = 16,
		SpecialDescrptiveName0 = 16384,
		SpecialDescrptiveName1 = 32768,
		SpecialDescrptiveName2 = 65536,
		SpecialDescrptiveName3 = 131072,
		SpecialDescrptiveName4 = 262144,
		SpecialDescrptiveName5 = 524288,
		SpecialDescrptiveName6 = 1048576,
		SpecialDescrptiveName7 = 2097152,
		SpecialDescrptiveName8 = 4194304,
		SpecialKey0 = 8388608,
		SpecialKey1 = 16777216,
		SpecialKey2 = 33554432,
		SpecialKey3 = 67108864,
		SpecialKey4 = 134217728,
		SpecialKey5 = 268435456,
		SpecialKey6 = 536870912,
		SpecialKey7 = 1073741824,
		SpecialKey8 = int.MinValue,
		All = -1
	}

	public enum KMtjipaOdFdYovyjrhBVREbSUYnh
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum jgYXfxdxpkTgDbqAHkfiZaHWlWIS
	{
		None = 0,
		Axis2D = 1,
		Hat = 2,
		ThumbStick = 3,
		DPad = 4,
		Stick = 5,
		Stick6D = 6,
		Unknown = int.MaxValue
	}

	private static readonly ADictionary<int, ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA> sRAkMACAxajqnEfWgsvTsEocGfbM = new ADictionary<int, ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA>
	{
		{
			4,
			new ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA(new AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD>
			{
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Horizontal),
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Vertical)
			})
		},
		{
			1,
			new ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA(new AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD>
			{
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Horizontal),
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Vertical)
			})
		},
		{
			5,
			new ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA(new AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD>
			{
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Horizontal),
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Vertical)
			})
		},
		{
			3,
			new ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA(new AList<pEYRJfGHWtbWHpMTKEnGnmKcgRzD>
			{
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Horizontal),
				new pEYRJfGHWtbWHpMTKEnGnmKcgRzD(AxisDirection.Vertical)
			})
		}
	};

	private KMtjipaOdFdYovyjrhBVREbSUYnh CKAfOAykhgiudMjJfzgPFhZaOHuv;

	private jgYXfxdxpkTgDbqAHkfiZaHWlWIS gBrQtYNCzibEnImjPvYNxfukTdST;

	public KMtjipaOdFdYovyjrhBVREbSUYnh DAOKSnnHuTDqugiPODKjezPOSdlnA
	{
		get
		{
			return CKAfOAykhgiudMjJfzgPFhZaOHuv;
		}
		set
		{
			if (kMtjipaOdFdYovyjrhBVREbSUYnh != CKAfOAykhgiudMjJfzgPFhZaOHuv)
			{
				CKAfOAykhgiudMjJfzgPFhZaOHuv = kMtjipaOdFdYovyjrhBVREbSUYnh;
				if (base.dGapOzTUMHUpIdKtHUvoXobNNlrv)
				{
					LXXnWsDVIgOSTwkzKCSaFgvWkxDIA();
				}
			}
		}
	}

	public jgYXfxdxpkTgDbqAHkfiZaHWlWIS FjIpftQKdbloQPysZEVhuJqAdgNDA
	{
		get
		{
			return gBrQtYNCzibEnImjPvYNxfukTdST;
		}
		set
		{
			if (jgYXfxdxpkTgDbqAHkfiZaHWlWIS2 != gBrQtYNCzibEnImjPvYNxfukTdST)
			{
				gBrQtYNCzibEnImjPvYNxfukTdST = jgYXfxdxpkTgDbqAHkfiZaHWlWIS2;
				if (base.dGapOzTUMHUpIdKtHUvoXobNNlrv)
				{
					LXXnWsDVIgOSTwkzKCSaFgvWkxDIA();
				}
			}
		}
	}

	public static bool VMDhryivHoghcaUTSuLnPqEKPyIkA(jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_0, out ZfCeIRDlDNKDcEWGKfqjQcYzQLUdA P_1)
	{
		return sRAkMACAxajqnEfWgsvTsEocGfbM.TryGetValue((int)P_0, out P_1);
	}

	public static int pKmJnPnIjYFsvlVnstcPJZTOEgjA(KMtjipaOdFdYovyjrhBVREbSUYnh P_0, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_1)
	{
		if (P_0 != KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement)
		{
			return 0;
		}
		if (!sRAkMACAxajqnEfWgsvTsEocGfbM.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.TcjTOUeWeWJtkueYuHfKBpJjfTmS;
	}

	protected rwVLDpDqxWJPlwdrjLQNpZOFNoCM(KMtjipaOdFdYovyjrhBVREbSUYnh P_0, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_1)
	{
		CKAfOAykhgiudMjJfzgPFhZaOHuv = P_0;
		gBrQtYNCzibEnImjPvYNxfukTdST = P_1;
	}

	protected rwVLDpDqxWJPlwdrjLQNpZOFNoCM(BMeYXymsuXMDMyjfaaClzmryYLZG P_0, KMtjipaOdFdYovyjrhBVREbSUYnh P_1, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		CKAfOAykhgiudMjJfzgPFhZaOHuv = P_1;
		gBrQtYNCzibEnImjPvYNxfukTdST = P_2;
	}

	protected virtual void qvsyLZqibgFeMsKjSghfKGaBjDIb()
	{
		base.vWJmbpvFeJzKUDwbFNlKSwonRyyo();
		ZlfHtevMSzeBbYiVnqPJOsUlqIjE();
	}

	public virtual void mpvBgIfDWmPGGhRRWsstOGCGgReQA()
	{
		base.WFhSGNWPafnDBVFrKcYWKWWaVrjl();
		ZlfHtevMSzeBbYiVnqPJOsUlqIjE(UrPbjcfQbpDBnInqPrAWRiTKBvQMA.Names);
	}

	public virtual void ESUcSSJKXxEChmajqiCzVsvvEwyvA()
	{
		base.HeIcdCCpZhLydGytFlnbSIDefvCBb();
		ZlfHtevMSzeBbYiVnqPJOsUlqIjE(UrPbjcfQbpDBnInqPrAWRiTKBvQMA.Keys);
	}

	public virtual void sFaisCkvynlfgBKHRNxsfTGoxFbQA()
	{
		base.cwUahnpqwmWpOYgoibmoVeKGCqrw();
		ZlfHtevMSzeBbYiVnqPJOsUlqIjE(UrPbjcfQbpDBnInqPrAWRiTKBvQMA.Names);
	}

	public virtual bool lQQlZSenQuUtmEKsxBKXOUAwIdXH(jFvndfajLIsLMxvEcfhFneFXVWss P_0, bool P_1)
	{
		rwVLDpDqxWJPlwdrjLQNpZOFNoCM rwVLDpDqxWJPlwdrjLQNpZOFNoCM2 = P_0 as rwVLDpDqxWJPlwdrjLQNpZOFNoCM;
		if (rwVLDpDqxWJPlwdrjLQNpZOFNoCM2 != null)
		{
			return false;
		}
		if (!base.xZrerYupDOdVXRUEcCKkbPBksnvpA(P_0, P_1))
		{
			return false;
		}
		return CKAfOAykhgiudMjJfzgPFhZaOHuv == rwVLDpDqxWJPlwdrjLQNpZOFNoCM2.DAOKSnnHuTDqugiPODKjezPOSdlnA;
	}

	protected virtual void AYftJcvPreQqLXjGblGSQqsgEBEI()
	{
		base.YpzmZuxhPasmCuJTsDwvvqRktbhd();
		aAelMHyiZraDIjoaonZvPwEMOdWh(ykNazPVyLsbqwLeFgbkcoskbJrlf.All);
	}

	protected virtual void ZlfHtevMSzeBbYiVnqPJOsUlqIjE(UrPbjcfQbpDBnInqPrAWRiTKBvQMA P_0 = UrPbjcfQbpDBnInqPrAWRiTKBvQMA.None)
	{
		if (P_0 != UrPbjcfQbpDBnInqPrAWRiTKBvQMA.None)
		{
			zTcBvlcsEJdVpUfZcYlJcSPFZZlK(P_0);
		}
		BMeYXymsuXMDMyjfaaClzmryYLZG bMeYXymsuXMDMyjfaaClzmryYLZG = BMBXvRAQqSEcDAWEUIhxPASEJkSIb();
		if (bMeYXymsuXMDMyjfaaClzmryYLZG != null && (bMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(bMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(bMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName))
		{
			bMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName = bMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName;
			bMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags |= 1;
			stIdSjGLgdmpdoKfxdFGeinstuIX(1);
		}
	}

	protected virtual void BIxKbEGAVSFkTRCzBrSSqPhAoCbj(int P_0)
	{
		base.ZMFRLsiLxJwlABCAqCnahnNMoAlu(P_0);
		aAelMHyiZraDIjoaonZvPwEMOdWh((ykNazPVyLsbqwLeFgbkcoskbJrlf)P_0);
	}

	protected virtual void aAelMHyiZraDIjoaonZvPwEMOdWh(ykNazPVyLsbqwLeFgbkcoskbJrlf P_0)
	{
		BMeYXymsuXMDMyjfaaClzmryYLZG bMeYXymsuXMDMyjfaaClzmryYLZG = BMBXvRAQqSEcDAWEUIhxPASEJkSIb();
		if (bMeYXymsuXMDMyjfaaClzmryYLZG != null && ((uint)bMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & ykNazPVyLsbqwLeFgbkcoskbJrlf.DescriptiveName) != ykNazPVyLsbqwLeFgbkcoskbJrlf.None && (bMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags & 1) != 0)
		{
			if (BMBXvRAQqSEcDAWEUIhxPASEJkSIb() != null)
			{
				BMBXvRAQqSEcDAWEUIhxPASEJkSIb().nonLocalizedDescriptiveName = null;
			}
			stIdSjGLgdmpdoKfxdFGeinstuIX(1);
			bMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags &= -2;
		}
	}

	private void zTcBvlcsEJdVpUfZcYlJcSPFZZlK(UrPbjcfQbpDBnInqPrAWRiTKBvQMA P_0)
	{
		ykNazPVyLsbqwLeFgbkcoskbJrlf ykNazPVyLsbqwLeFgbkcoskbJrlf2 = ybZqRCAcQgSaJVeiWyZtveyktRZF(P_0);
		if (ykNazPVyLsbqwLeFgbkcoskbJrlf2 != ykNazPVyLsbqwLeFgbkcoskbJrlf.None)
		{
			aAelMHyiZraDIjoaonZvPwEMOdWh(ykNazPVyLsbqwLeFgbkcoskbJrlf2);
		}
	}

	protected virtual ykNazPVyLsbqwLeFgbkcoskbJrlf ybZqRCAcQgSaJVeiWyZtveyktRZF(UrPbjcfQbpDBnInqPrAWRiTKBvQMA P_0)
	{
		ykNazPVyLsbqwLeFgbkcoskbJrlf ykNazPVyLsbqwLeFgbkcoskbJrlf2 = ykNazPVyLsbqwLeFgbkcoskbJrlf.None;
		if ((P_0 & UrPbjcfQbpDBnInqPrAWRiTKBvQMA.Names) != UrPbjcfQbpDBnInqPrAWRiTKBvQMA.None)
		{
			ykNazPVyLsbqwLeFgbkcoskbJrlf2 |= ykNazPVyLsbqwLeFgbkcoskbJrlf.DescriptiveName;
		}
		return ykNazPVyLsbqwLeFgbkcoskbJrlf2;
	}

	protected virtual void iOkIeDOMUfoQKnSLdrVAsxpyvpPW()
	{
		base.SMvupJzMtAnsimKORrGNsRVPKmcX();
		GgJIdjbrcTsxVbBNSBtCrqQLiCRBb(1, new uQzNTOAEYNCKgRdubwQSHetIDLey
		{
			iboJCjeedqFKoTgBGjeSEwlFFyRD = GJDamLJnmQxyXObUvmZciZVlGxPjA
		});
	}
}
