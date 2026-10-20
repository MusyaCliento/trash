using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class pxmGIZLDmjeWcctuwsIuvAjQwjgDA
{
	public enum xQDvWGkjnOWYMZhNLQFBsPfFLybr : uint
	{
		SDL_INIT_AUDIO = 16u,
		SDL_INIT_VIDEO = 32u,
		SDL_INIT_JOYSTICK = 512u,
		SDL_INIT_HAPTIC = 4096u,
		SDL_INIT_GAMEPAD = 8192u,
		SDL_INIT_EVENTS = 16384u,
		SDL_INIT_SENSOR = 32768u,
		SDL_INIT_CAMERA = 65536u,
		EVERYTHING = 29232u
	}

	public enum cJhHdMCGFpZnVrLUjglfYcitgPUY : uint
	{
		SDL_EVENT_FIRST = 0u,
		SDL_EVENT_QUIT = 256u,
		SDL_EVENT_TERMINATING = 257u,
		SDL_EVENT_LOW_MEMORY = 258u,
		SDL_EVENT_WILL_ENTER_BACKGROUND = 259u,
		SDL_EVENT_DID_ENTER_BACKGROUND = 260u,
		SDL_EVENT_WILL_ENTER_FOREGROUND = 261u,
		SDL_EVENT_DID_ENTER_FOREGROUND = 262u,
		SDL_EVENT_LOCALE_CHANGED = 263u,
		SDL_EVENT_SYSTEM_THEME_CHANGED = 264u,
		SDL_EVENT_DISPLAY_ORIENTATION = 337u,
		SDL_EVENT_DISPLAY_ADDED = 338u,
		SDL_EVENT_DISPLAY_REMOVED = 339u,
		SDL_EVENT_DISPLAY_MOVED = 340u,
		SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED = 341u,
		SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED = 342u,
		SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED = 343u,
		SDL_EVENT_DISPLAY_USABLE_BOUNDS_CHANGED = 344u,
		SDL_EVENT_DISPLAY_FIRST = 337u,
		SDL_EVENT_DISPLAY_LAST = 344u,
		SDL_EVENT_WINDOW_SHOWN = 514u,
		SDL_EVENT_WINDOW_HIDDEN = 515u,
		SDL_EVENT_WINDOW_EXPOSED = 516u,
		SDL_EVENT_WINDOW_MOVED = 517u,
		SDL_EVENT_WINDOW_RESIZED = 518u,
		SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED = 519u,
		SDL_EVENT_WINDOW_METAL_VIEW_RESIZED = 520u,
		SDL_EVENT_WINDOW_MINIMIZED = 521u,
		SDL_EVENT_WINDOW_MAXIMIZED = 522u,
		SDL_EVENT_WINDOW_RESTORED = 523u,
		SDL_EVENT_WINDOW_MOUSE_ENTER = 524u,
		SDL_EVENT_WINDOW_MOUSE_LEAVE = 525u,
		SDL_EVENT_WINDOW_FOCUS_GAINED = 526u,
		SDL_EVENT_WINDOW_FOCUS_LOST = 527u,
		SDL_EVENT_WINDOW_CLOSE_REQUESTED = 528u,
		SDL_EVENT_WINDOW_HIT_TEST = 529u,
		SDL_EVENT_WINDOW_ICCPROF_CHANGED = 530u,
		SDL_EVENT_WINDOW_DISPLAY_CHANGED = 531u,
		SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED = 532u,
		SDL_EVENT_WINDOW_SAFE_AREA_CHANGED = 533u,
		SDL_EVENT_WINDOW_OCCLUDED = 534u,
		SDL_EVENT_WINDOW_ENTER_FULLSCREEN = 535u,
		SDL_EVENT_WINDOW_LEAVE_FULLSCREEN = 536u,
		SDL_EVENT_WINDOW_DESTROYED = 537u,
		SDL_EVENT_WINDOW_HDR_STATE_CHANGED = 538u,
		SDL_EVENT_WINDOW_FIRST = 514u,
		SDL_EVENT_WINDOW_LAST = 538u,
		SDL_EVENT_KEY_DOWN = 768u,
		SDL_EVENT_KEY_UP = 769u,
		SDL_EVENT_TEXT_EDITING = 770u,
		SDL_EVENT_TEXT_INPUT = 771u,
		SDL_EVENT_KEYMAP_CHANGED = 772u,
		SDL_EVENT_KEYBOARD_ADDED = 773u,
		SDL_EVENT_KEYBOARD_REMOVED = 774u,
		SDL_EVENT_TEXT_EDITING_CANDIDATES = 775u,
		SDL_EVENT_SCREEN_KEYBOARD_SHOWN = 776u,
		SDL_EVENT_SCREEN_KEYBOARD_HIDDEN = 777u,
		SDL_EVENT_MOUSE_MOTION = 1024u,
		SDL_EVENT_MOUSE_BUTTON_DOWN = 1025u,
		SDL_EVENT_MOUSE_BUTTON_UP = 1026u,
		SDL_EVENT_MOUSE_WHEEL = 1027u,
		SDL_EVENT_MOUSE_ADDED = 1028u,
		SDL_EVENT_MOUSE_REMOVED = 1029u,
		SDL_EVENT_JOYSTICK_AXIS_MOTION = 1536u,
		SDL_EVENT_JOYSTICK_BALL_MOTION = 1537u,
		SDL_EVENT_JOYSTICK_HAT_MOTION = 1538u,
		SDL_EVENT_JOYSTICK_BUTTON_DOWN = 1539u,
		SDL_EVENT_JOYSTICK_BUTTON_UP = 1540u,
		SDL_EVENT_JOYSTICK_ADDED = 1541u,
		SDL_EVENT_JOYSTICK_REMOVED = 1542u,
		SDL_EVENT_JOYSTICK_BATTERY_UPDATED = 1543u,
		SDL_EVENT_JOYSTICK_UPDATE_COMPLETE = 1544u,
		SDL_EVENT_GAMEPAD_AXIS_MOTION = 1616u,
		SDL_EVENT_GAMEPAD_BUTTON_DOWN = 1617u,
		SDL_EVENT_GAMEPAD_BUTTON_UP = 1618u,
		SDL_EVENT_GAMEPAD_ADDED = 1619u,
		SDL_EVENT_GAMEPAD_REMOVED = 1620u,
		SDL_EVENT_GAMEPAD_REMAPPED = 1621u,
		SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN = 1622u,
		SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION = 1623u,
		SDL_EVENT_GAMEPAD_TOUCHPAD_UP = 1624u,
		SDL_EVENT_GAMEPAD_SENSOR_UPDATE = 1625u,
		SDL_EVENT_GAMEPAD_UPDATE_COMPLETE = 1626u,
		SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED = 1627u,
		SDL_EVENT_FINGER_DOWN = 1792u,
		SDL_EVENT_FINGER_UP = 1793u,
		SDL_EVENT_FINGER_MOTION = 1794u,
		SDL_EVENT_FINGER_CANCELED = 1795u,
		SDL_EVENT_PINCH_BEGIN = 1808u,
		SDL_EVENT_PINCH_UPDATE = 1809u,
		SDL_EVENT_PINCH_END = 1810u,
		SDL_EVENT_CLIPBOARD_UPDATE = 2304u,
		SDL_EVENT_DROP_FILE = 4096u,
		SDL_EVENT_DROP_TEXT = 4097u,
		SDL_EVENT_DROP_BEGIN = 4098u,
		SDL_EVENT_DROP_COMPLETE = 4099u,
		SDL_EVENT_DROP_POSITION = 4100u,
		SDL_EVENT_AUDIO_DEVICE_ADDED = 4352u,
		SDL_EVENT_AUDIO_DEVICE_REMOVED = 4353u,
		SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED = 4354u,
		SDL_EVENT_SENSOR_UPDATE = 4608u,
		SDL_EVENT_PEN_PROXIMITY_IN = 4864u,
		SDL_EVENT_PEN_PROXIMITY_OUT = 4865u,
		SDL_EVENT_PEN_DOWN = 4866u,
		SDL_EVENT_PEN_UP = 4867u,
		SDL_EVENT_PEN_BUTTON_DOWN = 4868u,
		SDL_EVENT_PEN_BUTTON_UP = 4869u,
		SDL_EVENT_PEN_MOTION = 4870u,
		SDL_EVENT_PEN_AXIS = 4871u,
		SDL_EVENT_CAMERA_DEVICE_ADDED = 5120u,
		SDL_EVENT_CAMERA_DEVICE_REMOVED = 5121u,
		SDL_EVENT_CAMERA_DEVICE_APPROVED = 5122u,
		SDL_EVENT_CAMERA_DEVICE_DENIED = 5123u,
		SDL_EVENT_RENDER_TARGETS_RESET = 8192u,
		SDL_EVENT_RENDER_DEVICE_RESET = 8193u,
		SDL_EVENT_RENDER_DEVICE_LOST = 8194u,
		SDL_EVENT_PRIVATE0 = 16384u,
		SDL_EVENT_PRIVATE1 = 16385u,
		SDL_EVENT_PRIVATE2 = 16386u,
		SDL_EVENT_PRIVATE3 = 16387u,
		SDL_EVENT_POLL_SENTINEL = 32512u,
		SDL_EVENT_USER = 32768u,
		SDL_EVENT_LAST = 65535u,
		SDL_EVENT_ENUM_PADDING = 2147483647u
	}

	public struct fwklKkKokRzjnEYMfCpdkRxVcXaD
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY HUYgMoKFlXfPZbMFKmiwVYNdMBmqB;

		public uint pThuSFKXRRpatiYxUBCasRubuMGo;

		public ulong eFZbxMzWjIoDwDpjqfshRYFmJXOK;
	}

	public struct OqzTEfMgOGbQoTnhYsbRBNPlwWCR
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY fzqxXKrzkudttZiREDhNisUXgBNjb;

		public uint RRDosCqbFSEpfkTyKySFEFoHJgNSA;

		public ulong jIVgLZRKtwnrmkudxiGxQUsWoiCv;

		public uint ukTXZWZmylHESlFlOCWzyggYcbgiA;

		public int zIkBYKFzwXRBDEnRyDEIEIPdjvDEb;

		public int zDLrpsEZkMoLixqmpCDGPLEuFdKK;
	}

	public struct MuqDKfuVVRFbEzdYzcQTvJcdDzSV
	{
		private cJhHdMCGFpZnVrLUjglfYcitgPUY bKsBcfWFFLybSFjpVjiOYhUGENEfA;

		private uint riaIElVxlIDKBZUUyEBFUliIuKew;

		private ulong ZIujDILlLYqVuORjfjiPPhfDkTxr;

		private uint qGLAPZFmoGKwlBTbPNUYXoVUunPAA;

		private int oDKhpcSbHFRDrxlfketpHGfVElxQ;

		private int cBYrRmAINrZJTVRCcEBgrlpfRaKl;
	}

	public struct oTptegxYSswbozHXmavJcdvsYmVb
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY TvRLaoIooAaVYfKrYwNzWXpbmODnA;

		public uint UztxNYlwZCfRyiDmCdIyCAUyARuuA;

		public ulong USUkCbnoBLOrVJQvVbrNzyoGqfWA;

		public uint oDUsQhvopaFsyghCzBeoKkaetqdTA;
	}

	public struct xvgePFPOsFtIIlDTjfltkPemtXZQA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY XhUbLfIKIUDfmYEnuwwquPPlAPJk;

		public uint MdYIEEHorMLSbXQupkiawLYBNtdZ;

		public ulong SbVDecRWhgemBObrgJYEiJiWlDzh;

		public uint IwWFecvjEppItJKKxGwthWZIesju;

		public uint yYuRSDnBwmABCBCShdfzbBSzxSzQ;

		public iydMKbzCSEkRTyYpUVlwRAlImugr ANHwERZRtxsedAKaWetyJqhuJNxN;

		public uint mvfWdCrKrMOBJpKOhRIThbtwddfm;

		public ushort zIyzShqcfwQvzUoOyaTDgcYNKMDC;

		public ushort PyYJErLBDNfaWwwitPrwwMLyeohG;

		public bool btNrtTWixVDCDUOeTfYBmRitixhZ;

		public bool gmBycpskyGBjJBzGQICcTnaPXXyAA;
	}

	public struct nUUbTuaXcDyxibeuuTAyOleMjJGYA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY RchfelCJxybhEWmUODyOdmoXAhhGA;

		public uint EzkXWWtaKBwLUgwHNbiPmIRAwWnQ;

		public ulong PZxPAOsTumgLjusXmoJRuNNGApsdA;

		public uint EjmGBEmnKzsoVtQUqqBsGBLbFIFf;

		public IntPtr NoDGakFtwxTGUhJGyYTakyfrcmhyA;

		public int lgrlkrbiBmKVjPMXezjCVMjaykNp;

		public int hSJwMaoUIZauQMnMXYRgSPWcIXoJ;
	}

	public struct PSaOVGAXbLDPycfbFWimRCOmOcnL
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY fUBVsPuTNJttxrozmCBQNfcyxlbE;

		public uint DuyoHouNPMHNmzVLiddRGOYQkfow;

		public ulong cbWXemNkVJiFdasoCEyMpkwmwOKX;

		public uint pdLBsXGxsKqrOOPJaHICAUwXuBjfA;

		public IntPtr TTTJItHugihBSiEwDBTnYNwGxLJv;

		public int oTyMAoUTAnmjBtpDwDOJymiAdXgk;

		public int dLnvVXgYgkgbuGUdTwIbLhmgInDM;

		public bool cEScWYBbDEpsVCLHxWVBmvozGViFb;

		public byte DxjipqdTwVVOFkeSLhptpxPyYtBG;

		public byte exIKAEbKsWtrkxzTAayHZfatLwnA;

		public byte gyGnlTCFovbPDedAHruGaFmuiqpdb;
	}

	public struct UqlqRzjFGjRGfkyCcIdpNDiAIlvQ
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY evmdZpSpBiWqkfrDrnKvxcohcmiz;

		public uint nTZVXnNkujcAfbijRxPGYLSYaziGA;

		public ulong UHLhOaoPqidnuEhDMUpNOOwSnJCY;

		public uint ehSPcfaxFZozWJICKiHXjzMdCrbb;

		public IntPtr knwtmzCHyddOVQuJJmfhalfLdaum;
	}

	public struct bDlwyLjwoBoYCVpMqOPAeEqPoXwt
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY ffFFRyByMLQJwPJDwBfZJFFsokBNA;

		public uint veOHBIBgdhAYtnSiTfFZEleBZrwWA;

		public ulong aXPqeEBfRlxaEHrvnLotuTxlXLoi;

		public uint dVmnsqOPfBjikxRmLfHcfEgYFgCPA;
	}

	public struct deqfcsHveBdnJwJWQAdGZMorbAzM
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY CByeOraiJeLVoUrKulzxUtPjIUZP;

		public uint pdXmmIGsBTUeEshHjLZQUavMEmLV;

		public ulong qtafWNhoooutoOxzOvIsmzHAhvDC;

		public uint QdAewhUtPRyGYWqKCxBAFGxRufSe;

		public uint TldVTErnbGoLPAKyBeaeRoZPkhYK;

		public DnCFVvvmErGHnZSLOgWMEXbxVJWp pxiRoDErBnGMLEdtxVzIJSFBARLnA;

		public float LIWHypMSSqWPwMvURIZcQuugeEhE;

		public float BkgyMDSroDEwSuFxXbQUOxjXWigj;

		public float noPHTqCfGtsSLZXScznlFhFfcSJI;

		public float oVocGUKeSOwBoOTYWrTgIOlQxkHG;
	}

	public struct nlmaeVxGKTCztVccwfHWJdNvTGhkA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY oPxaagdrqGTUelLAyreKFGgbyAXAc;

		public uint NDnIUADeGrxeCrAGwGvPzmFkAHye;

		public ulong OPCFZLCsgFcLePVDSiQlibltnNcbb;

		public uint IKimdbXeodkLJnIIjbRIwTRxkmyk;

		public uint jNDMZoTtgPGmHPYlvQioYMNJffGf;

		public byte fhjcpfTCvWYaXEcEvVzKJORnRuAJ;

		public bool SFxQxOJCIQpOcWqmykPfKEDuotZx;

		public byte vFQodnlJVpDwYfbfqcuFhlOOjtKgb;

		public byte uNSfVDLbNAmsaKdXMjAWjKSJHejs;

		public float EvaWvmLxIJVBzsDasWHolDEeZxOl;

		public float VYBVzvdMywdxrZJlmKyiZXViPmxP;
	}

	public struct DnMGjchUdlxXpfzZhXcbrWvPMThuA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY QGCoxwMcNTzSbaeRUfKiQHLWcLBC;

		public uint UibZkKyRRfMESNLUlQIXPKbmWqUo;

		public ulong LaPjeaZsHtNxBsMQBGrKhiTTOBmN;

		public uint pfCZXEseuOwytRdLvrbWiMeEiItGA;

		public uint GVwYIASqUfZMuHSYGpGdAOaFCuSc;

		public float jqfxcmiSSKRcNdPDqFjtfcENNSpq;

		public float tnHexsvBTklulWlYjMIehLnzAyzN;

		public wLMxdOBWESOCPvWDBmbAtJjMvcaw biYmhLbICxfLLKmDkzqnYSKKcIzd;

		public float BYmPPRzBSkNWyuPknrVfKFIwTOmn;

		public float PPnRZXhqBDRNVZJncgxmRUrgXXPr;

		public int UUAwgBXVunrcqjjDizUfWqvdWcYt;

		public int yVqkzQmRAojcxmHxBRkSGUTvCNBX;
	}

	public struct yQJEMlmMhtNqHLGYvefFEJpNAUbrA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY fvrBqjkoRLZGFMfqwYlQzNanlmhd;

		public uint AIGBDigFzuJlylqCcEKSEdaDEHpb;

		public ulong BiEyXwnWnidFHigaMgzkJEBifYnFA;

		public uint hYkgToHcrWiIAHpufGvJeYXRUtjPB;

		public byte ptVihlAKwPNDEtpGCWvCSOWDahmcA;

		public byte gbKPRrOFrcbsgEqQEdySdZKLQbbW;

		public byte NRbeRhLmEVhSaEbIpxMacDiyHFxJA;

		public byte jvIoacQUWzIJcbdwLPjXLVVxMYYi;

		public short vthMnOkThcfQrRilyfjPEVkbucpA;

		public ushort VVNzUmUafISnnkCYzPHkvkSvFgbN;

		public void aFWwfcgZdTqgGpdePFhyAZsEjNHjA(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			fvrBqjkoRLZGFMfqwYlQzNanlmhd = P_0;
			BiEyXwnWnidFHigaMgzkJEBifYnFA = P_1;
			hYkgToHcrWiIAHpufGvJeYXRUtjPB = (uint)Marshal.ReadInt32(P_2, 16);
			ptVihlAKwPNDEtpGCWvCSOWDahmcA = Marshal.ReadByte(P_2, 20);
			vthMnOkThcfQrRilyfjPEVkbucpA = Marshal.ReadInt16(P_2, 24);
		}
	}

	public struct vOhKbcnMhKrsIyaSqcZPexMpZjLxA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY NZyptthlpgNlqBuAySjODBxvbKxU;

		public uint sjsYbhxMZLcyocHaHNsRuLlWqVbb;

		public ulong VTjrixKtTfmaOBJzknFUHDFjDvqp;

		public uint dqLDOSblmrkgJJzXfbyiGCWcxRJuB;

		public byte WdsAqaBaZsaccDMGFgQEIFqbENrNc;

		public byte LlpZcRInzZCqnIqknDVfCcvJqkVcb;

		public byte jQonosjfgfAvBfAVanusZDkshbifb;

		public byte WQXPaYAOHBogaBxmxPxxiIMoVEih;

		public short dedmQEpuyVtPTaTttkiRcFLvcvTP;

		public short OnvqNSkDvYBaarkbsfVqAJMwSbdrA;

		public void QymRdTfluGPgPHNJINTVFbIoDkvQ(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			NZyptthlpgNlqBuAySjODBxvbKxU = P_0;
			VTjrixKtTfmaOBJzknFUHDFjDvqp = P_1;
			dqLDOSblmrkgJJzXfbyiGCWcxRJuB = (uint)Marshal.ReadInt32(P_2, 16);
			WdsAqaBaZsaccDMGFgQEIFqbENrNc = Marshal.ReadByte(P_2, 20);
			dedmQEpuyVtPTaTttkiRcFLvcvTP = Marshal.ReadInt16(P_2, 24);
			OnvqNSkDvYBaarkbsfVqAJMwSbdrA = Marshal.ReadInt16(P_2, 28);
		}
	}

	public struct PpiubwNfAtDLNReyxBVjDzwOQTbA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY UcVMcYkvbHpCuPYDWpKQamaRUBTT;

		public uint BhmfwWczVteylMHwSoYCFxzfsRrmc;

		public ulong KhYUdvfXZzqDhNoNUgKvgqnpHDTk;

		public uint uPyWTTvdMpQxzUcKvhlOrlBCZuZA;

		public byte FRcEfUetZMlNaehhaknInEoNtRwE;

		public byte pUJBtwatoqvnCGcbhcesNfQOcfbg;

		public byte OOLDOnzgdGrsQlqyefRYtoOJVpOk;

		public byte szKKTBvtlssTuucMxUrdMmoTimqz;

		public void MWzMUokRGbgqDdgIhrsweERepQgb(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			UcVMcYkvbHpCuPYDWpKQamaRUBTT = P_0;
			KhYUdvfXZzqDhNoNUgKvgqnpHDTk = P_1;
			uPyWTTvdMpQxzUcKvhlOrlBCZuZA = (uint)Marshal.ReadInt32(P_2, 16);
			FRcEfUetZMlNaehhaknInEoNtRwE = Marshal.ReadByte(P_2, 20);
			pUJBtwatoqvnCGcbhcesNfQOcfbg = Marshal.ReadByte(P_2, 21);
		}
	}

	public struct MUmgZITDTnkpecACRXAWNbyLqoUh
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY FXxTqHcfusQTiuplitQiVSMpTUSN;

		public uint ximbUkGYzlPqabuCKPiTogUaPmSaA;

		public ulong chgJznWtsxfslZItAYAtKppIQfOE;

		public uint tnFRSMKPcOaiVsyhucJARhwFeMxX;

		public byte AzJvrvftlmKBMVHagpQbIbCgnyQg;

		public bool GVOqtNtaIebeHEuiuFcZPIwktqaM;

		public byte bXdCTmVTKUiKjqoMuAMUKWHxtTwIA;

		public byte HCGEzmAYUxlMlksbKjffZJgwONmW;

		public void yyLwKWxglKuIbVAdzUrXIzAvMzHP(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			FXxTqHcfusQTiuplitQiVSMpTUSN = P_0;
			chgJznWtsxfslZItAYAtKppIQfOE = P_1;
			tnFRSMKPcOaiVsyhucJARhwFeMxX = (uint)Marshal.ReadInt32(P_2, 16);
			AzJvrvftlmKBMVHagpQbIbCgnyQg = Marshal.ReadByte(P_2, 20);
			GVOqtNtaIebeHEuiuFcZPIwktqaM = Marshal.ReadByte(P_2, 21) > 0;
		}
	}

	public struct baOlxHoNmARXmTdiFWvcXIlwKhml
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY TAZJykHKWpdOrsuBYbLYCDFNgdwS;

		public uint COiMWhRkSBufsfDFZebmVqPLilKB;

		public ulong BuqRXhpQQAGncFQNqALxVAGfMMZB;

		public uint WURiEHOzJutyQtdjVWxpRlUpiYRh;

		public void dqreQFUTppItSRmhppGuUGfTPWuN(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			TAZJykHKWpdOrsuBYbLYCDFNgdwS = P_0;
			BuqRXhpQQAGncFQNqALxVAGfMMZB = P_1;
			WURiEHOzJutyQtdjVWxpRlUpiYRh = (uint)Marshal.ReadInt32(P_2, 16);
		}
	}

	public struct imvhBLhgMaIsdnolZuYjSOjHHhjo
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY VOjtjTVWAgtwruanMaoUlBPyNooP;

		public uint yqseDyCpnFqIVnoRrHaipVnRIGCCb;

		public ulong vrqjVQUtmoatiQtQkPXVVVSrkbhO;

		public uint WMjszInVuTBRgHjeuaAeyWjzoWEo;

		public rKqDlPQafLKAxjfQgfQbCPLJFNmTA yhodZNnnTCFSthMbAFStdwpzXbCjA;

		public int ZUBXisKuEXaLzoXHvOCQwVTLoqrW;
	}

	public struct yrKsHENCotxjHyATqFCwdSUsUAsW
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY CJEhMRrIxVxqEEiHtCuTLHJgCXhg;

		public uint NTiAQCdCIOonNroZVOEaOTeqRaWgb;

		public ulong yEJngeAkPNrEWHKsplILEOMDBMciA;

		public uint aHLylUISxsNyVtEvTKMCxXqzMcAq;

		public byte FQsaJhJpqgzbEXhYjfexjxGryPZoA;

		public byte bkrJrXEbtMyYNlQYKsGhAfjZaBkE;

		public byte lEhHlcYfGzIAvuvAzNdxpwzAuiBM;

		public byte XevVOOrERDMBuegPrIqYhFYPzaap;

		public short tJKLBrTLnqeuiiHHrgOVpXOImYwBA;

		public ushort ofTYMMKpAPMjpoleZHfqHnajYUGRA;

		public void vLBtupVTiAHolCZQelGWvXcSzenD(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			CJEhMRrIxVxqEEiHtCuTLHJgCXhg = P_0;
			yEJngeAkPNrEWHKsplILEOMDBMciA = P_1;
			aHLylUISxsNyVtEvTKMCxXqzMcAq = (uint)Marshal.ReadInt32(P_2, 16);
			FQsaJhJpqgzbEXhYjfexjxGryPZoA = Marshal.ReadByte(P_2, 20);
			tJKLBrTLnqeuiiHHrgOVpXOImYwBA = Marshal.ReadInt16(P_2, 24);
		}
	}

	public struct cxbxRuDqZxEKatrrguTOSUAZCobB
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY QcXBFSCcPbmxWwVuHOsfYDFGCzBj;

		public uint KXMUeXohbLyeCXSrxSAvKptYaImHA;

		public ulong UBSetHFMxaavCoISZEunzslYMqZS;

		public uint YpJdtCdOILbMxhFvJcopcWFXNPdOB;

		public byte BtPhypzDBTuegKWoWIcwcqwDYSfU;

		public bool vuuaijXxZixZaBjdhTjElytqHTsr;

		public byte dUoghtFqCrRMhFbVqEZuAbMWxTJUA;

		public byte FwJUcjxxVVFTulTqqrmGCBdAcAxm;

		public void pfliKZsThmVIvnSBizzORCJpqcRh(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			QcXBFSCcPbmxWwVuHOsfYDFGCzBj = P_0;
			UBSetHFMxaavCoISZEunzslYMqZS = P_1;
			YpJdtCdOILbMxhFvJcopcWFXNPdOB = (uint)Marshal.ReadInt32(P_2, 16);
			BtPhypzDBTuegKWoWIcwcqwDYSfU = Marshal.ReadByte(P_2, 20);
			vuuaijXxZixZaBjdhTjElytqHTsr = Marshal.ReadByte(P_2, 21) > 0;
		}
	}

	public struct hSQawAHNEYBBHjowSErncAJAhUXwA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY dMsaxdDXWNgnCipDoIrVgIajEzliA;

		public uint yoxYaglamRjgfUJWjXxiGDjpWbRV;

		public ulong pXfaGOBVxyDWprswDnjZEiqoraUY;

		public uint YRHkdXLqrFgyXTaUtmqyWdCQfbKN;

		public void koCcbXTLQICytoSutRlxrAFEzMIC(cJhHdMCGFpZnVrLUjglfYcitgPUY P_0, ulong P_1, IntPtr P_2)
		{
			dMsaxdDXWNgnCipDoIrVgIajEzliA = P_0;
			pXfaGOBVxyDWprswDnjZEiqoraUY = P_1;
			YRHkdXLqrFgyXTaUtmqyWdCQfbKN = (uint)Marshal.ReadInt32(P_2, 16);
		}
	}

	public struct xRBmwwEtInWAGHgiUVSjyMjwIqXDA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY YJJfKsqTbLXGisOjeXippHMrDYAE;

		public uint wtebhNmwoyvaQgqurQqVnOqiWroX;

		public ulong XjMpEGjdViesDkDnzOVRUQKGsliqA;

		public uint HZcnGgTMGnUGtPcISbFaaQcmWihrA;

		public int hnDLXgviiBWreJNdEDTWkFBFBVSCb;

		public int YuqgmfjZTWLzuOiRRWZyBbzdKLjDb;

		public float DVUegUGZLmefxvmcUWoPeqZYdPh;

		public float EwOvqIIBxjKzZbxaRhQrUGlDaDviA;

		public float egcPkIXtzdQAUAkKwAwPImHTgsyF;
	}

	public struct zHkxqsMocrARWnaZxfFEsHSansDX
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY bIZsTYUTJbPBBKGxVnNnPXjCsXyM;

		public uint sDgceojQGdodDZcwuCJXDHMKSsJsB;

		public ulong WmOqxNCMyJsFmAxcLadkdeWKDjrt;

		public uint lzDdJWGsGaNBnGoSDCEdVsQqNoZPB;

		public int rFaigglVgDyFAUtHOruAvLCNWUze;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public float[] TXsnwPoziQdUudJiyANKrJkovpDB;

		public ulong TzrCPPVAqIzixeHcFCTjIjtHerFbb;
	}

	public struct QOdhxvkyjdUzcDxfkoEcvpsfHbrU
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY xzZDHtNiYPTQxbqiRKVzBJHhazzy;

		public uint YSZsWXOvsQBSaArDyNqNSJpRLoc;

		public ulong uRdAMKVlOGRzEBfgscucffRJUDGR;

		public uint BykzsfhysPlhugMjBqgHRbEUodfO;

		public bool PFEAvLbJZcySOpXuLgwKkzcWwvBN;

		public byte NIszSfBgmixyKwUWOHzyuitlPKmr;

		public byte lQhdKJwdEzHAoFOthzdmpWcGsTbpA;

		public byte OfcZucUVmriSdagSKmrzNiGnRSV;
	}

	public struct LVQJqwXDQLFhQjqXpuVquNMIcuhfb
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY KxdDALpIXyuVscQrPgbsFOYoxcDIA;

		public uint CsgGpQaUBAufOzRGkfEmZpjPEDJJA;

		public ulong SddJDhMMdFGNmIrmLSsdlqwkwJsd;

		public uint cOaRqGUutdymoYsByTBCCvvWwkff;
	}

	public struct EeAVUSPvqnSJmHPnywmQfuwHvBKm
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY kPapASgBZEdFuGuanjcwMLGiVCRwA;

		public uint faylPnknqBAQHKLjIFOFOpoIdeRSA;

		public ulong cANAvRBkbFluLpYQpUzgdoqNZkZOA;

		public uint SigiQhkezotpUBJqtbtqcdpIrftt;
	}

	public struct arfpnrSgXTqufyWrZEstiGLrRRvv
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY SUHBnFaxOnyrjLLiRGRcfXWHKMpTB;

		public uint pYzHTTPrIXQBnhqQGbfdAeeFDNyjb;

		public ulong AijFFsbEGYkrJxIjQBAnGPTGMJphB;

		public long ObNFAaJfdzzbhsHbnaDjMcigUeNhA;

		public ulong pnRSfpTCsIDGFWfkStZDgCXXXFwe;

		public float YLbTMcNrRRehNBUcgnTnmQaTBcRib;

		public float zJRGDqDNOAQpfDBIwEmRfNetYHqI;

		public float jMsgHHfqpTabxjWNUdIcINljNfZbB;

		public float pCegUejCiBxVEXUXNledohFTBqQX;

		public float xMLcSYMWFrJfSbJrQXuxLukYpylc;

		public uint yRUWwTpdkNDadETFwokfqePMsMybA;
	}

	public struct EZGYJbFGcjgmUQszZDZFynqznoQy
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY fpsPzWGWlNPGAwsGESqHFNwfUACC;

		public uint hKLFbQJSpUZeDBQzDHftDMrQwPHpA;

		public ulong UJlAdakKXCzQHEqbsfnNcMlStHVP;

		public float PFCCHJWgXWKweVYaLCTJUVdaJXKE;

		public uint PlOgcEoXzmAIoDcPWOLxiXmWQIDVA;
	}

	public struct OwDAAuKhtJmcwCMkEwEzfOehtQJCc
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY ZHykcnYOLbOSUBVESsNbIQCmoXhg;

		public uint uHNuNciMimIHqjIRLFoPiqoIjTbOA;

		public ulong MeOQVHvJJDpRDxKUCTPDWqeygWRM;

		public uint vqYoOmVnJZueaPnZbnkTNvxuWLvF;

		public uint erefdxoAwhqnaGYegEVjHkZCbrvcA;
	}

	public struct AYAMGfapXayToeesAXuSxxhRLMrv
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY pSlBqdZRnrqWNkcGYxSzjCPXCkwcA;

		public uint QMIFByjEuZdxaWBJpAovUUsrpxcKA;

		public ulong GcmHjTvSWWINVircRFQZbBEoAGAKA;

		public uint vNjzZueiCmZCjRrbZtHfYDKEmKcL;

		public uint CtDbMDiQodDQgdtHBwzEysktOUBs;

		public ONlGaEaISAAiRGfjXmMvjNRfhzpPc NBgBcjsrFGNtVNHTleTXfUIZNHxIA;

		public float BShiZEhyvXRUCYxXAmZdFLmHtPfU;

		public float xqvQtLpVqsdYzIgMFLRqfNehJKde;
	}

	public struct TtWxtmXriVrxZJfnpdqKaSmHsuFh
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY SSunIIGWADiEagaDlMFeprlnvmvt;

		public uint UOnEfYdSIQqRHJwAtMOIAcrkTsbM;

		public ulong yncDFjTyyjjoucrGhkKwmQoyjfSQ;

		public uint TRmLaWGeFZEAMRGVRsJsTpeAeGSK;

		public uint XuSxlSGnPCAUpMgZqElvnREHRSYL;

		public ONlGaEaISAAiRGfjXmMvjNRfhzpPc FOtVJYhbBjXhSASxzCJnxKMYGfjcA;

		public float jpAHJKZZpPQEfVRljJtOUYooNosd;

		public float hGWDoMAfHpkMFNNQnEWIMLFfchpf;

		public bool cQbtHCywkDDiVoPBNcwCeUBZYqSy;

		public bool ADTJscHphjytnAKvarEJrARtcpbm;
	}

	public struct eCQBkHCRdzUOevmKGtNkotNgiXRGb
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY IWxXzgVVwBfGHqkbJanBrwEsLOwf;

		public uint gocbWAviWCzzIivqyaNzjkUexJzx;

		public ulong kVcJWljwbhpNESCjVnXSYhDlpyiA;

		public uint SbFDSeIJsbluxboPYIkJxskIiMVd;

		public uint DfZBhZmVePojVOBhbQKSDiMfxhQA;

		public ONlGaEaISAAiRGfjXmMvjNRfhzpPc HBumrUoWhZNXEOFTpjyIzMSXQWTI;

		public float yMQtSiylSLWeoCdzlgVsxEQEJPxq;

		public float yUnNmyZeDyyivOeeQcVmrdoahOFr;

		public byte rRjRWfhdtcOHqpIDIdLYsYUejrYO;

		public bool PojooHyiQsSMiiDAblOVUSjZAutN;
	}

	public struct TpyzziWKaYkENyxzLuYKrdEyhpHjA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY VbRRfQTsavRfGdamssLDwPJnCasu;

		public uint JebPtsbMUnRdAQzWthOqXGiAafdcA;

		public ulong KZLrjegRusGhrwQyNSCghJYAwMIH;

		public uint lLQCqMnptJhHCAOCrgkbLJpYGIraA;

		public uint VaflwKfLjrSEmpouYKQpKtOfvhtp;

		public ONlGaEaISAAiRGfjXmMvjNRfhzpPc ENSnPipeHhsOlffOXrNYkIhYWQpr;

		public float MoKDKVOiMcmGiiFPldxLEFvItGKD;

		public float AJJFSzlOmsLQxrVbLVeLIYGULgBt;

		public dspHJVYAHVpiKoGdtALtpxYWaRAY OZbUOXxEpFBBDDOscfwACGmzApczA;

		public float LuHpddvzleKuoogKgmMqNulDwNHD;
	}

	public struct xuzyGPLMmXEshsGVPQhjooneIlkd
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY RJgvjJPFiAUVprYGcxkOtcHzumiL;

		public uint gFGxLRpDgbjdqGaBqePAxjiiTlEY;

		public ulong lBVJBarTiNJKKAcJjzqFXXTtGBau;

		public uint pLlzvrEqLqGZpdIlHAAdJqovGiOFA;

		public float JnbPcKtWvjoSYhvgMEStVeZWHkdc;

		public float SEeUGcOHWpKdpgjVcSSQtlAmtjku;

		public IntPtr HdAWWTaHmnvPrqniutgBDfpIJyku;

		public IntPtr lLhEKveURoFSKXAWgSOylNZMkXBHA;
	}

	public struct KPwZhWQlbEfZufUriTCZhMPGdXOE
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY cWVaHGiMwDVrUsisMvlFwMqRnZjU;

		public uint MfnPFofmwVdEGJfMpsmRBmXokGQbb;

		public ulong xKtYthAnKzFSWMRktMwXVSQdMiVj;

		public bool LJZEXJlXhhgUdKozcrgqSaBRFtrq;

		public int sGkxdUSwSQovbGdUUOXjgKYanPxI;

		public IntPtr yZKvwZVkwgqFTNzDrJwGJfjhgUOv;
	}

	public struct RaueCfgEqJZDMmZaMJbigQHKpQev
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY nPZlttirfLvYBxLHWALzrKihERnP;

		public uint pDcgsMBrZvEPySoMNqBFVDBvZZcIA;

		public ulong jseTbEwNztHTrTFSERQGIQhvdZtf;

		public uint KrIXDyVXvEgVDmKmVNqTVeNJEBkN;

		public float tRGafmkLhiMNsLkHIpRmLQOJACdp;

		public float usYRDCYoTznUzsmxmkSNzlPSBZEV;

		public float PSrcRTAvdIgfpirIVRhLCcaLKumab;

		public float lsYewVOmWauvsSSOsHSToUaImTAG;

		public float aXSsnRGCPKxbyiVdnfaCmQyfjZzK;

		public float DQtlbHFDTgPpaeWqpMufBoaLKDuc;

		public ulong ejsAKIibAFczsOMWnajCzWwtBEFxA;
	}

	public struct RFFKtaqAzHUvlgqFBFRCFmjdzlRjA
	{
		public cJhHdMCGFpZnVrLUjglfYcitgPUY cUVrcWSfIeiklbmbzEXWakqddoHR;

		public uint vEYetCDOJYiMLeKsVljYBMyNSjSJA;

		public ulong qVvMwgDLaBLEnYZCGCgKsVsxJAXc;
	}

	public struct zvnSiczZSXkKotWMUbgPIcmhNSZx
	{
		public uint rYNtHHFBZlXQfssRhRnNyVgMkzBV;

		public uint qNpvuGZgQdYwWxNEfgcYqlgkVBly;

		public ulong WjiUYNhtceTvrUHDGnzlKUpCvyuO;

		public uint PdctbvmTzWvoJxTFhuUjascecDgE;

		public int yJzwMdbIKPZDRsTCsKkLVkQrKJPN;

		public IntPtr ADWpEyviMkiEOfDfCiYxxtTitOXJ;

		public IntPtr jSEVEHQbWmmLKOXKbtSYluqOMgzy;
	}

	public struct jrOXKvmxVSNAXCtMxUHPQibkIkNe
	{
		private static int? MFBHBlbYglEqIcecJRvOzZWrmhVJB;

		public cJhHdMCGFpZnVrLUjglfYcitgPUY gnHaUxSKuyLCqSvQoIPUZjOHejMEA;

		public fwklKkKokRzjnEYMfCpdkRxVcXaD esLztELPvFiUuYgnlwMhwXkwWeGI;

		public OqzTEfMgOGbQoTnhYsbRBNPlwWCR gpXJoScQjfZKQfxLYfTitghtLixb;

		public MuqDKfuVVRFbEzdYzcQTvJcdDzSV AUjQXZxGLtbZtZhIhSHKwGxPKfIH;

		public oTptegxYSswbozHXmavJcdvsYmVb foItyVRyjtSfkpjtGFchwadQkBub;

		public xvgePFPOsFtIIlDTjfltkPemtXZQA hKCiSsFajApVXtQhjbjOcQwYtAwv;

		public nUUbTuaXcDyxibeuuTAyOleMjJGYA aTacAZEirLbWKPFYzUVKGbUfEOwIA;

		public PSaOVGAXbLDPycfbFWimRCOmOcnL tLWQglVUSmmTbxFIXfAtHYCGJqlq;

		public UqlqRzjFGjRGfkyCcIdpNDiAIlvQ kXmcApdRFFTPavWmhcXhdZxCwNPbA;

		public bDlwyLjwoBoYCVpMqOPAeEqPoXwt XLfpurjbwezADWsUESFlpucRlBvQ;

		public deqfcsHveBdnJwJWQAdGZMorbAzM wfZcrWdkWEKvxSGnsBDofaYfGLelA;

		public nlmaeVxGKTCztVccwfHWJdNvTGhkA vwtgKHnBgmgIXMPxvGrkLbEqxVIA;

		public DnMGjchUdlxXpfzZhXcbrWvPMThuA lAPCdFmMldeomfclIEiJIdtHUDmPb;

		public baOlxHoNmARXmTdiFWvcXIlwKhml VLGIejdlITxupuoLjKExTBiNBQce;

		public yQJEMlmMhtNqHLGYvefFEJpNAUbrA nbygCcLlBVIhAQkheILGbTTKHffC;

		public vOhKbcnMhKrsIyaSqcZPexMpZjLxA foWdnCasrSPhMRmWnvqJISYaegsy;

		public PpiubwNfAtDLNReyxBVjDzwOQTbA yfhAoNlZJBftuqMUHoUIQVIquYuI;

		public MUmgZITDTnkpecACRXAWNbyLqoUh IKPYBqlTeLaOWflYvOWXeRXHtLfc;

		public imvhBLhgMaIsdnolZuYjSOjHHhjo jqguoEpLVhQrWAGGJgtTfmpTvAZpA;

		public hSQawAHNEYBBHjowSErncAJAhUXwA feFzqUnaGKvpjzzgYIfXoZRrTatn;

		public yrKsHENCotxjHyATqFCwdSUsUAsW SeorunZGJXCLMkaXOBZyNaugtzSn;

		public cxbxRuDqZxEKatrrguTOSUAZCobB VIVUCxHmRPBuQOMGZRowutlENubN;

		public xRBmwwEtInWAGHgiUVSjyMjwIqXDA aqPwHJNPYtAMaQWlAMCgbsaUhYgf;

		public zHkxqsMocrARWnaZxfFEsHSansDX ZCjapRbvoanUMqysiakAAVgeLAQeB;

		public QOdhxvkyjdUzcDxfkoEcvpsfHbrU piABrQEhOekTcaLRZmqObVTetaZkB;

		public LVQJqwXDQLFhQjqXpuVquNMIcuhfb hWwWwDDmJyLvBMzteICgsIcnrJtL;

		public RaueCfgEqJZDMmZaMJbigQHKpQev nbnHHsPomKjKotcdpAylIhmMnmrr;

		public RFFKtaqAzHUvlgqFBFRCFmjdzlRjA kiIEpDjYOkVpvkIPronPnrPNDrMWA;

		public zvnSiczZSXkKotWMUbgPIcmhNSZx tDwYfwJKaWmvzPGGttPegZUXxxlm;

		public arfpnrSgXTqufyWrZEstiGLrRRvv wiWmpzfjtnuzyEBvXsghNjPjFXIo;

		public EZGYJbFGcjgmUQszZDZFynqznoQy sHEsCCaMvQXOBgiHgcZdIluVpWps;

		public OwDAAuKhtJmcwCMkEwEzfOehtQJCc rpgrMBRmGECvZKcPAAUpuMHAZdCq;

		public TtWxtmXriVrxZJfnpdqKaSmHsuFh EYccDCImkFoIVUyVNPZgYdmNGzMK;

		public AYAMGfapXayToeesAXuSxxhRLMrv JlLSAOmlhDloYuecrMVXyhnHbtMJA;

		public eCQBkHCRdzUOevmKGtNkotNgiXRGb MiYEAqqkermEWCHOAxFSBOtfWhBC;

		public TpyzziWKaYkENyxzLuYKrdEyhpHjA CmrhhonMZrdRpmgGTAUoaJJXHBRpA;

		public EeAVUSPvqnSJmHPnywmQfuwHvBKm FBXFpGckxtAjtPhvFQkeamLcfkpZB;

		public xuzyGPLMmXEshsGVPQhjooneIlkd SJwfEIzgvHZBnqvteugGZdsaewiv;

		public KPwZhWQlbEfZufUriTCZhMPGdXOE DQAvYJlDtypBQLdidMXfevdWKwlg;

		public ulong bANVFQPtBnOJCKHnjAkBnJhfzIxb;

		public ulong YnyZYTTeHwHLZpkciMgZiYtCTlmh;

		public static int uNhRJkRZcRVUIXUbBPSbQlACsmQB
		{
			get
			{
				if (!MFBHBlbYglEqIcecJRvOzZWrmhVJB.HasValue)
				{
					MFBHBlbYglEqIcecJRvOzZWrmhVJB = Marshal.SizeOf(typeof(jrOXKvmxVSNAXCtMxUHPQibkIkNe));
				}
				return MFBHBlbYglEqIcecJRvOzZWrmhVJB.Value;
			}
		}

		public void BvInkoCaSPYIbhsmliOsMcwBMsDA(IntPtr P_0)
		{
			gnHaUxSKuyLCqSvQoIPUZjOHejMEA = (cJhHdMCGFpZnVrLUjglfYcitgPUY)Marshal.ReadInt32(P_0, 0);
			uint num = (uint)Marshal.ReadInt32(P_0, 0);
			switch (gnHaUxSKuyLCqSvQoIPUZjOHejMEA)
			{
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_AXIS_MOTION:
				nbygCcLlBVIhAQkheILGbTTKHffC.aFWwfcgZdTqgGpdePFhyAZsEjNHjA(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BUTTON_DOWN:
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BUTTON_UP:
				IKPYBqlTeLaOWflYvOWXeRXHtLfc.yyLwKWxglKuIbVAdzUrXIzAvMzHP(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_BALL_MOTION:
				foWdnCasrSPhMRmWnvqJISYaegsy.QymRdTfluGPgPHNJINTVFbIoDkvQ(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_HAT_MOTION:
				yfhAoNlZJBftuqMUHoUIQVIquYuI.MWzMUokRGbgqDdgIhrsweERepQgb(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_ADDED:
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_JOYSTICK_REMOVED:
				VLGIejdlITxupuoLjKExTBiNBQce.dqreQFUTppItSRmhppGuUGfTPWuN(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_AXIS_MOTION:
				SeorunZGJXCLMkaXOBZyNaugtzSn.vLBtupVTiAHolCZQelGWvXcSzenD(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_BUTTON_DOWN:
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_BUTTON_UP:
				VIVUCxHmRPBuQOMGZRowutlENubN.pfliKZsThmVIvnSBizzORCJpqcRh(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_ADDED:
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_REMOVED:
			case cJhHdMCGFpZnVrLUjglfYcitgPUY.SDL_EVENT_GAMEPAD_REMAPPED:
				feFzqUnaGKvpjzzgYIfXoZRrTatn.koCcbXTLQICytoSutRlxrAFEzMIC(gnHaUxSKuyLCqSvQoIPUZjOHejMEA, num, P_0);
				break;
			}
		}
	}

	public enum iydMKbzCSEkRTyYpUVlwRAlImugr
	{
		SDL_SCANCODE_UNKNOWN = 0,
		SDL_SCANCODE_A = 4,
		SDL_SCANCODE_B = 5,
		SDL_SCANCODE_C = 6,
		SDL_SCANCODE_D = 7,
		SDL_SCANCODE_E = 8,
		SDL_SCANCODE_F = 9,
		SDL_SCANCODE_G = 10,
		SDL_SCANCODE_H = 11,
		SDL_SCANCODE_I = 12,
		SDL_SCANCODE_J = 13,
		SDL_SCANCODE_K = 14,
		SDL_SCANCODE_L = 15,
		SDL_SCANCODE_M = 16,
		SDL_SCANCODE_N = 17,
		SDL_SCANCODE_O = 18,
		SDL_SCANCODE_P = 19,
		SDL_SCANCODE_Q = 20,
		SDL_SCANCODE_R = 21,
		SDL_SCANCODE_S = 22,
		SDL_SCANCODE_T = 23,
		SDL_SCANCODE_U = 24,
		SDL_SCANCODE_V = 25,
		SDL_SCANCODE_W = 26,
		SDL_SCANCODE_X = 27,
		SDL_SCANCODE_Y = 28,
		SDL_SCANCODE_Z = 29,
		SDL_SCANCODE_1 = 30,
		SDL_SCANCODE_2 = 31,
		SDL_SCANCODE_3 = 32,
		SDL_SCANCODE_4 = 33,
		SDL_SCANCODE_5 = 34,
		SDL_SCANCODE_6 = 35,
		SDL_SCANCODE_7 = 36,
		SDL_SCANCODE_8 = 37,
		SDL_SCANCODE_9 = 38,
		SDL_SCANCODE_0 = 39,
		SDL_SCANCODE_RETURN = 40,
		SDL_SCANCODE_ESCAPE = 41,
		SDL_SCANCODE_BACKSPACE = 42,
		SDL_SCANCODE_TAB = 43,
		SDL_SCANCODE_SPACE = 44,
		SDL_SCANCODE_MINUS = 45,
		SDL_SCANCODE_EQUALS = 46,
		SDL_SCANCODE_LEFTBRACKET = 47,
		SDL_SCANCODE_RIGHTBRACKET = 48,
		SDL_SCANCODE_BACKSLASH = 49,
		SDL_SCANCODE_NONUSHASH = 50,
		SDL_SCANCODE_SEMICOLON = 51,
		SDL_SCANCODE_APOSTROPHE = 52,
		SDL_SCANCODE_GRAVE = 53,
		SDL_SCANCODE_COMMA = 54,
		SDL_SCANCODE_PERIOD = 55,
		SDL_SCANCODE_SLASH = 56,
		SDL_SCANCODE_CAPSLOCK = 57,
		SDL_SCANCODE_F1 = 58,
		SDL_SCANCODE_F2 = 59,
		SDL_SCANCODE_F3 = 60,
		SDL_SCANCODE_F4 = 61,
		SDL_SCANCODE_F5 = 62,
		SDL_SCANCODE_F6 = 63,
		SDL_SCANCODE_F7 = 64,
		SDL_SCANCODE_F8 = 65,
		SDL_SCANCODE_F9 = 66,
		SDL_SCANCODE_F10 = 67,
		SDL_SCANCODE_F11 = 68,
		SDL_SCANCODE_F12 = 69,
		SDL_SCANCODE_PRINTSCREEN = 70,
		SDL_SCANCODE_SCROLLLOCK = 71,
		SDL_SCANCODE_PAUSE = 72,
		SDL_SCANCODE_INSERT = 73,
		SDL_SCANCODE_HOME = 74,
		SDL_SCANCODE_PAGEUP = 75,
		SDL_SCANCODE_DELETE = 76,
		SDL_SCANCODE_END = 77,
		SDL_SCANCODE_PAGEDOWN = 78,
		SDL_SCANCODE_RIGHT = 79,
		SDL_SCANCODE_LEFT = 80,
		SDL_SCANCODE_DOWN = 81,
		SDL_SCANCODE_UP = 82,
		SDL_SCANCODE_NUMLOCKCLEAR = 83,
		SDL_SCANCODE_KP_DIVIDE = 84,
		SDL_SCANCODE_KP_MULTIPLY = 85,
		SDL_SCANCODE_KP_MINUS = 86,
		SDL_SCANCODE_KP_PLUS = 87,
		SDL_SCANCODE_KP_ENTER = 88,
		SDL_SCANCODE_KP_1 = 89,
		SDL_SCANCODE_KP_2 = 90,
		SDL_SCANCODE_KP_3 = 91,
		SDL_SCANCODE_KP_4 = 92,
		SDL_SCANCODE_KP_5 = 93,
		SDL_SCANCODE_KP_6 = 94,
		SDL_SCANCODE_KP_7 = 95,
		SDL_SCANCODE_KP_8 = 96,
		SDL_SCANCODE_KP_9 = 97,
		SDL_SCANCODE_KP_0 = 98,
		SDL_SCANCODE_KP_PERIOD = 99,
		SDL_SCANCODE_NONUSBACKSLASH = 100,
		SDL_SCANCODE_APPLICATION = 101,
		SDL_SCANCODE_POWER = 102,
		SDL_SCANCODE_KP_EQUALS = 103,
		SDL_SCANCODE_F13 = 104,
		SDL_SCANCODE_F14 = 105,
		SDL_SCANCODE_F15 = 106,
		SDL_SCANCODE_F16 = 107,
		SDL_SCANCODE_F17 = 108,
		SDL_SCANCODE_F18 = 109,
		SDL_SCANCODE_F19 = 110,
		SDL_SCANCODE_F20 = 111,
		SDL_SCANCODE_F21 = 112,
		SDL_SCANCODE_F22 = 113,
		SDL_SCANCODE_F23 = 114,
		SDL_SCANCODE_F24 = 115,
		SDL_SCANCODE_EXECUTE = 116,
		SDL_SCANCODE_HELP = 117,
		SDL_SCANCODE_MENU = 118,
		SDL_SCANCODE_SELECT = 119,
		SDL_SCANCODE_STOP = 120,
		SDL_SCANCODE_AGAIN = 121,
		SDL_SCANCODE_UNDO = 122,
		SDL_SCANCODE_CUT = 123,
		SDL_SCANCODE_COPY = 124,
		SDL_SCANCODE_PASTE = 125,
		SDL_SCANCODE_FIND = 126,
		SDL_SCANCODE_MUTE = 127,
		SDL_SCANCODE_VOLUMEUP = 128,
		SDL_SCANCODE_VOLUMEDOWN = 129,
		SDL_SCANCODE_KP_COMMA = 133,
		SDL_SCANCODE_KP_EQUALSAS400 = 134,
		SDL_SCANCODE_INTERNATIONAL1 = 135,
		SDL_SCANCODE_INTERNATIONAL2 = 136,
		SDL_SCANCODE_INTERNATIONAL3 = 137,
		SDL_SCANCODE_INTERNATIONAL4 = 138,
		SDL_SCANCODE_INTERNATIONAL5 = 139,
		SDL_SCANCODE_INTERNATIONAL6 = 140,
		SDL_SCANCODE_INTERNATIONAL7 = 141,
		SDL_SCANCODE_INTERNATIONAL8 = 142,
		SDL_SCANCODE_INTERNATIONAL9 = 143,
		SDL_SCANCODE_LANG1 = 144,
		SDL_SCANCODE_LANG2 = 145,
		SDL_SCANCODE_LANG3 = 146,
		SDL_SCANCODE_LANG4 = 147,
		SDL_SCANCODE_LANG5 = 148,
		SDL_SCANCODE_LANG6 = 149,
		SDL_SCANCODE_LANG7 = 150,
		SDL_SCANCODE_LANG8 = 151,
		SDL_SCANCODE_LANG9 = 152,
		SDL_SCANCODE_ALTERASE = 153,
		SDL_SCANCODE_SYSREQ = 154,
		SDL_SCANCODE_CANCEL = 155,
		SDL_SCANCODE_CLEAR = 156,
		SDL_SCANCODE_PRIOR = 157,
		SDL_SCANCODE_RETURN2 = 158,
		SDL_SCANCODE_SEPARATOR = 159,
		SDL_SCANCODE_OUT = 160,
		SDL_SCANCODE_OPER = 161,
		SDL_SCANCODE_CLEARAGAIN = 162,
		SDL_SCANCODE_CRSEL = 163,
		SDL_SCANCODE_EXSEL = 164,
		SDL_SCANCODE_KP_00 = 176,
		SDL_SCANCODE_KP_000 = 177,
		SDL_SCANCODE_THOUSANDSSEPARATOR = 178,
		SDL_SCANCODE_DECIMALSEPARATOR = 179,
		SDL_SCANCODE_CURRENCYUNIT = 180,
		SDL_SCANCODE_CURRENCYSUBUNIT = 181,
		SDL_SCANCODE_KP_LEFTPAREN = 182,
		SDL_SCANCODE_KP_RIGHTPAREN = 183,
		SDL_SCANCODE_KP_LEFTBRACE = 184,
		SDL_SCANCODE_KP_RIGHTBRACE = 185,
		SDL_SCANCODE_KP_TAB = 186,
		SDL_SCANCODE_KP_BACKSPACE = 187,
		SDL_SCANCODE_KP_A = 188,
		SDL_SCANCODE_KP_B = 189,
		SDL_SCANCODE_KP_C = 190,
		SDL_SCANCODE_KP_D = 191,
		SDL_SCANCODE_KP_E = 192,
		SDL_SCANCODE_KP_F = 193,
		SDL_SCANCODE_KP_XOR = 194,
		SDL_SCANCODE_KP_POWER = 195,
		SDL_SCANCODE_KP_PERCENT = 196,
		SDL_SCANCODE_KP_LESS = 197,
		SDL_SCANCODE_KP_GREATER = 198,
		SDL_SCANCODE_KP_AMPERSAND = 199,
		SDL_SCANCODE_KP_DBLAMPERSAND = 200,
		SDL_SCANCODE_KP_VERTICALBAR = 201,
		SDL_SCANCODE_KP_DBLVERTICALBAR = 202,
		SDL_SCANCODE_KP_COLON = 203,
		SDL_SCANCODE_KP_HASH = 204,
		SDL_SCANCODE_KP_SPACE = 205,
		SDL_SCANCODE_KP_AT = 206,
		SDL_SCANCODE_KP_EXCLAM = 207,
		SDL_SCANCODE_KP_MEMSTORE = 208,
		SDL_SCANCODE_KP_MEMRECALL = 209,
		SDL_SCANCODE_KP_MEMCLEAR = 210,
		SDL_SCANCODE_KP_MEMADD = 211,
		SDL_SCANCODE_KP_MEMSUBTRACT = 212,
		SDL_SCANCODE_KP_MEMMULTIPLY = 213,
		SDL_SCANCODE_KP_MEMDIVIDE = 214,
		SDL_SCANCODE_KP_PLUSMINUS = 215,
		SDL_SCANCODE_KP_CLEAR = 216,
		SDL_SCANCODE_KP_CLEARENTRY = 217,
		SDL_SCANCODE_KP_BINARY = 218,
		SDL_SCANCODE_KP_OCTAL = 219,
		SDL_SCANCODE_KP_DECIMAL = 220,
		SDL_SCANCODE_KP_HEXADECIMAL = 221,
		SDL_SCANCODE_LCTRL = 224,
		SDL_SCANCODE_LSHIFT = 225,
		SDL_SCANCODE_LALT = 226,
		SDL_SCANCODE_LGUI = 227,
		SDL_SCANCODE_RCTRL = 228,
		SDL_SCANCODE_RSHIFT = 229,
		SDL_SCANCODE_RALT = 230,
		SDL_SCANCODE_RGUI = 231,
		SDL_SCANCODE_MODE = 257,
		SDL_SCANCODE_SLEEP = 258,
		SDL_SCANCODE_WAKE = 259,
		SDL_SCANCODE_CHANNEL_INCREMENT = 260,
		SDL_SCANCODE_CHANNEL_DECREMENT = 261,
		SDL_SCANCODE_MEDIA_PLAY = 262,
		SDL_SCANCODE_MEDIA_PAUSE = 263,
		SDL_SCANCODE_MEDIA_RECORD = 264,
		SDL_SCANCODE_MEDIA_FAST_FORWARD = 265,
		SDL_SCANCODE_MEDIA_REWIND = 266,
		SDL_SCANCODE_MEDIA_NEXT_TRACK = 267,
		SDL_SCANCODE_MEDIA_PREVIOUS_TRACK = 268,
		SDL_SCANCODE_MEDIA_STOP = 269,
		SDL_SCANCODE_MEDIA_EJECT = 270,
		SDL_SCANCODE_MEDIA_PLAY_PAUSE = 271,
		SDL_SCANCODE_MEDIA_SELECT = 272,
		SDL_SCANCODE_AC_NEW = 273,
		SDL_SCANCODE_AC_OPEN = 274,
		SDL_SCANCODE_AC_CLOSE = 275,
		SDL_SCANCODE_AC_EXIT = 276,
		SDL_SCANCODE_AC_SAVE = 277,
		SDL_SCANCODE_AC_PRINT = 278,
		SDL_SCANCODE_AC_PROPERTIES = 279,
		SDL_SCANCODE_AC_SEARCH = 280,
		SDL_SCANCODE_AC_HOME = 281,
		SDL_SCANCODE_AC_BACK = 282,
		SDL_SCANCODE_AC_FORWARD = 283,
		SDL_SCANCODE_AC_STOP = 284,
		SDL_SCANCODE_AC_REFRESH = 285,
		SDL_SCANCODE_AC_BOOKMARKS = 286,
		SDL_SCANCODE_SOFTLEFT = 287,
		SDL_SCANCODE_SOFTRIGHT = 288,
		SDL_SCANCODE_CALL = 289,
		SDL_SCANCODE_ENDCALL = 290,
		SDL_SCANCODE_RESERVED = 400,
		SDL_SCANCODE_COUNT = 512
	}

	public enum wLMxdOBWESOCPvWDBmbAtJjMvcaw
	{
		SDL_MOUSEWHEEL_NORMAL = 0,
		SDL_MOUSEWHEEL_FLIPPED = 1
	}

	public enum DnCFVvvmErGHnZSLOgWMEXbxVJWp
	{
		SDL_BUTTON_LEFT = 1,
		SDL_BUTTON_MIDDLE = 2,
		SDL_BUTTON_RIGHT = 3,
		SDL_BUTTON_X1 = 4,
		SDL_BUTTON_X2 = 5
	}

	public enum ONlGaEaISAAiRGfjXmMvjNRfhzpPc : uint
	{
		SDL_PEN_INPUT_DOWN = 1u,
		SDL_PEN_INPUT_BUTTON_1 = 2u,
		SDL_PEN_INPUT_BUTTON_2 = 4u,
		SDL_PEN_INPUT_BUTTON_3 = 8u,
		SDL_PEN_INPUT_BUTTON_4 = 0x10u,
		SDL_PEN_INPUT_BUTTON_5 = 0x20u,
		SDL_PEN_INPUT_ERASER_TIP = 0x40000000u,
		SDL_PEN_INPUT_IN_PROXIMITY = 0x80000000u
	}

	public enum dspHJVYAHVpiKoGdtALtpxYWaRAY
	{
		SDL_PEN_AXIS_PRESSURE = 0,
		SDL_PEN_AXIS_XTILT = 1,
		SDL_PEN_AXIS_YTILT = 2,
		SDL_PEN_AXIS_DISTANCE = 3,
		SDL_PEN_AXIS_ROTATION = 4,
		SDL_PEN_AXIS_SLIDER = 5,
		SDL_PEN_AXIS_TANGENTIAL_PRESSURE = 6,
		SDL_PEN_AXIS_COUNT = 7
	}

	public enum rKqDlPQafLKAxjfQgfQbCPLJFNmTA
	{
		SDL_POWERSTATE_ERROR = -1,
		SDL_POWERSTATE_UNKNOWN = 0,
		SDL_POWERSTATE_ON_BATTERY = 1,
		SDL_POWERSTATE_NO_BATTERY = 2,
		SDL_POWERSTATE_CHARGING = 3,
		SDL_POWERSTATE_CHARGED = 4
	}

	[Flags]
	public enum KnzDMmrpoILXSLSLoVSsRowSzgwh : uint
	{
		None = 0u,
		SDL_HAPTIC_CONSTANT = 1u,
		SDL_HAPTIC_SINE = 2u,
		SDL_HAPTIC_SQUARE = 4u,
		SDL_HAPTIC_TRIANGLE = 8u,
		SDL_HAPTIC_SAWTOOTHUP = 0x10u,
		SDL_HAPTIC_SAWTOOTHDOWN = 0x20u,
		SDL_HAPTIC_RAMP = 0x40u,
		SDL_HAPTIC_SPRING = 0x80u,
		SDL_HAPTIC_DAMPER = 0x100u,
		SDL_HAPTIC_INERTIA = 0x200u,
		SDL_HAPTIC_FRICTION = 0x400u,
		SDL_HAPTIC_LEFTRIGHT = 0x800u,
		SDL_HAPTIC_RESERVED1 = 0x1000u,
		SDL_HAPTIC_RESERVED2 = 0x2000u,
		SDL_HAPTIC_RESERVED3 = 0x4000u,
		SDL_HAPTIC_CUSTOM = 0x8000u,
		SDL_HAPTIC_GAIN = 0x10000u,
		SDL_HAPTIC_AUTOCENTER = 0x20000u,
		SDL_HAPTIC_STATUS = 0x40000u,
		SDL_HAPTIC_PAUSE = 0x80000u
	}

	public enum jtcSqbwgCEsJjOXvwLEMiEUWymMB
	{
		SDL_PROPERTY_TYPE_INVALID = 0,
		SDL_PROPERTY_TYPE_POINTER = 1,
		SDL_PROPERTY_TYPE_STRING = 2,
		SDL_PROPERTY_TYPE_NUMBER = 3,
		SDL_PROPERTY_TYPE_FLOAT = 4,
		SDL_PROPERTY_TYPE_BOOLEAN = 5
	}

	public enum oqFcrYhAiDGBXHnvJNgjicZUVnpjb
	{
		SDL_GAMEPAD_TYPE_UNKNOWN = 0,
		SDL_GAMEPAD_TYPE_STANDARD = 1,
		SDL_GAMEPAD_TYPE_XBOX360 = 2,
		SDL_GAMEPAD_TYPE_XBOXONE = 3,
		SDL_GAMEPAD_TYPE_PS3 = 4,
		SDL_GAMEPAD_TYPE_PS4 = 5,
		SDL_GAMEPAD_TYPE_PS5 = 6,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_PRO = 7,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_LEFT = 8,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT = 9,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_PAIR = 10,
		SDL_GAMEPAD_TYPE_GAMECUBE = 11,
		SDL_GAMEPAD_TYPE_COUNT = 12
	}

	public enum AxgFQhfotfIXKYJWlfgsPlrkPOx
	{
		SDL_GAMEPAD_BUTTON_INVALID = -1,
		SDL_GAMEPAD_BUTTON_SOUTH = 0,
		SDL_GAMEPAD_BUTTON_EAST = 1,
		SDL_GAMEPAD_BUTTON_WEST = 2,
		SDL_GAMEPAD_BUTTON_NORTH = 3,
		SDL_GAMEPAD_BUTTON_BACK = 4,
		SDL_GAMEPAD_BUTTON_GUIDE = 5,
		SDL_GAMEPAD_BUTTON_START = 6,
		SDL_GAMEPAD_BUTTON_LEFT_STICK = 7,
		SDL_GAMEPAD_BUTTON_RIGHT_STICK = 8,
		SDL_GAMEPAD_BUTTON_LEFT_SHOULDER = 9,
		SDL_GAMEPAD_BUTTON_RIGHT_SHOULDER = 10,
		SDL_GAMEPAD_BUTTON_DPAD_UP = 11,
		SDL_GAMEPAD_BUTTON_DPAD_DOWN = 12,
		SDL_GAMEPAD_BUTTON_DPAD_LEFT = 13,
		SDL_GAMEPAD_BUTTON_DPAD_RIGHT = 14,
		SDL_GAMEPAD_BUTTON_MISC1 = 15,
		SDL_GAMEPAD_BUTTON_RIGHT_PADDLE1 = 16,
		SDL_GAMEPAD_BUTTON_LEFT_PADDLE1 = 17,
		SDL_GAMEPAD_BUTTON_RIGHT_PADDLE2 = 18,
		SDL_GAMEPAD_BUTTON_LEFT_PADDLE2 = 19,
		SDL_GAMEPAD_BUTTON_TOUCHPAD = 20,
		SDL_GAMEPAD_BUTTON_MISC2 = 21,
		SDL_GAMEPAD_BUTTON_MISC3 = 22,
		SDL_GAMEPAD_BUTTON_MISC4 = 23,
		SDL_GAMEPAD_BUTTON_MISC5 = 24,
		SDL_GAMEPAD_BUTTON_MISC6 = 25,
		SDL_GAMEPAD_BUTTON_COUNT = 26
	}

	public enum EtRzNUFJAUSbCcCBmfZEkvaozkdE
	{
		SDL_GAMEPAD_BUTTON_LABEL_UNKNOWN = 0,
		SDL_GAMEPAD_BUTTON_LABEL_A = 1,
		SDL_GAMEPAD_BUTTON_LABEL_B = 2,
		SDL_GAMEPAD_BUTTON_LABEL_X = 3,
		SDL_GAMEPAD_BUTTON_LABEL_Y = 4,
		SDL_GAMEPAD_BUTTON_LABEL_CROSS = 5,
		SDL_GAMEPAD_BUTTON_LABEL_CIRCLE = 6,
		SDL_GAMEPAD_BUTTON_LABEL_SQUARE = 7,
		SDL_GAMEPAD_BUTTON_LABEL_TRIANGLE = 8
	}

	public enum foOthQIhsjGsRIrmJOAvDqdyrqNV
	{
		SDL_GAMEPAD_AXIS_INVALID = -1,
		SDL_GAMEPAD_AXIS_LEFTX = 0,
		SDL_GAMEPAD_AXIS_LEFTY = 1,
		SDL_GAMEPAD_AXIS_RIGHTX = 2,
		SDL_GAMEPAD_AXIS_RIGHTY = 3,
		SDL_GAMEPAD_AXIS_LEFT_TRIGGER = 4,
		SDL_GAMEPAD_AXIS_RIGHT_TRIGGER = 5,
		SDL_GAMEPAD_AXIS_COUNT = 6
	}

	public enum vpShnByQRrPevXUOPZwMWXylBHJi
	{
		SDL_GAMEPAD_BINDTYPE_NONE = 0,
		SDL_GAMEPAD_BINDTYPE_BUTTON = 1,
		SDL_GAMEPAD_BINDTYPE_AXIS = 2,
		SDL_GAMEPAD_BINDTYPE_HAT = 3
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct bQeVGeOqwxvuRNDjOyjbhyTJIFBY
	{
		public struct VdZCvMHieFmGzcdRPWuWmFJxSQOoA
		{
			public int rONiyXLIxsQgGKqsEAgiFXWMtkXo;

			public int TprjHILIyFYJcplCpRjJqOkIZoZR;

			public int jQEtYxEndRtIbnimvjPfflCvPNaeA;
		}

		public struct TgaqRlzqRyjruIbiUtZPnMrGVvSU
		{
			public int MlXUWMQDpMlwhLPthLrfWTIqSOZr;

			public int VYjWBtHuPwKScqVEfjKITDZsfSdl;
		}

		public struct SNLMemqeAqtOAKZDgnyuqIljruYy
		{
			public foOthQIhsjGsRIrmJOAvDqdyrqNV sHaewXNJsrTDBhioanESQiErHJNDA;

			public int QtwamHASLXfIjYRkheSyRZZfPBwtA;

			public int RzOBMxGTORPbSoPtNJZfSnpWIzRnA;
		}

		[FieldOffset(0)]
		public vpShnByQRrPevXUOPZwMWXylBHJi sZmWFBuRsSeNoFlBLXjTIjyTzAQh;

		[FieldOffset(4)]
		public int ktNBkflccedzBiMoCKXqdhPfbglXA;

		[FieldOffset(4)]
		public VdZCvMHieFmGzcdRPWuWmFJxSQOoA ECXTsaLJHXeBaZnTtdwfuwvqOThW;

		[FieldOffset(4)]
		public TgaqRlzqRyjruIbiUtZPnMrGVvSU DGHIqqYiJcBdTkAlxYMyUrdkTDfw;

		[FieldOffset(16)]
		public vpShnByQRrPevXUOPZwMWXylBHJi KyJDTNGkfSGDtlpmGBizoMNyPYebb;

		[FieldOffset(20)]
		public AxgFQhfotfIXKYJWlfgsPlrkPOx qmCyRbKVamlDdOCKdzlOamTPNsZM;

		[FieldOffset(20)]
		public SNLMemqeAqtOAKZDgnyuqIljruYy DiAusxKxUmcJmjdtyCcHDWWOLcio;
	}

	private const string aKhQPQPYNunCxpYdlMujGCPCDqhP = "SDL3";

	private const CallingConvention fRqdPXBwQvRcxNdapDLnHdejdVUT = CallingConvention.Cdecl;

	private const CharSet DfPvJBsQksJIhGtDKXXEWMKzGILI = CharSet.Ansi;

	public const string kAfcZyDuZeiVbFMqpTPqEXNQeNPKA = "SDL.joystick.cap.mono_led";

	public const string KVpjYIRpEISpLKRoKfSrYIkdbfTW = "SDL.joystick.cap.rgb_led";

	public const string OXFWfnBSJMwCwIeDLlFpsuxmEETn = "SDL.joystick.cap.player_led";

	public const string LmgjJZOetTQOcRmNWnNJuxDvflIn = "SDL.joystick.cap.rumble";

	public const string FyZtIqrXAKlwryTclFSTWwfPNgDr = "SDL.joystick.cap.trigger_rumble";

	public const string fOgPtySZXetnbZhIVbvXUZoDchwp = "SDL.joystick.cap.mono_led";

	public const string HgsXnNDagMqdyCHGYyljPWLyjliM = "SDL.joystick.cap.rgb_led";

	public const string WIseAiKwfAbDvDFkJoKjPpUPhsleB = "SDL.joystick.cap.player_led";

	public const string GyzHOPjHTHeZmGgAbgyrrIQXDOjF = "SDL.joystick.cap.rumble";

	public const string ztuFZTkVuvjcvPCsYnifCNqTMJeX = "SDL.joystick.cap.trigger_rumble";

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_Init")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sFGuNRGtFNvYZnOnWzhTBzLeGKtD(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_PollEvent")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	public static extern int EbuFExHFxuHNjmbCEgXDtHWnQxRtA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_CloseHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void icMhAPudNhfECtsZRSidUTfGLyaL(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_DestroyHapticEffect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void uueWDYEKvTIPJQolwMUtNWkvlysf(IntPtr P_0, int P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_HapticEffectSupported")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ddRXxEkZqDQGqfgdZiReWmbZVQMC(IntPtr P_0, IntPtr P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetHapticEffectStatus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool tRTFEQcNVMGyEEjMjWNXnVgFjXDnc(IntPtr P_0, int P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetHapticID")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint pVHWOlkdkRhMPGdZQsaKQhIEskPeA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetHapticNameForID")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr IjjfcoOSckAeYdzEtjTptFPefLRuA(int P_0);

	public static string tJzZdHvyQeanCEUBkViHkdMtyJDX(int P_0)
	{
		IntPtr intPtr = IjjfcoOSckAeYdzEtjTptFPefLRuA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_CreateHapticEffect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint nPRnFNuwQDSPDZirKsLoVTUAJDDu(IntPtr P_0, IntPtr P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetNumHapticAxes")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZcTZuwcQYPXYqWxEsfjIakstgwkF(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetMaxHapticEffects")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int eQytudsBUJcmrZwZnFUFLvSSJIYW(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetMaxHapticEffectsPlaying")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int fhZqhOMooBVkKUjOQHpFkqjXjItbA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_OpenHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KqAxsYmBNRmfYphzZbuAYVczgcJe(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_OpenHapticFromJoystick")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr NMOfwovcOatkwmMgXXiVMfVXUhl(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_OpenHapticFromMouse")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KiIFAqDqUmqSmZAeJDJQsaNiQFhl();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_PauseHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool zxeysAXHytJREcOMlyijNwmveGYX(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetHapticFeatures")]
	[SuppressUnmanagedCodeSecurity]
	public static extern KnzDMmrpoILXSLSLoVSsRowSzgwh CCoYpcWvuGAEEemQOPFYAsJkacvG(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_InitHapticRumble")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CDONOOKvPTmUbXOeCpisEHiUJAyf(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_PlayHapticRumble")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool lLjofaMxbtBHoabjktzJiVpBEWUF(IntPtr P_0, float P_1, uint P_2);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_StopHapticRumble")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool xAqaFpDiGsHdaIYobbsRIlvjTNGqD(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_HapticRumbleSupported")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool BGxuFBzLuqmHkAZdTRrmIlhWuMJd(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_RunHapticEffect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool pBZCqVmswWQoGYLUDhhnhYlIiAOU(IntPtr P_0, int P_1, uint P_2);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_SetHapticAutocenter")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool lDqNZHQdlwqfmNmkTItTLEbLBDNjA(IntPtr P_0, int P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_SetHapticGain")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool IxnqNPlDDkqjLDuFkrHzllXudeoh(IntPtr P_0, int P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_StopHapticEffects")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kxXbURUxhFNqwKjczZQVlLwABLvN(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_StopHapticEffect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ipalADEKUCDHUkJyqFfQgKHCRmgSb(IntPtr P_0, int P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_ResumeHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kKpHPZkbkXYbkirSBSEXIOXkFMaE(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_UpdateHapticEffect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool KqJALHRRysyezDMjqpmILUNIwHpN(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_IsJoystickHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool gANjlmDTsQIGzUcZbecVDATzPqgUA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_IsMouseHaptic")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CycAQwSfvqAOoUDSXjNLhufUQrWq();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetHaptics")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern uint* YjWJFjyaCXGzTgTntRzoDqpIxHgU(ref int P_0);

	public unsafe static int gflhzpotpbkEutjKhIsreQNCiuaNA(IList<uint> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		int count = P_0.Count;
		int num = 0;
		uint* ptr = YjWJFjyaCXGzTgTntRzoDqpIxHgU(ref num);
		if (ptr == null)
		{
			return 0;
		}
		for (int i = 0; i < num; i++)
		{
			P_0.Add(ptr[i]);
		}
		SgciYFjVedmZIFtlVzqjYBfvxoJf((IntPtr)ptr);
		return P_0.Count - count;
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_HasProperty")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kVwUsxAkpjmfxXgjhZedVAzpCcwdA(uint P_0, string P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetPropertyType")]
	[SuppressUnmanagedCodeSecurity]
	public static extern jtcSqbwgCEsJjOXvwLEMiEUWymMB jZnhQHyEMIXDdLkjMzNnruWqrbHm(uint P_0, string P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetBooleanProperty")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool OTTnGmEKMPzlKLQIyAxoZhbSlUjU(uint P_0, string P_1, bool P_2);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoysticks")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern uint* biBoglmwEkpDPDepMzejygjtGUGh(ref int P_0);

	public unsafe static int uzkeCnIyobLcOEfNWrelYZdfuIvN(IList<uint> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		int count = P_0.Count;
		int num = 0;
		uint* ptr = biBoglmwEkpDPDepMzejygjtGUGh(ref num);
		if (ptr == null)
		{
			return 0;
		}
		for (int i = 0; i < num; i++)
		{
			P_0.Add(ptr[i]);
		}
		SgciYFjVedmZIFtlVzqjYBfvxoJf((IntPtr)ptr);
		return P_0.Count - count;
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickID")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint uoMimMWgJMUhoMItFBOpgJdOITInA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickName")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr EcblFFxgNpqONnckEAGIcYTObgQg(IntPtr P_0);

	public static string mgxLqapDDQLDKBNoIVzDWjxJMoIi(IntPtr P_0)
	{
		IntPtr intPtr = EcblFFxgNpqONnckEAGIcYTObgQg(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickGUID")]
	[SuppressUnmanagedCodeSecurity]
	public static extern Guid zPSkzKnYrZmBfQvWtHrUmFnqaZZdA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickGUIDForID")]
	[SuppressUnmanagedCodeSecurity]
	public static extern Guid OzMcfIegolxFreLvZTbUvgCegJad(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickProduct")]
	[SuppressUnmanagedCodeSecurity]
	public static extern ushort BmMrBxeQmbGOVjxGkEvKSiiMiPQOA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickVendor")]
	[SuppressUnmanagedCodeSecurity]
	public static extern ushort BwITpFhOTLCoiIDJvlHEzQoKPZlVA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickSerial")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr bDJSAKaCsNcoCGeTxCzOGRSIWQGnB(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickPath")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DieNSvQAMhBwdHHXbROlmRTiYtlo(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetNumJoystickButtons")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ObXgDYxDXCbapgjQQWiWQtKjCtCW(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetNumJoystickAxes")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int NyAuUXyxKhfZjOzqyCdDJVrillzE(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetNumJoystickHats")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int DlKebAjRVloWiYdPJRXemGzwLNOlA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetNumJoystickBalls")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int sbgKdaLDLMkEkGEtOihrnlrnIezX(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetJoystickProperties")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint VVAjxVjsnLFmAnZdCnJvBhOeAyUc(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_OpenJoystick")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr AnHUFEgCGQWFtoHtAHnyPluvoHPm(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_CloseJoystick")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void yWDfbPGYdLfrzekXDjFMEmFOgNwoB(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_JoystickConnected")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool bZeYUfmTABbLUNASGMVIpEsmAgOX(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_IsGamepad")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IWepkTAORKbrchNybcubBdgTSnxsA(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_OpenGamepad")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jSQcpRAKsOJqUGsdfyEbwoyQYuReb(uint P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_CloseGamepad")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void wxhQaGkxJXymCefWIsCgvpnnElEC(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GamepadConnected")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool JaZWQkUkaodWehrPpTLHlSyozRuNA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadJoystick")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr wqIWWYFYNwrUjkSKZPLLBEuZtrhm(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadName")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr vycaUysuTiozStwQgQNfULzXFzUm(IntPtr P_0);

	public static string ZbtNfpLoaDrbbeVCjJlEQLjzHYOH(IntPtr P_0)
	{
		IntPtr intPtr = vycaUysuTiozStwQgQNfULzXFzUm(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadProperties")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint QnkXtIFugNtCgLIcJGAPhpPOazbRA(IntPtr P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_RumbleGamepad")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool fZUsIVrHpGaxaDSdBkHAjtmaODEAB(IntPtr P_0, ushort P_1, ushort P_2, uint P_3);

	public static bool gwiEGirqhIEGZoCAESAskWizsVMk(IntPtr P_0, ushort P_1, ushort P_2, uint P_3)
	{
		try
		{
			return fZUsIVrHpGaxaDSdBkHAjtmaODEAB(P_0, P_1, P_2, P_3);
		}
		catch
		{
			return false;
		}
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_RumbleGamepadTriggers")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool jMSzqvPjTSOoqsMAyiRKEIdYjNZtA(IntPtr P_0, ushort P_1, ushort P_2, uint P_3);

	public static bool mKGdegfrwCtDfnSCqiDVsaBlayBgb(IntPtr P_0, ushort P_1, ushort P_2, uint P_3)
	{
		try
		{
			return jMSzqvPjTSOoqsMAyiRKEIdYjNZtA(P_0, P_1, P_2, P_3);
		}
		catch
		{
			return false;
		}
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadMappingForGUID")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr LmxZExNCQdNAPvJMnBVSibrIFYWV(IntPtr P_0);

	public static string hbyYCANTuVOSlYAxIJsrFkaJeqrs(IntPtr P_0)
	{
		IntPtr intPtr = LmxZExNCQdNAPvJMnBVSibrIFYWV(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadMappingForGUID")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr llimYFiwgamtrndBIuOKoNHDaeGQ(Guid P_0);

	public static string EHvjJbPptTBWDBJOPAkxHJxPmawG(Guid P_0)
	{
		IntPtr intPtr = llimYFiwgamtrndBIuOKoNHDaeGQ(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_AddGamepadMapping")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int HAnoHkhrOMwjxBkgeJEYBdFYmusM(string P_0);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetGamepadButtonLabel")]
	[SuppressUnmanagedCodeSecurity]
	public static extern EtRzNUFJAUSbCcCBmfZEkvaozkdE eiiRYgQkojIIFFkSqeMvbEyRQECY(IntPtr P_0, AxgFQhfotfIXKYJWlfgsPlrkPOx P_1);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_SetMainReady")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void rxIfovuaDCcalFbZbWqmiUUOSlyMA();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_Quit")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void tZZzGxzMUgcLwhGEiypPYcUMQcsQ();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_GetError")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr lBTfMRbkrqFWEvBKsgOsIHWXxnWA();

	public static string CoIYrtLCCxkUmuaiLbgotNrvjisL()
	{
		IntPtr intPtr = lBTfMRbkrqFWEvBKsgOsIHWXxnWA();
		if (intPtr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA.FZrtpGmnYoCkUbqdsdbHKHMfwnClA(new auIzLjThapfhEAPwYCbPNbnNEOhCA.oebfsDLacuaCdAUvryQLhcNOFEijA(intPtr));
	}

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SDL_free")]
	[SuppressUnmanagedCodeSecurity]
	public static extern void SgciYFjVedmZIFtlVzqjYBfvxoJf(IntPtr P_0);
}
