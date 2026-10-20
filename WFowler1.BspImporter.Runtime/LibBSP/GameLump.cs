using System;
using System.Collections.Generic;

namespace LibBSP
{
	public class GameLump : Dictionary<GameLumpType, LumpInfo>, ILump
	{
		private Dictionary<GameLumpType, ILump> _lumps;

		public BSP Bsp { get; protected set; }

		public LumpInfo LumpInfo { get; protected set; }

		public int Length
		{
			get
			{
				if (base.Count == 0)
				{
					return 4;
				}
				int num = ((Bsp.MapType == MapType.DMoMaM || Bsp.MapType == MapType.Vindictus) ? 20 : 16);
				int num2 = ((Bsp.MapType == MapType.DMoMaM) ? 8 : 4) + num * base.Count;
				foreach (GameLumpType key in base.Keys)
				{
					num2 = ((!_lumps.ContainsKey(key)) ? (num2 + base[key].length) : (num2 + _lumps[key].Length));
				}
				return num2;
			}
		}

		public StaticProps StaticProps
		{
			get
			{
				GameLumpType key = GameLumpType.prps;
				if (ContainsKey(key))
				{
					if (!_lumps.ContainsKey(key))
					{
						_lumps.Add(key, StaticProp.LumpFactory(ReadLump(base[key]), Bsp, base[key]));
					}
					return (StaticProps)_lumps[key];
				}
				return null;
			}
			set
			{
				_lumps[GameLumpType.prps] = value;
			}
		}

		public bool StaticPropsLoaded => LumpLoaded(GameLumpType.prps);

		public Dictionary<GameLumpType, ILump> Lumps => _lumps;

		public GameLump(byte[] data, BSP bsp, LumpInfo lumpInfo = default(LumpInfo))
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Bsp = bsp;
			LumpInfo = lumpInfo;
			int num = 0;
			if (bsp.MapType == MapType.DMoMaM || bsp.MapType == MapType.Vindictus)
			{
				num = 20;
			}
			else
			{
				if (!bsp.MapType.IsSubtypeOf(MapType.Source) && bsp.MapType != MapType.Titanfall)
				{
					throw new ArgumentException("Game lump does not exist in map type " + bsp.MapType.ToString() + " or has not been implemented.");
				}
				num = 16;
			}
			int num2 = BitConverter.ToInt32(data, 0);
			_lumps = new Dictionary<GameLumpType, ILump>(num2);
			if (num2 <= 0)
			{
				return;
			}
			int num3 = ((bsp.MapType == MapType.DMoMaM) ? 8 : 4);
			int num4 = int.MaxValue;
			for (int i = 0; i < num2; i++)
			{
				int ident = BitConverter.ToInt32(data, i * num + num3);
				int flags;
				int version;
				int offset;
				int length;
				if (bsp.MapType == MapType.Vindictus)
				{
					flags = BitConverter.ToInt32(data, i * num + num3 + 4);
					version = BitConverter.ToInt32(data, i * num + num3 + 8);
					offset = BitConverter.ToInt32(data, i * num + num3 + 12);
					length = BitConverter.ToInt32(data, i * num + num3 + 16);
				}
				else
				{
					flags = BitConverter.ToUInt16(data, i * num + num3 + 4);
					version = BitConverter.ToUInt16(data, i * num + num3 + 6);
					offset = BitConverter.ToInt32(data, i * num + num3 + 8);
					length = BitConverter.ToInt32(data, i * num + num3 + 12);
				}
				LumpInfo value = new LumpInfo
				{
					ident = ident,
					flags = flags,
					version = version,
					offset = offset,
					length = length,
					lumpFile = lumpInfo.lumpFile
				};
				base[(GameLumpType)value.ident] = value;
				if (value.offset < num4)
				{
					num4 = value.offset;
				}
			}
		}

