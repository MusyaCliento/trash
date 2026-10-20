using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent UHTUMplEQmlDThpmIqXZqPRPtUL;

		private readonly NativeRingBuffer gyKEVuedqrOXFbpxEECrAdAYIKezb;

		private readonly int hHBWEJXsVGnnMbmfemQGfNjSjHKfA;

		private readonly int ucreKgCRSiYmWtkbhrzJWJHucymbA;

		private readonly int kpRoCsGSCfhoVrejvHkgdqxgvJhb;

		private readonly int RFNaMZdpyuhFFTrqzPeOgzpNIFbyA;

		private readonly int ZXlbxBvSycnfgiKvcwszcfWPGbOg;

		private uint sXXiPxdMRsBjNbgQoWEMBBtQgkLR;

		private bool OZoAgBVkIRjeUaVaKwQlefUkFTvab;

		public int Count => gyKEVuedqrOXFbpxEECrAdAYIKezb.BytesInBuffer / RFNaMZdpyuhFFTrqzPeOgzpNIFbyA;

		public int Capacity => ZXlbxBvSycnfgiKvcwszcfWPGbOg;

		public int CapacityBytes => ZXlbxBvSycnfgiKvcwszcfWPGbOg * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(gyKEVuedqrOXFbpxEECrAdAYIKezb.GetPointerFromReadPosition(index * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA), hHBWEJXsVGnnMbmfemQGfNjSjHKfA, ucreKgCRSiYmWtkbhrzJWJHucymbA, kpRoCsGSCfhoVrejvHkgdqxgvJhb);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			ZXlbxBvSycnfgiKvcwszcfWPGbOg = P_0;
			hHBWEJXsVGnnMbmfemQGfNjSjHKfA = P_1;
			ucreKgCRSiYmWtkbhrzJWJHucymbA = P_2;
			kpRoCsGSCfhoVrejvHkgdqxgvJhb = P_3;
			RFNaMZdpyuhFFTrqzPeOgzpNIFbyA = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			gyKEVuedqrOXFbpxEECrAdAYIKezb = new NativeRingBuffer(ZXlbxBvSycnfgiKvcwszcfWPGbOg * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA);
			UHTUMplEQmlDThpmIqXZqPRPtUL = new LowLevelInputEvent(IntPtr.Zero, hHBWEJXsVGnnMbmfemQGfNjSjHKfA, ucreKgCRSiYmWtkbhrzJWJHucymbA, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = gyKEVuedqrOXFbpxEECrAdAYIKezb.Allocate(RFNaMZdpyuhFFTrqzPeOgzpNIFbyA, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, hHBWEJXsVGnnMbmfemQGfNjSjHKfA, ucreKgCRSiYmWtkbhrzJWJHucymbA, kpRoCsGSCfhoVrejvHkgdqxgvJhb);
			result.SetId(sXXiPxdMRsBjNbgQoWEMBBtQgkLR = MiscTools.Tick(sXXiPxdMRsBjNbgQoWEMBBtQgkLR));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = gyKEVuedqrOXFbpxEECrAdAYIKezb.BytesInBuffer / RFNaMZdpyuhFFTrqzPeOgzpNIFbyA;
			if (num == 0)
			{
				return -1;
			}
			UHTUMplEQmlDThpmIqXZqPRPtUL._buffer = gyKEVuedqrOXFbpxEECrAdAYIKezb.GetPointerFromReadPosition(0);
			uint num2 = UHTUMplEQmlDThpmIqXZqPRPtUL.GetId();
			int num3 = 0;
			if (MiscTools.IsTickNewer(id, num2))
			{
				num3 = (int)MiscTools.TickDifference(id, num2) + 1;
				num2 = MiscTools.Tick(id);
			}
			for (int i = num3; i < num; i++)
			{
				if (!MiscTools.IsTickNewer(num2, id))
				{
					num2 = MiscTools.Tick(num2);
					continue;
				}
				return i;
			}
			return -1;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			if (index < 0 || index >= gyKEVuedqrOXFbpxEECrAdAYIKezb.BytesInBuffer / RFNaMZdpyuhFFTrqzPeOgzpNIFbyA)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(gyKEVuedqrOXFbpxEECrAdAYIKezb.GetPointerFromReadPosition(index * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA), hHBWEJXsVGnnMbmfemQGfNjSjHKfA, ucreKgCRSiYmWtkbhrzJWJHucymbA, kpRoCsGSCfhoVrejvHkgdqxgvJhb);
			return true;
		}

		public void Clear()
		{
			gyKEVuedqrOXFbpxEECrAdAYIKezb.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			gyKEVuedqrOXFbpxEECrAdAYIKezb.CopyFrom(other.gyKEVuedqrOXFbpxEECrAdAYIKezb);
			sXXiPxdMRsBjNbgQoWEMBBtQgkLR = other.sXXiPxdMRsBjNbgQoWEMBBtQgkLR;
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			int count = Count;
			int count2 = other.Count;
			if (count2 == 0)
			{
				return;
			}
			if (count == 0)
			{
				CopyAllFrom(other);
				return;
			}
			uint id = new LowLevelInputEvent(gyKEVuedqrOXFbpxEECrAdAYIKezb.GetPointerFromReadPosition((count - 1) * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA), hHBWEJXsVGnnMbmfemQGfNjSjHKfA, ucreKgCRSiYmWtkbhrzJWJHucymbA, kpRoCsGSCfhoVrejvHkgdqxgvJhb).GetId();
			int num = other.FindNextIndex(id);
			if (num < 0)
			{
				return;
			}
			int num2 = count2 - num;
			if (num2 != 0)
			{
				for (int i = 0; i < num2; i++)
				{
					uint passId;
					IntPtr buffer = gyKEVuedqrOXFbpxEECrAdAYIKezb.Allocate(RFNaMZdpyuhFFTrqzPeOgzpNIFbyA, zeroFill: false, out passId);
					other.gyKEVuedqrOXFbpxEECrAdAYIKezb.RandomRead(buffer, RFNaMZdpyuhFFTrqzPeOgzpNIFbyA, RFNaMZdpyuhFFTrqzPeOgzpNIFbyA, other.gyKEVuedqrOXFbpxEECrAdAYIKezb.GetOffsetFromReadPosition((num + i) * RFNaMZdpyuhFFTrqzPeOgzpNIFbyA));
				}
				sXXiPxdMRsBjNbgQoWEMBBtQgkLR = other.sXXiPxdMRsBjNbgQoWEMBBtQgkLR;
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

		~LowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!OZoAgBVkIRjeUaVaKwQlefUkFTvab)
			{
				if (disposing)
				{
					gyKEVuedqrOXFbpxEECrAdAYIKezb.Dispose();
				}
				OZoAgBVkIRjeUaVaKwQlefUkFTvab = true;
			}
		}
	}
}
