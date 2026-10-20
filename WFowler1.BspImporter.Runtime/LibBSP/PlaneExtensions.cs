using System;
using UnityEngine;

namespace LibBSP
{
	public static class PlaneExtensions
	{
		public static readonly Vector3[] baseAxes = new Vector3[18]
		{
			new Vector3(0f, 0f, 1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 1f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, -1f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 0f, -1f)
		};

		public static Vector3 Normal(this Plane plane)
		{
			return plane.normal;
		}

		public static float Distance(this Plane plane)
		{
			return plane.distance;
		}

		public static Vector3 Intersect3(Plane plane1, Plane plane2, Plane plane3)
		{
			float num = plane1.Normal().Cross(plane2.Normal()).Dot(plane3.Normal());
			if (num == 0f)
			{
				return new Vector3(float.NaN, float.NaN, float.NaN);
			}
			return (plane2.Normal().Cross(plane3.Normal()) * plane1.Distance() + plane3.Normal().Cross(plane1.Normal()) * plane2.Distance() + plane1.Normal().Cross(plane2.Normal()) * plane3.Distance()) / num;
		}

		public static Vector3 Intersection(this Plane plane, Vector3 origin, Vector3 direction)
		{
			direction = direction.GetNormalized();
			if (plane.Raycast(origin, direction, out var enter) || enter != 0f)
			{
				return origin + enter * direction;
			}
			return new Vector3(float.NaN, float.NaN, float.NaN);
		}

		public static bool Raycast(this Plane plane, Vector3 origin, Vector3 direction, out float enter)
		{
			return plane.Raycast(new Ray(origin, direction), out enter);
		}

