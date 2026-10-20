using System;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	public struct Texture : ILumpObject
	{
		public const int NumMipmaps = 4;

		public const int FullMipmap = 0;

		public const int HalfMipmap = 1;

		public const int QuarterMipmap = 2;

		public const int EighthMipmap = 3;

		private byte[][] _mipmaps;

		private byte[] _palette;

		public ILump Parent { get; private set; }

		public byte[] Data { get; private set; }

		public byte[][] Mipmaps
		{
			get
			{
				if (_mipmaps == null && MipmapFullOffset >= 0)
				{
					_mipmaps = new byte[4][];
				}
				return _mipmaps;
			}
		}

		public byte[] Palette => _palette;

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
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return Data.ToNullTerminatedString(0, 16);
				}
				if (MapType == MapType.SiN)
				{
					return Data.ToNullTerminatedString(36, 64);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return Data.ToNullTerminatedString(40, 32);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					return Data.ToNullTerminatedString(0, 64);
				}
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					return Data.ToRawString();
				}
				return null;
			}
			set
			{
				byte[] bytes = Encoding.ASCII.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					for (int i = 0; i < 16; i++)
					{
						Data[i] = 0;
					}
					Array.Copy(bytes, 0, Data, 0, Math.Min(bytes.Length, 15));
				}
				else if (MapType == MapType.SiN)
				{
					for (int j = 0; j < 64; j++)
					{
						Data[j + 36] = 0;
					}
					Array.Copy(bytes, 0, Data, 36, Math.Min(bytes.Length, 63));
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					for (int k = 0; k < 32; k++)
					{
						Data[k + 40] = 0;
					}
					Array.Copy(bytes, 0, Data, 40, Math.Min(bytes.Length, 31));
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					for (int l = 0; l < 64; l++)
					{
						Data[l] = 0;
					}
					Array.Copy(bytes, 0, Data, 0, Math.Min(bytes.Length, 63));
				}
				else if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					Data = bytes;
				}
			}
		}

		public string Mask
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return Data.ToNullTerminatedString(76, 64);
				}
				return null;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					for (int i = 0; i < 64; i++)
					{
						Data[i + 76] = 0;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(value);
					Array.Copy(bytes, 0, Data, 76, Math.Min(bytes.Length, 63));
				}
			}
		}

		public int Flags
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToInt32(Data, 32);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 64);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					bytes.CopyTo(Data, 32);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 64);
				}
			}
		}

		public int Contents
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 68);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 68);
				}
			}
		}

		public TextureInfo TextureInfo
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return new TextureInfo(Vector3Extensions.ToVector3(Data), Vector3Extensions.ToVector3(Data, 16), new Vector2(BitConverter.ToSingle(Data, 12), BitConverter.ToSingle(Data, 28)), new Vector2(1f, 1f), -1, -1, 0f);
				}
				return default(TextureInfo);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					value.UAxis.GetBytes().CopyTo(Data, 0);
					value.VAxis.GetBytes().CopyTo(Data, 16);
					BitConverter.GetBytes(value.Translation.X()).CopyTo(Data, 12);
					BitConverter.GetBytes(value.Translation.Y()).CopyTo(Data, 28);
				}
			}
		}

		public Vector2 Dimensions
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return new Vector2(BitConverter.ToUInt32(Data, 16), BitConverter.ToUInt32(Data, 20));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 16);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 20);
				}
			}
		}

		public int MipmapFullOffset
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 24);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 24);
				}
			}
		}

		public int MipmapHalfOffset
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 28);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 28);
				}
			}
		}

		public int MipmapQuarterOffset
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 32);
				}
			}
		}

		public int PaletteSize => Palette.Length / 3;

		public int MipmapEighthOffset
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public int Value
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake2) && MapType != MapType.SiN)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return 0;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake2) && MapType != MapType.SiN)
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public int Next
		{
			get
			{
				if (MapType == MapType.SiN)
				{
					return BitConverter.ToInt32(Data, 100);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToInt32(Data, 72);
				}
				return 0;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.SiN)
				{
					bytes.CopyTo(Data, 100);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					bytes.CopyTo(Data, 72);
				}
			}
		}

		public int Subdivisions
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.UberTools))
				{
					return BitConverter.ToInt32(Data, 72);
				}
				return 16;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.UberTools))
				{
					bytes.CopyTo(Data, 72);
				}
			}
		}

		public Texture(byte[] data, ILump parent)
			: this(data, parent, null, null)
		{
		}

		public Texture(byte[] data, ILump parent, byte[][] mipmaps, byte[] palette)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
			_mipmaps = mipmaps;
			_palette = palette;
		}

		public Texture(Texture source, ILump parent)
		{
			Parent = parent;
			if (parent != null && parent.Bsp != null)
			{
				if (source.Parent != null && source.Parent.Bsp != null && source.Parent.Bsp.MapType == parent.Bsp.MapType && source.LumpVersion == parent.LumpInfo.version)
				{
					Data = new byte[source.Data.Length];
					Array.Copy(source.Data, Data, source.Data.Length);
					_mipmaps = source.Mipmaps;
					_palette = source.Palette;
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
				Data = new byte[GetStructLength(MapType.Undefined, 0)];
			}
			_mipmaps = source.Mipmaps;
			_palette = source.Palette;
			Name = source.Name;
			Mask = source.Mask;
			Flags = source.Flags;
			Contents = source.Contents;
			TextureInfo = source.TextureInfo;
			Dimensions = source.Dimensions;
			MipmapFullOffset = source.MipmapFullOffset;
			MipmapHalfOffset = source.MipmapHalfOffset;
			MipmapQuarterOffset = source.MipmapQuarterOffset;
			MipmapEighthOffset = source.MipmapEighthOffset;
			Value = source.Value;
			Next = source.Next;
			Subdivisions = source.Subdivisions;
		}

		public static Textures LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Textures(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType type, int version)
		{
			return -1;
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.UberTools) || type.IsSubtypeOf(MapType.CoD))
			{
				return 0;
			}
			if (type.IsSubtypeOf(MapType.Quake) || type == MapType.Nightfire)
			{
				return 2;
			}
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 5;
			}
			if (type.IsSubtypeOf(MapType.Quake3))
			{
				return 1;
			}
			if (type.IsSubtypeOf(MapType.Source) || type == MapType.Titanfall)
			{
				return 43;
			}
			return -1;
		}

		public static int GetIndexForMaterialLump(MapType type)
		{
			if (type == MapType.Nightfire)
			{
				return 3;
			}
			return -1;
		}

		public static string SanitizeName(string name, MapType mapType)
		{
			string text = name.Replace('\\', '/');
			if (mapType.IsSubtypeOf(MapType.Source) || mapType == MapType.Titanfall)
			{
				if (text.Length >= 5 && text.Substring(0, 5).Equals("maps/", StringComparison.InvariantCultureIgnoreCase))
				{
					text = text.Substring(5);
					for (int i = 0; i < text.Length; i++)
					{
						if (text[i] == '/')
						{
							text = text.Substring(i + 1);
							break;
						}
					}
				}
				int num = 0;
				bool flag = false;
				for (int num2 = text.Length - 1; num2 > 0; num2--)
				{
					if (text[num2] <= '9' && text[num2] >= '0')
					{
						flag = true;
					}
					else if (text[num2] == '-')
					{
						if (!flag)
						{
							break;
						}
					}
					else
					{
						if (text[num2] != '_' || !flag)
						{
							break;
						}
						num++;
						if (num == 3)
						{
							text = text.Substring(0, num2);
						}
						flag = false;
					}
				}
			}
			return text;
		}
	}
}
