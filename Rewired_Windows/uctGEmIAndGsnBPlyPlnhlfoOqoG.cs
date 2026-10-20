using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

internal class uctGEmIAndGsnBPlyPlnhlfoOqoG
{
	private int dPDjhZplbLFmffVaToljcFzlFmngb;

	private int miUOmKEozquhUUOBJCGXxDHwisKX;

	private int RcRALMrYaMdJjqTCFvVTEDGflIPq;

	[CompilerGenerated]
	private Action m_FxFPDwUFaZlttspQRrgthdlYGjxL;

	public float YqehZNHYymBOIHmEqdEdyQFwXHSt
	{
		get
		{
			return VZLzKDYcZgnjSvyQEeuUeozoIzqL(dPDjhZplbLFmffVaToljcFzlFmngb);
		}
		set
		{
			dPDjhZplbLFmffVaToljcFzlFmngb = LnidHKpgUEgkMPGkHOqoARuJhSmi(num);
			if (this.FxFPDwUFaZlttspQRrgthdlYGjxL != null)
			{
				this.FxFPDwUFaZlttspQRrgthdlYGjxL();
			}
		}
	}

	public int BxdGSwjSxTfTpGjIDKQRyBcYsxwM
	{
		get
		{
			return dPDjhZplbLFmffVaToljcFzlFmngb;
		}
		set
		{
			dPDjhZplbLFmffVaToljcFzlFmngb = num;
			if (this.FxFPDwUFaZlttspQRrgthdlYGjxL != null)
			{
				this.FxFPDwUFaZlttspQRrgthdlYGjxL();
			}
		}
	}

	public event Action FxFPDwUFaZlttspQRrgthdlYGjxL
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_FxFPDwUFaZlttspQRrgthdlYGjxL;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_FxFPDwUFaZlttspQRrgthdlYGjxL, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_FxFPDwUFaZlttspQRrgthdlYGjxL;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_FxFPDwUFaZlttspQRrgthdlYGjxL, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public uctGEmIAndGsnBPlyPlnhlfoOqoG(int P_0, int P_1)
	{
		miUOmKEozquhUUOBJCGXxDHwisKX = P_0;
		RcRALMrYaMdJjqTCFvVTEDGflIPq = P_1;
	}

	private float VZLzKDYcZgnjSvyQEeuUeozoIzqL(int P_0)
	{
		return MathTools.Clamp((float)P_0 / (float)RcRALMrYaMdJjqTCFvVTEDGflIPq, 0f, 1f);
	}

	private int LnidHKpgUEgkMPGkHOqoARuJhSmi(float P_0)
	{
		return MathTools.Clamp((int)(P_0 * (float)RcRALMrYaMdJjqTCFvVTEDGflIPq), miUOmKEozquhUUOBJCGXxDHwisKX, RcRALMrYaMdJjqTCFvVTEDGflIPq);
	}
}
