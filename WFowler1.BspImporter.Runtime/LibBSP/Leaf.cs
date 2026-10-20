using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LibBSP
{
	public struct Leaf : ILumpObject
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

		public int Contents
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 0);
				}
				return -1;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source) || MapType == MapType.Nightfire)
				{
					BitConverter.GetBytes(value).CopyTo(Data, 0);
				}
			}
		}

		public int Visibility
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Nightfire || MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt16(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 0);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType == MapType.Nightfire || MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[4] = bytes[0];
					Data[5] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3))
				{
					bytes.CopyTo(Data, 0);
				}
			}
		}

		public int Area
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					return BitConverter.ToInt16(Data, 6);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && MapType != MapType.CoD4)
				{
					return BitConverter.ToInt32(Data, 4);
				}
				if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					return Data[6];
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.Quake2))
				{
					Data[6] = bytes[0];
					Data[7] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && MapType != MapType.CoD4)
				{
					bytes.CopyTo(Data, 4);
				}
				else if (MapType.IsSubtypeOf(MapType.Source) && MapType != MapType.Vindictus)
				{
					Data[6] = bytes[0];
				}
			}
		}

		public int Flags
		{
			get
			{
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Source))
				{
					return Data[7];
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 8);
				}
				else if (MapType.IsSubtypeOf(MapType.Source))
				{
					Data[7] = bytes[0];
				}
			}
		}

		public Vector3 Minimums
		{
			get
			{
				if (MapType == MapType.SoF)
				{
					return new Vector3(BitConverter.ToInt16(Data, 10), BitConverter.ToInt16(Data, 12), BitConverter.ToInt16(Data, 14));
				}
				if (MapType == MapType.Vindictus)
				{
					return new Vector3(BitConverter.ToInt32(Data, 12), BitConverter.ToInt32(Data, 16), BitConverter.ToInt32(Data, 20));
				}
				if (MapType == MapType.Nightfire)
				{
					return Vector3Extensions.ToVector3(Data, 8);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector3(BitConverter.ToInt16(Data, 8), BitConverter.ToInt16(Data, 10), BitConverter.ToInt16(Data, 12));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return new Vector3(BitConverter.ToInt32(Data, 8), BitConverter.ToInt32(Data, 12), BitConverter.ToInt32(Data, 16));
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.SoF)
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 10);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 12);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 14);
				}
				else if (MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 12);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 16);
					BitConverter.GetBytes((int)value.Z()).CopyTo(Data, 20);
				}
				else if (MapType == MapType.Nightfire)
				{
					value.GetBytes().CopyTo(Data, 8);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 8);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 10);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 12);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 8);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 12);
					BitConverter.GetBytes((int)value.Z()).CopyTo(Data, 16);
				}
			}
		}

		public Vector3 Maximums
		{
			get
			{
				if (MapType == MapType.SoF)
				{
					return new Vector3(BitConverter.ToInt16(Data, 16), BitConverter.ToInt16(Data, 18), BitConverter.ToInt16(Data, 20));
				}
				if (MapType == MapType.Vindictus)
				{
					return new Vector3(BitConverter.ToInt32(Data, 24), BitConverter.ToInt32(Data, 28), BitConverter.ToInt32(Data, 32));
				}
				if (MapType == MapType.Nightfire)
				{
					return Vector3Extensions.ToVector3(Data, 20);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return new Vector3(BitConverter.ToInt16(Data, 14), BitConverter.ToInt16(Data, 16), BitConverter.ToInt16(Data, 18));
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					return new Vector3(BitConverter.ToInt32(Data, 20), BitConverter.ToInt32(Data, 24), BitConverter.ToInt32(Data, 28));
				}
				return new Vector3(0f, 0f, 0f);
			}
			set
			{
				if (MapType == MapType.SoF)
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 16);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 18);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 20);
				}
				else if (MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes((int)value.X()).CopyTo(Data, 24);
					BitConverter.GetBytes((int)value.Y()).CopyTo(Data, 28);
					BitConverter.GetBytes((int)value.Z()).CopyTo(Data, 32);
				}
				else if (MapType == MapType.Nightfire)
				{
					value.GetBytes().CopyTo(Data, 20);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 14);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 16);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 18);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) && !MapType.IsSubtypeOf(MapType.CoD))
				{
					BitConverter.GetBytes((short)value.X()).CopyTo(Data, 20);
					BitConverter.GetBytes((short)value.Y()).CopyTo(Data, 24);
					BitConverter.GetBytes((short)value.Z()).CopyTo(Data, 28);
				}
			}
		}

		public IEnumerable<int> MarkBrushes
		{
			get
			{
				int i = 0;
				while (i < NumMarkBrushIndices)
				{
					yield return (int)Parent.Bsp.LeafBrushes[FirstMarkBrushIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("LeafBrushes")]
		public int FirstMarkBrushIndex
		{
			get
			{
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt32(Data, 12);
				}
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 16);
				}
				if (MapType == MapType.SoF)
				{
					return BitConverter.ToUInt16(Data, 26);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 44);
				}
				if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 24);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD4)
				{
					bytes.CopyTo(Data, 12);
				}
				else if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 16);
				}
				else if (MapType == MapType.SoF)
				{
					Data[26] = bytes[0];
					Data[27] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[24] = bytes[0];
					Data[25] = bytes[1];
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 40);
				}
			}
		}

		[Count("LeafBrushes")]
		public int NumMarkBrushIndices
		{
			get
			{
				if (MapType == MapType.CoD4)
				{
					return BitConverter.ToInt32(Data, 16);
				}
				if (MapType.IsSubtypeOf(MapType.CoD))
				{
					return BitConverter.ToInt32(Data, 20);
				}
				if (MapType == MapType.SoF)
				{
					return BitConverter.ToUInt16(Data, 28);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 48);
				}
				if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 44);
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
				if (MapType == MapType.CoD4)
				{
					bytes.CopyTo(Data, 16);
				}
				else if (MapType.IsSubtypeOf(MapType.CoD))
				{
					bytes.CopyTo(Data, 20);
				}
				else if (MapType == MapType.SoF)
				{
					Data[28] = bytes[0];
					Data[29] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 48);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake3) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 44);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[26] = bytes[0];
					Data[27] = bytes[1];
				}
			}
		}

		public IEnumerable<int> MarkFaces
		{
			get
			{
				int i = 0;
				while (i < NumMarkFaceIndices)
				{
					yield return (int)Parent.Bsp.LeafFaces[FirstMarkFaceIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("LeafFaces")]
		public int FirstMarkFaceIndex
		{
			get
			{
				if (MapType == MapType.SoF)
				{
					return BitConverter.ToUInt16(Data, 22);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if ((MapType.IsSubtypeOf(MapType.Quake3) && MapType.IsSubtypeOf(MapType.CoD)) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 32);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 20);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.SoF)
				{
					Data[22] = bytes[0];
					Data[23] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 36);
				}
				else if ((MapType.IsSubtypeOf(MapType.Quake3) && MapType.IsSubtypeOf(MapType.CoD)) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 32);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[20] = bytes[0];
					Data[21] = bytes[1];
				}
			}
		}

		[Count("LeafFaces")]
		public int NumMarkFaceIndices
		{
			get
			{
				if (MapType == MapType.SoF)
				{
					return BitConverter.ToUInt16(Data, 24);
				}
				if (MapType == MapType.Vindictus)
				{
					return BitConverter.ToInt32(Data, 40);
				}
				if ((MapType.IsSubtypeOf(MapType.Quake3) && MapType.IsSubtypeOf(MapType.CoD)) || MapType == MapType.Nightfire)
				{
					return BitConverter.ToInt32(Data, 36);
				}
				if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToUInt16(Data, 22);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.SoF)
				{
					Data[24] = bytes[0];
					Data[25] = bytes[1];
				}
				else if (MapType == MapType.Vindictus)
				{
					bytes.CopyTo(Data, 40);
				}
				else if ((MapType.IsSubtypeOf(MapType.Quake3) && MapType.IsSubtypeOf(MapType.CoD)) || MapType == MapType.Nightfire)
				{
					bytes.CopyTo(Data, 36);
				}
				else if (MapType.IsSubtypeOf(MapType.Quake) || MapType.IsSubtypeOf(MapType.Quake2) || MapType.IsSubtypeOf(MapType.Source))
				{
					Data[22] = bytes[0];
					Data[23] = bytes[1];
				}
			}
		}

		public byte WaterSoundLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return Data[24];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[24] = value;
				}
			}
		}

		public byte SkySoundLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return Data[25];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[25] = value;
				}
			}
		}

		public byte SlimeSoundLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return Data[26];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[26] = value;
				}
			}
		}

		public byte LavaSoundLevel
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					return Data[27];
				}
				return 0;
			}
			set
			{
				if (MapType.IsSubtypeOf(MapType.Quake))
				{
					Data[27] = value;
				}
			}
		}

		public IEnumerable<int> LeafStaticModels
		{
			get
			{
				int i = 0;
				while (i < NumLeafStaticModelIndices)
				{
					yield return (int)Parent.Bsp.LeafStaticModels[FirstLeafStaticModelIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("LeafStaticModels")]
		public int FirstLeafStaticModelIndex
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToInt32(Data, 56);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 56);
				}
			}
		}

		[Count("LeafStaticModels")]
		public int NumLeafStaticModelIndices
		{
			get
			{
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					return BitConverter.ToInt32(Data, 60);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType.IsSubtypeOf(MapType.MOHAA))
				{
					bytes.CopyTo(Data, 60);
				}
			}
		}

		public IEnumerable<int> PatchIndices
		{
			get
			{
				int i = 0;
				while (i < NumPatchIndices)
				{
					yield return (int)Parent.Bsp.LeafPatches[FirstPatchIndicesIndex + i];
					int num = i + 1;
					i = num;
				}
			}
		}

		[Index("PatchIndices")]
		public int FirstPatchIndicesIndex
		{
			get
			{
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					return BitConverter.ToInt32(Data, 8);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					bytes.CopyTo(Data, 8);
				}
			}
		}

		[Count("PatchIndices")]
		public int NumPatchIndices
		{
			get
			{
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					return BitConverter.ToInt32(Data, 12);
				}
				return -1;
			}
			set
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (MapType == MapType.CoD || MapType == MapType.CoDDemo || MapType == MapType.CoD2)
				{
					bytes.CopyTo(Data, 12);
				}
			}
		}

		public Leaf(byte[] data, ILump parent = null)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Parent = parent;
		}

		public Leaf(Leaf source, ILump parent)
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
			Contents = source.Contents;
			Visibility = source.Visibility;
			Area = source.Area;
			Flags = source.Flags;
			Minimums = source.Minimums;
			Maximums = source.Maximums;
			FirstMarkBrushIndex = source.FirstMarkBrushIndex;
			NumMarkBrushIndices = source.NumMarkBrushIndices;
			FirstMarkFaceIndex = source.FirstMarkFaceIndex;
			NumMarkFaceIndices = source.NumMarkFaceIndices;
			WaterSoundLevel = source.WaterSoundLevel;
			SkySoundLevel = source.SkySoundLevel;
			SlimeSoundLevel = source.SlimeSoundLevel;
			LavaSoundLevel = source.LavaSoundLevel;
			FirstLeafStaticModelIndex = source.FirstLeafStaticModelIndex;
			NumLeafStaticModelIndices = source.NumLeafStaticModelIndices;
			FirstPatchIndicesIndex = source.FirstPatchIndicesIndex;
			NumPatchIndices = source.NumPatchIndices;
		}

		public static Lump<Leaf> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new Lump<Leaf>(data, GetStructLength(bsp.MapType, lumpInfo.version), bsp, lumpInfo);
		}

		public static int GetStructLength(MapType mapType, int lumpVersion = 0)
		{
			if (mapType == MapType.CoD4)
			{
				return 24;
			}
			if (mapType.IsSubtypeOf(MapType.CoD))
			{
				return 36;
			}
			if (mapType.IsSubtypeOf(MapType.MOHAA))
			{
				return 64;
			}
			if (mapType == MapType.Source18 || mapType == MapType.Source19 || mapType == MapType.Vindictus)
			{
				return 56;
			}
			if (mapType.IsSubtypeOf(MapType.Source) || mapType == MapType.SoF || mapType == MapType.Daikatana)
			{
				return 32;
			}
			if (mapType.IsSubtypeOf(MapType.Quake) || mapType.IsSubtypeOf(MapType.Quake2))
			{
				return 28;
			}
			if (mapType.IsSubtypeOf(MapType.Quake3) || mapType == MapType.Nightfire)
			{
				return 48;
			}
			throw new ArgumentException("Lump object " + MethodBase.GetCurrentMethod().DeclaringType.Name + " does not exist in map type " + mapType.ToString() + " or has not been implemented.");
		}

		public static int GetIndexForLump(MapType type)
		{
			switch (type)
			{
			case MapType.Nightfire:
				return 11;
			case MapType.CoD:
			case MapType.CoDDemo:
				return 21;
			case MapType.CoD2:
				return 26;
			case MapType.CoD4:
				return 28;
			default:
				if (type.IsSubtypeOf(MapType.Quake2) || type.IsSubtypeOf(MapType.MOHAA) || type.IsSubtypeOf(MapType.FAKK2))
				{
					return 8;
				}
				if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source) || type.IsSubtypeOf(MapType.STEF2))
				{
					return 10;
				}
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 4;
				}
				return -1;
			}
		}
	}
}
