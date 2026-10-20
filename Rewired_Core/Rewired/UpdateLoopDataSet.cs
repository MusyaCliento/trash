using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		private class lPegirFDNXxRxFVIujrszrxDWZPk
		{
			public readonly UpdateLoopType OIrqZNHtfnQGvvBcKJBslTeukkaD;

			public T jtPHuWcYbAkVFixhUPwjPhcoBfAi;

			public lPegirFDNXxRxFVIujrszrxDWZPk(UpdateLoopType P_0)
			{
				OIrqZNHtfnQGvvBcKJBslTeukkaD = P_0;
			}
		}

		private const int YBdCMTpHZLpmDebaDaGQzyrsaKic = 0;

		private lPegirFDNXxRxFVIujrszrxDWZPk eCqZpvhafdtrPfquigBZjZHuBwEE;

		private int kERPnwbCvKSjUIHeXWyIxQuzrvXd;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] jbVtLhksVghcyKAwydwkPSuMFgNq;

		private readonly lPegirFDNXxRxFVIujrszrxDWZPk[] yOLQlIcnwSAJahKNJeqMMbaJdxRN;

		private UpdateLoopType QYIWFMzCyhYQbjQFZrmAJPiHwAbh = (UpdateLoopType)(-1);

		public T Current => eCqZpvhafdtrPfquigBZjZHuBwEE.jtPHuWcYbAkVFixhUPwjPhcoBfAi;

		public int Count => kERPnwbCvKSjUIHeXWyIxQuzrvXd;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= kERPnwbCvKSjUIHeXWyIxQuzrvXd)
				{
					throw new IndexOutOfRangeException();
				}
				return yOLQlIcnwSAJahKNJeqMMbaJdxRN[index].jtPHuWcYbAkVFixhUPwjPhcoBfAi;
			}
			set
			{
				if (index < 0 || index >= kERPnwbCvKSjUIHeXWyIxQuzrvXd)
				{
					throw new IndexOutOfRangeException();
				}
				yOLQlIcnwSAJahKNJeqMMbaJdxRN[index].jtPHuWcYbAkVFixhUPwjPhcoBfAi = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			jbVtLhksVghcyKAwydwkPSuMFgNq = new int[3];
			ArrayTools.Fill(jbVtLhksVghcyKAwydwkPSuMFgNq, -1);
			List<lPegirFDNXxRxFVIujrszrxDWZPk> list = new List<lPegirFDNXxRxFVIujrszrxDWZPk>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					lPegirFDNXxRxFVIujrszrxDWZPk lPegirFDNXxRxFVIujrszrxDWZPk2 = new lPegirFDNXxRxFVIujrszrxDWZPk(list2[i]);
					if (P_1 != null)
					{
						T jtPHuWcYbAkVFixhUPwjPhcoBfAi = P_1();
						lPegirFDNXxRxFVIujrszrxDWZPk2.jtPHuWcYbAkVFixhUPwjPhcoBfAi = jtPHuWcYbAkVFixhUPwjPhcoBfAi;
					}
					list.Add(lPegirFDNXxRxFVIujrszrxDWZPk2);
					jbVtLhksVghcyKAwydwkPSuMFgNq[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			yOLQlIcnwSAJahKNJeqMMbaJdxRN = list.ToArray();
			kERPnwbCvKSjUIHeXWyIxQuzrvXd = yOLQlIcnwSAJahKNJeqMMbaJdxRN.Length;
			SetUpdateLoop(yOLQlIcnwSAJahKNJeqMMbaJdxRN[0].OIrqZNHtfnQGvvBcKJBslTeukkaD);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (QYIWFMzCyhYQbjQFZrmAJPiHwAbh != updateLoop)
			{
				QYIWFMzCyhYQbjQFZrmAJPiHwAbh = updateLoop;
				eCqZpvhafdtrPfquigBZjZHuBwEE = yOLQlIcnwSAJahKNJeqMMbaJdxRN[jbVtLhksVghcyKAwydwkPSuMFgNq[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= kERPnwbCvKSjUIHeXWyIxQuzrvXd)
			{
				throw new IndexOutOfRangeException();
			}
			return yOLQlIcnwSAJahKNJeqMMbaJdxRN[index].jtPHuWcYbAkVFixhUPwjPhcoBfAi;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return yOLQlIcnwSAJahKNJeqMMbaJdxRN[jbVtLhksVghcyKAwydwkPSuMFgNq[(int)updateLoop]].jtPHuWcYbAkVFixhUPwjPhcoBfAi;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= kERPnwbCvKSjUIHeXWyIxQuzrvXd)
			{
				throw new IndexOutOfRangeException();
			}
			yOLQlIcnwSAJahKNJeqMMbaJdxRN[index].jtPHuWcYbAkVFixhUPwjPhcoBfAi = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= kERPnwbCvKSjUIHeXWyIxQuzrvXd)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yOLQlIcnwSAJahKNJeqMMbaJdxRN[index].OIrqZNHtfnQGvvBcKJBslTeukkaD;
		}
	}
}
