using System;
using UnityEngine;

namespace LibBSP
{
	public static class Vector3Extensions
	{
		public static float Dot(this Vector3 vector, Vector3 other)
		{
			return Vector3.Dot(vector, other);
		}

		public static Vector3 Cross(this Vector3 left, Vector3 right)
		{
			return Vector3.Cross(left, right);
		}

		public static float DistanceTo(this Vector3 vector, Vector3 other)
		{
			return Vector3.Distance(vector, other);
		}

		public static float DistanceSquaredTo(this Vector3 vector, Vector3 other)
		{
			return (vector - other).sqrMagnitude;
		}

		public static Vector3 GetNormalized(this Vector3 vector)
		{
			if (float.IsNaN(vector.X()) || float.IsNaN(vector.Y()) || float.IsNaN(vector.Z()) || (vector.X() == 0f && vector.Y() == 0f && vector.Z() == 0f))
			{
				return new Vector3(0f, 0f, 0f);
			}
			return vector.normalized;
		}

		public static float Magnitude(this Vector3 vector)
		{
			return vector.magnitude;
		}

		public static float MagnitudeSquared(this Vector3 vector)
		{
			return vector.sqrMagnitude;
		}

		public static float TriangleAreaSquared(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
		{
			float num = vertex1.DistanceTo(vertex2);
			float num2 = vertex1.DistanceTo(vertex3);
			float num3 = vertex2.DistanceTo(vertex3);
			float num4 = (num + num2 + num3) / 2f;
			return num4 * (num4 - num) * (num4 - num2) * (num4 - num3);
		}

		public static float TriangleArea(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
		{
			return (float)Math.Sqrt(TriangleAreaSquared(vertex1, vertex2, vertex3));
		}

		public static byte[] GetBytes(this Vector3 vector)
		{
			byte[] array = new byte[12];
			BitConverter.GetBytes(vector.X()).CopyTo(array, 0);
			BitConverter.GetBytes(vector.Y()).CopyTo(array, 4);
			BitConverter.GetBytes(vector.Z()).CopyTo(array, 8);
			return array;
		}

		public static Vector3 ToVector3(byte[] value, int startIndex = 0)
		{
			return new Vector3(BitConverter.ToSingle(value, startIndex), BitConverter.ToSingle(value, startIndex + 4), BitConverter.ToSingle(value, startIndex + 8));
		}

		public static float X(this Vector3 vector)
		{
			return vector.x;
		}

		public static float Y(this Vector3 vector)
		{
			return vector.y;
		}

		public static float Z(this Vector3 vector)
		{
			return vector.z;
		}

		public static Lump<Vector3> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			int structLength = GetStructLength(bsp.MapType, lumpInfo.version);
			int num = data.Length / structLength;
			Lump<Vector3> lump = new Lump<Vector3>(num, bsp, lumpInfo);
			for (int i = 0; i < num; i++)
			{
				lump.Add(ToVector3(data, i * structLength));
			}
			return lump;
		}

		public static int GetIndexForNormalsLump(MapType type)
		{
			if (type == MapType.Nightfire)
			{
				return 5;
			}
			return -1;
		}

		public static int GetIndexForPatchVertsLump(MapType type)
		{
			if (type == MapType.CoD || type == MapType.CoDDemo)
			{
				return 25;
			}
			return -1;
		}

		public static int GetStructLength(MapType type, int version)
		{
			return 12;
		}
	}
}
