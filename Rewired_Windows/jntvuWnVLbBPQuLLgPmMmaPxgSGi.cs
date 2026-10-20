using System;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class jntvuWnVLbBPQuLLgPmMmaPxgSGi : xiVKhXnYVzwavDKMIGTGSvLGEfsF
{
	internal class AaZXGecZmiVtFjeWvjoeMHseFCIf : qzDDnmAMtAHREEfADcrxdWlbyfBqe
	{
		private int KtAfCHbXiaQRIVfhJFMkBlRHzNid;

		private int ntsHFDjNrSOSsLwZUxJsbyJERaak;

		public float[] cezHRgNqlZMgJwSEichDEdWdBptHA => (SgEetgATjqFQjeKYFGqlNUFjfMMxA as thuMeySUqCjyUFYJSagpOaDbJHIt).SrFjrHreGeENWjhHnriuFQgHGqTaA;

		public RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg> IjxgFhgPtIuwzEXTwAQKrnknKvlGb => (SgEetgATjqFQjeKYFGqlNUFjfMMxA as thuMeySUqCjyUFYJSagpOaDbJHIt).ONqKHSoqSMsoLEaOvfwHnJwjrsnt;

		public AaZXGecZmiVtFjeWvjoeMHseFCIf(UpdateLoopSetting P_0, int P_1, int P_2)
		{
			KtAfCHbXiaQRIVfhJFMkBlRHzNid = P_1;
			ntsHFDjNrSOSsLwZUxJsbyJERaak = P_2;
			BkdjRcLhvHGWPwQLOrXASXxXBpJl(P_0, XIejRVSolmbAWVbbLpSMLlvDNTVt);
		}

		public virtual void ytrfuwbQyBZwJTNFYsCtmsOeQteKA(UpdateLoopType P_0)
		{
			base.MbkeGPcKdUHzrLwpDGvgJtLbeNxxA(P_0);
			(SgEetgATjqFQjeKYFGqlNUFjfMMxA as thuMeySUqCjyUFYJSagpOaDbJHIt).ezelwEqZogKcCEZzbjjSykxVhdlH();
		}

		public void FzcJGEINSvlpfHEGRXOduvOogGEX(float[] P_0, float P_1)
		{
			for (int i = 0; i < ShjgISPwuxfinORONDEyNUOmfcMO.Length; i++)
			{
				(ShjgISPwuxfinORONDEyNUOmfcMO[i] as thuMeySUqCjyUFYJSagpOaDbJHIt).mHQHSuPSkqwJoEtwFSqHNDeEDglQ(P_0, P_1);
			}
		}

		private ELWquDtzkdGHDiJlLXvhLTVhOyAB XIejRVSolmbAWVbbLpSMLlvDNTVt(UpdateLoopType P_0)
		{
			return new thuMeySUqCjyUFYJSagpOaDbJHIt(P_0, KtAfCHbXiaQRIVfhJFMkBlRHzNid, ntsHFDjNrSOSsLwZUxJsbyJERaak);
		}
	}

	internal class thuMeySUqCjyUFYJSagpOaDbJHIt : ELWquDtzkdGHDiJlLXvhLTVhOyAB
	{
		[Serializable]
		private sealed class lCFeXNKrpAfMhiNSAlgyjPgtPBsUA
		{
			public static readonly lCFeXNKrpAfMhiNSAlgyjPgtPBsUA _003C_003E9 = new lCFeXNKrpAfMhiNSAlgyjPgtPBsUA();

			public static Func<xJZoNJvwOYuCkuguqxILWyKPVNLg> _003C_003E9__5_0;

			internal xJZoNJvwOYuCkuguqxILWyKPVNLg LfazpphLyPedMBFpwiUhfVoaLKovb()
			{
				return new xJZoNJvwOYuCkuguqxILWyKPVNLg();
			}
		}

		private float[] TVuiTQOCbdccAGvbeUJalRQUtZFj;

		public float[] SrFjrHreGeENWjhHnriuFQgHGqTaA;

		public RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg> ONqKHSoqSMsoLEaOvfwHnJwjrsnt;

		private RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg> LSSmfQdIcPAcUSLuEGGyCMecfLdT;

		private ObjectPool<xJZoNJvwOYuCkuguqxILWyKPVNLg> HTMLFIJnBFelnfzxYzuzzeSNaSGFA;

		public thuMeySUqCjyUFYJSagpOaDbJHIt(UpdateLoopType P_0, int P_1, int P_2)
			: base(P_0)
		{
			SrFjrHreGeENWjhHnriuFQgHGqTaA = new float[P_1];
			TVuiTQOCbdccAGvbeUJalRQUtZFj = new float[P_1];
			ONqKHSoqSMsoLEaOvfwHnJwjrsnt = new RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg>(P_2);
			LSSmfQdIcPAcUSLuEGGyCMecfLdT = new RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg>(P_2);
			HTMLFIJnBFelnfzxYzuzzeSNaSGFA = new ObjectPool<xJZoNJvwOYuCkuguqxILWyKPVNLg>(P_2, lCFeXNKrpAfMhiNSAlgyjPgtPBsUA._003C_003E9.LfazpphLyPedMBFpwiUhfVoaLKovb);
		}

		public void ezelwEqZogKcCEZzbjjSykxVhdlH()
		{
			for (int i = 0; i < TVuiTQOCbdccAGvbeUJalRQUtZFj.Length; i++)
			{
				SrFjrHreGeENWjhHnriuFQgHGqTaA[i] = TVuiTQOCbdccAGvbeUJalRQUtZFj[i];
				TVuiTQOCbdccAGvbeUJalRQUtZFj[i] = 0f;
			}
			CollectionTools.Clear(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, ONqKHSoqSMsoLEaOvfwHnJwjrsnt);
			int count = LSSmfQdIcPAcUSLuEGGyCMecfLdT.Count;
			for (int j = 0; j < count; j++)
			{
				xJZoNJvwOYuCkuguqxILWyKPVNLg xJZoNJvwOYuCkuguqxILWyKPVNLg2 = HTMLFIJnBFelnfzxYzuzzeSNaSGFA.Get();
				xJZoNJvwOYuCkuguqxILWyKPVNLg2.zwiHKTqhpTQmwwgyusStpcPMmwQF(LSSmfQdIcPAcUSLuEGGyCMecfLdT[j]);
				CollectionTools.Enqueue(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, ONqKHSoqSMsoLEaOvfwHnJwjrsnt, xJZoNJvwOYuCkuguqxILWyKPVNLg2, out var _);
			}
			CollectionTools.Clear(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, LSSmfQdIcPAcUSLuEGGyCMecfLdT);
		}

		public void mHQHSuPSkqwJoEtwFSqHNDeEDglQ(float[] P_0, float P_1)
		{
			for (int i = 0; i < TVuiTQOCbdccAGvbeUJalRQUtZFj.Length; i++)
			{
				TVuiTQOCbdccAGvbeUJalRQUtZFj[i] += P_0[i];
			}
			xJZoNJvwOYuCkuguqxILWyKPVNLg xJZoNJvwOYuCkuguqxILWyKPVNLg2 = HTMLFIJnBFelnfzxYzuzzeSNaSGFA.Get();
			xJZoNJvwOYuCkuguqxILWyKPVNLg2.NhkqacpKaVDXABfDYXgjRZwilXloA(P_0, P_1);
			CollectionTools.Enqueue(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, LSSmfQdIcPAcUSLuEGGyCMecfLdT, xJZoNJvwOYuCkuguqxILWyKPVNLg2, out var _);
		}

		public virtual void fFwjNwqHPQCvquMAcdXubeFHvcPW()
		{
			Array.Clear(SrFjrHreGeENWjhHnriuFQgHGqTaA, 0, SrFjrHreGeENWjhHnriuFQgHGqTaA.Length);
			CollectionTools.Clear(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, LSSmfQdIcPAcUSLuEGGyCMecfLdT);
			CollectionTools.Clear(HTMLFIJnBFelnfzxYzuzzeSNaSGFA, ONqKHSoqSMsoLEaOvfwHnJwjrsnt);
		}
	}

	public class xJZoNJvwOYuCkuguqxILWyKPVNLg
	{
		public Vector3 DvHdJsiOpQCMusadeasERFNqfxYj;

		public float xXpuLfPLSjTeMlQUaganZAUGZSHq;

		public xJZoNJvwOYuCkuguqxILWyKPVNLg()
		{
		}

		public xJZoNJvwOYuCkuguqxILWyKPVNLg(float[] P_0, float P_1)
		{
			NhkqacpKaVDXABfDYXgjRZwilXloA(P_0, P_1);
		}

		public void NhkqacpKaVDXABfDYXgjRZwilXloA(float[] P_0, float P_1)
		{
			int num = MathTools.Min(P_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				DvHdJsiOpQCMusadeasERFNqfxYj[i] = P_0[i];
			}
			xXpuLfPLSjTeMlQUaganZAUGZSHq = P_1;
		}

		public void zwiHKTqhpTQmwwgyusStpcPMmwQF(xJZoNJvwOYuCkuguqxILWyKPVNLg P_0)
		{
			DvHdJsiOpQCMusadeasERFNqfxYj = P_0.DvHdJsiOpQCMusadeasERFNqfxYj;
			xXpuLfPLSjTeMlQUaganZAUGZSHq = P_0.xXpuLfPLSjTeMlQUaganZAUGZSHq;
		}

		public void VuGIufVhsWcbjUVvjIGONxmCQjHn(xJZoNJvwOYuCkuguqxILWyKPVNLg P_0)
		{
			DvHdJsiOpQCMusadeasERFNqfxYj = P_0.DvHdJsiOpQCMusadeasERFNqfxYj;
			xXpuLfPLSjTeMlQUaganZAUGZSHq = P_0.xXpuLfPLSjTeMlQUaganZAUGZSHq;
		}

		public bool ZjNhyzNluInWLEMwZWnnZuPTchrA(xJZoNJvwOYuCkuguqxILWyKPVNLg P_0)
		{
			if (xXpuLfPLSjTeMlQUaganZAUGZSHq == P_0.xXpuLfPLSjTeMlQUaganZAUGZSHq)
			{
				return DvHdJsiOpQCMusadeasERFNqfxYj == P_0.DvHdJsiOpQCMusadeasERFNqfxYj;
			}
			return false;
		}

		public void GvbJLuexgBpEWbEcPeAoBJaoJzZsA()
		{
			DvHdJsiOpQCMusadeasERFNqfxYj.x = 0f;
			DvHdJsiOpQCMusadeasERFNqfxYj.y = 0f;
			DvHdJsiOpQCMusadeasERFNqfxYj.z = 0f;
			xXpuLfPLSjTeMlQUaganZAUGZSHq = 0f;
		}
	}

	public double wkeEOuHvsmePhtfaeNapmEGjidDRA;

	public readonly float[] FOFdTvxaVfzjKuXtYfOzBSpyuzjD;

	public readonly int kcxNEcfpizsnjtyDvoYNbrYJnrar;

	private readonly byte[] NccwcqHBJWAtnxOEajOydmNvofkT;

	private readonly float[] oCsHiMkSEoERwlNzplwGDDstUxbkA;

	private readonly int gvXrELZfmaxuJVJqqHYvhnhXMexv;

	private readonly int qKvGtiFrahlwDUlXdLEzVRFFOruY;

	private readonly Action<byte[], float[]> bkaYdkMUrZOcmBzgpjivUFUYxDAm;

	private readonly Func<float> NGdVEGgGaUipSglyyoZSAVdivUkb;

	public float[] YZhnygGArvWYHTgbFoiNYQuaNTyS => (gCJMNJfbcAfVAQppNjIUGmZAoHzY as AaZXGecZmiVtFjeWvjoeMHseFCIf).cezHRgNqlZMgJwSEichDEdWdBptHA;

	public RingBuffer<xJZoNJvwOYuCkuguqxILWyKPVNLg> eTrgYsFlPQxbSPEyqbAXOGmMXzVD => (gCJMNJfbcAfVAQppNjIUGmZAoHzY as AaZXGecZmiVtFjeWvjoeMHseFCIf).IjxgFhgPtIuwzEXTwAQKrnknKvlGb;

	public jntvuWnVLbBPQuLLgPmMmaPxgSGi(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
		: base(new AaZXGecZmiVtFjeWvjoeMHseFCIf(P_0, P_3, P_4), P_1, P_2)
	{
		kcxNEcfpizsnjtyDvoYNbrYJnrar = P_3;
		bkaYdkMUrZOcmBzgpjivUFUYxDAm = P_5;
		NGdVEGgGaUipSglyyoZSAVdivUkb = P_6;
		gvXrELZfmaxuJVJqqHYvhnhXMexv = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
		qKvGtiFrahlwDUlXdLEzVRFFOruY = P_2.dataIndex;
		NccwcqHBJWAtnxOEajOydmNvofkT = new byte[gvXrELZfmaxuJVJqqHYvhnhXMexv];
		oCsHiMkSEoERwlNzplwGDDstUxbkA = new float[P_3];
		FOFdTvxaVfzjKuXtYfOzBSpyuzjD = new float[P_3];
	}

	public virtual void pgnUFgcQvFwcTFIonRYYtpmboIUr(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == vKgAOBqhKKHeEXCKnijETKCeeaEg)
		{
			wkeEOuHvsmePhtfaeNapmEGjidDRA = P_1;
			for (int i = 0; i < gvXrELZfmaxuJVJqqHYvhnhXMexv; i++)
			{
				NccwcqHBJWAtnxOEajOydmNvofkT[i] = P_0[qKvGtiFrahlwDUlXdLEzVRFFOruY + i];
			}
			if (bkaYdkMUrZOcmBzgpjivUFUYxDAm != null)
			{
				bkaYdkMUrZOcmBzgpjivUFUYxDAm(NccwcqHBJWAtnxOEajOydmNvofkT, oCsHiMkSEoERwlNzplwGDDstUxbkA);
			}
			float num = ((NGdVEGgGaUipSglyyoZSAVdivUkb != null) ? NGdVEGgGaUipSglyyoZSAVdivUkb() : 0f);
			(gCJMNJfbcAfVAQppNjIUGmZAoHzY as AaZXGecZmiVtFjeWvjoeMHseFCIf).FzcJGEINSvlpfHEGRXOduvOogGEX(oCsHiMkSEoERwlNzplwGDDstUxbkA, num);
			for (int j = 0; j < kcxNEcfpizsnjtyDvoYNbrYJnrar; j++)
			{
				FOFdTvxaVfzjKuXtYfOzBSpyuzjD[j] = oCsHiMkSEoERwlNzplwGDDstUxbkA[j];
			}
		}
	}

	public void NkhAJTvhGWTbttITRyEnSEAPaCQW(float[] P_0, double P_1)
	{
		wkeEOuHvsmePhtfaeNapmEGjidDRA = P_1;
		float num = ((NGdVEGgGaUipSglyyoZSAVdivUkb != null) ? NGdVEGgGaUipSglyyoZSAVdivUkb() : 0f);
		for (int i = 0; i < kcxNEcfpizsnjtyDvoYNbrYJnrar; i++)
		{
			oCsHiMkSEoERwlNzplwGDDstUxbkA[i] = P_0[i];
		}
		(gCJMNJfbcAfVAQppNjIUGmZAoHzY as AaZXGecZmiVtFjeWvjoeMHseFCIf).FzcJGEINSvlpfHEGRXOduvOogGEX(oCsHiMkSEoERwlNzplwGDDstUxbkA, num);
		for (int j = 0; j < kcxNEcfpizsnjtyDvoYNbrYJnrar; j++)
		{
			FOFdTvxaVfzjKuXtYfOzBSpyuzjD[j] = oCsHiMkSEoERwlNzplwGDDstUxbkA[j];
		}
	}
}
