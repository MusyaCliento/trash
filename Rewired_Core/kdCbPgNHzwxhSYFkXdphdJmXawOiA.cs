using Rewired;
using Rewired.Internal.Localization;

internal sealed class kdCbPgNHzwxhSYFkXdphdJmXawOiA : KaCXFsFhskzfbhkKdLPgAorqiGtg, IKSacKLVyLBPnEFekyTvBVRtjkNe
{
	private readonly QYJjXxsVdyEaAjTsqvDHkTMqFyjf LJAvuwjayKgjMOzjeRqRpCIdmefP;

	private readonly int QqfgbBoFLNRxjfgEehGzTsfmglvl;

	private DeviceLocalizationInfo qXrYazQPueDiuPvHayBDAcLbeaUj;

	string jFvndfajLIsLMxvEcfhFneFXVWss.aWxJJrCnpmeqmclTDPTQjepbcypsA
	{
		get
		{
			BMeYXymsuXMDMyjfaaClzmryYLZG bMeYXymsuXMDMyjfaaClzmryYLZG = jHDjZvhOfZsaPJjgnWiFftWkqNrU();
			if (bMeYXymsuXMDMyjfaaClzmryYLZG == null)
			{
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return bMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName;
			}
			LocalizationManager.TryGetCachedLocalizedString(GJDamLJnmQxyXObUvmZciZVlGxPjA, bMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
			if (!GJDamLJnmQxyXObUvmZciZVlGxPjA.hasCachedValue || localizationVersionChanged)
			{
				DTXBHoWlhfJgnmlLPGnqIDrGONgbA.zahdbSAUJOZiVcMIeFoRAiWwqiThb(GJDamLJnmQxyXObUvmZciZVlGxPjA, bMeYXymsuXMDMyjfaaClzmryYLZG.key, DTXBHoWlhfJgnmlLPGnqIDrGONgbA.rKZLbwvQEuvapvevyByhVXyXAdBh(LJAvuwjayKgjMOzjeRqRpCIdmefP), bMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName, LocalizationManager.version, qXrYazQPueDiuPvHayBDAcLbeaUj, LJAvuwjayKgjMOzjeRqRpCIdmefP, QqfgbBoFLNRxjfgEehGzTsfmglvl, AxisRange.Full, -1, out result);
			}
			return result;
		}
	}

	DeviceLocalizationInfo IKSacKLVyLBPnEFekyTvBVRtjkNe.zLLhpYIXxjXosNBqIwKAIcSZIvLU => qXrYazQPueDiuPvHayBDAcLbeaUj;

	public string rdpSDGOkiGxqfiIQavxKeiPYoFql(int P_0)
	{
		if ((uint)P_0 >= (uint)base.yZBdXgdDSghBAUYbkSVxaHpdCAij || PljaZLFOGRhIAIoRRVsExUixqujV == null)
		{
			return string.Empty;
		}
		DDLiMrEdceQRXQSrNifvymIZIsut dDLiMrEdceQRXQSrNifvymIZIsut = jHDjZvhOfZsaPJjgnWiFftWkqNrU();
		if (dDLiMrEdceQRXQSrNifvymIZIsut == null)
		{
			return string.Empty;
		}
		if (!LocalizationManager.isEnabled)
		{
			return dDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementNonLocalizedDescriptiveName(P_0);
		}
		LocalizedString localizedString = PljaZLFOGRhIAIoRRVsExUixqujV[P_0];
		string specialElementKey = dDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementKey(P_0);
		LocalizationManager.TryGetCachedLocalizedString(localizedString, specialElementKey, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
		if (!localizedString.hasCachedValue || localizationVersionChanged)
		{
			DTXBHoWlhfJgnmlLPGnqIDrGONgbA.zahdbSAUJOZiVcMIeFoRAiWwqiThb(localizedString, specialElementKey, DTXBHoWlhfJgnmlLPGnqIDrGONgbA.rKZLbwvQEuvapvevyByhVXyXAdBh(LJAvuwjayKgjMOzjeRqRpCIdmefP), dDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementNonLocalizedDescriptiveName(P_0), LocalizationManager.version, qXrYazQPueDiuPvHayBDAcLbeaUj, LJAvuwjayKgjMOzjeRqRpCIdmefP, QqfgbBoFLNRxjfgEehGzTsfmglvl, AxisRange.Full, P_0, out result);
		}
		return result;
	}

	private kdCbPgNHzwxhSYFkXdphdJmXawOiA(QYJjXxsVdyEaAjTsqvDHkTMqFyjf P_0, KMtjipaOdFdYovyjrhBVREbSUYnh P_1, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_2, int P_3, DeviceLocalizationInfo P_4)
		: base(P_1, P_2)
	{
		LJAvuwjayKgjMOzjeRqRpCIdmefP = P_0;
		QqfgbBoFLNRxjfgEehGzTsfmglvl = P_3;
		qXrYazQPueDiuPvHayBDAcLbeaUj = P_4;
	}

	private kdCbPgNHzwxhSYFkXdphdJmXawOiA(DDLiMrEdceQRXQSrNifvymIZIsut P_0, QYJjXxsVdyEaAjTsqvDHkTMqFyjf P_1, KMtjipaOdFdYovyjrhBVREbSUYnh P_2, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_3, int P_4, DeviceLocalizationInfo P_5)
		: base(P_0, P_2, P_3)
	{
		LJAvuwjayKgjMOzjeRqRpCIdmefP = P_1;
		QqfgbBoFLNRxjfgEehGzTsfmglvl = P_4;
		qXrYazQPueDiuPvHayBDAcLbeaUj = P_5;
	}

	public static kdCbPgNHzwxhSYFkXdphdJmXawOiA hcFqECqWqKthvIsgrxcUKUnAOnnA(QYJjXxsVdyEaAjTsqvDHkTMqFyjf P_0, KMtjipaOdFdYovyjrhBVREbSUYnh P_1, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_2, int P_3, DeviceLocalizationInfo P_4)
	{
		return new kdCbPgNHzwxhSYFkXdphdJmXawOiA(P_0, P_1, P_2, P_3, P_4);
	}

	public static kdCbPgNHzwxhSYFkXdphdJmXawOiA RezTTLveYwLxiDxrlApgcqZRzhfd(DDLiMrEdceQRXQSrNifvymIZIsut P_0, QYJjXxsVdyEaAjTsqvDHkTMqFyjf P_1, KMtjipaOdFdYovyjrhBVREbSUYnh P_2, jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_3, int P_4, DeviceLocalizationInfo P_5)
	{
		kdCbPgNHzwxhSYFkXdphdJmXawOiA obj = new kdCbPgNHzwxhSYFkXdphdJmXawOiA(P_0, P_1, P_2, P_3, P_4, P_5);
		obj.LXXnWsDVIgOSTwkzKCSaFgvWkxDIA();
		return obj;
	}

	public bool mNchTAJJdYnpxkLsJAGtqUNLqXscb(jFvndfajLIsLMxvEcfhFneFXVWss P_0, bool P_1)
	{
		if (!(P_0 is kdCbPgNHzwxhSYFkXdphdJmXawOiA kdCbPgNHzwxhSYFkXdphdJmXawOiA2))
		{
			return false;
		}
		if (!TJeKbwiNhZhFdCMXbGPyoLKHBpJfb(P_0, P_1))
		{
			return false;
		}
		if (LJAvuwjayKgjMOzjeRqRpCIdmefP == kdCbPgNHzwxhSYFkXdphdJmXawOiA2.LJAvuwjayKgjMOzjeRqRpCIdmefP && QqfgbBoFLNRxjfgEehGzTsfmglvl == kdCbPgNHzwxhSYFkXdphdJmXawOiA2.QqfgbBoFLNRxjfgEehGzTsfmglvl)
		{
			return DeviceLocalizationInfo.DataMatches(qXrYazQPueDiuPvHayBDAcLbeaUj, kdCbPgNHzwxhSYFkXdphdJmXawOiA2.qXrYazQPueDiuPvHayBDAcLbeaUj);
		}
		return false;
	}
}
