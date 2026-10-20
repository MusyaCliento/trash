using Unity.Mathematics;

namespace andywiecko.BurstTriangulator
{
	internal struct I128
	{
		private ulong hi;

		private ulong lo;

		public bool IsNegative => (hi & 0x8000000000000000uL) != 0;

		public I128(ulong hi, ulong lo)
		{
			this.hi = hi;
			this.lo = lo;
		}

		public static I128 operator +(I128 a, I128 b)
		{
			ulong num = a.lo + b.lo;
			return new I128(a.hi + b.hi + (ulong)((num < a.lo) ? 1 : 0), num);
		}

		public static I128 operator -(I128 a, I128 b)
		{
			ulong num = a.lo - b.lo;
			return new I128(a.hi - b.hi - (ulong)((num > a.lo) ? 1 : 0), num);
		}

		public static I128 operator -(I128 a)
		{
			return new I128(~a.hi, ~a.lo) + new I128(0uL, 1uL);
		}

		public static I128 Multiply(long slhs, long srhs)
		{
			bool num = (slhs < 0) ^ (srhs < 0);
			long num2 = math.abs(slhs);
			ulong num3 = (ulong)math.abs(srhs);
			ulong num4 = (ulong)(num2 & 0xFFFFFFFFu) * (num3 & 0xFFFFFFFFu);
			ulong num5 = ((ulong)num2 >> 32) * (num3 & 0xFFFFFFFFu);
			ulong num6 = (ulong)(num2 & 0xFFFFFFFFu) * (num3 >> 32);
			ulong num7 = ((ulong)num2 >> 32) * (num3 >> 32);
			ulong num8 = (num4 >> 32) + (num5 & 0xFFFFFFFFu) + num6;
			ulong num9 = (num5 >> 32) + (num8 >> 32) + num7;
			I128 i = new I128(num9, (num8 << 32) | (num4 & 0xFFFFFFFFu));
			return num ? (-i) : i;
		}
	}
}