		public static GameLump LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			return new GameLump(data, bsp, lumpInfo);
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Source) || type == MapType.Titanfall)
			{
				return 35;
			}
			return -1;
		}

		public int GetLowestLumpOffset()
		{
			int num = int.MaxValue;
			foreach (LumpInfo value in base.Values)
			{
				if (value.offset < num)
				{
					num = value.offset;
				}
			}
			return num;
		}

		public byte[] ReadLump(LumpInfo info)
		{
			GameLumpType ident = (GameLumpType)info.ident;
			if (ContainsKey(ident))
			{
				if (GetLowestLumpOffset() < LumpInfo.offset)
				{
					return Bsp.Reader.ReadLump(new LumpInfo
					{
						ident = info.ident,
						flags = info.flags,
						version = info.version,
						offset = info.offset + LumpInfo.offset,
						length = info.length
					});
				}
				return Bsp.Reader.ReadLump(info);
			}
			return null;
		}

		public bool LumpLoaded(GameLumpType type)
		{
			if (_lumps != null)
			{
				return _lumps.ContainsKey(type);
			}
			return false;
		}

		public ILump GetLoadedLump(GameLumpType type)
		{
			if (!LumpLoaded(type))
			{
				return null;
			}
			return _lumps[type];
		}

		public byte[] GetBytes()
		{
			if (base.Count == 0)
			{
				return new byte[4];
			}
			int num = ((Bsp.MapType == MapType.DMoMaM || Bsp.MapType == MapType.Vindictus) ? 20 : 16);
			int num2 = ((Bsp.MapType == MapType.DMoMaM) ? 8 : 4);
			int num3 = num2 + num * base.Count;
			Dictionary<GameLumpType, byte[]> dictionary = new Dictionary<GameLumpType, byte[]>(base.Count);
			foreach (GameLumpType key in base.Keys)
			{
				if (_lumps.ContainsKey(key))
				{
					dictionary[key] = _lumps[key].GetBytes();
				}
				else
				{
					dictionary[key] = ReadLump(base[key]);
				}
				num3 += dictionary[key].Length;
			}
			byte[] array = new byte[num3];
			BitConverter.GetBytes(dictionary.Count).CopyTo(array, 0);
			int num4 = 0;
			int num5 = num2 + dictionary.Count * num;
			int num6 = ((Bsp.MapType == MapType.DMoMaM || Bsp.MapType == MapType.Vindictus) ? 20 : 16);
			foreach (KeyValuePair<GameLumpType, byte[]> item in dictionary)
			{
				LumpInfo value = base[item.Key];
				value.length = item.Value.Length;
				value.offset = num5;
				if (num5 < num3)
				{
					value.offset += LumpInfo.offset;
				}
				base[item.Key] = value;
				BitConverter.GetBytes(value.ident).CopyTo(array, num4 * num6 + num2);
				if (Bsp.MapType == MapType.Vindictus)
				{
					BitConverter.GetBytes(value.flags).CopyTo(array, num4 * num6 + num2 + 4);
					BitConverter.GetBytes(value.version).CopyTo(array, num4 * num6 + num2 + 8);
					BitConverter.GetBytes(value.offset).CopyTo(array, num4 * num6 + num2 + 12);
					BitConverter.GetBytes(value.length).CopyTo(array, num4 * num6 + num2 + 16);
				}
				else
				{
					BitConverter.GetBytes((short)value.flags).CopyTo(array, num4 * num6 + num2 + 4);
					BitConverter.GetBytes((short)value.version).CopyTo(array, num4 * num6 + num2 + 6);
					BitConverter.GetBytes(value.offset).CopyTo(array, num4 * num6 + num2 + 8);
					BitConverter.GetBytes(value.length).CopyTo(array, num4 * num6 + num2 + 12);
				}
				dictionary[item.Key].CopyTo(array, num5);
				num5 += dictionary[item.Key].Length;
				num4++;
			}
			return array;
		}
	}
}
