using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Node : ILumpObject
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
				return BitConverter.ToInt32(Data, 0);
			}
			set
			{
				BitConverter.GetBytes(value).CopyTo(Data, 0);
			}
		}

		public ILumpObject Child1
		{
			get
			{
				if (Child1Index >= 0)
				{
					return Parent.Bsp.Nodes[Child1Index];
				}
				return Parent.Bsp.Leaves[-Child1Index];
			}
		}

		public int Child1Index
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt16(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				return 0;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[4] = bytes[0];
					Data[5] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 4);
				}
			}
		}

		public ILumpObject Child2
		{
			get
			{
				if (Child2Index >= 0)
				{
					return Parent.Bsp.Nodes[Child2Index];
				}
				return Parent.Bsp.Leaves[-Child2Index];
			}
		}

		public int Child2Index
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt16(Data, 6);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				return 0;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[6] = bytes[0];
					Data[7] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Quake3) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 8);
				}
			}
		}

		public Vector3 Minimums
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return new Vector3(BitConverter.ToInt16(Data, 8), BitConverter.ToInt16(Data, 10), BitConverter.ToInt16(Data, 12));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					return new Vector3(BitConverter.ToInt32(Data, 12), BitConverter.ToInt32(Data, 16), BitConverter.ToInt32(Data, 20));
				}
				if (MapType.IsSubtypeOf(MapType.Source) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					return new Vector3(BitConverter.ToInt16(Data, 12), BitConverter.ToInt16(Data, 14), BitConverter.ToInt16(Data, 16));
				}
				if (MapType == MapType.Nightfire)
				{
					return Vector3Extensions.ToVector3(Data, 12);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 8);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 10);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 12);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 12);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 16);
					BitConverter.GetBytes((int)value.Z()).CopyTo(Data, 20);
				}
				else if (MapType.IsSubtypeOf(MapType.Source) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 12);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 14);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 16);
				}
				else if (MapType == MapType.Nightfire)
				{
					value.GetBytes().CopyTo(Data, 12);
				}
			}
		}

		public Vector3 Maximums
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return new Vector3(BitConverter.ToInt16(Data, 14), BitConverter.ToInt16(Data, 16), BitConverter.ToInt16(Data, 18));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					return new Vector3(BitConverter.ToInt32(Data, 24), BitConverter.ToInt32(Data, 28), BitConverter.ToInt32(Data, 32));
				}
				if (MapType.IsSubtypeOf(MapType.Source) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					return new Vector3(BitConverter.ToInt16(Data, 18), BitConverter.ToInt16(Data, 20), BitConverter.ToInt16(Data, 22));
				}
				if (MapType == MapType.Nightfire)
				{
					return Vector3Extensions.ToVector3(Data, 24);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 14);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 16);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 18);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 24);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 28);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 32);
				}
				else if (MapType.IsSubtypeOf(MapType.Source) || MapType.IsSubtypeOf(MapType.Quake2))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 18);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 20);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 22);
				}
				else if (MapType == MapType.Nightfire)
				{
					value.GetBytes().CopyTo(Data, 24);
				}
			}
		}

		public IEnumerable<Face> Faces
		{
			get
			{
				int i = 0;
				while (i < NumFaceIndices)
				{
					yield return Parent.Bsp.Faces[FirstFaceIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("Faces")]
		public int FirstFaceIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToUInt16(Data, 20);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 24);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[20] = bytes[0];
					Data[21] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[24] = bytes[0];
					Data[25] = bytes[1];
				}
			}
		}

		[Count("Faces")]
		public int NumFaceIndices
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToUInt16(Data, 22);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 26);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[22] = bytes[0];
					Data[23] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 40);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[26] = bytes[0];
					Data[27] = bytes[1];
				}
			}
		}

		public int AreaIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					return BitConverter.ToUInt16(Data, 28);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					Data[28] = bytes[0];
					Data[29] = bytes[1];
				}
			}
		}

		public Node(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Node(Node source, ILump parent)
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
			Child1Index = source.Child1Index;
			Child2Index = source.Child2Index;
			Minimums = source.Minimums;
			Maximums = source.Maximums;
			FirstFaceIndex = source.FirstFaceIndex;
			NumFaceIndices = source.NumFaceIndices;
			AreaIndex = source.AreaIndex;
		}

		public static Lump<Node> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Node>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.Quake))
			{
				return 24;
			}
			if (mapType.IsSubtypeOf(MapType.Quake2))
			{
				return 28;
			}
			if (mapType == MapType.Vindictus)
			{
				return 48;
			}
			if (mapType.IsSubtypeOf(MapType.Source))
			{
				return 32;
			}
			if (mapType.IsSubtypeOf(MapType.Quake3) || mapType == MapType.Nightfire)
			{
				return 36;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 4;
			}
			if (type.IsSubtypeOf(MapType.Quake))
			{
				return 5;
			}
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 5;
			}
			if (type.IsSubtypeOf(MapType.FAKK2) || type.IsSubtypeOf(MapType.MOHAA))
			{
				return 9;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 11;
			}
			switch (type)
			{
			case MapType.Nightfire:
				return 8;
			case MapType.CoD:
			case MapType.CoDDemo:
				return 20;
			case MapType.CoD2:
				return 25;
			case MapType.CoD4:
				return 27;
			default:
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 3;
				}
				return -1;
			}
		}
	}
}
