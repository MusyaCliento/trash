using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class ABRAMTFXAHCYdbLHDBkGAYIdpNTtA : IDisposable
{
	private abstract class JLVJJVVHUcWsVYzPbLVSWXNvJBek : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool JBIyZObxokXoBacgLrwTjlfiIhCk;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return JBIyZObxokXoBacgLrwTjlfiIhCk;
			}
			[CompilerGenerated]
			set
			{
				JBIyZObxokXoBacgLrwTjlfiIhCk = value;
			}
		}

		protected abstract void Clear();

		void IPoolableObject_Internal.Clear()
		{
			Clear();
		}

		void IDisposable.Dispose()
		{
			Return();
		}

		public void Return()
		{
			((IPoolableObject_Internal)this).pool?.Return(this);
		}

		void IPoolableObject.Return()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Return
			this.Return();
		}
	}

	private class gmeozPUHEjJxDTMovJYPbAncBMRX : JLVJJVVHUcWsVYzPbLVSWXNvJBek
	{
		public VgwvWxNdcHfXWFTgEsEQLMdlOXEy TaLnhoeNLSgLpjcCRVJQQTNKtcUc;

		public atgIFQpkSifJQdHTdmSHWzSyatSg SdykkVOytlljwwLeRubGZbeYfTke;

		public double ajpAZkciYBmZbGfVFCAwrIIqAyIgb;

		protected virtual void ukHFRwpDRLISscayniaGBhLhczNH()
		{
			TaLnhoeNLSgLpjcCRVJQQTNKtcUc = null;
			SdykkVOytlljwwLeRubGZbeYfTke = default(atgIFQpkSifJQdHTdmSHWzSyatSg);
			ajpAZkciYBmZbGfVFCAwrIIqAyIgb = 0.0;
		}
	}

	private sealed class YNXvJXgzEUlhGnNwGXjNHWwadcKh : JLVJJVVHUcWsVYzPbLVSWXNvJBek
	{
		public VgwvWxNdcHfXWFTgEsEQLMdlOXEy GKKggNHmJZYfBQmmtxhduqkTvetTA;

		public vhBtsabzPKkijgkLYIuaKiuzvryy IGsyhLjxuknyqQynjERRDAKbbYSfA;

		protected void iAkfrinGHIxtnMTIwDAVVsPrjjFl()
		{
			GKKggNHmJZYfBQmmtxhduqkTvetTA = null;
			IGsyhLjxuknyqQynjERRDAKbbYSfA = default(vhBtsabzPKkijgkLYIuaKiuzvryy);
		}
	}

	[Serializable]
	private sealed class RMpSiGqGgyIuVaCPNdnGTluwumBFA
	{
		public static readonly RMpSiGqGgyIuVaCPNdnGTluwumBFA _003C_003E9 = new RMpSiGqGgyIuVaCPNdnGTluwumBFA();

		public static Func<gmeozPUHEjJxDTMovJYPbAncBMRX> _003C_003E9__19_0;

		public static Func<YNXvJXgzEUlhGnNwGXjNHWwadcKh> _003C_003E9__19_1;

		internal gmeozPUHEjJxDTMovJYPbAncBMRX mCCEdSdultyldCUYnketeTPBovQj()
		{
			return new gmeozPUHEjJxDTMovJYPbAncBMRX();
		}

		internal YNXvJXgzEUlhGnNwGXjNHWwadcKh vGAXwGOlxyJHwDrmCcWTVkcRZtID()
		{
			return new YNXvJXgzEUlhGnNwGXjNHWwadcKh();
		}
	}

	private readonly List<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> KnpLmwbFeLCmBSgfKBeSvdlsAEEk;

	private readonly ReadOnlyCollection<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> MpLvSSlMNLceVMAZruOaatENDTNd;

	private readonly List<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> rbUKQvVfnODkxgrMJThHKfEnfxeN;

	private readonly Func<int> WYzGFPeGUdFAvUKafjUaTBeqDxgwA;

	private readonly Rewired.Utils.Classes.Utility.SpinLock xpKJywmZVZjutRBnzXwzuJVBrImd = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock OqRSBhtUXndxeQbgGahHINFdKusd = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<gmeozPUHEjJxDTMovJYPbAncBMRX> EHPgovmEYYnyUJYMGJqJsEwvLvZP;

	private RingBuffer<YNXvJXgzEUlhGnNwGXjNHWwadcKh> jzVdxcnxGRGDNJknccTCbxHMFVsB;

	private bool YzsyqmNrTAxFGfkjIOrGwxFuEhO;

	private readonly ThreadSafeObjectPool<gmeozPUHEjJxDTMovJYPbAncBMRX> PQqbMxXrRkruwcjmSthISAqFSlgj;

	private readonly ThreadSafeObjectPool<YNXvJXgzEUlhGnNwGXjNHWwadcKh> BtOburNCSboFGhqCnMBCgHBttvhG;

	private readonly List<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> PSOdDBDhOvAJCMMUEDBbqIAwpxTCb;

	private RingBuffer<gmeozPUHEjJxDTMovJYPbAncBMRX> zQGVvgmxscKOGBdLOkgqUBgaBHPu;

	private RingBuffer<YNXvJXgzEUlhGnNwGXjNHWwadcKh> CCfYhKckaJCGxjySoNeLGkVaLHEo;

	private bool UWYEfKIvgbyHZrxyiPUDpXzfdzkp;

	private Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy, vhBtsabzPKkijgkLYIuaKiuzvryy> HPlPcrofnVczZEdlSfDjbsldUgUKB;

	[CompilerGenerated]
	private Action m_bHlGGmsBrHHKJcUGCWcKdobPaFcy;

	private bool QIMzitEEQFmYoosOIWMQjWtqHgTw;

	private static Guid[] qOgSEBGdKIwQuTHDSUaYtvJwRKIo;

	private static string[] BnhUjjXNgvPYKfjWWgdlmpNTYuUP;

	private static string[] LrcZSvYDJvFeyBtPMfUXTgnsXrlMA;

	public event Action bHlGGmsBrHHKJcUGCWcKdobPaFcy
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_bHlGGmsBrHHKJcUGCWcKdobPaFcy;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_bHlGGmsBrHHKJcUGCWcKdobPaFcy, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_bHlGGmsBrHHKJcUGCWcKdobPaFcy;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_bHlGGmsBrHHKJcUGCWcKdobPaFcy, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public ABRAMTFXAHCYdbLHDBkGAYIdpNTtA(Func<int> P_0)
	{
		WYzGFPeGUdFAvUKafjUaTBeqDxgwA = P_0;
		HPlPcrofnVczZEdlSfDjbsldUgUKB = DoxwHJcjEcrJoDHsBRVGsWuVFnWU;
		KnpLmwbFeLCmBSgfKBeSvdlsAEEk = new List<oWjRNvMCqhpxHRZjgbtVgtKPLuXu>();
		PSOdDBDhOvAJCMMUEDBbqIAwpxTCb = new List<oWjRNvMCqhpxHRZjgbtVgtKPLuXu>();
		MpLvSSlMNLceVMAZruOaatENDTNd = new ReadOnlyCollection<oWjRNvMCqhpxHRZjgbtVgtKPLuXu>(KnpLmwbFeLCmBSgfKBeSvdlsAEEk);
		rbUKQvVfnODkxgrMJThHKfEnfxeN = new List<VgwvWxNdcHfXWFTgEsEQLMdlOXEy>();
		YzsyqmNrTAxFGfkjIOrGwxFuEhO = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)VpydvvgAmkTUcjFPOCjeqVyqydEE.FouUkwuOnOhmqjkVSnyhOgtAiHCbA * 32f) + 1;
		PQqbMxXrRkruwcjmSthISAqFSlgj = new ThreadSafeObjectPool<gmeozPUHEjJxDTMovJYPbAncBMRX>(num, RMpSiGqGgyIuVaCPNdnGTluwumBFA._003C_003E9.mCCEdSdultyldCUYnketeTPBovQj);
		BtOburNCSboFGhqCnMBCgHBttvhG = new ThreadSafeObjectPool<YNXvJXgzEUlhGnNwGXjNHWwadcKh>(128, RMpSiGqGgyIuVaCPNdnGTluwumBFA._003C_003E9.vGAXwGOlxyJHwDrmCcWTVkcRZtID);
		EHPgovmEYYnyUJYMGJqJsEwvLvZP = new RingBuffer<gmeozPUHEjJxDTMovJYPbAncBMRX>(num);
		jzVdxcnxGRGDNJknccTCbxHMFVsB = new RingBuffer<YNXvJXgzEUlhGnNwGXjNHWwadcKh>(128);
		zQGVvgmxscKOGBdLOkgqUBgaBHPu = new RingBuffer<gmeozPUHEjJxDTMovJYPbAncBMRX>(num);
		CCfYhKckaJCGxjySoNeLGkVaLHEo = new RingBuffer<YNXvJXgzEUlhGnNwGXjNHWwadcKh>(128);
		VgwvWxNdcHfXWFTgEsEQLMdlOXEy.dBRKfQUuPZjqCUIyIDpPRPbvfEZHA += mlMcNsiqxfakQFViElynZNrjeHBRB;
		VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DTDhADdXRCjgAeCnaFwJVPxSnTHm += wKFfnqfnClgkjBwmZtRsQJfbiLJh;
		VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent += PGDaLUYaRmfJAvCiTcNnOhRofMmeA;
		VpydvvgAmkTUcjFPOCjeqVyqydEE.ehOnSWgRdmIwRYhdEneGjxefKKyo.ThreadUpdateEvent += EhXDSltiYNgIxClyZUiVoYYtbKDx;
		ReInput.ApplicationFocusChangedEvent += NQGExwnVGrmohrlEKYqjEzfeLfVc;
		ReInput.ApplicationPauseChangedEvent += LvuZvqcsoUdvMiSDzLTeUgFbhcyeA;
		VgwvWxNdcHfXWFTgEsEQLMdlOXEy.GlAaPqrCkDjoeBQrBbxgNaEMuWuO();
		ynMGpWHVNwfYJBeUfQnzvpbepwsdb();
	}

	public void FtbLzmJsYVITlrxtpNKOHNQWbPew()
	{
		bool flag = false;
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			if (UWYEfKIvgbyHZrxyiPUDpXzfdzkp)
			{
				UWYEfKIvgbyHZrxyiPUDpXzfdzkp = false;
				flag = true;
			}
		}
		if (flag)
		{
			ynMGpWHVNwfYJBeUfQnzvpbepwsdb();
		}
	}

	public void ZeoZBOhhPBdtSIUsVqnbEloTqbivA()
	{
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			MiscTools.Swap(ref EHPgovmEYYnyUJYMGJqJsEwvLvZP, ref zQGVvgmxscKOGBdLOkgqUBgaBHPu);
		}
		while (EHPgovmEYYnyUJYMGJqJsEwvLvZP.Count > 0)
		{
			gmeozPUHEjJxDTMovJYPbAncBMRX gmeozPUHEjJxDTMovJYPbAncBMRX2 = EHPgovmEYYnyUJYMGJqJsEwvLvZP.Dequeue();
			int num = TZhLVQGCHfiagqtQgkEtrmUDYylI(KnpLmwbFeLCmBSgfKBeSvdlsAEEk, gmeozPUHEjJxDTMovJYPbAncBMRX2.TaLnhoeNLSgLpjcCRVJQQTNKtcUc);
			if (num >= 0)
			{
				KnpLmwbFeLCmBSgfKBeSvdlsAEEk[num].ZRFewnaTCaLsIJiOxjNOZsipwMUhA(gmeozPUHEjJxDTMovJYPbAncBMRX2.SdykkVOytlljwwLeRubGZbeYfTke, gmeozPUHEjJxDTMovJYPbAncBMRX2.ajpAZkciYBmZbGfVFCAwrIIqAyIgb);
			}
			gmeozPUHEjJxDTMovJYPbAncBMRX2.Return();
		}
	}

	private void DoxwHJcjEcrJoDHsBRVGsWuVFnWU(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0, vhBtsabzPKkijgkLYIuaKiuzvryy P_1)
	{
		if (!YzsyqmNrTAxFGfkjIOrGwxFuEhO)
		{
			return;
		}
		using (OqRSBhtUXndxeQbgGahHINFdKusd.Lock())
		{
			YNXvJXgzEUlhGnNwGXjNHWwadcKh yNXvJXgzEUlhGnNwGXjNHWwadcKh = BtOburNCSboFGhqCnMBCgHBttvhG.Get();
			yNXvJXgzEUlhGnNwGXjNHWwadcKh.GKKggNHmJZYfBQmmtxhduqkTvetTA = P_0;
			yNXvJXgzEUlhGnNwGXjNHWwadcKh.IGsyhLjxuknyqQynjERRDAKbbYSfA = P_1;
			jzVdxcnxGRGDNJknccTCbxHMFVsB.Enqueue(yNXvJXgzEUlhGnNwGXjNHWwadcKh);
		}
	}

	public IList<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> OnemwQvmWWpKnWGcZTHDxCCkLjDe()
	{
		return MpLvSSlMNLceVMAZruOaatENDTNd;
	}

	private void ynMGpWHVNwfYJBeUfQnzvpbepwsdb()
	{
		bool flag = false;
		List<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> list = rbUKQvVfnODkxgrMJThHKfEnfxeN;
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			VgwvWxNdcHfXWFTgEsEQLMdlOXEy.LOYnAvyHzJtHyqedTlbeEDFfpeLN(list);
			for (int num = PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Count - 1; num >= 0; num--)
			{
				if (!jiNoDjFyLVIfrNezwLhsLIqeDKmq(list, PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[num].fQeOhgwTnnGIazappLVocGvMcqKD))
				{
					PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[num].fQeOhgwTnnGIazappLVocGvMcqKD.keQIIDyPbblqAlAdcGQFTVBTOtzV();
					PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[num].Dispose();
					PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				VgwvWxNdcHfXWFTgEsEQLMdlOXEy vgwvWxNdcHfXWFTgEsEQLMdlOXEy = list[num2];
				if (VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(vgwvWxNdcHfXWFTgEsEQLMdlOXEy, null))
				{
					list.RemoveAt(num2);
				}
				else
				{
					int num3 = TZhLVQGCHfiagqtQgkEtrmUDYylI(PSOdDBDhOvAJCMMUEDBbqIAwpxTCb, vgwvWxNdcHfXWFTgEsEQLMdlOXEy);
					if (num3 >= 0)
					{
						list[num2].keQIIDyPbblqAlAdcGQFTVBTOtzV();
						list[num2] = PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[num3].fQeOhgwTnnGIazappLVocGvMcqKD;
					}
					else
					{
						PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Add(new oWjRNvMCqhpxHRZjgbtVgtKPLuXu(vgwvWxNdcHfXWFTgEsEQLMdlOXEy, WYzGFPeGUdFAvUKafjUaTBeqDxgwA(), HPlPcrofnVczZEdlSfDjbsldUgUKB));
						flag = true;
					}
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				VgwvWxNdcHfXWFTgEsEQLMdlOXEy vgwvWxNdcHfXWFTgEsEQLMdlOXEy2 = list[num4];
				int num5 = TZhLVQGCHfiagqtQgkEtrmUDYylI(PSOdDBDhOvAJCMMUEDBbqIAwpxTCb, vgwvWxNdcHfXWFTgEsEQLMdlOXEy2);
				if (num5 >= 0)
				{
					oWjRNvMCqhpxHRZjgbtVgtKPLuXu item = PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[num5];
					PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.RemoveAt(num5);
					PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Insert(0, item);
				}
			}
			KnpLmwbFeLCmBSgfKBeSvdlsAEEk.Clear();
			for (int i = 0; i < PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Count; i++)
			{
				KnpLmwbFeLCmBSgfKBeSvdlsAEEk.Add(PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[i]);
			}
		}
		list.Clear();
		if (flag)
		{
			this.bHlGGmsBrHHKJcUGCWcKdobPaFcy?.Invoke();
		}
	}

	private void NQGExwnVGrmohrlEKYqjEzfeLfVc(bool P_0)
	{
		YzsyqmNrTAxFGfkjIOrGwxFuEhO = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!YzsyqmNrTAxFGfkjIOrGwxFuEhO)
		{
			using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
			{
				EHPgovmEYYnyUJYMGJqJsEwvLvZP.Clear();
			}
		}
	}

	private void LvuZvqcsoUdvMiSDzLTeUgFbhcyeA(bool P_0)
	{
		YzsyqmNrTAxFGfkjIOrGwxFuEhO = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!YzsyqmNrTAxFGfkjIOrGwxFuEhO)
		{
			using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
			{
				EHPgovmEYYnyUJYMGJqJsEwvLvZP.Clear();
			}
		}
	}

	private void PGDaLUYaRmfJAvCiTcNnOhRofMmeA()
	{
		if (QIMzitEEQFmYoosOIWMQjWtqHgTw || !YzsyqmNrTAxFGfkjIOrGwxFuEhO)
		{
			return;
		}
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			int count = PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Count;
			for (int i = 0; i < count; i++)
			{
				gmeozPUHEjJxDTMovJYPbAncBMRX gmeozPUHEjJxDTMovJYPbAncBMRX2 = PQqbMxXrRkruwcjmSthISAqFSlgj.Get();
				gmeozPUHEjJxDTMovJYPbAncBMRX2.TaLnhoeNLSgLpjcCRVJQQTNKtcUc = PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[i].fQeOhgwTnnGIazappLVocGvMcqKD;
				gmeozPUHEjJxDTMovJYPbAncBMRX2.SdykkVOytlljwwLeRubGZbeYfTke = gmeozPUHEjJxDTMovJYPbAncBMRX2.TaLnhoeNLSgLpjcCRVJQQTNKtcUc.SrIEwbDFXUTJOOKhCzLeTtHrAcxz();
				gmeozPUHEjJxDTMovJYPbAncBMRX2.ajpAZkciYBmZbGfVFCAwrIIqAyIgb = ReInput.realTime;
				zQGVvgmxscKOGBdLOkgqUBgaBHPu.Enqueue(gmeozPUHEjJxDTMovJYPbAncBMRX2);
			}
		}
	}

	private void EhXDSltiYNgIxClyZUiVoYYtbKDx()
	{
		if (QIMzitEEQFmYoosOIWMQjWtqHgTw)
		{
			return;
		}
		using (OqRSBhtUXndxeQbgGahHINFdKusd.Lock())
		{
			MiscTools.Swap(ref jzVdxcnxGRGDNJknccTCbxHMFVsB, ref CCfYhKckaJCGxjySoNeLGkVaLHEo);
		}
		while (CCfYhKckaJCGxjySoNeLGkVaLHEo.Count > 0)
		{
			YNXvJXgzEUlhGnNwGXjNHWwadcKh yNXvJXgzEUlhGnNwGXjNHWwadcKh = CCfYhKckaJCGxjySoNeLGkVaLHEo.Dequeue();
			try
			{
				yNXvJXgzEUlhGnNwGXjNHWwadcKh.GKKggNHmJZYfBQmmtxhduqkTvetTA.noCGNIduvKiDQhHGzRPqhMxwQzIpA = yNXvJXgzEUlhGnNwGXjNHWwadcKh.IGsyhLjxuknyqQynjERRDAKbbYSfA;
			}
			catch
			{
			}
			yNXvJXgzEUlhGnNwGXjNHWwadcKh.Return();
		}
	}

	private void mlMcNsiqxfakQFViElynZNrjeHBRB(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0)
	{
		P_0.keQIIDyPbblqAlAdcGQFTVBTOtzV();
		if (QIMzitEEQFmYoosOIWMQjWtqHgTw)
		{
			return;
		}
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			UWYEfKIvgbyHZrxyiPUDpXzfdzkp = true;
		}
	}

	private void wKFfnqfnClgkjBwmZtRsQJfbiLJh(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0)
	{
		P_0.keQIIDyPbblqAlAdcGQFTVBTOtzV();
		if (QIMzitEEQFmYoosOIWMQjWtqHgTw)
		{
			return;
		}
		using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
		{
			UWYEfKIvgbyHZrxyiPUDpXzfdzkp = true;
		}
	}

	public void Dispose()
	{
		qEyjiRgOTpbkEwLRtLPoLlHoebhSA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void CVyXcSVWgQIqkHYZXgNLGbByaSjhA()
	{
		try
		{
			qEyjiRgOTpbkEwLRtLPoLlHoebhSA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void qEyjiRgOTpbkEwLRtLPoLlHoebhSA(bool P_0)
	{
		if (QIMzitEEQFmYoosOIWMQjWtqHgTw)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= NQGExwnVGrmohrlEKYqjEzfeLfVc;
			ReInput.ApplicationPauseChangedEvent -= LvuZvqcsoUdvMiSDzLTeUgFbhcyeA;
			VgwvWxNdcHfXWFTgEsEQLMdlOXEy.dBRKfQUuPZjqCUIyIDpPRPbvfEZHA -= mlMcNsiqxfakQFViElynZNrjeHBRB;
			VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DTDhADdXRCjgAeCnaFwJVPxSnTHm -= wKFfnqfnClgkjBwmZtRsQJfbiLJh;
			VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent -= PGDaLUYaRmfJAvCiTcNnOhRofMmeA;
			VpydvvgAmkTUcjFPOCjeqVyqydEE.ehOnSWgRdmIwRYhdEneGjxefKKyo.ThreadUpdateEvent -= EhXDSltiYNgIxClyZUiVoYYtbKDx;
			using (xpKJywmZVZjutRBnzXwzuJVBrImd.Lock())
			{
				for (int i = 0; i < PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Count; i++)
				{
					try
					{
						PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[i].Dispose();
						PSOdDBDhOvAJCMMUEDBbqIAwpxTCb[i].fQeOhgwTnnGIazappLVocGvMcqKD.keQIIDyPbblqAlAdcGQFTVBTOtzV();
					}
					catch
					{
					}
				}
				PSOdDBDhOvAJCMMUEDBbqIAwpxTCb.Clear();
				KnpLmwbFeLCmBSgfKBeSvdlsAEEk.Clear();
			}
			try
			{
				VgwvWxNdcHfXWFTgEsEQLMdlOXEy.sBFthxVVsfvKFlxXCYUHzwaxpzKH();
			}
			catch
			{
			}
		}
		QIMzitEEQFmYoosOIWMQjWtqHgTw = true;
	}

	private static bool ioBGwzaxutmzWdBRuVKFOgqppRdbA(IList<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		return TZhLVQGCHfiagqtQgkEtrmUDYylI(P_0, P_1) >= 0;
	}

	private static bool jiNoDjFyLVIfrNezwLhsLIqeDKmq(IList<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		return VHseOOcSPaDxAvLfjqhlwfesBJgf(P_0, P_1) >= 0;
	}

	private static int TZhLVQGCHfiagqtQgkEtrmUDYylI(IList<oWjRNvMCqhpxHRZjgbtVgtKPLuXu> P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		if (P_0 == null || VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_0[i].fQeOhgwTnnGIazappLVocGvMcqKD, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int VHseOOcSPaDxAvLfjqhlwfesBJgf(IList<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		if (P_0 == null || VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_0[i], null) && VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static ABRAMTFXAHCYdbLHDBkGAYIdpNTtA()
	{
		qOgSEBGdKIwQuTHDSUaYtvJwRKIo = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		BnhUjjXNgvPYKfjWWgdlmpNTYuUP = new string[1] { "Xbox Bluetooth Gamepad" };
		LrcZSvYDJvFeyBtPMfUXTgnsXrlMA = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool vZlAMimXrTiqKWPzWBcOikQbPWdH(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < BnhUjjXNgvPYKfjWWgdlmpNTYuUP.Length; i++)
			{
				if (P_1.Equals(BnhUjjXNgvPYKfjWWgdlmpNTYuUP[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < LrcZSvYDJvFeyBtPMfUXTgnsXrlMA.Length; j++)
			{
				if (Regex.IsMatch(P_1, LrcZSvYDJvFeyBtPMfUXTgnsXrlMA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		string[] array = P_0.Split('#');
		if (array.Length < 2)
		{
			return false;
		}
		for (int k = 0; k < array.Length; k++)
		{
			string text = array[k].ToLower();
			if (text.Contains("pid_"))
			{
				int num = text.IndexOf("vid_");
				if (num >= 0 && text.IndexOf("ig_") >= num)
				{
					return true;
				}
			}
		}
		return false;
	}
}
