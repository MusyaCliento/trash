using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class bimdKvbqUrLNpChzaxUOwpXBUjvcB
		{
			public const long GpeJXuWJoqUaCOZmZmmNUBmVOhTP = 10000000L;

			private double LVzOJIpeUYOkMImtkwZowSXEUtQn;

			private bool RPSKqoaPFtmQGSoysbINRqzMHwET;

			private double lyOtxbOePMIuAPPuWEjEKtGJwAuB;

			private double nhbChnqLTULphwYFRgWtUhlwIznC;

			public bool zCBNBDnGMxtRwYVJnJTYXXVhSolN => RPSKqoaPFtmQGSoysbINRqzMHwET;

			public double PEhbzPiwBPhmMuqZINeftwRdjxqGA
			{
				get
				{
					if (!RPSKqoaPFtmQGSoysbINRqzMHwET)
					{
						return nhbChnqLTULphwYFRgWtUhlwIznC;
					}
					return (double)Time.realtimeSinceStartup - lyOtxbOePMIuAPPuWEjEKtGJwAuB;
				}
			}

			public void vItKbVAXGHaDIcmnKGhvedTCtessA()
			{
				LVzOJIpeUYOkMImtkwZowSXEUtQn = Time.realtimeSinceStartup;
			}

			public void kltLwfpFSRZCJJQMxnFCPKGgxTCM()
			{
				if (!RPSKqoaPFtmQGSoysbINRqzMHwET)
				{
					RPSKqoaPFtmQGSoysbINRqzMHwET = true;
					lyOtxbOePMIuAPPuWEjEKtGJwAuB = LVzOJIpeUYOkMImtkwZowSXEUtQn;
				}
			}

			public void jmWrqiVnmDbSnaTkRUKsPUGDcfZEb()
			{
				if (RPSKqoaPFtmQGSoysbINRqzMHwET)
				{
					RPSKqoaPFtmQGSoysbINRqzMHwET = false;
					nhbChnqLTULphwYFRgWtUhlwIznC += LVzOJIpeUYOkMImtkwZowSXEUtQn - lyOtxbOePMIuAPPuWEjEKtGJwAuB;
				}
			}

			public void WNRDZioEglcbOKFVInkCeZSuWMjHA()
			{
				lyOtxbOePMIuAPPuWEjEKtGJwAuB = 0.0;
				nhbChnqLTULphwYFRgWtUhlwIznC = 0.0;
				bool rPSKqoaPFtmQGSoysbINRqzMHwET = RPSKqoaPFtmQGSoysbINRqzMHwET;
				RPSKqoaPFtmQGSoysbINRqzMHwET = false;
				if (rPSKqoaPFtmQGSoysbINRqzMHwET)
				{
					kltLwfpFSRZCJJQMxnFCPKGgxTCM();
				}
			}
		}

		private const long aakaiLfukwowoVMhEvbGFkLqKsHv = 10000000L;

		private static UnityStopwatch TdrHeTHnDByPoisrknojUsNIIkbgb;

		private readonly bimdKvbqUrLNpChzaxUOwpXBUjvcB fiREOOROYUeAJWvebqzFuxruOtuw;

		private readonly bool SbbUnnvQpFZHrSDosGdESVCOTNgv;

		private double xlcisBSXpsoRAhetMBOefrulaMdk;

		public static UnityStopwatch Global => TdrHeTHnDByPoisrknojUsNIIkbgb ?? (TdrHeTHnDByPoisrknojUsNIIkbgb = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return xlcisBSXpsoRAhetMBOefrulaMdk;
			}
			set
			{
				xlcisBSXpsoRAhetMBOefrulaMdk = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(xlcisBSXpsoRAhetMBOefrulaMdk * 10000000.0);
			}
			set
			{
				xlcisBSXpsoRAhetMBOefrulaMdk = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => fiREOOROYUeAJWvebqzFuxruOtuw.PEhbzPiwBPhmMuqZINeftwRdjxqGA + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => fiREOOROYUeAJWvebqzFuxruOtuw.PEhbzPiwBPhmMuqZINeftwRdjxqGA;

		long StopwatchBase.elapsedMilliseconds => (long)((fiREOOROYUeAJWvebqzFuxruOtuw.PEhbzPiwBPhmMuqZINeftwRdjxqGA + xlcisBSXpsoRAhetMBOefrulaMdk) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(fiREOOROYUeAJWvebqzFuxruOtuw.PEhbzPiwBPhmMuqZINeftwRdjxqGA * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => fiREOOROYUeAJWvebqzFuxruOtuw.zCBNBDnGMxtRwYVJnJTYXXVhSolN;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(false)
		{
		}

		private UnityStopwatch(bool P_0)
		{
			fiREOOROYUeAJWvebqzFuxruOtuw = new bimdKvbqUrLNpChzaxUOwpXBUjvcB();
			SVvbUgHNPphCiMRVrQODUjjjbOsR();
			if (P_0)
			{
				Start();
			}
			SbbUnnvQpFZHrSDosGdESVCOTNgv = P_0;
		}

		~UnityStopwatch()
		{
			zRQmgmZkQFoatgLGZpMoOsYUeIdB();
		}

		public override void Stop()
		{
			if (SbbUnnvQpFZHrSDosGdESVCOTNgv)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			fiREOOROYUeAJWvebqzFuxruOtuw.jmWrqiVnmDbSnaTkRUKsPUGDcfZEb();
		}

		public override void Start()
		{
			if (!SbbUnnvQpFZHrSDosGdESVCOTNgv)
			{
				fiREOOROYUeAJWvebqzFuxruOtuw.kltLwfpFSRZCJJQMxnFCPKGgxTCM();
			}
		}

		public override void Reset()
		{
			if (SbbUnnvQpFZHrSDosGdESVCOTNgv)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			fiREOOROYUeAJWvebqzFuxruOtuw.WNRDZioEglcbOKFVInkCeZSuWMjHA();
		}

		private void SVvbUgHNPphCiMRVrQODUjjjbOsR()
		{
			zRQmgmZkQFoatgLGZpMoOsYUeIdB();
			ReInput.BeforeTimeManagerUpdateEvent += vZLgJVjNVQrjiViKblrUkDZogVdx;
		}

		private void zRQmgmZkQFoatgLGZpMoOsYUeIdB()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= vZLgJVjNVQrjiViKblrUkDZogVdx;
		}

		private void vZLgJVjNVQrjiViKblrUkDZogVdx(UpdateLoopType P_0)
		{
			fiREOOROYUeAJWvebqzFuxruOtuw.vItKbVAXGHaDIcmnKGhvedTCtessA();
		}
	}
}
