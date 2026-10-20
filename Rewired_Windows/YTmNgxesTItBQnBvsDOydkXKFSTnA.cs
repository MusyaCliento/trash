using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct YTmNgxesTItBQnBvsDOydkXKFSTnA : IEquatable<YTmNgxesTItBQnBvsDOydkXKFSTnA>, IFormattable
{
	public static readonly int GjKyFZnllfkqHTkQYacCHgbIahqjb = Marshal.SizeOf(typeof(YTmNgxesTItBQnBvsDOydkXKFSTnA));

	public static readonly YTmNgxesTItBQnBvsDOydkXKFSTnA UhodojabZXHiPScgIIBbcNXpAagz = default(YTmNgxesTItBQnBvsDOydkXKFSTnA);

	public static readonly YTmNgxesTItBQnBvsDOydkXKFSTnA rWKnbCXUxuurNlZbZFGYKJsetyjO = new YTmNgxesTItBQnBvsDOydkXKFSTnA(1f, 0f);

	public static readonly YTmNgxesTItBQnBvsDOydkXKFSTnA cusXethJobBhVeGraxSLTUyXFgQj = new YTmNgxesTItBQnBvsDOydkXKFSTnA(0f, 1f);

	public static readonly YTmNgxesTItBQnBvsDOydkXKFSTnA UvWqzSBQbFOnJdBAxGyApHFlpGbe = new YTmNgxesTItBQnBvsDOydkXKFSTnA(1f, 1f);

	public float yjmCGtZZxlCuwenCzISUackcFdBy;

	public float NMzSMZgXAnTTtzOAlLRktyttbQZP;

	public bool jBIknuvjYmfkYmofKesupDqBGxP => ouJCRYIccCnMbiacKQSFQszJhffXA.PGURyPPwOiBMXlGmQyUwoKuKlXpK(yjmCGtZZxlCuwenCzISUackcFdBy * yjmCGtZZxlCuwenCzISUackcFdBy + NMzSMZgXAnTTtzOAlLRktyttbQZP * NMzSMZgXAnTTtzOAlLRktyttbQZP);

	public bool ziRDeOaRuwGlALKuQZOtfvmSZjUQ
	{
		get
		{
			if (yjmCGtZZxlCuwenCzISUackcFdBy == 0f)
			{
				return NMzSMZgXAnTTtzOAlLRktyttbQZP == 0f;
			}
			return false;
		}
	}

	public float zjkydqNXgesEAwRHaOQyWSBgYTNb
	{
		get
		{
			return P_0 switch
			{
				0 => yjmCGtZZxlCuwenCzISUackcFdBy, 
				1 => NMzSMZgXAnTTtzOAlLRktyttbQZP, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				yjmCGtZZxlCuwenCzISUackcFdBy = nMzSMZgXAnTTtzOAlLRktyttbQZP;
				break;
			case 1:
				NMzSMZgXAnTTtzOAlLRktyttbQZP = nMzSMZgXAnTTtzOAlLRktyttbQZP;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public YTmNgxesTItBQnBvsDOydkXKFSTnA(float P_0)
	{
		yjmCGtZZxlCuwenCzISUackcFdBy = P_0;
		NMzSMZgXAnTTtzOAlLRktyttbQZP = P_0;
	}

	public YTmNgxesTItBQnBvsDOydkXKFSTnA(float P_0, float P_1)
	{
		yjmCGtZZxlCuwenCzISUackcFdBy = P_0;
		NMzSMZgXAnTTtzOAlLRktyttbQZP = P_1;
	}

	public YTmNgxesTItBQnBvsDOydkXKFSTnA(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		yjmCGtZZxlCuwenCzISUackcFdBy = P_0[0];
		NMzSMZgXAnTTtzOAlLRktyttbQZP = P_0[1];
	}

	public float rxeNMLyGVVKEFqonbdSMNdPGmuLC()
	{
		return (float)Math.Sqrt(yjmCGtZZxlCuwenCzISUackcFdBy * yjmCGtZZxlCuwenCzISUackcFdBy + NMzSMZgXAnTTtzOAlLRktyttbQZP * NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public float GxyjINFMOZCduNSEScJsoOKveaGD()
	{
		return yjmCGtZZxlCuwenCzISUackcFdBy * yjmCGtZZxlCuwenCzISUackcFdBy + NMzSMZgXAnTTtzOAlLRktyttbQZP * NMzSMZgXAnTTtzOAlLRktyttbQZP;
	}

	public void leVqqWMoncwBipUWohWUdQiacQgm()
	{
		float num = rxeNMLyGVVKEFqonbdSMNdPGmuLC();
		if (!ouJCRYIccCnMbiacKQSFQszJhffXA.bGzvKloDlABPmAOojrQQWohMsSvp(num))
		{
			float num2 = 1f / num;
			yjmCGtZZxlCuwenCzISUackcFdBy *= num2;
			NMzSMZgXAnTTtzOAlLRktyttbQZP *= num2;
		}
	}

	public float[] eGwODyilmNCwRPqRPDZXaMVDdKeZA()
	{
		return new float[2] { yjmCGtZZxlCuwenCzISUackcFdBy, NMzSMZgXAnTTtzOAlLRktyttbQZP };
	}

	public static void fuNDxQfxizcJcfWhZnkkVcRQftZAb(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA eutnsjLsixdlpIqNUUQwBjDxVfsL(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void AMjLFavYTOHQlYdaXIUOUnMCGnIL(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref float P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA ghcMPXbhQQhSFiYrDSfaeSNTgdQBA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1);
	}

	public static void dlqSRjriWUaeFnKFXAJqBSjYAaQdb(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA fsiDcWfvjzNBlThRrNfdcxxNGhZvA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void dVOyBjFFIbCuUtRxwafqzBrQbKyd(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref float P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA uNezvuGzaWTKKLyBXQfEprRMdllC(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1);
	}

	public static void xxDnbKSwgOClFjvoxbobdSCSFPUN(ref float P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA MSLbRVgfsgKliYThXlExdhaJfqbKc(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void CjvsTCyLkTWsffrXQIVRPgeDuduV(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA kduxEbpzSqVGlbJvLwzAyiafwvBc(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1);
	}

	public static void FuGGnlzecXwZSSNqvpGbqxNhIPml(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA IYTACfLVyQbuVnVEwTiEobGLyCuR(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void JMxYwHcgrjFJfzCTunDumSqbccWE(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy / P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP / P_1);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA PKRvUXXoEZWZrjAUUNPpUKafBcz(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy / P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP / P_1);
	}

	public static void inWqpuhTFtDetKfoxeWPodIjhNZkA(float P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 / P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 / P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA akXAKofSKZaauusjUeOUNcklrfQDA(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 / P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 / P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void LOowXIRhZlLVKEImMjOOAAKReSaDA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		P_1 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(0f - P_0.yjmCGtZZxlCuwenCzISUackcFdBy, 0f - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA WgkaGDIQPaafCSvSzQYYgMWKjriSA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(0f - P_0.yjmCGtZZxlCuwenCzISUackcFdBy, 0f - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static void oantZoepbonMdeSlRRpevXQymRro(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, float P_3, float P_4, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_5)
	{
		P_5 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_3 * (P_1.yjmCGtZZxlCuwenCzISUackcFdBy - P_0.yjmCGtZZxlCuwenCzISUackcFdBy) + P_4 * (P_2.yjmCGtZZxlCuwenCzISUackcFdBy - P_0.yjmCGtZZxlCuwenCzISUackcFdBy), P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_3 * (P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP) + P_4 * (P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP));
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA pRxxBrcEOXqrNHUOTUGGqTxkmEDY(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, float P_3, float P_4)
	{
		oantZoepbonMdeSlRRpevXQymRro(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void ZlIhwRtGgWbnHNFrnfkgMHAZWKYD(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_3)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy;
		num = ((num > P_2.yjmCGtZZxlCuwenCzISUackcFdBy) ? P_2.yjmCGtZZxlCuwenCzISUackcFdBy : num);
		num = ((num < P_1.yjmCGtZZxlCuwenCzISUackcFdBy) ? P_1.yjmCGtZZxlCuwenCzISUackcFdBy : num);
		float nMzSMZgXAnTTtzOAlLRktyttbQZP = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		nMzSMZgXAnTTtzOAlLRktyttbQZP = ((nMzSMZgXAnTTtzOAlLRktyttbQZP > P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP) ? P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP : nMzSMZgXAnTTtzOAlLRktyttbQZP);
		nMzSMZgXAnTTtzOAlLRktyttbQZP = ((nMzSMZgXAnTTtzOAlLRktyttbQZP < P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP) ? P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP : nMzSMZgXAnTTtzOAlLRktyttbQZP);
		P_3 = new YTmNgxesTItBQnBvsDOydkXKFSTnA(num, nMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA PVJOtGtnifobHxBwgmJoDFgtsRUP(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		ZlIhwRtGgWbnHNFrnfkgMHAZWKYD(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void bMdTchgOWiKbgGVOeRLzoofrJzvf()
	{
		yjmCGtZZxlCuwenCzISUackcFdBy = ((yjmCGtZZxlCuwenCzISUackcFdBy < 0f) ? 0f : ((yjmCGtZZxlCuwenCzISUackcFdBy > 1f) ? 1f : yjmCGtZZxlCuwenCzISUackcFdBy));
		NMzSMZgXAnTTtzOAlLRktyttbQZP = ((NMzSMZgXAnTTtzOAlLRktyttbQZP < 0f) ? 0f : ((NMzSMZgXAnTTtzOAlLRktyttbQZP > 1f) ? 1f : NMzSMZgXAnTTtzOAlLRktyttbQZP));
	}

	public static void VPWbnzgPbOThVqfJqsDseMajhEIXA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out float P_2)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy;
		float num2 = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float JjrArfUuBWvMucwodVJAenfMOhxh(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy;
		float num2 = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void fnfBGkrJRvMerHXzcfjVmdlDfBiGA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out float P_2)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy;
		float num2 = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		P_2 = num * num + num2 * num2;
	}

	public static float eJAlTHxPDZwHFDDVfGBFBluFbftgA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy;
		float num2 = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		return num * num + num2 * num2;
	}

	public static void YYFYquIBgPFpXRaeQAVhHtJCykmC(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out float P_2)
	{
		P_2 = P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy + P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
	}

	public static float xwsovDmdNPFVYuohfWTwVtLJRUbr(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy + P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
	}

	public static void yvaMkfHmJdfBdCsRcRxKBptdXsPDA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		P_1 = P_0;
		P_1.leVqqWMoncwBipUWohWUdQiacQgm();
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA amznJYWmqdftqbYdDtJiWwsVtWOSA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0)
	{
		P_0.leVqqWMoncwBipUWohWUdQiacQgm();
		return P_0;
	}

	public static void flSeDyiTQdaDOJrfMSzZsNDrxfvO(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, float P_2, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_3)
	{
		P_3.yjmCGtZZxlCuwenCzISUackcFdBy = ouJCRYIccCnMbiacKQSFQszJhffXA.JyACZAAShLnZwBIoNKsAdPJKpcfNc(P_0.yjmCGtZZxlCuwenCzISUackcFdBy, P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_2);
		P_3.NMzSMZgXAnTTtzOAlLRktyttbQZP = ouJCRYIccCnMbiacKQSFQszJhffXA.JyACZAAShLnZwBIoNKsAdPJKpcfNc(P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP, P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP, P_2);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA rdSfZDjrTOwQIRgMUjQQhlknwKkm(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, float P_2)
	{
		flSeDyiTQdaDOJrfMSzZsNDrxfvO(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void PmKnKxonnlFhtszhnCFXZInWGlaAA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, float P_2, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_3)
	{
		P_2 = ouJCRYIccCnMbiacKQSFQszJhffXA.zpSAILIFhfZCNEqOTKbyRxXcGnKV(P_2);
		flSeDyiTQdaDOJrfMSzZsNDrxfvO(ref P_0, ref P_1, P_2, out P_3);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA kIKkblGPSPMfwyQbGHBvefrBMbnf(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, float P_2)
	{
		PmKnKxonnlFhtszhnCFXZInWGlaAA(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void BONaneEUGijSQGUZOtvLgIZfkEwoA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_3, float P_4, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.yjmCGtZZxlCuwenCzISUackcFdBy = P_0.yjmCGtZZxlCuwenCzISUackcFdBy * num3 + P_2.yjmCGtZZxlCuwenCzISUackcFdBy * num4 + P_1.yjmCGtZZxlCuwenCzISUackcFdBy * num5 + P_3.yjmCGtZZxlCuwenCzISUackcFdBy * num6;
		P_5.NMzSMZgXAnTTtzOAlLRktyttbQZP = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * num3 + P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP * num4 + P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP * num5 + P_3.NMzSMZgXAnTTtzOAlLRktyttbQZP * num6;
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA FIQgOSQUIpHiHEsoQuCnPleqHndp(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, YTmNgxesTItBQnBvsDOydkXKFSTnA P_3, float P_4)
	{
		BONaneEUGijSQGUZOtvLgIZfkEwoA(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void kMhEQhtFUeciODlXAnwBbrvdVRud(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_3, float P_4, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.yjmCGtZZxlCuwenCzISUackcFdBy = 0.5f * (2f * P_1.yjmCGtZZxlCuwenCzISUackcFdBy + (0f - P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_2.yjmCGtZZxlCuwenCzISUackcFdBy) * P_4 + (2f * P_0.yjmCGtZZxlCuwenCzISUackcFdBy - 5f * P_1.yjmCGtZZxlCuwenCzISUackcFdBy + 4f * P_2.yjmCGtZZxlCuwenCzISUackcFdBy - P_3.yjmCGtZZxlCuwenCzISUackcFdBy) * num + (0f - P_0.yjmCGtZZxlCuwenCzISUackcFdBy + 3f * P_1.yjmCGtZZxlCuwenCzISUackcFdBy - 3f * P_2.yjmCGtZZxlCuwenCzISUackcFdBy + P_3.yjmCGtZZxlCuwenCzISUackcFdBy) * num2);
		P_5.NMzSMZgXAnTTtzOAlLRktyttbQZP = 0.5f * (2f * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP + (0f - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP) * P_4 + (2f * P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - 5f * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP + 4f * P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_3.NMzSMZgXAnTTtzOAlLRktyttbQZP) * num + (0f - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + 3f * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP - 3f * P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_3.NMzSMZgXAnTTtzOAlLRktyttbQZP) * num2);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA ItEFjlvIypdWYfLHEItMbEmAUUVJB(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, YTmNgxesTItBQnBvsDOydkXKFSTnA P_2, YTmNgxesTItBQnBvsDOydkXKFSTnA P_3, float P_4)
	{
		kMhEQhtFUeciODlXAnwBbrvdVRud(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void AHiGOdOCrYcCGPkLTgNHeNViasoW(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2.yjmCGtZZxlCuwenCzISUackcFdBy = ((P_0.yjmCGtZZxlCuwenCzISUackcFdBy > P_1.yjmCGtZZxlCuwenCzISUackcFdBy) ? P_0.yjmCGtZZxlCuwenCzISUackcFdBy : P_1.yjmCGtZZxlCuwenCzISUackcFdBy);
		P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP = ((P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP > P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP) ? P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP : P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA jjPOaPCgIqLuEUHkqHyELtJNGVnD(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		AHiGOdOCrYcCGPkLTgNHeNViasoW(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void rZrCPSBLHXbMQbHrXoNWBpDiRzREB(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		P_2.yjmCGtZZxlCuwenCzISUackcFdBy = ((P_0.yjmCGtZZxlCuwenCzISUackcFdBy < P_1.yjmCGtZZxlCuwenCzISUackcFdBy) ? P_0.yjmCGtZZxlCuwenCzISUackcFdBy : P_1.yjmCGtZZxlCuwenCzISUackcFdBy);
		P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP = ((P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP < P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP) ? P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP : P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA OxpDsZBQbsuQYKDNYdBqJZDMnSxIA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		rZrCPSBLHXbMQbHrXoNWBpDiRzREB(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void JRIZfvhfZYTOolkvdwEKJnpogAAiA(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_1, out YTmNgxesTItBQnBvsDOydkXKFSTnA P_2)
	{
		float num = P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy + P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
		P_2.yjmCGtZZxlCuwenCzISUackcFdBy = P_0.yjmCGtZZxlCuwenCzISUackcFdBy - 2f * num * P_1.yjmCGtZZxlCuwenCzISUackcFdBy;
		P_2.NMzSMZgXAnTTtzOAlLRktyttbQZP = P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - 2f * num * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP;
	}

	public static YTmNgxesTItBQnBvsDOydkXKFSTnA EkdAQGFfENqlrQQDWXtToiKYUTxs(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		JRIZfvhfZYTOolkvdwEKJnpogAAiA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void BLYtgYdggOlmBQMZNBUWfzpublSFA(YTmNgxesTItBQnBvsDOydkXKFSTnA[] P_0, params YTmNgxesTItBQnBvsDOydkXKFSTnA[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			YTmNgxesTItBQnBvsDOydkXKFSTnA yTmNgxesTItBQnBvsDOydkXKFSTnA = P_1[i];
			for (int j = 0; j < i; j++)
			{
				yTmNgxesTItBQnBvsDOydkXKFSTnA = PNhwsQMCdAlrjeKgjcKpGyCYTNQJ(yTmNgxesTItBQnBvsDOydkXKFSTnA, GnKKdYIhMrRpPXjTqzuQuklNvcVh(xwsovDmdNPFVYuohfWTwVtLJRUbr(P_0[j], yTmNgxesTItBQnBvsDOydkXKFSTnA) / xwsovDmdNPFVYuohfWTwVtLJRUbr(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = yTmNgxesTItBQnBvsDOydkXKFSTnA;
		}
	}

	public static void gNPjecNlcmMBsJLqMdPMAzaiCxjCA(YTmNgxesTItBQnBvsDOydkXKFSTnA[] P_0, params YTmNgxesTItBQnBvsDOydkXKFSTnA[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			YTmNgxesTItBQnBvsDOydkXKFSTnA yTmNgxesTItBQnBvsDOydkXKFSTnA = P_1[i];
			for (int j = 0; j < i; j++)
			{
				yTmNgxesTItBQnBvsDOydkXKFSTnA = PNhwsQMCdAlrjeKgjcKpGyCYTNQJ(yTmNgxesTItBQnBvsDOydkXKFSTnA, GnKKdYIhMrRpPXjTqzuQuklNvcVh(xwsovDmdNPFVYuohfWTwVtLJRUbr(P_0[j], yTmNgxesTItBQnBvsDOydkXKFSTnA), P_0[j]));
			}
			yTmNgxesTItBQnBvsDOydkXKFSTnA.leVqqWMoncwBipUWohWUdQiacQgm();
			P_0[i] = yTmNgxesTItBQnBvsDOydkXKFSTnA;
		}
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA tKBIXGOqTrGycXeQxAaJjuwRGuCqA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA QyhVFGEFrQkuFDjBcCDnATlzaXdI(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA dDemdVXLiBScOkVQdkiUZqjcCihO(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA PNhwsQMCdAlrjeKgjcKpGyCYTNQJ(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA IVafPAHTbDWrpvpHcizcpjrITErtA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(0f - P_0.yjmCGtZZxlCuwenCzISUackcFdBy, 0f - P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA GnKKdYIhMrRpPXjTqzuQuklNvcVh(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_1.yjmCGtZZxlCuwenCzISUackcFdBy * P_0, P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_0);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA bLwIxCnfgPUXcNSCLEdmgFzKuiqj(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy * P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP * P_1);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA duZPbtcKuKGwqBlVXcpyITtCIMkl(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy / P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP / P_1);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA zjQvbucdHtclaodcWkyMmEUYtvtt(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 / P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 / P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA hcXDZHDCUtKisyyPGbPOFbQgFNpjB(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy / P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP / P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA mNLcHoVEsdiyFYcAphhlEiZNAbpdA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy + P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP + P_1);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA skyWGGujmEVTfiSSZhqFmSMgSyYm(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 + P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 + P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA IfuGzzdzxAjdAexvEYzEtUGJtYtHA(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, float P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0.yjmCGtZZxlCuwenCzISUackcFdBy - P_1, P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP - P_1);
	}

	[SpecialName]
	public static YTmNgxesTItBQnBvsDOydkXKFSTnA bpMowgbjSIPQgTnpMGWQbBHjHQcrA(float P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return new YTmNgxesTItBQnBvsDOydkXKFSTnA(P_0 - P_1.yjmCGtZZxlCuwenCzISUackcFdBy, P_0 - P_1.NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	[SpecialName]
	public static bool WcMcXYNwxEwwShfVzBSyMWMdMBfo(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return P_0.wzVZJGRvlZTFJoNkorjhIfOUVEoM(ref P_1);
	}

	[SpecialName]
	public static bool gNHZJDyTXuIzZjrMFemysCElppiJ(YTmNgxesTItBQnBvsDOydkXKFSTnA P_0, YTmNgxesTItBQnBvsDOydkXKFSTnA P_1)
	{
		return !P_0.wzVZJGRvlZTFJoNkorjhIfOUVEoM(ref P_1);
	}

	public string gGSlBOBKVFrvyVGAzVrnvmUUuvGR()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", yjmCGtZZxlCuwenCzISUackcFdBy, NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public string ikNXMfpHhttKxbwLmKRREvokHhyv(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", yjmCGtZZxlCuwenCzISUackcFdBy.ToString(P_0, CultureInfo.CurrentCulture), NMzSMZgXAnTTtzOAlLRktyttbQZP.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string dksGmhWarZEUADLOdCunZuzmBzAEA(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", yjmCGtZZxlCuwenCzISUackcFdBy, NMzSMZgXAnTTtzOAlLRktyttbQZP);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			dksGmhWarZEUADLOdCunZuzmBzAEA(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", yjmCGtZZxlCuwenCzISUackcFdBy.ToString(format, formatProvider), NMzSMZgXAnTTtzOAlLRktyttbQZP.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int JPnsjMUELOyldqKDvpfrsCdTnamD()
	{
		return (yjmCGtZZxlCuwenCzISUackcFdBy.GetHashCode() * 397) ^ NMzSMZgXAnTTtzOAlLRktyttbQZP.GetHashCode();
	}

	public bool wzVZJGRvlZTFJoNkorjhIfOUVEoM(ref YTmNgxesTItBQnBvsDOydkXKFSTnA P_0)
	{
		if (ouJCRYIccCnMbiacKQSFQszJhffXA.kGhGZCfRPoeZOUTDrSlAIYbbbTxsB(P_0.yjmCGtZZxlCuwenCzISUackcFdBy, yjmCGtZZxlCuwenCzISUackcFdBy))
		{
			return ouJCRYIccCnMbiacKQSFQszJhffXA.kGhGZCfRPoeZOUTDrSlAIYbbbTxsB(P_0.NMzSMZgXAnTTtzOAlLRktyttbQZP, NMzSMZgXAnTTtzOAlLRktyttbQZP);
		}
		return false;
	}

	public bool Equals(YTmNgxesTItBQnBvsDOydkXKFSTnA other)
	{
		return wzVZJGRvlZTFJoNkorjhIfOUVEoM(ref other);
	}

	bool IEquatable<YTmNgxesTItBQnBvsDOydkXKFSTnA>.Equals(YTmNgxesTItBQnBvsDOydkXKFSTnA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool bRozlqLglXIXlEztGXsnewHxgAcd(object P_0)
	{
		if (!(P_0 is YTmNgxesTItBQnBvsDOydkXKFSTnA yTmNgxesTItBQnBvsDOydkXKFSTnA))
		{
			return false;
		}
		return wzVZJGRvlZTFJoNkorjhIfOUVEoM(ref yTmNgxesTItBQnBvsDOydkXKFSTnA);
	}
}
