using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class MAPDisplacement
	{
		private static IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public int power;

		public Vector3 start;

		public Vector3[,] normals;

		public float[,] distances;

		public float[,] alphas;

		public MAPDisplacement()
		{
		}

		public MAPDisplacement(string[] lines)
		{
			Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>(5);
			Dictionary<int, string[]> dictionary2 = new Dictionary<int, string[]>(5);
			Dictionary<int, string[]> dictionary3 = new Dictionary<int, string[]>(5);
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			foreach (string text in lines)
			{
				switch (text)
				{
				case "{":
					num++;
					continue;
				case "}":
					num--;
					if (num == 1)
					{
						flag = false;
						flag2 = false;
						flag3 = false;
					}
					continue;
				case "normals":
					flag = true;
					continue;
				case "distances":
					flag2 = true;
					continue;
				case "alphas":
					flag3 = true;
					continue;
				}
				if (num == 1)
				{
					string[] array = text.SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
					string text2 = array[0];
					if (!(text2 == "power"))
					{
						if (text2 == "startposition")
						{
							string[] array2 = array[1].Substring(1, array[1].Length - 2).Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							start = new Vector3(float.Parse(array2[0], _format), float.Parse(array2[1], _format), float.Parse(array2[2], _format));
						}
					}
					else
					{
						power = int.Parse(array[1]);
						int num2 = (int)Math.Pow(2.0, power) + 1;
						normals = new Vector3[num2, num2];
						distances = new float[num2, num2];
						alphas = new float[num2, num2];
					}
				}
				else if (num > 1)
				{
					if (flag)
					{
						string[] array3 = text.SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
						int key = int.Parse(array3[0].Substring(3));
						string[] value = array3[1].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						dictionary[key] = value;
					}
					else if (flag2)
					{
						string[] array4 = text.SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
						int key2 = int.Parse(array4[0].Substring(3));
						string[] value2 = array4[1].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						dictionary2[key2] = value2;
					}
					else if (flag3)
					{
						string[] array5 = text.SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
						int key3 = int.Parse(array5[0].Substring(3));
						string[] value3 = array5[1].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						dictionary3[key3] = value3;
					}
				}
			}
			if (power == 0)
			{
				throw new ArgumentException("Bad data given to MAPDisplacement, no power specified!");
			}
			if (start.X() == float.NaN)
			{
				throw new ArgumentException("Bad data given to MAPDisplacement, no starting point specified!");
			}
			foreach (int key4 in dictionary.Keys)
			{
				for (int j = 0; j < dictionary[key4].Length / 3; j++)
				{
					normals[key4, j] = new Vector3(float.Parse(dictionary[key4][j * 3], _format), float.Parse(dictionary[key4][j * 3 + 1], _format), float.Parse(dictionary[key4][j * 3 + 2], _format));
					distances[key4, j] = float.Parse(dictionary2[key4][j], _format);
					alphas[key4, j] = float.Parse(dictionary3[key4][j], _format);
				}
			}
		}
	}
}
