using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformFloat : ITransform<TransformFloat, float, float2>
	{
		private readonly float2x2 rotScale;

		private readonly float2 translation;

		public TransformFloat Identity => new TransformFloat(float2x2.identity, float2.zero);

		public float AreaScalingFactor => math.abs(math.determinant(rotScale));

		public TransformFloat(float2x2 rotScale, float2 translation)
		{
			this.rotScale = rotScale;
			this.translation = translation;
		}

		private static TransformFloat Translate(float2 offset)
		{
			return new TransformFloat(float2x2.identity, offset);
		}

		private static TransformFloat Scale(float2 scale)
		{
			return new TransformFloat(new float2x2(scale.x, 0f, 0f, scale.y), float2.zero);
		}

		private static TransformFloat Rotate(float2x2 rotation)
		{
			return new TransformFloat(rotation, float2.zero);
		}

		public static TransformFloat operator *(TransformFloat lhs, TransformFloat rhs)
		{
			return new TransformFloat(math.mul(lhs.rotScale, rhs.rotScale), math.mul(math.inverse(rhs.rotScale), lhs.translation) + rhs.translation);
		}

		public TransformFloat Inverse()
		{
			return new TransformFloat(math.inverse(rotScale), math.mul(rotScale, -translation));
		}

		public float2 Transform(float2 point)
		{
			return math.mul(rotScale, point + translation);
		}

		public TransformFloat CalculatePCATransformation(NativeArray<float2> positions)
		{
			float2 float5 = 0;
			foreach (float2 item in positions)
			{
				float5 += item;
			}
			float5 /= (float)positions.Length;
			float2x2 zero = float2x2.zero;
			for (int i = 0; i < positions.Length; i++)
			{
				float2 float6 = positions[i] - float5;
				zero += Kron(float6, float6);
			}
			zero /= (float)positions.Length;
			Eigen(zero, out var _, out var eigvec);
			TransformFloat transformFloat = Rotate(math.transpose(eigvec)) * Translate(-float5);
			float2 float7 = float.MaxValue;
			float2 float8 = float.MinValue;
			for (int j = 0; j < positions.Length; j++)
			{
				float2 x = transformFloat.Transform(positions[j]);
				float7 = math.min(x, float7);
				float8 = math.max(x, float8);
			}
			float2 float9 = 0.5f * (float7 + float8);
			return Scale(2f / (float8 - float7)) * Translate(-float9) * transformFloat;
		}

		public TransformFloat CalculateLocalTransformation(NativeArray<float2> positions)
		{
			float2 float5 = float.MaxValue;
			float2 float6 = float.MinValue;
			float2 float7 = 0;
			foreach (float2 item in positions)
			{
				float5 = math.min(item, float5);
				float6 = math.max(item, float6);
				float7 += item;
			}
			float7 /= (float)positions.Length;
			return Scale(1f / math.cmax(math.max(math.abs(float6 - float7), math.abs(float5 - float7)))) * Translate(-float7);
		}

		private static void Eigen(float2x2 matrix, out float2 eigval, out float2x2 eigvec)
		{
			float num = matrix[0][0];
			float num2 = matrix[1][1];
			float num3 = matrix[0][1];
			float num4 = num - num2;
			float num5 = num + num2;
			float num6 = (float)((num4 >= 0f) ? 1 : (-1)) * math.sqrt(num4 * num4 + 4f * num3 * num3);
			float x = num5 + num6;
			float y = num5 - num6;
			eigval = 0.5f * math.float2(x, y);
			float x2 = 0.5f * math.atan2(2f * num3, num4);
			eigvec = math.float2x2(math.cos(x2), 0f - math.sin(x2), math.sin(x2), math.cos(x2));
		}

		private static float2x2 Kron(float2 a, float2 b)
		{
			return math.float2x2(a * b[0], a * b[1]);
		}
	}
}
