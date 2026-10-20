using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint quvcdcNegXHCNcdSqUfchdWfmIWp = 750u;

		private readonly Stopwatch aNPDohjlrhWtwFEZaGpFimJQVHlSA;

		private Thread aMPoSEuSsQfFmAGGwAcaTRoYzTbgA;

		private ManualResetEvent bmcUiUFXEbuZnIffmRKgspNauYre;

		private ManualResetEvent XAqbirlatbDMzbqyVanLhMPjrbtMb;

		private AutoResetEvent TymGrvStVAGBBxOObCoediWepehaA;

		private bool YsFPgvHEpMmGkZTbbAUqZnRHdqEq;

		private bool ISRXTJABYrBgpEqULhGxTIKeSZTtA;

		private int HFESmLcjajxWRdtnuteCwxZlCfpo;

		private bool BRdhnCFJlrxjNATffzsrMVoaCGycb;

		private int FwdbMtDxfQZVsGwtAPJVjocuFKueA;

		private long gPWqThBcARlZwKGNsULyClyTlCOR;

		private bool flxhWdDEhThzcuzCFnfjmagfcfQA;

		private int ZqTFAKvzmpQMUWFrlzZruBXJEDdgA;

		private long lZLBpbjNoOrzDeuixMBxcPblBFFiA;

		private uint hXjkkOBoIMCkcCCvEZMIQyMQQAnWA;

		private readonly object issqBPsuOTbbDMBDzbyzBGjLdnOnA;

		private Queue<Action> hDoQDLcTHmjGrUGECTQiEkAKIcXH;

		private Queue<Action> wIrrqojBHxmgjYhqjJRIzbSvbuzy;

		private bool OEijvDTKFDbfhdmaDEilzjiwvfXCA;

		private Action naoaythlwdmjdDYHclgVgcdHsAvxb;

		[CompilerGenerated]
		private Action qQvEThbmgMesVBLMueOHmNCuaySdA;

		[CompilerGenerated]
		private Action ywLXBTlmDEwPCksMNiAtBAAsoCiiA;

		private bool QKbslKeSHALYGCAnMBdurzAEwARd;

		public bool isRunning => ISRXTJABYrBgpEqULhGxTIKeSZTtA;

		public bool isStopped
		{
			get
			{
				if (!ISRXTJABYrBgpEqULhGxTIKeSZTtA)
				{
					if (aMPoSEuSsQfFmAGGwAcaTRoYzTbgA == null)
					{
						return true;
					}
					return !aMPoSEuSsQfFmAGGwAcaTRoYzTbgA.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!BRdhnCFJlrxjNATffzsrMVoaCGycb)
				{
					return (long)FwdbMtDxfQZVsGwtAPJVjocuFKueA >= 750L;
				}
				return true;
			}
			set
			{
				if (value != BRdhnCFJlrxjNATffzsrMVoaCGycb)
				{
					BRdhnCFJlrxjNATffzsrMVoaCGycb = value;
					GIIZxmvufsXUNSjEMGSKItmpfeYw();
				}
			}
		}

		public bool useFixedTimeStep => flxhWdDEhThzcuzCFnfjmagfcfQA;

		public int fixedTimeStepFPS
		{
			get
			{
				return FwdbMtDxfQZVsGwtAPJVjocuFKueA;
			}
			set
			{
				FwdbMtDxfQZVsGwtAPJVjocuFKueA = ((value > 0) ? value : 0);
				GIIZxmvufsXUNSjEMGSKItmpfeYw();
			}
		}

		public int timeoutMS
		{
			get
			{
				return ZqTFAKvzmpQMUWFrlzZruBXJEDdgA;
			}
			set
			{
				ZqTFAKvzmpQMUWFrlzZruBXJEDdgA = ((value > 0) ? value : 0);
				GIIZxmvufsXUNSjEMGSKItmpfeYw();
			}
		}

		public uint tick => hXjkkOBoIMCkcCCvEZMIQyMQQAnWA;

		public event Action ThreadUpdateEvent
		{
			add
			{
				naoaythlwdmjdDYHclgVgcdHsAvxb = (Action)Delegate.Combine(naoaythlwdmjdDYHclgVgcdHsAvxb, value);
			}
			remove
			{
				naoaythlwdmjdDYHclgVgcdHsAvxb = (Action)Delegate.Remove(naoaythlwdmjdDYHclgVgcdHsAvxb, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = qQvEThbmgMesVBLMueOHmNCuaySdA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref qQvEThbmgMesVBLMueOHmNCuaySdA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = qQvEThbmgMesVBLMueOHmNCuaySdA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref qQvEThbmgMesVBLMueOHmNCuaySdA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action ThreadStartedEvent
		{
			add
			{
				_ThreadStartedEvent += value;
			}
			remove
			{
				_ThreadStartedEvent -= value;
			}
		}

		private event Action _ThreadPreStopEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = ywLXBTlmDEwPCksMNiAtBAAsoCiiA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref ywLXBTlmDEwPCksMNiAtBAAsoCiiA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = ywLXBTlmDEwPCksMNiAtBAAsoCiiA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref ywLXBTlmDEwPCksMNiAtBAAsoCiiA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action ThreadPreStopEvent
		{
			add
			{
				_ThreadPreStopEvent += value;
			}
			remove
			{
				_ThreadPreStopEvent -= value;
			}
		}

		public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			if (fixedTimeStep)
			{
				return new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
			}
			return new ThreadHelper(timeoutMS);
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return CreateFixedTimeStep(timeStepFPS, useHighPrecisionTimer: false, timeoutMS);
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return new ThreadHelper(timeStepFPS, useHighPrecisionTimer, timeoutMS);
		}

		private ThreadHelper()
			: this(0)
		{
		}

		private ThreadHelper(int P_0)
			: this(0, false, P_0)
		{
		}

		private ThreadHelper(int P_0, bool P_1, int P_2)
		{
			aNPDohjlrhWtwFEZaGpFimJQVHlSA = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			ZqTFAKvzmpQMUWFrlzZruBXJEDdgA = P_2;
			FwdbMtDxfQZVsGwtAPJVjocuFKueA = P_0;
			BRdhnCFJlrxjNATffzsrMVoaCGycb = P_1;
			GIIZxmvufsXUNSjEMGSKItmpfeYw();
			bmcUiUFXEbuZnIffmRKgspNauYre = new ManualResetEvent(initialState: false);
			XAqbirlatbDMzbqyVanLhMPjrbtMb = new ManualResetEvent(initialState: false);
			TymGrvStVAGBBxOObCoediWepehaA = new AutoResetEvent(initialState: false);
			issqBPsuOTbbDMBDzbyzBGjLdnOnA = new object();
			hDoQDLcTHmjGrUGECTQiEkAKIcXH = new Queue<Action>();
			wIrrqojBHxmgjYhqjJRIzbSvbuzy = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (ISRXTJABYrBgpEqULhGxTIKeSZTtA)
			{
				return false;
			}
			try
			{
				bmcUiUFXEbuZnIffmRKgspNauYre.Reset();
				TymGrvStVAGBBxOObCoediWepehaA.Reset();
				aMPoSEuSsQfFmAGGwAcaTRoYzTbgA = new Thread(lvwSvYoQAZoonKigeIEGeiRYsygz);
				aMPoSEuSsQfFmAGGwAcaTRoYzTbgA.Start();
				if (wait)
				{
					bmcUiUFXEbuZnIffmRKgspNauYre.WaitOne();
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void Stop(bool wait)
		{
			if (aMPoSEuSsQfFmAGGwAcaTRoYzTbgA != null && ISRXTJABYrBgpEqULhGxTIKeSZTtA && YsFPgvHEpMmGkZTbbAUqZnRHdqEq)
			{
				bmcUiUFXEbuZnIffmRKgspNauYre.Reset();
				YsFPgvHEpMmGkZTbbAUqZnRHdqEq = false;
				TymGrvStVAGBBxOObCoediWepehaA.Set();
				if (wait)
				{
					bmcUiUFXEbuZnIffmRKgspNauYre.WaitOne();
				}
				NDUEJqsjxHywnbhJUPvjOQEzTaWA();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!ISRXTJABYrBgpEqULhGxTIKeSZTtA)
			{
				return false;
			}
			if (!YsFPgvHEpMmGkZTbbAUqZnRHdqEq)
			{
				return false;
			}
			ResetTimeout();
			lock (issqBPsuOTbbDMBDzbyzBGjLdnOnA)
			{
				hDoQDLcTHmjGrUGECTQiEkAKIcXH.Enqueue(action);
				OEijvDTKFDbfhdmaDEilzjiwvfXCA = true;
				TymGrvStVAGBBxOObCoediWepehaA.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!ISRXTJABYrBgpEqULhGxTIKeSZTtA)
			{
				return false;
			}
			if (!YsFPgvHEpMmGkZTbbAUqZnRHdqEq)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!ISRXTJABYrBgpEqULhGxTIKeSZTtA || !YsFPgvHEpMmGkZTbbAUqZnRHdqEq)
			{
				return;
			}
			ResetTimeout();
			lock (issqBPsuOTbbDMBDzbyzBGjLdnOnA)
			{
				XAqbirlatbDMzbqyVanLhMPjrbtMb.Reset();
				HFESmLcjajxWRdtnuteCwxZlCfpo++;
			}
			TymGrvStVAGBBxOObCoediWepehaA.Set();
			XAqbirlatbDMzbqyVanLhMPjrbtMb.WaitOne();
			lock (issqBPsuOTbbDMBDzbyzBGjLdnOnA)
			{
				HFESmLcjajxWRdtnuteCwxZlCfpo--;
			}
		}

		public void ResetTimeout()
		{
			lZLBpbjNoOrzDeuixMBxcPblBFFiA = ((ZqTFAKvzmpQMUWFrlzZruBXJEDdgA > 0) ? (aNPDohjlrhWtwFEZaGpFimJQVHlSA.elapsedMillisecondsRaw + ZqTFAKvzmpQMUWFrlzZruBXJEDdgA) : 0);
		}

		private void lvwSvYoQAZoonKigeIEGeiRYsygz()
		{
			ResetTimeout();
			ISRXTJABYrBgpEqULhGxTIKeSZTtA = true;
			YsFPgvHEpMmGkZTbbAUqZnRHdqEq = true;
			bmcUiUFXEbuZnIffmRKgspNauYre.Set();
			if (qQvEThbmgMesVBLMueOHmNCuaySdA != null)
			{
				lock (qQvEThbmgMesVBLMueOHmNCuaySdA)
				{
					try
					{
						qQvEThbmgMesVBLMueOHmNCuaySdA();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (YsFPgvHEpMmGkZTbbAUqZnRHdqEq)
			{
				long num = aNPDohjlrhWtwFEZaGpFimJQVHlSA.elapsedTicksRaw + gPWqThBcARlZwKGNsULyClyTlCOR;
				UhOMYThoxGMROIIlXhXEAhZkNGgV();
				lock (issqBPsuOTbbDMBDzbyzBGjLdnOnA)
				{
					if (!OEijvDTKFDbfhdmaDEilzjiwvfXCA && HFESmLcjajxWRdtnuteCwxZlCfpo > 0)
					{
						XAqbirlatbDMzbqyVanLhMPjrbtMb.Set();
					}
				}
				if (naoaythlwdmjdDYHclgVgcdHsAvxb != null)
				{
					try
					{
						naoaythlwdmjdDYHclgVgcdHsAvxb();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (flxhWdDEhThzcuzCFnfjmagfcfQA)
				{
					if (BRdhnCFJlrxjNATffzsrMVoaCGycb || (long)FwdbMtDxfQZVsGwtAPJVjocuFKueA >= 750L)
					{
						while (aNPDohjlrhWtwFEZaGpFimJQVHlSA.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - aNPDohjlrhWtwFEZaGpFimJQVHlSA.elapsedTicksRaw;
						if (num2 > 0)
						{
							TymGrvStVAGBBxOObCoediWepehaA.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				hXjkkOBoIMCkcCCvEZMIQyMQQAnWA = ((hXjkkOBoIMCkcCCvEZMIQyMQQAnWA != uint.MaxValue) ? (hXjkkOBoIMCkcCCvEZMIQyMQQAnWA + 1) : 0u);
				if (ZqTFAKvzmpQMUWFrlzZruBXJEDdgA > 0 && aNPDohjlrhWtwFEZaGpFimJQVHlSA.elapsedMillisecondsRaw >= lZLBpbjNoOrzDeuixMBxcPblBFFiA)
				{
					YsFPgvHEpMmGkZTbbAUqZnRHdqEq = false;
				}
			}
			if (ywLXBTlmDEwPCksMNiAtBAAsoCiiA != null)
			{
				lock (ywLXBTlmDEwPCksMNiAtBAAsoCiiA)
				{
					try
					{
						ywLXBTlmDEwPCksMNiAtBAAsoCiiA();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			ISRXTJABYrBgpEqULhGxTIKeSZTtA = false;
			bmcUiUFXEbuZnIffmRKgspNauYre.Set();
		}

		private void UhOMYThoxGMROIIlXhXEAhZkNGgV()
		{
			if (!OEijvDTKFDbfhdmaDEilzjiwvfXCA)
			{
				return;
			}
			lock (issqBPsuOTbbDMBDzbyzBGjLdnOnA)
			{
				MiscTools.Swap(ref hDoQDLcTHmjGrUGECTQiEkAKIcXH, ref wIrrqojBHxmgjYhqjJRIzbSvbuzy);
				OEijvDTKFDbfhdmaDEilzjiwvfXCA = false;
			}
			while (wIrrqojBHxmgjYhqjJRIzbSvbuzy.Count > 0)
			{
				Action action = wIrrqojBHxmgjYhqjJRIzbSvbuzy.Dequeue();
				try
				{
					action();
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while processing thread Action queue.\n" + ex, requiredThreadSafety: true);
				}
			}
		}

		private void GIIZxmvufsXUNSjEMGSKItmpfeYw()
		{
			if (FwdbMtDxfQZVsGwtAPJVjocuFKueA <= 0)
			{
				flxhWdDEhThzcuzCFnfjmagfcfQA = false;
			}
			else
			{
				flxhWdDEhThzcuzCFnfjmagfcfQA = true;
				gPWqThBcARlZwKGNsULyClyTlCOR = Stopwatch.frequency / FwdbMtDxfQZVsGwtAPJVjocuFKueA;
			}
			ResetTimeout();
		}

		private void NDUEJqsjxHywnbhJUPvjOQEzTaWA()
		{
			aMPoSEuSsQfFmAGGwAcaTRoYzTbgA = null;
			ISRXTJABYrBgpEqULhGxTIKeSZTtA = false;
			YsFPgvHEpMmGkZTbbAUqZnRHdqEq = false;
			hDoQDLcTHmjGrUGECTQiEkAKIcXH.Clear();
			wIrrqojBHxmgjYhqjJRIzbSvbuzy.Clear();
			OEijvDTKFDbfhdmaDEilzjiwvfXCA = false;
			HFESmLcjajxWRdtnuteCwxZlCfpo = 0;
			bmcUiUFXEbuZnIffmRKgspNauYre.Reset();
			XAqbirlatbDMzbqyVanLhMPjrbtMb.Reset();
			lZLBpbjNoOrzDeuixMBxcPblBFFiA = 0L;
			hXjkkOBoIMCkcCCvEZMIQyMQQAnWA = 0u;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~ThreadHelper()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!QKbslKeSHALYGCAnMBdurzAEwARd)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					YsFPgvHEpMmGkZTbbAUqZnRHdqEq = false;
				}
				QKbslKeSHALYGCAnMBdurzAEwARd = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void qIXiiObzgAKSiyKBUADuLJQYskBT(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
