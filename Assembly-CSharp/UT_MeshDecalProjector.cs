using System.Collections.Generic;
using Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class UT_MeshDecalProjector : MonoBehaviourGizmos
{
	public Material decalMaterial;

	public float decalSize = 1f;

	public float decalDepth = 0.1f;

	public LayerMask affectedLayers;

	public float offset = 0.1f;

	public bool projectOnStart;

	private GameObject decal;

	private void Start()
	{
		if (projectOnStart && Application.isPlaying && Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, 100f))
		{
			Vector3 point = hitInfo.point;
			Vector3 normal = hitInfo.normal;
			GameObject targetObject = hitInfo.collider.gameObject;
			Debug.Log(hitInfo.collider.name);
			ProjectDecal(point, normal, targetObject);
		}
	}

	public void ProjectDecal(Vector3 position, Vector3 normal, GameObject targetObject)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Object.DestroyImmediate(base.transform.GetChild(i).gameObject);
		}
		decal = new GameObject("MeshDecal");
		decal.transform.parent = base.transform;
		decal.transform.position = position;
		decal.transform.rotation = Quaternion.LookRotation(-normal);
		decal.transform.localScale = Vector3.one * decalSize;
		MeshFilter meshFilter = decal.AddComponent<MeshFilter>();
		decal.AddComponent<MeshRenderer>().material = decalMaterial;
		Mesh mesh = GenerateDecalMesh(decal.transform, targetObject);
		if (mesh != null)
		{
			meshFilter.mesh = mesh;
		}
	}

	private Mesh GenerateDecalMesh(Transform decalTransform, GameObject targetObject)
	{
		Vector3 vector = new Vector3(decalSize * 0.5f, decalSize * 0.5f, decalDepth * 0.5f);
		Bounds bounds = new Bounds(decalTransform.position, vector * 2f);
		Renderer[] obj = new Renderer[1] { targetObject.GetComponent<Renderer>() };
		List<Vector3> list = new List<Vector3>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector2> list3 = new List<Vector2>();
		List<int> list4 = new List<int>();
		Renderer[] array = obj;
		foreach (Renderer renderer in array)
		{
			if (!renderer.bounds.Intersects(bounds) || (affectedLayers.value & (1 << renderer.gameObject.layer)) == 0)
			{
				continue;
			}
			MeshFilter component = renderer.GetComponent<MeshFilter>();
			if (component == null)
			{
				continue;
			}
			Mesh sharedMesh = component.sharedMesh;
			if (sharedMesh == null)
			{
				continue;
			}
			Matrix4x4 matrix4x = decalTransform.worldToLocalMatrix * component.transform.localToWorldMatrix;
			Vector3[] vertices = sharedMesh.vertices;
			Vector3[] normals = sharedMesh.normals;
			int[] triangles = sharedMesh.triangles;
			for (int j = 0; j < triangles.Length; j += 3)
			{
				Vector3[] array2 = new Vector3[3];
				Vector3[] array3 = new Vector3[3];
				for (int k = 0; k < 3; k++)
				{
					int num = triangles[j + k];
					Vector3 vector2 = vertices[num];
					Vector3 vector3 = normals[num];
					vector2 = matrix4x.MultiplyPoint(vector2 + vector3 * offset);
					vector3 = matrix4x.MultiplyVector(vector3);
					array2[k] = vector2;
					array3[k] = vector3;
				}
				if (ClipTriangleToBounds(array2, vector))
				{
					int count = list.Count;
					list.AddRange(array2);
					list2.AddRange(array3);
					for (int l = 0; l < 3; l++)
					{
						Vector2 item = new Vector2(array2[l].x / decalSize + 0.5f, array2[l].y / decalSize + 0.5f);
						list3.Add(item);
					}
					list4.Add(count);
					list4.Add(count + 1);
					list4.Add(count + 2);
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return new Mesh
		{
			vertices = list.ToArray(),
			normals = list2.ToArray(),
			uv = list3.ToArray(),
			triangles = list4.ToArray()
		};
	}

	private bool ClipTriangleToBounds(Vector3[] triangle, Vector3 halfSize)
	{
		for (int i = 0; i < triangle.Length; i++)
		{
			Vector3 vector = triangle[i];
			if (Mathf.Abs(vector.x) <= halfSize.x && Mathf.Abs(vector.y) <= halfSize.y && Mathf.Abs(vector.z) <= halfSize.z)
			{
				return true;
			}
		}
		return false;
	}

	public override void DrawGizmos()
	{
		if (projectOnStart && GizmoContext.InSelection(this))
		{
			Draw.DashedLine(base.transform.position, base.transform.position + base.transform.forward, 0.1f, 0.1f, Color.yellow);
			Draw.WireBox(base.transform.position, decalSize, Color.yellow);
		}
	}
}
