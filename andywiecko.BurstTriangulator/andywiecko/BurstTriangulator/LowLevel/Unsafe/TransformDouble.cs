using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformDouble : ITransform<TransformDouble, double, double2>
	{
		private readonly double2x2 rotScale;

		private readonly double2 translation;

		public TransformDouble Identity => new TransformDouble(double2x2.identity, double2.zero);

		public double AreaScalingFactor => math.abs(math.determinant(rotScale));

		public TransformDouble(double2x2 rotScale, double2 translation)
		{
			this.rotScale = rotScale;
			this.translation = translation;
		}

		private static TransformDouble Translate(double2 offset)
		{
			return new TransformDouble(double2x2.identity, offset);
		}

		private static TransformDouble Scale(double2 scale)
		{
			return new TransformDouble(new double2x2(scale.x, 0.0, 0.0, scale.y), double2.zero);
		}

		private static TransformDouble Rotate(double2x2 rotation)
		{
			return new TransformDouble(rotation, double2.zero);
		}

		public static TransformDouble operator *(TransformDouble lhs, TransformDouble rhs)
		{
			return new TransformDouble(math.mul(lhs.rotScale, rhs.rotScale), math.mul(math.inverse(rhs.rotScale), lhs.translation) + rhs.translation);
		}

		public TransformDouble Inverse()
		{
			return new TransformDouble(math.inverse(rotScale), math.mul(rotScale, -translation));
		}

		public double2 Transform(double2 point)
		{
			return math.mul(rotScale, point + translation);
		}

		public TransformDouble CalculatePCATransformation(NativeArray<double2> positions)
		{
			double2 double5 = 0;
			foreach (double2 item in positions)
			{
				double5 += item;
			}
			double5 /= (double)positions.Length;
			double2x2 zero = double2x2.zero;
			for (int i = 0; i < positions.Length; i++)
			{
				double2 double6 = positions[i] - double5;
				zero += Kron(double6, double6);
			}
			zero /= (double)positions.Length;
			Eigen(zero, out var _, out var eigvec);
			TransformDouble transformDouble = Rotate(math.transpose(eigvec)) * Translate(-double5);
			double2 double7 = double.MaxValue;
			double2 double8 = double.MinValue;
			for (int j = 0; j < positions.Length; j++)
			{
				double2 x = transformDouble.Transform(positions[j]);
				double7 = math.min(x, double7);
				double8 = math.max(x, double8);
			}
			double2 double9 = 0.5 * (double7 + double8);
			return Scale(2.0 / (double8 - double7)) * Translate(-double9) * transformDouble;
		}

		public TransformDouble CalculateLocalTransformation(NativeArray<double2> positions)
		{
			double2 double5 = double.MaxValue;
			double2 double6 = double.MinValue;
			double2 double7 = 0;
			foreach (double2 item in positions)
			{
				double5 = math.min(item, double5);
				double6 = math.max(item, double6);
				double7 += item;
			}
			double7 /= (double)positions.Length;
			return Scale(1.0 / math.cmax(math.max(math.abs(double6 - double7), math.abs(double5 - double7)))) * Translate(-double7);
		}

		private static void Eigen(double2x2 matrix, out double2 eigval, out double2x2 eigvec)
		{
			double num = matrix[0][0];
			double num2 = matrix[1][1];
			double num3 = matrix[0][1];
			double num4 = num - num2;
			double num5 = num + num2;
			double num6 = (double)((num4 >= 0.0) ? 1 : (-1)) * math.sqrt(num4 * num4 + 4.0 * num3 * num3);
			double x = num5 + num6;
			double y = num5 - num6;
			eigval = 0.5 * math.double2(x, y);
			double x2 = 0.5 * math.atan2(2.0 * num3, num4);
			eigvec = math.double2x2(math.cos(x2), 0.0 - math.sin(x2), math.sin(x2), math.cos(x2));
		}

		private static double2x2 Kron(double2 a, double2 b)
		{
			return math.double2x2(a * b[0], a * b[1]);
		}
	}
}
