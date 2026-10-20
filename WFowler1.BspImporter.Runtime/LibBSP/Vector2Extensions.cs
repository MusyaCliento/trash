using System;
using UnityEngine;

namespace LibBSP
{
	public static class Vector2Extensions
	{
		public static float Dot(this Vector2 vector, Vector2 other)
		{
			return Vector2.Dot(vector, other);
		}

		public static float DistanceTo(this Vector2 vector, Vector2 other)
		{
			return Vector2.Distance(vector, other);
		}

		public static float DistanceSquaredTo(this Vector2 vector, Vector2 other)
		{
			return (vector - other).sqrMagnitude;
		}

		public static Vector2 GetNormalized(this Vector2 vector)
		{
			if (float.IsNaN(vector.X()) || float.IsNaN(vector.Y()) || (vector.X() == 0f && vector.Y() == 0f))
			{
				return new Vector2(0f, 0f);
			}
			return vector.normalized;
		}

		public static float Magnitude(this Vector2 vector)
		{
			return vector.magnitude;
		}

		public static float MagnitudeSquared(this Vector2 vector)
		{
			return vector.sqrMagnitude;
		}

		public static float TriangleAreaSquared(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
		{
			float num = vertex1.DistanceTo(vertex2);
			float num2 = vertex1.DistanceTo(vertex3);
			float num3 = vertex2.DistanceTo(vertex3);
			float num4 = (num + num2 + num3) / 2f;
			return num4 * (num4 - num) * (num4 - num2) * (num4 - num3);
		}

		public static float TriangleArea(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
		{
			return (float)Math.Sqrt(TriangleAreaSquared(vertex1, vertex2, vertex3));
		}

		public static byte[] GetBytes(this Vector2 vector)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(vector.X()).CopyTo(array, 0);
			BitConverter.GetBytes(vector.Y()).CopyTo(array, 4);
			return array;
		}

		public static Vector2 ToVector2(byte[] value, int startIndex = 0)
		{
			return new Vector2(BitConverter.ToSingle(value, startIndex), BitConverter.ToSingle(value, startIndex + 4));
		}

		public static float X(this Vector2 vector)
		{
			return vector.x;
		}

		public static float Y(this Vector2 vector)
		{
			return vector.y;
		}
	}
}
