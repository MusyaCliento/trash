using UnityEngine;

namespace LibBSP
{
	public static class ColorExtensions
	{
		public static Color32 FromArgb(int a, int r, int g, int b)
		{
			return new Color32((byte)r, (byte)g, (byte)b, (byte)a);
		}

		public static byte[] GetBytes(this Color32 color)
		{
			return new byte[4] { color.r, color.g, color.b, color.a };
		}

		public static byte A(this Color32 color)
		{
			return color.a;
		}

		public static byte R(this Color32 color)
		{
			return color.r;
		}

		public static byte G(this Color32 color)
		{
			return color.g;
		}

		public static byte B(this Color32 color)
		{
			return color.b;
		}
	}
}
