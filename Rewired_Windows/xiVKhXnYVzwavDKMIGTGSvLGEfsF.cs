using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class xiVKhXnYVzwavDKMIGTGSvLGEfsF : VJJORtyhxtIZFDAvjUdtXgBUbPYD
{
	internal abstract class qzDDnmAMtAHREEfADcrxdWlbyfBqe
	{
		private int tIBfDYisPxrBmKvMJhnxoFQmHUjyA;

		private int[] EBGeAauMNYtyyFmqxHdRPTolgdfP;

		protected ELWquDtzkdGHDiJlLXvhLTVhOyAB[] ShjgISPwuxfinORONDEyNUOmfcMO;

		public ELWquDtzkdGHDiJlLXvhLTVhOyAB SgEetgATjqFQjeKYFGqlNUFjfMMxA;

		private int zdeIvTFxjqrdeFNqiknceiKiLUbbb;

		private int GQBBPJzoNGhrSsNwBunLdGBlkDAM = -1;

		private bool KIjyIASRkSmVmIoWUFUvEHlfnXZQ;

		protected int FHokiXTnHkUDqNtkCxWfvUcgFnXe => tIBfDYisPxrBmKvMJhnxoFQmHUjyA;

		protected int[] RCtxNQOAVXaKhhWMCVWOQYhJICWH => EBGeAauMNYtyyFmqxHdRPTolgdfP;

		public UpdateLoopType NDsPbxyezgZuIXkxLjKdxovHDNSA
		{
			set
			{
				if (GQBBPJzoNGhrSsNwBunLdGBlkDAM != (int)updateLoopType)
				{
					GQBBPJzoNGhrSsNwBunLdGBlkDAM = (int)updateLoopType;
					zdeIvTFxjqrdeFNqiknceiKiLUbbb = EBGeAauMNYtyyFmqxHdRPTolgdfP[(int)updateLoopType];
					SgEetgATjqFQjeKYFGqlNUFjfMMxA = ShjgISPwuxfinORONDEyNUOmfcMO[zdeIvTFxjqrdeFNqiknceiKiLUbbb];
				}
			}
		}

		public qzDDnmAMtAHREEfADcrxdWlbyfBqe()
		{
		}

		public void BkdjRcLhvHGWPwQLOrXASXxXBpJl(UpdateLoopSetting P_0, Func<UpdateLoopType, ELWquDtzkdGHDiJlLXvhLTVhOyAB> P_1)
		{
			if (KIjyIASRkSmVmIoWUFUvEHlfnXZQ)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			EBGeAauMNYtyyFmqxHdRPTolgdfP = new int[3];
			tIBfDYisPxrBmKvMJhnxoFQmHUjyA = 0;
			List<ELWquDtzkdGHDiJlLXvhLTVhOyAB> list = new List<ELWquDtzkdGHDiJlLXvhLTVhOyAB>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					EBGeAauMNYtyyFmqxHdRPTolgdfP[(int)list2[i]] = tIBfDYisPxrBmKvMJhnxoFQmHUjyA;
					tIBfDYisPxrBmKvMJhnxoFQmHUjyA++;
					list.Add(P_1(list2[i]));
				}
			}
			ShjgISPwuxfinORONDEyNUOmfcMO = list.ToArray();
			SgEetgATjqFQjeKYFGqlNUFjfMMxA = ShjgISPwuxfinORONDEyNUOmfcMO[0];
			KIjyIASRkSmVmIoWUFUvEHlfnXZQ = true;
		}

		private void GPkAQsrpnrTnAvmVgAPWqLkqvxdM(UpdateLoopType P_0, ELWquDtzkdGHDiJlLXvhLTVhOyAB P_1)
		{
			ShjgISPwuxfinORONDEyNUOmfcMO[EBGeAauMNYtyyFmqxHdRPTolgdfP[(int)P_0]] = P_1;
		}

		public virtual void MbkeGPcKdUHzrLwpDGvgJtLbeNxxA(UpdateLoopType P_0)
		{
			if (GQBBPJzoNGhrSsNwBunLdGBlkDAM != (int)P_0)
			{
				NDsPbxyezgZuIXkxLjKdxovHDNSA = P_0;
			}
		}

		public void yuuvejppLnfHCaArWinCyGHbkybab()
		{
			for (int i = 0; i < tIBfDYisPxrBmKvMJhnxoFQmHUjyA; i++)
			{
				ShjgISPwuxfinORONDEyNUOmfcMO[i].yijuQkbrjAaplRPSilzBxaFFcMnI();
			}
		}
	}

	internal abstract class ELWquDtzkdGHDiJlLXvhLTVhOyAB
	{
		public readonly UpdateLoopType udXlIorzzgjiLeRRzfQwZOYaYScq;

		public ELWquDtzkdGHDiJlLXvhLTVhOyAB(UpdateLoopType P_0)
		{
			udXlIorzzgjiLeRRzfQwZOYaYScq = P_0;
		}

		public abstract void yijuQkbrjAaplRPSilzBxaFFcMnI();
	}

	internal qzDDnmAMtAHREEfADcrxdWlbyfBqe gCJMNJfbcAfVAQppNjIUGmZAoHzY;

	public xiVKhXnYVzwavDKMIGTGSvLGEfsF(qzDDnmAMtAHREEfADcrxdWlbyfBqe P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		gCJMNJfbcAfVAQppNjIUGmZAoHzY = P_0;
	}

	public virtual void BCGcmapvEbIKVHbVuYWRyVedPpTs(UpdateLoopType P_0)
	{
		if (gCJMNJfbcAfVAQppNjIUGmZAoHzY != null)
		{
			gCJMNJfbcAfVAQppNjIUGmZAoHzY.MbkeGPcKdUHzrLwpDGvgJtLbeNxxA(P_0);
		}
	}
}
