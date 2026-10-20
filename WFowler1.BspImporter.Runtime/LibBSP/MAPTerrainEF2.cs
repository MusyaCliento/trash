using System;
using System.Globalization;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class MAPTerrainEF2
	{
		private static IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public int side;

		public string texture;

		public float textureShiftS;

		public float textureShiftT;

		public float texRot;

		public float texScaleX;

		public float texScaleY;

		public int flags;

		public float sideLength;

		public Vector3 start;

		public Vector4 IF;

		public Vector4 LF;

		public float[,] heightMap;

		public float[,] alphaMap;

		public MAPTerrainEF2()
		{
		}

		public MAPTerrainEF2(string[] lines)
		{
			texture = lines[2];
			if (lines[0] == "terrainDef")
			{
				for (int i = 2; i < lines.Length; i++)
				{
					string[] array = lines[i].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					switch (array[0])
					{
					case "TEX(":
						texture = array[1];
						textureShiftS = float.Parse(array[2], _format);
						textureShiftT = float.Parse(array[3], _format);
						texRot = float.Parse(array[4], _format);
						texScaleX = float.Parse(array[5], _format);
						texScaleY = float.Parse(array[6], _format);
						flags = int.Parse(array[8]);
						break;
					case "TD(":
						sideLength = int.Parse(array[1], _format);
						start = new Vector3(float.Parse(array[2], _format), float.Parse(array[3], _format), float.Parse(array[4], _format));
						break;
					case "IF(":
						IF = new Vector4(float.Parse(array[1], _format), float.Parse(array[2], _format), float.Parse(array[3], _format), float.Parse(array[4], _format));
						break;
					case "LF(":
						LF = new Vector4(float.Parse(array[1], _format), float.Parse(array[2], _format), float.Parse(array[3], _format), float.Parse(array[4], _format));
						break;
					case "V(":
					{
						i++;
						array = lines[i].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						if (side == 0)
						{
							side = array.Length;
						}
						heightMap = new float[side, side];
						for (int l = 0; l < side; l++)
						{
							for (int m = 0; m < side; m++)
							{
								heightMap[l, m] = float.Parse(array[m], _format);
							}
							i++;
							array = lines[i].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						}
						break;
					}
					case "A(":
					{
						i++;
						array = lines[i].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						if (side == 0)
						{
							side = array.Length;
						}
						alphaMap = new float[side, side];
						for (int j = 0; j < side; j++)
						{
							for (int k = 0; k < side; k++)
							{
								alphaMap[j, k] = float.Parse(array[k], _format);
							}
							i++;
							array = lines[i].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						}
						break;
					}
					}
				}
				return;
			}
			throw new ArgumentException($"Unknown terrain type {lines[0]}!");
		}
	}
}
