using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.InputSources.SDL;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.InputSources.SDL2
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SDL2InputSource : SDLInputSource
	{
		private const int mTXSnzRxBAFaXCAQuvBucnqfBrQKA = 32;

		private const float jEffmKcLdlKrvVLIaNpdYZzDyRDl = 1f;

		private auIzLjThapfhEAPwYCbPNbnNEOhCA.hJGZMWbrsMHzeMUEaOXHElkLJrVl tihXVakBOoPEALiOojEnEgprZHMS;

		private readonly TimerAbs UzSAMkgFbiCfStZqqQnFmrYECxsUA;

		private readonly List<int> rQIYGMsOwHGxwPTbzYshhtVKrADS;

		[CompilerGenerated]
		private Action VuVBpBchFFluRgjJJTqqwSLQBSLiA;

		private bool boJAjFfYAsVqZkjDESHbhUOfucENA;

		private static readonly string[] KYSsuHdUEwWiRhqPIhSBMewUFDIh = new string[0];

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = VuVBpBchFFluRgjJJTqqwSLQBSLiA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref VuVBpBchFFluRgjJJTqqwSLQBSLiA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = VuVBpBchFFluRgjJJTqqwSLQBSLiA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref VuVBpBchFFluRgjJJTqqwSLQBSLiA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		event Action SDLInputSource.DeviceChangedEvent
		{
			add
			{
				_DeviceChangedEvent += value;
			}
			remove
			{
				_DeviceChangedEvent -= value;
			}
		}

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
			: base(P_0, P_1, P_2, P_3, P_4)
		{
			UzSAMkgFbiCfStZqqQnFmrYECxsUA = new TimerAbs(1.0);
			rQIYGMsOwHGxwPTbzYshhtVKrADS = new List<int>();
			PostConstructor();
		}

		protected override bool InitializeSDL()
		{
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				if (auIzLjThapfhEAPwYCbPNbnNEOhCA.BqxudvqwtDLdTOMgpqvDpluIoLuj((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected override void DeinitializeSDL()
		{
			auIzLjThapfhEAPwYCbPNbnNEOhCA.SsqdhcYuwHIMCLRAmFiVLzKrHVeb();
		}

		protected override int GetEventBufferSize()
		{
			return 56;
		}

		protected override int GetSDLJoystickCount()
		{
			if (!base.initialized)
			{
				return 0;
			}
			return Math.Min(auIzLjThapfhEAPwYCbPNbnNEOhCA.kILhpfyyRDgTJsfihgpzTNUdrtBx(), 32);
		}

		protected override int GetGamepadCount()
		{
			if (!base.initialized)
			{
				return 0;
			}
			int sDLJoystickCount = GetSDLJoystickCount();
			int num = 0;
			for (int i = 0; i < sDLJoystickCount; i++)
			{
				if (!auIzLjThapfhEAPwYCbPNbnNEOhCA.PGSVpUXAOSpQsipxAeiHaDYKBLGfA(i))
				{
					num++;
				}
			}
			return num;
		}

		protected override void PollForJoystickChanges(bool force)
		{
			if ((!handleJoysticks && !handleGamepads) || (!force && !UzSAMkgFbiCfStZqqQnFmrYECxsUA.Update()))
			{
				return;
			}
			rQIYGMsOwHGxwPTbzYshhtVKrADS.Clear();
			int sDLJoystickCount = GetSDLJoystickCount();
			for (int i = 0; i < sDLJoystickCount; i++)
			{
				rQIYGMsOwHGxwPTbzYshhtVKrADS.Add(auIzLjThapfhEAPwYCbPNbnNEOhCA.TMPtlUZiCORPMTxMdNCGhlKfjUjH(i));
			}
			bool flag = false;
			for (int num = base.joysticks.Count - 1; num >= 0; num--)
			{
				int num2 = base.joysticks[num].LLLVSyGEDzGKHJoApyvkQjXBgayhA;
				if (!rQIYGMsOwHGxwPTbzYshhtVKrADS.Contains(num2))
				{
					PZNBVvfTvnLXNyBLYuKNgPXcHlZr(num2);
					flag = true;
				}
			}
			for (int j = 0; j < sDLJoystickCount; j++)
			{
				int instanceId = rQIYGMsOwHGxwPTbzYshhtVKrADS[j];
				if (IndexOfJoystickWithInstanceId(instanceId) < 0)
				{
					cVsdxGADcKzbmgtnMngefQxxPQbUA(j);
					flag = true;
				}
			}
			UzSAMkgFbiCfStZqqQnFmrYECxsUA.Start();
			if (flag && VuVBpBchFFluRgjJJTqqwSLQBSLiA != null)
			{
				VuVBpBchFFluRgjJJTqqwSLQBSLiA();
			}
		}

		protected override void CloseJoysticks()
		{
			if (handleJoysticks || handleJoysticks)
			{
				for (int i = 0; i < base.joysticks.Count; i++)
				{
					YUhbQhiLFKRAUFwRWqBNoTItxqmB yUhbQhiLFKRAUFwRWqBNoTItxqmB = base.joysticks[i];
					yUhbQhiLFKRAUFwRWqBNoTItxqmB.fAHcymjXpGWrrPnAFpKcaDcXehCdA();
					yUhbQhiLFKRAUFwRWqBNoTItxqmB.Dispose();
				}
				base.joysticks.Clear();
			}
		}

		protected override void ProcessEvents()
		{
			NativeBuffer nativeBuffer = base.eventBuffer;
			while (auIzLjThapfhEAPwYCbPNbnNEOhCA.uqjzlPitgJPziEIVwZWNlSjrSDXd(nativeBuffer) != 0)
			{
				tihXVakBOoPEALiOojEnEgprZHMS.ApNKpbZSkOHmuMcAYSkKirVJExUo(nativeBuffer);
				auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb kUadhbVcTqqYgADdMZjLXknmZMiC = tihXVakBOoPEALiOojEnEgprZHMS.kUadhbVcTqqYgADdMZjLXknmZMiC;
				double realTime = ReInput.realTime;
				switch (kUadhbVcTqqYgADdMZjLXknmZMiC)
				{
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERAXISMOTION:
					mRukQvGTrhzmxwEmpbVcMFxfzLdr(ref tihXVakBOoPEALiOojEnEgprZHMS.hiRyoxgTBBbsqzolJBuHTPcsXmzi, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERBUTTONDOWN:
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERBUTTONUP:
					ZQnZiTFGEzdQjNRddjbJaEoVdkEM(ref tihXVakBOoPEALiOojEnEgprZHMS.opZyVpBPrwPNVfHTLntFcEUqcJXZ, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERDEVICEREMAPPED:
					xnuaQOHazqUSfmuzigwFluIUxXyF(ref tihXVakBOoPEALiOojEnEgprZHMS.rSIEzaWigZJijybWHOwfujwKBOiK);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYAXISMOTION:
					lAQtDzmeirCJCdwSOKtRfQPwtblg(ref tihXVakBOoPEALiOojEnEgprZHMS.zKZMLHWlZiINnAdMDEIZIAzOrXQD, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYBUTTONDOWN:
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYBUTTONUP:
					BCaFQSUdKMoXVxmiqwAPqoEBDwAO(ref tihXVakBOoPEALiOojEnEgprZHMS.aOzbJGVQrcDqsyvdcrLwwdfVEDRIA, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYHATMOTION:
					fgPExWEKMxdyfdzROqLfnDaVEXVn(ref tihXVakBOoPEALiOojEnEgprZHMS.hHsafQExHvPJYQDdVSGUURhrxOzk, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYBALLMOTION:
					pStCbqHSRntPOHthpzVVLTZhqSGnA(ref tihXVakBOoPEALiOojEnEgprZHMS.ReIbssnPlwQpCgjSxLwhykTMvrLk, realTime);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYDEVICEADDED:
					fsrSPdNoLKfCBSgleeYARCcCkBDn(ref tihXVakBOoPEALiOojEnEgprZHMS.ZTXLTsnBdpATfgYjKVxOqYbOgLby);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_JOYDEVICEREMOVED:
					YKuBlpOaVwSbKkOwsftoTEqnuOfS(ref tihXVakBOoPEALiOojEnEgprZHMS.ZTXLTsnBdpATfgYjKVxOqYbOgLby);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERDEVICEADDED:
					XNrAsITtoNdTPuVdzcFASNJlgTxdA(ref tihXVakBOoPEALiOojEnEgprZHMS.rSIEzaWigZJijybWHOwfujwKBOiK);
					break;
				case auIzLjThapfhEAPwYCbPNbnNEOhCA.sANnGZTBRWwntchCiItibIYRCkHcb.SDL_CONTROLLERDEVICEREMOVED:
					axfrwFpkrCICmcBGWSYvSHeasYzH(ref tihXVakBOoPEALiOojEnEgprZHMS.rSIEzaWigZJijybWHOwfujwKBOiK);
					break;
				}
			}
		}

		protected override void LoadGamepadMappings()
		{
			string[] array = cHpFLKXAGAZEQJBGKrdYpjstbYJaA.kyfucaKZkiMsxGLGdfDMcKlXwVKsA();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && array[i].IndexOf(',') >= 32 && !(auIzLjThapfhEAPwYCbPNbnNEOhCA.oFBJsfpSWpLZRtzCfcUREiADwKth(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					auIzLjThapfhEAPwYCbPNbnNEOhCA.XUgxuNJHUXHoHjLgQzNZUZfeLhsn(array[i]);
				}
			}
		}

		protected override bool IsAllowed(qsgekoIkSLKHNvSvhDyqzbhlTpKd device)
		{
			for (int i = 0; i < KYSsuHdUEwWiRhqPIhSBMewUFDIh.Length; i++)
			{
				if (string.Equals(device.daoSvnTfYTUAaCJXGklyVPSSbAmL, KYSsuHdUEwWiRhqPIhSBMewUFDIh[i], StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			return true;
		}

		private VmAHFiBjLbqxTYETGuFGHvkfzWgE qfmimeWQrvZULzityBhAIcxoVQqGA(int P_0)
		{
			bool flag = handleGamepads && auIzLjThapfhEAPwYCbPNbnNEOhCA.PGSVpUXAOSpQsipxAeiHaDYKBLGfA(P_0);
			IntPtr intPtr = ((!flag) ? auIzLjThapfhEAPwYCbPNbnNEOhCA.mRxIijsttrucirsjIVKenZCXUvDF(P_0) : auIzLjThapfhEAPwYCbPNbnNEOhCA.BoFGBEzWpeprOFSfRjgmADzWyIrL(P_0));
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			if (flag)
			{
				zDbEpgAbmSQSqdROmaGAcBeJJIpLA zDbEpgAbmSQSqdROmaGAcBeJJIpLA2 = new zDbEpgAbmSQSqdROmaGAcBeJJIpLA(intPtr);
				ibfdNJCqoNhVOkGrOkOzUQpgutqhA ibfdNJCqoNhVOkGrOkOzUQpgutqhA2;
				if (zDbEpgAbmSQSqdROmaGAcBeJJIpLA2 == null || (ibfdNJCqoNhVOkGrOkOzUQpgutqhA2 = bIIjwxjwXFNPcGGEBxheautIuGaH(P_0, zDbEpgAbmSQSqdROmaGAcBeJJIpLA2)) == null)
				{
					auIzLjThapfhEAPwYCbPNbnNEOhCA.NLaCsZzOWgnAEyAkybDhkTTlOChZ(intPtr);
					return null;
				}
				ibfdNJCqoNhVOkGrOkOzUQpgutqhA2.sfoYVJcrXkevgsOSdTNFBJgwhbPR = auIzLjThapfhEAPwYCbPNbnNEOhCA.DoNPTwVUNjbSgeOiItyeOAHofdGp(zDbEpgAbmSQSqdROmaGAcBeJJIpLA2);
				return new pfGVNMnIUEHGTwiTnVNavVXbGNKo(zDbEpgAbmSQSqdROmaGAcBeJJIpLA2, ibfdNJCqoNhVOkGrOkOzUQpgutqhA2);
			}
			XpNKCOqUzDasRgxXUoUMgbzXvBfj xpNKCOqUzDasRgxXUoUMgbzXvBfj = new XpNKCOqUzDasRgxXUoUMgbzXvBfj(intPtr);
			ibfdNJCqoNhVOkGrOkOzUQpgutqhA ibfdNJCqoNhVOkGrOkOzUQpgutqhA3;
			if (xpNKCOqUzDasRgxXUoUMgbzXvBfj == null || (ibfdNJCqoNhVOkGrOkOzUQpgutqhA3 = RUXmCiwHHenWkHxaBDsClcWPigTA(P_0, xpNKCOqUzDasRgxXUoUMgbzXvBfj)) == null)
			{
				auIzLjThapfhEAPwYCbPNbnNEOhCA.FJtBuOgZTNAOoSbDcXUpnYSLdyXv(intPtr);
				return null;
			}
			return new VmAHFiBjLbqxTYETGuFGHvkfzWgE(xpNKCOqUzDasRgxXUoUMgbzXvBfj, ibfdNJCqoNhVOkGrOkOzUQpgutqhA3);
		}

		private ibfdNJCqoNhVOkGrOkOzUQpgutqhA RUXmCiwHHenWkHxaBDsClcWPigTA(int P_0, XpNKCOqUzDasRgxXUoUMgbzXvBfj P_1)
		{
			if (!base.initialized)
			{
				return null;
			}
			if (P_0 < 0 || P_0 >= 32)
			{
				return null;
			}
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			ibfdNJCqoNhVOkGrOkOzUQpgutqhA obj = new ibfdNJCqoNhVOkGrOkOzUQpgutqhA
			{
				JExAiOxYNtGqtOQIZosFFncDxlet = P_0,
				TDudrxbFvSstbgDXOPSMbfHAwiWi = auIzLjThapfhEAPwYCbPNbnNEOhCA.DwyuqqwCfjYJaVlmBSSzrHTpbmOU(P_1),
				DuFcMoHqcexRAUNbpmCitVQxoaSMA = auIzLjThapfhEAPwYCbPNbnNEOhCA.PGSVpUXAOSpQsipxAeiHaDYKBLGfA(P_0),
				fGIInnkAVaVFJKaBwjSzHBZWEcMg = auIzLjThapfhEAPwYCbPNbnNEOhCA.kCFFyrElCAucTvVeOSMyxSJUkfVG(P_1)
			};
			obj.sfoYVJcrXkevgsOSdTNFBJgwhbPR = obj.fGIInnkAVaVFJKaBwjSzHBZWEcMg;
			obj.AQvCMFJkTvPzrjpOQCEnprMZCYF = auIzLjThapfhEAPwYCbPNbnNEOhCA.bjNKxWuaZWDkGbFEPeHfDLaAlyNsB(P_1);
			obj.VukEvBLvmrBftyCEzFgwLbAAWyJR = auIzLjThapfhEAPwYCbPNbnNEOhCA.RpEdJEiidOprtHhFMpZRqBvZrUMc(P_1);
			obj.RmKSHNAGkceIRsmrGCuDobqChBTCA = auIzLjThapfhEAPwYCbPNbnNEOhCA.plcgAzHkDiPGagtWIJhYQASpmQNqA(P_1);
			obj.FkDELqtzCmYPMVFpwfLQPTmSsXb = auIzLjThapfhEAPwYCbPNbnNEOhCA.zZnEsOtTGsjruIaIjEvUzSUMaLvAA(P_1);
			obj.TKbHDwxJdmGNiCXUCkPdgLYfccNnA = auIzLjThapfhEAPwYCbPNbnNEOhCA.fYkvYBzPWlmofffwZlskNnPhjFjo(P_1);
			obj.pMoufDFFSiuqwYruLxjEMclAscOI = new PidVid(auIzLjThapfhEAPwYCbPNbnNEOhCA.PLmsCgulZITksyCJeISLybYSKaxV(P_1), auIzLjThapfhEAPwYCbPNbnNEOhCA.hTNsmVxiIqpWbgySuBqarTuSKnMn(P_1));
			return obj;
		}

		private ibfdNJCqoNhVOkGrOkOzUQpgutqhA bIIjwxjwXFNPcGGEBxheautIuGaH(int P_0, zDbEpgAbmSQSqdROmaGAcBeJJIpLA P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			XpNKCOqUzDasRgxXUoUMgbzXvBfj xpNKCOqUzDasRgxXUoUMgbzXvBfj = new XpNKCOqUzDasRgxXUoUMgbzXvBfj(auIzLjThapfhEAPwYCbPNbnNEOhCA.xxwgEPsseCwWPIvdQrwXfyDKblpm(P_1));
			if (!xpNKCOqUzDasRgxXUoUMgbzXvBfj.IsValid)
			{
				return null;
			}
			return RUXmCiwHHenWkHxaBDsClcWPigTA(P_0, xpNKCOqUzDasRgxXUoUMgbzXvBfj);
		}

		private bool cVsdxGADcKzbmgtnMngefQxxPQbUA(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			int instanceId = auIzLjThapfhEAPwYCbPNbnNEOhCA.TMPtlUZiCORPMTxMdNCGhlKfjUjH(P_0);
			if (GetJoystickByInstanceId(instanceId) != null)
			{
				return false;
			}
			VmAHFiBjLbqxTYETGuFGHvkfzWgE vmAHFiBjLbqxTYETGuFGHvkfzWgE = qfmimeWQrvZULzityBhAIcxoVQqGA(P_0);
			if (vmAHFiBjLbqxTYETGuFGHvkfzWgE == null)
			{
				return false;
			}
			instanceId = vmAHFiBjLbqxTYETGuFGHvkfzWgE.fwPwpHJZGJwiTqvNdhjNsqLontIc;
			base.joysticks.Add(instanceId, vmAHFiBjLbqxTYETGuFGHvkfzWgE);
			vmAHFiBjLbqxTYETGuFGHvkfzWgE.hHEnyQdaaIvddTeEsIqNULQzGaaV();
			return true;
		}

		private void PZNBVvfTvnLXNyBLYuKNgPXcHlZr(int P_0)
		{
			if (base.joysticks.ContainsKey(P_0))
			{
				base.joysticks.GetValue(P_0).fAHcymjXpGWrrPnAFpKcaDcXehCdA();
				base.joysticks.Remove(P_0);
			}
		}

		private void lAQtDzmeirCJCdwSOKtRfQPwtblg(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.TYElOkKFZMEEyRjdUKsyZCLtQOqT P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent(P_0.eqSCZkPjiGSTUNjvqTIYEIscbqpY, LCUivSLtVZjfWgluNTVEMTZzAtrd.Axis, P_0.nGdoQmbAlqoaVzFHXjYkpohhqVyS, P_0.GbuQBvidGvAbJenjCZjxMhzWHNqdA, P_1);
			}
		}

		private void BCaFQSUdKMoXVxmiqwAPqoEBDwAO(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.rfJxPINfqtyiIjpMCLqbmCRtAXuCA P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent(P_0.CNiQqtLsXIosNyIVkQoAurtcdJzX, LCUivSLtVZjfWgluNTVEMTZzAtrd.Button, P_0.grcqZOSCdclPVRHhgjFiEGoDkOfmA, P_0.NyuoGcEKipqYXgjeNKntVwptyHLk, P_1);
			}
		}

		private void fgPExWEKMxdyfdzROqLfnDaVEXVn(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.shGWzmLmtnTfhXZHOTQlWNgTwDQv P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent(P_0.yYbgwkjPibQhhhYAZHKAxmwbbVqBA, LCUivSLtVZjfWgluNTVEMTZzAtrd.Hat, P_0.MPcMhjARYSjbgwIpyDAKGLAlfHXf, P_0.tkwTpVnMGdWJUzIFfjSkhPRWPess, P_1);
			}
		}

		private void pStCbqHSRntPOHthpzVVLTZhqSGnA(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.VMubMcEuYwLbamzIHplRqPETxQRU P_0, double P_1)
		{
			_ = handleJoysticks;
		}

		private void fsrSPdNoLKfCBSgleeYARCcCkBDn(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.zvAFfUhYCozXsDnOQaSkXREcAXup P_0)
		{
			if (handleJoysticks)
			{
				cVsdxGADcKzbmgtnMngefQxxPQbUA(P_0.bquiHuXAIhrXJrSaXomkHaTXfhFq);
				if (VuVBpBchFFluRgjJJTqqwSLQBSLiA != null)
				{
					VuVBpBchFFluRgjJJTqqwSLQBSLiA();
				}
			}
		}

		private void YKuBlpOaVwSbKkOwsftoTEqnuOfS(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.zvAFfUhYCozXsDnOQaSkXREcAXup P_0)
		{
			if (handleJoysticks)
			{
				PZNBVvfTvnLXNyBLYuKNgPXcHlZr(P_0.bquiHuXAIhrXJrSaXomkHaTXfhFq);
				if (VuVBpBchFFluRgjJJTqqwSLQBSLiA != null)
				{
					VuVBpBchFFluRgjJJTqqwSLQBSLiA();
				}
			}
		}

		private void mRukQvGTrhzmxwEmpbVcMFxfzLdr(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.DsdkddDSidZqATmfIjGPVcTQrhLQ P_0, double P_1)
		{
			if (handleGamepads && P_0.bFliVjTjBnrEvXeZZQCIHADixXRj < 6 && P_0.bFliVjTjBnrEvXeZZQCIHADixXRj != -1)
			{
				SendGamepadElementChangedEvent(P_0.tgDUjYPUeMBGftOUQRljgpOIqpvo, LCUivSLtVZjfWgluNTVEMTZzAtrd.Axis, P_0.bFliVjTjBnrEvXeZZQCIHADixXRj, P_0.WVoZwxCeMPdzlwGuZGDPWfddFsVAA, P_1);
			}
		}

		private void ZQnZiTFGEzdQjNRddjbJaEoVdkEM(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.msEsPcuAGEdSbeaqraVMloywebcJ P_0, double P_1)
		{
			if (handleGamepads && P_0.rFCiTzdisCxTtHcDkLgXNCPFaPtz < 21 && P_0.rFCiTzdisCxTtHcDkLgXNCPFaPtz != -1)
			{
				SendGamepadElementChangedEvent(P_0.FXWXYFYqrCInjtphuurGXQLeWgni, LCUivSLtVZjfWgluNTVEMTZzAtrd.Button, P_0.rFCiTzdisCxTtHcDkLgXNCPFaPtz, P_0.xQDpLeGUTkdhendlXbSCNSAQtVkL, P_1);
			}
		}

		private void XNrAsITtoNdTPuVdzcFASNJlgTxdA(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.CzEGHQVnBgiKaHHOuFOqxktYXiYsA P_0)
		{
			if (handleGamepads)
			{
				cVsdxGADcKzbmgtnMngefQxxPQbUA(P_0.GPmPgPClpzExlmpoELILMqVueucq);
				if (VuVBpBchFFluRgjJJTqqwSLQBSLiA != null)
				{
					VuVBpBchFFluRgjJJTqqwSLQBSLiA();
				}
			}
		}

		private void axfrwFpkrCICmcBGWSYvSHeasYzH(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.CzEGHQVnBgiKaHHOuFOqxktYXiYsA P_0)
		{
			if (handleGamepads)
			{
				PZNBVvfTvnLXNyBLYuKNgPXcHlZr(P_0.GPmPgPClpzExlmpoELILMqVueucq);
				if (VuVBpBchFFluRgjJJTqqwSLQBSLiA != null)
				{
					VuVBpBchFFluRgjJJTqqwSLQBSLiA();
				}
			}
		}

		private void xnuaQOHazqUSfmuzigwFluIUxXyF(ref auIzLjThapfhEAPwYCbPNbnNEOhCA.CzEGHQVnBgiKaHHOuFOqxktYXiYsA P_0)
		{
			_ = handleGamepads;
		}

		protected override void Dispose(bool disposing)
		{
			if (!boJAjFfYAsVqZkjDESHbhUOfucENA)
			{
				boJAjFfYAsVqZkjDESHbhUOfucENA = true;
				base.Dispose(disposing);
			}
		}
	}
}
