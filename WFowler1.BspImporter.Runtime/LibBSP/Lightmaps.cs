using System;

namespace LibBSP
{
	public class Lightmaps : ILump
	{
		public BSP Bsp { get; protected set; }

		public LumpInfo LumpInfo { get; protected set; }

		public byte[] Data { get; set; }

		public int Length => Data.Length;

		public Lightmaps(byte[] data, BSP bsp, LumpInfo lumpInfo = default(LumpInfo))
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Bsp = bsp;
			LumpInfo = lumpInfo;
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.CoD))
			{
				return 1;
			}
			if (type.IsSubtypeOf(MapType.UberTools))
			{
				return 2;
			}
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 7;
			}
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source))
			{
				return 8;
			}
			if (type == MapType.Nightfire)
			{
				return 10;
			}
			if (type.IsSubtypeOf(MapType.Quake3))
			{
				return 14;
			}
			return -1;
		}

		public byte[] GetBytes()
		{
			return Data;
		}
	}
}
