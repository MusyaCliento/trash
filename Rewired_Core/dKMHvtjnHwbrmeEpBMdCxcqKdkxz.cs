using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class dKMHvtjnHwbrmeEpBMdCxcqKdkxz<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> bRztcbGCLueGaABfHESydTRhprcT;

	private Id auJumTVsdppabCMSWanPbTjKJbijA;

	private double jMjODGlnYbvIltkwbpeZIUmCBekd;

	private float wjSryMecSbzdikjKCdrZovoPmirT;

	public dKMHvtjnHwbrmeEpBMdCxcqKdkxz()
	{
		bRztcbGCLueGaABfHESydTRhprcT = new IndexedDictionary<uint, WeakReference>();
		auJumTVsdppabCMSWanPbTjKJbijA = 1u;
	}

	public dKMHvtjnHwbrmeEpBMdCxcqKdkxz(float P_0)
		: this()
	{
		wjSryMecSbzdikjKCdrZovoPmirT = P_0;
	}

	public bool lAcEviemZhMnKjTFEUZBGGTUQZcFB(uint P_0, out _0001 P_1)
	{
		if (!bRztcbGCLueGaABfHESydTRhprcT.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			bRztcbGCLueGaABfHESydTRhprcT.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint OxSTHoscbMWZIVblFwqRXSsOejoG(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		mTgNxuslpZLbVqSrreastkPhuhJT();
		bRztcbGCLueGaABfHESydTRhprcT.SetValue(auJumTVsdppabCMSWanPbTjKJbijA.id, new WeakReference(P_0, trackResurrection: false));
		auJumTVsdppabCMSWanPbTjKJbijA.Increment();
		return auJumTVsdppabCMSWanPbTjKJbijA.id;
	}

	public bool RjxcuGiHchffGTyZXnYuYpPwBJsJA(uint P_0)
	{
		mTgNxuslpZLbVqSrreastkPhuhJT();
		return bRztcbGCLueGaABfHESydTRhprcT.Remove(P_0);
	}

	public void vgRWaCmXOzvjDsezgCKXJmOEJMjb()
	{
		for (int num = bRztcbGCLueGaABfHESydTRhprcT.Count - 1; num >= 0; num--)
		{
			if (!bRztcbGCLueGaABfHESydTRhprcT[num].IsAlive)
			{
				bRztcbGCLueGaABfHESydTRhprcT.RemoveAt(num);
			}
		}
		jMjODGlnYbvIltkwbpeZIUmCBekd = ReInput.unscaledTime + (double)wjSryMecSbzdikjKCdrZovoPmirT;
	}

	public void LqbEaGEnaEhHpJTCavQVpRSxylKt(Action<_0001> P_0)
	{
		for (int num = bRztcbGCLueGaABfHESydTRhprcT.Count - 1; num >= 0; num--)
		{
			if (!(bRztcbGCLueGaABfHESydTRhprcT[num].Target is _0001 obj))
			{
				bRztcbGCLueGaABfHESydTRhprcT.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		jMjODGlnYbvIltkwbpeZIUmCBekd = ReInput.unscaledTime + (double)wjSryMecSbzdikjKCdrZovoPmirT;
	}

	private void mTgNxuslpZLbVqSrreastkPhuhJT()
	{
		if (!(wjSryMecSbzdikjKCdrZovoPmirT <= 0f) && ReInput.unscaledTime > jMjODGlnYbvIltkwbpeZIUmCBekd)
		{
			vgRWaCmXOzvjDsezgCKXJmOEJMjb();
		}
	}
}
