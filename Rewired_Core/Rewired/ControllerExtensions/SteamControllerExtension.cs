using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class hBoCqhkEhVYUcptBySCASLFuozKTA : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal lysGDpgymVVDKDCTzpSUcObemolub;

			public hBoCqhkEhVYUcptBySCASLFuozKTA(ISteamControllerInternal P_0)
			{
				lysGDpgymVVDKDCTzpSUcObemolub = P_0;
			}
		}

		private hBoCqhkEhVYUcptBySCASLFuozKTA XJXpEDLhdxjprDQIdIVrFRSfDvnQB;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub;

		internal SteamControllerExtension(ISteamControllerInternal P_0)
			: base(new hBoCqhkEhVYUcptBySCASLFuozKTA(P_0))
		{
			yVvyVYMgZGextwxvCZOAMMcuOQXn();
		}

		private SteamControllerExtension(SteamControllerExtension P_0)
			: base(P_0)
		{
			yVvyVYMgZGextwxvCZOAMMcuOQXn();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.ShowBindingPanel();
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.SetHapticPulse(targePad, durationSeconds);
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return XJXpEDLhdxjprDQIdIVrFRSfDvnQB.lysGDpgymVVDKDCTzpSUcObemolub.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			XJXpEDLhdxjprDQIdIVrFRSfDvnQB = source as hBoCqhkEhVYUcptBySCASLFuozKTA;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void yVvyVYMgZGextwxvCZOAMMcuOQXn()
		{
		}
	}
}
