using System;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	public struct StaticModel : ILumpObject
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

		public string Name
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Data.ToNullTerminatedString(0, 128);
				}
				return null;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					for (int i = 0; i < 128; i++)
					{
						Data[i] = 0;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(value);
					Array.Copy(bytes, 0, Data, 0, Math.Min(bytes.Length, 127));
				}
			}
		}

		public Vector3 Origin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Vector3Extensions.ToVector3(Data, 128);
				}
				return new Vector3(float.NaN, float.NaN, float.NaN);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					value.GetBytes().CopyTo(Data, 128);
				}
			}
		}

		public Vector3 Angles
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Vector3Extensions.ToVector3(Data, 140);
				}
				return new Vector3(float.NaN, float.NaN, float.NaN);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					value.GetBytes().CopyTo(Data, 140);
				}
			}
		}

		public float Scale
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToSingle(Data, 152);
				}
				return float.NaN;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 152);
				}
			}
		}

		public StaticModel(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public StaticModel(StaticModel source, ILump parent = null)
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
			Data = source.Data;
			Name = source.Name;
			Origin = source.Origin;
			Angles = source.Angles;
			Scale = source.Scale;
		}

		public static Lump<StaticModel> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<StaticModel>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType.IsSubtypeOf(MapType.MOHAA))
			{
				return 164;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type == MapType.MOHAADemo)
			{
				return 26;
			}
			if (type.IsSubtypeOf(MapType.MOHAA))
			{
				return 25;
			}
			return -1;
		}
	}
}
