using System;
using Rewired;
using Rewired.Utils;

internal class YiwcomZCvMgfXhGkTHKiDqEgfOmd : GOJqgIzOFsUnPFJzQRAaRcOacDWS, ELcxqnjIBKqLBxYuSmwWERrVPWMu, YUhbQhiLFKRAUFwRWqBNoTItxqmB, qsgekoIkSLKHNvSvhDyqzbhlTpKd, IDisposable, lPcssJPgXzScBSWtGcoKpYaHsCUN
{
	InputSource OjQQfGnFDJzmKEafdABKsTevxLCm.InputSource => InputSource.SDL3;

	public YiwcomZCvMgfXhGkTHKiDqEgfOmd(XpNKCOqUzDasRgxXUoUMgbzXvBfj P_0, GdElFSEOhuyCrFfZjnsSYHuwFWAO P_1)
		: this(P_0, P_1, dHPpbhmiaqtelxmYmFpgoGAPMmoe.Joystick)
	{
	}

	protected YiwcomZCvMgfXhGkTHKiDqEgfOmd(XpNKCOqUzDasRgxXUoUMgbzXvBfj P_0, GdElFSEOhuyCrFfZjnsSYHuwFWAO P_1, dHPpbhmiaqtelxmYmFpgoGAPMmoe P_2)
		: this(P_0, P_1, P_2, P_1.VukEvBLvmrBftyCEzFgwLbAAWyJR, P_1.RmKSHNAGkceIRsmrGCuDobqChBTCA, P_1.FkDELqtzCmYPMVFpwfLQPTmSsXb, P_1.TKbHDwxJdmGNiCXUCkPdgLYfccNnA)
	{
	}

	protected YiwcomZCvMgfXhGkTHKiDqEgfOmd(XpNKCOqUzDasRgxXUoUMgbzXvBfj P_0, GdElFSEOhuyCrFfZjnsSYHuwFWAO P_1, dHPpbhmiaqtelxmYmFpgoGAPMmoe P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6)
	{
	}

