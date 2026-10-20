using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class MAPPatch
	{
		private static IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public UIVertex[] points;

		public Vector2 dims;

		public string texture;

		public MAPPatch()
		{
		}

		public MAPPatch(string[] lines)
		{
			texture = lines[2];
			List<UIVertex> list = new List<UIVertex>(9);
			switch (lines[0])
			{
			case "patchDef3":
			case "patchDef2":
			{
				string[] array2 = lines[3].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				dims = new Vector2(float.Parse(array2[1], _format), float.Parse(array2[2], _format));
				for (int k = 0; (float)k < dims.X(); k++)
				{
					array2 = lines[k + 5].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					for (int l = 0; (float)l < dims.Y(); l++)
					{
						Vector3 position2 = new Vector3(float.Parse(array2[2 + l * 7], _format), float.Parse(array2[3 + l * 7], _format), float.Parse(array2[4 + l * 7], _format));
						Vector2 vector2 = new Vector2(float.Parse(array2[5 + l * 7], _format), float.Parse(array2[6 + l * 7], _format));
						UIVertex item2 = new UIVertex
						{
							position = position2,
							uv0 = vector2,
							color = ColorExtensions.FromArgb(255, 255, 255, 255)
						};
						list.Add(item2);
					}
				}
				break;
			}
			case "patchTerrainDef3":
			{
				string[] array = lines[3].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				dims = new Vector2(float.Parse(array[1], _format), float.Parse(array[2], _format));
				for (int i = 0; (float)i < dims.X(); i++)
				{
					array = lines[i + 5].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					for (int j = 0; (float)j < dims.Y(); j++)
					{
						Vector3 position = new Vector3(float.Parse(array[2 + j * 12], _format), float.Parse(array[3 + j * 12], _format), float.Parse(array[4 + j * 12], _format));
						Vector2 vector = new Vector2(float.Parse(array[5 + j * 12], _format), float.Parse(array[6 + j * 12], _format));
						Color32 color = ColorExtensions.FromArgb(byte.Parse(array[7 + j * 12]), byte.Parse(array[8 + j * 12]), byte.Parse(array[9 + j * 12]), byte.Parse(array[10 + j * 12]));
						UIVertex item = new UIVertex
						{
							position = position,
							uv0 = vector,
							color = color
						};
						list.Add(item);
					}
				}
				break;
			}
			default:
				throw new ArgumentException($"Unknown patch type {lines[0]}! Call a scientist! ");
			}
		}
	}
}
