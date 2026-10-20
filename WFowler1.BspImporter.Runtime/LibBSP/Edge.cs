using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Edge : ILumpObject
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

		public UIVertex FirstVertex => Parent.Bsp.Vertices[FirstVertexIndex];

		public int FirstVertexIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 0);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[0] = bytes[0];
					Data[1] = bytes[1];
				}
			}
		}

		public UIVertex SecondVertex => Parent.Bsp.Vertices[SecondVertexIndex];

		public int SecondVertexIndex
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 2);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes(value).CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[2] = bytes[0];
					Data[3] = bytes[1];
				}
			}
		}

		public Edge(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Edge(Edge source, ILump parent)
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
			FirstVertexIndex = source.FirstVertexIndex;
			SecondVertexIndex = source.SecondVertexIndex;
		}

		public static Lump<Edge> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Edge>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType == MapType.Vindictus)
			{
				return 8;
			}
			if (mapType.IsSubtypeOf(MapType.Quake) || mapType.IsSubtypeOf(MapType.Quake2) || mapType.IsSubtypeOf(MapType.Source))
			{
				return 4;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 11;
			}
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source))
			{
				return 12;
			}
			return -1;
		}
	}
}
