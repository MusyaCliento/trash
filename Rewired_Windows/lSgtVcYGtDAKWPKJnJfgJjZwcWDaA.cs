using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal abstract class lSgtVcYGtDAKWPKJnJfgJjZwcWDaA : QMQjWbDoKRhaRVmjlawINgNoJnPr, IDisposable
{
	public sealed class wcsXWfcIIJlNTQPXVUXBwsUKvnEj
	{
		public struct UqYBDTbKryfPVwSxckVXPuEbGOBx
		{
			public RImcHFOqxsreyFrUWhEbpJpyeGGR ErZakShiznZZTgbqJGGQDqWVHGzEA;

			public double DjeieTOLAgzjhdcVHgcctQovdkzG;

			public UqYBDTbKryfPVwSxckVXPuEbGOBx(RImcHFOqxsreyFrUWhEbpJpyeGGR P_0, double P_1)
			{
				ErZakShiznZZTgbqJGGQDqWVHGzEA = P_0;
				DjeieTOLAgzjhdcVHgcctQovdkzG = P_1;
			}
		}

		public enum RImcHFOqxsreyFrUWhEbpJpyeGGR
		{
			None = 0,
			AsyncInitialization = 1,
			Unknown = 2
		}

		private class kRLEADWScBNwptnxRsFkRetYvNwt
		{
			public const int cVDZdjXOWcajqCqybhfBjLaJNrrwb = 10;

			public readonly string tJOsMMlMfnJEeeSWHlaVJFEwgIEx;

			public readonly List<UqYBDTbKryfPVwSxckVXPuEbGOBx> KbIYnhBGKGLLKkceQFgHXCgzEsJT;

			public bool hnfOESOJKqXacNCqshfZgCPlfeJU;

			public kRLEADWScBNwptnxRsFkRetYvNwt(string P_0)
			{
				KbIYnhBGKGLLKkceQFgHXCgzEsJT = new List<UqYBDTbKryfPVwSxckVXPuEbGOBx>();
				tJOsMMlMfnJEeeSWHlaVJFEwgIEx = P_0;
			}
		}

		private static wcsXWfcIIJlNTQPXVUXBwsUKvnEj ciQavIpzVQqolUhuzpZPjTrDKveV;

		private readonly Dictionary<string, kRLEADWScBNwptnxRsFkRetYvNwt> mXJyzbwylbGKLnXspylOlfkgbQfD = new Dictionary<string, kRLEADWScBNwptnxRsFkRetYvNwt>();

		private readonly SpinLock ECPXJfwuUKBbUfhTodfyxuWwUpzc = new SpinLock();

		public static wcsXWfcIIJlNTQPXVUXBwsUKvnEj uUcFQFGOzBePNzdIqVvalzVKnmApA
		{
			get
			{
				if (ciQavIpzVQqolUhuzpZPjTrDKveV == null)
				{
					ciQavIpzVQqolUhuzpZPjTrDKveV = new wcsXWfcIIJlNTQPXVUXBwsUKvnEj();
					ReInput.ShutDownEvent += TykXmIWEeKuHGVVAuWlHPnrfPvKi;
				}
				return ciQavIpzVQqolUhuzpZPjTrDKveV;
			}
		}

		public int HiwtRtpTlOzoQquaPjmvADdebgci(string P_0, RImcHFOqxsreyFrUWhEbpJpyeGGR P_1)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (!mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Count; i++)
				{
					if ((value.KbIYnhBGKGLLKkceQFgHXCgzEsJT[i].ErZakShiznZZTgbqJGGQDqWVHGzEA & P_1) == 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int GbnNXyqqnxcPAgKjmkRSrOSjKwvh(string P_0, RImcHFOqxsreyFrUWhEbpJpyeGGR P_1, float P_2)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (!mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					return 0;
				}
				double num = ReInput.realTime - (double)P_2;
				int num2 = 0;
				for (int i = 0; i < value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Count; i++)
				{
					if (!(value.KbIYnhBGKGLLKkceQFgHXCgzEsJT[i].DjeieTOLAgzjhdcVHgcctQovdkzG < num) || (value.KbIYnhBGKGLLKkceQFgHXCgzEsJT[i].ErZakShiznZZTgbqJGGQDqWVHGzEA & P_1) == 0)
					{
						num2++;
					}
				}
				return num2;
			}
		}

		public int fXoqGcfwWNffUOgqzMdHMJwTKlXc(string P_0, IList<UqYBDTbKryfPVwSxckVXPuEbGOBx> P_1)
		{
			int count = P_1.Count;
			if (mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
			{
				for (int i = 0; i < value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Count; i++)
				{
					P_1.Add(value.KbIYnhBGKGLLKkceQFgHXCgzEsJT[i]);
				}
			}
			return P_1.Count - count;
		}

		public void MxpPIYxavafqvNHTjrWCRCQlliLL(string P_0, RImcHFOqxsreyFrUWhEbpJpyeGGR P_1)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (!mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					value = new kRLEADWScBNwptnxRsFkRetYvNwt(P_0);
					mXJyzbwylbGKLnXspylOlfkgbQfD.Add(P_0, value);
				}
				while (value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Count >= 10)
				{
					value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.RemoveAt(0);
				}
				value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Add(new UqYBDTbKryfPVwSxckVXPuEbGOBx(P_1, ReInput.realTime));
			}
		}

		public void YfvoKxYocglYHxmKQEzyainujoIH(string P_0)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					value.KbIYnhBGKGLLKkceQFgHXCgzEsJT.Clear();
				}
			}
		}

		public bool mjpxPVomBmkmMnNqqfXNdCvytvIm(string P_0)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					return value.hnfOESOJKqXacNCqshfZgCPlfeJU;
				}
			}
			return false;
		}

		public void NYUNxPxZnsTjrvWrqVuVoUlVbvZE(string P_0, bool P_1)
		{
			using (ECPXJfwuUKBbUfhTodfyxuWwUpzc.Lock())
			{
				if (!mXJyzbwylbGKLnXspylOlfkgbQfD.TryGetValue(P_0, out var value))
				{
					value = new kRLEADWScBNwptnxRsFkRetYvNwt(P_0);
					mXJyzbwylbGKLnXspylOlfkgbQfD.Add(P_0, value);
				}
				value.hnfOESOJKqXacNCqshfZgCPlfeJU = P_1;
			}
		}

		private static void TykXmIWEeKuHGVVAuWlHPnrfPvKi()
		{
			ReInput.ShutDownEvent -= TykXmIWEeKuHGVVAuWlHPnrfPvKi;
			ciQavIpzVQqolUhuzpZPjTrDKveV = null;
		}
	}

	protected readonly yBATXoBSRnHIKCFttVvSrbcAKezC QLmawvCCFcIJCVfPjwAPrlkMMLpj;

	protected IntPtr TfyxcOhYELecfnjnVTdocJAjSCtu;

	protected readonly int NIrrwkBHRBKjCxwIRUeptNBStVvF;

	protected readonly int uZSIxNHHlAywKBJDzPvQJhUQdDZc;

	protected readonly Guid RmaUWULMKHsUyIHdwBkMUTlNQklU;

	protected readonly Guid YlOEeqvyCAaDACUuXSudVacKeGuDA;

	protected readonly DeviceType KMoDtiNxObfplPaUERlLmrjxHshu;

	protected readonly string jHfRpVmRjsmLsQbrPGzhcKOqlySt;

	private HIDDeviceDriver NiXLjbKgqCWFvicUHGVUiPvnDCOg;

	private readonly List<Controller.Extension> KjTefvEHHOcmPfJGIKeFKOWsmeezA;

	private readonly ReadOnlyCollection<Controller.Extension> UxNrfILAVwpVgxmNLtEjQXEtsiNd;

	private bool kFyLEodOLBokttElPRKyJAqHLIhX;

	private string sLTudtQKXACioCYiStGeyvtcfazw;

	private string MSIQODLCstYzgduIRkpbBmudsuML;

	private string yTygqkLWAxVegYIoGIhkjbHHYVsS;

	private bool UzEhrQvLbMCzBHJHbJxmidZnXzoT;

	private bool HjCgbGYhTNqqbfnghlmYKfhZwisV;

	private bool IuigssratldqukbSWrhKHXXeMGeG;

	yBATXoBSRnHIKCFttVvSrbcAKezC QMQjWbDoKRhaRVmjlawINgNoJnPr.DBTqBLqRsnBRzJXzDKTzOGLLAJiT => QLmawvCCFcIJCVfPjwAPrlkMMLpj;

	IntPtr QMQjWbDoKRhaRVmjlawINgNoJnPr.MUjMKpvlxHyNGczJsJjSwQNkRtcs => TfyxcOhYELecfnjnVTdocJAjSCtu;

	string QMQjWbDoKRhaRVmjlawINgNoJnPr.MJCEwRBVuVKSGDFqTrsuJVtjFKBab
	{
		get
		{
			if (!string.IsNullOrEmpty(sLTudtQKXACioCYiStGeyvtcfazw))
			{
				return sLTudtQKXACioCYiStGeyvtcfazw;
			}
			sLTudtQKXACioCYiStGeyvtcfazw = QLmawvCCFcIJCVfPjwAPrlkMMLpj.KBncbmUyuUuggqyiqOLXReBMpKYC();
			if (string.IsNullOrEmpty(sLTudtQKXACioCYiStGeyvtcfazw))
			{
				sLTudtQKXACioCYiStGeyvtcfazw = "Unknown";
			}
			return sLTudtQKXACioCYiStGeyvtcfazw;
		}
	}

	string QMQjWbDoKRhaRVmjlawINgNoJnPr.TpwfkVxStQbrzDQkYyLhIsDfkqmFA
	{
		get
		{
			if (UzEhrQvLbMCzBHJHbJxmidZnXzoT)
			{
				return MSIQODLCstYzgduIRkpbBmudsuML;
			}
			MSIQODLCstYzgduIRkpbBmudsuML = QLmawvCCFcIJCVfPjwAPrlkMMLpj.uBKpZXOtGhosxdINzCJUZYEjpoFK();
			UzEhrQvLbMCzBHJHbJxmidZnXzoT = true;
			return MSIQODLCstYzgduIRkpbBmudsuML;
		}
	}

	int QMQjWbDoKRhaRVmjlawINgNoJnPr.UIDBCQFGvhtUWvgAxequFCQKjHjA => NIrrwkBHRBKjCxwIRUeptNBStVvF;

	int QMQjWbDoKRhaRVmjlawINgNoJnPr.QhSgzIhvKfsJeIaXJhbIxtnlJSzmA => uZSIxNHHlAywKBJDzPvQJhUQdDZc;

	Guid QMQjWbDoKRhaRVmjlawINgNoJnPr.ivpdrYRhLgwLyrtsRFoaeEevvzRJ => RmaUWULMKHsUyIHdwBkMUTlNQklU;

	Guid QMQjWbDoKRhaRVmjlawINgNoJnPr.cJZeqceByQzQXVQhxbGYpsxUkUdnA => YlOEeqvyCAaDACUuXSudVacKeGuDA;

	DeviceType QMQjWbDoKRhaRVmjlawINgNoJnPr.vjwGglosJzWDxTNkOWbLuahYiiijA => KMoDtiNxObfplPaUERlLmrjxHshu;

	bool QMQjWbDoKRhaRVmjlawINgNoJnPr.CDIlMCeJNcMdbbkgVhwkeOlHCOww => QLmawvCCFcIJCVfPjwAPrlkMMLpj.UOsRCkLusRFOaQvLUafVGsFIkXzU;

	string QMQjWbDoKRhaRVmjlawINgNoJnPr.VQoWzcAGPoQlIieOrWohGPvFaMtI => QLmawvCCFcIJCVfPjwAPrlkMMLpj.MTwhczrOWjxUMrNMBtosGjhrMsHd;

	string QMQjWbDoKRhaRVmjlawINgNoJnPr.MuZFTeZVMoSmFqZrrsLCDXSSLaDf => jHfRpVmRjsmLsQbrPGzhcKOqlySt;

	int QMQjWbDoKRhaRVmjlawINgNoJnPr.RexRfhyDMuiOORsxhVQlRffKcxOI => QLmawvCCFcIJCVfPjwAPrlkMMLpj.WLpfWCwgPbFLaGTzegZdqfSZTzLg;

	int QMQjWbDoKRhaRVmjlawINgNoJnPr.ILbJCMdESsTkRFboYpwuabEYgRWW => QLmawvCCFcIJCVfPjwAPrlkMMLpj.kkrAAsDIHqyBvwRnPPhPCsbWOpWh;

	string QMQjWbDoKRhaRVmjlawINgNoJnPr.TypAIrJwMuYsFPCrkpWiaRBgKwMlb
	{
		get
		{
			if (HjCgbGYhTNqqbfnghlmYKfhZwisV)
			{
				return yTygqkLWAxVegYIoGIhkjbHHYVsS;
			}
			yTygqkLWAxVegYIoGIhkjbHHYVsS = JqoBfisQKbNTMkNdWslkfAHzLkfW.qeSsqmKLpFsMTLWPbRhxnqBEIese(QLmawvCCFcIJCVfPjwAPrlkMMLpj, RmaUWULMKHsUyIHdwBkMUTlNQklU, MJCEwRBVuVKSGDFqTrsuJVtjFKBab, VQoWzcAGPoQlIieOrWohGPvFaMtI);
			HjCgbGYhTNqqbfnghlmYKfhZwisV = true;
			return yTygqkLWAxVegYIoGIhkjbHHYVsS;
		}
	}

	HIDDeviceDriver QMQjWbDoKRhaRVmjlawINgNoJnPr.VWSXLNJpPZpyLvVWAebHbsdTMCEo
	{
		get
		{
			return NiXLjbKgqCWFvicUHGVUiPvnDCOg;
		}
		protected set
		{
			if (NiXLjbKgqCWFvicUHGVUiPvnDCOg != null)
			{
				NiXLjbKgqCWFvicUHGVUiPvnDCOg.ErrorEvent -= uWXasskuyhOUaFvvRVfKMLrnGjlE;
			}
			NiXLjbKgqCWFvicUHGVUiPvnDCOg = niXLjbKgqCWFvicUHGVUiPvnDCOg;
			if (NiXLjbKgqCWFvicUHGVUiPvnDCOg != null)
			{
				NiXLjbKgqCWFvicUHGVUiPvnDCOg.ErrorEvent += uWXasskuyhOUaFvvRVfKMLrnGjlE;
			}
		}
	}

	IList<Controller.Extension> QMQjWbDoKRhaRVmjlawINgNoJnPr.ZTUgJyyvKoTYnVhVIJshSukzyiOi => UxNrfILAVwpVgxmNLtEjQXEtsiNd;

	virtual bool QMQjWbDoKRhaRVmjlawINgNoJnPr.DIgMquQcUiJUCmpcvVcSJQDlfzZM
	{
		get
		{
			if (!IuigssratldqukbSWrhKHXXeMGeG)
			{
				return !kFyLEodOLBokttElPRKyJAqHLIhX;
			}
			return false;
		}
	}

	public lSgtVcYGtDAKWPKJnJfgJjZwcWDaA(yBATXoBSRnHIKCFttVvSrbcAKezC P_0, IntPtr P_1)
	{
		QLmawvCCFcIJCVfPjwAPrlkMMLpj = P_0;
		TfyxcOhYELecfnjnVTdocJAjSCtu = P_1;
		KMoDtiNxObfplPaUERlLmrjxHshu = fJoYSGWjxzUjSDoEZajzeYSlpVQb((ushort)P_0.YYzFmtrEAtiRNtPjhZbbbhzJBxoo.YHaocuphiCGBhKcRoqVlRwiBJVrGA, (ushort)P_0.YYzFmtrEAtiRNtPjhZbbbhzJBxoo.NEzrNjrjnXJIZxmooNEMWPidoNIu);
		NIrrwkBHRBKjCxwIRUeptNBStVvF = P_0.gVrebRKaUUSNFbSkxkRvqtYcLJvGb.phMGylZqabzQwbLlYEfhkDynaowRA;
		uZSIxNHHlAywKBJDzPvQJhUQdDZc = P_0.gVrebRKaUUSNFbSkxkRvqtYcLJvGb.GunPvQHiBsGaoxIGHIfevfcuhVZu;
		jHfRpVmRjsmLsQbrPGzhcKOqlySt = P_0.zclQeZKkczjwAACdBcgpzBrhKJjb();
		RmaUWULMKHsUyIHdwBkMUTlNQklU = MiscTools.CreateHIDProductGuid(NIrrwkBHRBKjCxwIRUeptNBStVvF, uZSIxNHHlAywKBJDzPvQJhUQdDZc);
		YlOEeqvyCAaDACUuXSudVacKeGuDA = MiscTools.CreateGuidHashSHA1(QLmawvCCFcIJCVfPjwAPrlkMMLpj.xBMIpxAaKDkRBpomErAuGhPXdszl);
		KjTefvEHHOcmPfJGIKeFKOWsmeezA = new List<Controller.Extension>();
		UxNrfILAVwpVgxmNLtEjQXEtsiNd = new ReadOnlyCollection<Controller.Extension>(KjTefvEHHOcmPfJGIKeFKOWsmeezA);
		KjTefvEHHOcmPfJGIKeFKOWsmeezA.Add(new RawInputControllerExtension(this));
	}

	public void htZzZygHZONfNVqOIJaBLXzqESgF(IntPtr P_0)
	{
		TfyxcOhYELecfnjnVTdocJAjSCtu = P_0;
	}

	void QMQjWbDoKRhaRVmjlawINgNoJnPr.htZzZygHZONfNVqOIJaBLXzqESgF(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in htZzZygHZONfNVqOIJaBLXzqESgF
		this.htZzZygHZONfNVqOIJaBLXzqESgF(P_0);
	}

	public virtual void dqufjUAJhVXctUzyeeesSNGXiWAh(UpdateLoopType P_0)
	{
		if (NiXLjbKgqCWFvicUHGVUiPvnDCOg != null)
		{
			NiXLjbKgqCWFvicUHGVUiPvnDCOg.Update(P_0);
		}
	}

	void QMQjWbDoKRhaRVmjlawINgNoJnPr.dqufjUAJhVXctUzyeeesSNGXiWAh(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in dqufjUAJhVXctUzyeeesSNGXiWAh
		this.dqufjUAJhVXctUzyeeesSNGXiWAh(P_0);
	}

	public abstract void YxSCNoLUGAffTPXJSYNgjiQxeSKT();

	protected void RxIuOcegQLKEFkaRDqxDEOpHcFDf(int P_0, Controller.Extension P_1)
	{
		if (P_1 != null && !KjTefvEHHOcmPfJGIKeFKOWsmeezA.Contains(P_1))
		{
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			else if (P_0 >= KjTefvEHHOcmPfJGIKeFKOWsmeezA.Count)
			{
				KjTefvEHHOcmPfJGIKeFKOWsmeezA.Add(P_1);
				return;
			}
			KjTefvEHHOcmPfJGIKeFKOWsmeezA.Insert(P_0, P_1);
		}
	}

	private void uWXasskuyhOUaFvvRVfKMLrnGjlE(HIDDeviceDriver.MiNaIzDPKzaXZdztgHayeKZcnRCwb P_0)
	{
		if (HIDDeviceDriver.IsCriticalError(P_0))
		{
			kFyLEodOLBokttElPRKyJAqHLIhX = true;
		}
	}

	public void Dispose()
	{
		aqZPErrSfNTawXqNctXCZPGnkyuG(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void RSxLjyVEdkxZubDmrOElvCPiBRhe()
	{
		try
		{
			aqZPErrSfNTawXqNctXCZPGnkyuG(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void aqZPErrSfNTawXqNctXCZPGnkyuG(bool P_0)
	{
		if (IuigssratldqukbSWrhKHXXeMGeG)
		{
			return;
		}
		if (P_0)
		{
			if (NiXLjbKgqCWFvicUHGVUiPvnDCOg != null)
			{
				NiXLjbKgqCWFvicUHGVUiPvnDCOg.ErrorEvent -= uWXasskuyhOUaFvvRVfKMLrnGjlE;
				NiXLjbKgqCWFvicUHGVUiPvnDCOg.Dispose();
			}
			if (QLmawvCCFcIJCVfPjwAPrlkMMLpj != null)
			{
				QLmawvCCFcIJCVfPjwAPrlkMMLpj.Dispose();
			}
		}
		IuigssratldqukbSWrhKHXXeMGeG = true;
	}

	private static DeviceType fJoYSGWjxzUjSDoEZajzeYSlpVQb(ushort P_0, ushort P_1)
	{
		if (P_0 != 1)
		{
			return DeviceType.Unknown;
		}
		return P_1 switch
		{
			4 => DeviceType.Joystick, 
			5 => DeviceType.Gamepad, 
			6 => DeviceType.Keyboard, 
			2 => DeviceType.Mouse, 
			8 => DeviceType.MultiAxisController, 
			_ => DeviceType.Unknown, 
		};
	}

	public abstract void smaQhtTrUqNmDWDQEApJkjZTEhYx();

	public abstract void AKMehlDMgtqaPNuADIJLcXEPnOcRA();

	public abstract bool HTNLLvwTYbnxasfGiABGnBTUQTtl();
}
