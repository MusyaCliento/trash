using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class pRDgLchjiEOPcnRILfvcikMCaUIN : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource sWPFjYnAcmWomVnyVshIgCDrckwm;

	private readonly HardwareControllerMap_Game ctDIfQDIMRVefoloMhxvgwpcgAxiA;

	private bool wFQtvoBGSVOkAAwWoaYiLCRMQojV;

	public InputSource inputSource => InputSource.Custom;

	public HardwareControllerMap_Game hardwareMap => ctDIfQDIMRVefoloMhxvgwpcgAxiA;

	public int axisCount => sWPFjYnAcmWomVnyVshIgCDrckwm.axisCount;

	public int buttonCount => sWPFjYnAcmWomVnyVshIgCDrckwm.buttonCount;

	public Controller.Extension controllerExtension => sWPFjYnAcmWomVnyVshIgCDrckwm.controllerExtension;

	public pRDgLchjiEOPcnRILfvcikMCaUIN(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		sWPFjYnAcmWomVnyVshIgCDrckwm = P_0;
		ctDIfQDIMRVefoloMhxvgwpcgAxiA = P_1;
	}

	public void Clear()
	{
		sWPFjYnAcmWomVnyVshIgCDrckwm.EzGdavrwXRDGejzHKLZyKHleVOWU();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		sWPFjYnAcmWomVnyVshIgCDrckwm.dyMKNzRtxHDYgJqCxtnUUKsUKIIF(dataUpdater);
	}

	public void FoEgKvCSSVATzcsDVVwiHqBhsGQq()
	{
		sWPFjYnAcmWomVnyVshIgCDrckwm.PfkBaPDVMyRtqEQbRKeFNCPeCxIaA();
	}

	protected virtual void dAffdGgZmfHPfuAhAlFxFJSLfqAw(bool P_0)
	{
		if (!wFQtvoBGSVOkAAwWoaYiLCRMQojV)
		{
			if (P_0 && sWPFjYnAcmWomVnyVshIgCDrckwm != null)
			{
				((IDisposable)sWPFjYnAcmWomVnyVshIgCDrckwm).Dispose();
			}
			wFQtvoBGSVOkAAwWoaYiLCRMQojV = true;
		}
	}

	void IDisposable.Dispose()
	{
		dAffdGgZmfHPfuAhAlFxFJSLfqAw(true);
		GC.SuppressFinalize(this);
	}
}
