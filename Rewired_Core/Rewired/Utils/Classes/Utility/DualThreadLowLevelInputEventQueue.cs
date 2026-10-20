using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class iNsoFHDkoaGRQXtkjtFItrDMnrjW : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			LowLevelInputEvent INewEventWrapper.Event
			{
				get
				{
					return item;
				}
				set
				{
					item = value;
				}
			}

			public iNsoFHDkoaGRQXtkjtFItrDMnrjW(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue NgYoGlhUGHjPIcdzUkqoTSXnEFzH;

		private readonly LowLevelInputEventQueue louEtGcxwKOnNzZwEmQjRZlvmMxn;

		private readonly object PoiGdmkZHJrdpvwysstAGBuNMeDb;

		private uint pOrFAoYCBeGWCBpEiihkLwtgAPIO;

		private bool xhSTPvBfgzHhpEUgFciOIiVdYKkfB;

		private int oGHESXDfFREykuBTzhIPqGkYmRtAb;

		private int iWIzarZGgrlDJtYlwjlcYZVZnSgQ;

		private iNsoFHDkoaGRQXtkjtFItrDMnrjW qRzxzBIVseHUUlrOUORqohlLdGwq;

		public LowLevelInputEvent currentEvent;

		private bool MhriAsPHwJXFHNFXRsMEpCGBIFVA;

		public uint lastProcessedEventId => pOrFAoYCBeGWCBpEiihkLwtgAPIO;

		public int count
		{
			get
			{
				lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
				{
					return NgYoGlhUGHjPIcdzUkqoTSXnEFzH.Count;
				}
			}
		}

		public int capacity
		{
			get
			{
				lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
				{
					return NgYoGlhUGHjPIcdzUkqoTSXnEFzH.Capacity;
				}
			}
		}

		public int capacityBytes
		{
			get
			{
				lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
				{
					return NgYoGlhUGHjPIcdzUkqoTSXnEFzH.CapacityBytes;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			NgYoGlhUGHjPIcdzUkqoTSXnEFzH = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			louEtGcxwKOnNzZwEmQjRZlvmMxn = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			PoiGdmkZHJrdpvwysstAGBuNMeDb = new object();
			qRzxzBIVseHUUlrOUORqohlLdGwq = new iNsoFHDkoaGRQXtkjtFItrDMnrjW(PoiGdmkZHJrdpvwysstAGBuNMeDb);
		}

		public INewEventWrapper T_CreateEvent()
		{
			qRzxzBIVseHUUlrOUORqohlLdGwq.Lock();
			qRzxzBIVseHUUlrOUORqohlLdGwq.item = louEtGcxwKOnNzZwEmQjRZlvmMxn.CreateEvent();
			return qRzxzBIVseHUUlrOUORqohlLdGwq;
		}

		public void Update()
		{
			lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
			{
				NgYoGlhUGHjPIcdzUkqoTSXnEFzH.CopyNewEventsFrom(louEtGcxwKOnNzZwEmQjRZlvmMxn);
			}
		}

		public void Clear()
		{
			lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
			{
				StopProcessingEvents();
				NgYoGlhUGHjPIcdzUkqoTSXnEFzH.Clear();
				louEtGcxwKOnNzZwEmQjRZlvmMxn.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (iWIzarZGgrlDJtYlwjlcYZVZnSgQ == 0)
			{
				Update();
				int num = NgYoGlhUGHjPIcdzUkqoTSXnEFzH.FindNextIndex(pOrFAoYCBeGWCBpEiihkLwtgAPIO);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				iWIzarZGgrlDJtYlwjlcYZVZnSgQ = num;
				xhSTPvBfgzHhpEUgFciOIiVdYKkfB = true;
				oGHESXDfFREykuBTzhIPqGkYmRtAb = NgYoGlhUGHjPIcdzUkqoTSXnEFzH.Count;
			}
			if (iWIzarZGgrlDJtYlwjlcYZVZnSgQ >= oGHESXDfFREykuBTzhIPqGkYmRtAb)
			{
				currentEvent = default(LowLevelInputEvent);
				xhSTPvBfgzHhpEUgFciOIiVdYKkfB = false;
				iWIzarZGgrlDJtYlwjlcYZVZnSgQ = 0;
				return false;
			}
			if (NgYoGlhUGHjPIcdzUkqoTSXnEFzH.TryGetNext(iWIzarZGgrlDJtYlwjlcYZVZnSgQ, out currentEvent))
			{
				pOrFAoYCBeGWCBpEiihkLwtgAPIO = currentEvent.GetId();
				iWIzarZGgrlDJtYlwjlcYZVZnSgQ++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			xhSTPvBfgzHhpEUgFciOIiVdYKkfB = false;
			iWIzarZGgrlDJtYlwjlcYZVZnSgQ = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			xhSTPvBfgzHhpEUgFciOIiVdYKkfB = false;
			iWIzarZGgrlDJtYlwjlcYZVZnSgQ = 0;
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other == this)
			{
				return;
			}
			lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
			{
				lock (other.PoiGdmkZHJrdpvwysstAGBuNMeDb)
				{
					NgYoGlhUGHjPIcdzUkqoTSXnEFzH.CopyAllFrom(other.NgYoGlhUGHjPIcdzUkqoTSXnEFzH);
					louEtGcxwKOnNzZwEmQjRZlvmMxn.CopyAllFrom(other.louEtGcxwKOnNzZwEmQjRZlvmMxn);
					pOrFAoYCBeGWCBpEiihkLwtgAPIO = other.pOrFAoYCBeGWCBpEiihkLwtgAPIO;
					xhSTPvBfgzHhpEUgFciOIiVdYKkfB = other.xhSTPvBfgzHhpEUgFciOIiVdYKkfB;
					oGHESXDfFREykuBTzhIPqGkYmRtAb = other.oGHESXDfFREykuBTzhIPqGkYmRtAb;
					iWIzarZGgrlDJtYlwjlcYZVZnSgQ = other.iWIzarZGgrlDJtYlwjlcYZVZnSgQ;
				}
			}
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

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (MhriAsPHwJXFHNFXRsMEpCGBIFVA)
			{
				return;
			}
			if (disposing)
			{
				lock (PoiGdmkZHJrdpvwysstAGBuNMeDb)
				{
					NgYoGlhUGHjPIcdzUkqoTSXnEFzH.Dispose();
					louEtGcxwKOnNzZwEmQjRZlvmMxn.Dispose();
				}
			}
			MhriAsPHwJXFHNFXRsMEpCGBIFVA = true;
		}
	}
}
