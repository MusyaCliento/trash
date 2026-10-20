using System;
using UnityEngine;

namespace Paloma
{
	internal static class Utilities
	{
		internal static int GetBits(byte b, int offset, int count)
		{
			return (b >> offset) & ((1 << count) - 1);
		}

		internal static Color GetColorFrom2Bytes(byte one, byte two)
		{
			byte r = Convert.ToByte(GetBits(one, 2, 5) << 3);
			int num = GetBits(one, 0, 2) << 6;
			int num2 = GetBits(two, 5, 3) << 3;
			byte g = Convert.ToByte(num + num2);
			byte b = Convert.ToByte(GetBits(two, 0, 5) << 3);
			byte a = Convert.ToByte(GetBits(one, 7, 1) * 255);
			return new Color32(r, g, b, a);
		}

		internal static string GetIntBinaryString(int n)
		{
			char[] array = new char[32];
			int num = 31;
			for (int i = 0; i < 32; i++)
			{
				if ((n & (1 << i)) != 0)
				{
					array[num] = '1';
				}
				else
				{
					array[num] = '0';
				}
				num--;
			}
			return new string(array);
		}

		internal static string GetInt16BinaryString(short n)
		{
			char[] array = new char[16];
			int num = 15;
			for (int i = 0; i < 16; i++)
			{
				if ((n & (1 << i)) != 0)
				{
					array[num] = '1';
				}
				else
				{
					array[num] = '0';
				}
				num--;
			}
			return new string(array);
		}
	}
}
