using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Displacement : ILumpObject
	{
		public struct DisplacementNeighbor
		{
			public struct DisplacementSubNeighbor
			{
				public ILumpObject parent;

				public int offset;

				public int NeighborIndex
				{
					get
					{
						if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							return BitConverter.ToInt16(parent.Data, offset);
						}
						return -1;
					}
					set
					{
						if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							byte[] bytes = BitConverter.GetBytes(value);
							parent.Data[offset] = bytes[0];
							parent.Data[offset + 1] = bytes[1];
						}
					}
				}

				public int Orientation
				{
					get
					{
						if (parent.MapType == MapType.Vindictus)
						{
							return BitConverter.ToInt16(parent.Data, offset + 2);
						}
						if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							return parent.Data[offset + 2];
						}
						return -1;
					}
					set
					{
						byte[] bytes = BitConverter.GetBytes(value);
						if (parent.MapType == MapType.Vindictus)
						{
							parent.Data[offset + 2] = bytes[0];
							parent.Data[offset + 3] = bytes[1];
						}
						else if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							parent.Data[offset + 2] = bytes[0];
						}
					}
				}

				public int Span
				{
					get
					{
						if (parent.MapType == MapType.Vindictus)
						{
							return BitConverter.ToInt16(parent.Data, offset + 4);
						}
						if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							return parent.Data[offset + 3];
						}
						return -1;
					}
					set
					{
						byte[] bytes = BitConverter.GetBytes(value);
						if (parent.MapType == MapType.Vindictus)
						{
							parent.Data[offset + 4] = bytes[0];
							parent.Data[offset + 5] = bytes[1];
						}
						else if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							parent.Data[offset + 3] = bytes[0];
						}
					}
				}

				public int NeighborSpan
				{
					get
					{
						if (parent.MapType == MapType.Vindictus)
						{
							return BitConverter.ToInt16(parent.Data, offset + 6);
						}
						if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							return parent.Data[offset + 4];
						}
						return -1;
					}
					set
					{
						byte[] bytes = BitConverter.GetBytes(value);
						if (parent.MapType == MapType.Vindictus)
						{
							parent.Data[offset + 6] = bytes[0];
							parent.Data[offset + 7] = bytes[1];
						}
						else if (parent.MapType.IsSubtypeOf(MapType.Source))
						{
							parent.Data[offset + 4] = bytes[0];
						}
					}
				}

				public DisplacementSubNeighbor(ILumpObject parent, int offset)
				{
					this.parent = parent;
					this.offset = offset;
				}

				public DisplacementSubNeighbor(DisplacementSubNeighbor source, ILumpObject parent, int offset)
				{
					this.parent = parent;
					this.offset = offset;
					NeighborIndex = source.NeighborIndex;
					Orientation = source.Orientation;
					Span = source.Span;
					NeighborSpan = source.NeighborSpan;
				}

				public static int GetStructLength(MapType mapType, int lumpVersion = 0)
				{
					if (mapType == MapType.Vindictus)
					{
						return 8;
					}
					if (mapType.IsSubtypeOf(MapType.Source))
					{
						return 6;
					}
					throw new ArgumentException("Object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
				}
			}

			public ILumpObject parent;

			private int offset;

			public DisplacementSubNeighbor[] Subneighbors { get; private set; }

			public DisplacementNeighbor(ILumpObject parent, int offset)
			{
				this.parent = parent;
				this.offset = offset;
				Subneighbors = new DisplacementSubNeighbor[2]
				{
					new DisplacementSubNeighbor(parent, offset),
					new DisplacementSubNeighbor(parent, offset + GetStructLength(parent.MapType, parent.LumpVersion))
				};
			}

			public DisplacementNeighbor(DisplacementNeighbor source, ILumpObject parent, int offset)
			{
				this.parent = parent;
				this.offset = offset;
				Subneighbors = new DisplacementSubNeighbor[2]
				{
					new DisplacementSubNeighbor(source.Subneighbors[0], parent, this.offset),
					new DisplacementSubNeighbor(source.Subneighbors[1], parent, this.offset + GetStructLength(parent.MapType, parent.LumpVersion))
				};
			}

			public static int GetStructLength(MapType mapType, int lumpVersion = 0)
			{
				return 2 * DisplacementSubNeighbor.GetStructLength(mapType, lumpVersion);
			}
		}

		public struct DisplacementCornerNeighbor
		{
			public ILumpObject parent;

			public int offset;

			public int[] NeighborIndices
			{
				get
				{
					int[] array = new int[10];
					if (parent.MapType == MapType.Vindictus)
					{
						for (int i = 0; i < 4; i++)
						{
							array[i] = BitConverter.ToInt32(parent.Data, offset + i * 4);
						}
					}
					else if (parent.MapType.IsSubtypeOf(MapType.Source))
					{
						for (int j = 0; j < 4; j++)
						{
							array[j] = BitConverter.ToInt16(parent.Data, offset + j * 2);
						}
					}
					return array;
				}
				set
				{
					if (value.Length != 4)
					{
						throw new ArgumentException("NeighborIndices array must have 4 elements.");
					}
					if (parent.MapType == MapType.Vindictus)
					{
						for (int i = 0; i < value.Length; i++)
						{
							BitConverter.GetBytes(value[i]).CopyTo(parent.Data, offset + i * 4);
						}
					}
					else if (parent.MapType.IsSubtypeOf(MapType.Source))
					{
						for (int j = 0; j < value.Length; j++)
						{
							byte[] bytes = BitConverter.GetBytes(value[j]);
							parent.Data[offset + j * 2] = bytes[0];
							parent.Data[offset + j * 2 + 1] = bytes[1];
						}
					}
				}
			}

			public int NumNeighbors
			{
				get
				{
					if (parent.MapType == MapType.Vindictus)
					{
						return BitConverter.ToInt32(parent.Data, offset + 16);
					}
					if (parent.MapType.IsSubtypeOf(MapType.Source))
					{
						return parent.Data[offset + 8];
					}
					return -1;
				}
				set
				{
					byte[] bytes = BitConverter.GetBytes(value);
					if (parent.MapType == MapType.Vindictus)
					{
						BitConverter.GetBytes(value).CopyTo(parent.Data, offset + 16);
					}
					else if (parent.MapType.IsSubtypeOf(MapType.Source))
					{
						parent.Data[offset + 8] = bytes[0];
					}
				}
			}

			public DisplacementCornerNeighbor(ILumpObject parent, int offset)
			{
				this.parent = parent;
				this.offset = offset;
			}

			public DisplacementCornerNeighbor(DisplacementCornerNeighbor source, ILumpObject parent, int offset)
			{
				this.parent = parent;
				this.offset = offset;
				NeighborIndices = source.NeighborIndices;
				NumNeighbors = source.NumNeighbors;
			}

			public static int GetStructLength(MapType mapType, int lumpVersion = 0)
			{
				if (mapType == MapType.Vindictus)
				{
					return 20;
				}
				if (mapType.IsSubtypeOf(MapType.Source))
				{
					return 10;
				}
				throw new ArgumentException("Object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
			}
		}

		public ILump Parent { get; private set; }

		public byte[] Data { get; private set; }

		public MapType MapType
		{
			get
			{
				if (Parent == null || Parent.Bsp == null)
				{
					return MapType.Undefined;
				}
				return Parent.Bsp.MapType;
			}
		}

		public int LumpVersion
		{
			get
			{
				if (Parent == null)
				{
					return 0;
				}
				return Parent.LumpInfo.version;
			}
		}

		public Vector3 StartPosition
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Vector3Extensions.ToVector3(Data);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 0);
				}
			}
		}

		public IEnumerable<DisplacementVertex> Vertices
		{
			get
			{
				int numVertices = NumVertices;
				int i = 0;
				while (i < numVertices)
				{
					yield return Parent.Bsp.DisplacementVertices[FirstVertexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("DisplacementVertices")]
		public int FirstVertexIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 12);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 12);
				}
			}
		}

		public IEnumerable<ushort> Triangles
		{
			get
			{
				int i = 0;
				while (i < NumTriangles)
				{
					yield return (ushort)Parent.Bsp.DisplacementTriangles[FirstTriangleIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("DisplacementTriangles")]
		public int FirstTriangleIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 16);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 16);
				}
			}
		}

		public int Power
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 20);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 20);
				}
			}
		}

		[Count("DisplacementVertices")]
		public int NumVertices
		{
			get
			{
				int num = (int)Math.Pow(2.0, Power) + 1;
				return num * num;
			}
		}

		[Count("DisplacementTriangles")]
		public int NumTriangles
		{
			get
			{
				int num = Power * Power;
				return 2 * num * num;
			}
		}

		public int MinimumTesselation
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 24);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 24);
				}
			}
		}

		public float SmoothingAngle
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToSingle(Data, 28);
				}
				return 0f;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 28);
				}
			}
		}

		public int Contents
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 32);
				}
			}
		}

		public Face Face => Parent.Bsp.Faces[FaceIndex];

		public int FaceIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[36] = bytes[0];
					Data[37] = bytes[1];
				}
			}
		}

		public int LightmapAlphaStart
		{
			get
			{
				return BitConverter.ToInt32(Data, 40);
			}
			set
			{
				BitConverter.GetBytes(value).CopyTo(Data, 40);
			}
		}

		public int LightmapSamplePositionStart
		{
			get
			{
				return BitConverter.ToInt32(Data, 44);
			}
			set
			{
				BitConverter.GetBytes(value).CopyTo(Data, 44);
			}
		}

		public DisplacementNeighbor[] Neighbors { get; private set; }

		public DisplacementCornerNeighbor[] CornerNeighbors { get; private set; }

		public uint[] AllowedVertices
		{
			get
			{
				uint[] array = new uint[10];
				int num = -1;
				if (MapType == MapType.Vindictus)
				{
					num = 192;
				}
				else if (MapType == MapType.Source22)
				{
					num = 140;
				}
				else if (MapType == MapType.Source23)
				{
					num = 144;
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					num = 136;
				}
				if (num >= 0)
				{
					for (int i = 0; i < 10; i++)
					{
						array[i] = BitConverter.ToUInt32(Data, num + i * 4);
					}
				}
				return array;
			}
			set
			{
				if (value.Length != 10)
				{
					throw new ArgumentException("AllowedVerts array must have 10 elements.");
				}
				int num = -1;
				if (MapType == MapType.Vindictus)
				{
					num = 192;
				}
				else if (MapType == MapType.Source22)
				{
					num = 140;
				}
				else if (MapType == MapType.Source23)
				{
					num = 144;
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					num = 136;
				}
				if (num >= 0)
				{
					for (int i = 0; i < value.Length; i++)
					{
						BitConverter.GetBytes(value[i]).CopyTo(Data, num + i * 4);
					}
				}
			}
		}

		public Displacement(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
			Neighbors = new DisplacementNeighbor[4];
			CornerNeighbors = new DisplacementCornerNeighbor[4];
			int structLength = DisplacementNeighbor.GetStructLength(MapType, LumpVersion);
			for (int i = 0; i < Neighbors.Length; i++)
			{
				Neighbors[i] = new DisplacementNeighbor(this, 48 + structLength * i);
			}
			int structLength2 = DisplacementCornerNeighbor.GetStructLength(MapType, LumpVersion);
			for (int j = 0; j < CornerNeighbors.Length; j++)
			{
				CornerNeighbors[j] = new DisplacementCornerNeighbor(this, 48 + structLength * Neighbors.Length + structLength2 * j);
			}
		}

		public Displacement(Displacement source, ILump parent)
		{
			Parent = parent;
			Neighbors = new DisplacementNeighbor[4];
			CornerNeighbors = new DisplacementCornerNeighbor[4];
			if (parent != null && parent.Bsp != null)
			{
				if (source.Parent != null && source.Parent.Bsp != null && source.Parent.Bsp.MapType == parent.Bsp.MapType && source.LumpVersion == parent.LumpInfo.version)
				{
					Data = new byte[source.Data.Length];
					Array.Copy(source.Data, Data, source.Data.Length);
					return;
				}
				Data = new byte[GetStructLength(parent.Bsp.MapType, parent.LumpInfo.version)];
			}
			else if (source.Parent != null && source.Parent.Bsp != null)
			{
				Data = new byte[GetStructLength(source.Parent.Bsp.MapType, source.Parent.LumpInfo.version)];
			}
			else
			{
				Data = new byte[GetStructLength(MapType.Undefined)];
			}
			StartPosition = source.StartPosition;
			FirstVertexIndex = source.FirstVertexIndex;
			FirstTriangleIndex = source.FirstTriangleIndex;
			Power = source.Power;
			MinimumTesselation = source.MinimumTesselation;
			SmoothingAngle = source.SmoothingAngle;
			Contents = source.Contents;
			FaceIndex = source.FaceIndex;
			LightmapAlphaStart = source.LightmapAlphaStart;
			LightmapSamplePositionStart = source.LightmapSamplePositionStart;
			int structLength = DisplacementNeighbor.GetStructLength(MapType, LumpVersion);
			for (int i = 0; i < Neighbors.Length; i++)
			{
				Neighbors[i] = new DisplacementNeighbor(source.Neighbors[i], this, 48 + structLength * i);
			}
			int structLength2 = DisplacementCornerNeighbor.GetStructLength(MapType, LumpVersion);
			for (int j = 0; j < CornerNeighbors.Length; j++)
			{
				CornerNeighbors[j] = new DisplacementCornerNeighbor(source.CornerNeighbors[j], this, 48 + structLength * Neighbors.Length + structLength2 * j);
			}
			AllowedVertices = source.AllowedVertices;
		}

		public static Lump<Displacement> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Displacement>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			switch (mapType)
			{
			case MapType.Source23:
				return 184;
			case MapType.Vindictus:
				return 232;
			default:
				if (mapType.IsSubtypeOf(MapType.Source))
				{
					return 176;
				}
				throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
			}
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 26;
			}
			return -1;
		}
	}
}
