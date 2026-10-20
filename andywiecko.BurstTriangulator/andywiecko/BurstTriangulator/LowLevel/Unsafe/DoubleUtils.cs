using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct DoubleUtils : IUtils<double, double2, double>
	{
		public double Cast(double v)
		{
			return v;
		}

		public double2 CircumCenter(double2 a, double2 b, double2 c)
		{
			double2 x = b - a;
			double2 x2 = c - a;
			double num = math.lengthsq(x);
			double num2 = math.lengthsq(x2);
			double num3 = 0.5 / (x.x * x2.y - x.y * x2.x);
			return a + num3 * (num * math.double2(x2.y, 0.0 - x2.x) + num2 * math.double2(0.0 - x.y, x.x));
		}

		public double Const(float v)
		{
			return v;
		}

		public double EPSILON()
		{
			return 2.220446049250313E-16;
		}

		public bool InCircle(double2 a, double2 b, double2 c, double2 p)
		{
			double num = a.x - p.x;
			double num2 = a.y - p.y;
			double num3 = b.x - p.x;
			double num4 = b.y - p.y;
			double num5 = c.x - p.x;
			double num6 = c.y - p.y;
			double num7 = num * num + num2 * num2;
			double num8 = num3 * num3 + num4 * num4;
			double num9 = num5 * num5 + num6 * num6;
			return num * (num4 * num9 - num8 * num6) - num2 * (num3 * num9 - num8 * num5) + num7 * (num3 * num6 - num4 * num5) < 0.0;
		}

		public double MaxValue()
		{
			return double.MaxValue;
		}

		public double2 MaxValue2()
		{
			return double.MaxValue;
		}

		public double2 MinValue2()
		{
			return double.MinValue;
		}

		public bool PointInsideTriangle(double2 p, double2 a, double2 b, double2 c)
		{
			return math.cmax(-bar(a, b, c, p)) <= 0.0;
			static double3 bar(double2 double7, double2 double6, double2 double9, double2 double10)
			{
				double2 double5 = double6 - double7;
				double2 double8 = double9 - double7;
				double2 obj = double10 - double7;
				double2 a2 = double5;
				double2 b2 = double8;
				double2 double11 = obj;
				double num = 1.0 / cross(a2, b2);
				double num2 = num * cross(double11, b2);
				double num3 = num * cross(a2, double11);
				return new double3(1.0 - num2 - num3, num2, num3);
			}
			static double cross(double2 double5, double2 double6)
			{
				return double5.x * double6.y - double5.y * double6.x;
			}
		}

		public bool SupportsRefinement()
		{
			return true;
		}

		public double X(double2 a)
		{
			return a.x;
		}

		public double Y(double2 a)
		{
			return a.y;
		}

		public double Zero()
		{
			return 0.0;
		}

		public double ZeroTBig()
		{
			return 0.0;
		}

		public double abs(double v)
		{
			return math.abs(v);
		}

		public double alpha(double concentricShellReferenceRadius, double edgeLengthSq)
		{
			double num = math.sqrt(edgeLengthSq);
			int num2 = (int)math.round(math.log2(0.5 * num / concentricShellReferenceRadius));
			return concentricShellReferenceRadius / num * (double)((num2 < 0) ? math.pow(2f, num2) : ((float)(1 << num2)));
		}

		public bool anygreaterthan(double a, double b, double c, double v)
		{
			return math.any(math.double3(a, b, c) > v);
		}

		public double2 avg(double2 a, double2 b)
		{
			return 0.5 * (a + b);
		}

		public double cos(double v)
		{
			return math.cos(v);
		}

		public double diff(double a, double b)
		{
			return a - b;
		}

		public double2 diff(double2 a, double2 b)
		{
			return a - b;
		}

		public double distancesq(double2 a, double2 b)
		{
			return math.distancesq(a, b);
		}

		public double dot(double2 a, double2 b)
		{
			return math.dot(a, b);
		}

		public bool2 eq(double2 v, double2 w)
		{
			return v == w;
		}

		public bool2 ge(double2 a, double2 b)
		{
			return a >= b;
		}

		public bool greater(double a, double b)
		{
			return a > b;
		}

		public int hashkey(double2 p, double2 c, int hashSize)
		{
			return (int)math.floor(pseudoAngle(p.x - c.x, p.y - c.y) * (double)hashSize) % hashSize;
			static double pseudoAngle(double dx, double dy)
			{
				double num = dx / (math.abs(dx) + math.abs(dy));
				return ((dy > 0.0) ? (3.0 - num) : (1.0 + num)) / 4.0;
			}
		}

		public bool2 isfinite(double2 v)
		{
			return math.isfinite(v);
		}

		public bool le(double a, double b)
		{
			return a <= b;
		}

		public bool2 le(double2 a, double2 b)
		{
			return a <= b;
		}

		public double2 lerp(double2 a, double2 b, double v)
		{
			return math.lerp(a, b, v);
		}

		public bool less(double a, double b)
		{
			return a < b;
		}

		public double2 max(double2 v, double2 w)
		{
			return math.max(v, w);
		}

		public double2 min(double2 v, double2 w)
		{
			return math.min(v, w);
		}

		public double mul(double a, double b)
		{
			return a * b;
		}

		public double2 neg(double2 v)
		{
			return -v;
		}

		public double2 normalizesafe(double2 v)
		{
			return math.normalizesafe(v);
		}
	}
}
