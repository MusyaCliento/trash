using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct BrushSide : ILumpObject
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

		public Plane Plane => Parent.Bsp.Planes[PlaneIndex];

		public int PlaneIndex
		{
			get
			{
				if (MapType == MapType.STEF2 || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.STEF2 || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[0] = bytes[0];
					Data[1] = bytes[1];
				}
			}
		}

		public float Distance
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToSingle(Data, 0);
				}
				return 0f;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 0);
				}
			}
		}

		public Texture Texture => Parent.Bsp.Textures[TextureIndex];

		public int TextureIndex
		{
			get
			{
				if (MapType == MapType.STEF2)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 2);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.STEF2)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[2] = bytes[0];
					Data[3] = bytes[1];
				}
			}
		}

		public Face Face => Parent.Bsp.Faces[FaceIndex];

		public int FaceIndex
		{
			get
			{
				return MapType switch
				{
					MapType.Nightfire => BitConverter.ToInt32(Data, 0), 
					MapType.Raven => BitConverter.ToInt32(Data, 8), 
					_ => -1, 
				};
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				switch (MapType)
				{
				case MapType.Nightfire:
					bytes.CopyTo(Data, 0);
					break;
				case MapType.Raven:
					bytes.CopyTo(Data, 8);
					break;
				}
			}
		}

		public Displacement Displacement => Parent.Bsp.Displacements[DisplacementIndex];

		public int DisplacementIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 4);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[4] = bytes[0];
					Data[5] = bytes[1];
				}
			}
		}

		public bool IsBevel
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return Data[12] > 0;
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Data[6] > 0;
				}
				return false;
			}
			set
			{
				if (MapType == MapType.Vindictus)
				{
					Data[12] = (byte)(value ? 1u : 0u);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[6] = (byte)(value ? 1u : 0u);
				}
			}
		}

		public bool IsThin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					return Data[7] > 0;
				}
				return false;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					Data[7] = (byte)(value ? 1u : 0u);
				}
			}
		}

		public BrushSide(byte[] data, ILump parent)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public BrushSide(BrushSide source, ILump parent)
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
			PlaneIndex = source.PlaneIndex;
			TextureIndex = source.TextureIndex;
			FaceIndex = source.FaceIndex;
			DisplacementIndex = source.DisplacementIndex;
			IsBevel = source.IsBevel;
			IsThin = source.IsThin;
		}

		public static Lump<BrushSide> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<BrushSide>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType type, int version = 0)
		{
			if (type == MapType.Vindictus)
			{
				return 16;
			}
			if (type.IsSubtypeOf(MapType.MOHAA) || type == MapType.Raven)
			{
				return 12;
			}
			if (type.IsSubtypeOf(MapType.Quake3) || type.IsSubtypeOf(MapType.Source) || type == MapType.SiN || type == MapType.Nightfire)
			{
				return 8;
			}
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 4;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + type.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 19;
			}
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 15;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 12;
			}
			if (type.IsSubtypeOf(MapType.MOHAA))
			{
				return 11;
			}
			switch (type)
			{
			case MapType.Nightfire:
				return 16;
			case MapType.CoD:
			case MapType.CoDDemo:
				return 3;
			case MapType.CoD2:
			case MapType.CoD4:
				return 5;
			default:
				if (type.IsSubtypeOf(MapType.FAKK2))
				{
					return 10;
				}
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 9;
				}
				return -1;
			}
		}
	}
}
