using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class qNmehkleTfcBTeRaeVPEWTMAtwnsA<_0001>
{
	private enum jNvZPHiMHXmIxSxjHFcSbwjFETCD
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class lMbeNsGYNnAtVbNqfnPXgUOpOiZt
	{
		private class dOwaJNyhsSkFChSkHmxmIoDccUlv : IDisposable
		{
			private sealed class dPbKYhYEgCxpdnKRhaVvchbRlTeg
			{
				public dOwaJNyhsSkFChSkHmxmIoDccUlv dSNBpfbLdGEVAbSTpBvdwfrboqym;

				public ManualResetEvent RtwGkusVJwPBngpGoIXawYICcbzF;

				internal void XbtqqUojpxzsoTcNMFuncPFprptq()
				{
					RtwGkusVJwPBngpGoIXawYICcbzF.Set();
					dSNBpfbLdGEVAbSTpBvdwfrboqym.jSQkTgeZBEdfCioNefWTsFTSagEKA();
				}
			}

			private readonly object BnJcNgmVeLLznWvOPQMKIfWQmSfF;

			private List<WaitCallback> CVIKTvxOGoyBchCfciKAzobLhxgBA;

			private List<WaitCallback> XFFQnrSodyIXfspcLPCtgahZpUNr;

			private Thread DaAAYEowQJaSvkehJxpyycEJaySV;

			private AutoResetEvent JPqmOWZFVbmvTRsZheKfnoRxqxbm;

			private bool ilTeDnRGPKueuZajvsyMfzKXGJWx;

			private bool QukFjhwUpwEGgoVJrxceJRPGtpxj;

			private bool lRXAxYaqsogvkEajgVNsKPtFOiksD;

			private bool jtlZGMgOUYJRzUJLUvyGlbhorlKy;

			public dOwaJNyhsSkFChSkHmxmIoDccUlv()
			{
				BnJcNgmVeLLznWvOPQMKIfWQmSfF = new object();
				CVIKTvxOGoyBchCfciKAzobLhxgBA = new List<WaitCallback>();
				XFFQnrSodyIXfspcLPCtgahZpUNr = new List<WaitCallback>();
				JPqmOWZFVbmvTRsZheKfnoRxqxbm = new AutoResetEvent(initialState: false);
			}

			public void DeLTOFdYNCMgscXUsggKBbirGBlP(WaitCallback P_0)
			{
				if (TqLGuvBqhTHlIlAmYkgyouARxnQnA())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (BnJcNgmVeLLznWvOPQMKIfWQmSfF)
					{
						CVIKTvxOGoyBchCfciKAzobLhxgBA.Add(P_0);
					}
					JPqmOWZFVbmvTRsZheKfnoRxqxbm.Set();
				}
			}

			public void bXQesRIiSGxVyPRnByBidnGOrAEw()
			{
				mWWKNYwKZWztTwSLUgfxXdCzRdlA();
			}

			public bool CxoZRiIdXxvfrNwBgrOBTJRzRJuy()
			{
				return TqLGuvBqhTHlIlAmYkgyouARxnQnA();
			}

			private bool TqLGuvBqhTHlIlAmYkgyouARxnQnA()
			{
				if (lRXAxYaqsogvkEajgVNsKPtFOiksD)
				{
					return false;
				}
				if (QukFjhwUpwEGgoVJrxceJRPGtpxj)
				{
					return false;
				}
				if (ilTeDnRGPKueuZajvsyMfzKXGJWx)
				{
					return true;
				}
				if (DaAAYEowQJaSvkehJxpyycEJaySV != null)
				{
					return true;
				}
				return hCXeqIlsnTacZTMhTgVLCsYLfODJA();
			}

			private bool hCXeqIlsnTacZTMhTgVLCsYLfODJA()
			{
				dPbKYhYEgCxpdnKRhaVvchbRlTeg dPbKYhYEgCxpdnKRhaVvchbRlTeg2 = new dPbKYhYEgCxpdnKRhaVvchbRlTeg();
				dPbKYhYEgCxpdnKRhaVvchbRlTeg2.dSNBpfbLdGEVAbSTpBvdwfrboqym = this;
				try
				{
					dPbKYhYEgCxpdnKRhaVvchbRlTeg2.RtwGkusVJwPBngpGoIXawYICcbzF = new ManualResetEvent(initialState: false);
					DaAAYEowQJaSvkehJxpyycEJaySV = new Thread(dPbKYhYEgCxpdnKRhaVvchbRlTeg2.XbtqqUojpxzsoTcNMFuncPFprptq);
					DaAAYEowQJaSvkehJxpyycEJaySV.Start();
					dPbKYhYEgCxpdnKRhaVvchbRlTeg2.RtwGkusVJwPBngpGoIXawYICcbzF.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					DaAAYEowQJaSvkehJxpyycEJaySV = null;
					lRXAxYaqsogvkEajgVNsKPtFOiksD = true;
					return false;
				}
			}

			private void jSQkTgeZBEdfCioNefWTsFTSagEKA()
			{
				ilTeDnRGPKueuZajvsyMfzKXGJWx = true;
				while (!QukFjhwUpwEGgoVJrxceJRPGtpxj)
				{
					JPqmOWZFVbmvTRsZheKfnoRxqxbm.WaitOne();
					if (QukFjhwUpwEGgoVJrxceJRPGtpxj)
					{
						break;
					}
					lock (BnJcNgmVeLLznWvOPQMKIfWQmSfF)
					{
						MiscTools.Swap(ref CVIKTvxOGoyBchCfciKAzobLhxgBA, ref XFFQnrSodyIXfspcLPCtgahZpUNr);
					}
					List<WaitCallback> xFFQnrSodyIXfspcLPCtgahZpUNr = XFFQnrSodyIXfspcLPCtgahZpUNr;
					int count = xFFQnrSodyIXfspcLPCtgahZpUNr.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							xFFQnrSodyIXfspcLPCtgahZpUNr[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					xFFQnrSodyIXfspcLPCtgahZpUNr.Clear();
				}
				lock (BnJcNgmVeLLznWvOPQMKIfWQmSfF)
				{
					CVIKTvxOGoyBchCfciKAzobLhxgBA.Clear();
					XFFQnrSodyIXfspcLPCtgahZpUNr.Clear();
				}
				QukFjhwUpwEGgoVJrxceJRPGtpxj = false;
				ilTeDnRGPKueuZajvsyMfzKXGJWx = false;
			}

			private void ynSSISKPatATzgkfmhdOjvVasdVqc()
			{
				DaAAYEowQJaSvkehJxpyycEJaySV = null;
				lRXAxYaqsogvkEajgVNsKPtFOiksD = false;
				QukFjhwUpwEGgoVJrxceJRPGtpxj = true;
			}

			private void mWWKNYwKZWztTwSLUgfxXdCzRdlA()
			{
				ynSSISKPatATzgkfmhdOjvVasdVqc();
				try
				{
					JPqmOWZFVbmvTRsZheKfnoRxqxbm.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				VgguJdrqSGxOvefXXvPvunXmreqM(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void BliRLsYBeDubNBNuFgXDJXGEoHzM()
			{
				try
				{
					VgguJdrqSGxOvefXXvPvunXmreqM(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void VgguJdrqSGxOvefXXvPvunXmreqM(bool P_0)
			{
				if (!jtlZGMgOUYJRzUJLUvyGlbhorlKy)
				{
					mWWKNYwKZWztTwSLUgfxXdCzRdlA();
					jtlZGMgOUYJRzUJLUvyGlbhorlKy = true;
				}
			}
		}

		private static lMbeNsGYNnAtVbNqfnPXgUOpOiZt KhxEyNAXKMAMQbFIOqGaduqOEMAEb;

		private dOwaJNyhsSkFChSkHmxmIoDccUlv PNJBcdptAzbgHduBWQuGSAjcKXTiA;

		private int RrDZRJwMYbiYiLqInHgDzoGHUmiD;

		private bool MSdQjtcRGiyNVXuOxDIcGfwZAggM;

		private static lMbeNsGYNnAtVbNqfnPXgUOpOiZt hMxShgShbKDqEkLGHqVrNjzWzWfkA => KhxEyNAXKMAMQbFIOqGaduqOEMAEb ?? new lMbeNsGYNnAtVbNqfnPXgUOpOiZt();

		private dOwaJNyhsSkFChSkHmxmIoDccUlv LEDqDoEfHRaXRyaXRFmgqHBMEQfg => PNJBcdptAzbgHduBWQuGSAjcKXTiA ?? (PNJBcdptAzbgHduBWQuGSAjcKXTiA = new dOwaJNyhsSkFChSkHmxmIoDccUlv());

		private lMbeNsGYNnAtVbNqfnPXgUOpOiZt()
		{
			KhxEyNAXKMAMQbFIOqGaduqOEMAEb?.bvbNkKkWmqwjeYkHeVzbACepSeKH();
			KhxEyNAXKMAMQbFIOqGaduqOEMAEb = this;
		}

		private void uPdQqlBPRwxsXfwpmMZSHgIBCeAe()
		{
			RrDZRJwMYbiYiLqInHgDzoGHUmiD++;
		}

		private void tkQAlgsoyBSoSReBCEJSUKwtTGge()
		{
			RrDZRJwMYbiYiLqInHgDzoGHUmiD--;
			if (RrDZRJwMYbiYiLqInHgDzoGHUmiD < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (RrDZRJwMYbiYiLqInHgDzoGHUmiD == 0)
			{
				bvbNkKkWmqwjeYkHeVzbACepSeKH();
			}
		}

		private void TyLRgdKBLMJBIQFNJlozLaRLJXFE(WaitCallback P_0)
		{
			LEDqDoEfHRaXRyaXRFmgqHBMEQfg.DeLTOFdYNCMgscXUsggKBbirGBlP(P_0);
		}

		private void RcNMGoGNXSIFhvpAgQUhATIJrFZB()
		{
			LEDqDoEfHRaXRyaXRFmgqHBMEQfg.bXQesRIiSGxVyPRnByBidnGOrAEw();
		}

		private bool CZJLvTGvfvSZyEVgAhOOZobZCIcQ()
		{
			return LEDqDoEfHRaXRyaXRFmgqHBMEQfg.CxoZRiIdXxvfrNwBgrOBTJRzRJuy();
		}

		private void bvbNkKkWmqwjeYkHeVzbACepSeKH()
		{
			lYlkebRkczSlWvLzVEaIWQkEZkUl(true);
			GC.SuppressFinalize(this);
		}

		protected void vwAmzxuXvkCHKaKXLTQpcEnZbkyp()
		{
			try
			{
				lYlkebRkczSlWvLzVEaIWQkEZkUl(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void lYlkebRkczSlWvLzVEaIWQkEZkUl(bool P_0)
		{
			if (!MSdQjtcRGiyNVXuOxDIcGfwZAggM)
			{
				if (P_0 && PNJBcdptAzbgHduBWQuGSAjcKXTiA != null)
				{
					PNJBcdptAzbgHduBWQuGSAjcKXTiA.Dispose();
					PNJBcdptAzbgHduBWQuGSAjcKXTiA = null;
				}
				RrDZRJwMYbiYiLqInHgDzoGHUmiD = 0;
				if (KhxEyNAXKMAMQbFIOqGaduqOEMAEb == this)
				{
					KhxEyNAXKMAMQbFIOqGaduqOEMAEb = null;
				}
				MSdQjtcRGiyNVXuOxDIcGfwZAggM = true;
			}
		}

		public static void bzANpMCjCaJHMpHJeLbzRTDDWsTe()
		{
			hMxShgShbKDqEkLGHqVrNjzWzWfkA.uPdQqlBPRwxsXfwpmMZSHgIBCeAe();
		}

		public static void djztYdyKjEuWmZeeMJYIhWCtHYYt()
		{
			KhxEyNAXKMAMQbFIOqGaduqOEMAEb?.tkQAlgsoyBSoSReBCEJSUKwtTGge();
		}

		public static void hjZGlQomvwddRcyJbrAFahZmcofy(WaitCallback P_0)
		{
			hMxShgShbKDqEkLGHqVrNjzWzWfkA.TyLRgdKBLMJBIQFNJlozLaRLJXFE(P_0);
		}
	}

	private jNvZPHiMHXmIxSxjHFcSbwjFETCD SoeAdThGHsvVDuMvJKUdjjNKlfDVA;

	private _0001 FPidJVFLaGvysZvRwNUBWEYEXFPV;

	private WaitCallback KykPiiAVbPNvRwLvBisQyUMKPiiE;

	private object DsFQdPSQYqaOSLNjjIiEngrcSYuV;

	private Func<_0001> alQpLaKnlnVYbtHEuIDVSAvFgbfZ;

	private bool AhrtoOeopfFiYsvGZmikuvWJUlfn;

	private bool aYSqSEXImyDSeLzYiLdaXUhdmhBf;

	public bool TPoeWwEYcJhWohaeHjOgcVjxblcSA
	{
		get
		{
			if (SoeAdThGHsvVDuMvJKUdjjNKlfDVA != jNvZPHiMHXmIxSxjHFcSbwjFETCD.AwaitingResult)
			{
				return SoeAdThGHsvVDuMvJKUdjjNKlfDVA == jNvZPHiMHXmIxSxjHFcSbwjFETCD.ResultReceived;
			}
			return true;
		}
	}

	public _0001 FFWjswuhFTDsWeZHbKPsbmwJBlek => FPidJVFLaGvysZvRwNUBWEYEXFPV;

	public bool VWKJlWBJsiHHmQEXkCqAcjYYeDisA()
	{
		bool num = SoeAdThGHsvVDuMvJKUdjjNKlfDVA == jNvZPHiMHXmIxSxjHFcSbwjFETCD.ResultReceived;
		if (num)
		{
			SoeAdThGHsvVDuMvJKUdjjNKlfDVA = jNvZPHiMHXmIxSxjHFcSbwjFETCD.Idle;
		}
		return num;
	}

	public qNmehkleTfcBTeRaeVPEWTMAtwnsA(bool P_0, Func<_0001> P_1)
	{
		AhrtoOeopfFiYsvGZmikuvWJUlfn = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		alQpLaKnlnVYbtHEuIDVSAvFgbfZ = P_1;
		KykPiiAVbPNvRwLvBisQyUMKPiiE = GzsOVHmQcyFBiAeDBQSFestNGaQC;
		DsFQdPSQYqaOSLNjjIiEngrcSYuV = new object();
		SoeAdThGHsvVDuMvJKUdjjNKlfDVA = jNvZPHiMHXmIxSxjHFcSbwjFETCD.Idle;
		if (P_0)
		{
			lMbeNsGYNnAtVbNqfnPXgUOpOiZt.bzANpMCjCaJHMpHJeLbzRTDDWsTe();
		}
	}

	public bool tGmkFOBGLIStwNoiokXgtfxSMCi()
	{
		lock (DsFQdPSQYqaOSLNjjIiEngrcSYuV)
		{
			if (SoeAdThGHsvVDuMvJKUdjjNKlfDVA == jNvZPHiMHXmIxSxjHFcSbwjFETCD.AwaitingResult)
			{
				return false;
			}
			FPidJVFLaGvysZvRwNUBWEYEXFPV = default(_0001);
			SoeAdThGHsvVDuMvJKUdjjNKlfDVA = jNvZPHiMHXmIxSxjHFcSbwjFETCD.AwaitingResult;
		}
		if (AhrtoOeopfFiYsvGZmikuvWJUlfn)
		{
			lMbeNsGYNnAtVbNqfnPXgUOpOiZt.hjZGlQomvwddRcyJbrAFahZmcofy(KykPiiAVbPNvRwLvBisQyUMKPiiE);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(KykPiiAVbPNvRwLvBisQyUMKPiiE, this);
		}
		return true;
	}

	public void BkqktNKahOeytCbRroMuYcZtGFWK()
	{
		lock (DsFQdPSQYqaOSLNjjIiEngrcSYuV)
		{
			FPidJVFLaGvysZvRwNUBWEYEXFPV = default(_0001);
			SoeAdThGHsvVDuMvJKUdjjNKlfDVA = jNvZPHiMHXmIxSxjHFcSbwjFETCD.Idle;
		}
	}

	private void GzsOVHmQcyFBiAeDBQSFestNGaQC(object P_0)
	{
		lock (DsFQdPSQYqaOSLNjjIiEngrcSYuV)
		{
			if (SoeAdThGHsvVDuMvJKUdjjNKlfDVA == jNvZPHiMHXmIxSxjHFcSbwjFETCD.AwaitingResult)
			{
				FPidJVFLaGvysZvRwNUBWEYEXFPV = alQpLaKnlnVYbtHEuIDVSAvFgbfZ();
				SoeAdThGHsvVDuMvJKUdjjNKlfDVA = jNvZPHiMHXmIxSxjHFcSbwjFETCD.ResultReceived;
			}
		}
	}

	public void INBczqSosoXHntgpZStpJliJdQBM()
	{
		LQXybuLIEkIqSaGgokyLlLOIGQKjA(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void bFkaFebhYetJxgLHKptNnjRnQawiA()
	{
		try
		{
			LQXybuLIEkIqSaGgokyLlLOIGQKjA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void LQXybuLIEkIqSaGgokyLlLOIGQKjA(bool P_0)
	{
		if (!aYSqSEXImyDSeLzYiLdaXUhdmhBf)
		{
			if (P_0)
			{
				BkqktNKahOeytCbRroMuYcZtGFWK();
			}
			if (AhrtoOeopfFiYsvGZmikuvWJUlfn)
			{
				lMbeNsGYNnAtVbNqfnPXgUOpOiZt.djztYdyKjEuWmZeeMJYIhWCtHYYt();
			}
			aYSqSEXImyDSeLzYiLdaXUhdmhBf = true;
		}
	}
}
