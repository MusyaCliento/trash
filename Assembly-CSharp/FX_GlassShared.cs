using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "White Knuckle/Effects/Glass Shared")]
public class FX_GlassShared : ScriptableObject
{
	[Flags]
	public enum RegionFlags
	{
		IsOnEdge = 1
	}

	[Serializable]
	public class Region
	{
		public RegionFlags flags;

		public Vector2 centerPosition;

		public int shatterLinksBeg;

		public int shatterLinksEnd;
	}

	public Texture2D regionMap;

	public Region[] shatterRegions;

	public byte[] shatterLinks;

	private NativeArray<byte> shatterRegionMap;

	public void Initialize()
	{
		if (shatterRegionMap.Length == 0)
		{
			shatterRegionMap = ReadTextureAsBytes(regionMap);
		}
	}

	public int NormPosToRegion(Vector2 normPos)
	{
		Vector2 vector = new Vector2(normPos.x * (float)regionMap.width, normPos.y * (float)regionMap.height);
		return shatterRegionMap[(int)vector.x + regionMap.width * (int)vector.y];
	}

	public Span<byte> RegionNeighbors(int region)
	{
		Region region2 = shatterRegions[region];
		Span<byte> span = shatterLinks.AsSpan();
		int shatterLinksBeg = region2.shatterLinksBeg;
		return span.Slice(shatterLinksBeg, region2.shatterLinksEnd - shatterLinksBeg);
	}

	public void GenerateMask()
	{
		if (regionMap == null)
		{
			shatterRegions = new Region[0];
			shatterLinks = new byte[0];
			shatterRegionMap = default(NativeArray<byte>);
			return;
		}
		NativeArray<byte> nativeArray = ReadTextureAsBytes(regionMap);
		int num = 256;
		List<Region> list = new List<Region>(num);
		List<byte> list2 = new List<byte>();
		for (int i = 0; i < num; i++)
		{
			list.Add(new Region());
		}
		HashSet<byte>[] array = new HashSet<byte>[num];
		(Vector2, int)[] array2 = new(Vector2, int)[num];
		bool[] array3 = new bool[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = new HashSet<byte>();
		}
		for (int k = 1; k < regionMap.width; k++)
		{
			for (int l = 1; l < regionMap.height; l++)
			{
				int index = k + l * regionMap.width;
				byte b = nativeArray[index];
				for (int m = 1; m <= 3; m++)
				{
					int index2 = k - (m & 1) + (l - (m >> 1)) * regionMap.width;
					byte b2 = nativeArray[index2];
					if (b != b2)
					{
						array[b].Add(b2);
						array[b2].Add(b);
					}
				}
			}
		}
		for (int n = 0; n < regionMap.width; n++)
		{
			for (int num2 = 0; num2 < regionMap.height; num2++)
			{
				int index3 = n + num2 * regionMap.width;
				byte b3 = nativeArray[index3];
				if (n == 0 || num2 == 0 || n == regionMap.width - 1 || num2 == regionMap.height - 1)
				{
					array3[b3] = true;
				}
				var (vector, num3) = array2[b3];
				array2[b3] = (vector + new Vector2(n, num2), num3 + 1);
			}
		}
		for (int num4 = 0; num4 < array.Length; num4++)
		{
			int num5 = num4;
			HashSet<byte> hashSet = array[num5];
			(Vector2, int) tuple2 = array2[num5];
			Vector2 item = tuple2.Item1;
			int item2 = tuple2.Item2;
			Vector2 centerPosition = item / item2;
			centerPosition.x /= regionMap.width;
			centerPosition.y /= regionMap.height;
			Region region = new Region
			{
				centerPosition = centerPosition,
				shatterLinksBeg = list2.Count,
				shatterLinksEnd = list2.Count + hashSet.Count
			};
			if (array3[num5])
			{
				region.flags |= RegionFlags.IsOnEdge;
			}
			list[num5] = region;
			list2.AddRange(hashSet.OrderBy((byte result) => result));
		}
		shatterRegions = list.ToArray();
		shatterLinks = list2.ToArray();
		shatterRegionMap = nativeArray;
	}

	private static NativeArray<byte> ReadTextureAsBytes(Texture2D texture)
	{
		if (texture.format != TextureFormat.R8)
		{
			throw new Exception($"Unsupported shatter format {texture.format}. RGB24 is supported.");
		}
		return texture.GetPixelData<byte>(0);
	}
}
