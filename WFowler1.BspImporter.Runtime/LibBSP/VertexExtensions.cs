using System;
using UnityEngine;

namespace LibBSP
{
	public static class VertexExtensions
	{
		public static UIVertex Scale(UIVertex vertex, float scalar)
		{
			vertex.position *= scalar;
			return vertex;
		}

		public static UIVertex Add(UIVertex vertex1, UIVertex vertex2)
		{
			vertex1.position += vertex2.position;
			return vertex1;
		}

		public static UIVertex Translate(UIVertex vertex1, Vector3 vertex2)
		{
			vertex1.position += vertex2;
			return vertex1;
		}

		public static UIVertex CreateVertex(byte[] data, MapType type, int version = 0)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			UIVertex result = default(UIVertex);
			if (type == MapType.CoD2 || type == MapType.CoD4)
			{
				result.normal = Vector3Extensions.ToVector3(data, 12);
				result.color = ColorExtensions.FromArgb(data[27], data[24], data[25], data[26]);
				result.uv0 = Vector2Extensions.ToVector2(data, 28);
				result.uv1 = Vector2Extensions.ToVector2(data, 36);
				result.tangent = Vector4Extensions.ToVector4(data, 44);
				result.uv3 = Vector2Extensions.ToVector2(data, 60);
			}
			else if (type.IsSubtypeOf(MapType.STEF2))
			{
				result.uv0 = Vector2Extensions.ToVector2(data, 12);
				result.uv1 = Vector2Extensions.ToVector2(data, 20);
				result.uv2 = new Vector2(BitConverter.ToSingle(data, 28), 0f);
				result.color = ColorExtensions.FromArgb(data[35], data[32], data[33], data[34]);
				result.normal = Vector3Extensions.ToVector3(data, 36);
			}
			else if (type == MapType.Raven)
			{
				result.uv0 = Vector2Extensions.ToVector2(data, 12);
				result.uv1 = Vector2Extensions.ToVector2(data, 20);
				result.uv2 = Vector2Extensions.ToVector2(data, 28);
				result.uv3 = Vector2Extensions.ToVector2(data, 36);
				result.normal = Vector3Extensions.ToVector3(data, 52);
				result.color = ColorExtensions.FromArgb(data[67], data[64], data[65], data[66]);
				result.tangent = Vector4Extensions.ToVector4(data, 44);
			}
			else if (type.IsSubtypeOf(MapType.Quake3))
			{
				result.uv0 = Vector2Extensions.ToVector2(data, 12);
				result.uv1 = Vector2Extensions.ToVector2(data, 20);
				result.normal = Vector3Extensions.ToVector3(data, 28);
				result.color = ColorExtensions.FromArgb(data[43], data[40], data[41], data[42]);
			}
			result.position = Vector3Extensions.ToVector3(data);
			return result;
		}

		public static Lump<UIVertex> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			int structLength = GetStructLength(bsp.MapType, lumpInfo.version);
			int num = data.Length / structLength;
			Lump<UIVertex> lump = new Lump<UIVertex>(num, bsp, lumpInfo);
			byte[] array = new byte[structLength];
			for (int i = 0; i < num; i++)
			{
				Array.Copy(data, i * structLength, array, 0, structLength);
				lump.Add(CreateVertex(array, bsp.MapType, lumpInfo.version));
			}
			return lump;
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type.IsSubtypeOf(MapType.Quake2))
			{
				return 2;
			}
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Source) || type == MapType.Titanfall)
			{
				return 3;
			}
			if (type.IsSubtypeOf(MapType.MOHAA) || type.IsSubtypeOf(MapType.FAKK2) || type == MapType.Nightfire)
			{
				return 4;
			}
			if (type.IsSubtypeOf(MapType.STEF2))
			{
				return 6;
			}
			switch (type)
			{
			case MapType.CoD:
			case MapType.CoDDemo:
				return 7;
			case MapType.CoD2:
				return 8;
			default:
				if (type.IsSubtypeOf(MapType.Quake3))
				{
					return 10;
				}
				return -1;
			}
		}

		public static int GetStructLength(MapType type, int version)
		{
			if (!type.IsSubtypeOf(MapType.Quake) && !type.IsSubtypeOf(MapType.Quake2) && type != MapType.Nightfire && !type.IsSubtypeOf(MapType.Source))
			{
				switch (type)
				{
				case MapType.Titanfall:
					break;
				case MapType.CoD2:
				case MapType.CoD4:
					return 68;
				default:
					if (type.IsSubtypeOf(MapType.STEF2))
					{
						return 48;
					}
					if (type == MapType.Raven)
					{
						return 80;
					}
					if (type.IsSubtypeOf(MapType.Quake3))
					{
						return 44;
					}
					return -1;
				}
			}
			return 12;
		}

		public static byte[] GetBytes(this UIVertex v, MapType type, int version)
		{
			byte[] array = new byte[GetStructLength(type, version)];
			switch (type)
			{
			case MapType.CoD2:
			case MapType.CoD4:
				v.normal.GetBytes().CopyTo(array, 12);
				v.color.GetBytes().CopyTo(array, 24);
				v.uv0.GetBytes().CopyTo(array, 28);
				v.uv1.GetBytes().CopyTo(array, 36);
				v.tangent.GetBytes().CopyTo(array, 44);
				v.uv3.GetBytes().CopyTo(array, 60);
				break;
			case MapType.Raven:
				v.uv0.GetBytes().CopyTo(array, 12);
				v.uv1.GetBytes().CopyTo(array, 20);
				v.uv2.GetBytes().CopyTo(array, 28);
				v.uv3.GetBytes().CopyTo(array, 36);
				BitConverter.GetBytes(v.tangent.X()).CopyTo(array, 44);
				BitConverter.GetBytes(v.tangent.Y()).CopyTo(array, 48);
				v.normal.GetBytes().CopyTo(array, 52);
				v.color.GetBytes().CopyTo(array, 64);
				BitConverter.GetBytes(v.tangent.Z()).CopyTo(array, 68);
				BitConverter.GetBytes(v.tangent.W()).CopyTo(array, 72);
				array[76] = byte.MaxValue;
				array[77] = byte.MaxValue;
				array[78] = byte.MaxValue;
				array[79] = byte.MaxValue;
				break;
			default:
				if (type.IsSubtypeOf(MapType.STEF2))
				{
					v.uv0.GetBytes().CopyTo(array, 12);
					v.uv1.GetBytes().CopyTo(array, 20);
					BitConverter.GetBytes(v.uv2.X()).CopyTo(array, 28);
					v.color.GetBytes().CopyTo(array, 32);
					v.normal.GetBytes().CopyTo(array, 36);
				}
				else if (type.IsSubtypeOf(MapType.Quake3))
				{
					v.uv0.GetBytes().CopyTo(array, 12);
					v.uv1.GetBytes().CopyTo(array, 20);
					v.normal.GetBytes().CopyTo(array, 28);
					v.color.GetBytes().CopyTo(array, 40);
				}
				break;
			}
			v.position.GetBytes().CopyTo(array, 0);
			return array;
		}
	}
}
