using Rewired;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using UnityEngine;

internal class xghRvlLxyPpXuZsJSeOklBaJSdvg : pRDgLchjiEOPcnRILfvcikMCaUIN, IUnifiedMouseSource
{
	Vector2 IUnifiedMouseSource.mousePosition => ((CustomPlatformUnifiedMouseSource)sWPFjYnAcmWomVnyVshIgCDrckwm).mousePosition;

	public xghRvlLxyPpXuZsJSeOklBaJSdvg(CustomPlatformUnifiedMouseSource P_0)
		: base(P_0, UnityUnifiedMouseSource.CreateHardwareMap())
	{
	}
}
