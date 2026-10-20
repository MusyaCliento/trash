using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct DisplacementVertex : ILumpObject
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

		public Vector3 Normal
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

		public float Magnitude
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToSingle(Data, 12);
				}
				return -1f;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 12);
				}
			}
		}

		public float Alpha
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToSingle(Data, 16);
				}
				return -1f;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 16);
				}
			}
		}

		public DisplacementVertex(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public DisplacementVertex(DisplacementVertex source, ILump parent)
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
			Normal = source.Normal;
			Magnitude = source.Magnitude;
			Alpha = source.Alpha;
		}

		public static Lump<DisplacementVertex> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<DisplacementVertex>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.Source))
			{
				return 20;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 33;
			}
			return -1;
		}
	}
}
