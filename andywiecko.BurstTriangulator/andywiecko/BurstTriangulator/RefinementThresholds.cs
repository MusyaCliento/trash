using System;
using Unity.Mathematics;
using UnityEngine;

namespace andywiecko.BurstTriangulator
{
	[Serializable]
	public class RefinementThresholds
	{
		[field: SerializeField]
		public float Area { get; set; } = 1f;

		[field: SerializeField]
		public float Angle { get; set; } = math.radians(5f);
	}
}
