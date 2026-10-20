using System;
using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal readonly struct TransformInt : ITransform<TransformInt, int, int2>
	{
		private readonly int2 translation;

		public TransformInt Identity => new TransformInt(int2.zero);

		public int AreaScalingFactor => 1;

		public TransformInt(int2 translation)
		{
			this.translation = translation;
		}

		public TransformInt Inverse()
		{
			return new TransformInt(-translation);
		}

		public int2 Transform(int2 point)
		{
			return point + translation;
		}

		public TransformInt CalculatePCATransformation(NativeArray<int2> positions)
		{
			throw new NotImplementedException("PCA is not implemented for int2 coordinates!");
		}

		public TransformInt CalculateLocalTransformation(NativeArray<int2> positions)
		{
			int2 y = int.MaxValue;
			int2 y2 = int.MinValue;
			int2 int5 = 0;
			foreach (int2 item in positions)
			{
				y = math.min(item, y);
				y2 = math.max(item, y2);
				int5 += item;
			}
			return new TransformInt(-int5 / positions.Length);
		}
	}
}
