using System;
using System.Reflection;

namespace LibBSP
{
	public struct LODTerrain : ILumpObject
	{
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

		public byte Flags
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Data[0];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					Data[0] = value;
				}
			}
		}

		public byte Scale
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Data[1];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					Data[1] = value;
				}
			}
		}

		public byte[] LightmapCoordinates
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return new byte[2]
					{
						Data[2],
						Data[3]
					};
				}
				return null;
			}
			set
			{
				if (value.Length != 2)
				{
					throw new ArgumentException("LightmapCoordinates array must have 2 elements.");
				}
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					Data[2] = value[0];
					Data[3] = value[1];
				}
			}
		}

		public float[] UVs
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return new float[8]
					{
						BitConverter.ToSingle(Data, 4),
						BitConverter.ToSingle(Data, 8),
						BitConverter.ToSingle(Data, 12),
						BitConverter.ToSingle(Data, 16),
						BitConverter.ToSingle(Data, 20),
						BitConverter.ToSingle(Data, 24),
						BitConverter.ToSingle(Data, 28),
						BitConverter.ToSingle(Data, 32)
					};
				}
				return null;
			}
			set
			{
				if (value.Length != 8)
				{
					throw new ArgumentException("UVs array must have 8 elements.");
				}
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					int num = 4;
					for (int i = 0; i < value.Length; i++)
					{
						BitConverter.GetBytes(value[i]).CopyTo(Data, num + i * 4);
					}
				}
			}
		}

		public sbyte X
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return (sbyte)Data[36];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					Data[36] = (byte)value;
				}
			}
		}

		public sbyte Y
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return (sbyte)Data[37];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					Data[37] = (byte)value;
				}
			}
		}

		public short BaseZ
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToInt16(Data, 38);
				}
				return 0;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 38);
				}
			}
		}

		public Texture Texture => Parent.Bsp.Textures[TextureIndex];

		public short TextureIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToInt16(Data, 40);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 40);
				}
			}
		}

		public short Lightmap
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToInt16(Data, 42);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 42);
				}
			}
		}

		public ushort[,] VertexFlags
		{
			get
			{
				ushort[,] array = new ushort[2, 63];
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					for (int i = 0; i < array.GetLength(0); i++)
					{
						for (int j = 0; j < array.GetLength(1); j++)
						{
							array[i, j] = BitConverter.ToUInt16(Data, 52 + i * 126 + j * 2);
						}
					}
				}
				return array;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return;
				}
				if (value.GetLength(0) != 2 || value.GetLength(1) != 63)
				{
					throw new ArgumentException("VertexFlags array must be size (2, 63) elements.");
				}
				for (int i = 0; i < value.GetLength(0); i++)
				{
					for (int j = 0; j < value.GetLength(1); j++)
					{
						BitConverter.GetBytes(value[i, j]).CopyTo(Data, 52 + i * 126 + j * 2);
					}
				}
			}
		}

		public byte[,] Heightmap
		{
			get
			{
				byte[,] array = new byte[9, 9];
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					for (int i = 0; i < array.GetLength(0); i++)
					{
						for (int j = 0; j < array.GetLength(1); j++)
						{
							array[i, j] = Data[304 + i * 9 + j];
						}
					}
				}
				return array;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return;
				}
				if (value.GetLength(0) != 9 || value.GetLength(1) != 9)
				{
					throw new ArgumentException("Heightmap array must be size (9, 9) elements.");
				}
				for (int i = 0; i < value.GetLength(0); i++)
				{
					for (int j = 0; j < value.GetLength(1); j++)
					{
						Data[304 + i * 9 + j] = value[i, j];
					}
				}
			}
		}

		public LODTerrain(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public LODTerrain(LODTerrain source, ILump parent)
		{
			Parent = parent;
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
			Flags = source.Flags;
			Scale = source.Scale;
			LightmapCoordinates = source.LightmapCoordinates;
			UVs = source.UVs;
			X = source.X;
			Y = source.Y;
			BaseZ = source.BaseZ;
			TextureIndex = source.TextureIndex;
			Lightmap = source.Lightmap;
			VertexFlags = source.VertexFlags;
			Heightmap = source.Heightmap;
		}

		public static Lump<LODTerrain> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<LODTerrain>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.MOHAA))
			{
				return 388;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type == MapType.MOHAADemo)
			{
				return 23;
			}
			if (type.IsSubtypeOf(MapType.MOHAA))
			{
				return 22;
			}
			return -1;
		}
	}
}
