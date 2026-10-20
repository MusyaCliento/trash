using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class xHnZWDhFGbiJownHBijvjqoTlMxEb<_0001> where _0001 : class
{
	private const float BYcGxwEtnFjMMAfOXrFtadJZQUGX = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> hDXGSdkzFmgyYdxTdyrYzpzQEozLb;

	private float vWgLVNaIPzjEhaBhrEoxRvqZsfMfA;

	private double nfhTaPEjjfZsOfbhPkETCTwxNWlp;

	private Func<_0001, _0001, bool> RSEfpaIFBsoFGGvCwvQIDWohzBEec;

	public float YLZPTtQpeJesKDzLEThBfjxPnYzF
	{
		get
		{
			return vWgLVNaIPzjEhaBhrEoxRvqZsfMfA;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			vWgLVNaIPzjEhaBhrEoxRvqZsfMfA = num;
		}
	}

	public xHnZWDhFGbiJownHBijvjqoTlMxEb(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		RSEfpaIFBsoFGGvCwvQIDWohzBEec = P_0;
		vWgLVNaIPzjEhaBhrEoxRvqZsfMfA = 60f;
		hDXGSdkzFmgyYdxTdyrYzpzQEozLb = new IndexedDictionary<Bytes20, List<WeakReference>>();
		hDXGSdkzFmgyYdxTdyrYzpzQEozLb.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 EYMpOyiRjmedkBfSviPFfZqDTlAb(Bytes20 P_0, _0001 P_1)
	{
		if (qrFrqzPWIsDJMlbgkLpFmaHheneF(P_0, P_1, out var result))
		{
			return result;
		}
		NXHLFpCwANwzyGWhCrhPkhelfuym(P_0, P_1);
		return P_1;
	}

	public bool qrFrqzPWIsDJMlbgkLpFmaHheneF(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		RgqTPsSLIWsmRHlphGcCEyEVPwALA();
		if (!hDXGSdkzFmgyYdxTdyrYzpzQEozLb.TryGetValue(P_0, out var value))
		{
			P_2 = null;
			return false;
		}
		for (int num = value.Count - 1; num >= 0; num--)
		{
			if (!(value[num].Target is _0001 val))
			{
				value.RemoveAt(num);
			}
			else if (RSEfpaIFBsoFGGvCwvQIDWohzBEec(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void NXHLFpCwANwzyGWhCrhPkhelfuym(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			RgqTPsSLIWsmRHlphGcCEyEVPwALA();
			if (!hDXGSdkzFmgyYdxTdyrYzpzQEozLb.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				hDXGSdkzFmgyYdxTdyrYzpzQEozLb.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void hQBbHWEPbIDtBvHpLqcMHnqdvMNP()
	{
		for (int num = hDXGSdkzFmgyYdxTdyrYzpzQEozLb.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = hDXGSdkzFmgyYdxTdyrYzpzQEozLb[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				hDXGSdkzFmgyYdxTdyrYzpzQEozLb.RemoveAt(num);
			}
		}
		nfhTaPEjjfZsOfbhPkETCTwxNWlp = ReInput.unscaledTime + (double)YLZPTtQpeJesKDzLEThBfjxPnYzF;
	}

	private void RgqTPsSLIWsmRHlphGcCEyEVPwALA()
	{
		if (vWgLVNaIPzjEhaBhrEoxRvqZsfMfA != 0f && !(ReInput.unscaledTime < nfhTaPEjjfZsOfbhPkETCTwxNWlp))
		{
			hQBbHWEPbIDtBvHpLqcMHnqdvMNP();
		}
	}
}