	public override void XODLAQcDSeqnqYXPpFHPxhievRiB(int P_0, float P_1, bool P_2)
	{
		XUAqDfNckUTARXJyRKNOaatjlCke xUAqDfNckUTARXJyRKNOaatjlCke = base.ERODsKTKSAWKMPlebFBMbVgRFZjaA;
		if (xUAqDfNckUTARXJyRKNOaatjlCke == XUAqDfNckUTARXJyRKNOaatjlCke.None || !base.RrBntAiBLvYdWbroLqoTdBJylFRC || P_0 < 0 || P_0 >= base.rqkDbYkfOOEiiDWLSabGMJnYWAIxA)
		{
			return;
		}
		if (P_2)
		{
			Array.Clear(base.JkNxFKrIBSUOFBYawkVXLlTgWgkT, 0, base.JkNxFKrIBSUOFBYawkVXLlTgWgkT.Length);
		}
		P_1 = MathTools.Clamp01(P_1);
		wicUJjlSeZKGdhICJAwjEMHQcZwq(P_0, P_1);
		if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumble) != XUAqDfNckUTARXJyRKNOaatjlCke.None && P_0 >= 0 && P_0 < 2)
		{
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.gwiEGirqhIEGZoCAESAskWizsVMk(fnNOhmKjUQqFLmthSwtwsQbWFnkM, (ushort)(65535f * base.JkNxFKrIBSUOFBYawkVXLlTgWgkT[0]), (ushort)(65535f * base.JkNxFKrIBSUOFBYawkVXLlTgWgkT[1]), 0u);
		}
		else if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumbleTriggers) != XUAqDfNckUTARXJyRKNOaatjlCke.None && P_0 >= 2 && P_0 < 4)
		{
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.mKGdegfrwCtDfnSCqiDVsaBlayBgb(fnNOhmKjUQqFLmthSwtwsQbWFnkM, (ushort)(65535f * base.JkNxFKrIBSUOFBYawkVXLlTgWgkT[2]), (ushort)(65535f * base.JkNxFKrIBSUOFBYawkVXLlTgWgkT[3]), 0u);
		}
		else if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.HapticRumble) != XUAqDfNckUTARXJyRKNOaatjlCke.None)
		{
			for (int i = 0; i < base.rqkDbYkfOOEiiDWLSabGMJnYWAIxA; i++)
			{
				P_1 = MathTools.Max(base.JkNxFKrIBSUOFBYawkVXLlTgWgkT[i], P_1);
			}
			if (P_1 == 0f)
			{
				zJNwGHMSLyPHPkNrKtBMXPnNZqat();
			}
			else
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.lLjofaMxbtBHoabjktzJiVpBEWUF(base.HBZGXTBWpgNJKbcQLvEpHHKVfbdUA, P_1, 0u);
			}
		}
	}

	public override void zJNwGHMSLyPHPkNrKtBMXPnNZqat()
	{
		base.zJNwGHMSLyPHPkNrKtBMXPnNZqat();
		XUAqDfNckUTARXJyRKNOaatjlCke xUAqDfNckUTARXJyRKNOaatjlCke = base.ERODsKTKSAWKMPlebFBMbVgRFZjaA;
		if (xUAqDfNckUTARXJyRKNOaatjlCke != XUAqDfNckUTARXJyRKNOaatjlCke.None && base.RrBntAiBLvYdWbroLqoTdBJylFRC)
		{
			if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.HapticRumble) != XUAqDfNckUTARXJyRKNOaatjlCke.None)
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.xAqaFpDiGsHdaIYobbsRIlvjTNGqD(base.HBZGXTBWpgNJKbcQLvEpHHKVfbdUA);
			}
			if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumble) != XUAqDfNckUTARXJyRKNOaatjlCke.None)
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.gwiEGirqhIEGZoCAESAskWizsVMk(fnNOhmKjUQqFLmthSwtwsQbWFnkM, 0, 0, 0u);
			}
			if ((xUAqDfNckUTARXJyRKNOaatjlCke & XUAqDfNckUTARXJyRKNOaatjlCke.GamepadRumbleTriggers) != XUAqDfNckUTARXJyRKNOaatjlCke.None)
			{
				pxmGIZLDmjeWcctuwsIuvAjQwjgDA.mKGdegfrwCtDfnSCqiDVsaBlayBgb(fnNOhmKjUQqFLmthSwtwsQbWFnkM, 0, 0, 0u);
			}
		}
	}

	public override bool rEybbyoLWHwQTcvIdpCuAsswrlWx()
	{
		if (fnNOhmKjUQqFLmthSwtwsQbWFnkM == null || !fnNOhmKjUQqFLmthSwtwsQbWFnkM.IsValid)
		{
			return false;
		}
		return pxmGIZLDmjeWcctuwsIuvAjQwjgDA.bZeYUfmTABbLUNASGMVIpEsmAgOX(fnNOhmKjUQqFLmthSwtwsQbWFnkM);
	}

	protected virtual void dOfECXsJpivoVkUboJXdVphHPDzR(XpNKCOqUzDasRgxXUoUMgbzXvBfj P_0)
	{
		if (!base.RrBntAiBLvYdWbroLqoTdBJylFRC || !pxmGIZLDmjeWcctuwsIuvAjQwjgDA.gANjlmDTsQIGzUcZbecVDATzPqgUA(P_0))
		{
			return;
		}
		IntPtr intPtr = pxmGIZLDmjeWcctuwsIuvAjQwjgDA.NMOfwovcOatkwmMgXXiVMfVXUhl(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (!pxmGIZLDmjeWcctuwsIuvAjQwjgDA.CDONOOKvPTmUbXOeCpisEHiUJAyf(intPtr))
		{
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.icMhAPudNhfECtsZRSidUTfGLyaL(intPtr);
			return;
		}
		dkAoIXGknDzNDgjJKsvOQqjkDdMKA dkAoIXGknDzNDgjJKsvOQqjkDdMKA2 = new dkAoIXGknDzNDgjJKsvOQqjkDdMKA(intPtr);
		if (dkAoIXGknDzNDgjJKsvOQqjkDdMKA2 != null && dkAoIXGknDzNDgjJKsvOQqjkDdMKA2.IsValid)
		{
			int num = 0;
			XUAqDfNckUTARXJyRKNOaatjlCke xUAqDfNckUTARXJyRKNOaatjlCke = XUAqDfNckUTARXJyRKNOaatjlCke.None;
			xUAqDfNckUTARXJyRKNOaatjlCke |= XUAqDfNckUTARXJyRKNOaatjlCke.Haptic;
			if (pxmGIZLDmjeWcctuwsIuvAjQwjgDA.BGxuFBzLuqmHkAZdTRrmIlhWuMJd(dkAoIXGknDzNDgjJKsvOQqjkDdMKA2))
			{
				xUAqDfNckUTARXJyRKNOaatjlCke |= XUAqDfNckUTARXJyRKNOaatjlCke.HapticRumble;
				num = 2;
			}
			inTPeGqDSundZvJKBlzRexebNyVj(dkAoIXGknDzNDgjJKsvOQqjkDdMKA2, xUAqDfNckUTARXJyRKNOaatjlCke, num);
		}
	}

	protected virtual void oTKdICOQRccUkLLeCucBAZNKtqyq()
	{
		if (base.HBZGXTBWpgNJKbcQLvEpHHKVfbdUA != null && base.HBZGXTBWpgNJKbcQLvEpHHKVfbdUA.IsValid)
		{
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.icMhAPudNhfECtsZRSidUTfGLyaL(base.HBZGXTBWpgNJKbcQLvEpHHKVfbdUA);
			base.IfbrswRqWNgoRhnZykNfkuabVwtW();
		}
	}

	protected virtual void HllEtOknYNOTjlIXdMcMxekFzIRnA()
	{
		if (fnNOhmKjUQqFLmthSwtwsQbWFnkM != null && fnNOhmKjUQqFLmthSwtwsQbWFnkM.IsValid)
		{
			if (!rEybbyoLWHwQTcvIdpCuAsswrlWx())
			{
				fnNOhmKjUQqFLmthSwtwsQbWFnkM.Clear();
				return;
			}
			pxmGIZLDmjeWcctuwsIuvAjQwjgDA.yWDfbPGYdLfrzekXDjFMEmFOgNwoB(fnNOhmKjUQqFLmthSwtwsQbWFnkM);
			fnNOhmKjUQqFLmthSwtwsQbWFnkM.Clear();
		}
	}

	protected virtual float nGnepDIsVZEDfohwZiYthHRLWwrj(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32768f, 32767f, -1f, 1f);
	}

	protected virtual int LAsfXZDFrgfQzVKtAtzLtHKlkSzEb(short P_0)
	{
		return P_0 switch
		{
			0 => -1, 
			1 => 0, 
			3 => 4500, 
			2 => 9000, 
			6 => 13500, 
			4 => 18000, 
			12 => 22500, 
			8 => 27000, 
			9 => 31500, 
			_ => -1, 
		};
	}
}
