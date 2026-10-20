using System;
using System.Collections.Generic;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class MAPTerrainMoHAA
	{
		[Serializable]
		public class Partition
		{
			public int unknown1;

			public int unknown2;

			public string shader;

			public int[] textureShift;

			public float rotation;

			public int unknown3;

			public float[] textureScale;

			public int unknown4;

			public int flags;

			public int unknown5;

			public string properties;

			public Partition()
			{
				unknown1 = 0;
				unknown2 = 0;
				shader = "";
				textureShift = new int[2];
				rotation = 0f;
				unknown3 = 0;
				textureScale = new float[2] { 1f, 1f };
				unknown4 = 0;
				flags = 0;
				unknown5 = 0;
				properties = "";
			}
		}

		[Serializable]
		public class Vertex
		{
			public int height;

			public string unknown1;

			public string unknown2;

			public Vertex()
			{
				height = 0;
				unknown1 = "";
				unknown2 = "";
			}
		}

		public Vector2 size;

		public int flags;

		public Vector3 origin;

		public List<Partition> partitions;

		public List<Vertex> vertices;

		public MAPTerrainMoHAA()
		{
			partitions = new List<Partition>(4);
			vertices = new List<Vertex>(81);
		}

		public MAPTerrainMoHAA(string[] lines)
		{
		}
	}
}
