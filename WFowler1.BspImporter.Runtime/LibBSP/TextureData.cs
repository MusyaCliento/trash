using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct TextureData : ILumpObject
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

		public Color32 Reflectivity
		{
			get
			{
				return ColorExtensions.FromArgb((int)(BitConverter.ToSingle(Data, 0) * 255f), (int)(BitConverter.ToSingle(Data, 4) * 255f), (int)(BitConverter.ToSingle(Data, 8) * 255f), 255);
			}
			set
			{
				float x = (float)(int)value.R() / 255f;
				float y = (float)(int)value.G() / 255f;
				float z = (float)(int)value.B() / 255f;
				new Vector3(x, y, z).GetBytes().CopyTo(Data, 0);
			}
		}

		public uint TextureStringOffset => (uint)Parent.Bsp.TextureTable[TextureStringOffsetIndex];

		public int TextureStringOffsetIndex
		{
			get
			{
				return BitConverter.ToInt32(Data, 12);
			}
			set
			{
				BitConverter.GetBytes(value).CopyTo(Data, 12);
			}
		}

		public Vector2 Size
		{
			get
			{
				return new Vector2(BitConverter.ToInt32(Data, 16), BitConverter.ToInt32(Data, 20));
			}
			set
			{
				int value2 = (int)value.X();
				int value3 = (int)value.Y();
				BitConverter.GetBytes(value2).CopyTo(Data, 16);
				BitConverter.GetBytes(value3).CopyTo(Data, 20);
			}
		}

		public Vector2 ViewSize
		{
			get
			{
				return new Vector2(BitConverter.ToInt32(Data, 24), BitConverter.ToInt32(Data, 28));
			}
			set
			{
				int value2 = (int)value.X();
				int value3 = (int)value.Y();
				BitConverter.GetBytes(value2).CopyTo(Data, 24);
				BitConverter.GetBytes(value3).CopyTo(Data, 28);
			}
		}

		public TextureData(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public TextureData(TextureData source, ILump parent)
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
			Reflectivity = source.Reflectivity;
			TextureStringOffsetIndex = source.TextureStringOffsetIndex;
			Size = source.Size;
			ViewSize = source.ViewSize;
		}

		public static Lump<TextureData> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<TextureData>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType == MapType.Titanfall)
			{
				return 36;
			}
			if (mapType.IsSubtypeOf(MapType.Source))
			{
				return 32;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 2;
			}
			return -1;
		}
	}
}
