using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class TnoRqImDjcECtKPzwXKjwDnoigZnA : ISteamControllerInternal
{
	private static Dictionary<string, ulong> AgnxLfUUBYNQKmxpblEjyXlmrzHk;

	private static Dictionary<string, ulong> jeFdxZASLaQFpKXAuxJEPvYpNKe;

	private static Dictionary<string, ulong> cotldIRphMiCntumwDXBNKNeIRWO;

	private static Dictionary<ulong, string> qOulCBjDBZqJQkyvipzAUpkrclRg;

	private static Dictionary<ulong, string> WHeKReAqgpDPJCMwhEemfUBHoNQbB;

	private static Dictionary<ulong, string> wjlCcrxjbqFXQnkBOmBUJagHVwtf;

	public readonly ulong nAUYieaXrTfZNOMxOuXsQKgTDRJx;

	private TgAaaZzJziTHXdkJSZequTgWUFUv[] sFGHCVdGyhiDvBPZyTsVAQdlBvWdA;

	private List<SteamControllerActionOrigin> dRFKAroYdkuldHyUmCLmmdURBHov;

	private ReadOnlyCollection<SteamControllerActionOrigin> RgdEIHJOUWnjhsikmEbXjCzKBlmm;

	int ISteamControllerInternal.MaxActionSourceCount => 8;

	bool ISteamControllerInternal.IsConnected => ArGLRTNamJWBoaaaNpkufJPcAwgu.HmYNuzELPpMaBhiRQYnNwIuiItef(nAUYieaXrTfZNOMxOuXsQKgTDRJx);

	public static void oAajIUjsuqVYffqVbgrabfejfGQxB(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			AgnxLfUUBYNQKmxpblEjyXlmrzHk = P_0;
			qOulCBjDBZqJQkyvipzAUpkrclRg = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void LThWtOkhAbkHJzfVQaMpcHbRNztV(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			jeFdxZASLaQFpKXAuxJEPvYpNKe = P_0;
			WHeKReAqgpDPJCMwhEemfUBHoNQbB = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public static void epwyaIVlMNMfSXKdNJVmdHNdcEHW(Dictionary<string, ulong> P_0)
	{
		if (P_0 != null && P_0.Count != 0)
		{
			cotldIRphMiCntumwDXBNKNeIRWO = P_0;
			wjlCcrxjbqFXQnkBOmBUJagHVwtf = CollectionTools.CreateInverseDictionary(P_0);
		}
	}

	public TnoRqImDjcECtKPzwXKjwDnoigZnA(ulong P_0)
	{
		nAUYieaXrTfZNOMxOuXsQKgTDRJx = P_0;
		sFGHCVdGyhiDvBPZyTsVAQdlBvWdA = new TgAaaZzJziTHXdkJSZequTgWUFUv[8];
		dRFKAroYdkuldHyUmCLmmdURBHov = new List<SteamControllerActionOrigin>(8);
		RgdEIHJOUWnjhsikmEbXjCzKBlmm = new ReadOnlyCollection<SteamControllerActionOrigin>(dRFKAroYdkuldHyUmCLmmdURBHov);
	}

	public string GetActionSetName(ulong handle)
	{
		return ZTpluwhkgGugPdIdkYkcJeiefuyH(qOulCBjDBZqJQkyvipzAUpkrclRg, handle);
	}

	string ISteamControllerInternal.GetActionSetName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetName
		return this.GetActionSetName(handle);
	}

	public string GetDigitalActionName(ulong handle)
	{
		return ZTpluwhkgGugPdIdkYkcJeiefuyH(wjlCcrxjbqFXQnkBOmBUJagHVwtf, handle);
	}

	string ISteamControllerInternal.GetDigitalActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionName
		return this.GetDigitalActionName(handle);
	}

	public string GetAnalogActionName(ulong handle)
	{
		return ZTpluwhkgGugPdIdkYkcJeiefuyH(WHeKReAqgpDPJCMwhEemfUBHoNQbB, handle);
	}

	string ISteamControllerInternal.GetAnalogActionName(ulong handle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionName
		return this.GetAnalogActionName(handle);
	}

	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return xphYfotBMRCCvmmDBCJnVcqQwXFg(AgnxLfUUBYNQKmxpblEjyXlmrzHk, ref actionSetName);
	}

	ulong ISteamControllerInternal.GetActionSetHandle(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActionSetHandle
		return this.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return xphYfotBMRCCvmmDBCJnVcqQwXFg(cotldIRphMiCntumwDXBNKNeIRWO, ref actionName);
	}

	ulong ISteamControllerInternal.GetDigitalActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionHandle
		return this.GetDigitalActionHandle(ref actionName);
	}

	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return xphYfotBMRCCvmmDBCJnVcqQwXFg(jeFdxZASLaQFpKXAuxJEPvYpNKe, ref actionName);
	}

	ulong ISteamControllerInternal.GetAnalogActionHandle(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionHandle
		return this.GetAnalogActionHandle(ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return default(Vector2);
		}
		try
		{
			AVWdbhzvXTMFixgfJhJvFXkaOBZrA aVWdbhzvXTMFixgfJhJvFXkaOBZrA = ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.kRgctVdmfHCnglIHAeqBBouGaxSg(nAUYieaXrTfZNOMxOuXsQKgTDRJx, actionHandle);
			if (!aVWdbhzvXTMFixgfJhJvFXkaOBZrA.npjMJZVMPMHVpicgCQBvLgqlKnHZ)
			{
				return default(Vector2);
			}
			return new Vector2(aVWdbhzvXTMFixgfJhJvFXkaOBZrA.KkrsurqYvZLvezxTsqKQLYXMPqMT, aVWdbhzvXTMFixgfJhJvFXkaOBZrA.orLLDTMdDzIzPHmSLQmgWQGuYeJh);
		}
		catch
		{
			return default(Vector2);
		}
	}

	Vector2 ISteamControllerInternal.GetAnalogActionValue(ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionValue
		return this.GetAnalogActionValue(actionHandle);
	}

	public Vector2 GetAnalogActionValue(ref string actionName)
	{
		ulong analogActionHandle = GetAnalogActionHandle(ref actionName);
		return GetAnalogActionValue(analogActionHandle);
	}

	Vector2 ISteamControllerInternal.GetAnalogActionValue(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionValue
		return this.GetAnalogActionValue(ref actionName);
	}

	public bool GetDigitalActionValue(ulong actionHandle)
	{
		if (actionHandle == 0L)
		{
			return false;
		}
		try
		{
			rGpxtodvTgCBWUyahqRfNQGKyfWw rGpxtodvTgCBWUyahqRfNQGKyfWw2 = ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.oCRCqtRbjHAcqkBBaLEdfRlcTcOIA(nAUYieaXrTfZNOMxOuXsQKgTDRJx, actionHandle);
			Debug.Log(actionHandle + " state = " + rGpxtodvTgCBWUyahqRfNQGKyfWw2.vrTtOXWYXDAaOcTMxXpBbQKRtdzI + " active = " + rGpxtodvTgCBWUyahqRfNQGKyfWw2.SgIHxSNZemMSaZceIuCwKlIsHtoi);
			return rGpxtodvTgCBWUyahqRfNQGKyfWw2.SgIHxSNZemMSaZceIuCwKlIsHtoi && rGpxtodvTgCBWUyahqRfNQGKyfWw2.vrTtOXWYXDAaOcTMxXpBbQKRtdzI;
		}
		catch
		{
			return false;
		}
	}

	bool ISteamControllerInternal.GetDigitalActionValue(ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionValue
		return this.GetDigitalActionValue(actionHandle);
	}

	public bool GetDigitalActionValue(ref string actionName)
	{
		ulong digitalActionHandle = GetDigitalActionHandle(ref actionName);
		return GetDigitalActionValue(digitalActionHandle);
	}

	bool ISteamControllerInternal.GetDigitalActionValue(ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionValue
		return this.GetDigitalActionValue(ref actionName);
	}

	public bool SetActiveActionSet(ulong actionSetHandle)
	{
		if (actionSetHandle == 0L)
		{
			return false;
		}
		try
		{
			ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.TnhdbOZfAJidxgRuuGYimXNhEemO(nAUYieaXrTfZNOMxOuXsQKgTDRJx, actionSetHandle);
			return true;
		}
		catch
		{
			return false;
		}
	}

	bool ISteamControllerInternal.SetActiveActionSet(ulong actionSetHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetActiveActionSet
		return this.SetActiveActionSet(actionSetHandle);
	}

	public bool SetActiveActionSet(ref string actionSetName)
	{
		ulong actionSetHandle = GetActionSetHandle(ref actionSetName);
		return SetActiveActionSet(actionSetHandle);
	}

	bool ISteamControllerInternal.SetActiveActionSet(ref string actionSetName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetActiveActionSet
		return this.SetActiveActionSet(ref actionSetName);
	}

	public ulong GetActiveActionSetHandle()
	{
		return ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.bkNhZWZQNwztSepYMhWwSrWmfhoj(nAUYieaXrTfZNOMxOuXsQKgTDRJx);
	}

	ulong ISteamControllerInternal.GetActiveActionSetHandle()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetHandle
		return this.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		return ZTpluwhkgGugPdIdkYkcJeiefuyH(qOulCBjDBZqJQkyvipzAUpkrclRg, ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.bkNhZWZQNwztSepYMhWwSrWmfhoj(nAUYieaXrTfZNOMxOuXsQKgTDRJx));
	}

	string ISteamControllerInternal.GetActiveActionSetName()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetActiveActionSetName
		return this.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.pJiNgCDswKxyVrnolmgcKIEbscJF(nAUYieaXrTfZNOMxOuXsQKgTDRJx);
	}

	void ISteamControllerInternal.ShowBindingPanel()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ShowBindingPanel
		this.ShowBindingPanel();
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.LizJYLGXSdDjNzMaTSdpLPSmpiuo(nAUYieaXrTfZNOMxOuXsQKgTDRJx, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationSeconds);
	}

	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.LizJYLGXSdDjNzMaTSdpLPSmpiuo(nAUYieaXrTfZNOMxOuXsQKgTDRJx, (uint)triggerPad, durationMicroSeconds);
	}

	void ISteamControllerInternal.SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetHapticPulse
		this.SetHapticPulse(triggerPad, durationMicroSeconds);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetDigitalActionOrigins(xphYfotBMRCCvmmDBCJnVcqQwXFg(AgnxLfUUBYNQKmxpblEjyXlmrzHk, ref actionSetName), xphYfotBMRCCvmmDBCJnVcqQwXFg(cotldIRphMiCntumwDXBNKNeIRWO, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		dRFKAroYdkuldHyUmCLmmdURBHov.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return RgdEIHJOUWnjhsikmEbXjCzKBlmm;
		}
		int num = ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.jorSzFdEoNZOamSfvDtwbBSsgpCu(nAUYieaXrTfZNOMxOuXsQKgTDRJx, actionSetHandle, actionHandle, sFGHCVdGyhiDvBPZyTsVAQdlBvWdA);
		for (int i = 0; i < num; i++)
		{
			dRFKAroYdkuldHyUmCLmmdURBHov.Add((SteamControllerActionOrigin)sFGHCVdGyhiDvBPZyTsVAQdlBvWdA[i]);
		}
		return RgdEIHJOUWnjhsikmEbXjCzKBlmm;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDigitalActionOrigins
		return this.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return GetAnalogActionOrigins(xphYfotBMRCCvmmDBCJnVcqQwXFg(AgnxLfUUBYNQKmxpblEjyXlmrzHk, ref actionSetName), xphYfotBMRCCvmmDBCJnVcqQwXFg(jeFdxZASLaQFpKXAuxJEPvYpNKe, ref actionName));
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		dRFKAroYdkuldHyUmCLmmdURBHov.Clear();
		if (actionSetHandle == 0L || actionHandle == 0L)
		{
			return RgdEIHJOUWnjhsikmEbXjCzKBlmm;
		}
		int num = ArGLRTNamJWBoaaaNpkufJPcAwgu.yzFGUSGhpmzwsSrCYMnOxNEYZBYY.coYTpmKCGCfVwlcuscyeicfRLKDFb(nAUYieaXrTfZNOMxOuXsQKgTDRJx, actionSetHandle, actionHandle, sFGHCVdGyhiDvBPZyTsVAQdlBvWdA);
		for (int i = 0; i < num; i++)
		{
			dRFKAroYdkuldHyUmCLmmdURBHov.Add((SteamControllerActionOrigin)sFGHCVdGyhiDvBPZyTsVAQdlBvWdA[i]);
		}
		return RgdEIHJOUWnjhsikmEbXjCzKBlmm;
	}

	IList<SteamControllerActionOrigin> ISteamControllerInternal.GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnalogActionOrigins
		return this.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	private ulong xphYfotBMRCCvmmDBCJnVcqQwXFg(Dictionary<string, ulong> P_0, ref string P_1)
	{
		if (P_0 == null || string.IsNullOrEmpty(P_1))
		{
			return 0uL;
		}
		if (!P_0.TryGetValue(P_1, out var value))
		{
			return 0uL;
		}
		return value;
	}

	private string ZTpluwhkgGugPdIdkYkcJeiefuyH(Dictionary<ulong, string> P_0, ulong P_1)
	{
		if (P_0 == null || P_1 == 0L)
		{
			return string.Empty;
		}
		if (!P_0.TryGetValue(P_1, out var value))
		{
			return string.Empty;
		}
		return value;
	}
}
