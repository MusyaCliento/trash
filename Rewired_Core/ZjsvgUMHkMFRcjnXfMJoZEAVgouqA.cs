using System;
using Rewired;

internal sealed class ZjsvgUMHkMFRcjnXfMJoZEAVgouqA : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType aDqdNhfzpmFlRSShaIXBDgORKDedA;

	private bool iNhrzKUJJWBCxevCBPmUQKllMaST;

	private IControllerElementTarget jxPRTTnaQqtscNnFfeNLipInrbZQ;

	private IControllerElementTarget rdIfttQLZruYlrGixwOMRYxQTvQP;

	private IControllerElementTarget JYnYjJOrVMuoQNcBRLuGllNLLsxr;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => GHPcAvLGyrhUIIuLWeQoyFTYgunBA.RzfkBiUeYvmCRKRlxaKBmuncGxXe(aDqdNhfzpmFlRSShaIXBDgORKDedA, false);

	bool IControllerTemplateAxisSource.splitAxis => iNhrzKUJJWBCxevCBPmUQKllMaST;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => jxPRTTnaQqtscNnFfeNLipInrbZQ;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => rdIfttQLZruYlrGixwOMRYxQTvQP;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => JYnYjJOrVMuoQNcBRLuGllNLLsxr;

	IControllerElementTarget IControllerTemplateButtonSource.target => jxPRTTnaQqtscNnFfeNLipInrbZQ;

	internal ZjsvgUMHkMFRcjnXfMJoZEAVgouqA(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("target");
		}
		if (P_4 == null)
		{
			throw new ArgumentNullException("positiveTarget");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("negativeTarget");
		}
		aDqdNhfzpmFlRSShaIXBDgORKDedA = P_0;
		iNhrzKUJJWBCxevCBPmUQKllMaST = P_1;
		jxPRTTnaQqtscNnFfeNLipInrbZQ = P_2;
		rdIfttQLZruYlrGixwOMRYxQTvQP = P_3;
		JYnYjJOrVMuoQNcBRLuGllNLLsxr = P_4;
	}

	internal static ZjsvgUMHkMFRcjnXfMJoZEAVgouqA UgJqQFedtMXhSrKVrFdnnDIAlKxe(ControllerTemplateElementType P_0)
	{
		return new ZjsvgUMHkMFRcjnXfMJoZEAVgouqA(P_0, false, oFieiUIUewVeTJqZtmiJuPDLbluKA.qXUNZZuijDscRtCotpGpTMLihHXH(), oFieiUIUewVeTJqZtmiJuPDLbluKA.qXUNZZuijDscRtCotpGpTMLihHXH(), oFieiUIUewVeTJqZtmiJuPDLbluKA.qXUNZZuijDscRtCotpGpTMLihHXH());
	}
}
