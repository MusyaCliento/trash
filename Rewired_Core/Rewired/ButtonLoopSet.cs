using System;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] gNvAyIyCJpWRdWzcMJvmQHsHkxtu;

			private int erWMwAYMAFSfmtaYKytTvbKDoJCT;

			private readonly bool[] ZuABcFJjYBBAwRufKSLcqiixxnng;

			private readonly bool[] JgIJpemoClvcvsOGeKxtNCIKiIOh;

			public bool[] effectiveValue
			{
				get
				{
					if (updateLoop == UpdateLoopType.FixedUpdate)
					{
						BCVZqWhkpgChoXZfNNDYYMYtUSIw();
					}
					return gNvAyIyCJpWRdWzcMJvmQHsHkxtu;
				}
			}

			public ButtonData(int P_0, UpdateLoopType P_1)
			{
				updateLoop = P_1;
				values = new bool[P_0];
				JgIJpemoClvcvsOGeKxtNCIKiIOh = new bool[P_0];
				wasTrueThisFrame = new bool[P_0];
				ZuABcFJjYBBAwRufKSLcqiixxnng = new bool[P_0];
				gNvAyIyCJpWRdWzcMJvmQHsHkxtu = new bool[P_0];
				erWMwAYMAFSfmtaYKytTvbKDoJCT = ReInput.timeScalePauseChangedCount;
			}

			public void SetValue(int index, bool value)
			{
				if (updateLoop == UpdateLoopType.FixedUpdate)
				{
					BCVZqWhkpgChoXZfNNDYYMYtUSIw();
				}
				values[index] = value;
				if (value)
				{
					wasTrueThisFrame[index] = true;
					if (!JgIJpemoClvcvsOGeKxtNCIKiIOh[index])
					{
						ZuABcFJjYBBAwRufKSLcqiixxnng[index] = true;
					}
				}
				gNvAyIyCJpWRdWzcMJvmQHsHkxtu[index] = value | ZuABcFJjYBBAwRufKSLcqiixxnng[index];
				JgIJpemoClvcvsOGeKxtNCIKiIOh[index] = value;
			}

			public void ClearWasTrueThisFrame()
			{
				for (int i = 0; i < values.Length; i++)
				{
					wasTrueThisFrame[i] = false;
					ZuABcFJjYBBAwRufKSLcqiixxnng[i] = false;
					gNvAyIyCJpWRdWzcMJvmQHsHkxtu[i] = values[i];
				}
			}

			public void Clear()
			{
				Array.Clear(values, 0, values.Length);
				Array.Clear(JgIJpemoClvcvsOGeKxtNCIKiIOh, 0, values.Length);
				Array.Clear(wasTrueThisFrame, 0, wasTrueThisFrame.Length);
				Array.Clear(ZuABcFJjYBBAwRufKSLcqiixxnng, 0, ZuABcFJjYBBAwRufKSLcqiixxnng.Length);
				Array.Clear(gNvAyIyCJpWRdWzcMJvmQHsHkxtu, 0, gNvAyIyCJpWRdWzcMJvmQHsHkxtu.Length);
				erWMwAYMAFSfmtaYKytTvbKDoJCT = ReInput.timeScalePauseChangedCount;
			}

			public void Import(ButtonData source)
			{
				if (source != null)
				{
					int num = MathTools.Min(values.Length, source.values.Length);
					for (int i = 0; i < num; i++)
					{
						values[i] = source.values[i];
						JgIJpemoClvcvsOGeKxtNCIKiIOh[i] = source.JgIJpemoClvcvsOGeKxtNCIKiIOh[i];
						wasTrueThisFrame[i] = source.wasTrueThisFrame[i];
						ZuABcFJjYBBAwRufKSLcqiixxnng[i] = source.ZuABcFJjYBBAwRufKSLcqiixxnng[i];
						gNvAyIyCJpWRdWzcMJvmQHsHkxtu[i] = source.gNvAyIyCJpWRdWzcMJvmQHsHkxtu[i];
						erWMwAYMAFSfmtaYKytTvbKDoJCT = source.erWMwAYMAFSfmtaYKytTvbKDoJCT;
					}
				}
			}

			private void BCVZqWhkpgChoXZfNNDYYMYtUSIw()
			{
				if (ReInput.timeScalePauseChangedCount != erWMwAYMAFSfmtaYKytTvbKDoJCT)
				{
					ClearWasTrueThisFrame();
					erWMwAYMAFSfmtaYKytTvbKDoJCT = ReInput.timeScalePauseChangedCount;
				}
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting P_0, int P_1)
			: base(P_0)
		{
			buttonCount = P_1;
			for (int i = 0; i < base.Count; i++)
			{
				base[i] = new ButtonData(P_1, GetUpdateLoopType(i));
			}
		}

		public void SetValue(int index, bool value, double timestamp)
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].SetValue(index, value);
			}
		}

		public void Clear()
		{
			int count = base.Count;
			for (int i = 0; i < count; i++)
			{
				base[i].Clear();
			}
		}

		public void Import(ButtonLoopSet set)
		{
			if (set == null)
			{
				throw new ArgumentNullException("set");
			}
			if (set.buttonCount != buttonCount)
			{
				throw new Exception("Cannot import from a set with a different button count.");
			}
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Import(set[i]);
			}
		}
	}
}
