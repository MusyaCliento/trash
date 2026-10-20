using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct IntUtils : IUtils<int, int2, long>
	{
		public int Cast(long v)
		{
			return (int)v;
		}

		public int2 CircumCenter(int2 a, int2 b, int2 c)
		{
			int2 int5 = b - a;
			int2 int6 = c - a;
			long num = (long)int5.x * (long)int5.x + (long)int5.y * (long)int5.y;
			long num2 = (long)int6.x * (long)int6.x + (long)int6.y * (long)int6.y;
			long num3 = (long)int5.x * (long)int6.y - (long)int5.y * (long)int6.x;
			if (num3 != 0L)
			{
				return (int2)math.round(a + 0.5 / (double)num3 * (num * math.double2(int6.y, -int6.x) + num2 * math.double2(-int5.y, int5.x)));
			}
			return new int2(int.MaxValue);
		}

		public int Const(float v)
		{
			return (int)v;
		}

		public long EPSILON()
		{
			return 0L;
		}

		public bool InCircle(int2 a, int2 b, int2 c, int2 p)
		{
			a -= p;
			b -= p;
			c -= p;
			long slhs = (long)a.x * (long)a.x + (long)a.y * (long)a.y;
			long num = (long)b.x * (long)b.x + (long)b.y * (long)b.y;
			long num2 = (long)c.x * (long)c.x + (long)c.y * (long)c.y;
			long srhs = b.y * num2 - num * c.y;
			long srhs2 = b.x * num2 - num * c.x;
			long srhs3 = (long)b.x * (long)c.y - (long)b.y * (long)c.x;
			return (I128.Multiply(a.x, srhs) - I128.Multiply(a.y, srhs2) + I128.Multiply(slhs, srhs3)).IsNegative;
		}

		public long MaxValue()
		{
			return long.MaxValue;
		}

		public int2 MaxValue2()
		{
			return int.MaxValue;
		}

		public int2 MinValue2()
		{
			return int.MinValue;
		}

		public bool PointInsideTriangle(int2 p, int2 a, int2 b, int2 c)
		{
			if (cross(p - a, b - a) >= 0 && cross(p - b, c - b) >= 0)
			{
				return cross(p - c, a - c) >= 0;
			}
			return false;
			static long cross(int2 int5, int2 int6)
			{
				return (long)int5.x * (long)int6.y - (long)int5.y * (long)int6.x;
			}
		}

		public bool SupportsRefinement()
		{
			return false;
		}

		public int X(int2 a)
		{
			return a.x;
		}

		public int Y(int2 a)
		{
			return a.y;
		}

		public int Zero()
		{
			return 0;
		}

		public long ZeroTBig()
		{
			return 0L;
		}

		public int abs(int v)
		{
			return math.abs(v);
		}

		public long abs(long v)
		{
			return math.abs(v);
		}

		public int alpha(int concentricShellReferenceRadius, int edgeLengthSq)
		{
			throw new NotImplementedException();
		}

		public bool anygreaterthan(int a, int b, int c, int v)
		{
			throw new NotImplementedException();
		}

		public int2 avg(int2 a, int2 b)
		{
			return (a + b) / 2;
		}

		public int cos(int v)
		{
			throw new NotImplementedException();
		}

		public int diff(int a, int b)
		{
			return a - b;
		}

		public long diff(long a, long b)
		{
			return a - b;
		}

		public int2 diff(int2 a, int2 b)
		{
			return a - b;
		}

		public long distancesq(int2 a, int2 b)
		{
			return (long)(a - b).x * (long)(a - b).x + (long)(a - b).y * (long)(a - b).y;
		}

		public int dot(int2 a, int2 b)
		{
			throw new NotImplementedException();
		}

		public bool2 eq(int2 v, int2 w)
		{
			return v == w;
		}

		public bool2 ge(int2 a, int2 b)
		{
			return a >= b;
		}

		public bool greater(int a, int b)
		{
			return a > b;
		}

		public bool greater(long a, long b)
		{
			return a > b;
		}

		public int hashkey(int2 p, int2 c, int hashSize)
		{
			return (int)math.floor(pseudoAngle(p.x - c.x, p.y - c.y) * (double)hashSize) % hashSize;
			static double pseudoAngle(int dx, int dy)
			{
				int num = math.abs(dx) + math.abs(dy);
				if (num == 0)
				{
					return 0.0;
				}
				double num2 = (double)dx / (double)num;
				return ((dy > 0) ? (3.0 - num2) : (1.0 + num2)) / 4.0;
			}
		}

		public bool2 isfinite(int2 v)
		{
			return true;
		}

		public bool le(int a, int b)
		{
			return a <= b;
		}

		public bool le(long a, long b)
		{
			return a <= b;
		}

		public bool2 le(int2 a, int2 b)
		{
			return a <= b;
		}

		public int2 lerp(int2 a, int2 b, int v)
		{
			throw new NotImplementedException();
		}

		public bool less(long a, long b)
		{
			return a < b;
		}

		public int2 max(int2 v, int2 w)
		{
			return math.max(v, w);
		}

		public int2 min(int2 v, int2 w)
		{
			return math.min(v, w);
		}

		public long mul(int a, int b)
		{
			return (long)a * (long)b;
		}

		public int2 neg(int2 v)
		{
			return -v;
		}

		public int2 normalizesafe(int2 v)
		{
			throw new NotImplementedException();
		}
	}
}
