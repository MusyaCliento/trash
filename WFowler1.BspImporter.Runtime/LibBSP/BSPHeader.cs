using System;
using System.Collections.Generic;

namespace LibBSP
{
	public struct BSPHeader
	{
		public const int IBSPHeader = 1347633737;

		public const int RBSPHeader = 1347633746;

		public const int VBSPHeader = 1347633750;

		public const int EALAHeader = 1095516485;

		public const int MOHAAHeader = 892416050;

		public const int EF2Header = 556942917;

		public const int rBSPHeader = 1347633778;

		public const int FAKKHeader = 1263223110;

		public BSP Bsp { get; private set; }

		public byte[] Data { get; set; }

		public int Revision
		{
			get
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.UberTools))
				{
					return BitConverter.ToInt32(Data, 8);
				}
				return 0;
			}
			set
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.UberTools))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 8);
				}
			}
		}

		public BSPHeader(BSP bsp, byte[] data)
		{
			Bsp = bsp;
			Data = data;
		}

		public BSPHeader Regenerate()
		{
			if (Bsp != null && Bsp.MapType != MapType.Undefined)
			{
				int lumpInfoLength = GetLumpInfoLength(Bsp.MapType);
				int numLumps = BSP.GetNumLumps(Bsp.MapType);
				byte[] magic = GetMagic(Bsp.MapType);
				int revision = Revision;
				if (Bsp.MapType == MapType.CoD4)
				{
					int num = 0;
					int num2 = magic.Length + 4;
					Dictionary<int, LumpInfo> dictionary = new Dictionary<int, LumpInfo>();
					for (int i = 0; i < BSP.GetNumLumps(MapType.CoD4); i++)
					{
						LumpInfo lumpInfo = GetLumpInfo(i);
						if (lumpInfo.length > 0)
						{
							int num3 = Bsp.GetLoadedLump(lumpInfo.ident)?.Length ?? lumpInfo.length;
							lumpInfo.offset = num2;
							lumpInfo.length = num3;
							num2 += num3;
							dictionary.Add(i, lumpInfo);
							num++;
						}
					}
					byte[] array = new byte[num2 + lumpInfoLength * num];
					magic.CopyTo(array, 0);
					BitConverter.GetBytes(num).CopyTo(array, 8);
					int num4 = magic.Length + 4;
					foreach (KeyValuePair<int, LumpInfo> item in dictionary)
					{
						BitConverter.GetBytes(item.Key).CopyTo(array, num4);
						BitConverter.GetBytes(num4).CopyTo(array, num4 + 4);
						num4 += 8;
					}
					return new BSPHeader(Bsp, array);
				}
				int num5;
				byte[] array2;
				if (Bsp.MapType.IsSubtypeOf(MapType.UberTools))
				{
					num5 = magic.Length + 4;
					array2 = new byte[num5 + lumpInfoLength * numLumps];
					Revision = revision + 1;
				}
				else
				{
					num5 = magic.Length;
					array2 = new byte[num5 + lumpInfoLength * numLumps];
				}
				magic.CopyTo(array2, 0);
				int num6 = array2.Length;
				for (int j = 0; j < numLumps; j++)
				{
					ILump loadedLump = Bsp.GetLoadedLump(j);
					int length;
					int version;
					int ident;
					if (loadedLump != null)
					{
						length = loadedLump.Length;
						version = Bsp[j].version;
						ident = Bsp[j].ident;
					}
					else
					{
						LumpInfo lumpInfo2 = GetLumpInfo(j);
						length = lumpInfo2.length;
						version = lumpInfo2.version;
						ident = lumpInfo2.ident;
					}
					if (Bsp.MapType == MapType.L4D2 || Bsp.MapType == MapType.Source27)
					{
						BitConverter.GetBytes(version).CopyTo(array2, num5);
						BitConverter.GetBytes(num6).CopyTo(array2, num5 + 4);
						BitConverter.GetBytes(length).CopyTo(array2, num5 + 8);
						BitConverter.GetBytes(ident).CopyTo(array2, num5 + 12);
					}
					else if (Bsp.MapType.IsSubtypeOf(MapType.Source))
					{
						BitConverter.GetBytes(num6).CopyTo(array2, num5);
						BitConverter.GetBytes(length).CopyTo(array2, num5 + 4);
						BitConverter.GetBytes(version).CopyTo(array2, num5 + 8);
						BitConverter.GetBytes(ident).CopyTo(array2, num5 + 12);
					}
					else if (Bsp.MapType == MapType.CoD || Bsp.MapType == MapType.CoD2)
					{
						BitConverter.GetBytes(length).CopyTo(array2, num5);
						BitConverter.GetBytes(num6).CopyTo(array2, num5 + 4);
					}
					else
					{
						BitConverter.GetBytes(num6).CopyTo(array2, num5);
						BitConverter.GetBytes(length).CopyTo(array2, num5 + 4);
					}
					num5 += GetLumpInfoLength(Bsp.MapType);
					num6 += length;
				}
				return new BSPHeader(Bsp, array2);
			}
			return new BSPHeader(Bsp, new byte[0]);
		}

		public LumpInfo GetLumpInfo(int index)
		{
			if (index < 0 || index >= BSP.GetNumLumps(Bsp.MapType))
			{
				throw new IndexOutOfRangeException();
			}
			int lumpInfoLength = GetLumpInfoLength(Bsp.MapType);
			if (Bsp.MapType.IsSubtypeOf(MapType.Quake) || Bsp.MapType == MapType.Nightfire)
			{
				return GetLumpInfoAtOffset(4 + lumpInfoLength * index);
			}
			if (Bsp.MapType.IsSubtypeOf(MapType.STEF2) || Bsp.MapType.IsSubtypeOf(MapType.MOHAA) || Bsp.MapType.IsSubtypeOf(MapType.FAKK2))
			{
				return GetLumpInfoAtOffset(12 + lumpInfoLength * index);
			}
			if (Bsp.MapType == MapType.Titanfall)
			{
				LumpInfo lumpFileLumpInfo = Bsp.Reader.GetLumpFileLumpInfo(index);
				if (lumpFileLumpInfo.lumpFile != null)
				{
					return lumpFileLumpInfo;
				}
				return GetLumpInfoAtOffset(lumpInfoLength * (index + 1));
			}
			if (Bsp.MapType == MapType.CoD4)
			{
				int num = BitConverter.ToInt32(Data, 8);
				int num2 = 12;
				int i = num2 + num * 8;
				for (int j = 0; j < num; j++)
				{
					int num3 = BitConverter.ToInt32(Data, num2);
					int num4 = BitConverter.ToInt32(Data, num2 + 4);
					if (num3 == index)
					{
						return new LumpInfo
						{
							ident = num3,
							offset = i,
							length = num4
						};
					}
					for (i += num4; i % 4 != 0; i++)
					{
					}
					num2 += 8;
				}
				return default(LumpInfo);
			}
			if (Bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				LumpInfo lumpFileLumpInfo2 = Bsp.Reader.GetLumpFileLumpInfo(index);
				if (lumpFileLumpInfo2.lumpFile != null)
				{
					return lumpFileLumpInfo2;
				}
				return GetLumpInfoAtOffset(8 + lumpInfoLength * index);
			}
			if (Bsp.MapType.IsSubtypeOf(MapType.Quake2) || Bsp.MapType.IsSubtypeOf(MapType.Quake3))
			{
				return GetLumpInfoAtOffset(8 + lumpInfoLength * index);
			}
			return default(LumpInfo);
		}

		private LumpInfo GetLumpInfoAtOffset(int offset)
		{
			int lumpInfoLength = GetLumpInfoLength(Bsp.MapType);
			if (Data.Length < offset + lumpInfoLength)
			{
				return default(LumpInfo);
			}
			int version = 0;
			int ident = 0;
			int offset2;
			int length;
			if (Bsp.MapType == MapType.L4D2 || Bsp.MapType == MapType.Source27)
			{
				version = BitConverter.ToInt32(Data, offset);
				offset2 = BitConverter.ToInt32(Data, offset + 4);
				length = BitConverter.ToInt32(Data, offset + 8);
				ident = BitConverter.ToInt32(Data, offset + 12);
			}
			else if (Bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				offset2 = BitConverter.ToInt32(Data, offset);
				length = BitConverter.ToInt32(Data, offset + 4);
				version = BitConverter.ToInt32(Data, offset + 8);
				ident = BitConverter.ToInt32(Data, offset + 12);
			}
			else if (Bsp.MapType == MapType.CoD || Bsp.MapType == MapType.CoD2)
			{
				length = BitConverter.ToInt32(Data, offset);
				offset2 = BitConverter.ToInt32(Data, offset + 4);
			}
			else
			{
				offset2 = BitConverter.ToInt32(Data, offset);
				length = BitConverter.ToInt32(Data, offset + 4);
			}
			return new LumpInfo
			{
				offset = offset2,
				length = length,
				version = version,
				ident = ident
			};
		}

		public static byte[] GetMagic(MapType type)
		{
			switch (type)
			{
			case MapType.Quake:
				return BitConverter.GetBytes(29);
			case MapType.GoldSrc:
			case MapType.BlueShift:
				return BitConverter.GetBytes(30);
			case MapType.Quake2:
			{
				byte[] array26 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array26, 0);
				BitConverter.GetBytes(38).CopyTo(array26, 4);
				return array26;
			}
			case MapType.Daikatana:
			{
				byte[] array25 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array25, 0);
				BitConverter.GetBytes(41).CopyTo(array25, 4);
				return array25;
			}
			case MapType.SoF:
			case MapType.Quake3:
			{
				byte[] array24 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array24, 0);
				BitConverter.GetBytes(46).CopyTo(array24, 4);
				return array24;
			}
			case MapType.SiN:
			case MapType.Raven:
			{
				byte[] array23 = new byte[8];
				BitConverter.GetBytes(1347633746).CopyTo(array23, 0);
				BitConverter.GetBytes(1).CopyTo(array23, 4);
				return array23;
			}
			case MapType.ET:
			{
				byte[] array22 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array22, 0);
				BitConverter.GetBytes(47).CopyTo(array22, 4);
				return array22;
			}
			case MapType.CoD:
			{
				byte[] array21 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array21, 0);
				BitConverter.GetBytes(59).CopyTo(array21, 4);
				return array21;
			}
			case MapType.CoDDemo:
			{
				byte[] array20 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array20, 0);
				BitConverter.GetBytes(58).CopyTo(array20, 4);
				return array20;
			}
			case MapType.CoD2:
			{
				byte[] array19 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array19, 0);
				BitConverter.GetBytes(4).CopyTo(array19, 4);
				return array19;
			}
			case MapType.CoD4:
			{
				byte[] array18 = new byte[8];
				BitConverter.GetBytes(1347633737).CopyTo(array18, 0);
				BitConverter.GetBytes(22).CopyTo(array18, 4);
				return array18;
			}
			case MapType.STEF2:
			{
				byte[] array17 = new byte[8];
				BitConverter.GetBytes(556942917).CopyTo(array17, 0);
				BitConverter.GetBytes(20).CopyTo(array17, 4);
				return array17;
			}
			case MapType.STEF2Demo:
			{
				byte[] array16 = new byte[8];
				BitConverter.GetBytes(1263223110).CopyTo(array16, 0);
				BitConverter.GetBytes(19).CopyTo(array16, 4);
				return array16;
			}
			case MapType.MOHAA:
			{
				byte[] array15 = new byte[8];
				BitConverter.GetBytes(892416050).CopyTo(array15, 0);
				BitConverter.GetBytes(19).CopyTo(array15, 4);
				return array15;
			}
			case MapType.MOHAADemo:
			{
				byte[] array14 = new byte[8];
				BitConverter.GetBytes(892416050).CopyTo(array14, 0);
				BitConverter.GetBytes(18).CopyTo(array14, 4);
				return array14;
			}
			case MapType.MOHAABT:
			{
				byte[] array13 = new byte[8];
				BitConverter.GetBytes(1095516485).CopyTo(array13, 0);
				BitConverter.GetBytes(21).CopyTo(array13, 4);
				return array13;
			}
			case MapType.FAKK2:
			{
				byte[] array12 = new byte[8];
				BitConverter.GetBytes(1263223110).CopyTo(array12, 0);
				BitConverter.GetBytes(12).CopyTo(array12, 4);
				return array12;
			}
			case MapType.Alice:
			{
				byte[] array11 = new byte[8];
				BitConverter.GetBytes(1263223110).CopyTo(array11, 0);
				BitConverter.GetBytes(42).CopyTo(array11, 4);
				return array11;
			}
			case MapType.Nightfire:
				return BitConverter.GetBytes(42);
			case MapType.Source17:
			{
				byte[] array10 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array10, 0);
				BitConverter.GetBytes(17).CopyTo(array10, 4);
				return array10;
			}
			case MapType.Source18:
			{
				byte[] array9 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array9, 0);
				BitConverter.GetBytes(18).CopyTo(array9, 4);
				return array9;
			}
			case MapType.Source19:
			{
				byte[] array8 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array8, 0);
				BitConverter.GetBytes(19).CopyTo(array8, 4);
				return array8;
			}
			case MapType.Source20:
			case MapType.Vindictus:
			{
				byte[] array7 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array7, 0);
				BitConverter.GetBytes(20).CopyTo(array7, 4);
				return array7;
			}
			case MapType.DMoMaM:
			{
				byte[] array6 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array6, 0);
				BitConverter.GetBytes(262164).CopyTo(array6, 4);
				return array6;
			}
			case MapType.Source21:
			case MapType.L4D2:
			{
				byte[] array5 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array5, 0);
				BitConverter.GetBytes(21).CopyTo(array5, 4);
				return array5;
			}
			case MapType.Source22:
			{
				byte[] array4 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array4, 0);
				BitConverter.GetBytes(22).CopyTo(array4, 4);
				return array4;
			}
			case MapType.Source23:
			{
				byte[] array3 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array3, 0);
				BitConverter.GetBytes(23).CopyTo(array3, 4);
				return array3;
			}
			case MapType.Source27:
			{
				byte[] array2 = new byte[8];
				BitConverter.GetBytes(1347633750).CopyTo(array2, 0);
				BitConverter.GetBytes(27).CopyTo(array2, 4);
				return array2;
			}
			case MapType.Titanfall:
			{
				byte[] array = new byte[8];
				BitConverter.GetBytes(1347633778).CopyTo(array, 0);
				BitConverter.GetBytes(29).CopyTo(array, 4);
				return array;
			}
			default:
				return new byte[0];
			}
		}

		public static int GetLumpInfoLength(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source))
			{
				return 16;
			}
			return 8;
		}
	}
}
