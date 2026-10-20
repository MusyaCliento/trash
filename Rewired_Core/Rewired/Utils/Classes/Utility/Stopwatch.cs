using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		private const long IcAgjKGzmchdcSGezuXvQvDEBgIfA = 10000000L;

		public static readonly Stopwatch Global;

		private static long tmrTiVmfatBCrFScaIiEfvQOMbHtA;

		private System.Diagnostics.Stopwatch DrckbbyoaOcZBoYitAKZRBLmsNKm;

		private long xfbxHeDSvzzkzuGClREyzWqtdSLd;

		public static long frequency => tmrTiVmfatBCrFScaIiEfvQOMbHtA;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return (double)xfbxHeDSvzzkzuGClREyzWqtdSLd / (double)tmrTiVmfatBCrFScaIiEfvQOMbHtA;
			}
			set
			{
				xfbxHeDSvzzkzuGClREyzWqtdSLd = (long)(value * (double)tmrTiVmfatBCrFScaIiEfvQOMbHtA);
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return xfbxHeDSvzzkzuGClREyzWqtdSLd;
			}
			set
			{
				xfbxHeDSvzzkzuGClREyzWqtdSLd = value;
			}
		}

		double StopwatchBase.elapsedSeconds => (double)(DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedTicks + offsetTicks) / (double)tmrTiVmfatBCrFScaIiEfvQOMbHtA;

		double StopwatchBase.elapsedSecondsRaw => (double)DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedTicks / (double)tmrTiVmfatBCrFScaIiEfvQOMbHtA;

		long StopwatchBase.elapsedMilliseconds => (long)((double)(DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedTicks + offsetTicks) / (double)tmrTiVmfatBCrFScaIiEfvQOMbHtA * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedMilliseconds;

		long StopwatchBase.elapsedTicks => DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedTicks + xfbxHeDSvzzkzuGClREyzWqtdSLd;

		long StopwatchBase.elapsedTicksRaw => DrckbbyoaOcZBoYitAKZRBLmsNKm.ElapsedTicks;

		bool StopwatchBase.isRunning => DrckbbyoaOcZBoYitAKZRBLmsNKm.IsRunning;

		static Stopwatch()
		{
			tmrTiVmfatBCrFScaIiEfvQOMbHtA = System.Diagnostics.Stopwatch.Frequency;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Global = stopwatch;
		}

		public static Stopwatch StartNew()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			if (tmrTiVmfatBCrFScaIiEfvQOMbHtA == 10000000)
			{
				return ticks;
			}
			return 10000000 / tmrTiVmfatBCrFScaIiEfvQOMbHtA;
		}

		public Stopwatch()
		{
			DrckbbyoaOcZBoYitAKZRBLmsNKm = new System.Diagnostics.Stopwatch();
		}

		public override void Stop()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			DrckbbyoaOcZBoYitAKZRBLmsNKm.Stop();
		}

		public override void Start()
		{
			if (this != Global)
			{
				DrckbbyoaOcZBoYitAKZRBLmsNKm.Start();
			}
		}

		public override void Reset()
		{
			if (this == Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			DrckbbyoaOcZBoYitAKZRBLmsNKm.Reset();
		}
	}
}
