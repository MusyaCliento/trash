using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HandholdGenerator
{
	private struct Edge
	{
		public int a;

		public int b;

		public Edge(int x, int y)
		{
			if (x < y)
			{
				a = x;
				b = y;
			}
			else
			{
				a = y;
				b = x;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is Edge edge && edge.a == a)
			{
				return edge.b == b;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (a * 73856093) ^ (b * 19349663);
		}
	}

	private const float EXTRUDE_AMOUNT = 0.1f;

	public static MeshCollider Generate(GameObject root, Vector3 upVector, LayerMask generationLayers, float maxUpAngle = 60f, string handholdNameAffix = "", bool saveGeneratedData = true, string generationName = "handhold:basic:generated-collider")
	{
		if (!root)
		{
			Debug.LogError("No GameObject selected.");
			return null;
		}
		Transform transform = root.transform;
		Vector3 rootLocalExtrudeDir = transform.InverseTransformVector(upVector);
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		MeshFilter[] componentsInChildren = root.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if ((bool)meshFilter.sharedMesh && ((int)generationLayers & (1 << meshFilter.gameObject.layer)) != 0)
			{
				ProcessMesh(meshFilter.sharedMesh, meshFilter.transform, transform, rootLocalExtrudeDir, list, list2, upVector, maxUpAngle);
			}
		}
		if (list.Count == 0)
		{
			Debug.LogWarning("No upward-facing boundary edges found.");
			return null;
		}
		Mesh mesh = new Mesh();
		mesh.indexFormat = IndexFormat.UInt32;
		mesh.SetVertices(list);
		mesh.SetTriangles(list2, 0);
		mesh.RecalculateBounds();
		GameObject gameObject = new GameObject(generationName);
		gameObject.transform.SetParent(transform, worldPositionStays: false);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
		meshCollider.sharedMesh = mesh;
		meshCollider.convex = false;
		Debug.Log("World-up edge extrusion collider generated.");
		return meshCollider;
	}

	private static void ProcessMesh(Mesh mesh, Transform meshTransform, Transform rootTransform, Vector3 rootLocalExtrudeDir, List<Vector3> outVerts, List<int> outTris, Vector3 upVector, float maxUpAngle)
	{
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		Matrix4x4 localToWorldMatrix = meshTransform.localToWorldMatrix;
		Matrix4x4 worldToLocalMatrix = rootTransform.worldToLocalMatrix;
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 vector = localToWorldMatrix.MultiplyPoint3x4(vertices[triangles[i]]);
			Vector3 vector2 = localToWorldMatrix.MultiplyPoint3x4(vertices[triangles[i + 1]]);
			if (Vector3.Angle(Vector3.Cross(rhs: localToWorldMatrix.MultiplyPoint3x4(vertices[triangles[i + 2]]) - vector, lhs: vector2 - vector).normalized, upVector) <= maxUpAngle)
			{
				hashSet.Add(i / 3);
			}
		}
		Dictionary<Edge, int> dictionary = new Dictionary<Edge, int>();
		foreach (int item3 in hashSet)
		{
			int num = item3 * 3;
			AddEdge(triangles[num], triangles[num + 1], dictionary);
			AddEdge(triangles[num + 1], triangles[num + 2], dictionary);
			AddEdge(triangles[num + 2], triangles[num], dictionary);
		}
		foreach (KeyValuePair<Edge, int> item4 in dictionary)
		{
			if (item4.Value == 1)
			{
				Edge key = item4.Key;
				Vector3 point = localToWorldMatrix.MultiplyPoint3x4(vertices[key.a]);
				Vector3 point2 = localToWorldMatrix.MultiplyPoint3x4(vertices[key.b]);
				Vector3 vector3 = worldToLocalMatrix.MultiplyPoint3x4(point);
				Vector3 vector4 = worldToLocalMatrix.MultiplyPoint3x4(point2);
				Vector3 item = vector3 + rootLocalExtrudeDir * 0.1f;
				Vector3 item2 = vector4 + rootLocalExtrudeDir * 0.1f;
				int count = outVerts.Count;
				outVerts.Add(vector3);
				outVerts.Add(vector4);
				outVerts.Add(item2);
				outVerts.Add(item);
				outTris.Add(count);
				outTris.Add(count + 2);
				outTris.Add(count + 1);
				outTris.Add(count);
				outTris.Add(count + 3);
				outTris.Add(count + 2);
			}
		}
	}

	private static void AddEdge(int a, int b, Dictionary<Edge, int> dict)
	{
		Edge key = new Edge(a, b);
		dict.TryGetValue(key, out var value);
		dict[key] = value + 1;
	}
}
