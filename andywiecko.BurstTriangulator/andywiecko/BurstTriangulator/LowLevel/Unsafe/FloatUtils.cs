using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct FloatUtils : IUtils<float, float2, float>
	{
		public float Cast(float v)
		{
			return v;
		}

		public float2 CircumCenter(float2 a, float2 b, float2 c)
		{
			float2 x = b - a;
			float2 x2 = c - a;
			float num = math.lengthsq(x);
			float num2 = math.lengthsq(x2);
			float num3 = 0.5f / (x.x * x2.y - x.y * x2.x);
			return a + num3 * (num * math.float2(x2.y, 0f - x2.x) + num2 * math.float2(0f - x.y, x.x));
		}

		public float Const(float v)
		{
			return v;
		}

		public float EPSILON()
		{
			return 1.1920929E-07f;
		}

		public bool InCircle(float2 a, float2 b, float2 c, float2 p)
		{
			float num = a.x - p.x;
			float num2 = a.y - p.y;
			float num3 = b.x - p.x;
			float num4 = b.y - p.y;
			float num5 = c.x - p.x;
			float num6 = c.y - p.y;
			float num7 = num * num + num2 * num2;
			float num8 = num3 * num3 + num4 * num4;
			float num9 = num5 * num5 + num6 * num6;
			return num * (num4 * num9 - num8 * num6) - num2 * (num3 * num9 - num8 * num5) + num7 * (num3 * num6 - num4 * num5) < 0f;
		}

		public float MaxValue()
		{
			return float.MaxValue;
		}

		public float2 MaxValue2()
		{
			return float.MaxValue;
		}

		public float2 MinValue2()
		{
			return float.MinValue;
		}

		public bool PointInsideTriangle(float2 p, float2 a, float2 b, float2 c)
		{
			return math.cmax(-bar(a, b, c, p)) <= 0f;
			static float3 bar(float2 float7, float2 float6, float2 float9, float2 float10)
			{
				float2 float5 = float6 - float7;
				float2 float8 = float9 - float7;
				float2 obj = float10 - float7;
				float2 a2 = float5;
				float2 b2 = float8;
				float2 float11 = obj;
				float num = 1f / cross(a2, b2);
				float num2 = num * cross(float11, b2);
				float num3 = num * cross(a2, float11);
				return new float3(1f - num2 - num3, num2, num3);
			}
			static float cross(float2 float5, float2 float6)
			{
				return float5.x * float6.y - float5.y * float6.x;
			}
		}

		public bool SupportsRefinement()
		{
			return true;
		}

		public float X(float2 a)
		{
			return a.x;
		}

		public float Y(float2 a)
		{
			return a.y;
		}

		public float Zero()
		{
			return 0f;
		}

		public float ZeroTBig()
		{
			return 0f;
		}

		public float abs(float v)
		{
			return math.abs(v);
		}

		public float alpha(float concentricShellReferenceRadius, float edgeLengthSq)
		{
			float num = math.sqrt(edgeLengthSq);
			int num2 = (int)math.round(math.log2(0.5f * num / concentricShellReferenceRadius));
			return concentricShellReferenceRadius / num * ((num2 < 0) ? math.pow(2f, num2) : ((float)(1 << num2)));
		}

		public bool anygreaterthan(float a, float b, float c, float v)
		{
			return math.any(math.float3(a, b, c) > v);
		}

		public float2 avg(float2 a, float2 b)
		{
			return 0.5f * (a + b);
		}

		public float cos(float v)
		{
			return math.cos(v);
		}

		public float diff(float a, float b)
		{
			return a - b;
		}

		public float2 diff(float2 a, float2 b)
		{
			return a - b;
		}

		public float distancesq(float2 a, float2 b)
		{
			return math.distancesq(a, b);
		}

		public float dot(float2 a, float2 b)
		{
			return math.dot(a, b);
		}

		public bool2 eq(float2 v, float2 w)
		{
			return v == w;
		}

		public bool2 ge(float2 a, float2 b)
		{
			return a >= b;
		}

		public bool greater(float a, float b)
		{
			return a > b;
		}

		public int hashkey(float2 p, float2 c, int hashSize)
		{
			return (int)math.floor(pseudoAngle(p.x - c.x, p.y - c.y) * (float)hashSize) % hashSize;
			static float pseudoAngle(float dx, float dy)
			{
				float num = dx / (math.abs(dx) + math.abs(dy));
				return ((dy > 0f) ? (3f - num) : (1f + num)) / 4f;
			}
		}

		public bool2 isfinite(float2 v)
		{
			return math.isfinite(v);
		}

		public bool le(float a, float b)
		{
			return a <= b;
		}

		public bool2 le(float2 a, float2 b)
		{
			return a <= b;
		}

		public float2 lerp(float2 a, float2 b, float v)
		{
			return math.lerp(a, b, v);
		}

		public bool less(float a, float b)
		{
			return a < b;
		}

		public float2 max(float2 v, float2 w)
		{
			return math.max(v, w);
		}

		public float2 min(float2 v, float2 w)
		{
			return math.min(v, w);
		}

		public float mul(float a, float b)
		{
			return a * b;
		}

		public float2 neg(float2 v)
		{
			return -v;
		}

		public float2 normalizesafe(float2 v)
		{
			return math.normalizesafe(v);
		}
	}
}
