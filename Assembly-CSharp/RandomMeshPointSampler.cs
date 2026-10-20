using System;
using UnityEngine;

public static class RandomMeshPointSampler
{
	public static Vector3 SamplePointLocal(Mesh mesh)
	{
		if (mesh == null)
		{
			Debug.LogError("Mesh is null");
			return Vector3.zero;
		}
		int[] triangles = mesh.triangles;
		Vector3[] vertices = mesh.vertices;
		float[] array = new float[triangles.Length / 3];
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		while (num2 < triangles.Length)
		{
			Vector3 vector = vertices[triangles[num2]];
			Vector3 vector2 = vertices[triangles[num2 + 1]];
			Vector3 vector3 = vertices[triangles[num2 + 2]];
			float num4 = Vector3.Cross(vector2 - vector, vector3 - vector).magnitude * 0.5f;
			num = (array[num3] = num + num4);
			num2 += 3;
			num3++;
		}
		float value = UnityEngine.Random.value * num;
		int num5 = Array.BinarySearch(array, value);
		if (num5 < 0)
		{
			num5 = ~num5;
		}
		int num6 = triangles[num5 * 3];
		int num7 = triangles[num5 * 3 + 1];
		int num8 = triangles[num5 * 3 + 2];
		Vector3 vector4 = vertices[num6];
		Vector3 vector5 = vertices[num7];
		Vector3 vector6 = vertices[num8];
		float num9 = UnityEngine.Random.value;
		float num10 = UnityEngine.Random.value;
		if (num9 + num10 > 1f)
		{
			num9 = 1f - num9;
			num10 = 1f - num10;
		}
		return vector4 + num9 * (vector5 - vector4) + num10 * (vector6 - vector4);
	}

	public static Vector3 SamplePointWorld(Mesh mesh, Transform meshTransform)
	{
		return meshTransform.TransformPoint(SamplePointLocal(mesh));
	}
}
