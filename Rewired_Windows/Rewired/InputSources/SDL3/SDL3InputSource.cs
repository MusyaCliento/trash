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

namespace Rewired.InputSources.SDL3
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SDL3InputSource : SDLInputSource
	{
		private const int AesfglDgmauACYpUrQPckKhVnGGg = 32;

		private const float WOissdcSECkozQkddLtBdmBAZSXf = 1f;

		private pxmGIZLDmjeWcctuwsIuvAjQwjgDA.jrOXKvmxVSNAXCtMxUHPQibkIkNe sQXMRevZeoAVozQJLHiJXoLgiAyG;

		private readonly TimerAbs uoSEghnWgxxvAxOyxQerkEReGEKU;

		private readonly List<uint> IWzZzRRisqBqcxBEXNNyzQzkhDml;

		private readonly List<uint> ZsMrWjViuBeNlPdaLZiwfasbVNou;

		[CompilerGenerated]
		private Action DkdvkqkNFAgmUjfitjmWscBwPPpAb;

		private bool KMSPyxeQoYMVULwTpgytWbLtjLGT;

		private static readonly string[] NpMbBgstJSoZukXeDACPYZVXnjcv = new string[0];

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = DkdvkqkNFAgmUjfitjmWscBwPPpAb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref DkdvkqkNFAgmUjfitjmWscBwPPpAb, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = DkdvkqkNFAgmUjfitjmWscBwPPpAb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref DkdvkqkNFAgmUjfitjmWscBwPPpAb, value2, action2);
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

		public SDL3InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
			: base(P_0, P_1, P_2, P_3, P_4)
		{
			uoSEghnWgxxvAxOyxQerkEReGEKU = new TimerAbs(1.0);
			IWzZzRRisqBqcxBEXNNyzQzkhDml = new List<uint>();
			ZsMrWjViuBeNlPdaLZiwfasbVNou = new List<uint>();
			PostConstructor();
		}

		protected override bool InitializeSDL()
		{
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				if (!pxmGIZLDmjeWcctuwsIuvAjQwjgDA.sFGuNRGtFNvYZnOnWzhTBzLeGKtD((uint)num))
				{
					throw new Exception("Failed initialize SDL3!");
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
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.tZZzGxzMUgcLwhGEiypPYcUMQcsQ();
		}

		protected override int GetEventBufferSize()
		{
			return pxmGIZLDmjeWcctuwsIuvAjQwjgDA.jrOXKvmxVSNAXCtMxUHPQibkIkNe.uNhRJkRZcRVUIXUbBPSbQlACsmQB;
		}

		protected override int GetSDLJoystickCount()
		{
			if (!base.initialized)
			{
				return 0;
			}
			ZsMrWjViuBeNlPdaLZiwfasbVNou.Clear();
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.uzkeCnIyobLcOEfNWrelYZdfuIvN(ZsMrWjViuBeNlPdaLZiwfasbVNou);
			return Math.Min(ZsMrWjViuBeNlPdaLZiwfasbVNou.Count, 32);
		}

		protected override int GetGamepadCount()
		{
			if (!base.initialized)
			{
				return 0;
			}
			ZsMrWjViuBeNlPdaLZiwfasbVNou.Clear();
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.uzkeCnIyobLcOEfNWrelYZdfuIvN(ZsMrWjViuBeNlPdaLZiwfasbVNou);
			int num = 0;
			for (int i = 0; i < ZsMrWjViuBeNlPdaLZiwfasbVNou.Count; i++)
			{
				if (!pxmGIZLDmjeWcctuwsIuvAjQwjgDA.IWepkTAORKbrchNybcubBdgTSnxsA(ZsMrWjViuBeNlPdaLZiwfasbVNou[i]))
				{
					num++;
				}
			}
			return num;
		}

		protected override void PollForJoystickChanges(bool force)
		{
			if ((!handleJoysticks && !handleGamepads) || (!force && !uoSEghnWgxxvAxOyxQerkEReGEKU.Update()))
			{
				return;
			}
			IWzZzRRisqBqcxBEXNNyzQzkhDml.Clear();
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.uzkeCnIyobLcOEfNWrelYZdfuIvN(IWzZzRRisqBqcxBEXNNyzQzkhDml);
			int count = IWzZzRRisqBqcxBEXNNyzQzkhDml.Count;
			bool flag = false;
			for (int num = base.joysticks.Count - 1; num >= 0; num--)
			{
				uint num2 = (uint)base.joysticks[num].LLLVSyGEDzGKHJoApyvkQjXBgayhA;
				if (!IWzZzRRisqBqcxBEXNNyzQzkhDml.Contains(num2))
				{
					ohkAYngzsnBbiGrvpwwFnipwIsBEb(num2);
					flag = true;
				}
			}
			for (int i = 0; i < count; i++)
			{
				uint num3 = IWzZzRRisqBqcxBEXNNyzQzkhDml[i];
				if (IndexOfJoystickWithInstanceId((int)num3) < 0)
				{
					EPSSdFXiEOkEMJHrBjhgejVBTWef(num3);
					flag = true;
				}
			}
			uoSEghnWgxxvAxOyxQerkEReGEKU.Start();
			if (flag && DkdvkqkNFAgmUjfitjmWscBwPPpAb != null)
			{
				DkdvkqkNFAgmUjfitjmWscBwPPpAb();
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
			while (pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EbuFExHFxuHNjmbCEgXDtHWnQxRtA(nativeBuffer) != 0)
			{
				sQXMRevZeoAVozQJLHiJXoLgiAyG.BvInkoCaSPYIbhsmliOsMcwBMsDA(nativeBuffer);
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY gnHaUxSKuyLCqSvQoIPUZjOHejMEA = sQXMRevZeoAVozQJLHiJXoLgiAyG.gnHaUxSKuyLCqSvQoIPUZjOHejMEA;
				double realTime = ReInput.realTime;
				switch (gnHaUxSKuyLCqSvQoIPUZjOHejMEA)
				{
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_AXIS_MOTION:
					fzJbCOAfBGFMIrkyqJpQKhTuufsb(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.SeorunZGJXCLMkaXOBZyNaugtzSn, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_BUTTON_DOWN:
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_BUTTON_UP:
					eaANhVcVVpKCxOXcwXhrQGgkcVbV(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.VIVUCxHmRPBuQOMGZRowutlENubN, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_REMAPPED:
					gRFiilNSykztJlnhWDPFyHYnxsdk(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.feFzqUnaGKvpjzzgYIfXoZRrTatn);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_AXIS_MOTION:
					iZYbFfcSEnccPihDuylYULEgofTAb(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.nbygCcLlBVIhAQkheILGbTTKHffC, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BUTTON_DOWN:
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BUTTON_UP:
					WuygkByhcNLKZcsYMbbxsBgFIWIaA(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.IKPYBqlTeLaOWflYvOWXeRXHtLfc, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_HAT_MOTION:
					bgeGqwprTObFkcYKwYluAuuJBnGx(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.yfhAoNlZJBftuqMUHoUIQVIquYuI, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BALL_MOTION:
					gAJVsvLwCqMqUChKTABfBJcaTxFEA(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.foWdnCasrSPhMRmWnvqJISYaegsy, realTime);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_ADDED:
					GQSqnWwkQuvJvxbEmITLFnnRowxdA(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.VLGIejdlITxupuoLjKExTBiNBQce);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_REMOVED:
					jYwkjyQDtnIBpdPlQSglIDpfxbU(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.VLGIejdlITxupuoLjKExTBiNBQce);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_ADDED:
					pPUrodmzlUQSIhWTRObuceqqVilU(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.feFzqUnaGKvpjzzgYIfXoZRrTatn);
					break;
				case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_REMOVED:
					ulHdYucqbAccAHYcGmINrGagJNfqA(ref sQXMRevZeoAVozQJLHiJXoLgiAyG.feFzqUnaGKvpjzzgYIfXoZRrTatn);
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
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && array[i].IndexOf(',') >= 32 && !(pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EHvjJbPptTBWDBJOPAkxHJxPmawG(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					pxmGIZLDmjeWcctuwsIuvAjQwjgDA.HAnoHkhrOMwjxBkgeJEYBdFYmusM(array[i]);
				}
			}
		}

		protected override bool IsAllowed(qsgekoIkSLKHNvSvhDyqzbhlTpKd device)
		{
			for (int i = 0; i < NpMbBgstJSoZukXeDACPYZVXnjcv.Length; i++)
			{
				if (string.Equals(device.daoSvnTfYTUAaCJXGklyVPSSbAmL, NpMbBgstJSoZukXeDACPYZVXnjcv[i], StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			return true;
		}

		protected override void SendGamepadElementChangedEvent(int instanceId, LCUivSLtVZjfWgluNTVEMTZzAtrd elementType, byte gamepadElement, short value, double timestamp)
		{
			if (elementType != LCUivSLtVZjfWgluNTVEMTZzAtrd.Button)
			{
				base.SendGamepadElementChangedEvent(instanceId, elementType, gamepadElement, value, timestamp);
				return;
			}
			YUhbQhiLFKRAUFwRWqBNoTItxqmB joystickByInstanceId = GetJoystickByInstanceId(instanceId);
			if (joystickByInstanceId == null || joystickByInstanceId.JoystickType != dHPpbhmiaqtelxmYmFpgoGAPMmoe.Gamepad)
			{
				return;
			}
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx axgFQhfotfIXKYJWlfgsPlrkPOx = (pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx)gamepadElement;
			switch (axgFQhfotfIXKYJWlfgsPlrkPOx)
			{
			case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx.SDL_GAMEPAD_BUTTON_SOUTH:
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE etRzNUFJAUSbCcCBmfZEkvaozkdE = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.eiiRYgQkojIIFFkSqeMvbEyRQECY(joystickByInstanceId.LbIjrRdDUawnkqAaEILaGMrckkrHA, axgFQhfotfIXKYJWlfgsPlrkPOx);
				if (etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_B || etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_CIRCLE)
				{
					gamepadElement = 1;
				}
				break;
			}
			case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx.SDL_GAMEPAD_BUTTON_EAST:
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE etRzNUFJAUSbCcCBmfZEkvaozkdE = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.eiiRYgQkojIIFFkSqeMvbEyRQECY(joystickByInstanceId.LbIjrRdDUawnkqAaEILaGMrckkrHA, axgFQhfotfIXKYJWlfgsPlrkPOx);
				if (etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_A || etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_SQUARE)
				{
					gamepadElement = 0;
				}
				break;
			}
			case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx.SDL_GAMEPAD_BUTTON_NORTH:
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE etRzNUFJAUSbCcCBmfZEkvaozkdE = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.eiiRYgQkojIIFFkSqeMvbEyRQECY(joystickByInstanceId.LbIjrRdDUawnkqAaEILaGMrckkrHA, axgFQhfotfIXKYJWlfgsPlrkPOx);
				if (etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_X || etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_SQUARE)
				{
					gamepadElement = 2;
				}
				break;
			}
			case pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AxgFQhfotfIXKYJWlfgsPlrkPOx.SDL_GAMEPAD_BUTTON_WEST:
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE etRzNUFJAUSbCcCBmfZEkvaozkdE = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.eiiRYgQkojIIFFkSqeMvbEyRQECY(joystickByInstanceId.LbIjrRdDUawnkqAaEILaGMrckkrHA, axgFQhfotfIXKYJWlfgsPlrkPOx);
				if (etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_Y || etRzNUFJAUSbCcCBmfZEkvaozkdE == pxmGIZLDmjeWcctuwsIuvAjQwjgDA.EtRzNUFJAUSbCcCBmfZEkvaozkdE.SDL_GAMEPAD_BUTTON_LABEL_CIRCLE)
				{
					gamepadElement = 3;
				}
				break;
			}
			}
			joystickByInstanceId.BXtMGusXZmJevKpyBFevOheNKlrI(elementType, gamepadElement, value, timestamp);
		}

		private YiwcomZCvMgfXhGkTHKiDqEgfOmd NjPrNvRFAZywjJcxwNgLXchbHKqhA(uint P_0)
		{
			bool flag = handleGamepads && pxmGIZLDmjeWcctuwsIuvAjQwjgDA.IWepkTAORKbrchNybcubBdgTSnxsA(P_0);
			IntPtr intPtr = ((!flag) ? pxmGIZLDmjeWcctuwsIuvAjQwjgDA.AnHUFEgCGQWFtoHtAHnyPluvoHPm(P_0) : pxmGIZLDmjeWcctuwsIuvAjQwjgDA.jSQcpRAKsOJqUGsdfyEbwoyQYuReb(P_0));
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			if (flag)
			{
				zDbEpgAbmSQSqdROmaGAcBeJJIpLA zDbEpgAbmSQSqdROmaGAcBeJJIpLA2 = new zDbEpgAbmSQSqdROmaGAcBeJJIpLA(intPtr);
				GdElFSEOhuyCrFfZjnsSYHuwFWAO gdElFSEOhuyCrFfZjnsSYHuwFWAO;
				if (zDbEpgAbmSQSqdROmaGAcBeJJIpLA2 == null || (gdElFSEOhuyCrFfZjnsSYHuwFWAO = VkWvxfyLvgDxOLdYIxSgXpHXrlYu(zDbEpgAbmSQSqdROmaGAcBeJJIpLA2)) == null)
				{
					pxmGIZLDmjeWcctuwsIuvAjQwjgDA.wxhQaGkxJXymCefWIsCgvpnnElEC(intPtr);
					return null;
				}
				gdElFSEOhuyCrFfZjnsSYHuwFWAO.sfoYVJcrXkevgsOSdTNFBJgwhbPR = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.ZbtNfpLoaDrbbeVCjJlEQLjzHYOH(zDbEpgAbmSQSqdROmaGAcBeJJIpLA2);
				return new HNmQPvTfApgGTPfKxjBLGwYpqewKA(zDbEpgAbmSQSqdROmaGAcBeJJIpLA2, gdElFSEOhuyCrFfZjnsSYHuwFWAO);
			}
			XpNKCOqUzDasRgxXUoUMgbzXvBfj xpNKCOqUzDasRgxXUoUMgbzXvBfj = new XpNKCOqUzDasRgxXUoUMgbzXvBfj(intPtr);
			GdElFSEOhuyCrFfZjnsSYHuwFWAO gdElFSEOhuyCrFfZjnsSYHuwFWAO2;
			if (xpNKCOqUzDasRgxXUoUMgbzXvBfj == null || (gdElFSEOhuyCrFfZjnsSYHuwFWAO2 = uecPTqlbNWsAnHVVEotMQbupRoSl(xpNKCOqUzDasRgxXUoUMgbzXvBfj)) == null)
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.yWDfbPGYdLfrzekXDjFMEmFOgNwoB(intPtr);
				return null;
			}
			return new YiwcomZCvMgfXhGkTHKiDqEgfOmd(xpNKCOqUzDasRgxXUoUMgbzXvBfj, gdElFSEOhuyCrFfZjnsSYHuwFWAO2);
		}

		private static GdElFSEOhuyCrFfZjnsSYHuwFWAO uecPTqlbNWsAnHVVEotMQbupRoSl(XpNKCOqUzDasRgxXUoUMgbzXvBfj P_0)
		{
			if (P_0 == null || !P_0.IsValid)
			{
				return null;
			}
			uint num = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.uoMimMWgJMUhoMItFBOpgJdOITInA(P_0);
			GdElFSEOhuyCrFfZjnsSYHuwFWAO obj = new GdElFSEOhuyCrFfZjnsSYHuwFWAO
			{
				TDudrxbFvSstbgDXOPSMbfHAwiWi = (int)num,
				DuFcMoHqcexRAUNbpmCitVQxoaSMA = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.IWepkTAORKbrchNybcubBdgTSnxsA(num),
				fGIInnkAVaVFJKaBwjSzHBZWEcMg = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.mgxLqapDDQLDKBNoIVzDWjxJMoIi(P_0)
			};
			obj.sfoYVJcrXkevgsOSdTNFBJgwhbPR = obj.fGIInnkAVaVFJKaBwjSzHBZWEcMg;
			obj.AQvCMFJkTvPzrjpOQCEnprMZCYF = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.zPSkzKnYrZmBfQvWtHrUmFnqaZZdA(P_0);
			obj.VukEvBLvmrBftyCEzFgwLbAAWyJR = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.ObXgDYxDXCbapgjQQWiWQtKjCtCW(P_0);
			obj.RmKSHNAGkceIRsmrGCuDobqChBTCA = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.NyAuUXyxKhfZjOzqyCdDJVrillzE(P_0);
			obj.FkDELqtzCmYPMVFpwfLQPTmSsXb = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.DlKebAjRVloWiYdPJRXemGzwLNOlA(P_0);
			obj.TKbHDwxJdmGNiCXUCkPdgLYfccNnA = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.sbgKdaLDLMkEkGEtOihrnlrnIezX(P_0);
			obj.pMoufDFFSiuqwYruLxjEMclAscOI = new PidVid(pxmGIZLDmjeWcctuwsIuvAjQwjgDA.BmMrBxeQmbGOVjxGkEvKSiiMiPQOA(P_0), pxmGIZLDmjeWcctuwsIuvAjQwjgDA.BwITpFhOTLCoiIDJvlHEzQoKPZlVA(P_0));
			return obj;
		}

		private GdElFSEOhuyCrFfZjnsSYHuwFWAO VkWvxfyLvgDxOLdYIxSgXpHXrlYu(zDbEpgAbmSQSqdROmaGAcBeJJIpLA P_0)
		{
			if (P_0 == null || !P_0.IsValid)
			{
				return null;
			}
			XpNKCOqUzDasRgxXUoUMgbzXvBfj xpNKCOqUzDasRgxXUoUMgbzXvBfj = new XpNKCOqUzDasRgxXUoUMgbzXvBfj(pxmGIZLDmjeWcctuwsIuvAjQwjgDA.wqIWWYFYNwrUjkSKZPLLBEuZtrhm(P_0));
			if (!xpNKCOqUzDasRgxXUoUMgbzXvBfj.IsValid)
			{
				return null;
			}
			return uecPTqlbNWsAnHVVEotMQbupRoSl(xpNKCOqUzDasRgxXUoUMgbzXvBfj);
		}

		private bool EPSSdFXiEOkEMJHrBjhgejVBTWef(uint P_0)
		{
			if (GetJoystickByInstanceId((int)P_0) != null)
			{
				return false;
			}
			YiwcomZCvMgfXhGkTHKiDqEgfOmd yiwcomZCvMgfXhGkTHKiDqEgfOmd = NjPrNvRFAZywjJcxwNgLXchbHKqhA(P_0);
			if (yiwcomZCvMgfXhGkTHKiDqEgfOmd == null)
			{
				return false;
			}
			base.joysticks.Add((int)P_0, yiwcomZCvMgfXhGkTHKiDqEgfOmd);
			yiwcomZCvMgfXhGkTHKiDqEgfOmd.hHEnyQdaaIvddTeEsIqNULQzGaaV();
			return true;
		}

		private void ohkAYngzsnBbiGrvpwwFnipwIsBEb(uint P_0)
		{
			if (base.joysticks.ContainsKey((int)P_0))
			{
				base.joysticks.GetValue((int)P_0).fAHcymjXpGWrrPnAFpKcaDcXehCdA();
				base.joysticks.Remove((int)P_0);
			}
		}

		private void iZYbFfcSEnccPihDuylYULEgofTAb(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.yQJEMlmMhtNqHLGYvefFEJpNAUbrA P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent((int)P_0.hYkgToHcrWiIAHpufGvJeYXRUtjPB, LCUivSLtVZjfWgluNTVEMTZzAtrd.Axis, P_0.ptVihlAKwPNDEtpGCWvCSOWDahmcA, P_0.vthMnOkThcfQrRilyfjPEVkbucpA, P_1);
			}
		}

		private void WuygkByhcNLKZcsYMbbxsBgFIWIaA(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.MUmgZITDTnkpecACRXAWNbyLqoUh P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent((int)P_0.tnFRSMKPcOaiVsyhucJARhwFeMxX, LCUivSLtVZjfWgluNTVEMTZzAtrd.Button, P_0.AzJvrvftlmKBMVHagpQbIbCgnyQg, P_0.GVOqtNtaIebeHEuiuFcZPIwktqaM ? ((short)1) : ((short)0), P_1);
			}
		}

		private void bgeGqwprTObFkcYKwYluAuuJBnGx(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.PpiubwNfAtDLNReyxBVjDzwOQTbA P_0, double P_1)
		{
			if (handleJoysticks)
			{
				SendJoystickElementChangedEvent((int)P_0.uPyWTTvdMpQxzUcKvhlOrlBCZuZA, LCUivSLtVZjfWgluNTVEMTZzAtrd.Hat, P_0.FRcEfUetZMlNaehhaknInEoNtRwE, P_0.pUJBtwatoqvnCGcbhcesNfQOcfbg, P_1);
			}
		}

		private void gAJVsvLwCqMqUChKTABfBJcaTxFEA(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.vOhKbcnMhKrsIyaSqcZPexMpZjLxA P_0, double P_1)
		{
			_ = handleJoysticks;
		}

		private void GQSqnWwkQuvJvxbEmITLFnnRowxdA(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.baOlxHoNmARXmTdiFWvcXIlwKhml P_0)
		{
			if (handleJoysticks)
			{
				EPSSdFXiEOkEMJHrBjhgejVBTWef(P_0.WURiEHOzJutyQtdjVWxpRlUpiYRh);
				if (DkdvkqkNFAgmUjfitjmWscBwPPpAb != null)
				{
					DkdvkqkNFAgmUjfitjmWscBwPPpAb();
				}
			}
		}

		private void jYwkjyQDtnIBpdPlQSglIDpfxbU(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.baOlxHoNmARXmTdiFWvcXIlwKhml P_0)
		{
			if (handleJoysticks)
			{
				ohkAYngzsnBbiGrvpwwFnipwIsBEb(P_0.WURiEHOzJutyQtdjVWxpRlUpiYRh);
				if (DkdvkqkNFAgmUjfitjmWscBwPPpAb != null)
				{
					DkdvkqkNFAgmUjfitjmWscBwPPpAb();
				}
			}
		}

		private void fzJbCOAfBGFMIrkyqJpQKhTuufsb(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.yrKsHENCotxjHyATqFCwdSUsUAsW P_0, double P_1)
		{
			if (handleGamepads && P_0.FQsaJhJpqgzbEXhYjfexjxGryPZoA < 6 && P_0.FQsaJhJpqgzbEXhYjfexjxGryPZoA != -1)
			{
				SendGamepadElementChangedEvent((int)P_0.aHLylUISxsNyVtEvTKMCxXqzMcAq, LCUivSLtVZjfWgluNTVEMTZzAtrd.Axis, P_0.FQsaJhJpqgzbEXhYjfexjxGryPZoA, P_0.tJKLBrTLnqeuiiHHrgOVpXOImYwBA, P_1);
			}
		}

		private void eaANhVcVVpKCxOXcwXhrQGgkcVbV(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.cxbxRuDqZxEKatrrguTOSUAZCobB P_0, double P_1)
		{
			if (handleGamepads && P_0.BtPhypzDBTuegKWoWIcwcqwDYSfU < 26 && P_0.BtPhypzDBTuegKWoWIcwcqwDYSfU != -1)
			{
				SendGamepadElementChangedEvent((int)P_0.YpJdtCdOILbMxhFvJcopcWFXNPdOB, LCUivSLtVZjfWgluNTVEMTZzAtrd.Button, P_0.BtPhypzDBTuegKWoWIcwcqwDYSfU, P_0.vuuaijXxZixZaBjdhTjElytqHTsr ? ((short)1) : ((short)0), P_1);
			}
		}

		private void pPUrodmzlUQSIhWTRObuceqqVilU(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.hSQawAHNEYBBHjowSErncAJAhUXwA P_0)
		{
			if (handleGamepads)
			{
				EPSSdFXiEOkEMJHrBjhgejVBTWef(P_0.YRHkdXLqrFgyXTaUtmqyWdCQfbKN);
				if (DkdvkqkNFAgmUjfitjmWscBwPPpAb != null)
				{
					DkdvkqkNFAgmUjfitjmWscBwPPpAb();
				}
			}
		}

		private void ulHdYucqbAccAHYcGmINrGagJNfqA(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.hSQawAHNEYBBHjowSErncAJAhUXwA P_0)
		{
			if (handleGamepads)
			{
				ohkAYngzsnBbiGrvpwwFnipwIsBEb(P_0.YRHkdXLqrFgyXTaUtmqyWdCQfbKN);
				if (DkdvkqkNFAgmUjfitjmWscBwPPpAb != null)
				{
					DkdvkqkNFAgmUjfitjmWscBwPPpAb();
				}
			}
		}

		private void gRFiilNSykztJlnhWDPFyHYnxsdk(ref pxmGIZLDmjeWcctuwsIuvAjQwjgDA.hSQawAHNEYBBHjowSErncAJAhUXwA P_0)
		{
			_ = handleGamepads;
		}

		protected override void Dispose(bool disposing)
		{
			if (!KMSPyxeQoYMVULwTpgytWbLtjLGT)
			{
				KMSPyxeQoYMVULwTpgytWbLtjLGT = true;
				base.Dispose(disposing);
			}
		}
	}
}
