using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;

internal class eiLWwlzVJeseqUWxMFDDBdBzIEdkA : PlatformInputManager, XxcRWDacxPwaZuelhLPGabtEumyQ
{
	private class wKijuDZUjWtKaiUIyrWxEquIfJhV : IInputManagerJoystick, IInputManagerJoystickPublic, IGetValues<Controller.Extension>
	{
		private enum oSjIvAmdbasVdKYkhIPzWMTbPhbd
		{
			None = 0,
			Valid = 1,
			Invalid = 2,
			PendingRemoval = 3
		}

		private int sLvfflkZfaaalMHCsuYLfsBgQUBl;

		private int EfUUUDNMKLkXRAPBUSHedPVHOEfF;

		public Guid TSkKbcNlQcILnfPqFcLYJSNFyJjQA;

		public string XpEVitpWsoXuBDzXxdpmpaaxvFBK;

		private readonly VANUTLsVUcepnrrsTIUZlnrrdggd PRNWEgpHlknToxIwlfNCJhWEiLHL;

		private readonly DeviceType lmGGtKHaPgSacbcDqiGSUgJcGoafA;

		public string NsiDbJoWyAcgeceQYAoxZmGVFdgm;

		public string ruESEabnqsbiTACtjPdsWQAqsjlu;

		public string GDuFeGudgiHPWIiryvawxsJiHsUY;

		public int GrJfzOrvuHhGgCtFBcbhfvmJQFcv;

		public int LkmdjTIYRyLBShskJJpQWrEWOasr;

		public Guid wxhLRjNDTGYVtZkVgDrQiYOkEcnJ;

		public Guid OqERMJbGQjEkJJiwnMORQXBRHhPZ;

		public Guid ImSRosKpphJIGjmKgAFZqllNlASn;

		public int sMLBMVkMEbpMKqMnhrczsQpjqIXR;

		public int ZzQBPVlLotJonWnmVtQgNmDJFdRcA;

		public int ZFpGSjZiczZuAWnpXureMrnXFoZs;

		public int cRCNYQpURpVKkXTblOvrAbAmAICo;

		public int ZOONGaPymhzMOaorijtjglEXgRoC;

		public int PhOkofzuDhnDAkSGmmhbRPmJJYUj;

		public bool TqYGoZGZYnMivightGoDHyCoJxBiA;

		public bool ZphgXxCiKtRftwiGkbSugrfBQkzLA;

		public bool ojBmqFfjnKyjtBmDOBTQRCQIfDtcA;

		public int UKCelkbZFoFoGikdSqwYhVxapXLm;

		private float[] pKaXliGUvdJLMxgoUdjEixlhkuIL;

		private float[] bpfWVHVoRQpTJTVnlLQpzoqQhbbk;

		private bool[] gUuZDGwYptzTfZGkAbbPoPBtjxnp;

		private HardwareJoystickMap_InputManager VTvTcbwpEXySSiGCtsVDKtmwlJNE;

		private HDBCccmhGrnyJeNxDcBEeidlIFlE ltZedwRunpyYXNbdchJqlLgQjPWH;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> RPFIevxLhUzbhmSxScxgBHfRkANX;

		private bool tjBEKwmUzDJrwuWjshkWCvOPsOsK;

		private bool UrjYKEtslThvosWMXKEyhQKjzpCI;

		private bool VWncqploZKXrtnZEYPddFIYnloFV;

		[CompilerGenerated]
		private Action m_VDGHzfijStPLeadAlNCPSOHlWtIgA;

		[CompilerGenerated]
		private Action<bool> m_WZqDpNtFRDPjHksizBKkShgrHkRJA;

		private bool EqNclmjLNRhBVyqmzIGBdSWgSKWCb;

