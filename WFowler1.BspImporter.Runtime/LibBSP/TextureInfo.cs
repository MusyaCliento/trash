using System;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public struct TextureInfo : ILumpObject
	{
		public Vector2 scale;

		public float rotation;

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

		public Vector3 UAxis
		{
			get
			{
				return Vector3Extensions.ToVector3(Data);
			}
			set
			{
				value.GetBytes().CopyTo(Data, 0);
			}
		}

		public Vector3 VAxis
		{
			get
			{
				return Vector3Extensions.ToVector3(Data, 16);
			}
			set
			{
				value.GetBytes().CopyTo(Data, 16);
			}
		}

		public Vector2 Translation
		{
			get
			{
				return new Vector2(BitConverter.ToSingle(Data, 12), BitConverter.ToSingle(Data, 28));
			}
			set
			{
				BitConverter.GetBytes(value.X()).CopyTo(Data, 12);
				BitConverter.GetBytes(value.Y()).CopyTo(Data, 28);
			}
		}

		public Vector3 LightmapUAxis
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Vector3Extensions.ToVector3(Data, 32);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 32);
				}
			}
		}

		public Vector3 LightmapVAxis
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Vector3Extensions.ToVector3(Data, 48);
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					value.GetBytes().CopyTo(Data, 48);
				}
			}
		}

		public Vector2 LightmapTranslation
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector2(BitConverter.ToSingle(Data, 44), BitConverter.ToSingle(Data, 60));
				}
				return new Vector2(0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value.X()).CopyTo(Data, 44);
					BitConverter.GetBytes(value.Y()).CopyTo(Data, 60);
				}
			}
		}

		public int Flags
		{
			get
			{
				if (MapType == MapType.DMoMaM)
				{
					return BitConverter.ToInt32(Data, 88);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 64);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Undefined)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.DMoMaM)
				{
					bytes.CopyTo(Data, 88);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 64);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Undefined)
				{
					bytes.CopyTo(Data, 36);
				}
			}
		}

		public int TextureIndex
		{
			get
			{
				if (MapType == MapType.DMoMaM)
				{
					return BitConverter.ToInt32(Data, 92);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 68);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Undefined)
				{
					return BitConverter.ToInt32(Data, 32);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.DMoMaM)
				{
					bytes.CopyTo(Data, 92);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					bytes.CopyTo(Data, 68);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Undefined)
				{
					bytes.CopyTo(Data, 32);
				}
			}
		}

		public TextureInfo(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
			scale = new Vector2(1f, 1f);
			rotation = 0f;
		}

		public TextureInfo(Vector3 uAxis, Vector3 vAxis, Vector2 translation, Vector2 scale, int flags, int texture, float rotation)
		{
			Data = new byte[40];
			Parent = null;
			this.scale = scale;
			this.rotation = rotation;
			UAxis = uAxis;
			VAxis = vAxis;
			Translation = translation;
			Flags = flags;
			TextureIndex = texture;
		}

		public TextureInfo(TextureInfo source, ILump parent)
		{
			Parent = parent;
			scale = source.scale;
			rotation = source.rotation;
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
			UAxis = source.UAxis;
			VAxis = source.VAxis;
			Translation = source.Translation;
			LightmapUAxis = source.LightmapUAxis;
			LightmapVAxis = source.LightmapVAxis;
			LightmapTranslation = source.LightmapTranslation;
			Flags = source.Flags;
			TextureIndex = source.TextureIndex;
		}

		public static Vector3[] TextureAxisFromPlane(Plane p)
		{
			int num = p.BestAxis();
			return new Vector3[2]
			{
				PlaneExtensions.baseAxes[num * 3 + 1],
				PlaneExtensions.baseAxes[num * 3 + 2]
			};
		}

		public static Lump<TextureInfo> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<TextureInfo>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType == MapType.DMoMaM)
			{
				return 96;
			}
			if (mapType.IsSubtypeOf(MapType.Source))
			{
				return 72;
			}
			if (mapType == MapType.Nightfire)
			{
				return 32;
			}
			if (mapType.IsSubtypeOf(MapType.Quake) || mapType == MapType.Undefined)
			{
				return 40;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source))
			{
				return 6;
			}
			if (type == MapType.Nightfire)
			{
				return 17;
			}
			return -1;
		}
	}
}