		public static Vector3[] GenerateThreePoints(this Plane plane, float scalar = 16f)
		{
			Vector3[] array = new Vector3[3];
			if (plane.Normal().Y() == 0f && plane.Normal().Z() == 0f)
			{
				array[0] = new Vector3(plane.Distance() / plane.Normal().X(), 0f - scalar, scalar);
				array[1] = new Vector3(plane.Distance() / plane.Normal().X(), 0f, 0f);
				array[2] = new Vector3(plane.Distance() / plane.Normal().X(), scalar, scalar);
				if (plane.Normal().X() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else if (plane.Normal().X() == 0f && plane.Normal().Z() == 0f)
			{
				array[0] = new Vector3(scalar, plane.Distance() / plane.Normal().Y(), 0f - scalar);
				array[1] = new Vector3(0f, plane.Distance() / plane.Normal().Y(), 0f);
				array[2] = new Vector3(scalar, plane.Distance() / plane.Normal().Y(), scalar);
				if (plane.Normal().Y() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else if (plane.Normal().X() == 0f && plane.Normal().Y() == 0f)
			{
				array[0] = new Vector3(0f - scalar, scalar, plane.Distance() / plane.Normal().Z());
				array[1] = new Vector3(0f, 0f, plane.Distance() / plane.Normal().Z());
				array[2] = new Vector3(scalar, scalar, plane.Distance() / plane.Normal().Z());
				if (plane.Normal().Z() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else if (plane.Normal().X() == 0f)
			{
				array[0] = new Vector3(0f - scalar, scalar * scalar, (0f - (scalar * scalar * plane.Normal().Y() - plane.Distance())) / plane.Normal().Z());
				array[1] = new Vector3(0f, 0f, plane.Distance() / plane.Normal().Z());
				array[2] = new Vector3(scalar, scalar * scalar, (0f - (scalar * scalar * plane.Normal().Y() - plane.Distance())) / plane.Normal().Z());
				if (plane.Normal().Z() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else if (plane.Normal().Y() == 0f)
			{
				array[0] = new Vector3((0f - (scalar * scalar * plane.Normal().Z() - plane.Distance())) / plane.Normal().X(), 0f - scalar, scalar * scalar);
				array[1] = new Vector3(plane.Distance() / plane.Normal().X(), 0f, 0f);
				array[2] = new Vector3((0f - (scalar * scalar * plane.Normal().Z() - plane.Distance())) / plane.Normal().X(), scalar, scalar * scalar);
				if (plane.Normal().X() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else if (plane.Normal().Z() == 0f)
			{
				array[0] = new Vector3(scalar * scalar, (0f - (scalar * scalar * plane.Normal().X() - plane.Distance())) / plane.Normal().Y(), 0f - scalar);
				array[1] = new Vector3(0f, plane.Distance() / plane.Normal().Y(), 0f);
				array[2] = new Vector3(scalar * scalar, (0f - (scalar * scalar * plane.Normal().X() - plane.Distance())) / plane.Normal().Y(), scalar);
				if (plane.Normal().Y() > 0f)
				{
					Array.Reverse(array);
				}
			}
			else
			{
				array[0] = new Vector3(0f - scalar, scalar * scalar, (0f - ((0f - scalar) * plane.Normal().X() + scalar * scalar * plane.Normal().Y() - plane.Distance())) / plane.Normal().Z());
				array[1] = new Vector3(0f, 0f, plane.Distance() / plane.Normal().Z());
				array[2] = new Vector3(scalar, scalar * scalar, (0f - (scalar * plane.Normal().X() + scalar * scalar * plane.Normal().Y() - plane.Distance())) / plane.Normal().Z());
				if (plane.Normal().Z() > 0f)
				{
					Array.Reverse(array);
				}
			}
			return array;
		}

		public static bool HasPoint(this Plane plane, Vector3 point, float epsilon = 1E-05f)
		{
			float distanceToPoint = plane.GetDistanceToPoint(point);
			if (distanceToPoint < epsilon)
			{
				return distanceToPoint > 0f - epsilon;
			}
			return false;
		}

		public static Plane CreateFromVertices(Vector3 point1, Vector3 point2, Vector3 point3)
		{
			if ((point1 + point2).Cross(point1 + point3).Magnitude() == 0f || float.IsNaN(point1.X()) || float.IsNaN(point1.Y()) || float.IsNaN(point1.Z()) || float.IsNaN(point2.X()) || float.IsNaN(point2.Y()) || float.IsNaN(point2.Z()) || float.IsNaN(point3.X()) || float.IsNaN(point3.Y()) || float.IsNaN(point3.Z()))
			{
				return new Plane(new Vector3(0f, 0f, 0f), 0f);
			}
			return new Plane(point1, point2, point3);
		}

		public static Lump<Plane> LumpFactory(byte[] data, BSP bsp, LumpInfo lumpInfo)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			int structLength = GetStructLength(bsp.MapType, lumpInfo.version);
			int num = data.Length / structLength;
			Lump<Plane> lump = new Lump<Plane>(num, bsp, lumpInfo);
			for (int i = 0; i < num; i++)
			{
				Vector3 inNormal = Vector3Extensions.ToVector3(data, structLength * i);
				float d = BitConverter.ToSingle(data, structLength * i + 12);
				lump.Add(new Plane(inNormal, d));
			}
			return lump;
		}

		public static byte[] GetBytes(this Plane p, MapType type, int version = 0)
		{
			byte[] array = new byte[GetStructLength(type, version)];
			if (type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Quake2) || type.IsSubtypeOf(MapType.Source) || type == MapType.Nightfire)
			{
				BitConverter.GetBytes(p.Type()).CopyTo(array, 16);
			}
			p.Normal().GetBytes().CopyTo(array, 0);
			BitConverter.GetBytes(p.Distance()).CopyTo(array, 12);
			return array;
		}

		public static int BestAxis(this Plane p)
		{
			int result = 0;
			float num = 0f;
			for (int i = 0; i < 6; i++)
			{
				float num2 = p.Normal().Dot(baseAxes[i * 3]);
				if (num2 > num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		public static int Type(this Plane p)
		{
			float num = Math.Abs(p.Normal().X());
			if ((double)num >= 1.0)
			{
				return 0;
			}
			float num2 = Math.Abs(p.Normal().Y());
			if ((double)num2 >= 1.0)
			{
				return 1;
			}
			float num3 = Math.Abs(p.Normal().Z());
			if ((double)num3 >= 1.0)
			{
				return 2;
			}
			if (num >= num2 && num >= num3)
			{
				return 3;
			}
			if (num2 >= num && num2 >= num3)
			{
				return 4;
			}
			return 5;
		}

		public static int GetIndexForLump(MapType type)
		{
			if (type == MapType.BlueShift)
			{
				return 0;
			}
			if (type.IsSubtypeOf(MapType.Source) || type.IsSubtypeOf(MapType.STEF2) || type.IsSubtypeOf(MapType.MOHAA) || type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Quake2))
			{
				return 1;
			}
			if (type == MapType.Nightfire || type.IsSubtypeOf(MapType.FAKK2))
			{
				return 1;
			}
			if (type == MapType.CoD2 || type == MapType.CoD4)
			{
				return 4;
			}
			if (type.IsSubtypeOf(MapType.Quake3))
			{
				return 2;
			}
			return -1;
		}

		public static int GetStructLength(MapType type, int version)
		{
			if (type == MapType.Titanfall || type.IsSubtypeOf(MapType.Quake3))
			{
				return 16;
			}
			if (type == MapType.Nightfire || type.IsSubtypeOf(MapType.Quake) || type.IsSubtypeOf(MapType.Quake2) || type.IsSubtypeOf(MapType.Source))
			{
				return 20;
			}
			return 0;
		}
	}
}
