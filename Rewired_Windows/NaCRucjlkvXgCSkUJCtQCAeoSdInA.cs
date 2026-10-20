using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class NaCRucjlkvXgCSkUJCtQCAeoSdInA : VJJORtyhxtIZFDAvjUdtXgBUbPYD
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TouchpadInfo
	{
		public int maxTouches;

		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public bool invertY;

		public bool reverseY;

		public TouchpadInfo(int P_0, int P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
		{
			maxTouches = P_0;
			minX = P_1;
			maxX = P_2;
			minY = P_3;
			maxY = P_4;
			invertY = P_5;
			reverseY = P_6;
		}

		public void CalculateTouch(ref TouchData data)
		{
			int num = (reverseY ? (maxY - data.positionRawY) : data.positionRawY);
			data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
			data.positionY = MathTools.ValueInNewRange(num, minY, maxY, 0f, 1f);
			data.positionAbsX = data.positionRawX;
			data.positionAbsY = num;
			if (data.positionAbsX > maxX)
			{
				data.positionAbsX = maxX;
			}
			if (data.positionAbsY > maxY)
			{
				data.positionAbsY = maxY;
			}
			if (data.positionAbsX < minX)
			{
				data.positionAbsX = minX;
			}
			if (data.positionAbsY < minY)
			{
				data.positionAbsY = minY;
			}
			if (invertY)
			{
				data.positionY *= -1f;
				data.positionAbsY *= -1;
			}
		}
	}

	private class iuadgUPoSIpCBNDQQVUxIIjRCnsGA
	{
		public readonly TouchData[] bnbTOguwngUsCjUgzFNPtrBiWVRU;

		public iuadgUPoSIpCBNDQQVUxIIjRCnsGA(int P_0)
		{
			bnbTOguwngUsCjUgzFNPtrBiWVRU = new TouchData[P_0];
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct TouchData
	{
		public int touchId;

		public float timeStamp;

		public bool isTouching;

		public int positionRawX;

		public int positionRawY;

		public float positionX;

		public float positionY;

		public int positionAbsX;

		public int positionAbsY;

		public void Clear()
		{
			touchId = -1;
			timeStamp = 0f;
			isTouching = false;
			positionRawX = 0;
			positionRawY = 0;
			positionX = 0f;
			positionY = 0f;
			positionAbsX = 0;
			positionAbsY = 0;
		}
	}

	private TouchpadInfo HjsqTnOCEZkgDZwMwbhHFnaYZfxN;

	private RingBuffer<iuadgUPoSIpCBNDQQVUxIIjRCnsGA> ppmZTBYrzNZHZwLdgCBBbKRjAeOHA;

	private TouchData[] nRHyIRvNHkZhfGPHnlgylhLaxQl;

	private Action<NativeBuffer, TouchData[]> kVGLVHziCQCNrRrqmLnvAdunPUvT;

	public TouchData[] KUQBOGfLZVeZToGzEycJtsYzolPab;

	private ObjectPool<iuadgUPoSIpCBNDQQVUxIIjRCnsGA> MTqkdXoJEyrMAPmJvwUZhmvUZPyG;

	public NaCRucjlkvXgCSkUJCtQCAeoSdInA(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		HjsqTnOCEZkgDZwMwbhHFnaYZfxN = P_1;
		kVGLVHziCQCNrRrqmLnvAdunPUvT = P_4;
		ppmZTBYrzNZHZwLdgCBBbKRjAeOHA = new RingBuffer<iuadgUPoSIpCBNDQQVUxIIjRCnsGA>(P_3);
		nRHyIRvNHkZhfGPHnlgylhLaxQl = new TouchData[P_1.maxTouches];
		KUQBOGfLZVeZToGzEycJtsYzolPab = new TouchData[P_1.maxTouches];
		for (int i = 0; i < KUQBOGfLZVeZToGzEycJtsYzolPab.Length; i++)
		{
			KUQBOGfLZVeZToGzEycJtsYzolPab[i].Clear();
		}
		MTqkdXoJEyrMAPmJvwUZhmvUZPyG = new ObjectPool<iuadgUPoSIpCBNDQQVUxIIjRCnsGA>(P_3, () => new iuadgUPoSIpCBNDQQVUxIIjRCnsGA(HjsqTnOCEZkgDZwMwbhHFnaYZfxN.maxTouches));
	}

	public virtual void gmFKVehXgcIvDmJhicMrMfSwGCLE(NativeBuffer P_0, double P_1)
	{
		if (kVGLVHziCQCNrRrqmLnvAdunPUvT == null)
		{
			return;
		}
		kVGLVHziCQCNrRrqmLnvAdunPUvT(P_0, nRHyIRvNHkZhfGPHnlgylhLaxQl);
		lock (ppmZTBYrzNZHZwLdgCBBbKRjAeOHA)
		{
			iuadgUPoSIpCBNDQQVUxIIjRCnsGA iuadgUPoSIpCBNDQQVUxIIjRCnsGA2 = MTqkdXoJEyrMAPmJvwUZhmvUZPyG.Get();
			for (int i = 0; i < HjsqTnOCEZkgDZwMwbhHFnaYZfxN.maxTouches; i++)
			{
				iuadgUPoSIpCBNDQQVUxIIjRCnsGA2.bnbTOguwngUsCjUgzFNPtrBiWVRU[i] = nRHyIRvNHkZhfGPHnlgylhLaxQl[i];
			}
			CollectionTools.Enqueue(MTqkdXoJEyrMAPmJvwUZhmvUZPyG, ppmZTBYrzNZHZwLdgCBBbKRjAeOHA, iuadgUPoSIpCBNDQQVUxIIjRCnsGA2, out var _);
		}
		HGMPQwEVmuPHHXTLBLcmfcyrCkkl();
	}

	public void HGMPQwEVmuPHHXTLBLcmfcyrCkkl()
	{
		for (int i = 0; i < KUQBOGfLZVeZToGzEycJtsYzolPab.Length; i++)
		{
			KUQBOGfLZVeZToGzEycJtsYzolPab[i].Clear();
		}
		lock (ppmZTBYrzNZHZwLdgCBBbKRjAeOHA)
		{
			int num = ppmZTBYrzNZHZwLdgCBBbKRjAeOHA.Count;
			while (num > 0)
			{
				iuadgUPoSIpCBNDQQVUxIIjRCnsGA iuadgUPoSIpCBNDQQVUxIIjRCnsGA2 = ppmZTBYrzNZHZwLdgCBBbKRjAeOHA.Dequeue();
				num--;
				for (int j = 0; j < iuadgUPoSIpCBNDQQVUxIIjRCnsGA2.bnbTOguwngUsCjUgzFNPtrBiWVRU.Length; j++)
				{
					HjsqTnOCEZkgDZwMwbhHFnaYZfxN.CalculateTouch(ref iuadgUPoSIpCBNDQQVUxIIjRCnsGA2.bnbTOguwngUsCjUgzFNPtrBiWVRU[j]);
					KUQBOGfLZVeZToGzEycJtsYzolPab[j] = iuadgUPoSIpCBNDQQVUxIIjRCnsGA2.bnbTOguwngUsCjUgzFNPtrBiWVRU[j];
				}
				MTqkdXoJEyrMAPmJvwUZhmvUZPyG.Return(iuadgUPoSIpCBNDQQVUxIIjRCnsGA2);
			}
		}
	}

	public bool NKWCgdlFAhYRGtzEYBcTkWuDbbZI(int P_0)
	{
		for (int i = 0; i < KUQBOGfLZVeZToGzEycJtsYzolPab.Length; i++)
		{
			if (KUQBOGfLZVeZToGzEycJtsYzolPab[i].isTouching && KUQBOGfLZVeZToGzEycJtsYzolPab[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private iuadgUPoSIpCBNDQQVUxIIjRCnsGA CjqfuZwvnfdLlLuvPmpDKcedsJeE()
	{
		return new iuadgUPoSIpCBNDQQVUxIIjRCnsGA(HjsqTnOCEZkgDZwMwbhHFnaYZfxN.maxTouches);
	}
}
