using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class oXhUBdScogwrDwEwyyfvbQcRuDUt : IDisposable
{
	private enum GYyFyoPXxbgMLgDkfCtNDOmFFZVZb
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum VfGDlJqfZHFaHSivGsQQqsGfgDfu
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int nnETkEcOQDNxtFwcylVWFvAFpqrN = 8;

	private const int GAPRrcPxbWsYJLncDngUgjIRPYBM = 10;

	private readonly string ZoseEaVsmxDToIfazcupRwWSrGif;

	private IntPtr fNcJMOVlghDPFWIqbKxPFWnhHfgA = edmPFVQXZAgSMnagypaqNIebBPiI.ZCbxcdZGGByxfBpqlmRFbGeSOXvT;

	private readonly NativeBuffer pHrEGrdPBofoAufAGTEfjylsYLSSA;

	private readonly int QjedazgWMJtSWFSVtXDhJFGiegFr;

	private readonly edmPFVQXZAgSMnagypaqNIebBPiI.XldoBUXqwwDikcvOfyiflVwLzCETA REcuMRCiWOOqQUWKdFRZGokrFRCl;

	private readonly object ocTXkGdjAZrDjJDMEqwTalLfTsGP;

	private readonly uint TYFJnGvqKaBiuQJXGJeKxgRsLepH;

	private global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA> MevoYLFzDMFlDPEiTkyfkDKqdpHr;

	private GYyFyoPXxbgMLgDkfCtNDOmFFZVZb KVDtHxdKylzsUIDzjDdUEegvzavK;

	private int CIGSVnaYqETglqOhuFJMcbATDqiF;

	private bool deDDhsBxNwVYdmuNsYJWdogsmcXkA;

	private int JnwBHEyxHcbAnkhEMHrHZavmykRk;

	private int dJUkERNJwiYpqVRPoyeIAxAEZNyA;

	public readonly int MPfduedbasdzvfSzlYRGOPUaflOxA;

	private bool eQdZQfVJnjSpdePfATYMehqsvSou;

	private bool qGjvkgmzRrhweOODcoENsMMsOksu => RciGSOAIVzSFNUsWuoeDdCDjeMbbc.bZPCVCkEklgiBIxvXmWuAfnvdadbb(ZoseEaVsmxDToIfazcupRwWSrGif);

	public oXhUBdScogwrDwEwyyfvbQcRuDUt(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		TYFJnGvqKaBiuQJXGJeKxgRsLepH = ObjectInstanceTracker.Default.Register(this);
		ZoseEaVsmxDToIfazcupRwWSrGif = P_0;
		if (!aLOgtXLcbLvldmRYkMxbtDhjINAL())
		{
			throw new Exception("Could not open HID device.");
		}
		QjedazgWMJtSWFSVtXDhJFGiegFr = P_1;
		MPfduedbasdzvfSzlYRGOPUaflOxA = P_1 + 8;
		pHrEGrdPBofoAufAGTEfjylsYLSSA = new NativeBuffer(MPfduedbasdzvfSzlYRGOPUaflOxA);
		MevoYLFzDMFlDPEiTkyfkDKqdpHr = new global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA>();
		KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle;
		CIGSVnaYqETglqOhuFJMcbATDqiF = ((P_2 < 0) ? 65535 : P_2);
		ocTXkGdjAZrDjJDMEqwTalLfTsGP = new object();
		REcuMRCiWOOqQUWKdFRZGokrFRCl = rHxiCgMpLCgpJVOqGgVqzghdFfncA;
		XgnQvdhNXOrMMPINDVGYfhgMUfVP();
	}

	public VfGDlJqfZHFaHSivGsQQqsGfgDfu FEHkrtOoqutsJzLxemZHmNyMDlWO(byte[] P_0)
	{
		lock (ocTXkGdjAZrDjJDMEqwTalLfTsGP)
		{
			if (eQdZQfVJnjSpdePfATYMehqsvSou)
			{
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.CriticalError;
			}
			if (!DyjpmXkxKgJcEhbpMcfuUumYqTAg())
			{
				return (dJUkERNJwiYpqVRPoyeIAxAEZNyA >= 10) ? VfGDlJqfZHFaHSivGsQQqsGfgDfu.CriticalError : VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < MPfduedbasdzvfSzlYRGOPUaflOxA)
			{
				int mPfduedbasdzvfSzlYRGOPUaflOxA = MPfduedbasdzvfSzlYRGOPUaflOxA;
				throw new Exception("buffer must be at least " + mPfduedbasdzvfSzlYRGOPUaflOxA + " bytes");
			}
			switch (KVDtHxdKylzsUIDzjDdUEegvzavK)
			{
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle:
				rrsIvuyCNEtjrQjsyvAVwrVKmnJd();
				break;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Waiting:
				XKqiMLpySxpyiKpjmAcVshsrqTAm();
				break;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.ErrorPending:
				GTkqHIonbTfRBwFlQLrUqTxWrqnR();
				break;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.SuccessPending:
				mwFJJKrujzMLqPOXhGJMAuuKQFNfA();
				break;
			}
			switch (KVDtHxdKylzsUIDzjDdUEegvzavK)
			{
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle:
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Idle;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Waiting:
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.ErrorPending:
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.SuccessPending:
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Waiting;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.FinishedSuccess:
				pHrEGrdPBofoAufAGTEfjylsYLSSA.TryReadBytes(P_0, MPfduedbasdzvfSzlYRGOPUaflOxA);
				KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle;
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Success;
			case GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.FinishedError:
				KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle;
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool rrsIvuyCNEtjrQjsyvAVwrVKmnJd()
	{
		if (KVDtHxdKylzsUIDzjDdUEegvzavK != GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Idle)
		{
			int kVDtHxdKylzsUIDzjDdUEegvzavK = (int)KVDtHxdKylzsUIDzjDdUEegvzavK;
			throw new Exception("Cannot StartRead from this state. State = " + kVDtHxdKylzsUIDzjDdUEegvzavK);
		}
		try
		{
			OReNkvHgBaaIbduxxeUDJipbQvVj();
			bool num = edmPFVQXZAgSMnagypaqNIebBPiI.LCBWhNemCdmsdNFAdwsOIYLbzJLD(fNcJMOVlghDPFWIqbKxPFWnhHfgA, pHrEGrdPBofoAufAGTEfjylsYLSSA, (uint)QjedazgWMJtSWFSVtXDhJFGiegFr, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(MevoYLFzDMFlDPEiTkyfkDKqdpHr.oJsyFKLPSMlekgCzKCXFHmehEQXpA), REcuMRCiWOOqQUWKdFRZGokrFRCl);
			if (num)
			{
				KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Waiting;
				deDDhsBxNwVYdmuNsYJWdogsmcXkA = true;
			}
			else
			{
				pkuEfuHSoOceSjzGduILAelEuYWD();
			}
			return num;
		}
		catch (Exception)
		{
			pkuEfuHSoOceSjzGduILAelEuYWD();
			return false;
		}
	}

	private void XKqiMLpySxpyiKpjmAcVshsrqTAm()
	{
		if (KVDtHxdKylzsUIDzjDdUEegvzavK != GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Waiting)
		{
			int kVDtHxdKylzsUIDzjDdUEegvzavK = (int)KVDtHxdKylzsUIDzjDdUEegvzavK;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + kVDtHxdKylzsUIDzjDdUEegvzavK);
		}
		switch (FKnwhnPDPzHTcbXcvfRzedlcGfWdA())
		{
		case VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error:
			pkuEfuHSoOceSjzGduILAelEuYWD();
			break;
		case VfGDlJqfZHFaHSivGsQQqsGfgDfu.Success:
			CfWDGRNkTMgfkBpKzGlhByLcXHlc();
			break;
		case VfGDlJqfZHFaHSivGsQQqsGfgDfu.Waiting:
			break;
		}
	}

	private VfGDlJqfZHFaHSivGsQQqsGfgDfu FKnwhnPDPzHTcbXcvfRzedlcGfWdA()
	{
		if (KVDtHxdKylzsUIDzjDdUEegvzavK != GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.Waiting)
		{
			return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
		}
		try
		{
			switch (edmPFVQXZAgSMnagypaqNIebBPiI.HrDyAZYAimOOVCLFSGnYHCUTvxDjA(CIGSVnaYqETglqOhuFJMcbATDqiF, true))
			{
			case 0u:
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Waiting;
			case 192u:
			{
				if (!edmPFVQXZAgSMnagypaqNIebBPiI.aSifBsgkVcMLsjDcLEcAniQaRLVI(fNcJMOVlghDPFWIqbKxPFWnhHfgA, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(MevoYLFzDMFlDPEiTkyfkDKqdpHr.oJsyFKLPSMlekgCzKCXFHmehEQXpA), out var num, false))
				{
					return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
				}
				return (num > 0) ? VfGDlJqfZHFaHSivGsQQqsGfgDfu.Success : VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Waiting;
			default:
				return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
			}
		}
		catch
		{
			return VfGDlJqfZHFaHSivGsQQqsGfgDfu.Error;
		}
	}

	private void pkuEfuHSoOceSjzGduILAelEuYWD()
	{
		KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.ErrorPending;
		GTkqHIonbTfRBwFlQLrUqTxWrqnR();
	}

	private void GTkqHIonbTfRBwFlQLrUqTxWrqnR()
	{
		if (KVDtHxdKylzsUIDzjDdUEegvzavK != GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.ErrorPending)
		{
			int kVDtHxdKylzsUIDzjDdUEegvzavK = (int)KVDtHxdKylzsUIDzjDdUEegvzavK;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + kVDtHxdKylzsUIDzjDdUEegvzavK);
		}
		KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.FinishedError;
	}

	private void CfWDGRNkTMgfkBpKzGlhByLcXHlc()
	{
		KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.SuccessPending;
		mwFJJKrujzMLqPOXhGJMAuuKQFNfA();
	}

	private void mwFJJKrujzMLqPOXhGJMAuuKQFNfA()
	{
		if (KVDtHxdKylzsUIDzjDdUEegvzavK != GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.SuccessPending)
		{
			int kVDtHxdKylzsUIDzjDdUEegvzavK = (int)KVDtHxdKylzsUIDzjDdUEegvzavK;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + kVDtHxdKylzsUIDzjDdUEegvzavK);
		}
		KVDtHxdKylzsUIDzjDdUEegvzavK = GYyFyoPXxbgMLgDkfCtNDOmFFZVZb.FinishedSuccess;
		pHrEGrdPBofoAufAGTEfjylsYLSSA.Write(ReInput.realTime, QjedazgWMJtSWFSVtXDhJFGiegFr);
	}

	private void OReNkvHgBaaIbduxxeUDJipbQvVj()
	{
		XgnQvdhNXOrMMPINDVGYfhgMUfVP();
		pHrEGrdPBofoAufAGTEfjylsYLSSA.Clear();
		JnwBHEyxHcbAnkhEMHrHZavmykRk = 0;
		deDDhsBxNwVYdmuNsYJWdogsmcXkA = false;
	}

	private void XgnQvdhNXOrMMPINDVGYfhgMUfVP()
	{
		edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA yIAkmGDKNBTAeODUKEvafjOatpYwA = default(edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA);
		yIAkmGDKNBTAeODUKEvafjOatpYwA.hRNCKQafqMcZywIuKByzzVZhElRt = new IntPtr((int)TYFJnGvqKaBiuQJXGJeKxgRsLepH);
		yIAkmGDKNBTAeODUKEvafjOatpYwA.JNpeYGPcEmXZdPuCVLvwUUBLLxmJ = IntPtr.Zero;
		yIAkmGDKNBTAeODUKEvafjOatpYwA.HXncOkIfFtjqkgsgwpGtwNiugVncb = IntPtr.Zero;
		yIAkmGDKNBTAeODUKEvafjOatpYwA.oQrUHEsVKCgCtlSJAjXGETimnyMg = 0;
		yIAkmGDKNBTAeODUKEvafjOatpYwA.zNJoUDXobzeELMxatlkCmCGEatUeA = 0;
		MevoYLFzDMFlDPEiTkyfkDKqdpHr.QkYCmYRuXflOvGNGbdVbrlDqToex = yIAkmGDKNBTAeODUKEvafjOatpYwA;
	}

	private bool DyjpmXkxKgJcEhbpMcfuUumYqTAg()
	{
		if (dJUkERNJwiYpqVRPoyeIAxAEZNyA >= 10)
		{
			return false;
		}
		if (!aLOgtXLcbLvldmRYkMxbtDhjINAL())
		{
			dJUkERNJwiYpqVRPoyeIAxAEZNyA++;
			return false;
		}
		if (dJUkERNJwiYpqVRPoyeIAxAEZNyA > 0)
		{
			dJUkERNJwiYpqVRPoyeIAxAEZNyA = 0;
		}
		return true;
	}

	private bool aLOgtXLcbLvldmRYkMxbtDhjINAL()
	{
		if (fNcJMOVlghDPFWIqbKxPFWnhHfgA != edmPFVQXZAgSMnagypaqNIebBPiI.ZCbxcdZGGByxfBpqlmRFbGeSOXvT)
		{
			return true;
		}
		if (!qGjvkgmzRrhweOODcoENsMMsOksu)
		{
			return false;
		}
		IntPtr intPtr = SIYuejvQjndRFJfAYGpZwmWjVrTh.KnKRkIbplaylLYnvvutFgSMbPTWI(ZoseEaVsmxDToIfazcupRwWSrGif, KRlBBVNENHhjaxVLrSwqLDZMBPEO.Overlapped, 3221225472u, VQXgTjBnGHNJmJPzKCMciSKedVQMc.ShareRead | VQXgTjBnGHNJmJPzKCMciSKedVQMc.ShareWrite);
		if (intPtr == edmPFVQXZAgSMnagypaqNIebBPiI.ZCbxcdZGGByxfBpqlmRFbGeSOXvT)
		{
			return false;
		}
		fNcJMOVlghDPFWIqbKxPFWnhHfgA = intPtr;
		return true;
	}

	private void yrCQhJWzcMAKGYdeXAYQIPykgYFP()
	{
		if (!(fNcJMOVlghDPFWIqbKxPFWnhHfgA == edmPFVQXZAgSMnagypaqNIebBPiI.ZCbxcdZGGByxfBpqlmRFbGeSOXvT))
		{
			SIYuejvQjndRFJfAYGpZwmWjVrTh.ZxsgpNvFFQdELlTlvHLpYgfgdsUH(fNcJMOVlghDPFWIqbKxPFWnhHfgA);
			fNcJMOVlghDPFWIqbKxPFWnhHfgA = edmPFVQXZAgSMnagypaqNIebBPiI.ZCbxcdZGGByxfBpqlmRFbGeSOXvT;
		}
	}

	[MonoPInvokeCallback(typeof(edmPFVQXZAgSMnagypaqNIebBPiI.XldoBUXqwwDikcvOfyiflVwLzCETA))]
	private static void rHxiCgMpLCgpJVOqGgVqzghdFfncA(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		yBhIUicZfcGBwEjyfofRSIIcrHeAB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void oFDfNVIUPnrNRtMmWvtrchqnxDZr()
	{
		try
		{
			yBhIUicZfcGBwEjyfofRSIIcrHeAB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void yBhIUicZfcGBwEjyfofRSIIcrHeAB(bool P_0)
	{
		if (eQdZQfVJnjSpdePfATYMehqsvSou)
		{
			return;
		}
		using (new Locker(ocTXkGdjAZrDjJDMEqwTalLfTsGP))
		{
			if (P_0)
			{
				MevoYLFzDMFlDPEiTkyfkDKqdpHr.Dispose();
				ObjectInstanceTracker.Default.Unregister(TYFJnGvqKaBiuQJXGJeKxgRsLepH);
			}
			yrCQhJWzcMAKGYdeXAYQIPykgYFP();
			eQdZQfVJnjSpdePfATYMehqsvSou = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void fgDwOZnEnluxPGYlKMBinKUYjMYH(string P_0)
	{
	}
}