		public bool hASoeckensUwMrLwbVviUStbmILD
		{
			get
			{
				if (PRNWEgpHlknToxIwlfNCJhWEiLHL == null)
				{
					return false;
				}
				return PRNWEgpHlknToxIwlfNCJhWEiLHL.VWSXLNJpPZpyLvVWAebHbsdTMCEo != null;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return sLvfflkZfaaalMHCsuYLfsBgQUBl;
			}
			set
			{
				sLvfflkZfaaalMHCsuYLfsBgQUBl = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return EfUUUDNMKLkXRAPBUSHedPVHOEfF;
			}
			set
			{
				EfUUUDNMKLkXRAPBUSHedPVHOEfF = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => XpEVitpWsoXuBDzXxdpmpaaxvFBK;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (EfUUUDNMKLkXRAPBUSHedPVHOEfF < 0)
				{
					return null;
				}
				return EfUUUDNMKLkXRAPBUSHedPVHOEfF;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (PRNWEgpHlknToxIwlfNCJhWEiLHL == null)
				{
					return null;
				}
				return PRNWEgpHlknToxIwlfNCJhWEiLHL.ZTUgJyyvKoTYnVhVIJshSukzyiOi[0];
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => wxhLRjNDTGYVtZkVgDrQiYOkEcnJ;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		public bool HokkQwRVnPGCfSUNpwAPcxGHsvNx
		{
			get
			{
				if (!EqNclmjLNRhBVyqmzIGBdSWgSKWCb && PRNWEgpHlknToxIwlfNCJhWEiLHL != null)
				{
					return PRNWEgpHlknToxIwlfNCJhWEiLHL.DIgMquQcUiJUCmpcvVcSJQDlfzZM;
				}
				return false;
			}
		}

		public bool MWvChOjCnXETODivhYlcnwYEtZAjB => !VWncqploZKXrtnZEYPddFIYnloFV;

		public event Action VDGHzfijStPLeadAlNCPSOHlWtIgA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_VDGHzfijStPLeadAlNCPSOHlWtIgA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_VDGHzfijStPLeadAlNCPSOHlWtIgA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_VDGHzfijStPLeadAlNCPSOHlWtIgA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_VDGHzfijStPLeadAlNCPSOHlWtIgA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action<bool> WZqDpNtFRDPjHksizBKkShgrHkRJA
		{
			[CompilerGenerated]
			add
			{
				Action<bool> action = this.m_WZqDpNtFRDPjHksizBKkShgrHkRJA;
				Action<bool> action2;
				do
				{
					action2 = action;
					Action<bool> value2 = (Action<bool>)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_WZqDpNtFRDPjHksizBKkShgrHkRJA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<bool> action = this.m_WZqDpNtFRDPjHksizBKkShgrHkRJA;
				Action<bool> action2;
				do
				{
					action2 = action;
					Action<bool> value2 = (Action<bool>)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_WZqDpNtFRDPjHksizBKkShgrHkRJA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = HokkQwRVnPGCfSUNpwAPcxGHsvNx;
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = HokkQwRVnPGCfSUNpwAPcxGHsvNx;
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		int IGetValues<Controller.Extension>.GetValues(IList<Controller.Extension> results)
		{
			if (results == null)
			{
				return 0;
			}
			if (PRNWEgpHlknToxIwlfNCJhWEiLHL == null)
			{
				return 0;
			}
			int count = results.Count;
			IList<Controller.Extension> list = PRNWEgpHlknToxIwlfNCJhWEiLHL.ZTUgJyyvKoTYnVhVIJshSukzyiOi;
			int count2 = list.Count;
			for (int i = 0; i < count2; i++)
			{
				results.Add(list[i]);
			}
			return results.Count - count;
		}

		public wKijuDZUjWtKaiUIyrWxEquIfJhV(VANUTLsVUcepnrrsTIUZlnrrdggd P_0, DeviceType P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			PRNWEgpHlknToxIwlfNCJhWEiLHL = P_0;
			lmGGtKHaPgSacbcDqiGSUgJcGoafA = P_1;
			RPFIevxLhUzbhmSxScxgBHfRkANX = P_2;
			EfUUUDNMKLkXRAPBUSHedPVHOEfF = -1;
			sLvfflkZfaaalMHCsuYLfsBgQUBl = -1;
			VWncqploZKXrtnZEYPddFIYnloFV = true;
			if (P_0 != null && P_0.VWSXLNJpPZpyLvVWAebHbsdTMCEo != null)
			{
				VWncqploZKXrtnZEYPddFIYnloFV = P_0.VWSXLNJpPZpyLvVWAebHbsdTMCEo.IsInitialized;
				P_0.VWSXLNJpPZpyLvVWAebHbsdTMCEo.ErrorEvent += xicDgsIZSNLpCPOipszccrRTbNtqA;
				P_0.VWSXLNJpPZpyLvVWAebHbsdTMCEo.InitializedEvent += LcAyaoreDRgzKNGHqzmKivUXjwUj;
			}
		}

		public void rqPCaKBRAiDRwCciKATFhWzOLocpc()
		{
			if (!HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				return;
			}
			string obj = ((!string.IsNullOrEmpty(GDuFeGudgiHPWIiryvawxsJiHsUY)) ? GDuFeGudgiHPWIiryvawxsJiHsUY : ruESEabnqsbiTACtjPdsWQAqsjlu);
			Guid oqERMJbGQjEkJJiwnMORQXBRHhPZ = OqERMJbGQjEkJJiwnMORQXBRHhPZ;
			ImSRosKpphJIGjmKgAFZqllNlASn = MiscTools.CreateGuidHashSHA1(obj + oqERMJbGQjEkJJiwnMORQXBRHhPZ.ToString());
			ZzQBPVlLotJonWnmVtQgNmDJFdRcA = cRCNYQpURpVKkXTblOvrAbAmAICo;
			ZFpGSjZiczZuAWnpXureMrnXFoZs = ZOONGaPymhzMOaorijtjglEXgRoC + PhOkofzuDhnDAkSGmmhbRPmJJYUj * 8;
			BDVsFdsHKiqAaXSWLqEVKbuutzOb();
			TSkKbcNlQcILnfPqFcLYJSNFyJjQA = VTvTcbwpEXySSiGCtsVDKtmwlJNE.hardwareMapIdentifier.guid;
			XpEVitpWsoXuBDzXxdpmpaaxvFBK = VTvTcbwpEXySSiGCtsVDKtmwlJNE.controllerName;
			if (XpEVitpWsoXuBDzXxdpmpaaxvFBK == "Unknown Controller")
			{
				if (ZphgXxCiKtRftwiGkbSugrfBQkzLA && !string.IsNullOrEmpty(GDuFeGudgiHPWIiryvawxsJiHsUY))
				{
					XpEVitpWsoXuBDzXxdpmpaaxvFBK = GDuFeGudgiHPWIiryvawxsJiHsUY;
				}
				else if (!string.IsNullOrEmpty(ruESEabnqsbiTACtjPdsWQAqsjlu))
				{
					XpEVitpWsoXuBDzXxdpmpaaxvFBK = ruESEabnqsbiTACtjPdsWQAqsjlu;
				}
			}
			tjBEKwmUzDJrwuWjshkWCvOPsOsK = TSkKbcNlQcILnfPqFcLYJSNFyJjQA == Guid.Empty;
			pKaXliGUvdJLMxgoUdjEixlhkuIL = new float[ZzQBPVlLotJonWnmVtQgNmDJFdRcA];
			bpfWVHVoRQpTJTVnlLQpzoqQhbbk = new float[ZFpGSjZiczZuAWnpXureMrnXFoZs];
			gUuZDGwYptzTfZGkAbbPoPBtjxnp = new bool[ZFpGSjZiczZuAWnpXureMrnXFoZs];
			if (VTvTcbwpEXySSiGCtsVDKtmwlJNE != null && ZFpGSjZiczZuAWnpXureMrnXFoZs > 0)
			{
				switch (VTvTcbwpEXySSiGCtsVDKtmwlJNE.map.platform)
				{
				case InputPlatform.WindowsRawInput:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							gUuZDGwYptzTfZGkAbbPoPBtjxnp[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				case InputPlatform.WindowsDirectInput:
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							gUuZDGwYptzTfZGkAbbPoPBtjxnp[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			ltZedwRunpyYXNbdchJqlLgQjPWH = PRNWEgpHlknToxIwlfNCJhWEiLHL.qGuNfawbLaSlQvsGELkPmHLTaxkk;
			Update();
		}

		public void gczfSqfScKvLjnlEDCEuIkXSSKKBb(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0)
		{
			if (HokkQwRVnPGCfSUNpwAPcxGHsvNx && P_0 != null)
			{
				EfUUUDNMKLkXRAPBUSHedPVHOEfF = P_0.EfUUUDNMKLkXRAPBUSHedPVHOEfF;
				sLvfflkZfaaalMHCsuYLfsBgQUBl = P_0.sLvfflkZfaaalMHCsuYLfsBgQUBl;
				for (int i = 0; i < MathTools.Min(bpfWVHVoRQpTJTVnlLQpzoqQhbbk.Length, P_0.bpfWVHVoRQpTJTVnlLQpzoqQhbbk.Length); i++)
				{
					bpfWVHVoRQpTJTVnlLQpzoqQhbbk[i] = P_0.bpfWVHVoRQpTJTVnlLQpzoqQhbbk[i];
				}
				for (int j = 0; j < MathTools.Min(gUuZDGwYptzTfZGkAbbPoPBtjxnp.Length, P_0.gUuZDGwYptzTfZGkAbbPoPBtjxnp.Length); j++)
				{
					gUuZDGwYptzTfZGkAbbPoPBtjxnp[j] = P_0.gUuZDGwYptzTfZGkAbbPoPBtjxnp[j];
				}
				for (int k = 0; k < MathTools.Min(pKaXliGUvdJLMxgoUdjEixlhkuIL.Length, P_0.pKaXliGUvdJLMxgoUdjEixlhkuIL.Length); k++)
				{
					pKaXliGUvdJLMxgoUdjEixlhkuIL[k] = P_0.pKaXliGUvdJLMxgoUdjEixlhkuIL[k];
				}
				UrjYKEtslThvosWMXKEyhQKjzpCI = P_0.UrjYKEtslThvosWMXKEyhQKjzpCI;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				bool[] array = PRNWEgpHlknToxIwlfNCJhWEiLHL.gXBEEafTFlCbrgyNkDahyGkHfdwM;
				int[] array2 = PRNWEgpHlknToxIwlfNCJhWEiLHL.rljFnhZACKuRSqZtwsojLdAPPLML;
				DZfjtnrzotIqJhNTHaGBFvpYYmdxA(array, array2);
				GXtqtvJOCSBfNadFfnFbPntXxenVA(array, array2);
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				return;
			}
			if (ZzQBPVlLotJonWnmVtQgNmDJFdRcA != dataUpdater.axisCount || ZFpGSjZiczZuAWnpXureMrnXFoZs != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < ZzQBPVlLotJonWnmVtQgNmDJFdRcA; i++)
			{
				dataUpdater.axisValues[i] = pKaXliGUvdJLMxgoUdjEixlhkuIL[i];
			}
			for (int j = 0; j < ZFpGSjZiczZuAWnpXureMrnXFoZs; j++)
			{
				if (gUuZDGwYptzTfZGkAbbPoPBtjxnp[j])
				{
					dataUpdater.buttonPressureValues[j] = bpfWVHVoRQpTJTVnlLQpzoqQhbbk[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = bpfWVHVoRQpTJTVnlLQpzoqQhbbk[j] > 0f;
				}
			}
			if (UrjYKEtslThvosWMXKEyhQKjzpCI && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int tZmtrMjkavzAQJmPEHMTVDZWFhym(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0)
		{
			if (!HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				return 0;
			}
			if (P_0.sLvfflkZfaaalMHCsuYLfsBgQUBl == sLvfflkZfaaalMHCsuYLfsBgQUBl)
			{
				return 2;
			}
			if (cRCNYQpURpVKkXTblOvrAbAmAICo != P_0.cRCNYQpURpVKkXTblOvrAbAmAICo)
			{
				return 0;
			}
			if (ZOONGaPymhzMOaorijtjglEXgRoC != P_0.ZOONGaPymhzMOaorijtjglEXgRoC)
			{
				return 0;
			}
			if (PhOkofzuDhnDAkSGmmhbRPmJJYUj != P_0.PhOkofzuDhnDAkSGmmhbRPmJJYUj)
			{
				return 0;
			}
			if (hASoeckensUwMrLwbVviUStbmILD != P_0.hASoeckensUwMrLwbVviUStbmILD)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.ImSRosKpphJIGjmKgAFZqllNlASn == ImSRosKpphJIGjmKgAFZqllNlASn)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo StONbVypJozjndcHeFoZhBjlpexf()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			yzIASVfhalggoEaqmxYXrVFlVPJWA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			pAaqMrFOpnkhpNWwBthidrXWvGse(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(sLvfflkZfaaalMHCsuYLfsBgQUBl);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void DZfjtnrzotIqJhNTHaGBFvpYYmdxA(bool[] P_0, int[] P_1)
		{
			if (ZzQBPVlLotJonWnmVtQgNmDJFdRcA <= 0)
			{
				return;
			}
			switch (VTvTcbwpEXySSiGCtsVDKtmwlJNE.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						VePjtlIZjuYGmSFXnZejAjofGNBHb(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						VePjtlIZjuYGmSFXnZejAjofGNBHb(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						zbNdoXxPXMyNTIGMHEDqWLhtDKNL(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void GXtqtvJOCSBfNadFfnFbPntXxenVA(bool[] P_0, int[] P_1)
		{
			if (ZFpGSjZiczZuAWnpXureMrnXFoZs <= 0)
			{
				return;
			}
			switch (VTvTcbwpEXySSiGCtsVDKtmwlJNE.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						edXVyaWOlaoLtmKWDGaKkAVwGJLP(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						edXVyaWOlaoLtmKWDGaKkAVwGJLP(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)VTvTcbwpEXySSiGCtsVDKtmwlJNE.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						SKJCIBRPvAFiTDKqBSOFbcbokmVGb(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void VePjtlIZjuYGmSFXnZejAjofGNBHb(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= ZzQBPVlLotJonWnmVtQgNmDJFdRcA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			pKaXliGUvdJLMxgoUdjEixlhkuIL[P_1] = KJxBNsHmcGopNdiFfqbWCGmBHXPPB(P_0, P_2, P_3);
			if (!UrjYKEtslThvosWMXKEyhQKjzpCI && pKaXliGUvdJLMxgoUdjEixlhkuIL[P_1] != 0f)
			{
				UrjYKEtslThvosWMXKEyhQKjzpCI = true;
			}
		}

		private void edXVyaWOlaoLtmKWDGaKkAVwGJLP(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= ZFpGSjZiczZuAWnpXureMrnXFoZs)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			bpfWVHVoRQpTJTVnlLQpzoqQhbbk[P_1] = ObVXzwJbyAdIBsGRSOiprzRhfcBF(P_0, P_2, P_3);
			if (!UrjYKEtslThvosWMXKEyhQKjzpCI && bpfWVHVoRQpTJTVnlLQpzoqQhbbk[P_1] != 0f)
			{
				UrjYKEtslThvosWMXKEyhQKjzpCI = true;
			}
		}

		private float KJxBNsHmcGopNdiFfqbWCGmBHXPPB(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Axis axis))
						{
							return 0f;
						}
						num = axis.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				return qIesBWaAPmggGbyfCdLNKvdFXPoFA((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= ZOONGaPymhzMOaorijtjglEXgRoC || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= PhOkofzuDhnDAkSGmmhbRPmJJYUj || sourceHat >= 4)
				{
					return 0f;
				}
				int num2 = P_2[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = BkRItFOYeqtIcPFeMygmDjebCmB(num2, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num3 = BkRItFOYeqtIcPFeMygmDjebCmB(num2, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num3 *= -1f;
				}
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && MOsoJEYAiduTwcordtmscdPIdYMq(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			return 0f;
		}

		private float qIesBWaAPmggGbyfCdLNKvdFXPoFA(RawInputAxis P_0, int P_1)
		{
			return SdQSYbUBDejxMomsFRePZzeTnOoA((ltZedwRunpyYXNbdchJqlLgQjPWH as sgKnzlYAugAxgEuazGbXddXYpjfPA).qmOgenmGDMjdedDNpLMaocOGaNYnA(P_0, P_1));
		}

		private float ObVXzwJbyAdIBsGRSOiprzRhfcBF(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!P_1[P_0.requiredButtons[j]])
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= ZOONGaPymhzMOaorijtjglEXgRoC || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Button button))
						{
							return 0f;
						}
						num = button.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				float num2 = qIesBWaAPmggGbyfCdLNKvdFXPoFA((RawInputAxis)sourceAxis, num);
				float num3 = MathTools.Abs(num2);
				if (num3 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num2 < 0f)
					{
						return 0f;
					}
				}
				else if (num2 > 0f)
				{
					return 0f;
				}
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= PhOkofzuDhnDAkSGmmhbRPmJJYUj || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int k = 0; k < customCalculationSourceData.Length; k++)
				{
					if (customCalculationSourceData[k] == null)
					{
						continue;
					}
					switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
					{
						if (GCicEIvyeeIWXxtSBUGfxtBIadDL(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (MOsoJEYAiduTwcordtmscdPIdYMq(customCalculationSourceData[k], out var num4))
						{
							customCalculation.AddData((num4 != 0f) ? 1f : 0f);
						}
						break;
					}
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				if ((float)customCalculation.Result == 0f)
				{
					return 0f;
				}
				return 1f;
			}
			return 0f;
		}

		private float SdQSYbUBDejxMomsFRePZzeTnOoA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float MEYgtnuUrBvytvvjZfXChEeQKemE(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (VTvTcbwpEXySSiGCtsVDKtmwlJNE.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return 1f;
			}
			return 0f;
		}

		private float BkRItFOYeqtIcPFeMygmDjebCmB(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private bool GCicEIvyeeIWXxtSBUGfxtBIadDL(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= ZOONGaPymhzMOaorijtjglEXgRoC || sourceButton >= 256)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool MOsoJEYAiduTwcordtmscdPIdYMq(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = qIesBWaAPmggGbyfCdLNKvdFXPoFA((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType XPxLBRMbEmlxOHZuADlXuABoBxxw(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.Keyboard, 
				DeviceType.Joystick => ControlDeviceType.Joystick, 
				DeviceType.Gamepad => ControlDeviceType.Gamepad, 
				DeviceType.Mouse => ControlDeviceType.Mouse, 
				DeviceType.MultiAxisController => ControlDeviceType.Joystick, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void zbNdoXxPXMyNTIGMHEDqWLhtDKNL(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= ZzQBPVlLotJonWnmVtQgNmDJFdRcA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			pKaXliGUvdJLMxgoUdjEixlhkuIL[P_1] = ugzjjJxpSWXNAgQMnlNSpzCpniPN(P_0, P_2, P_3);
			if (!UrjYKEtslThvosWMXKEyhQKjzpCI && pKaXliGUvdJLMxgoUdjEixlhkuIL[P_1] != 0f)
			{
				UrjYKEtslThvosWMXKEyhQKjzpCI = true;
			}
		}

		private void SKJCIBRPvAFiTDKqBSOFbcbokmVGb(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= ZFpGSjZiczZuAWnpXureMrnXFoZs)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			bpfWVHVoRQpTJTVnlLQpzoqQhbbk[P_1] = FmLfXsNzyPkYXzacvKObbyNWuhDJ(P_0, P_2, P_3);
			if (!UrjYKEtslThvosWMXKEyhQKjzpCI && bpfWVHVoRQpTJTVnlLQpzoqQhbbk[P_1] != 0f)
			{
				UrjYKEtslThvosWMXKEyhQKjzpCI = true;
			}
		}

		private float ugzjjJxpSWXNAgQMnlNSpzCpniPN(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= cRCNYQpURpVKkXTblOvrAbAmAICo || sourceAxis >= 56)
				{
					return 0f;
				}
				return BmXtvVjExwvLWRHRXcGkOJBlBVJS(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= ZOONGaPymhzMOaorijtjglEXgRoC || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= PhOkofzuDhnDAkSGmmhbRPmJJYUj || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = BkRItFOYeqtIcPFeMygmDjebCmB(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = BkRItFOYeqtIcPFeMygmDjebCmB(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			return 0f;
		}

		private float BmXtvVjExwvLWRHRXcGkOJBlBVJS(int P_0)
		{
			return (ltZedwRunpyYXNbdchJqlLgQjPWH as tZexCHiMmKRLendpReaoTFICTkIx).QjGFqvUpJysGPNpweKGAkRnYetOf(P_0);
		}

		private float FmLfXsNzyPkYXzacvKObbyNWuhDJ(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= ZOONGaPymhzMOaorijtjglEXgRoC || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= cRCNYQpURpVKkXTblOvrAbAmAICo || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = BmXtvVjExwvLWRHRXcGkOJBlBVJS(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= PhOkofzuDhnDAkSGmmhbRPmJJYUj || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return MEYgtnuUrBvytvvjZfXChEeQKemE(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private bool FwhozYefUfcGVFlTQyKbCWjLwfyj(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float zPnvXKhAGgeXcmdbNIjsJyUaePSQ(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private void BDVsFdsHKiqAaXSWLqEVKbuutzOb()
		{
			VTvTcbwpEXySSiGCtsVDKtmwlJNE = RPFIevxLhUzbhmSxScxgBHfRkANX(StONbVypJozjndcHeFoZhBjlpexf());
			if (VTvTcbwpEXySSiGCtsVDKtmwlJNE == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			ZzQBPVlLotJonWnmVtQgNmDJFdRcA = VTvTcbwpEXySSiGCtsVDKtmwlJNE.axisCount;
			ZFpGSjZiczZuAWnpXureMrnXFoZs = VTvTcbwpEXySSiGCtsVDKtmwlJNE.buttonCount;
		}

		private string TXmCNZFphlMfdUNYsKThWEytMliO()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), PRNWEgpHlknToxIwlfNCJhWEiLHL.oZydMJiQQcjcKHviUOmAIRPKEzVJA, (ZphgXxCiKtRftwiGkbSugrfBQkzLA && !string.IsNullOrEmpty(GDuFeGudgiHPWIiryvawxsJiHsUY)) ? GDuFeGudgiHPWIiryvawxsJiHsUY : ruESEabnqsbiTACtjPdsWQAqsjlu, GrJfzOrvuHhGgCtFBcbhfvmJQFcv.ToString("X4"), LkmdjTIYRyLBShskJJpQWrEWOasr.ToString("X4")));
		}

		private void yzIASVfhalggoEaqmxYXrVFlVPJWA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = PRNWEgpHlknToxIwlfNCJhWEiLHL.oZydMJiQQcjcKHviUOmAIRPKEzVJA;
			P_0.deviceType = XPxLBRMbEmlxOHZuADlXuABoBxxw(lmGGtKHaPgSacbcDqiGSUgJcGoafA);
			P_0.hardwareIdentifier = TXmCNZFphlMfdUNYsKThWEytMliO();
			P_0.hardwareAxisCount = cRCNYQpURpVKkXTblOvrAbAmAICo;
			P_0.hardwareButtonCount = ZOONGaPymhzMOaorijtjglEXgRoC;
			P_0.hardwareHatCount = PhOkofzuDhnDAkSGmmhbRPmJJYUj;
			P_0.hw_productName = ruESEabnqsbiTACtjPdsWQAqsjlu;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_vendorId = LkmdjTIYRyLBShskJJpQWrEWOasr;
			P_0.hw_productId = GrJfzOrvuHhGgCtFBcbhfvmJQFcv;
			P_0.hw_pidVid = new PidVid(OqERMJbGQjEkJJiwnMORQXBRHhPZ);
			P_0.hw_isBluetoothDevice = ZphgXxCiKtRftwiGkbSugrfBQkzLA;
			P_0.hw_bluetoothDeviceName = GDuFeGudgiHPWIiryvawxsJiHsUY;
			P_0.hw_supportsVibration = ojBmqFfjnKyjtBmDOBTQRCQIfDtcA;
			P_0.hw_localVibrationMotorCount = UKCelkbZFoFoGikdSqwYhVxapXLm;
			P_0.definitionMatchTag = PRNWEgpHlknToxIwlfNCJhWEiLHL.TypAIrJwMuYsFPCrkpWiaRBgKwMlb;
		}

		private void pAaqMrFOpnkhpNWwBthidrXWvGse(BridgedController P_0)
		{
			yzIASVfhalggoEaqmxYXrVFlVPJWA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = VTvTcbwpEXySSiGCtsVDKtmwlJNE.ToGameHardwareControllerMap();
			P_0.instanceName = NsiDbJoWyAcgeceQYAoxZmGVFdgm;
			P_0.productName = ruESEabnqsbiTACtjPdsWQAqsjlu;
			P_0.isXInputDevice = TqYGoZGZYnMivightGoDHyCoJxBiA;
			P_0.axisCount = ZzQBPVlLotJonWnmVtQgNmDJFdRcA;
			P_0.buttonCount = ZFpGSjZiczZuAWnpXureMrnXFoZs;
			P_0.isButtonPressureSensitive = new bool[ZFpGSjZiczZuAWnpXureMrnXFoZs];
			Array.Copy(gUuZDGwYptzTfZGkAbbPoPBtjxnp, P_0.isButtonPressureSensitive, ZFpGSjZiczZuAWnpXureMrnXFoZs);
			P_0.unknownControllerHats = CncZmXMarZMJtCHtgiCwdBlEDAdCA();
			P_0.controllerTypeGuid = TSkKbcNlQcILnfPqFcLYJSNFyJjQA;
			P_0.controllerExtensions = ((PRNWEgpHlknToxIwlfNCJhWEiLHL != null) ? PRNWEgpHlknToxIwlfNCJhWEiLHL.ZTUgJyyvKoTYnVhVIJshSukzyiOi : null);
		}

		private void pexfSOHknOguDacDiWzqVMANYWcnA()
		{
			for (int i = 0; i < ZFpGSjZiczZuAWnpXureMrnXFoZs; i++)
			{
				bpfWVHVoRQpTJTVnlLQpzoqQhbbk[i] = 0f;
			}
			for (int j = 0; j < ZzQBPVlLotJonWnmVtQgNmDJFdRcA; j++)
			{
				pKaXliGUvdJLMxgoUdjEixlhkuIL[j] = 0f;
			}
		}

		private UnknownControllerHat[] CncZmXMarZMJtCHtgiCwdBlEDAdCA()
		{
			if (!tjBEKwmUzDJrwuWjshkWCvOPsOsK)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		private void xicDgsIZSNLpCPOipszccrRTbNtqA(HIDDeviceDriver.MiNaIzDPKzaXZdztgHayeKZcnRCwb P_0)
		{
			if (HIDDeviceDriver.IsCriticalError(P_0))
			{
				this.VDGHzfijStPLeadAlNCPSOHlWtIgA?.Invoke();
			}
		}

		private void LcAyaoreDRgzKNGHqzmKivUXjwUj()
		{
			bool flag = MWvChOjCnXETODivhYlcnwYEtZAjB;
			VWncqploZKXrtnZEYPddFIYnloFV = true;
			HOcDGSFOhbNrtoGQjpYQQFdEjWcj(flag);
		}

		private void HOcDGSFOhbNrtoGQjpYQQFdEjWcj(bool P_0)
		{
			if (P_0 != MWvChOjCnXETODivhYlcnwYEtZAjB)
			{
				this.WZqDpNtFRDPjHksizBKkShgrHkRJA?.Invoke(MWvChOjCnXETODivhYlcnwYEtZAjB);
			}
		}

		public void bQMBphCDEewlbJBCUlFNUcBdnyKSA()
		{
			gwCcrFfDcNhDZKJyZpdbCjfVTfgzA(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void ZCvcmMulQojVDkSLAWqsHrtHZYvg()
		{
			try
			{
				gwCcrFfDcNhDZKJyZpdbCjfVTfgzA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void gwCcrFfDcNhDZKJyZpdbCjfVTfgzA(bool P_0)
		{
			if (!EqNclmjLNRhBVyqmzIGBdSWgSKWCb)
			{
				if (P_0 && PRNWEgpHlknToxIwlfNCJhWEiLHL != null && PRNWEgpHlknToxIwlfNCJhWEiLHL.VWSXLNJpPZpyLvVWAebHbsdTMCEo != null)
				{
					PRNWEgpHlknToxIwlfNCJhWEiLHL.VWSXLNJpPZpyLvVWAebHbsdTMCEo.ErrorEvent -= xicDgsIZSNLpCPOipszccrRTbNtqA;
					PRNWEgpHlknToxIwlfNCJhWEiLHL.VWSXLNJpPZpyLvVWAebHbsdTMCEo.InitializedEvent -= LcAyaoreDRgzKNGHqzmKivUXjwUj;
				}
				EqNclmjLNRhBVyqmzIGBdSWgSKWCb = true;
			}
		}

		public static int QBbJtnMTLsrQfrCxhEkghRILuSKiA(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, wKijuDZUjWtKaiUIyrWxEquIfJhV P_1)
		{
			if (P_0.EfUUUDNMKLkXRAPBUSHedPVHOEfF < P_1.EfUUUDNMKLkXRAPBUSHedPVHOEfF)
			{
				return -1;
			}
			if (P_0.EfUUUDNMKLkXRAPBUSHedPVHOEfF > P_1.EfUUUDNMKLkXRAPBUSHedPVHOEfF)
			{
				return 1;
			}
			return 0;
		}

		public static int DlkxJecWfrPcHqCgNdATnVsQmxaK(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, wKijuDZUjWtKaiUIyrWxEquIfJhV P_1)
		{
			if (P_0.sMLBMVkMEbpMKqMnhrczsQpjqIXR < P_1.sMLBMVkMEbpMKqMnhrczsQpjqIXR)
			{
				return -1;
			}
			if (P_0.sMLBMVkMEbpMKqMnhrczsQpjqIXR > P_1.sMLBMVkMEbpMKqMnhrczsQpjqIXR)
			{
				return 1;
			}
			return 0;
		}
	}

	private class QnwKdPAYpBBAtCNXJTAQEFBPArTHA
	{
		public enum khlunZmoRYiFPOfIFanMRMAJjeuT
		{
			Exact = 0,
			Approximate = 1
		}

		public class aIggFUjIZtxuQhqUKAwmsQIUoUxA
		{
			public int LFqZJGUspPRfdLLAoGNBmdvVqhPy;

			public Guid JkPHSmElVLStfeWQsrlSlFfYssjy;

			public Guid iPoQzSgUjtuvNAlxYEqxfZWFDdt;

			public int xEPIPwimHEwlRZslYQSSJpaECjou;

			public int UYNTXmpavKTKiuBczdWGVKLIFIpKA;

			public int iLSvAUXTIZeAnhIOLEcKaPJBhkgU;

			public int tUVnvvDgqGXHQOwCgXcvzLGFUggE;

			public int JVhapZuIFgtuzCsUzKTNeEXnYbmU;

			public int qlGrXWrVxphPScYFKpWLCsOzVcxe;

			public bool KPOGrhBifIEMiZuLBavZGkYZjXFrA;

			public bool SxCbZOLoGRyrXIhPsLsBXLYNrsmP(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, khlunZmoRYiFPOfIFanMRMAJjeuT P_1)
			{
				if (UYNTXmpavKTKiuBczdWGVKLIFIpKA != P_0.cRCNYQpURpVKkXTblOvrAbAmAICo)
				{
					return false;
				}
				if (iLSvAUXTIZeAnhIOLEcKaPJBhkgU != P_0.ZOONGaPymhzMOaorijtjglEXgRoC)
				{
					return false;
				}
				if (tUVnvvDgqGXHQOwCgXcvzLGFUggE != P_0.PhOkofzuDhnDAkSGmmhbRPmJJYUj)
				{
					return false;
				}
				if (JVhapZuIFgtuzCsUzKTNeEXnYbmU != P_0.ZFpGSjZiczZuAWnpXureMrnXFoZs)
				{
					return false;
				}
				if (qlGrXWrVxphPScYFKpWLCsOzVcxe != P_0.ZzQBPVlLotJonWnmVtQgNmDJFdRcA)
				{
					return false;
				}
				if (KPOGrhBifIEMiZuLBavZGkYZjXFrA != P_0.hASoeckensUwMrLwbVviUStbmILD)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == LFqZJGUspPRfdLLAoGNBmdvVqhPy)
				{
					return true;
				}
				return P_1 switch
				{
					khlunZmoRYiFPOfIFanMRMAJjeuT.Exact => JkPHSmElVLStfeWQsrlSlFfYssjy == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					khlunZmoRYiFPOfIFanMRMAJjeuT.Approximate => iPoQzSgUjtuvNAlxYEqxfZWFDdt == P_0.ImSRosKpphJIGjmKgAFZqllNlASn, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string daFlnuFANrmkBnzPbAzRUdTFkqNw()
			{
				string text = "" + "rewiredId = " + LFqZJGUspPRfdLLAoGNBmdvVqhPy + "\n";
				Guid jkPHSmElVLStfeWQsrlSlFfYssjy = JkPHSmElVLStfeWQsrlSlFfYssjy;
				string text2 = text + "instanceGuid = " + jkPHSmElVLStfeWQsrlSlFfYssjy.ToString() + "\n";
				jkPHSmElVLStfeWQsrlSlFfYssjy = iPoQzSgUjtuvNAlxYEqxfZWFDdt;
				return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + jkPHSmElVLStfeWQsrlSlFfYssjy.ToString() + "\n", "lastInputManagerId = ", xEPIPwimHEwlRZslYQSSJpaECjou.ToString(), "\n"), "hardwareAxisCount = ", UYNTXmpavKTKiuBczdWGVKLIFIpKA.ToString(), "\n"), "hardwareButtonCount = ", iLSvAUXTIZeAnhIOLEcKaPJBhkgU.ToString(), "\n"), "hardwareHatCount = ", tUVnvvDgqGXHQOwCgXcvzLGFUggE.ToString(), "\n"), "gameButtonCount = ", JVhapZuIFgtuzCsUzKTNeEXnYbmU.ToString(), "\n"), "gameAxisCount = ", qlGrXWrVxphPScYFKpWLCsOzVcxe.ToString(), "\n"), "hasDriver = ", KPOGrhBifIEMiZuLBavZGkYZjXFrA.ToString(), "\n");
			}
		}

		private sealed class sQyxBGsdpqzgjMhIWHambVodtUqMA : IEnumerable<aIggFUjIZtxuQhqUKAwmsQIUoUxA>, IEnumerable, IEnumerator<aIggFUjIZtxuQhqUKAwmsQIUoUxA>, IEnumerator, IDisposable
		{
			private int AgMNGIBuZpbCscZzqDzxxLoEtdeo;

			private aIggFUjIZtxuQhqUKAwmsQIUoUxA tVTLBOuSjdTkzKSLodJuqHHTgazH;

			private int XRHmZBWPVxOzLEvmWqjesHkIjUYp;

			public QnwKdPAYpBBAtCNXJTAQEFBPArTHA kaJnkkvHcHjISFbEgllZdjyJYyAf;

			private wKijuDZUjWtKaiUIyrWxEquIfJhV UmpLUpMkVILvjkkiraAGIZkIDDPo;

			public wKijuDZUjWtKaiUIyrWxEquIfJhV eHwyqagaldnlmpKfpwNGPbnsKfXd;

			private khlunZmoRYiFPOfIFanMRMAJjeuT JGXGPKDJcTbgvFeYgXiEJYIJATZUb;

			public khlunZmoRYiFPOfIFanMRMAJjeuT akmHkJnRRCRIDJbvQhKOrNnHCvsE;

			private int tceyjroFVIldyFboMUbQziRTzBWe;

			private int HmAhfDKzkniLSJRkjvmuVCMlQGpFA;

			aIggFUjIZtxuQhqUKAwmsQIUoUxA IEnumerator<aIggFUjIZtxuQhqUKAwmsQIUoUxA>.Current
			{
				[DebuggerHidden]
				get
				{
					return tVTLBOuSjdTkzKSLodJuqHHTgazH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tVTLBOuSjdTkzKSLodJuqHHTgazH;
				}
			}

			[DebuggerHidden]
			public sQyxBGsdpqzgjMhIWHambVodtUqMA(int P_0)
			{
				AgMNGIBuZpbCscZzqDzxxLoEtdeo = P_0;
				XRHmZBWPVxOzLEvmWqjesHkIjUYp = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				AgMNGIBuZpbCscZzqDzxxLoEtdeo = -2;
			}

			private bool MoveNext()
			{
				int agMNGIBuZpbCscZzqDzxxLoEtdeo = AgMNGIBuZpbCscZzqDzxxLoEtdeo;
				QnwKdPAYpBBAtCNXJTAQEFBPArTHA qnwKdPAYpBBAtCNXJTAQEFBPArTHA = kaJnkkvHcHjISFbEgllZdjyJYyAf;
				if (agMNGIBuZpbCscZzqDzxxLoEtdeo != 0)
				{
					if (agMNGIBuZpbCscZzqDzxxLoEtdeo != 1)
					{
						return false;
					}
					AgMNGIBuZpbCscZzqDzxxLoEtdeo = -1;
					goto IL_0083;
				}
				AgMNGIBuZpbCscZzqDzxxLoEtdeo = -1;
				tceyjroFVIldyFboMUbQziRTzBWe = qnwKdPAYpBBAtCNXJTAQEFBPArTHA.VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count;
				HmAhfDKzkniLSJRkjvmuVCMlQGpFA = 0;
				goto IL_0093;
				IL_0083:
				HmAhfDKzkniLSJRkjvmuVCMlQGpFA++;
				goto IL_0093;
				IL_0093:
				if (HmAhfDKzkniLSJRkjvmuVCMlQGpFA < tceyjroFVIldyFboMUbQziRTzBWe)
				{
					if (qnwKdPAYpBBAtCNXJTAQEFBPArTHA.VFRgEyFSXxGYgDfEdFAnzypVVXOQ[HmAhfDKzkniLSJRkjvmuVCMlQGpFA].SxCbZOLoGRyrXIhPsLsBXLYNrsmP(UmpLUpMkVILvjkkiraAGIZkIDDPo, JGXGPKDJcTbgvFeYgXiEJYIJATZUb))
					{
						tVTLBOuSjdTkzKSLodJuqHHTgazH = qnwKdPAYpBBAtCNXJTAQEFBPArTHA.VFRgEyFSXxGYgDfEdFAnzypVVXOQ[HmAhfDKzkniLSJRkjvmuVCMlQGpFA];
						AgMNGIBuZpbCscZzqDzxxLoEtdeo = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<aIggFUjIZtxuQhqUKAwmsQIUoUxA> IEnumerable<aIggFUjIZtxuQhqUKAwmsQIUoUxA>.GetEnumerator()
			{
				sQyxBGsdpqzgjMhIWHambVodtUqMA sQyxBGsdpqzgjMhIWHambVodtUqMA2;
				if (AgMNGIBuZpbCscZzqDzxxLoEtdeo == -2 && XRHmZBWPVxOzLEvmWqjesHkIjUYp == Environment.CurrentManagedThreadId)
				{
					AgMNGIBuZpbCscZzqDzxxLoEtdeo = 0;
					sQyxBGsdpqzgjMhIWHambVodtUqMA2 = this;
				}
				else
				{
					sQyxBGsdpqzgjMhIWHambVodtUqMA2 = new sQyxBGsdpqzgjMhIWHambVodtUqMA(0);
					sQyxBGsdpqzgjMhIWHambVodtUqMA2.kaJnkkvHcHjISFbEgllZdjyJYyAf = kaJnkkvHcHjISFbEgllZdjyJYyAf;
				}
				sQyxBGsdpqzgjMhIWHambVodtUqMA2.UmpLUpMkVILvjkkiraAGIZkIDDPo = eHwyqagaldnlmpKfpwNGPbnsKfXd;
				sQyxBGsdpqzgjMhIWHambVodtUqMA2.JGXGPKDJcTbgvFeYgXiEJYIJATZUb = akmHkJnRRCRIDJbvQhKOrNnHCvsE;
				return sQyxBGsdpqzgjMhIWHambVodtUqMA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<aIggFUjIZtxuQhqUKAwmsQIUoUxA>)this).GetEnumerator();
			}
		}

		private List<aIggFUjIZtxuQhqUKAwmsQIUoUxA> VFRgEyFSXxGYgDfEdFAnzypVVXOQ;

		public QnwKdPAYpBBAtCNXJTAQEFBPArTHA()
		{
			VFRgEyFSXxGYgDfEdFAnzypVVXOQ = new List<aIggFUjIZtxuQhqUKAwmsQIUoUxA>();
		}

		public void cTtNVpOcRgNJkUwwLtrLWzWGkmFF(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].SxCbZOLoGRyrXIhPsLsBXLYNrsmP(P_0, khlunZmoRYiFPOfIFanMRMAJjeuT.Exact))
				{
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].LFqZJGUspPRfdLLAoGNBmdvVqhPy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].JkPHSmElVLStfeWQsrlSlFfYssjy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].iPoQzSgUjtuvNAlxYEqxfZWFDdt = P_0.ImSRosKpphJIGjmKgAFZqllNlASn;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].xEPIPwimHEwlRZslYQSSJpaECjou = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].UYNTXmpavKTKiuBczdWGVKLIFIpKA = P_0.cRCNYQpURpVKkXTblOvrAbAmAICo;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].iLSvAUXTIZeAnhIOLEcKaPJBhkgU = P_0.ZOONGaPymhzMOaorijtjglEXgRoC;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].tUVnvvDgqGXHQOwCgXcvzLGFUggE = P_0.PhOkofzuDhnDAkSGmmhbRPmJJYUj;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].JVhapZuIFgtuzCsUzKTNeEXnYbmU = P_0.ZFpGSjZiczZuAWnpXureMrnXFoZs;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].qlGrXWrVxphPScYFKpWLCsOzVcxe = P_0.ZzQBPVlLotJonWnmVtQgNmDJFdRcA;
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].KPOGrhBifIEMiZuLBavZGkYZjXFrA = P_0.hASoeckensUwMrLwbVviUStbmILD;
					NasBhBySdCxxujBbTbfBEUXoPaIBA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Add(new aIggFUjIZtxuQhqUKAwmsQIUoUxA
			{
				LFqZJGUspPRfdLLAoGNBmdvVqhPy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				JkPHSmElVLStfeWQsrlSlFfYssjy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				iPoQzSgUjtuvNAlxYEqxfZWFDdt = P_0.ImSRosKpphJIGjmKgAFZqllNlASn,
				xEPIPwimHEwlRZslYQSSJpaECjou = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				UYNTXmpavKTKiuBczdWGVKLIFIpKA = P_0.cRCNYQpURpVKkXTblOvrAbAmAICo,
				iLSvAUXTIZeAnhIOLEcKaPJBhkgU = P_0.ZOONGaPymhzMOaorijtjglEXgRoC,
				tUVnvvDgqGXHQOwCgXcvzLGFUggE = P_0.PhOkofzuDhnDAkSGmmhbRPmJJYUj,
				JVhapZuIFgtuzCsUzKTNeEXnYbmU = P_0.ZFpGSjZiczZuAWnpXureMrnXFoZs,
				qlGrXWrVxphPScYFKpWLCsOzVcxe = P_0.ZzQBPVlLotJonWnmVtQgNmDJFdRcA,
				KPOGrhBifIEMiZuLBavZGkYZjXFrA = P_0.hASoeckensUwMrLwbVviUStbmILD
			});
			NasBhBySdCxxujBbTbfBEUXoPaIBA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count - 1);
		}

		public bool DzYpIpFHRCONWlQevPIfHsdOKjjF(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, khlunZmoRYiFPOfIFanMRMAJjeuT P_1)
		{
			int count = VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].SxCbZOLoGRyrXIhPsLsBXLYNrsmP(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(sQyxBGsdpqzgjMhIWHambVodtUqMA))]
		public IEnumerable<aIggFUjIZtxuQhqUKAwmsQIUoUxA> lMIWZWxJuseLLioOCihPWOLEfEQT(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, khlunZmoRYiFPOfIFanMRMAJjeuT P_1)
		{
			return new sQyxBGsdpqzgjMhIWHambVodtUqMA(-2)
			{
				kaJnkkvHcHjISFbEgllZdjyJYyAf = this,
				eHwyqagaldnlmpKfpwNGPbnsKfXd = P_0,
				akmHkJnRRCRIDJbvQhKOrNnHCvsE = P_1
			};
		}

		private void NasBhBySdCxxujBbTbfBEUXoPaIBA(int P_0, Guid P_1, int P_2)
		{
			for (int num = VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (VFRgEyFSXxGYgDfEdFAnzypVVXOQ[num].LFqZJGUspPRfdLLAoGNBmdvVqhPy == P_0 || VFRgEyFSXxGYgDfEdFAnzypVVXOQ[num].JkPHSmElVLStfeWQsrlSlFfYssjy == P_1))
				{
					VFRgEyFSXxGYgDfEdFAnzypVVXOQ.RemoveAt(num);
				}
			}
		}

		public virtual string SupnlIJYlilFpRjIgKLbjkpsBZRu()
		{
			string text = "";
			text = text + "Joystick records: " + VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count + "\n";
			for (int i = 0; i < VFRgEyFSXxGYgDfEdFAnzypVVXOQ.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + VFRgEyFSXxGYgDfEdFAnzypVVXOQ[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private struct zZsZiQwEvhliIWgFOZKLLDCPrLYS
	{
		public wKijuDZUjWtKaiUIyrWxEquIfJhV WnRDgxksKgWDjkLYyGgRoohUPaPqA;

		public bool wDwHjqNaRiwqSAtGuhyGvMjOxPpl;

		public zZsZiQwEvhliIWgFOZKLLDCPrLYS(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, bool P_1)
		{
			WnRDgxksKgWDjkLYyGgRoohUPaPqA = P_0;
			wDwHjqNaRiwqSAtGuhyGvMjOxPpl = P_1;
		}
	}

	private sealed class WFSWoKUpcXKmwQwgjrbAPJlaxrhS
	{
		public wKijuDZUjWtKaiUIyrWxEquIfJhV LpHWBoIYKAnWLIHpbxvNoybzhbaP;

		public eiLWwlzVJeseqUWxMFDDBdBzIEdkA VjeTqUVOslfcJHPyePqBWstzbfToA;

		internal void iTUzHzPMdVcPUtmpvDHfhaDZNKbB(bool P_0)
		{
			VjeTqUVOslfcJHPyePqBWstzbfToA.jaAHPmfsaCgvwSVXTClQaEXdiAro(LpHWBoIYKAnWLIHpbxvNoybzhbaP, P_0);
		}
	}

	private CAMKjWWITLmVKNQaIYUpYBAnWcXD BtOMtPqkDCCvgvMeocaZzOjCTfMs;

	private List<wKijuDZUjWtKaiUIyrWxEquIfJhV> JeKpbnNIYDRrLTBPfHBNXZwJbNFw;

	private int cAOZAWuhfcKoKpVqfROXXpOjLrAF;

	private QnwKdPAYpBBAtCNXJTAQEFBPArTHA vZNqgzyLqtucYyRqaitOsUfnaOuS;

	private bool ENyxHKrYmthebTKVpcfFAXLegDhx;

	private TimerRealTime vJqeVmNcDrAnCiDurwkMttQZTwfJA;

	private global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool> fGlYkDFEUwDZusMaaTWfBQqjOJnh;

	private global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool> bdfbpjAzfBhJAklWiuMFWIlQYjNMA;

	private int dbsImjuXbwrrKooxCoOyBjqruRDW;

	private int jbODfMDXIqKYiQOFXPFJFDBmQSQbb;

	private readonly Queue<zZsZiQwEvhliIWgFOZKLLDCPrLYS> qZTSogjtBhtCIEbanxHULIdKjiVw;

	private ConfigVars EROEPavzlRfMOPGptSQGBnFaNjGB;

	private NmANKYQYjJJatXyTLQutNfBhTrds mbUMJINoNraMTHqPYVzUldXymsuyA;

	private Action<int, ControllerDataUpdater> JfHEBKXJaOctduZuSEMZbWlnSfdk;

	private PlatformInputManager RGOELoxPMtfagBcQHMdzqcfvIGPcA;

	private readonly fsCGaOEpsRBSmcVjAqpMyeMmPWhRA UghMgcgDqwomYTdneZKuMybzfOym;

	private readonly pKsmEHzqbGUnPrIgUbPlXlJimyVh UNARODWidReetDkFswVTghpaLzgJA;

	private readonly bool CadRokSzrlIenXlnHUrnvXhycGll;

	private readonly bool bWsPlRzQqfGXmUJJbVmRbobSgoKA;

	private readonly bool sivZnZogffoKcXPFGsRlopzdcIdk;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> FNQHdiZjSrRJdvgaXInzMRUrDQBS;

	private readonly Func<int> pJrIWhBhlsIfDVeocfMkReBHxBSq;

	NmANKYQYjJJatXyTLQutNfBhTrds XxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA
	{
		get
		{
			return mbUMJINoNraMTHqPYVzUldXymsuyA;
		}
		set
		{
			YogAZbtYYniRhKJTUxmdWNvJBxiaA = nmANKYQYjJJatXyTLQutNfBhTrds;
			BtOMtPqkDCCvgvMeocaZzOjCTfMs.MadMEQtHcRgWzBCUJeVLeqMUBmnH = nmANKYQYjJJatXyTLQutNfBhTrds;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => cAOZAWuhfcKoKpVqfROXXpOjLrAF;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => RGOELoxPMtfagBcQHMdzqcfvIGPcA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => BtOMtPqkDCCvgvMeocaZzOjCTfMs;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.RawInput;

	public eiLWwlzVJeseqUWxMFDDBdBzIEdkA(ConfigVars P_0, NmANKYQYjJJatXyTLQutNfBhTrds P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, bool P_4, bool P_5, bool P_6, bool P_7)
	{
		try
		{
			EROEPavzlRfMOPGptSQGBnFaNjGB = P_0;
			mbUMJINoNraMTHqPYVzUldXymsuyA = P_1;
			FNQHdiZjSrRJdvgaXInzMRUrDQBS = P_2;
			pJrIWhBhlsIfDVeocfMkReBHxBSq = P_3;
			CadRokSzrlIenXlnHUrnvXhycGll = P_4;
			bWsPlRzQqfGXmUJJbVmRbobSgoKA = P_5;
			sivZnZogffoKcXPFGsRlopzdcIdk = P_6;
			RGOELoxPMtfagBcQHMdzqcfvIGPcA = this;
			UpdateLoopSetting updateLoop = P_0.updateLoop;
			if (P_6)
			{
				UNARODWidReetDkFswVTghpaLzgJA = new pKsmEHzqbGUnPrIgUbPlXlJimyVh(updateLoop, P_0.unityUsePhysicalKeys, P_0.showSystemKeyLabels);
			}
			if (P_5)
			{
				UghMgcgDqwomYTdneZKuMybzfOym = new fsCGaOEpsRBSmcVjAqpMyeMmPWhRA(updateLoop);
			}
			BtOMtPqkDCCvgvMeocaZzOjCTfMs = new CAMKjWWITLmVKNQaIYUpYBAnWcXD(P_0, P_1, P_4, P_7, UghMgcgDqwomYTdneZKuMybzfOym, UNARODWidReetDkFswVTghpaLzgJA);
			JfHEBKXJaOctduZuSEMZbWlnSfdk = UpdateControllerData;
			fGlYkDFEUwDZusMaaTWfBQqjOJnh = new global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool>(true, zpvGpioElhPaOeAhJRZaWNkwCuSV);
			bdfbpjAzfBhJAklWiuMFWIlQYjNMA = new global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool>(true, BtOMtPqkDCCvgvMeocaZzOjCTfMs.HAprlQzxNAkiaqwqOQmUhZISUPTM);
			qZTSogjtBhtCIEbanxHULIdKjiVw = new Queue<zZsZiQwEvhliIWgFOZKLLDCPrLYS>();
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (CadRokSzrlIenXlnHUrnvXhycGll || BtOMtPqkDCCvgvMeocaZzOjCTfMs.noETkuHbzzGgCbhhbhTnEJdNuMyO)
		{
			vJqeVmNcDrAnCiDurwkMttQZTwfJA = new TimerRealTime(1.0);
			vJqeVmNcDrAnCiDurwkMttQZTwfJA.Start();
		}
		if (sivZnZogffoKcXPFGsRlopzdcIdk)
		{
			UNARODWidReetDkFswVTghpaLzgJA.kQwCANfCxdbbtGpnbdtMjJPSCeEEb();
		}
		if (CadRokSzrlIenXlnHUrnvXhycGll)
		{
			vZNqgzyLqtucYyRqaitOsUfnaOuS = new QnwKdPAYpBBAtCNXJTAQEFBPArTHA();
			jnVMbrqFeyBBcgNnPkQnlDWohDGjb();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (CadRokSzrlIenXlnHUrnvXhycGll || BtOMtPqkDCCvgvMeocaZzOjCTfMs.noETkuHbzzGgCbhhbhTnEJdNuMyO)
		{
			WPZBiauAaVNLgksPIuxdebBJmFnC();
		}
		if (BtOMtPqkDCCvgvMeocaZzOjCTfMs != null)
		{
			BtOMtPqkDCCvgvMeocaZzOjCTfMs.Update();
		}
		vSDZVKsLSmGmxJrdjnVAjHTvfyUIA();
		if (CadRokSzrlIenXlnHUrnvXhycGll)
		{
			if (BtOMtPqkDCCvgvMeocaZzOjCTfMs != null)
			{
				BtOMtPqkDCCvgvMeocaZzOjCTfMs.UpdateDevices(updateLoop);
			}
			NuNjRFDwgVJEpQiPAJiUFuNOWSDfA();
			if (BtOMtPqkDCCvgvMeocaZzOjCTfMs != null)
			{
				BtOMtPqkDCCvgvMeocaZzOjCTfMs.UpdateFinished();
			}
		}
		if (bWsPlRzQqfGXmUJJbVmRbobSgoKA)
		{
			UghMgcgDqwomYTdneZKuMybzfOym.biEhSJFaMvujHmTYEFoLsRjmXQFE(updateLoop);
		}
		if (sivZnZogffoKcXPFGsRlopzdcIdk)
		{
			UNARODWidReetDkFswVTghpaLzgJA.FiGoaASIaWRCNZZpNFpfHRIhAXdx(updateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (bdfbpjAzfBhJAklWiuMFWIlQYjNMA != null)
		{
			bdfbpjAzfBhJAklWiuMFWIlQYjNMA.INBczqSosoXHntgpZStpJliJdQBM();
		}
		if (fGlYkDFEUwDZusMaaTWfBQqjOJnh != null)
		{
			fGlYkDFEUwDZusMaaTWfBQqjOJnh.INBczqSosoXHntgpZStpJliJdQBM();
		}
		if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw != null)
		{
			int count = JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Count;
			for (int i = 0; i < count; i++)
			{
				if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i] != null)
				{
					JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i].bQMBphCDEewlbJBCUlFNUcBdnyKSA();
				}
			}
		}
		if (UNARODWidReetDkFswVTghpaLzgJA != null)
		{
			UNARODWidReetDkFswVTghpaLzgJA.Dispose();
		}
		if (UghMgcgDqwomYTdneZKuMybzfOym != null)
		{
			UghMgcgDqwomYTdneZKuMybzfOym.Dispose();
		}
		if (BtOMtPqkDCCvgvMeocaZzOjCTfMs != null)
		{
			BtOMtPqkDCCvgvMeocaZzOjCTfMs.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return JfHEBKXJaOctduZuSEMZbWlnSfdk;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!CadRokSzrlIenXlnHUrnvXhycGll)
		{
			return;
		}
		for (int i = 0; i < cAOZAWuhfcKoKpVqfROXXpOjLrAF; i++)
		{
			if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		BtOMtPqkDCCvgvMeocaZzOjCTfMs.SystemDeviceConnected();
		ENyxHKrYmthebTKVpcfFAXLegDhx = true;
		if (CadRokSzrlIenXlnHUrnvXhycGll || BtOMtPqkDCCvgvMeocaZzOjCTfMs.noETkuHbzzGgCbhhbhTnEJdNuMyO)
		{
			vJqeVmNcDrAnCiDurwkMttQZTwfJA.Start();
		}
		if (sivZnZogffoKcXPFGsRlopzdcIdk)
		{
			UNARODWidReetDkFswVTghpaLzgJA.ugOdhIQrMajicQdNVXSzKDHRrbZf(true);
		}
		if (bWsPlRzQqfGXmUJJbVmRbobSgoKA)
		{
			UghMgcgDqwomYTdneZKuMybzfOym.nsfoMBOPpBZpWgbEqHOIvOEoryni(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		BtOMtPqkDCCvgvMeocaZzOjCTfMs.SystemDeviceDisconnected();
		ENyxHKrYmthebTKVpcfFAXLegDhx = true;
		if (CadRokSzrlIenXlnHUrnvXhycGll || BtOMtPqkDCCvgvMeocaZzOjCTfMs.noETkuHbzzGgCbhhbhTnEJdNuMyO)
		{
			vJqeVmNcDrAnCiDurwkMttQZTwfJA.Start();
		}
		if (sivZnZogffoKcXPFGsRlopzdcIdk)
		{
			UNARODWidReetDkFswVTghpaLzgJA.ugOdhIQrMajicQdNVXSzKDHRrbZf(false);
		}
		if (bWsPlRzQqfGXmUJJbVmRbobSgoKA)
		{
			UghMgcgDqwomYTdneZKuMybzfOym.nsfoMBOPpBZpWgbEqHOIvOEoryni(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = CadRokSzrlIenXlnHUrnvXhycGll;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return UghMgcgDqwomYTdneZKuMybzfOym;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return UNARODWidReetDkFswVTghpaLzgJA;
	}

	public void TKWxnaPYHCvJVorguRyireYDBvdL(LzzDrSGBjXWyBBXOFCXFTEexBDId P_0, hiUiesdLsyDsupsnncGPkmAIzTXrA P_1)
	{
	}

	private void WPZBiauAaVNLgksPIuxdebBJmFnC()
	{
		if (fGlYkDFEUwDZusMaaTWfBQqjOJnh.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
		{
			if (fGlYkDFEUwDZusMaaTWfBQqjOJnh.VWKJlWBJsiHHmQEXkCqAcjYYeDisA() && !vJqeVmNcDrAnCiDurwkMttQZTwfJA.running && !bdfbpjAzfBhJAklWiuMFWIlQYjNMA.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
			{
				if (fGlYkDFEUwDZusMaaTWfBQqjOJnh.FFWjswuhFTDsWeZHbKPsbmwJBlek)
				{
					ENyxHKrYmthebTKVpcfFAXLegDhx = true;
				}
				vJqeVmNcDrAnCiDurwkMttQZTwfJA.Start();
			}
		}
		else if (!vJqeVmNcDrAnCiDurwkMttQZTwfJA.running)
		{
			vJqeVmNcDrAnCiDurwkMttQZTwfJA.Start();
		}
		else if (vJqeVmNcDrAnCiDurwkMttQZTwfJA.Update())
		{
			fGlYkDFEUwDZusMaaTWfBQqjOJnh.tGmkFOBGLIStwNoiokXgtfxSMCi();
		}
	}

	private void jnVMbrqFeyBBcgNnPkQnlDWohDGjb()
	{
		vmJbdiBPOleDniuRRioQnOrbEukZA(GvNVBQcCpFfGAmCIEEviWZnAFuFe());
	}

	private void vmJbdiBPOleDniuRRioQnOrbEukZA(IList<VANUTLsVUcepnrrsTIUZlnrrdggd> P_0)
	{
		int num = 0;
		List<wKijuDZUjWtKaiUIyrWxEquIfJhV> jeKpbnNIYDRrLTBPfHBNXZwJbNFw = JeKpbnNIYDRrLTBPfHBNXZwJbNFw;
		int num2 = cAOZAWuhfcKoKpVqfROXXpOjLrAF;
		JeKpbnNIYDRrLTBPfHBNXZwJbNFw = new List<wKijuDZUjWtKaiUIyrWxEquIfJhV>();
		dbsImjuXbwrrKooxCoOyBjqruRDW = 0;
		List<wKijuDZUjWtKaiUIyrWxEquIfJhV> list = new List<wKijuDZUjWtKaiUIyrWxEquIfJhV>();
		new List<wKijuDZUjWtKaiUIyrWxEquIfJhV>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num3] != null && !jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num3].HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				list.Add(jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num3]);
				jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num3].bQMBphCDEewlbJBCUlFNUcBdnyKSA();
				jeKpbnNIYDRrLTBPfHBNXZwJbNFw.RemoveAt(num3);
			}
		}
		num2 = jeKpbnNIYDRrLTBPfHBNXZwJbNFw?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			WFSWoKUpcXKmwQwgjrbAPJlaxrhS wFSWoKUpcXKmwQwgjrbAPJlaxrhS = new WFSWoKUpcXKmwQwgjrbAPJlaxrhS();
			wFSWoKUpcXKmwQwgjrbAPJlaxrhS.VjeTqUVOslfcJHPyePqBWstzbfToA = this;
			if (P_0[i] == null)
			{
				continue;
			}
			VANUTLsVUcepnrrsTIUZlnrrdggd vANUTLsVUcepnrrsTIUZlnrrdggd = P_0[i];
			if (vANUTLsVUcepnrrsTIUZlnrrdggd != null && vANUTLsVUcepnrrsTIUZlnrrdggd.DIgMquQcUiJUCmpcvVcSJQDlfzZM)
			{
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP = new wKijuDZUjWtKaiUIyrWxEquIfJhV(vANUTLsVUcepnrrsTIUZlnrrdggd, vANUTLsVUcepnrrsTIUZlnrrdggd.vjwGglosJzWDxTNkOWbLuahYiiijA, FNQHdiZjSrRJdvgaXInzMRUrDQBS);
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.wxhLRjNDTGYVtZkVgDrQiYOkEcnJ = vANUTLsVUcepnrrsTIUZlnrrdggd.cJZeqceByQzQXVQhxbGYpsxUkUdnA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.NsiDbJoWyAcgeceQYAoxZmGVFdgm = vANUTLsVUcepnrrsTIUZlnrrdggd.MJCEwRBVuVKSGDFqTrsuJVtjFKBab;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.ruESEabnqsbiTACtjPdsWQAqsjlu = vANUTLsVUcepnrrsTIUZlnrrdggd.MJCEwRBVuVKSGDFqTrsuJVtjFKBab;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.OqERMJbGQjEkJJiwnMORQXBRHhPZ = vANUTLsVUcepnrrsTIUZlnrrdggd.ivpdrYRhLgwLyrtsRFoaeEevvzRJ;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.GrJfzOrvuHhGgCtFBcbhfvmJQFcv = vANUTLsVUcepnrrsTIUZlnrrdggd.QhSgzIhvKfsJeIaXJhbIxtnlJSzmA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.LkmdjTIYRyLBShskJJpQWrEWOasr = vANUTLsVUcepnrrsTIUZlnrrdggd.UIDBCQFGvhtUWvgAxequFCQKjHjA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.sMLBMVkMEbpMKqMnhrczsQpjqIXR = vANUTLsVUcepnrrsTIUZlnrrdggd.CjUdVHgAsXQymctxyxnBvFytYGTCA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.cRCNYQpURpVKkXTblOvrAbAmAICo = vANUTLsVUcepnrrsTIUZlnrrdggd.pRsRmQMbpTFETkGFBFDUnwCubcGDA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.ZOONGaPymhzMOaorijtjglEXgRoC = vANUTLsVUcepnrrsTIUZlnrrdggd.FVhFeZFkcSgtaZJQFwZiHyBPSKzJA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.PhOkofzuDhnDAkSGmmhbRPmJJYUj = vANUTLsVUcepnrrsTIUZlnrrdggd.jOAqLcdfStbmayoeZfLkKOCzAdWgb;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.TqYGoZGZYnMivightGoDHyCoJxBiA = false;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.ZphgXxCiKtRftwiGkbSugrfBQkzLA = vANUTLsVUcepnrrsTIUZlnrrdggd.CDIlMCeJNcMdbbkgVhwkeOlHCOww;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.GDuFeGudgiHPWIiryvawxsJiHsUY = vANUTLsVUcepnrrsTIUZlnrrdggd.VQoWzcAGPoQlIieOrWohGPvFaMtI;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.ojBmqFfjnKyjtBmDOBTQRCQIfDtcA = vANUTLsVUcepnrrsTIUZlnrrdggd.kFMJlmVYZFLDGUSadzkcEJcyxaud;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.UKCelkbZFoFoGikdSqwYhVxapXLm = vANUTLsVUcepnrrsTIUZlnrrdggd.JuPDFTZzLfsYQfdedMjOOaQbCxaeA;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.VDGHzfijStPLeadAlNCPSOHlWtIgA += OOiRvpFQlVcNEtOGUyKvFxXHiWac;
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.WZqDpNtFRDPjHksizBKkShgrHkRJA += wFSWoKUpcXKmwQwgjrbAPJlaxrhS.iTUzHzPMdVcPUtmpvDHfhaDZNKbB;
				vANUTLsVUcepnrrsTIUZlnrrdggd.smaQhtTrUqNmDWDQEApJkjZTEhYx();
				wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.rqPCaKBRAiDRwCciKATFhWzOLocpc();
				JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Add(wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP);
				num++;
				if (wFSWoKUpcXKmwQwgjrbAPJlaxrhS.LpHWBoIYKAnWLIHpbxvNoybzhbaP.ZphgXxCiKtRftwiGkbSugrfBQkzLA)
				{
					dbsImjuXbwrrKooxCoOyBjqruRDW++;
				}
			}
		}
		cAOZAWuhfcKoKpVqfROXXpOjLrAF = num;
		LTeofzNxBcrZTBCrSbWizaSjNjgF(num2, num, jeKpbnNIYDRrLTBPfHBNXZwJbNFw, JeKpbnNIYDRrLTBPfHBNXZwJbNFw);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(JeKpbnNIYDRrLTBPfHBNXZwJbNFw[j]));
			}
		}
		list.ForEach(delegate(wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2)
		{
			jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(wKijuDZUjWtKaiUIyrWxEquIfJhV2, false, false);
		});
		QWxcETSQyUbigcDhGRMuxEtubbiDA(jeKpbnNIYDRrLTBPfHBNXZwJbNFw, JeKpbnNIYDRrLTBPfHBNXZwJbNFw, false);
		QWxcETSQyUbigcDhGRMuxEtubbiDA(JeKpbnNIYDRrLTBPfHBNXZwJbNFw, jeKpbnNIYDRrLTBPfHBNXZwJbNFw, true);
		for (int num4 = 0; num4 < num2; num4++)
		{
			if (jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num4] != null)
			{
				jeKpbnNIYDRrLTBPfHBNXZwJbNFw[num4].bQMBphCDEewlbJBCUlFNUcBdnyKSA();
			}
		}
	}

	private void NuNjRFDwgVJEpQiPAJiUFuNOWSDfA()
	{
		for (int i = 0; i < cAOZAWuhfcKoKpVqfROXXpOjLrAF; i++)
		{
			wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2 = JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i];
			if (wKijuDZUjWtKaiUIyrWxEquIfJhV2 != null && (mbUMJINoNraMTHqPYVzUldXymsuyA == null || !wKijuDZUjWtKaiUIyrWxEquIfJhV2.TqYGoZGZYnMivightGoDHyCoJxBiA))
			{
				wKijuDZUjWtKaiUIyrWxEquIfJhV2.Update();
			}
		}
	}

	private bool PTXcfPxxTtFWuDDmICXdxNQLnZlsA(mXdHbbQHqxXpwypNyIwQkcCWvUzu P_0)
	{
		try
		{
			return P_0.HTNLLvwTYbnxasfGiABGnBTUQTtl();
		}
		catch
		{
			return false;
		}
	}

	private IList<VANUTLsVUcepnrrsTIUZlnrrdggd> GvNVBQcCpFfGAmCIEEviWZnAFuFe()
	{
		return BtOMtPqkDCCvgvMeocaZzOjCTfMs.GetJoysticks<VANUTLsVUcepnrrsTIUZlnrrdggd>();
	}

	private void LTeofzNxBcrZTBCrSbWizaSjNjgF(int P_0, int P_1, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_2, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(wKijuDZUjWtKaiUIyrWxEquIfJhV.DlkxJecWfrPcHqCgNdATnVsQmxaK);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			HoQEMdKSbOzvSZjdfAcPXJtVQJqc(P_1, P_3, P_0, P_2, QnwKdPAYpBBAtCNXJTAQEFBPArTHA.khlunZmoRYiFPOfIFanMRMAJjeuT.Exact);
		}
		LsofZkDVhUqBQpanCDWrEXodHadjB(P_1, P_3, QnwKdPAYpBBAtCNXJTAQEFBPArTHA.khlunZmoRYiFPOfIFanMRMAJjeuT.Exact);
		for (int i = 0; i < P_1; i++)
		{
			wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2 = P_3[i];
			if (wKijuDZUjWtKaiUIyrWxEquIfJhV2 != null && wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = BmUqlSXRxZaQVbznpjYypvmUaptS(P_3);
				wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = pJrIWhBhlsIfDVeocfMkReBHxBSq();
				vZNqgzyLqtucYyRqaitOsUfnaOuS.cTtNVpOcRgNJkUwwLtrLWzWGkmFF(wKijuDZUjWtKaiUIyrWxEquIfJhV2);
			}
		}
		P_3.Sort(wKijuDZUjWtKaiUIyrWxEquIfJhV.QBbJtnMTLsrQfrCxhEkghRILuSKiA);
	}

	private void TVRczYvkCvWeAqdNnZOlZRqVTQIo(List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
			{
				P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
			}
		}
	}

	private bool GMvSXHwHBptqcIcemyVEPYusCFbH(List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int BmUqlSXRxZaQVbznpjYypvmUaptS(List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool bpQcHdfUbCOxkpbzWnLArlumFvyPA(List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void HoQEMdKSbOzvSZjdfAcPXJtVQJqc(int P_0, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_1, int P_2, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_3, QnwKdPAYpBBAtCNXJTAQEFBPArTHA.khlunZmoRYiFPOfIFanMRMAJjeuT P_4)
	{
		int num = ((P_4 != QnwKdPAYpBBAtCNXJTAQEFBPArTHA.khlunZmoRYiFPOfIFanMRMAJjeuT.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2 = P_1[i];
			if (wKijuDZUjWtKaiUIyrWxEquIfJhV2 == null || wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV3 = P_3[j];
				if (wKijuDZUjWtKaiUIyrWxEquIfJhV3 != null && !bpQcHdfUbCOxkpbzWnLArlumFvyPA(P_1, wKijuDZUjWtKaiUIyrWxEquIfJhV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && wKijuDZUjWtKaiUIyrWxEquIfJhV2.tZmtrMjkavzAQJmPEHMTVDZWFhym(wKijuDZUjWtKaiUIyrWxEquIfJhV3) >= num)
				{
					wKijuDZUjWtKaiUIyrWxEquIfJhV2.gczfSqfScKvLjnlEDCEuIkXSSKKBb(wKijuDZUjWtKaiUIyrWxEquIfJhV3);
					vZNqgzyLqtucYyRqaitOsUfnaOuS.cTtNVpOcRgNJkUwwLtrLWzWGkmFF(wKijuDZUjWtKaiUIyrWxEquIfJhV2);
				}
			}
		}
	}

	private void LsofZkDVhUqBQpanCDWrEXodHadjB(int P_0, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_1, QnwKdPAYpBBAtCNXJTAQEFBPArTHA.khlunZmoRYiFPOfIFanMRMAJjeuT P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2 = P_1[i];
			if (wKijuDZUjWtKaiUIyrWxEquIfJhV2 == null || wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			QnwKdPAYpBBAtCNXJTAQEFBPArTHA.aIggFUjIZtxuQhqUKAwmsQIUoUxA aIggFUjIZtxuQhqUKAwmsQIUoUxA = null;
			foreach (QnwKdPAYpBBAtCNXJTAQEFBPArTHA.aIggFUjIZtxuQhqUKAwmsQIUoUxA item in vZNqgzyLqtucYyRqaitOsUfnaOuS.lMIWZWxJuseLLioOCihPWOLEfEQT(wKijuDZUjWtKaiUIyrWxEquIfJhV2, P_2))
			{
				if (!bpQcHdfUbCOxkpbzWnLArlumFvyPA(P_1, item.LFqZJGUspPRfdLLAoGNBmdvVqhPy) && item.xEPIPwimHEwlRZslYQSSJpaECjou >= 0)
				{
					aIggFUjIZtxuQhqUKAwmsQIUoUxA = item;
					break;
				}
			}
			if (aIggFUjIZtxuQhqUKAwmsQIUoUxA != null)
			{
				int num = aIggFUjIZtxuQhqUKAwmsQIUoUxA.xEPIPwimHEwlRZslYQSSJpaECjou;
				if (!GMvSXHwHBptqcIcemyVEPYusCFbH(P_1, num))
				{
					num = (aIggFUjIZtxuQhqUKAwmsQIUoUxA.xEPIPwimHEwlRZslYQSSJpaECjou = BmUqlSXRxZaQVbznpjYypvmUaptS(P_1));
				}
				wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = aIggFUjIZtxuQhqUKAwmsQIUoUxA.LFqZJGUspPRfdLLAoGNBmdvVqhPy;
				vZNqgzyLqtucYyRqaitOsUfnaOuS.cTtNVpOcRgNJkUwwLtrLWzWGkmFF(wKijuDZUjWtKaiUIyrWxEquIfJhV2);
			}
		}
	}

	private void vSDZVKsLSmGmxJrdjnVAjHTvfyUIA()
	{
		while (qZTSogjtBhtCIEbanxHULIdKjiVw.Count > 0)
		{
			zZsZiQwEvhliIWgFOZKLLDCPrLYS zZsZiQwEvhliIWgFOZKLLDCPrLYS2 = qZTSogjtBhtCIEbanxHULIdKjiVw.Dequeue();
			if (zZsZiQwEvhliIWgFOZKLLDCPrLYS2.wDwHjqNaRiwqSAtGuhyGvMjOxPpl)
			{
				if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Contains(zZsZiQwEvhliIWgFOZKLLDCPrLYS2.WnRDgxksKgWDjkLYyGgRoohUPaPqA))
				{
					jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(zZsZiQwEvhliIWgFOZKLLDCPrLYS2.WnRDgxksKgWDjkLYyGgRoohUPaPqA, true, false);
				}
			}
			else
			{
				jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(zZsZiQwEvhliIWgFOZKLLDCPrLYS2.WnRDgxksKgWDjkLYyGgRoohUPaPqA, false, true);
			}
		}
		if (BtOMtPqkDCCvgvMeocaZzOjCTfMs.CFcqVvoJyXcbIhKgWUhODcoRGZAB(true))
		{
			ENyxHKrYmthebTKVpcfFAXLegDhx = true;
		}
		if (ENyxHKrYmthebTKVpcfFAXLegDhx)
		{
			GMPnyJBlYSnyAAEPkWVJGZuzLIpy();
		}
		if ((CadRokSzrlIenXlnHUrnvXhycGll || BtOMtPqkDCCvgvMeocaZzOjCTfMs.noETkuHbzzGgCbhhbhTnEJdNuMyO) && bdfbpjAzfBhJAklWiuMFWIlQYjNMA.TPoeWwEYcJhWohaeHjOgcVjxblcSA && bdfbpjAzfBhJAklWiuMFWIlQYjNMA.VWKJlWBJsiHHmQEXkCqAcjYYeDisA())
		{
			ngDSCYtOghhOBgmKuZHdVGWbWxbbA();
		}
	}

	private void GMPnyJBlYSnyAAEPkWVJGZuzLIpy()
	{
		ENyxHKrYmthebTKVpcfFAXLegDhx = false;
		if (!bdfbpjAzfBhJAklWiuMFWIlQYjNMA.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
		{
			BtOMtPqkDCCvgvMeocaZzOjCTfMs.YNyeiSbFRWSFiWVYCPUeRRFjRDpxA();
			bdfbpjAzfBhJAklWiuMFWIlQYjNMA.tGmkFOBGLIStwNoiokXgtfxSMCi();
		}
	}

	private void ngDSCYtOghhOBgmKuZHdVGWbWxbbA()
	{
		BtOMtPqkDCCvgvMeocaZzOjCTfMs.lwlGhJBBYVoIisnMZHEbeaiDCXtB();
		if (CadRokSzrlIenXlnHUrnvXhycGll)
		{
			IList<VANUTLsVUcepnrrsTIUZlnrrdggd> list = GvNVBQcCpFfGAmCIEEviWZnAFuFe();
			if (XkdRXXOaZGQuEETKtfTyVyDIUuzh(list))
			{
				vmJbdiBPOleDniuRRioQnOrbEukZA(list);
			}
		}
	}

	private bool XkdRXXOaZGQuEETKtfTyVyDIUuzh(IList<VANUTLsVUcepnrrsTIUZlnrrdggd> P_0)
	{
		for (int i = 0; i < JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Count; i++)
		{
			if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i] != null && !JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i].HokkQwRVnPGCfSUNpwAPcxGHsvNx)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !ZCmCRkWMGGJIdJkIGmCYCJSXYtmO(P_0[j].cJZeqceByQzQXVQhxbGYpsxUkUdnA) && P_0[j].DIgMquQcUiJUCmpcvVcSJQDlfzZM)
			{
				return true;
			}
		}
		int count2 = JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Count;
		for (int k = 0; k < count2; k++)
		{
			if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw[k] != null && (!DMBQdrHWOjnSOysXQhwyhySxtFf(P_0, JeKpbnNIYDRrLTBPfHBNXZwJbNFw[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid) || !JeKpbnNIYDRrLTBPfHBNXZwJbNFw[k].HokkQwRVnPGCfSUNpwAPcxGHsvNx))
			{
				return true;
			}
		}
		return false;
	}

	private bool ZCmCRkWMGGJIdJkIGmCYCJSXYtmO(Guid P_0)
	{
		int count = JeKpbnNIYDRrLTBPfHBNXZwJbNFw.Count;
		for (int i = 0; i < count; i++)
		{
			if (JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i] != null && JeKpbnNIYDRrLTBPfHBNXZwJbNFw[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool DMBQdrHWOjnSOysXQhwyhySxtFf(IList<VANUTLsVUcepnrrsTIUZlnrrdggd> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].cJZeqceByQzQXVQhxbGYpsxUkUdnA == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void QWxcETSQyUbigcDhGRMuxEtubbiDA(List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_0, List<wKijuDZUjWtKaiUIyrWxEquIfJhV> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV2 = P_0[i];
			if (wKijuDZUjWtKaiUIyrWxEquIfJhV2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					wKijuDZUjWtKaiUIyrWxEquIfJhV wKijuDZUjWtKaiUIyrWxEquIfJhV3 = P_1[j];
					if (wKijuDZUjWtKaiUIyrWxEquIfJhV3 != null && wKijuDZUjWtKaiUIyrWxEquIfJhV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == wKijuDZUjWtKaiUIyrWxEquIfJhV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(P_0[i], P_2, false);
			}
		}
	}

	private void jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, bool P_1, bool P_2)
	{
		if (!P_2 && P_0.MWvChOjCnXETODivhYlcnwYEtZAjB)
		{
			return;
		}
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}

	private bool zpvGpioElhPaOeAhJRZaWNkwCuSV()
	{
		try
		{
			int num = 0;
			FwSmjzeEGJTlvIrgEhrMknbMtsVE.DyZHeDUdcXEgbEavawdzooRyeAajA(null, ref num, hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.mEwPgRNNMPvZMwAMACZigplGyyfDA<kizRvorWUKVAMIsDgNoQcxCBBUhd>());
			if (jbODfMDXIqKYiQOFXPFJFDBmQSQbb != num)
			{
				jbODfMDXIqKYiQOFXPFJFDBmQSQbb = num;
				return true;
			}
		}
		catch (Exception)
		{
		}
		if (dbsImjuXbwrrKooxCoOyBjqruRDW > 0 && BtOMtPqkDCCvgvMeocaZzOjCTfMs.pxGJjrmYtfETXiXsfbqDTFyMRfkm())
		{
			return true;
		}
		return false;
	}

	private void OOiRvpFQlVcNEtOGUyKvFxXHiWac()
	{
		ENyxHKrYmthebTKVpcfFAXLegDhx = true;
	}

	private void jaAHPmfsaCgvwSVXTClQaEXdiAro(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0, bool P_1)
	{
		qZTSogjtBhtCIEbanxHULIdKjiVw.Enqueue(new zZsZiQwEvhliIWgFOZKLLDCPrLYS(P_0, !P_1));
	}

	[Conditional("DEBUGTHIS")]
	private void iOEDfcgsBJISutrTgPxuaotaUYNtA(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void OxTdLnXlibxCZIDwsgRxhFutuwEMA(wKijuDZUjWtKaiUIyrWxEquIfJhV P_0)
	{
		jXSyNIsrPpMIdsRbRBSiiJjiEAxcb(P_0, false, false);
	}
}
