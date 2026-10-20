using System;
using UnityEngine;

namespace LibBSP
{
	public static class Vector4Extensions
	{
		public static float Dot(this Vector4 vector, Vector4 other)
		{
			return Vector4.Dot(vector, other);
		}

		public static Vector4 GetNormalized(this Vector4 vector)
		{
			if (float.IsNaN(vector.X()) || float.IsNaN(vector.Y()) || float.IsNaN(vector.Z()) || float.IsNaN(vector.W()) || (vector.X() == 0f && vector.Y() == 0f && vector.Z() == 0f && vector.W() == 0f))
			{
				return new Vector4(0f, 0f, 0f, 0f);
			}
			return vector.normalized;
		}

		public static float DistanceTo(this Vector4 vector, Vector4 other)
		{
			return Vector4.Distance(vector, other);
		}

		public static float DistanceSquaredTo(this Vector4 vector, Vector4 other)
		{
			return (vector - other).sqrMagnitude;
		}

		public static float Magnitude(this Vector4 vector)
		{
			return vector.magnitude;
		}

		public static float MagnitudeSquared(this Vector4 vector)
		{
			return vector.sqrMagnitude;
		}

		public static float TriangleAreaSquared(Vector4 vertex1, Vector4 vertex2, Vector4 vertex3)
		{
			float num = vertex1.DistanceTo(vertex2);
			float num2 = vertex1.DistanceTo(vertex3);
			float num3 = vertex2.DistanceTo(vertex3);
			float num4 = (num + num2 + num3) / 2f;
			return num4 * (num4 - num) * (num4 - num2) * (num4 - num3);
		}

		public static float TriangleArea(Vector4 vertex1, Vector4 vertex2, Vector4 vertex3)
		{
			return (float)Math.Sqrt(TriangleAreaSquared(vertex1, vertex2, vertex3));
		}

		public static byte[] GetBytes(this Vector4 vector)
		{
			byte[] array = new byte[16];
			BitConverter.GetBytes(vector.X()).CopyTo(array, 0);
			BitConverter.GetBytes(vector.Y()).CopyTo(array, 4);
			BitConverter.GetBytes(vector.Z()).CopyTo(array, 8);
			BitConverter.GetBytes(vector.W()).CopyTo(array, 12);
			return array;
		}

		public static Vector4 ToVector4(byte[] value, int startIndex = 0)
		{
			return new Vector4(BitConverter.ToSingle(value, startIndex), BitConverter.ToSingle(value, startIndex + 4), BitConverter.ToSingle(value, startIndex + 8), BitConverter.ToSingle(value, startIndex + 12));
		}

		public static float X(this Vector4 vector)
		{
			return vector.x;
		}

		public static float Y(this Vector4 vector)
		{
			return vector.y;
		}

		public static float Z(this Vector4 vector)
		{
			return vector.z;
		}

		public static float W(this Vector4 vector)
		{
			return vector.w;
		}
	}
}
