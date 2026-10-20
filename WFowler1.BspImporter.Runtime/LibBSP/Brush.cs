using System;
using System.Collections.Generic;
using System.Reflection;

namespace LibBSP
{
	public struct Brush : ILumpObject
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

		public IEnumerable<BrushSide> Sides
		{
			get
			{
				int i = 0;
				while (i < NumSides)
				{
					yield return Parent.Bsp.BrushSides[FirstSideIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("BrushSides")]
		public int FirstSideIndex
		{
			get
			{
				if (MapType == MapType.Nightfire || MapType == MapType.STEF2)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD)) || (MapType & MapType.Source) == MapType.Source)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire || MapType == MapType.STEF2)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD)) || (MapType & MapType.Source) == MapType.Source)
				{
					bytes.CopyTo(Data, 0);
				}
			}
		}

		[Count("BrushSides")]
		public int NumSides
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt16(Data, 0);
				}
				if (MapType == MapType.STEF2)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || (MapType & MapType.Source) == MapType.Source)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					Data[0] = bytes[0];
					Data[1] = bytes[1];
				}
				else if (MapType == MapType.STEF2)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || (MapType & MapType.Source) == MapType.Source)
				{
					bytes.CopyTo(Data, 4);
				}
			}
		}

		public Texture Texture => Parent.Bsp.Textures[TextureIndex];

		public int TextureIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt16(Data, 2);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 8);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 2);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 8);
				}
			}
		}

		public int Contents
		{
			get
			{
				if (MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 8);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 8);
				}
			}
		}

		public Brush(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Brush(Brush source, ILump parent)
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
			FirstSideIndex = source.FirstSideIndex;
			NumSides = source.NumSides;
			TextureIndex = source.TextureIndex;
			Contents = source.Contents;
		}

		public static Lump<Brush> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Brush>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.CoD))
			{
				return 4;
			}
			if (mapType.IsSubtypeOf(MapType.Quake2) || mapType.IsSubtypeOf(MapType.Quake3) || mapType == MapType.Nightfire || mapType.IsSubtypeOf(MapType.Source))
			{
				return 12;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 18;
			}
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 14;
			}
			if (type.IsSubtypeOf(MapType.MOHAA))
			{
				return 12;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 13;
			}
			if (type.IsSubtypeOf(MapType.FAKK2))
			{
				return 11;
			}
			switch (type)
			{
			case MapType.Nightfire:
				return 15;
			case MapType.CoD:
			case MapType.CoDDemo:
				return 4;
			case MapType.CoD2:
				return 6;
			default:
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 8;
				}
				return -1;
			}
		}
	}
}
