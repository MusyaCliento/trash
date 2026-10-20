using System;

namespace LibBSP
{
	public class Visibility : ILump
	{
		public BSP Bsp { get; protected set; }

		public LumpInfo LumpInfo { get; protected set; }

		public byte[] Data { get; set; }

		public int Length => Data.Length;

		public int NumClusters
		{
			get
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.Quake2) || Bsp.MapType.IsSubtypeOf(MapType.Quake3) || Bsp.MapType.IsSubtypeOf(MapType.Source))
				{
					return BitConverter.ToInt32(Data, 0);
				}
				return -1;
			}
			set
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.Quake2) || Bsp.MapType.IsSubtypeOf(MapType.Quake3) || Bsp.MapType.IsSubtypeOf(MapType.Source))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 0);
				}
			}
		}

		public int ClusterSize
		{
			get
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.Quake3))
				{
					return BitConverter.ToInt32(Data, 4);
				}
				return -1;
			}
			set
			{
				if (Bsp.MapType.IsSubtypeOf(MapType.Quake3))
				{
					BitConverter.GetBytes(value).CopyTo(Data, 4);
				}
			}
		}

		public Visibility(byte[] data, BSP bsp, LumpInfo lumpInfo = default(LumpInfo))
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			Data = data;
			Bsp = bsp;
			LumpInfo = lumpInfo;
		}

		public bool CanSee(Leaf leaf, int other)
		{
			int num = GetOffsetForClusterPVS(leaf.Visibility);
			if (num < 0)
			{
				num = leaf.Visibility;
			}
			int num2 = 1;
			while (num2 < leaf.Parent.Bsp.Leaves.Count)
			{
				if (Data[num] == 0 && Bsp.MapType != MapType.Nightfire && !Bsp.MapType.IsSubtypeOf(MapType.Quake))
				{
					num2 += 8 * Data[num + 1];
					if (num2 > other)
					{
						return false;
					}
					num++;
				}
				else
				{
					int num3 = 1;
					while (num3 != 0)
					{
						if (other == num2)
						{
							return (Data[num] & num3) > 0;
						}
						num3 *= 2;
						num2++;
					}
				}
				num++;
			}
			return false;
		}

		public int GetOffsetForClusterPVS(int cluster)
		{
			if (Bsp.MapType.IsSubtypeOf(MapType.Quake2) || Bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				return BitConverter.ToInt32(Data, 4 + cluster * 8);
			}
			return -1;
		}

		public int GetOffsetForClusterPAS(int cluster)
		{
			if (Bsp.MapType.IsSubtypeOf(MapType.Quake2) || Bsp.MapType.IsSubtypeOf(MapType.Source))
			{
				return BitConverter.ToInt32(Data, 8 + cluster * 8);
			}
			return -1;
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 3;
			}
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source))
			{
				return 4;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 17;
			}
			if (type == MapType.MOHAADemo)
			{
				return 16;
			}
			if (type.IsSubtypeOf(MapType.FAKK2) || type.IsSubtypeOf(MapType.MOHAA))
			{
				return 15;
			}
			switch (type)
			{
			case MapType.CoD:
			case MapType.CoDDemo:
				return 28;
			case MapType.CoD2:
				return 36;
			case MapType.Nightfire:
				return 7;
			default:
				if (type.IsSubtypeOf(MapType.Quake3) && type != MapType.CoD4)
				{
					return 16;
				}
				return -1;
			}
		}

		public byte[] GetBytes()
		{
			return Data;
		}
	}
}
