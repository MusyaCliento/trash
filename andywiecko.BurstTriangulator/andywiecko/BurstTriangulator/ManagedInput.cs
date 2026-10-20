using System;
using Unity.Collections;

namespace andywiecko.BurstTriangulator
{
	[Obsolete("Use AsNativeArray(out Handle) instead! You can learn more in the project manual.")]
	public class ManagedInput<T2> where T2 : unmanaged
	{
		public T2[] Positions { get; set; }

		public int[] ConstraintEdges { get; set; }

		public T2[] HoleSeeds { get; set; }

		public static implicit operator InputData<T2>(ManagedInput<T2> input)
		{
			return new InputData<T2>
			{
				Positions = ((input.Positions == null) ? default(NativeArray<T2>) : input.Positions.AsNativeArray()),
				ConstraintEdges = ((input.ConstraintEdges == null) ? default(NativeArray<int>) : input.ConstraintEdges.AsNativeArray()),
				HoleSeeds = ((input.HoleSeeds == null) ? default(NativeArray<T2>) : input.HoleSeeds.AsNativeArray())
			};
		}
	}
}
