using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class oFieiUIUewVeTJqZtmiJuPDLbluKA : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class SqqRjMCbRBChxnJasqJyIHjOmOlI
	{
		public static readonly SqqRjMCbRBChxnJasqJyIHjOmOlI _003C_003E9 = new SqqRjMCbRBChxnJasqJyIHjOmOlI();

		public static Func<oFieiUIUewVeTJqZtmiJuPDLbluKA> _003C_003E9__30_0;

		internal oFieiUIUewVeTJqZtmiJuPDLbluKA KxkbKiNdTaWjreCGKhOFhCokwvzpA()
		{
			return qXUNZZuijDscRtCotpGpTMLihHXH();
		}
	}

	private static ObjectPool<oFieiUIUewVeTJqZtmiJuPDLbluKA> jPiEPRoJeyeHqdCSzqFngWrgtlDnB;

	private Controller RTnalkcboyCgVZydxdukeGbIHTUu;

	private int YcxjXRmUfljRKISlcVTLpxfnJcyC;

	private AxisRange oSMfzgSLQIMHfGNoOgUhJOuevDgR;

	private IObjectPool xzkeOhkvBcurVGGSNiXmTSXVQeQaA;

	private bool KXGaCDheBmEfjXfDORhGBRfTUHhab;

	int IControllerElementTarget.elementIdentifierId => YcxjXRmUfljRKISlcVTLpxfnJcyC;

	AxisRange IControllerElementTarget.axisRange => oSMfzgSLQIMHfGNoOgUhJOuevDgR;

	bool IControllerElementTarget.hasTarget => ((IControllerElementTarget)this).element != null;

	ControllerElementType IControllerElementTarget.elementType
	{
		get
		{
			if (((IControllerElementTarget)this).element == null)
			{
				return ControllerElementType.Axis;
			}
			return ((IControllerElementTarget)this).element.type;
		}
	}

	string IControllerElementTarget.descriptiveName
	{
		get
		{
			if (RTnalkcboyCgVZydxdukeGbIHTUu == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = RTnalkcboyCgVZydxdukeGbIHTUu.GetElementIdentifierById(YcxjXRmUfljRKISlcVTLpxfnJcyC);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = RTnalkcboyCgVZydxdukeGbIHTUu.GetElementById(YcxjXRmUfljRKISlcVTLpxfnJcyC);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, oSMfzgSLQIMHfGNoOgUhJOuevDgR);
		}
	}

	Controller IControllerElementTarget.controller => RTnalkcboyCgVZydxdukeGbIHTUu;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (RTnalkcboyCgVZydxdukeGbIHTUu == null)
			{
				return null;
			}
			if (RTnalkcboyCgVZydxdukeGbIHTUu.GetElementIdentifierById(YcxjXRmUfljRKISlcVTLpxfnJcyC) == null)
			{
				return null;
			}
			return RTnalkcboyCgVZydxdukeGbIHTUu.GetElementById(YcxjXRmUfljRKISlcVTLpxfnJcyC);
		}
	}

	public ControllerElementIdentifier swEcHjJflTlpJCbpJWpeUSNpKSvDb
	{
		get
		{
			if (RTnalkcboyCgVZydxdukeGbIHTUu == null)
			{
				return null;
			}
			return RTnalkcboyCgVZydxdukeGbIHTUu.GetElementIdentifierById(YcxjXRmUfljRKISlcVTLpxfnJcyC);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return xzkeOhkvBcurVGGSNiXmTSXVQeQaA;
		}
		set
		{
			xzkeOhkvBcurVGGSNiXmTSXVQeQaA = value;
		}
	}

	internal oFieiUIUewVeTJqZtmiJuPDLbluKA(Controller P_0, int P_1, AxisRange P_2)
	{
		RTnalkcboyCgVZydxdukeGbIHTUu = P_0;
		YcxjXRmUfljRKISlcVTLpxfnJcyC = P_1;
		oSMfzgSLQIMHfGNoOgUhJOuevDgR = P_2;
	}

	internal void aFxYjInlpvELvJknxLgqYRLJkxew(ControllerElementTarget P_0)
	{
		RTnalkcboyCgVZydxdukeGbIHTUu = P_0.controller;
		YcxjXRmUfljRKISlcVTLpxfnJcyC = P_0.elementIdentifierId;
		oSMfzgSLQIMHfGNoOgUhJOuevDgR = P_0.axisRange;
	}

	internal void qvQnXWEDVYfEYKvBtkyAilpojGBx(IControllerElementTarget P_0)
	{
		RTnalkcboyCgVZydxdukeGbIHTUu = P_0.controller;
		YcxjXRmUfljRKISlcVTLpxfnJcyC = P_0.elementIdentifierId;
		oSMfzgSLQIMHfGNoOgUhJOuevDgR = P_0.axisRange;
	}

	internal void WyTffWnCLfyQijhfjkbFktnWKoiH(oFieiUIUewVeTJqZtmiJuPDLbluKA P_0)
	{
		qvQnXWEDVYfEYKvBtkyAilpojGBx(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		RTnalkcboyCgVZydxdukeGbIHTUu = null;
		YcxjXRmUfljRKISlcVTLpxfnJcyC = -1;
		oSMfzgSLQIMHfGNoOgUhJOuevDgR = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (xzkeOhkvBcurVGGSNiXmTSXVQeQaA != null)
		{
			xzkeOhkvBcurVGGSNiXmTSXVQeQaA.Return(this);
		}
	}

	internal static oFieiUIUewVeTJqZtmiJuPDLbluKA pZpNgmIOCRrfzGKnsxiwpSAMtkWd()
	{
		if (jPiEPRoJeyeHqdCSzqFngWrgtlDnB == null)
		{
			jPiEPRoJeyeHqdCSzqFngWrgtlDnB = new ObjectPool<oFieiUIUewVeTJqZtmiJuPDLbluKA>(SqqRjMCbRBChxnJasqJyIHjOmOlI._003C_003E9.KxkbKiNdTaWjreCGKhOFhCokwvzpA);
		}
		return jPiEPRoJeyeHqdCSzqFngWrgtlDnB.Get();
	}

	internal static oFieiUIUewVeTJqZtmiJuPDLbluKA WKwdftlTADcIDJLOQftQVPMcNeXb(ControllerElementTarget P_0)
	{
		oFieiUIUewVeTJqZtmiJuPDLbluKA obj = pZpNgmIOCRrfzGKnsxiwpSAMtkWd();
		obj.aFxYjInlpvELvJknxLgqYRLJkxew(P_0);
		return obj;
	}

	internal static void DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA P_0)
	{
		if (P_0 != null && jPiEPRoJeyeHqdCSzqFngWrgtlDnB != null)
		{
			jPiEPRoJeyeHqdCSzqFngWrgtlDnB.Return(P_0);
		}
	}

	internal static oFieiUIUewVeTJqZtmiJuPDLbluKA qXUNZZuijDscRtCotpGpTMLihHXH()
	{
		return new oFieiUIUewVeTJqZtmiJuPDLbluKA(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		KkGYdeRtimHlDTQGlDjFKptAtejL(true);
		GC.SuppressFinalize(this);
	}

	protected void ePjruTNWFNcvgNborCVflXfJnbun()
	{
		try
		{
			KkGYdeRtimHlDTQGlDjFKptAtejL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void KkGYdeRtimHlDTQGlDjFKptAtejL(bool P_0)
	{
		if (!KXGaCDheBmEfjXfDORhGBRfTUHhab)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			KXGaCDheBmEfjXfDORhGBRfTUHhab = true;
		}
	}
}
