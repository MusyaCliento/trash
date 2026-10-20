using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LibBSP
{
	public struct StaticProp : ILumpObject
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
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						return Vector3Extensions.ToVector3(Data);
					}
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						value.GetBytes().CopyTo(Data, 0);
					}
				}
			}
		}

		public Vector3 Angles
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						return Vector3Extensions.ToVector3(Data, 12);
					}
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						value.GetBytes().CopyTo(Data, 12);
					}
				}
			}
		}

		public string Model => ((StaticProps)Parent).ModelDictionary[ModelIndex];

		public short ModelIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						return BitConverter.ToInt16(Data, 24);
					}
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 24);
					}
				}
			}
		}

		public IEnumerable<short> LeafIndices
		{
			get
			{
				int i = 0;
				while (i < NumLeafIndices)
				{
					yield return ((StaticProps)Parent).LeafIndices[FirstLeafIndexIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		public short FirstLeafIndexIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 7u)
					{
						return BitConverter.ToInt16(Data, 26);
					}
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 7u)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 26);
					}
				}
			}
		}

		public short NumLeafIndices
		{
			get
			{
				if (MapType == MapType.Source)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 7u)
					{
						return BitConverter.ToInt16(Data, 28);
					}
				}
				return -1;
			}
			set
			{
				if (MapType == MapType.Source)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 7u)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 28);
					}
				}
			}
		}

		public byte Solidity
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						return Data[30];
					}
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						Data[30] = value;
					}
				}
			}
		}

		public byte Flags
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						return Data[31];
					}
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 4) <= 8u)
					{
						Data[31] = value;
					}
				}
			}
		}

		public int Skin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return BitConverter.ToInt32(Data, 32);
					case 9:
						if (Data.Length == 76)
						{
							return BitConverter.ToInt32(Data, 36);
						}
						return BitConverter.ToInt32(Data, 32);
					}
				}
				return -1;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					BitConverter.GetBytes(value).CopyTo(Data, 32);
					break;
				case 9:
					if (Data.Length == 76)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 36);
					}
					else
					{
						BitConverter.GetBytes(value).CopyTo(Data, 32);
					}
					break;
				}
			}
		}

		public float MinimumFadeDistance
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return BitConverter.ToSingle(Data, 36);
					case 9:
						if (Data.Length == 76)
						{
							return BitConverter.ToSingle(Data, 40);
						}
						return BitConverter.ToSingle(Data, 36);
					}
				}
				return float.NaN;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					BitConverter.GetBytes(value).CopyTo(Data, 36);
					break;
				case 9:
					if (Data.Length == 76)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 40);
					}
					else
					{
						BitConverter.GetBytes(value).CopyTo(Data, 36);
					}
					break;
				}
			}
		}

		public float MaximumFadeDistance
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return BitConverter.ToSingle(Data, 40);
					case 9:
						if (Data.Length == 76)
						{
							return BitConverter.ToInt32(Data, 44);
						}
						return BitConverter.ToInt32(Data, 40);
					}
				}
				return float.NaN;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					BitConverter.GetBytes(value).CopyTo(Data, 40);
					break;
				case 9:
					if (Data.Length == 76)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 44);
					}
					else
					{
						BitConverter.GetBytes(value).CopyTo(Data, 40);
					}
					break;
				}
			}
		}

		public Vector3 LightingOrigin
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return Vector3Extensions.ToVector3(Data, 44);
					case 9:
						if (Data.Length == 76)
						{
							return Vector3Extensions.ToVector3(Data, 48);
						}
						return Vector3Extensions.ToVector3(Data, 44);
					}
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					value.GetBytes().CopyTo(Data, 44);
					break;
				case 9:
					if (Data.Length == 76)
					{
						value.GetBytes().CopyTo(Data, 48);
					}
					else
					{
						value.GetBytes().CopyTo(Data, 44);
					}
					break;
				}
			}
		}

		public float ForcedFadeScale
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 5:
					case 6:
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return BitConverter.ToSingle(Data, 56);
					case 9:
						if (Data.Length == 76)
						{
							return BitConverter.ToSingle(Data, 60);
						}
						return BitConverter.ToSingle(Data, 56);
					}
				}
				return float.NaN;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 5:
				case 6:
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					BitConverter.GetBytes(value).CopyTo(Data, 56);
					break;
				case 9:
					if (Data.Length == 76)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 60);
					}
					else
					{
						BitConverter.GetBytes(value).CopyTo(Data, 56);
					}
					break;
				}
			}
		}

		public short MinimumDirectXLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 6) <= 1u)
					{
						return BitConverter.ToInt16(Data, 60);
					}
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 6) <= 1u)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 60);
					}
				}
			}
		}

		public short MaximumDirectXLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 6) <= 1u)
					{
						return BitConverter.ToInt16(Data, 62);
					}
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 6) <= 1u)
					{
						BitConverter.GetBytes(value).CopyTo(Data, 62);
					}
				}
			}
		}

		public byte MinimumCPULevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 8:
					case 10:
					case 11:
					case 12:
						return Data[60];
					case 9:
						if (Data.Length == 76)
						{
							return Data[64];
						}
						return Data[60];
					}
				}
				return 0;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 8:
				case 10:
				case 11:
				case 12:
					Data[60] = value;
					break;
				case 9:
					if (Data.Length == 76)
					{
						Data[64] = value;
					}
					else
					{
						Data[60] = value;
					}
					break;
				}
			}
		}

		public byte MaximumCPULevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 8:
					case 10:
					case 11:
					case 12:
						return Data[61];
					case 9:
						if (Data.Length == 76)
						{
							return Data[65];
						}
						return Data[61];
					}
				}
				return 0;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 8:
				case 10:
				case 11:
				case 12:
					Data[61] = value;
					break;
				case 9:
					if (Data.Length == 76)
					{
						Data[65] = value;
					}
					else
					{
						Data[61] = value;
					}
					break;
				}
			}
		}

		public byte MinimumGPULevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 8:
					case 10:
					case 11:
					case 12:
						return Data[62];
					case 9:
						if (Data.Length == 76)
						{
							return Data[66];
						}
						return Data[62];
					}
				}
				return 0;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 8:
				case 10:
				case 11:
				case 12:
					Data[62] = value;
					break;
				case 9:
					if (Data.Length == 76)
					{
						Data[66] = value;
					}
					else
					{
						Data[62] = value;
					}
					break;
				}
			}
		}

		public byte MaximumGPULevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 8:
					case 10:
					case 11:
					case 12:
						return Data[63];
					case 9:
						if (Data.Length == 76)
						{
							return Data[67];
						}
						return Data[63];
					}
				}
				return 0;
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 8:
				case 10:
				case 11:
				case 12:
					Data[63] = value;
					break;
				case 9:
					if (Data.Length == 76)
					{
						Data[67] = value;
					}
					else
					{
						Data[63] = value;
					}
					break;
				}
			}
		}

		public Color32 DiffuseModulaton
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Titanfall)
				{
					switch (LumpVersion)
					{
					case 7:
					case 8:
					case 10:
					case 11:
					case 12:
						return ColorExtensions.FromArgb(Data[67], Data[64], Data[65], Data[66]);
					case 9:
						if (Data.Length == 76)
						{
							return ColorExtensions.FromArgb(Data[72], Data[69], Data[70], Data[71]);
						}
						return ColorExtensions.FromArgb(Data[67], Data[64], Data[65], Data[66]);
					}
				}
				return ColorExtensions.FromArgb(255, 255, 255, 255);
			}
			set
			{
				if (!MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Titanfall)
				{
					return;
				}
				switch (LumpVersion)
				{
				case 7:
				case 8:
				case 10:
				case 11:
				case 12:
					value.GetBytes().CopyTo(Data, 64);
					break;
				case 9:
					if (Data.Length == 76)
					{
						value.GetBytes().CopyTo(Data, 69);
					}
					else
					{
						value.GetBytes().CopyTo(Data, 64);
					}
					break;
				}
			}
		}

		public float Scale
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Source) && LumpVersion == 11)
				{
					return BitConverter.ToSingle(Data, 76);
				}
				return float.NaN;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Source) && LumpVersion == 11)
				{
					BitConverter.GetBytes(value).CopyTo(Data, 76);
				}
			}
		}

		public string Name
		{
			get
			{
				if (MapType == MapType.Source20)
				{
					int lumpVersion = LumpVersion;
					if ((uint)(lumpVersion - 5) <= 1u)
					{
						if (Data.Length > 128)
						{
							return Data.ToNullTerminatedString(Data.Length - 128, 128);
						}
						return null;
					}
				}
				return null;
			}
			set
			{
				if (MapType != MapType.Source20)
				{
					return;
				}
				int lumpVersion = LumpVersion;
				if ((uint)(lumpVersion - 5) <= 1u && Data.Length > 128)
				{
					for (int i = 0; i < 128; i++)
					{
						Data[Data.Length - i - 1] = 0;
					}
					if (value != null)
					{
						byte[] bytes = Encoding.ASCII.GetBytes(value);
						Array.Copy(bytes, 0, Data, Data.Length - 128, Math.Min(bytes.Length, 127));
					}
				}
			}
		}

		public StaticProp(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public StaticProp(StaticProp source, ILump parent)
		{
			Parent = parent;
			if (parent != null && parent.Bsp != null && source.Parent != null && source.Parent.Bsp != null && source.Parent.Bsp.MapType == parent.Bsp.MapType && source.LumpVersion == parent.LumpInfo.version)
			{
				Data = new byte[source.Data.Length];
				Array.Copy(source.Data, Data, source.Data.Length);
				return;
			}
			Data = new byte[192];
			Origin = source.Origin;
			Angles = source.Angles;
			ModelIndex = source.ModelIndex;
			FirstLeafIndexIndex = source.FirstLeafIndexIndex;
			NumLeafIndices = source.NumLeafIndices;
			Solidity = source.Solidity;
			Flags = source.Flags;
			Skin = source.Skin;
			MinimumFadeDistance = source.MinimumFadeDistance;
			MaximumFadeDistance = source.MaximumFadeDistance;
			LightingOrigin = source.LightingOrigin;
			ForcedFadeScale = source.ForcedFadeScale;
			MinimumDirectXLevel = source.MinimumDirectXLevel;
			MaximumDirectXLevel = source.MaximumDirectXLevel;
			MinimumCPULevel = source.MinimumCPULevel;
			MaximumCPULevel = source.MaximumCPULevel;
			MinimumGPULevel = source.MinimumGPULevel;
			MaximumGPULevel = source.MaximumGPULevel;
			DiffuseModulaton = source.DiffuseModulaton;
			Scale = source.Scale;
			Name = source.Name;
		}

		public static StaticProps LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new StaticProps(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			return -1;
		}
	}
}
