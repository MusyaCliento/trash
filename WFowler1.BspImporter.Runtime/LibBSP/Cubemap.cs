using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Cubemap : ILumpObject
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

		public Vector3 Origin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector3(BitConverter.ToInt32(Data, 0), BitConverter.ToInt32(Data, 4), BitConverter.ToInt32(Data, 8));
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 0);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 4);
					BitConverter.GetBytes((int)value.Z()).CopyTo(Data, 8);
				}
			}
		}

		public int Size
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
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 12);
				}
			}
		}

		public Cubemap(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Cubemap(Cubemap source, ILump parent)
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
			Origin = source.Origin;
			Size = source.Size;
		}

		public static Lump<Cubemap> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Cubemap>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.Source))
			{
				return 16;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 42;
			}
			return -1;
		}
	}
}
