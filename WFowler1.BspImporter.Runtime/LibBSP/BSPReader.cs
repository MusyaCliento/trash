using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibBSP
{
	public class BSPReader
	{
		private const string entityPattern = "\"classname\"";

		private Dictionary<int, LumpInfo> lumpFiles;

		private byte[] key = new byte[0];

		public FileInfo BspFile { get; set; }

		public BSPReader()
		{
		}

		public BSPReader(FileInfo file)
		{
			if (!File.Exists(file.FullName))
			{
				throw new FileNotFoundException("Unable to open BSP file: File " + file.FullName + " was not found.");
			}
			BspFile = file;
		}

		public byte[] GetHeader(MapType mapType)
		{
			if (BspFile == null)
			{
				return null;
			}
			if (mapType == MapType.CoD4)
			{
				int lumpInfoLength = BSPHeader.GetLumpInfoLength(mapType);
				int num = BSPHeader.GetMagic(mapType).Length;
				using FileStream fileStream = new FileStream(BspFile.FullName, FileMode.Open, FileAccess.Read);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Seek(num, SeekOrigin.Begin);
				int num2 = binaryReader.ReadInt32();
				int count = num + 4 + lumpInfoLength * num2;
				fileStream.Seek(0L, SeekOrigin.Begin);
				byte[] result = binaryReader.ReadBytes(count);
				binaryReader.Close();
				return result;
			}
			int lumpInfoLength2 = BSPHeader.GetLumpInfoLength(mapType);
			int numLumps = BSP.GetNumLumps(mapType);
			int num3 = BSPHeader.GetMagic(mapType).Length + lumpInfoLength2 * numLumps;
			if (mapType.IsSubtypeOf(MapType.UberTools))
			{
				num3 += 4;
			}
			byte[] array;
			using (FileStream fileStream2 = new FileStream(BspFile.FullName, FileMode.Open, FileAccess.Read))
			{
				BinaryReader binaryReader2 = new BinaryReader(fileStream2);
				fileStream2.Seek(0L, SeekOrigin.Begin);
				array = binaryReader2.ReadBytes(num3);
				binaryReader2.Close();
			}
			if (mapType == MapType.TacticalInterventionEncrypted)
			{
				array = XorWithKeyStartingAtIndex(array);
			}
			return array;
		}

		public byte[] ReadLump(LumpInfo info)
		{
			if (info.length == 0)
			{
				return new byte[0];
			}
			byte[] array = ((info.lumpFile == null) ? ReadLump(info.offset, info.length) : ReadLump(info.offset, info.length, info.lumpFile.FullName));
			if (key.Length != 0)
			{
				array = XorWithKeyStartingAtIndex(array, info.offset);
			}
			return array;
		}

		public byte[] ReadLump(int offset, int length, string fileName = null)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				if (BspFile == null)
				{
					return null;
				}
				fileName = BspFile.FullName;
			}
			using FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			fileStream.Seek(offset, SeekOrigin.Begin);
			byte[] result = binaryReader.ReadBytes(length);
			binaryReader.Close();
			return result;
		}

		private void LoadLumpFiles()
		{
			lumpFiles = new Dictionary<int, LumpInfo>();
			if (BspFile == null)
			{
				return;
			}
			List<FileInfo> list = BspFile.Directory.GetFiles(BspFile.Name.Substring(0, BspFile.Name.Length - 4) + "_?_*.lmp").ToList();
			list.Sort(delegate(FileInfo f1, FileInfo f2)
			{
				int num2 = BspFile.Name.Length - 1;
				int num3 = f1.Name.LastIndexOf('.');
				int num4 = f2.Name.LastIndexOf('.');
				int num5 = int.Parse(f1.Name.Substring(num2, num3 - num2));
				int num6 = int.Parse(f2.Name.Substring(num2, num4 - num2));
				return num5 - num6;
			});
			foreach (FileInfo item in list)
			{
				using FileStream fileStream = new FileStream(item.FullName, FileMode.Open, FileAccess.Read);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Seek(0L, SeekOrigin.Begin);
				byte[] value = binaryReader.ReadBytes(20);
				int offset = BitConverter.ToInt32(value, 0);
				int num = BitConverter.ToInt32(value, 4);
				int version = BitConverter.ToInt32(value, 8);
				int length = BitConverter.ToInt32(value, 12);
				lumpFiles[num] = new LumpInfo
				{
					offset = offset,
					version = version,
					length = length,
					lumpFile = item
				};
				binaryReader.Close();
			}
		}

		public LumpInfo GetLumpFileLumpInfo(int index)
		{
			if (lumpFiles == null)
			{
				LoadLumpFiles();
			}
			if (lumpFiles.ContainsKey(index))
			{
				return lumpFiles[index];
			}
			return default(LumpInfo);
		}

		private byte[] XorWithKeyStartingAtIndex(byte[] data, int index = 0)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			if (key.Length == 0 || data.Length == 0)
			{
				return data;
			}
			byte[] array = new byte[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = (byte)(data[i] ^ key[(i + index) % key.Length]);
			}
			return array;
		}

		public MapType GetVersion()
		{
			return GetVersion(bigEndian: false);
		}

		private MapType GetVersion(bool bigEndian)
		{
			MapType result = MapType.Undefined;
			if (BspFile != null)
			{
				using FileStream fileStream = new FileStream(BspFile.FullName, FileMode.Open, FileAccess.Read);
				if (fileStream.Length < 4)
				{
					return result;
				}
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Seek(0L, SeekOrigin.Begin);
				int num = binaryReader.ReadInt32();
				if (bigEndian)
				{
					byte[] bytes = BitConverter.GetBytes(num);
					Array.Reverse(bytes);
					num = BitConverter.ToInt32(bytes, 0);
				}
				switch (num)
				{
				case 1347633737:
				{
					int num3 = binaryReader.ReadInt32();
					if (bigEndian)
					{
						byte[] bytes3 = BitConverter.GetBytes(num3);
						Array.Reverse(bytes3);
						num3 = BitConverter.ToInt32(bytes3, 0);
					}
					switch (num3)
					{
					case 4:
						result = MapType.CoD2;
						break;
					case 22:
						result = MapType.CoD4;
						break;
					case 38:
						result = MapType.Quake2;
						break;
					case 41:
						result = MapType.Daikatana;
						break;
					case 46:
					{
						result = MapType.Quake3;
						for (int j = 0; j < 17; j++)
						{
							fileStream.Seek((j + 1) * 8, SeekOrigin.Begin);
							int num4 = binaryReader.ReadInt32();
							if (bigEndian)
							{
								byte[] bytes4 = BitConverter.GetBytes(num4);
								Array.Reverse(bytes4);
								num4 = BitConverter.ToInt32(bytes4, 0);
							}
							switch (num4)
							{
							case 184:
								result = MapType.SoF;
								break;
							default:
								continue;
							case 144:
								break;
							}
							break;
						}
						break;
					}
					case 47:
						result = MapType.ET;
						break;
					case 58:
						result = MapType.CoDDemo;
						break;
					case 59:
						result = MapType.CoD;
						break;
					}
					break;
				}
				case 892416050:
					result = ((binaryReader.ReadInt32() != 18) ? MapType.MOHAA : MapType.MOHAADemo);
					break;
				case 1095516485:
					result = MapType.MOHAABT;
					break;
				case 1347633750:
					switch ((int)binaryReader.ReadUInt16())
					{
					case 17:
						result = MapType.Source17;
						break;
					case 18:
						result = MapType.Source18;
						break;
					case 19:
						result = MapType.Source19;
						break;
					case 20:
					{
						if (binaryReader.ReadUInt16() == 4)
						{
							result = MapType.DMoMaM;
							break;
						}
						result = MapType.Source20;
						fileStream.Seek(568L, SeekOrigin.Begin);
						int num9 = binaryReader.ReadInt32();
						fileStream.Seek(num9, SeekOrigin.Begin);
						int num10 = binaryReader.ReadInt32();
						if (num10 > 0)
						{
							fileStream.Seek(num9 + 12, SeekOrigin.Begin);
							int num11 = binaryReader.ReadInt32();
							if (num10 > 0 && num11 < 24)
							{
								result = MapType.Vindictus;
							}
						}
						break;
					}
					case 21:
					{
						result = MapType.Source21;
						fileStream.Seek(8L, SeekOrigin.Begin);
						int num8 = binaryReader.ReadInt32();
						if (bigEndian)
						{
							byte[] bytes5 = BitConverter.GetBytes(num8);
							Array.Reverse(bytes5);
							num8 = BitConverter.ToInt32(bytes5, 0);
						}
						if (num8 < 1032)
						{
							result = MapType.L4D2;
						}
						break;
					}
					case 22:
						result = MapType.Source22;
						break;
					case 23:
						result = MapType.Source23;
						break;
					case 27:
						result = MapType.Source27;
						break;
					}
					break;
				case 1347633746:
				{
					result = MapType.Raven;
					for (int i = 0; i < 17; i++)
					{
						fileStream.Seek((i + 1) * 8, SeekOrigin.Begin);
						int num2 = binaryReader.ReadInt32();
						if (bigEndian)
						{
							byte[] bytes2 = BitConverter.GetBytes(num2);
							Array.Reverse(bytes2);
							num2 = BitConverter.ToInt32(bytes2, 0);
						}
						switch (num2)
						{
						case 168:
							result = MapType.SiN;
							break;
						default:
							continue;
						case 152:
							break;
						}
						break;
					}
					break;
				}
				case 556942917:
					result = MapType.STEF2;
					break;
				case 1347633778:
					result = MapType.Titanfall;
					break;
				case 1263223110:
				{
					int num12 = binaryReader.ReadInt32();
					if (bigEndian)
					{
						byte[] bytes6 = BitConverter.GetBytes(num12);
						Array.Reverse(bytes6);
						num12 = BitConverter.ToInt32(bytes6, 0);
					}
					switch (num12)
					{
					case 12:
						result = MapType.FAKK2;
						break;
					case 19:
						result = MapType.STEF2Demo;
						break;
					case 42:
						result = MapType.Alice;
						break;
					}
					break;
				}
				case 29:
					result = MapType.Quake;
					break;
				case 30:
				{
					result = MapType.BlueShift;
					fileStream.Seek(4L, SeekOrigin.Begin);
					int num5 = binaryReader.ReadInt32();
					int num6 = binaryReader.ReadInt32();
					fileStream.Seek(num5, SeekOrigin.Begin);
					int num7 = 0;
					for (int k = 0; k < num6 - "\"classname\"".Length; k++)
					{
						if ((ushort)fileStream.ReadByte() == "\"classname\""[num7])
						{
							num7++;
							if (num7 == "\"classname\"".Length)
							{
								result = MapType.GoldSrc;
								break;
							}
						}
						else
						{
							num7 = 0;
						}
					}
					break;
				}
				case 42:
					result = MapType.Nightfire;
					break;
				default:
					fileStream.Seek(384L, SeekOrigin.Begin);
					key = binaryReader.ReadBytes(32);
					fileStream.Seek(0L, SeekOrigin.Begin);
					result = ((BitConverter.ToInt32(XorWithKeyStartingAtIndex(binaryReader.ReadBytes(4)), 0) == 1347633750) ? MapType.TacticalInterventionEncrypted : MapType.Undefined);
					break;
				}
				binaryReader.Close();
			}
			return result;
		}
	}
}
