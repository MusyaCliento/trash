using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace LibBSP
{
	[Serializable]
	public class MAPBrushSide
	{
		private static IFormatProvider _format = CultureInfo.CreateSpecificCulture("en-US");

		public Vector3[] vertices;

		public Plane plane;

		public string texture;

		public TextureInfo textureInfo;

		public string material;

		public float lgtScale;

		public float lgtRot;

		public MAPDisplacement displacement;

		public MAPBrushSide()
		{
		}

		public MAPBrushSide(string[] lines)
		{
			if (lines.Length == 1)
			{
				string[] array = lines[0].SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
				float result = 0f;
				if (float.TryParse(array[4], out result))
				{
					plane = new Plane(new Vector3(float.Parse(array[1], _format), float.Parse(array[2], _format), float.Parse(array[3], _format)), result);
					textureInfo = new TextureInfo(new Vector3(float.Parse(array[8], _format), float.Parse(array[9], _format), float.Parse(array[10], _format)), new Vector3(float.Parse(array[13], _format), float.Parse(array[14], _format), float.Parse(array[15], _format)), new Vector2(0f, 0f), new Vector2(1f, 1f), 0, 0, 0f);
					texture = array[18];
					return;
				}
				Vector3 vector = new Vector3(float.Parse(array[1], _format), float.Parse(array[2], _format), float.Parse(array[3], _format));
				Vector3 vector2 = new Vector3(float.Parse(array[6], _format), float.Parse(array[7], _format), float.Parse(array[8], _format));
				Vector3 vector3 = new Vector3(float.Parse(array[11], _format), float.Parse(array[12], _format), float.Parse(array[13], _format));
				vertices = new Vector3[3] { vector, vector2, vector3 };
				plane = PlaneExtensions.CreateFromVertices(vector, vector2, vector3);
				texture = array[15];
				if (array[16] == "[")
				{
					textureInfo = new TextureInfo(new Vector3(float.Parse(array[17], _format), float.Parse(array[18], _format), float.Parse(array[19], _format)), new Vector3(float.Parse(array[23], _format), float.Parse(array[24], _format), float.Parse(array[25], _format)), new Vector2(float.Parse(array[20], _format), float.Parse(array[26], _format)), new Vector2(float.Parse(array[29], _format), float.Parse(array[30], _format)), int.Parse(array[31]), 0, float.Parse(array[28], _format));
					material = array[32];
				}
				else
				{
					Vector3[] array2 = TextureInfo.TextureAxisFromPlane(plane);
					textureInfo = new TextureInfo(array2[0], array2[1], new Vector2(float.Parse(array[16], _format), float.Parse(array[17], _format)), new Vector2(float.Parse(array[19], _format), float.Parse(array[20], _format)), int.Parse(array[22]), 0, float.Parse(array[18], _format));
				}
				return;
			}
			bool flag = false;
			int num = 0;
			textureInfo = default(TextureInfo);
			List<string> list = new List<string>(37);
			foreach (string text in lines)
			{
				switch (text)
				{
				case "{":
					num++;
					break;
				case "}":
					num--;
					if (num == 1)
					{
						list.Add(text);
						displacement = new MAPDisplacement(list.ToArray());
						list = new List<string>(37);
						flag = false;
					}
					break;
				case "dispinfo":
					flag = true;
					continue;
				}
				if (num == 1)
				{
					string[] array3 = text.SplitUnlessInContainer(' ', '"', StringSplitOptions.RemoveEmptyEntries);
					switch (array3[0])
					{
					case "material":
						texture = array3[1];
						break;
					case "plane":
					{
						string[] array6 = array3[1].SplitUnlessBetweenDelimiters(' ', '(', ')', StringSplitOptions.RemoveEmptyEntries);
						string[] array7 = array6[0].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						Vector3 point = new Vector3(float.Parse(array7[0], _format), float.Parse(array7[1], _format), float.Parse(array7[2], _format));
						array7 = array6[1].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						Vector3 point2 = new Vector3(float.Parse(array7[0], _format), float.Parse(array7[1], _format), float.Parse(array7[2], _format));
						array7 = array6[2].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						Vector3 point3 = new Vector3(float.Parse(array7[0], _format), float.Parse(array7[1], _format), float.Parse(array7[2], _format));
						plane = PlaneExtensions.CreateFromVertices(point, point2, point3);
						break;
					}
					case "uaxis":
					{
						string[] array5 = array3[1].SplitUnlessBetweenDelimiters(' ', '[', ']', StringSplitOptions.RemoveEmptyEntries);
						textureInfo.scale = new Vector2(float.Parse(array5[1], _format), textureInfo.scale.Y());
						array5 = array5[0].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						textureInfo.UAxis = new Vector3(float.Parse(array5[0], _format), float.Parse(array5[1], _format), float.Parse(array5[2], _format));
						textureInfo.Translation = new Vector2(float.Parse(array5[3], _format), textureInfo.Translation.Y());
						break;
					}
					case "vaxis":
					{
						string[] array4 = array3[1].SplitUnlessBetweenDelimiters(' ', '[', ']', StringSplitOptions.RemoveEmptyEntries);
						textureInfo.scale = new Vector2(textureInfo.scale.X(), float.Parse(array4[1], _format));
						array4 = array4[0].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						textureInfo.VAxis = new Vector3(float.Parse(array4[0], _format), float.Parse(array4[1], _format), float.Parse(array4[2], _format));
						textureInfo.Translation = new Vector2(textureInfo.Translation.X(), float.Parse(array4[3], _format));
						break;
					}
					case "rotation":
						textureInfo.rotation = float.Parse(array3[1], _format);
						break;
					}
				}
				else if (num > 1 && flag)
				{
					list.Add(text);
				}
			}
		}
	}
}
