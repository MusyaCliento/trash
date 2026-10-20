namespace Pathfinding.Util
{
	internal class Checksum
	{
		public static uint GetChecksum(byte[] arr, uint hash = 0u)
		{
			hash ^= 0x811C9DC5u;
			if (arr == null)
			{
				return hash - 1;
			}
			for (int i = 0; i < arr.Length; i++)
			{
				hash = (hash ^ arr[i]) * 16777619;
			}
			return hash;
		}
	}
}
