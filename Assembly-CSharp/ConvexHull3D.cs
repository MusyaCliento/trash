using System.Collections.Generic;
using UnityEngine;

public static class ConvexHull3D
{
	private class Face
	{
		public Vector3 normal;

		public int[] vertIndices;

		public List<int> outside;

		public Face(int v0, int v1, int v2, Vector3[] points)
		{
			vertIndices = new int[3] { v0, v1, v2 };
			normal = Vector3.Normalize(Vector3.Cross(points[v1] - points[v0], points[v2] - points[v0]));
			outside = new List<int>();
		}

		public bool PointAboveFace(Vector3 p, Vector3 refPoint)
		{
			return Vector3.Dot(p - refPoint, normal) > 0f;
		}
	}

	private static Vector3[] lastUsedPoints;

	public static Mesh GenerateConvexHullMesh(List<Vector3> points)
	{
		if (points == null || points.Count < 4)
		{
			return null;
		}
		HashSet<Vector3> hashSet = new HashSet<Vector3>(points);
		Vector3[] array = new Vector3[hashSet.Count];
		hashSet.CopyTo(array);
		return FacesToMesh(QuickHull(array));
	}

	private static List<Face> QuickHull(Vector3[] points)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 1; i < points.Length; i++)
		{
			if (points[i].x < points[num].x)
			{
				num = i;
			}
			if (points[i].x > points[num2].x)
			{
				num2 = i;
			}
		}
		int num3 = num;
		int num4 = num2;
		float num5 = -1f;
		int num6 = -1;
		for (int j = 0; j < points.Length; j++)
		{
			if (j != num3 && j != num4)
			{
				float magnitude = Vector3.Cross(points[num4] - points[num3], points[j] - points[num3]).magnitude;
				if (magnitude > num5)
				{
					num5 = magnitude;
					num6 = j;
				}
			}
		}
		float num7 = -1f;
		int num8 = -1;
		Vector3 vector = Vector3.Cross(points[num4] - points[num3], points[num6] - points[num3]);
		for (int k = 0; k < points.Length; k++)
		{
			if (k != num3 && k != num4 && k != num6)
			{
				float num9 = Mathf.Abs(Vector3.Dot(points[k] - points[num3], vector));
				if (num9 > num7)
				{
					num7 = num9;
					num8 = k;
				}
			}
		}
		List<Face> faces = new List<Face>();
		if (Vector3.Dot(vector, points[num8] - points[num3]) < 0f)
		{
			int num10 = num4;
			num4 = num6;
			num6 = num10;
			vector = Vector3.Cross(points[num4] - points[num3], points[num6] - points[num3]);
		}
		Face item = new Face(num3, num4, num6, points);
		Face item2 = new Face(num3, num6, num8, points);
		Face item3 = new Face(num3, num8, num4, points);
		Face item4 = new Face(num4, num8, num6, points);
		faces.Add(item);
		faces.Add(item2);
		faces.Add(item3);
		faces.Add(item4);
		for (int l = 0; l < points.Length; l++)
		{
			if (l == num3 || l == num4 || l == num6 || l == num8)
			{
				continue;
			}
			int num11 = -1;
			float num12 = 0f;
			foreach (Face item5 in faces)
			{
				float num13 = Vector3.Dot(item5.normal, points[l] - points[item5.vertIndices[0]]);
				if (num13 > 0f && num13 > num12)
				{
					num12 = num13;
					num11 = faces.IndexOf(item5);
				}
			}
			if (num11 >= 0)
			{
				faces[num11].outside.Add(l);
			}
		}
		bool flag = false;
		while (!flag)
		{
			flag = true;
			for (int m = 0; m < faces.Count; m++)
			{
				Face face = faces[m];
				if (face.outside.Count > 0)
				{
					int furthestPoint = GetFurthestPoint(face, points);
					UpdateHullWithPoint(ref faces, face, furthestPoint, points);
					flag = false;
					break;
				}
			}
		}
		return faces;
	}

	private static int GetFurthestPoint(Face face, Vector3[] points)
	{
		int num = face.outside[0];
		float num2 = Vector3.Dot(face.normal, points[num] - points[face.vertIndices[0]]);
		foreach (int item in face.outside)
		{
			float num3 = Vector3.Dot(face.normal, points[item] - points[face.vertIndices[0]]);
			if (num3 > num2)
			{
				num2 = num3;
				num = item;
			}
		}
		return num;
	}

	private static void UpdateHullWithPoint(ref List<Face> faces, Face face, int pointIndex, Vector3[] points)
	{
		List<Face> list = new List<Face>();
		foreach (Face face3 in faces)
		{
			if (face3.PointAboveFace(points[pointIndex], points[face3.vertIndices[0]]))
			{
				list.Add(face3);
			}
		}
		HashSet<(int, int)> hashSet = new HashSet<(int, int)>();
		foreach (Face item3 in list)
		{
			for (int i = 0; i < 3; i++)
			{
				int a = item3.vertIndices[i];
				int b = item3.vertIndices[(i + 1) % 3];
				(int, int) item = (Mathf.Min(a, b), Mathf.Max(a, b));
				hashSet.Add(item);
			}
		}
		List<(int, int)> list2 = new List<(int, int)>();
		Dictionary<(int, int), int> dictionary = new Dictionary<(int, int), int>();
		foreach (var item4 in hashSet)
		{
			if (!dictionary.ContainsKey(item4))
			{
				dictionary[item4] = 0;
			}
			dictionary[item4]++;
		}
		foreach (KeyValuePair<(int, int), int> item5 in dictionary)
		{
			if (item5.Value > 1)
			{
				list2.Add(item5.Key);
			}
		}
		foreach (var item6 in list2)
		{
			hashSet.Remove(item6);
		}
		foreach (Face item7 in list)
		{
			faces.Remove(item7);
		}
		List<Face> list3 = new List<Face>();
		foreach (var item8 in hashSet)
		{
			Face item2 = new Face(item8.Item1, item8.Item2, pointIndex, points);
			list3.Add(item2);
		}
		faces.AddRange(list3);
		List<int> list4 = new List<int>();
		foreach (Face item9 in list)
		{
			list4.AddRange(item9.outside);
		}
		HashSet<int> hashSet2 = new HashSet<int>(list4);
		hashSet2.Remove(pointIndex);
		foreach (int item10 in hashSet2)
		{
			float num = 0f;
			Face face2 = null;
			foreach (Face item11 in list3)
			{
				float num2 = Vector3.Dot(item11.normal, points[item10] - points[item11.vertIndices[0]]);
				if (num2 > 0f && num2 > num)
				{
					num = num2;
					face2 = item11;
				}
			}
			face2?.outside.Add(item10);
		}
	}

	private static Mesh FacesToMesh(List<Face> faces)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Face face in faces)
		{
			hashSet.Add(face.vertIndices[0]);
			hashSet.Add(face.vertIndices[1]);
			hashSet.Add(face.vertIndices[2]);
		}
		return BuildMeshFromFaces(faces, lastUsedPoints);
	}

	private static Mesh BuildMeshFromFaces(List<Face> faces, Vector3[] points)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Face face in faces)
		{
			hashSet.Add(face.vertIndices[0]);
			hashSet.Add(face.vertIndices[1]);
			hashSet.Add(face.vertIndices[2]);
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<Vector3> list = new List<Vector3>();
		foreach (int item in hashSet)
		{
			dictionary[item] = list.Count;
			list.Add(points[item]);
		}
		List<int> list2 = new List<int>();
		foreach (Face face2 in faces)
		{
			list2.Add(dictionary[face2.vertIndices[0]]);
			list2.Add(dictionary[face2.vertIndices[1]]);
			list2.Add(dictionary[face2.vertIndices[2]]);
		}
		Mesh mesh = new Mesh();
		mesh.vertices = list.ToArray();
		mesh.triangles = list2.ToArray();
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		return mesh;
	}

	private static Mesh FacesToMesh(List<Face> faces, Vector3[] points)
	{
		List<Vector3> list = new List<Vector3>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Face face in faces)
		{
			int[] vertIndices = face.vertIndices;
			foreach (int num in vertIndices)
			{
				if (!dictionary.ContainsKey(num))
				{
					dictionary[num] = list.Count;
					list.Add(points[num]);
				}
			}
		}
		List<int> list2 = new List<int>();
		foreach (Face face2 in faces)
		{
			list2.Add(dictionary[face2.vertIndices[0]]);
			list2.Add(dictionary[face2.vertIndices[1]]);
			list2.Add(dictionary[face2.vertIndices[2]]);
		}
		Mesh mesh = new Mesh();
		mesh.vertices = list.ToArray();
		mesh.triangles = list2.ToArray();
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		return mesh;
	}
}
