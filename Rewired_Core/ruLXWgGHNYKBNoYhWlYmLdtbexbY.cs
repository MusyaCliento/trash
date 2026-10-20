using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class ruLXWgGHNYKBNoYhWlYmLdtbexbY : IDisposable
{
	public enum uxaCQNhjmsRztFwNLhXzaVqhhPmhA
	{
		Connected = 0,
		Disconnected = 1
	}

	private class jUqcElLDWWskhhMkCdSZmvFBVzoK
	{
		public ADictionary<int, InputBehavior> kJeqpkgHMHhJTHhwMTUHPZxnSQwC;

		public List<InputBehavior> WQXPUaOyNbBVphMqnPlUPuFdfgSe;

		public IList<InputBehavior> TNIBGVqSplAGhJocBBfmLyPmPRGoA;

		public jUqcElLDWWskhhMkCdSZmvFBVzoK(List<InputBehavior> P_0)
		{
			WQXPUaOyNbBVphMqnPlUPuFdfgSe = new List<InputBehavior>(P_0.Count);
			kJeqpkgHMHhJTHhwMTUHPZxnSQwC = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				kJeqpkgHMHhJTHhwMTUHPZxnSQwC.Add(P_0[i].id, inputBehavior);
				WQXPUaOyNbBVphMqnPlUPuFdfgSe.Add(inputBehavior);
				num++;
			}
			TNIBGVqSplAGhJocBBfmLyPmPRGoA = new ReadOnlyCollection<InputBehavior>(WQXPUaOyNbBVphMqnPlUPuFdfgSe);
		}

		public InputBehavior MFuWebGAIBVUBPqEwfvSyzySgPLI(int P_0)
		{
			if (WQXPUaOyNbBVphMqnPlUPuFdfgSe.Count == 0)
			{
				return null;
			}
			kJeqpkgHMHhJTHhwMTUHPZxnSQwC.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return WQXPUaOyNbBVphMqnPlUPuFdfgSe[0];
			}
			return value;
		}
	}

	private sealed class jgyJBNXfFqDZfWBiQfZAHEGdaAhj : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int TIQiyKiVOpkXASwRXfpgzDTgMdJR;

		private CustomController hJdGFBvhUQWLFKdYLufvydvVbOzhA;

		private int YunomPatSeKJmGAEIAxVuISyLduC;

		public ruLXWgGHNYKBNoYhWlYmLdtbexbY XwKHMwGWPrtFxBKqYAZsbflgLjgOA;

		private int sNpGUrZVatafqyGMoqFsBEpjfHIp;

		public int GbIYMqzhkJtmJFVQBocgqZthoIbv;

		private int wOmLnHjkIwIzIjNhPETcBEVgdbdl;

		private int wGRxpZhlrkoXfpGPWcyWPYbqmQKF;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return hJdGFBvhUQWLFKdYLufvydvVbOzhA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return hJdGFBvhUQWLFKdYLufvydvVbOzhA;
			}
		}

		[DebuggerHidden]
		public jgyJBNXfFqDZfWBiQfZAHEGdaAhj(int P_0)
		{
			TIQiyKiVOpkXASwRXfpgzDTgMdJR = P_0;
			YunomPatSeKJmGAEIAxVuISyLduC = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			TIQiyKiVOpkXASwRXfpgzDTgMdJR = -2;
		}

		private bool MoveNext()
		{
			int tIQiyKiVOpkXASwRXfpgzDTgMdJR = TIQiyKiVOpkXASwRXfpgzDTgMdJR;
			ruLXWgGHNYKBNoYhWlYmLdtbexbY xwKHMwGWPrtFxBKqYAZsbflgLjgOA = XwKHMwGWPrtFxBKqYAZsbflgLjgOA;
			if (tIQiyKiVOpkXASwRXfpgzDTgMdJR != 0)
			{
				if (tIQiyKiVOpkXASwRXfpgzDTgMdJR != 1)
				{
					return false;
				}
				TIQiyKiVOpkXASwRXfpgzDTgMdJR = -1;
				goto IL_007d;
			}
			TIQiyKiVOpkXASwRXfpgzDTgMdJR = -1;
			wOmLnHjkIwIzIjNhPETcBEVgdbdl = xwKHMwGWPrtFxBKqYAZsbflgLjgOA.eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
			wGRxpZhlrkoXfpGPWcyWPYbqmQKF = 0;
			goto IL_008d;
			IL_007d:
			wGRxpZhlrkoXfpGPWcyWPYbqmQKF++;
			goto IL_008d;
			IL_008d:
			if (wGRxpZhlrkoXfpGPWcyWPYbqmQKF < wOmLnHjkIwIzIjNhPETcBEVgdbdl)
			{
				if (xwKHMwGWPrtFxBKqYAZsbflgLjgOA.eyTsgKEJSFkqCXOzDegTrvlZiykgA[wGRxpZhlrkoXfpGPWcyWPYbqmQKF].sourceControllerId == sNpGUrZVatafqyGMoqFsBEpjfHIp)
				{
					hJdGFBvhUQWLFKdYLufvydvVbOzhA = xwKHMwGWPrtFxBKqYAZsbflgLjgOA.eyTsgKEJSFkqCXOzDegTrvlZiykgA[wGRxpZhlrkoXfpGPWcyWPYbqmQKF];
					TIQiyKiVOpkXASwRXfpgzDTgMdJR = 1;
					return true;
				}
				goto IL_007d;
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
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			jgyJBNXfFqDZfWBiQfZAHEGdaAhj jgyJBNXfFqDZfWBiQfZAHEGdaAhj2;
			if (TIQiyKiVOpkXASwRXfpgzDTgMdJR == -2 && YunomPatSeKJmGAEIAxVuISyLduC == Environment.CurrentManagedThreadId)
			{
				TIQiyKiVOpkXASwRXfpgzDTgMdJR = 0;
				jgyJBNXfFqDZfWBiQfZAHEGdaAhj2 = this;
			}
			else
			{
				jgyJBNXfFqDZfWBiQfZAHEGdaAhj2 = new jgyJBNXfFqDZfWBiQfZAHEGdaAhj(0);
				jgyJBNXfFqDZfWBiQfZAHEGdaAhj2.XwKHMwGWPrtFxBKqYAZsbflgLjgOA = XwKHMwGWPrtFxBKqYAZsbflgLjgOA;
			}
			jgyJBNXfFqDZfWBiQfZAHEGdaAhj2.sNpGUrZVatafqyGMoqFsBEpjfHIp = GbIYMqzhkJtmJFVQBocgqZthoIbv;
			return jgyJBNXfFqDZfWBiQfZAHEGdaAhj2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class jqufrrbtUylIGFMdoVKYdAqATQBDB : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int EkZamazvZrSesFvKKcDbhWlzwnPh;

		private CustomController MqAbQDyMwNDlzjQdDNBXVazVJuISA;

		private int ncletklyvYuTHgdytBqthUBCnQyQA;

		public ruLXWgGHNYKBNoYhWlYmLdtbexbY IKunpfHQExduZdAGgeVOMgLWCdvX;

		private string kWHACzjJGmZdSIWHwXMUMyOuqElo;

		public string qjXHOBuRCPYsZjNfgGwNsbCrFTPKA;

		private int tCugOMIIjlPJbyqCSLHTeFwbNrRUA;

		private int MGXvYDlGgFYaFKjSBhQehCcyPHBV;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return MqAbQDyMwNDlzjQdDNBXVazVJuISA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return MqAbQDyMwNDlzjQdDNBXVazVJuISA;
			}
		}

		[DebuggerHidden]
		public jqufrrbtUylIGFMdoVKYdAqATQBDB(int P_0)
		{
			EkZamazvZrSesFvKKcDbhWlzwnPh = P_0;
			ncletklyvYuTHgdytBqthUBCnQyQA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			EkZamazvZrSesFvKKcDbhWlzwnPh = -2;
		}

		private bool MoveNext()
		{
			int ekZamazvZrSesFvKKcDbhWlzwnPh = EkZamazvZrSesFvKKcDbhWlzwnPh;
			ruLXWgGHNYKBNoYhWlYmLdtbexbY iKunpfHQExduZdAGgeVOMgLWCdvX = IKunpfHQExduZdAGgeVOMgLWCdvX;
			if (ekZamazvZrSesFvKKcDbhWlzwnPh != 0)
			{
				if (ekZamazvZrSesFvKKcDbhWlzwnPh != 1)
				{
					return false;
				}
				EkZamazvZrSesFvKKcDbhWlzwnPh = -1;
				goto IL_0083;
			}
			EkZamazvZrSesFvKKcDbhWlzwnPh = -1;
			tCugOMIIjlPJbyqCSLHTeFwbNrRUA = iKunpfHQExduZdAGgeVOMgLWCdvX.eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
			MGXvYDlGgFYaFKjSBhQehCcyPHBV = 0;
			goto IL_0093;
			IL_0083:
			MGXvYDlGgFYaFKjSBhQehCcyPHBV++;
			goto IL_0093;
			IL_0093:
			if (MGXvYDlGgFYaFKjSBhQehCcyPHBV < tCugOMIIjlPJbyqCSLHTeFwbNrRUA)
			{
				if (iKunpfHQExduZdAGgeVOMgLWCdvX.eyTsgKEJSFkqCXOzDegTrvlZiykgA[MGXvYDlGgFYaFKjSBhQehCcyPHBV].tag.Equals(kWHACzjJGmZdSIWHwXMUMyOuqElo, StringComparison.OrdinalIgnoreCase))
				{
					MqAbQDyMwNDlzjQdDNBXVazVJuISA = iKunpfHQExduZdAGgeVOMgLWCdvX.eyTsgKEJSFkqCXOzDegTrvlZiykgA[MGXvYDlGgFYaFKjSBhQehCcyPHBV];
					EkZamazvZrSesFvKKcDbhWlzwnPh = 1;
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
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			jqufrrbtUylIGFMdoVKYdAqATQBDB jqufrrbtUylIGFMdoVKYdAqATQBDB2;
			if (EkZamazvZrSesFvKKcDbhWlzwnPh == -2 && ncletklyvYuTHgdytBqthUBCnQyQA == Environment.CurrentManagedThreadId)
			{
				EkZamazvZrSesFvKKcDbhWlzwnPh = 0;
				jqufrrbtUylIGFMdoVKYdAqATQBDB2 = this;
			}
			else
			{
				jqufrrbtUylIGFMdoVKYdAqATQBDB2 = new jqufrrbtUylIGFMdoVKYdAqATQBDB(0);
				jqufrrbtUylIGFMdoVKYdAqATQBDB2.IKunpfHQExduZdAGgeVOMgLWCdvX = IKunpfHQExduZdAGgeVOMgLWCdvX;
			}
			jqufrrbtUylIGFMdoVKYdAqATQBDB2.kWHACzjJGmZdSIWHwXMUMyOuqElo = qjXHOBuRCPYsZjNfgGwNsbCrFTPKA;
			return jqufrrbtUylIGFMdoVKYdAqATQBDB2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> gQAmECSKPLTadxHHbPPNNyLrJMKU;

	private List<Joystick> NgEIfYnPYrpZwkLvTyhoMrhhsUVi;

	private List<CustomController> eyTsgKEJSFkqCXOzDegTrvlZiykgA;

	private List<Controller> ABLVaoSDSMrbAutSRyVrpplTNFGf;

	private ReadOnlyCollection<Controller> SnnWdDHpKJUGmrfOHbMsrufleaDKA;

	private Keyboard eSwLnIXJJYSDxFSCtBhAwsETkqcW;

	private Mouse ZBRfotJecEwgyCEGjexSASReSxJR;

	private ConfigVars lbvtyLZHjFUNXRHndFQYyvGGagaW;

	private ULWotIhqUFBdhwlfsIksjyZhzzXLA[] FldIgLCXtPTMXEQqtahjaKctsavc;

	private ULWotIhqUFBdhwlfsIksjyZhzzXLA[] uAkMkILgAmOkiUmCWOfrCArwkFwl;

	private ULWotIhqUFBdhwlfsIksjyZhzzXLA[,] vQfiZdcXOoAkGITxFZRTRFocDvCU;

	private MOwUUKuNTbUFoXIYrTFqUJUvwxIO fKJQOpXuCvfUQCPdujENIgJxEQpP;

	private uNUJNNadqmDFujCsBrlAGsjEbLTu ItwgjikaczpArIZZrYHShnIFWDiL;

	private uNUJNNadqmDFujCsBrlAGsjEbLTu[] ITMaMibUiXabsfRnKwcbBReGDmIsB;

	private global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<ActiveControllerChangedDelegate> vmRIuKuHSYArPsdUNEivAkmKnEjz;

	private global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<PlayerActiveControllerChangedDelegate> UOTLBXTbNoghTewWSzNUbCDGPJGQ;

	private global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<PlayerActiveControllerChangedDelegate>[] EZFSArzEckeHEiakMdDSruSPigjA;

	private ADictionary<int, jUqcElLDWWskhhMkCdSZmvFBVzoK> ddZpKZpnssfnRPFWlsFVCgvtDUCK;

	private readonly fIKoOjsUVwLfLYGsxsHqEoHWjzbJ ONbZarGoOFkuLsUTedkCSslONfXV;

	private IList<Joystick> JHUfetjSwcwNwUTyDFHtyhhSCgjrA;

	private IList<CustomController> ZEmTqwstOroTayFyqATdLbrMhQfv;

	private int YGAZxSVTFRVIbNewDcKAOTKtqZis;

	private bool qtAkVAzbEgVMATMioEaaSklGVRdD;

	private bool pRdVtFlUUdijWyOVKnbIjvjHCBTE;

	private bool fbMIQdJqFljXLpYKuivuxaJHIXOGA;

	private IUnifiedKeyboardSource JxhPSZQneqigAFnlStxhagiXSINt;

	private IUnifiedMouseSource XflMuxPzKyOpgScQZImwZeXqARDE;

	private int jHmCsYpyQRIEEOebXRQZKlQKALrGA;

	private ControllerType evGkzJxqUvEEVmUIPQplpAggMbbn;

	private double sJPEpKTApnrPTQmdFXJcjncEsVyJ;

	private int pRGwIDEdGrlfknaJbcMieYnpomIP;

	private tJoKaBpeixEcmjlcjTQCbZQpjqFR DeodXOYecDehAMWweDQhdpVRTvqdA;

	private XCvMDQBADcmACIDQJmYqAKqBfrW STAPHPSFjtiVXYUuDrtfswVgsJVM;

	private int UgNlMdzvHrBtBaBcBioGcLSZaIrh;

	private int dqAziZXQlnKHMuKyTcTermKVINiz;

	private Action<int, ControllerDataUpdater> AcRdPGYuTOjXuEimnUCSIlIszmCe;

	private Action<bool, int, int> nGBDFjbhYFOQBJoEjqXQZMNKIdS;

	private Action<ControllerStatusChangedEventArgs> LGYLyYnpmCjGoyvMiUcIRZZAtRpJ;

	private Action<ControllerType, int> tRIAnlzNgVYHzlOGLjECbZzztXHPA;

	private bool PYGEiBZbbvEJkhZsPkEktsCBBaLRA;

	public IList<Joystick> FmfxwfhlxDwfpqdOLrqFojAgTbO => JHUfetjSwcwNwUTyDFHtyhhSCgjrA;

	public List<Joystick> TAababCysaTzGIJhhnlxaZhBGYyBb => gQAmECSKPLTadxHHbPPNNyLrJMKU;

	public int BZmSVymcSLcbcCvESSRKrvmAIKVl => gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;

	public Mouse tAQmtNcIHgKfFSRzKoZtyWPabvG => ZBRfotJecEwgyCEGjexSASReSxJR;

	public Keyboard dqlVbgwiwbhfyZlhzyrqssSByBAe => eSwLnIXJJYSDxFSCtBhAwsETkqcW;

	public IList<CustomController> znuGFVHdakBIvysMReNIjKPHIQDfb => ZEmTqwstOroTayFyqATdLbrMhQfv;

	public List<CustomController> BopLkbMoDzSDlAKOudlAWTBnwxuk => eyTsgKEJSFkqCXOzDegTrvlZiykgA;

	public int egKAiAdlTOlVwxeoUjfWqxVINyPOA => eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;

	public IList<Controller> ABIjtGLogkGPxCWFMrrynAMFtiuWA => SnnWdDHpKJUGmrfOHbMsrufleaDKA;

	public int ItbHdsEnpbUQIbZQSBtDSiMsGsVcA => ABLVaoSDSMrbAutSRyVrpplTNFGf.Count;

	private int sKazAquTZlyyNuddwcGPbeXiXDj
	{
		get
		{
			int result = pRGwIDEdGrlfknaJbcMieYnpomIP;
			pRGwIDEdGrlfknaJbcMieYnpomIP++;
			if (pRGwIDEdGrlfknaJbcMieYnpomIP >= int.MaxValue)
			{
				pRGwIDEdGrlfknaJbcMieYnpomIP = 0;
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> PTAfSvaPqwFLLQaNUEhITJUdepvI
	{
		add
		{
			LGYLyYnpmCjGoyvMiUcIRZZAtRpJ = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(LGYLyYnpmCjGoyvMiUcIRZZAtRpJ, b);
		}
		remove
		{
			LGYLyYnpmCjGoyvMiUcIRZZAtRpJ = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(LGYLyYnpmCjGoyvMiUcIRZZAtRpJ, value2);
		}
	}

	public event Action<ControllerType, int> ldzDrzaMWtEtHkmsZNkiodTCOZWTA
	{
		add
		{
			tRIAnlzNgVYHzlOGLjECbZzztXHPA = (Action<ControllerType, int>)Delegate.Combine(tRIAnlzNgVYHzlOGLjECbZzztXHPA, b);
		}
		remove
		{
			tRIAnlzNgVYHzlOGLjECbZzztXHPA = (Action<ControllerType, int>)Delegate.Remove(tRIAnlzNgVYHzlOGLjECbZzztXHPA, value2);
		}
	}

	public ruLXWgGHNYKBNoYhWlYmLdtbexbY(ConfigVars P_0, PlatformInputManager P_1)
	{
		lbvtyLZHjFUNXRHndFQYyvGGagaW = P_0;
		YGAZxSVTFRVIbNewDcKAOTKtqZis = 0;
		qtAkVAzbEgVMATMioEaaSklGVRdD = UnityTools.isAndroidPlatform;
		ABLVaoSDSMrbAutSRyVrpplTNFGf = new List<Controller>(10);
		SnnWdDHpKJUGmrfOHbMsrufleaDKA = new ReadOnlyCollection<Controller>(ABLVaoSDSMrbAutSRyVrpplTNFGf);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (JxhPSZQneqigAFnlStxhagiXSINt = new UnityUnifiedKeyboardSource());
		}
		eSwLnIXJJYSDxFSCtBhAwsETkqcW = new Keyboard("Keyboard", unifiedKeyboardSource);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Add(eSwLnIXJJYSDxFSCtBhAwsETkqcW);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (XflMuxPzKyOpgScQZImwZeXqARDE = new UnityUnifiedMouseSource());
		}
		ZBRfotJecEwgyCEGjexSASReSxJR = new Mouse("Mouse", unifiedMouseSource);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Add(ZBRfotJecEwgyCEGjexSASReSxJR);
		fKJQOpXuCvfUQCPdujENIgJxEQpP = new MOwUUKuNTbUFoXIYrTFqUJUvwxIO(P_0.updateLoop, eSwLnIXJJYSDxFSCtBhAwsETkqcW);
		eSwLnIXJJYSDxFSCtBhAwsETkqcW.yMSMQOKECkxSEBpSrBiIfzDePoGuA += kcQHOjXmvoeOTtYxMIEcXZffYAng;
		eSwLnIXJJYSDxFSCtBhAwsETkqcW.enabled = !P_0.GetPlatformVar_disableKeyboard();
		ZBRfotJecEwgyCEGjexSASReSxJR.enabled = !P_0.GetPlatformVar_disableMouse();
		uDKoXqSXFZtewSqluDiWfCjusTEj.sWlZZXjeurEtztaMtqpZyVcdBddG();
		ONbZarGoOFkuLsUTedkCSslONfXV = new fIKoOjsUVwLfLYGsxsHqEoHWjzbJ(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		ONbZarGoOFkuLsUTedkCSslONfXV.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(eSwLnIXJJYSDxFSCtBhAwsETkqcW);
		ONbZarGoOFkuLsUTedkCSslONfXV.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(ZBRfotJecEwgyCEGjexSASReSxJR);
		ReInput.ApplicationFocusChangedEvent += oihuzraYdJVionCgvnTNFQEFNfAC;
	}

	public void OuhcZfgSkevBrldLORfxDuGYIfQGA(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		AcRdPGYuTOjXuEimnUCSIlIszmCe = P_0;
		upwHWrVIkRDTgPFBxOZaFkLESIKS(P_1);
	}

	public void kJEzgSqpIgiZHnKtcfHjBsUpGltH(UpdateLoopType P_0)
	{
		uDKoXqSXFZtewSqluDiWfCjusTEj.luiDXSazuIFJFBdLDyHrBcmMOuyF(P_0);
		if (eSwLnIXJJYSDxFSCtBhAwsETkqcW.enabled)
		{
			fKJQOpXuCvfUQCPdujENIgJxEQpP.iNfwbtHhBhtbuvDbcBonVVURwXhi(P_0);
		}
		IbpdaWclKCoBVpNUqhEMCYRyjqgwA(P_0);
		wTsNWwmoYLFQeKqLWIgWxGEoDdBKA(P_0);
		uDKoXqSXFZtewSqluDiWfCjusTEj.ryVGNmPzjHDafpSESbtmksbJEypNA(P_0, ReInput.currentFrame);
		if (fbMIQdJqFljXLpYKuivuxaJHIXOGA)
		{
			rIlYoLIBZgMuVjRmPEPXxEylEvHcA();
		}
	}

	public ULWotIhqUFBdhwlfsIksjyZhzzXLA PXhKbkfGYpgcekUEIUnUesoydMCuA(int P_0, string P_1, bool P_2)
	{
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.dguDgqFQMSFVkESJOObLZIzdEYyzA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return uAkMkILgAmOkiUmCWOfrCArwkFwl[num];
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return null;
		}
		return vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, num];
	}

	public ULWotIhqUFBdhwlfsIksjyZhzzXLA zUiRzVjDrtXdtCfESwaiFcTXGjlK(int P_0, int P_1, bool P_2)
	{
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.gwGPJXsVmpnHcrNmpYDODSJzdJJn(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return uAkMkILgAmOkiUmCWOfrCArwkFwl[num];
		}
		return vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, num];
	}

	public void eYZAAUHIhAWERVzuccmuYrySdyqU(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			uxaCQNhjmsRztFwNLhXzaVqhhPmhA uxaCQNhjmsRztFwNLhXzaVqhhPmhA2 = uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected;
			int num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0.sourceJoystick.rewiredId, uxaCQNhjmsRztFwNLhXzaVqhhPmhA2);
			if (num < 0)
			{
				uxaCQNhjmsRztFwNLhXzaVqhhPmhA2 = uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected;
				num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0.sourceJoystick.rewiredId, uxaCQNhjmsRztFwNLhXzaVqhhPmhA2);
			}
			if (num >= 0)
			{
				((uxaCQNhjmsRztFwNLhXzaVqhhPmhA2 == uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected) ? gQAmECSKPLTadxHHbPPNNyLrJMKU[num] : NgEIfYnPYrpZwkLvTyhoMrhhsUVi[num]).uYsPfQgQrvjJKoCCEGTDLlqfWetR(P_0);
			}
		}
	}

	public bool gtAsgRmaDkYbYZgyZlJedQRiLNXm(int P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA P_1)
	{
		return jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0, P_1) >= 0;
	}

	public int jbwjrtagZYLWanzcUlRGkITHBxGpA(int P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA P_1)
	{
		switch (P_1)
		{
		case uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected:
		{
			int count2 = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
			for (int j = 0; j < count2; j++)
			{
				if (gQAmECSKPLTadxHHbPPNNyLrJMKU[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected:
		{
			int count = NgEIfYnPYrpZwkLvTyhoMrhhsUVi.Count;
			for (int i = 0; i < count; i++)
			{
				if (NgEIfYnPYrpZwkLvTyhoMrhhsUVi[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int mlXKZsMjZtgxZquNOfunAvgutxbH(Guid P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA P_1)
	{
		switch (P_1)
		{
		case uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected:
		{
			int count2 = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
			for (int j = 0; j < count2; j++)
			{
				if (gQAmECSKPLTadxHHbPPNNyLrJMKU[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected:
		{
			int count = NgEIfYnPYrpZwkLvTyhoMrhhsUVi.Count;
			for (int i = 0; i < count; i++)
			{
				if (NgEIfYnPYrpZwkLvTyhoMrhhsUVi[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool zbpeashJVAltGyvXVEkqRwlVszwk(int P_0)
	{
		return lQjeuheQIHiAHRkwwKmEosyaZxmk(P_0) >= 0;
	}

	public int lQjeuheQIHiAHRkwwKmEosyaZxmk(int P_0)
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		for (int i = 0; i < count; i++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int srixRmTDigRkFnJNosBQewQYsXMo(Guid P_0)
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		for (int i = 0; i < count; i++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void AFQnawoogqUuoghzYbeWjfltItzVA(BridgedController P_0)
	{
		PIbwcKaIHTCMVQfQTgKTGeBOkGsab(P_0);
	}

	public void FGidPCTeJRfbSkSvvnsSFYbijMAtb(int P_0)
	{
		int num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected);
		WXPVYwKbkMlcGvyjoichcFxtaaNf(num);
	}

	public int qDTJXOYmrJdDmfrNFZpffvfiDtiC()
	{
		return YGAZxSVTFRVIbNewDcKAOTKtqZis++;
	}

	public IList<InputBehavior> gGgZBtkCabfbYKBSTdKVeifYdvGMA(int P_0)
	{
		if (!ddZpKZpnssfnRPFWlsFVCgvtDUCK.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return ddZpKZpnssfnRPFWlsFVCgvtDUCK[P_0].TNIBGVqSplAGhJocBBfmLyPmPRGoA;
	}

	public InputBehavior fGrbcxUbqLPGHwfPLCPGEIILpayh(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return aBmCPIjIQipDXvJzizuGNfyaNgx(P_0, inputBehaviorId);
	}

	public InputBehavior aBmCPIjIQipDXvJzizuGNfyaNgx(int P_0, int P_1)
	{
		if (!ddZpKZpnssfnRPFWlsFVCgvtDUCK.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> tNIBGVqSplAGhJocBBfmLyPmPRGoA = ddZpKZpnssfnRPFWlsFVCgvtDUCK[P_0].TNIBGVqSplAGhJocBBfmLyPmPRGoA;
		for (int i = 0; i < tNIBGVqSplAGhJocBBfmLyPmPRGoA.Count; i++)
		{
			if (tNIBGVqSplAGhJocBBfmLyPmPRGoA[i].id == P_1)
			{
				return tNIBGVqSplAGhJocBBfmLyPmPRGoA[i];
			}
		}
		return null;
	}

	public Joystick CjsxcJaHUvrHCwxyCGmMBABZwBpQ(int P_0, bool P_1 = false)
	{
		int num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected);
		if (num >= 0)
		{
			return gQAmECSKPLTadxHHbPPNNyLrJMKU[num];
		}
		if (P_1)
		{
			num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected);
			if (num >= 0)
			{
				return NgEIfYnPYrpZwkLvTyhoMrhhsUVi[num];
			}
		}
		return null;
	}

	public Joystick PqEeKpDLNMUdUeUhDnwikmdNTVwx(Guid P_0, bool P_1 = false)
	{
		int num = mlXKZsMjZtgxZquNOfunAvgutxbH(P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected);
		if (num >= 0)
		{
			return gQAmECSKPLTadxHHbPPNNyLrJMKU[num];
		}
		if (P_1)
		{
			num = mlXKZsMjZtgxZquNOfunAvgutxbH(P_0, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected);
			if (num >= 0)
			{
				return NgEIfYnPYrpZwkLvTyhoMrhhsUVi[num];
			}
		}
		return null;
	}

	public Joystick[] IBDzmhaSXJnVJPpLuikCeToDAVSK()
	{
		int count = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = gQAmECSKPLTadxHHbPPNNyLrJMKU[i];
		}
		return array;
	}

	public string[] LMfmohWbTMQrPwWsHQMJrnPApdxK()
	{
		int count = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = gQAmECSKPLTadxHHbPPNNyLrJMKU[i].name;
		}
		return array;
	}

	public CustomController gRvhnlvVEKDYyGVCrunkdbetDKMp(int P_0)
	{
		int num = lQjeuheQIHiAHRkwwKmEosyaZxmk(P_0);
		if (num < 0)
		{
			return null;
		}
		return eyTsgKEJSFkqCXOzDegTrvlZiykgA[num];
	}

	public CustomController pjeILucqhXaMHZYEMNLYCiWaozn(Guid P_0)
	{
		int num = srixRmTDigRkFnJNosBQewQYsXMo(P_0);
		if (num < 0)
		{
			return null;
		}
		return eyTsgKEJSFkqCXOzDegTrvlZiykgA[num];
	}

	public CustomController[] bItKhJSUzmOgUDkGJbwQLfyQJrfB()
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = eyTsgKEJSFkqCXOzDegTrvlZiykgA[i];
		}
		return array;
	}

	public string[] OIavYVmyEpLAEalwERrNYQUNoDJG()
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = eyTsgKEJSFkqCXOzDegTrvlZiykgA[i].name;
		}
		return array;
	}

	public CustomController wdCMlfofKsEmCXsYcusWVzNpaPIt(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int hBZblCBazeDfqCkWSDYrcRQYsMwoA = sKazAquTZlyyNuddwcGPbeXiXDj;
		CustomController customController = new CustomController(new XeeCNgHjZMIswyGERJdBBjwJCnEBA
		{
			ADDDCghZjPcBqomFNqaRChwimBYzB = InputSource.Custom,
			zBKJPlzimjZyagilmPlkXySOQmSy = customControllerById.descriptiveName,
			JsFMMvVfsnXVqqgsMGZDSybWHEgM = customControllerById.name,
			BlEDQbDUmfikEbtsAqRbAChLwPzT = customControllerById.axisCount,
			sAFWPhaoKuiAiWeWyWJkOJPWbOVdA = customControllerById.buttonCount,
			HBZblCBazeDfqCkWSDYrcRQYsMwoA = hBZblCBazeDfqCkWSDYrcRQYsMwoA,
			XHeLXBkEPmqdmYKhknXQSUsWRJXh = customControllerById.id,
			gtUHQOMvYkRjYAksobERwOUBiIYN = customControllerById.typeGuid,
			LgGByklfbGExtuEOzPazEUlFRlKb = customControllerById.id.ToString(),
			qlPyMfStFAUFVrytfjcRexWrMcci = customControllerById.CreateGameHardwareMap()
		});
		sRixWidcxvbGiVDzXIbcYhkIGjSBA(customController);
		return customController;
	}

	public bool LakYHFUCriIVxTqiqUXhkfNRzbuR(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return uTODXCdCpOECNgrpHtHWSNVpvoeMA(P_0);
	}

	public CustomController XlcbWdvLRxQzVRjbLForkREwCjzs(int P_0)
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		for (int i = 0; i < count; i++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[i].sourceControllerId == P_0)
			{
				return eyTsgKEJSFkqCXOzDegTrvlZiykgA[i];
			}
		}
		return null;
	}

	public CustomController ouytoEJugSLQZoGtQxSqYGhJIRgq(string P_0)
	{
		int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		for (int i = 0; i < count; i++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return eyTsgKEJSFkqCXOzDegTrvlZiykgA[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(jgyJBNXfFqDZfWBiQfZAHEGdaAhj))]
	public IEnumerable<CustomController> WExjsbarhUCRSFXLjkdZjtaIHMJgB(int P_0)
	{
		return new jgyJBNXfFqDZfWBiQfZAHEGdaAhj(-2)
		{
			XwKHMwGWPrtFxBKqYAZsbflgLjgOA = this,
			GbIYMqzhkJtmJFVQBocgqZthoIbv = P_0
		};
	}

	[IteratorStateMachine(typeof(jqufrrbtUylIGFMdoVKYdAqATQBDB))]
	public IEnumerable<CustomController> JdMGNSqlWFhAtHtZadIbtzDzqrTc(string P_0)
	{
		return new jqufrrbtUylIGFMdoVKYdAqATQBDB(-2)
		{
			IKunpfHQExduZdAGgeVOMgLWCdvX = this,
			qjXHOBuRCPYsZjNfgGwNsbCrFTPKA = P_0
		};
	}

	public Controller uNJmTUUZIgxCnlFgJshQMfTyrJwA(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => CjsxcJaHUvrHCwxyCGmMBABZwBpQ(P_1, P_2), 
			ControllerType.Keyboard => eSwLnIXJJYSDxFSCtBhAwsETkqcW, 
			ControllerType.Mouse => ZBRfotJecEwgyCEGjexSASReSxJR, 
			ControllerType.Custom => gRvhnlvVEKDYyGVCrunkdbetDKMp(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller syLDSFbeEMfdqJIKtznpocztFhSL(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return RqCdDMDHIrOotYBmgExekojLdxiB(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return uNJmTUUZIgxCnlFgJshQMfTyrJwA(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller RqCdDMDHIrOotYBmgExekojLdxiB(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (eSwLnIXJJYSDxFSCtBhAwsETkqcW.deviceInstanceGuid == P_0)
		{
			return eSwLnIXJJYSDxFSCtBhAwsETkqcW;
		}
		if (ZBRfotJecEwgyCEGjexSASReSxJR.deviceInstanceGuid == P_0)
		{
			return ZBRfotJecEwgyCEGjexSASReSxJR;
		}
		Controller result;
		if ((result = PqEeKpDLNMUdUeUhDnwikmdNTVwx(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = pjeILucqhXaMHZYEMNLYCiWaozn(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] XnicoCZswdsvulrRKokJFUxFQzNE(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => IBDzmhaSXJnVJPpLuikCeToDAVSK(), 
			ControllerType.Keyboard => new Controller[1] { eSwLnIXJJYSDxFSCtBhAwsETkqcW }, 
			ControllerType.Mouse => new Controller[1] { ZBRfotJecEwgyCEGjexSASReSxJR }, 
			ControllerType.Custom => bItKhJSUzmOgUDkGJbwQLfyQJrfB(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] LaygbBCrxnytQbTiQrAtovmkuWOE(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => LMfmohWbTMQrPwWsHQMJrnPApdxK(), 
			ControllerType.Keyboard => new string[1] { eSwLnIXJJYSDxFSCtBhAwsETkqcW.name }, 
			ControllerType.Mouse => new string[1] { ZBRfotJecEwgyCEGjexSASReSxJR.name }, 
			ControllerType.Custom => OIavYVmyEpLAEalwERrNYQUNoDJG(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void ZELESJItxBVDblGJuCmLvkYBJnzwA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.FXRPNsAxptiUuekqvkJSTDgJsDyH(P_1, P_2, InputActionEventType.Update, null);
	}

	public void xmXyeEjDmQjYkGqkIUaqVeDQGnEgA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.dslcdUZyuborPJTKPkbaHctgVEOu(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void xBjbbFtPTbVNGvyGPwkbZikCympl(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_3);
		if (num >= 0)
		{
			xmXyeEjDmQjYkGqkIUaqVeDQGnEgA(P_0, P_1, P_2, num);
		}
	}

	public void xwziLmPNfzwGKtRmcVNlawwrTIzH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.FXRPNsAxptiUuekqvkJSTDgJsDyH(P_1, P_2, P_3, P_4);
	}

	public void wUwdHkvIqQKRHpcJwwBrOyxsoQEd(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.dslcdUZyuborPJTKPkbaHctgVEOu(P_1, P_2, P_3, P_4, P_5);
	}

	public void vMmRfrMCctjpQRzxdvUcsaXLuPVH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			pRdVtFlUUdijWyOVKnbIjvjHCBTE = true;
		}
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_4);
		if (num >= 0)
		{
			wUwdHkvIqQKRHpcJwwBrOyxsoQEd(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void lWkbaGEYswBRHabNrpECQroplben(int P_0, Action<InputActionEventData> P_1)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.OvJdZelufiYiJTBHZZqEfUStzHvI(P_1);
	}

	public void zIIFpRMNaxdJvogZeyNkbtvniIRX(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.EnscmpHpZDiusYrPxENEcWoVHvPgb(P_1, P_2);
	}

	public void UhyChnQqujMEPPZGxaCXPvbaCJRD(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
		if (num >= 0)
		{
			zIIFpRMNaxdJvogZeyNkbtvniIRX(P_0, P_1, num);
		}
	}

	public void DIEEcZWmzMTuReGTSgKzJuSckCHc(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.KsuuHsKGJFymjEhHjpbFfXMQggji(P_1, P_2);
	}

	public void CLplVWlknHBRvJgAtTiPeuzCpENVA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.RcEbJKEOEERJCKDGbLLzTkHkYqIiA(P_1, P_2);
	}

	public void anGvIhGhMOhzilJHAVdykNyKPYAE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.PmCfvqOBJUvQVZeByCFBKCjrJZNo(P_1, P_2, P_3);
	}

	public void ZQKucqaGbQIBnaPeaKQsnVGLmjUab(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_3);
		if (num >= 0)
		{
			anGvIhGhMOhzilJHAVdykNyKPYAE(P_0, P_1, P_2, num);
		}
	}

	public void AkxFkhBvpWCVLyBjitOOkozYfvCt(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.nxvezEElFlvFkPIZstyupISlwvMt(P_1, P_2, P_3);
	}

	public void ZdmUhYvZaNbXuizOzdfYphDNYmkK(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_3);
		if (num >= 0)
		{
			AkxFkhBvpWCVLyBjitOOkozYfvCt(P_0, P_1, P_2, num);
		}
	}

	public void MVEqfATTddDMDQlfWEFYDioLNuaAb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.xiGrBvfurvjsERbymFdIgSkLrHJG(P_1, P_2, P_3);
	}

	public void AALLUIengqmiyADIaRruZWREAEUn(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.RDotrlKdYSTNQcqtLuGpoyenksom(P_1, P_2, P_3, P_4);
	}

	public void uXeHPXrNFjTuQFIygWBhpWLpGpKq(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_4);
		if (num >= 0)
		{
			AALLUIengqmiyADIaRruZWREAEUn(P_0, P_1, P_2, P_3, num);
		}
	}

	public void ajOAkAZfyzjWVhZsjDPbJfnnklFO(int P_0)
	{
		DgZaVndUQvkQYwebSfKTpxTMYtOtA(P_0)?.sdFsKaMZIOqdefFgqdFZojKujCMU();
	}

	public bool BRYiiIQkZMutWWvDgcSbWDyPsIOb(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].bboVUHBkbaSOWIdiLlywxyMWUUnP())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].bboVUHBkbaSOWIdiLlywxyMWUUnP())
			{
				return true;
			}
		}
		return false;
	}

	public bool RxmPsONHJStsMyyJRmjfONdxyTKc(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].MVRdnxXGZCsBJEWZdnMOyOTlrrdu())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].MVRdnxXGZCsBJEWZdnMOyOTlrrdu())
			{
				return true;
			}
		}
		return false;
	}

	public bool YRYEmpqxfSFWRyuTtLQyFpMSCehj(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].UfRoNrLsJHhqSsAsVeuTJufLfJRFA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].UfRoNrLsJHhqSsAsVeuTJufLfJRFA())
			{
				return true;
			}
		}
		return false;
	}

	public bool OkSaHVcjeqwywYgmchHiuTKVwPOr(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].CQCGDxvIRQaxxsKVThUacYtWsqMg())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].CQCGDxvIRQaxxsKVThUacYtWsqMg())
			{
				return true;
			}
		}
		return false;
	}

	public bool GjRQMnnTJZcXCTEPvjDmSzFhefJg(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].xGqLYAhmrlKApcDsGylXNoGhsHKJ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].xGqLYAhmrlKApcDsGylXNoGhsHKJ())
			{
				return true;
			}
		}
		return false;
	}

	public bool PcwdgKAGFNtHdoGUIrnrYcUdaJIA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].zQqegsuPBZQcPDbgYgCvXbzrMSjA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].zQqegsuPBZQcPDbgYgCvXbzrMSjA())
			{
				return true;
			}
		}
		return false;
	}

	public bool DYAgYeTWORjITkfpOjKmVooPWKimA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].uYGNTCcasDFipFwcGgdlFErqqgJJ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].uYGNTCcasDFipFwcGgdlFErqqgJJ())
			{
				return true;
			}
		}
		return false;
	}

	public bool ivBYFTnkRjdBNWGrXjaSdDfAcGbH(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < uAkMkILgAmOkiUmCWOfrCArwkFwl.Length; i++)
			{
				if (uAkMkILgAmOkiUmCWOfrCArwkFwl[i].LYHnxgyyuAPbCHIZzEjJDWjwOENI())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			return false;
		}
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		for (int j = 0; j < num; j++)
		{
			if (vQfiZdcXOoAkGITxFZRTRFocDvCU[P_0, j].LYHnxgyyuAPbCHIZzEjJDWjwOENI())
			{
				return true;
			}
		}
		return false;
	}

	public bool fBfVxNGNJukEUkgYzBQyjamUBcak()
	{
		if (!MWdFDwEtUAELhJsCqTNLqyhaHPpW(ZBRfotJecEwgyCEGjexSASReSxJR) && !oFOMmQSwiGPFhvZvQJmTdYNsGkVM(gQAmECSKPLTadxHHbPPNNyLrJMKU) && !MWdFDwEtUAELhJsCqTNLqyhaHPpW(eSwLnIXJJYSDxFSCtBhAwsETkqcW))
		{
			return oFOMmQSwiGPFhvZvQJmTdYNsGkVM(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		}
		return true;
	}

	public bool GjGeRgBAZotrAMokpmedeHrVebXz(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => oFOMmQSwiGPFhvZvQJmTdYNsGkVM(gQAmECSKPLTadxHHbPPNNyLrJMKU), 
			ControllerType.Keyboard => MWdFDwEtUAELhJsCqTNLqyhaHPpW(eSwLnIXJJYSDxFSCtBhAwsETkqcW), 
			ControllerType.Mouse => MWdFDwEtUAELhJsCqTNLqyhaHPpW(ZBRfotJecEwgyCEGjexSASReSxJR), 
			ControllerType.Custom => oFOMmQSwiGPFhvZvQJmTdYNsGkVM(eyTsgKEJSFkqCXOzDegTrvlZiykgA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool OooincwdLCWhvHqzvNOtcwfwKZDp()
	{
		if (!KNngFFqpARlwRvHGkQoMFgahCxZBA(ZBRfotJecEwgyCEGjexSASReSxJR) && !SXZqCKxMOIHKBjmIMgtFMkrEedajb(gQAmECSKPLTadxHHbPPNNyLrJMKU) && !KNngFFqpARlwRvHGkQoMFgahCxZBA(eSwLnIXJJYSDxFSCtBhAwsETkqcW))
		{
			return SXZqCKxMOIHKBjmIMgtFMkrEedajb(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		}
		return true;
	}

	public bool ThLKFptFBYXTwbTJlSCkJdQApBYB(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => SXZqCKxMOIHKBjmIMgtFMkrEedajb(gQAmECSKPLTadxHHbPPNNyLrJMKU), 
			ControllerType.Keyboard => KNngFFqpARlwRvHGkQoMFgahCxZBA(eSwLnIXJJYSDxFSCtBhAwsETkqcW), 
			ControllerType.Mouse => KNngFFqpARlwRvHGkQoMFgahCxZBA(ZBRfotJecEwgyCEGjexSASReSxJR), 
			ControllerType.Custom => SXZqCKxMOIHKBjmIMgtFMkrEedajb(eyTsgKEJSFkqCXOzDegTrvlZiykgA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool vfGiLBdzesiJYQgVbMWVwXcwjJMeA()
	{
		if (!OIBOBGLeNSAyMRmXngiLnwZGnVJI(ZBRfotJecEwgyCEGjexSASReSxJR) && !pXXavaAkoUEPqgvvMSeUgAcqSuaDb(gQAmECSKPLTadxHHbPPNNyLrJMKU) && !OIBOBGLeNSAyMRmXngiLnwZGnVJI(eSwLnIXJJYSDxFSCtBhAwsETkqcW))
		{
			return pXXavaAkoUEPqgvvMSeUgAcqSuaDb(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		}
		return true;
	}

	public bool FObTxupDRKdfnXHQHHITzCimAbeiA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => pXXavaAkoUEPqgvvMSeUgAcqSuaDb(gQAmECSKPLTadxHHbPPNNyLrJMKU), 
			ControllerType.Keyboard => OIBOBGLeNSAyMRmXngiLnwZGnVJI(eSwLnIXJJYSDxFSCtBhAwsETkqcW), 
			ControllerType.Mouse => OIBOBGLeNSAyMRmXngiLnwZGnVJI(ZBRfotJecEwgyCEGjexSASReSxJR), 
			ControllerType.Custom => pXXavaAkoUEPqgvvMSeUgAcqSuaDb(eyTsgKEJSFkqCXOzDegTrvlZiykgA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool cWemPSxkiVYmoLVDVotzscyAWcst()
	{
		if (!iHCxmbBGMPfmjjmmeAXhcoqDIBZh(ZBRfotJecEwgyCEGjexSASReSxJR) && !SjzlpFSlqrCQgjcvjsqLSalXKPAZA(gQAmECSKPLTadxHHbPPNNyLrJMKU) && !iHCxmbBGMPfmjjmmeAXhcoqDIBZh(eSwLnIXJJYSDxFSCtBhAwsETkqcW))
		{
			return SjzlpFSlqrCQgjcvjsqLSalXKPAZA(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		}
		return true;
	}

	public bool vSWUdGcGPCsovkdUTjxwVgIglOgV(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => SjzlpFSlqrCQgjcvjsqLSalXKPAZA(gQAmECSKPLTadxHHbPPNNyLrJMKU), 
			ControllerType.Keyboard => iHCxmbBGMPfmjjmmeAXhcoqDIBZh(eSwLnIXJJYSDxFSCtBhAwsETkqcW), 
			ControllerType.Mouse => iHCxmbBGMPfmjjmmeAXhcoqDIBZh(ZBRfotJecEwgyCEGjexSASReSxJR), 
			ControllerType.Custom => SjzlpFSlqrCQgjcvjsqLSalXKPAZA(eyTsgKEJSFkqCXOzDegTrvlZiykgA), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool TuAodslkIZrjpSosMGkHBpWqcaBgA()
	{
		if (!TmBVWoATHZTIhhLOoqUEfKdHSWZH(ZBRfotJecEwgyCEGjexSASReSxJR) && !xlYhyGVDmIACYeFdgEgJueGXeWcv(gQAmECSKPLTadxHHbPPNNyLrJMKU) && !TmBVWoATHZTIhhLOoqUEfKdHSWZH(eSwLnIXJJYSDxFSCtBhAwsETkqcW))
		{
			return xlYhyGVDmIACYeFdgEgJueGXeWcv(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		}
		return true;
	}

	public bool IfoZxEkXLVzqvynTjzBVOWqUZLqA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => xlYhyGVDmIACYeFdgEgJueGXeWcv(gQAmECSKPLTadxHHbPPNNyLrJMKU), 
			ControllerType.Keyboard => TmBVWoATHZTIhhLOoqUEfKdHSWZH(eSwLnIXJJYSDxFSCtBhAwsETkqcW), 
			ControllerType.Mouse => TmBVWoATHZTIhhLOoqUEfKdHSWZH(ZBRfotJecEwgyCEGjexSASReSxJR), 
			ControllerType.Custom => xlYhyGVDmIACYeFdgEgJueGXeWcv(eyTsgKEJSFkqCXOzDegTrvlZiykgA), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool oFOMmQSwiGPFhvZvQJmTdYNsGkVM<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	private bool MWdFDwEtUAELhJsCqTNLqyhaHPpW(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool SXZqCKxMOIHKBjmIMgtFMkrEedajb<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	private bool KNngFFqpARlwRvHGkQoMFgahCxZBA(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool pXXavaAkoUEPqgvvMSeUgAcqSuaDb<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	private bool OIBOBGLeNSAyMRmXngiLnwZGnVJI(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool SjzlpFSlqrCQgjcvjsqLSalXKPAZA<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	private bool iHCxmbBGMPfmjjmmeAXhcoqDIBZh(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool xlYhyGVDmIACYeFdgEgJueGXeWcv<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	private bool TmBVWoATHZTIhhLOoqUEfKdHSWZH(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller wGgMEpxCjvhhuISjQawEtoYwZOXn()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(ZBRfotJecEwgyCEGjexSASReSxJR, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(eSwLnIXJJYSDxFSCtBhAwsETkqcW, ref lastController, ref lastTime);
		IList<Joystick> list = gQAmECSKPLTadxHHbPPNNyLrJMKU;
		for (int i = 0; i < BZmSVymcSLcbcCvESSRKrvmAIKVl; i++)
		{
			InputTools.CompareLastActiveController(list[i], ref lastController, ref lastTime);
		}
		IList<CustomController> list2 = eyTsgKEJSFkqCXOzDegTrvlZiykgA;
		for (int j = 0; j < egKAiAdlTOlVwxeoUjfWqxVINyPOA; j++)
		{
			InputTools.CompareLastActiveController(list2[j], ref lastController, ref lastTime);
		}
		if (jHmCsYpyQRIEEOebXRQZKlQKALrGA >= 0)
		{
			Controller controller = uNJmTUUZIgxCnlFgJshQMfTyrJwA(evGkzJxqUvEEVmUIPQplpAggMbbn, jHmCsYpyQRIEEOebXRQZKlQKALrGA);
			if (controller != null && sJPEpKTApnrPTQmdFXJcjncEsVyJ >= lastTime)
			{
				lastController = controller;
				lastTime = sJPEpKTApnrPTQmdFXJcjncEsVyJ;
			}
		}
		if (lastController == null)
		{
			lastController = eSwLnIXJJYSDxFSCtBhAwsETkqcW;
		}
		return lastController;
	}

	public Controller SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(gQAmECSKPLTadxHHbPPNNyLrJMKU[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return dqlVbgwiwbhfyZlhzyrqssSByBAe;
		case ControllerType.Mouse:
			return tAQmtNcIHgKfFSRzKoZtyWPabvG;
		case ControllerType.Custom:
		{
			int count = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(eyTsgKEJSFkqCXOzDegTrvlZiykgA[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		if (jHmCsYpyQRIEEOebXRQZKlQKALrGA >= 0 && P_0 == evGkzJxqUvEEVmUIPQplpAggMbbn)
		{
			Controller controller = uNJmTUUZIgxCnlFgJshQMfTyrJwA(evGkzJxqUvEEVmUIPQplpAggMbbn, jHmCsYpyQRIEEOebXRQZKlQKALrGA);
			if (controller != null && sJPEpKTApnrPTQmdFXJcjncEsVyJ >= lastTime)
			{
				lastController = controller;
				lastTime = sJPEpKTApnrPTQmdFXJcjncEsVyJ;
			}
		}
		return lastController;
	}

	public _0001 wGgMEpxCjvhhuISjQawEtoYwZOXn<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType WgkKZFCcEbXZwUTaqLGrJjeUUNOy()
	{
		return wGgMEpxCjvhhuISjQawEtoYwZOXn()?.type ?? ControllerType.Keyboard;
	}

	public bool fOFmHFQepZixSMRoZacUitUNUVeS(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!ABLVaoSDSMrbAutSRyVrpplTNFGf.Contains(P_0))
		{
			return false;
		}
		jHmCsYpyQRIEEOebXRQZKlQKALrGA = P_0.id;
		evGkzJxqUvEEVmUIPQplpAggMbbn = P_0.type;
		sJPEpKTApnrPTQmdFXJcjncEsVyJ = ReInput.unscaledTime;
		return true;
	}

	public void KlqDiCqRMsjPOFHPzPaoUXYEgFzR(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			fbMIQdJqFljXLpYKuivuxaJHIXOGA = true;
			vmRIuKuHSYArPsdUNEivAkmKnEjz.pxYjNyFKbMJKesXXURVqWxyEJAie(P_0);
		}
	}

	public void sFDUYkeQsmiZlgqybsiaxnxFhzTB(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			fbMIQdJqFljXLpYKuivuxaJHIXOGA = true;
			vmRIuKuHSYArPsdUNEivAkmKnEjz.mDLOMolFDItjZPGcdGRQnIXYSpoc(P_0, P_1);
		}
	}

	public void byZbRperAgUbuSkGxkDTkpuWvysM(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			vmRIuKuHSYArPsdUNEivAkmKnEjz.MQhJBtvZSENpXeqDhgwVjQTuzPG(P_0);
		}
	}

	public void mOtnInayTXPStQTAObRbJHdBzIWH(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			vmRIuKuHSYArPsdUNEivAkmKnEjz.JlTFAPGOxKUvQOifNSwXSUhKGjRi(P_0, P_1);
		}
	}

	public void GVqFuFAaZEbVUkwCrwQWFmdlHgyiA()
	{
		vmRIuKuHSYArPsdUNEivAkmKnEjz.SHwPpcQEZpeCNkDXaZXHWlZGtUKh();
	}

	public void kItNvsztfCLiCwKpEaQlrGrvCqET(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			UOTLBXTbNoghTewWSzNUbCDGPJGQ.pxYjNyFKbMJKesXXURVqWxyEJAie(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)UgNlMdzvHrBtBaBcBioGcLSZaIrh)
			{
				return;
			}
			EZFSArzEckeHEiakMdDSruSPigjA[P_0].pxYjNyFKbMJKesXXURVqWxyEJAie(P_1);
		}
		fbMIQdJqFljXLpYKuivuxaJHIXOGA = true;
	}

	public void HCWzIyYxjAPfJxGJceitFyBWkGUT(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			UOTLBXTbNoghTewWSzNUbCDGPJGQ.mDLOMolFDItjZPGcdGRQnIXYSpoc(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)UgNlMdzvHrBtBaBcBioGcLSZaIrh)
			{
				return;
			}
			EZFSArzEckeHEiakMdDSruSPigjA[P_0].mDLOMolFDItjZPGcdGRQnIXYSpoc(P_1, P_2);
		}
		fbMIQdJqFljXLpYKuivuxaJHIXOGA = true;
	}

	public void xxwvPwFhmkkYRmXmWJpCfIFRCwvp(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				UOTLBXTbNoghTewWSzNUbCDGPJGQ.MQhJBtvZSENpXeqDhgwVjQTuzPG(P_1);
			}
			else if ((uint)P_0 < (uint)UgNlMdzvHrBtBaBcBioGcLSZaIrh)
			{
				EZFSArzEckeHEiakMdDSruSPigjA[P_0].MQhJBtvZSENpXeqDhgwVjQTuzPG(P_1);
			}
		}
	}

	public void vypSSlmVDFnXkzySpdHqTFAkhfHC(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				UOTLBXTbNoghTewWSzNUbCDGPJGQ.JlTFAPGOxKUvQOifNSwXSUhKGjRi(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)UgNlMdzvHrBtBaBcBioGcLSZaIrh)
			{
				EZFSArzEckeHEiakMdDSruSPigjA[P_0].JlTFAPGOxKUvQOifNSwXSUhKGjRi(P_1, P_2);
			}
		}
	}

	public void umhjZkCLWUHNEAduNFudIlIwMITb(int P_0)
	{
		if (P_0 == 9999999)
		{
			UOTLBXTbNoghTewWSzNUbCDGPJGQ.SHwPpcQEZpeCNkDXaZXHWlZGtUKh();
		}
		else if ((uint)P_0 < (uint)UgNlMdzvHrBtBaBcBioGcLSZaIrh)
		{
			EZFSArzEckeHEiakMdDSruSPigjA[P_0].SHwPpcQEZpeCNkDXaZXHWlZGtUKh();
		}
	}

	private void rIlYoLIBZgMuVjRmPEPXxEylEvHcA()
	{
		if (vmRIuKuHSYArPsdUNEivAkmKnEjz.nmSeymvmgowHbwrVwdFoHSzfJPjOA > 0)
		{
			vmRIuKuHSYArPsdUNEivAkmKnEjz.ptuZctsirfSPIzMhZaCxEivDscpc(-1, wGgMEpxCjvhhuISjQawEtoYwZOXn(), SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Joystick), SqKxZkLdhnAslJoioHFriMCAilEub(ControllerType.Custom));
		}
		if (UOTLBXTbNoghTewWSzNUbCDGPJGQ.nmSeymvmgowHbwrVwdFoHSzfJPjOA > 0)
		{
			Player.ControllerHelper controllers = STAPHPSFjtiVXYUuDrtfswVgsJVM.cbWeSIcpBJHiLSZzDUKykXKZEoiKA().controllers;
			UOTLBXTbNoghTewWSzNUbCDGPJGQ.ptuZctsirfSPIzMhZaCxEivDscpc(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < UgNlMdzvHrBtBaBcBioGcLSZaIrh; i++)
		{
			if (EZFSArzEckeHEiakMdDSruSPigjA[i].nmSeymvmgowHbwrVwdFoHSzfJPjOA != 0)
			{
				Player.ControllerHelper controllers2 = STAPHPSFjtiVXYUuDrtfswVgsJVM.xZpRDoxZuRLXgRBJebkaGhKZHgjCA[i].controllers;
				EZFSArzEckeHEiakMdDSruSPigjA[i].ptuZctsirfSPIzMhZaCxEivDscpc(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void FbKrVvakyqalEEZGRgQDiQMzkPFW(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < gQAmECSKPLTadxHHbPPNNyLrJMKU.Count; i++)
		{
			if (gQAmECSKPLTadxHHbPPNNyLrJMKU[i] != null)
			{
				cJFwEImvdVPPvHXpnOsbWnUUCeqd(gQAmECSKPLTadxHHbPPNNyLrJMKU[i], P_0);
			}
		}
		for (int j = 0; j < NgEIfYnPYrpZwkLvTyhoMrhhsUVi.Count; j++)
		{
			if (NgEIfYnPYrpZwkLvTyhoMrhhsUVi[j] != null)
			{
				cJFwEImvdVPPvHXpnOsbWnUUCeqd(NgEIfYnPYrpZwkLvTyhoMrhhsUVi[j], P_0);
			}
		}
		for (int k = 0; k < egKAiAdlTOlVwxeoUjfWqxVINyPOA; k++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[k] != null)
			{
				cJFwEImvdVPPvHXpnOsbWnUUCeqd(eyTsgKEJSFkqCXOzDegTrvlZiykgA[k], P_0);
			}
		}
		cJFwEImvdVPPvHXpnOsbWnUUCeqd(ZBRfotJecEwgyCEGjexSASReSxJR, P_0);
	}

	private void cJFwEImvdVPPvHXpnOsbWnUUCeqd(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].VjHSioMESUvcoZNTLZGzLmnuVlxf._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> ohGovAyBeejNnliFDGftyOIllKAM<_0001>() where _0001 : IControllerTemplate
	{
		return ONbZarGoOFkuLsUTedkCSslONfXV.pUbgQJGJJLcmIloEyGrUBDcSjNAY<_0001>();
	}

	private void upwHWrVIkRDTgPFBxOZaFkLESIKS(List<InputBehavior> P_0)
	{
		DeodXOYecDehAMWweDQhdpVRTvqdA = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw;
		STAPHPSFjtiVXYUuDrtfswVgsJVM = ReInput.kaDCuNAiSdnlkLeWRajALqrXMggab;
		gQAmECSKPLTadxHHbPPNNyLrJMKU = new List<Joystick>();
		NgEIfYnPYrpZwkLvTyhoMrhhsUVi = new List<Joystick>();
		eyTsgKEJSFkqCXOzDegTrvlZiykgA = new List<CustomController>();
		dqAziZXQlnKHMuKyTcTermKVINiz = DeodXOYecDehAMWweDQhdpVRTvqdA.WnFeyUIrIriYEMOToHgDIInXSDkM;
		UgNlMdzvHrBtBaBcBioGcLSZaIrh = STAPHPSFjtiVXYUuDrtfswVgsJVM.tpdryKsrOUTmelygFJMwPYWdGpuT;
		nGBDFjbhYFOQBJoEjqXQZMNKIdS = uxvQESuanUrOiHEtbpAjupQeVGEC;
		pRGwIDEdGrlfknaJbcMieYnpomIP = 0;
		ddZpKZpnssfnRPFWlsFVCgvtDUCK = new ADictionary<int, jUqcElLDWWskhhMkCdSZmvFBVzoK>();
		ddZpKZpnssfnRPFWlsFVCgvtDUCK.Add(ReInput.players.GetSystemPlayer().id, new jUqcElLDWWskhhMkCdSZmvFBVzoK(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			ddZpKZpnssfnRPFWlsFVCgvtDUCK.Add(players[i].id, new jUqcElLDWWskhhMkCdSZmvFBVzoK(P_0));
		}
		JHUfetjSwcwNwUTyDFHtyhhSCgjrA = new ReadOnlyCollection<Joystick>(gQAmECSKPLTadxHHbPPNNyLrJMKU);
		ZEmTqwstOroTayFyqATdLbrMhQfv = new ReadOnlyCollection<CustomController>(eyTsgKEJSFkqCXOzDegTrvlZiykgA);
		ULWotIhqUFBdhwlfsIksjyZhzzXLA.sYYDEXvpcinBWpZsnlkaeIRbbuRe(lbvtyLZHjFUNXRHndFQYyvGGagaW);
		FldIgLCXtPTMXEQqtahjaKctsavc = new ULWotIhqUFBdhwlfsIksjyZhzzXLA[(UgNlMdzvHrBtBaBcBioGcLSZaIrh + 1) * dqAziZXQlnKHMuKyTcTermKVINiz];
		int num = 0;
		uAkMkILgAmOkiUmCWOfrCArwkFwl = new ULWotIhqUFBdhwlfsIksjyZhzzXLA[dqAziZXQlnKHMuKyTcTermKVINiz];
		for (int j = 0; j < dqAziZXQlnKHMuKyTcTermKVINiz; j++)
		{
			InputAction inputAction = DeodXOYecDehAMWweDQhdpVRTvqdA.TftdlthJgOgjdQtIjvcGvMqKVXpP(j);
			InputBehavior inputBehavior = ddZpKZpnssfnRPFWlsFVCgvtDUCK[9999999].MFuWebGAIBVUBPqEwfvSyzySgPLI(inputAction.behaviorId);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = new ULWotIhqUFBdhwlfsIksjyZhzzXLA(9999999, inputAction, inputBehavior, lbvtyLZHjFUNXRHndFQYyvGGagaW);
			uAkMkILgAmOkiUmCWOfrCArwkFwl[j] = uLWotIhqUFBdhwlfsIksjyZhzzXLA;
			FldIgLCXtPTMXEQqtahjaKctsavc[num] = uLWotIhqUFBdhwlfsIksjyZhzzXLA;
			num++;
		}
		vQfiZdcXOoAkGITxFZRTRFocDvCU = new ULWotIhqUFBdhwlfsIksjyZhzzXLA[UgNlMdzvHrBtBaBcBioGcLSZaIrh, dqAziZXQlnKHMuKyTcTermKVINiz];
		for (int k = 0; k < UgNlMdzvHrBtBaBcBioGcLSZaIrh; k++)
		{
			for (int l = 0; l < dqAziZXQlnKHMuKyTcTermKVINiz; l++)
			{
				InputAction inputAction2 = DeodXOYecDehAMWweDQhdpVRTvqdA.TftdlthJgOgjdQtIjvcGvMqKVXpP(l);
				InputBehavior inputBehavior2 = ddZpKZpnssfnRPFWlsFVCgvtDUCK[players[k].id].MFuWebGAIBVUBPqEwfvSyzySgPLI(inputAction2.behaviorId);
				ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA2 = new ULWotIhqUFBdhwlfsIksjyZhzzXLA(k, inputAction2, inputBehavior2, lbvtyLZHjFUNXRHndFQYyvGGagaW);
				vQfiZdcXOoAkGITxFZRTRFocDvCU[k, l] = uLWotIhqUFBdhwlfsIksjyZhzzXLA2;
				FldIgLCXtPTMXEQqtahjaKctsavc[num] = uLWotIhqUFBdhwlfsIksjyZhzzXLA2;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.vdPnOLKbJBrenRKPKDLPhLsjfLpuA;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < list.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = list[m].startingCustomControllers;
			if (startingCustomControllers == null)
			{
				continue;
			}
			for (int n = 0; n < startingCustomControllers.Count; n++)
			{
				CustomController customController = wdCMlfofKsEmCXsYcusWVzNpaPIt(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					STAPHPSFjtiVXYUuDrtfswVgsJVM.lDoHnmryxjmnpsBMkafFfmrvyKiB(num2)?.controllers.AHYhGcLLXfDPhJHdzQkZUnJzyJdr(customController, false);
				}
			}
		}
		ItwgjikaczpArIZZrYHShnIFWDiL = new uNUJNNadqmDFujCsBrlAGsjEbLTu();
		ITMaMibUiXabsfRnKwcbBReGDmIsB = new uNUJNNadqmDFujCsBrlAGsjEbLTu[UgNlMdzvHrBtBaBcBioGcLSZaIrh];
		for (int num3 = 0; num3 < UgNlMdzvHrBtBaBcBioGcLSZaIrh; num3++)
		{
			ITMaMibUiXabsfRnKwcbBReGDmIsB[num3] = new uNUJNNadqmDFujCsBrlAGsjEbLTu();
		}
		vmRIuKuHSYArPsdUNEivAkmKnEjz = new global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<ActiveControllerChangedDelegate>();
		UOTLBXTbNoghTewWSzNUbCDGPJGQ = new global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<PlayerActiveControllerChangedDelegate>();
		EZFSArzEckeHEiakMdDSruSPigjA = new global::MhrDGSPWfvQRuTYyBwKWZSIWRpKK<PlayerActiveControllerChangedDelegate>[STAPHPSFjtiVXYUuDrtfswVgsJVM.tpdryKsrOUTmelygFJMwPYWdGpuT];
		ArrayTools.Populate(EZFSArzEckeHEiakMdDSruSPigjA);
	}

	private void IbpdaWclKCoBVpNUqhEMCYRyjqgwA(UpdateLoopType P_0)
	{
		int count = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = gQAmECSKPLTadxHHbPPNNyLrJMKU[i];
			if (joystick.enabled)
			{
				AcRdPGYuTOjXuEimnUCSIlIszmCe(joystick.rtdfUzEJbwgxmtELKImThFtLhgLkA, joystick.ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
				joystick.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
			}
		}
		if (eSwLnIXJJYSDxFSCtBhAwsETkqcW.enabled)
		{
			eSwLnIXJJYSDxFSCtBhAwsETkqcW.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
		}
		else if (qtAkVAzbEgVMATMioEaaSklGVRdD)
		{
			eSwLnIXJJYSDxFSCtBhAwsETkqcW.yZoZqbIcmDkBeWpbYEsSspMtNThW(P_0);
		}
		if (ZBRfotJecEwgyCEGjexSASReSxJR.enabled)
		{
			ZBRfotJecEwgyCEGjexSASReSxJR.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
		}
		int count2 = eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = eyTsgKEJSFkqCXOzDegTrvlZiykgA[j];
			if (customController.enabled)
			{
				customController.YwaBklKtnduwXFPUllzVWXhARgBUA();
				customController.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
			}
		}
	}

	private void wTsNWwmoYLFQeKqLWIgWxGEoDdBKA(UpdateLoopType P_0)
	{
		ULWotIhqUFBdhwlfsIksjyZhzzXLA.WuENaNsKgdWcATJYlArCPVHYWssh(P_0);
		Player[] array = STAPHPSFjtiVXYUuDrtfswVgsJVM.mnSetJQxxTJeOBjwJaXsLInXQadT;
		int num = array.Length;
		bool enabled = eSwLnIXJJYSDxFSCtBhAwsETkqcW.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = array[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						fKJQOpXuCvfUQCPdujENIgJxEQpP.nGoRHAMLLCcBDkdhIeQAZrygKdtdb(maps[j]);
					}
				}
			}
		}
		bool enabled2 = ZBRfotJecEwgyCEGjexSASReSxJR.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.PLGyjixFHHBkuOJvmdxVErQHNJye(nGBDFjbhYFOQBJoEjqXQZMNKIdS);
			if (enabled || qtAkVAzbEgVMATMioEaaSklGVRdD)
			{
				controllers.ibwEHkGGoEoDdmxeltZwKqrDfsBMA(eSwLnIXJJYSDxFSCtBhAwsETkqcW, fKJQOpXuCvfUQCPdujENIgJxEQpP, nGBDFjbhYFOQBJoEjqXQZMNKIdS);
			}
			if (enabled2)
			{
				controllers.eammjAsuAbKGclDduvqewxJshqQk(ZBRfotJecEwgyCEGjexSASReSxJR, nGBDFjbhYFOQBJoEjqXQZMNKIdS);
			}
			controllers.epeWeAWEMmperuTmgoNPDoUhOxSv(nGBDFjbhYFOQBJoEjqXQZMNKIdS);
		}
		for (int l = 0; l < FldIgLCXtPTMXEQqtahjaKctsavc.Length; l++)
		{
			if (FldIgLCXtPTMXEQqtahjaKctsavc[l].yDWEIWgyRwzFIvHUGXNfGyHxIdOv != ULWotIhqUFBdhwlfsIksjyZhzzXLA.bCRFLybzCrsBdPVUgpWlHyzLWBbl.Disabled)
			{
				FldIgLCXtPTMXEQqtahjaKctsavc[l].eGStfGBjoOHMkKtAqyJhawnBRAWB();
			}
		}
		ULWotIhqUFBdhwlfsIksjyZhzzXLA.WuWTKtxpUaVilraEoASwSfPAcTRBA();
		if (!pRdVtFlUUdijWyOVKnbIjvjHCBTE)
		{
			return;
		}
		if (ItwgjikaczpArIZZrYHShnIFWDiL.TfLmHoQfTGnihrPObIBtbLImFktSA > 0)
		{
			for (int m = 0; m < dqAziZXQlnKHMuKyTcTermKVINiz; m++)
			{
				ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = uAkMkILgAmOkiUmCWOfrCArwkFwl[m];
				if (uLWotIhqUFBdhwlfsIksjyZhzzXLA.yDWEIWgyRwzFIvHUGXNfGyHxIdOv != ULWotIhqUFBdhwlfsIksjyZhzzXLA.bCRFLybzCrsBdPVUgpWlHyzLWBbl.Disabled)
				{
					ItwgjikaczpArIZZrYHShnIFWDiL.YURXkFoEwxFUUbtcyndZmPHgxQcTA(uLWotIhqUFBdhwlfsIksjyZhzzXLA, P_0);
				}
			}
		}
		for (int n = 0; n < UgNlMdzvHrBtBaBcBioGcLSZaIrh; n++)
		{
			uNUJNNadqmDFujCsBrlAGsjEbLTu uNUJNNadqmDFujCsBrlAGsjEbLTu2 = ITMaMibUiXabsfRnKwcbBReGDmIsB[n];
			if (uNUJNNadqmDFujCsBrlAGsjEbLTu2.TfLmHoQfTGnihrPObIBtbLImFktSA == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < dqAziZXQlnKHMuKyTcTermKVINiz; num2++)
			{
				ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA2 = vQfiZdcXOoAkGITxFZRTRFocDvCU[n, num2];
				if (uLWotIhqUFBdhwlfsIksjyZhzzXLA2.yDWEIWgyRwzFIvHUGXNfGyHxIdOv != ULWotIhqUFBdhwlfsIksjyZhzzXLA.bCRFLybzCrsBdPVUgpWlHyzLWBbl.Disabled)
				{
					uNUJNNadqmDFujCsBrlAGsjEbLTu2.YURXkFoEwxFUUbtcyndZmPHgxQcTA(uLWotIhqUFBdhwlfsIksjyZhzzXLA2, P_0);
				}
			}
		}
	}

	private void uxvQESuanUrOiHEtbpAjupQeVGEC(bool P_0, int P_1, int P_2)
	{
		int num = DeodXOYecDehAMWweDQhdpVRTvqdA.gwGPJXsVmpnHcrNmpYDODSJzdJJn(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				uAkMkILgAmOkiUmCWOfrCArwkFwl[num].NvEUuSXgLpASNEEKmXvssyEgiNLgA(P_0);
			}
			else
			{
				vQfiZdcXOoAkGITxFZRTRFocDvCU[P_1, num].NvEUuSXgLpASNEEKmXvssyEgiNLgA(P_0);
			}
		}
	}

	private void PIbwcKaIHTCMVQfQTgKTGeBOkGsab(BridgedController P_0)
	{
		int num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0.sourceJoystick.rewiredId, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = jbwjrtagZYLWanzcUlRGkITHBxGpA(P_0.sourceJoystick.rewiredId, uxaCQNhjmsRztFwNLhXzaVqhhPmhA.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = NgEIfYnPYrpZwkLvTyhoMrhhsUVi[num];
			NgEIfYnPYrpZwkLvTyhoMrhhsUVi.RemoveAt(num);
			joystick.dPRUbYYoatgmhVCncCRYAwquHoFY(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		gQAmECSKPLTadxHHbPPNNyLrJMKU.Add(joystick);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Add(joystick);
		gQAmECSKPLTadxHHbPPNNyLrJMKU.Sort(Joystick.WTftbWcLcDIBqHuWnuQyoVSnesSs);
		ONbZarGoOFkuLsUTedkCSslONfXV.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(joystick);
	}

	private void WXPVYwKbkMlcGvyjoichcFxtaaNf(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= gQAmECSKPLTadxHHbPPNNyLrJMKU.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = gQAmECSKPLTadxHHbPPNNyLrJMKU[P_0];
		joystick.isConnected = false;
		if (LGYLyYnpmCjGoyvMiUcIRZZAtRpJ != null)
		{
			LGYLyYnpmCjGoyvMiUcIRZZAtRpJ(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (tRIAnlzNgVYHzlOGLjECbZzztXHPA != null)
		{
			tRIAnlzNgVYHzlOGLjECbZzztXHPA(joystick.type, joystick.id);
		}
		gQAmECSKPLTadxHHbPPNNyLrJMKU.RemoveAt(P_0);
		NgEIfYnPYrpZwkLvTyhoMrhhsUVi.Add(joystick);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Remove(joystick);
		ONbZarGoOFkuLsUTedkCSslONfXV.cKhLpzZdxbLRWdRHngLGhLGhgriC(joystick);
		joystick.DupAFRZPigDCXHzKZjcpbnZzkuAX();
	}

	private void NuhGzyOFTuhwDpoKccoeUDdoBwzp()
	{
		for (int num = gQAmECSKPLTadxHHbPPNNyLrJMKU.Count - 1; num >= 0; num--)
		{
			WXPVYwKbkMlcGvyjoichcFxtaaNf(num);
		}
	}

	private bool sRixWidcxvbGiVDzXIbcYhkIGjSBA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count; i++)
		{
			if (eyTsgKEJSFkqCXOzDegTrvlZiykgA[i] == P_0)
			{
				return true;
			}
		}
		eyTsgKEJSFkqCXOzDegTrvlZiykgA.Add(P_0);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Add(P_0);
		ONbZarGoOFkuLsUTedkCSslONfXV.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(P_0);
		return true;
	}

	private bool uTODXCdCpOECNgrpHtHWSNVpvoeMA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		ONbZarGoOFkuLsUTedkCSslONfXV.cKhLpzZdxbLRWdRHngLGhLGhgriC(P_0);
		ABLVaoSDSMrbAutSRyVrpplTNFGf.Remove(P_0);
		return eyTsgKEJSFkqCXOzDegTrvlZiykgA.Remove(P_0);
	}

	private uNUJNNadqmDFujCsBrlAGsjEbLTu DgZaVndUQvkQYwebSfKTpxTMYtOtA(int P_0)
	{
		if (P_0 == 9999999)
		{
			return ItwgjikaczpArIZZrYHShnIFWDiL;
		}
		if (P_0 < 0 || P_0 >= ReInput.kaDCuNAiSdnlkLeWRajALqrXMggab.tpdryKsrOUTmelygFJMwPYWdGpuT)
		{
			return null;
		}
		return ITMaMibUiXabsfRnKwcbBReGDmIsB[P_0];
	}

	private void kcQHOjXmvoeOTtYxMIEcXZffYAng(bool P_0)
	{
		if (!P_0)
		{
			fKJQOpXuCvfUQCPdujENIgJxEQpP.DyduMDxbXpSzjafEjRATPzFkXBoE();
		}
	}

	private void oihuzraYdJVionCgvnTNFQEFNfAC(bool P_0)
	{
		eSwLnIXJJYSDxFSCtBhAwsETkqcW.XcWhcMJqTFZzVMdmfmExVlrEKelfb(P_0);
		ZBRfotJecEwgyCEGjexSASReSxJR.XcWhcMJqTFZzVMdmfmExVlrEKelfb(P_0);
		for (int i = 0; i < gQAmECSKPLTadxHHbPPNNyLrJMKU.Count; i++)
		{
			gQAmECSKPLTadxHHbPPNNyLrJMKU[i].XcWhcMJqTFZzVMdmfmExVlrEKelfb(P_0);
		}
		for (int j = 0; j < eyTsgKEJSFkqCXOzDegTrvlZiykgA.Count; j++)
		{
			eyTsgKEJSFkqCXOzDegTrvlZiykgA[j].XcWhcMJqTFZzVMdmfmExVlrEKelfb(P_0);
		}
	}

	public void Dispose()
	{
		WELQumunmpxAJCZRqHIQAtuvBmdu(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void iBSLWJfcbpdvnBWIXEnuPxdzdFLb()
	{
		try
		{
			WELQumunmpxAJCZRqHIQAtuvBmdu(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void WELQumunmpxAJCZRqHIQAtuvBmdu(bool P_0)
	{
		if (PYGEiBZbbvEJkhZsPkEktsCBBaLRA)
		{
			return;
		}
		if (P_0)
		{
			if (JxhPSZQneqigAFnlStxhagiXSINt is IDisposable)
			{
				(JxhPSZQneqigAFnlStxhagiXSINt as IDisposable).Dispose();
			}
			if (XflMuxPzKyOpgScQZImwZeXqARDE is IDisposable)
			{
				(XflMuxPzKyOpgScQZImwZeXqARDE as IDisposable).Dispose();
			}
		}
		PYGEiBZbbvEJkhZsPkEktsCBBaLRA = true;
	}
}
