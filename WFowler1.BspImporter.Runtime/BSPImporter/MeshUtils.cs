using System.Collections.Generic;
using System.Linq;
using LibBSP;
using UnityEngine;

namespace BSPImporter
{
	public static class MeshUtils
	{
		public const int maxMeshVertices = 32767;

		public const float inch2MeterScale = 0.0254f;

		public static Mesh CreateFaceMesh(BSP bsp, Face face, Vector2 dims, int curveTessellationLevel)
		{
			Mesh mesh = null;
			if (face.NumVertices > 0)
			{
				mesh = ((face.NumIndices != 0 || face.Type != 2) ? LoadVerticesFromFace(bsp, face) : CreatePatchMesh(bsp, face, curveTessellationLevel));
			}
			else if (face.NumEdgeIndices > 0)
			{
				mesh = LoadVerticesFromEdges(bsp, face);
			}
			if (mesh != null)
			{
				TextureInfo textureInfo = bsp.GetTextureInfo(face);
				if (textureInfo.Data != null && textureInfo.Data.Length != 0)
				{
					mesh.CalculateUVs(textureInfo, dims);
				}
				mesh.NegateVs();
			}
			return mesh;
		}

		public static Mesh LoadVertices(IList<UIVertex> vertices)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3[] array = new Vector3[vertices.Count];
			Vector3[] array2 = new Vector3[vertices.Count];
			Vector2[] array3 = new Vector2[vertices.Count];
			Vector2[] array4 = new Vector2[vertices.Count];
			Color[] array5 = new Color[vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				UIVertex uIVertex = vertices[i].SwizzleYZ().ScaleInch2Meter();
				array[i] = uIVertex.position;
				array2[i] = uIVertex.normal;
				array3[i] = uIVertex.uv0;
				array4[i] = uIVertex.uv1;
				array5[i] = uIVertex.color;
			}
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.uv2 = array4;
			mesh.colors = array5;
			return mesh;
		}

		public static Mesh LoadVerticesFromFace(BSP bsp, Face face)
		{
			Mesh mesh = LoadVertices(bsp.GetReferencedObjects<UIVertex>(face, "Vertices"));
			List<long> referencedObjects = bsp.GetReferencedObjects<long>(face, "Indices");
			int[] array = new int[referencedObjects.Count];
			for (int i = 0; i < referencedObjects.Count; i++)
			{
				array[i] = (int)referencedObjects[i];
			}
			mesh.triangles = array;
			return mesh;
		}

		public static Mesh LoadVerticesFromEdges(BSP bsp, Face face)
		{
			UIVertex[] array = new UIVertex[face.NumEdgeIndices];
			int[] array2 = new int[(face.NumEdgeIndices - 2) * 3];
			int num = (int)bsp.FaceEdges[face.FirstEdgeIndexIndex];
			if (num > 0)
			{
				array[0] = bsp.Vertices[bsp.Edges[num].FirstVertexIndex];
			}
			else
			{
				array[0] = bsp.Vertices[bsp.Edges[-num].SecondVertexIndex];
			}
			int num2 = 0;
			int num3 = 1;
			for (int i = 1; i < face.NumEdgeIndices - 1; i++)
			{
				int num4 = (int)bsp.FaceEdges[face.FirstEdgeIndexIndex + i];
				UIVertex uIVertex;
				UIVertex uIVertex2;
				if (num4 > 0)
				{
					uIVertex = bsp.Vertices[bsp.Edges[num4].FirstVertexIndex];
					uIVertex2 = bsp.Vertices[bsp.Edges[num4].SecondVertexIndex];
				}
				else
				{
					uIVertex = bsp.Vertices[bsp.Edges[-num4].SecondVertexIndex];
					uIVertex2 = bsp.Vertices[bsp.Edges[-num4].FirstVertexIndex];
				}
				if (!(uIVertex.position != array[0].position) || !(uIVertex2.position != array[0].position))
				{
					continue;
				}
				array2[num2 * 3] = 0;
				bool flag = false;
				bool flag2 = false;
				for (int j = 1; j < num3; j++)
				{
					if (uIVertex.position == array[j].position)
					{
						array2[num2 * 3 + 1] = j;
						flag = true;
					}
				}
				if (!flag)
				{
					array[num3] = uIVertex;
					array2[num2 * 3 + 1] = num3;
					num3++;
				}
				for (int k = 1; k < num3; k++)
				{
					if (uIVertex2.position == array[k].position)
					{
						array2[num2 * 3 + 2] = k;
						flag2 = true;
					}
				}
				if (!flag2)
				{
					array[num3] = uIVertex2;
					array2[num2 * 3 + 2] = num3;
					num3++;
				}
				num2++;
			}
			Mesh mesh = LoadVertices(array);
			mesh.triangles = array2;
			return mesh;
		}

		public static void CalculateUVs(this Mesh mesh, TextureInfo textureInfo, Vector2 dims)
		{
			Vector2[] array = new Vector2[mesh.vertices.Length];
			Matrix4x4 inverse = textureInfo.BuildTexMatrix().inverse;
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 transformVertex = inverse.MultiplyPoint3x4(mesh.vertices[i]);
				Vector2 vector = textureInfo.CalculateUV(transformVertex, dims);
				array[i] = vector;
			}
			mesh.uv = array;
		}

		public static void TransformVertices(this Mesh mesh, Matrix4x4 transform)
		{
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = transform.MultiplyPoint3x4(vertices[i]);
				normals[i] = transform.MultiplyVector(normals[i]);
			}
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.RecalculateBounds();
		}

		public static void NegateVs(this Mesh mesh)
		{
			Vector2[] uv = mesh.uv;
			for (int i = 0; i < uv.Length; i++)
			{
				uv[i] = new Vector2(uv[i].x, 0f - uv[i].y);
			}
			mesh.uv = uv;
		}

		public static Mesh CombineAllMeshes(Mesh[] meshes, bool mergeSubMeshes, bool useMatrices)
		{
			List<CombineInstance> list = new List<CombineInstance>(meshes.Length);
			for (int i = 0; i < meshes.Length; i++)
			{
				if (meshes[i] != null)
				{
					list.Add(new CombineInstance
					{
						mesh = meshes[i],
						transform = Matrix4x4.identity
					});
				}
			}
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.CombineMeshes(list.ToArray(), mergeSubMeshes, useMatrices);
			return mesh;
		}

		public static void AddMeshToGameObject(this Mesh mesh, Material[] materials, GameObject gameObject)
		{
			MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = gameObject.AddComponent<MeshFilter>();
			}
			meshFilter.sharedMesh = mesh;
			MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = gameObject.AddComponent<MeshRenderer>();
			}
			meshRenderer.sharedMaterials = materials;
			if (gameObject.GetComponent<MeshCollider>() == null)
			{
				gameObject.AddComponent<MeshCollider>();
			}
		}

		public static Mesh CreateDisplacementMesh(BSP bsp, Face face, Vector2 dims)
		{
			Mesh mesh = null;
			if (face.NumEdgeIndices > 0)
			{
				mesh = LoadVerticesFromEdges(bsp, face);
				Vector3[] vertices = mesh.vertices;
				int[] triangles = mesh.triangles;
				if (vertices.Length != 4 || triangles.Length != 6)
				{
					Debug.LogWarning("Cannot create displacement mesh because " + vertices.Length + " corners and " + triangles.Length + " triangle indices.");
					return null;
				}
				Displacement displacement = bsp.Displacements[face.DisplacementIndex];
				int numSideTriangles = (int)Mathf.Pow(2f, displacement.Power);
				DisplacementVertex[] array = displacement.Vertices.ToArray();
				Vector3[] array2 = new Vector3[4];
				Vector3 vector = displacement.StartPosition.SwizzleYZ() * 0.0254f;
				if ((vertices[triangles[0]] - vector).sqrMagnitude < 0.01f)
				{
					array2[0] = vertices[triangles[0]];
					array2[1] = vertices[triangles[1]];
					array2[2] = vertices[triangles[5]];
					array2[3] = vertices[triangles[4]];
				}
				else if ((vertices[triangles[1]] - vector).sqrMagnitude < 0.01f)
				{
					array2[0] = vertices[triangles[1]];
					array2[1] = vertices[triangles[4]];
					array2[2] = vertices[triangles[0]];
					array2[3] = vertices[triangles[5]];
				}
				else if ((vertices[triangles[5]] - vector).sqrMagnitude < 0.01f)
				{
					array2[0] = vertices[triangles[5]];
					array2[1] = vertices[triangles[0]];
					array2[2] = vertices[triangles[4]];
					array2[3] = vertices[triangles[1]];
				}
				else
				{
					if (!((vertices[triangles[4]] - vector).sqrMagnitude < 0.01f))
					{
						Debug.LogWarning("Cannot create displacement mesh because start position isn't one of the face corners.\nStart position: " + vector.ToString() + "\nCorners: " + vertices[triangles[0]].ToString() + " " + vertices[triangles[1]].ToString() + " " + vertices[triangles[5]].ToString() + " " + vertices[triangles[4]]);
						return null;
					}
					array2[0] = vertices[triangles[4]];
					array2[1] = vertices[triangles[5]];
					array2[2] = vertices[triangles[1]];
					array2[3] = vertices[triangles[0]];
				}
				Vector3[] array3 = new Vector3[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array3[i] = array[i].Normal.SwizzleYZ() * array[i].Magnitude * 0.0254f;
				}
				Vector2[] uv = new Vector2[4];
				Vector2[] uv2 = new Vector2[4];
				mesh.vertices = array2;
				mesh.uv = uv;
				mesh.uv2 = uv2;
				mesh.CalculateUVs(bsp.GetTextureInfo(face), dims);
				mesh.CalculateTerrainVertices(array3, numSideTriangles);
				mesh.triangles = BuildDisplacementTriangles(numSideTriangles);
				mesh.NegateVs();
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				return mesh;
			}
			Debug.LogWarning("Cannot create displacement, face contains no edges.");
			return null;
		}

		public static Mesh CreateMoHAATerrainMesh(BSP bsp, LODTerrain lodTerrain)
		{
			Vector3[] cornersForTerrain = GetCornersForTerrain(new Vector3(lodTerrain.X * 64, lodTerrain.Y * 64, lodTerrain.BaseZ), 512f, (lodTerrain.Flags & 0x40) > 0);
			Vector3[] array = new Vector3[81];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if ((lodTerrain.Flags & 0x40) > 0)
					{
						array[j * 9 + i] = Vector3.up * (int)lodTerrain.Heightmap[i, j] * 2f * 0.0254f;
					}
					else
					{
						array[i * 9 + j] = Vector3.up * (int)lodTerrain.Heightmap[i, j] * 2f * 0.0254f;
					}
				}
			}
			Vector2[] uv = new Vector2[4]
			{
				new Vector2(lodTerrain.UVs[0], lodTerrain.UVs[1]),
				new Vector2(lodTerrain.UVs[2], lodTerrain.UVs[3]),
				new Vector2(lodTerrain.UVs[4], lodTerrain.UVs[5]),
				new Vector2(lodTerrain.UVs[6], lodTerrain.UVs[7])
			};
			Vector2[] uv2 = new Vector2[4];
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.vertices = cornersForTerrain;
			mesh.uv = uv;
			mesh.uv2 = uv2;
			mesh.CalculateTerrainVertices(array, 8);
			mesh.triangles = BuildDisplacementTriangles(8);
			mesh.NegateVs();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Vector3[] GetCornersForTerrain(Vector3 origin, float side, bool inverted)
		{
			Vector3[] array = new Vector3[4]
			{
				origin.SwizzleYZ().ScaleInch2Meter(),
				new Vector3(origin.x, origin.y + side, origin.z).SwizzleYZ().ScaleInch2Meter(),
				new Vector3(origin.x + side, origin.y, origin.z).SwizzleYZ().ScaleInch2Meter(),
				new Vector3(origin.x + side, origin.y + side, origin.z).SwizzleYZ().ScaleInch2Meter()
			};
			if (inverted)
			{
				Vector3 vector = array[1];
				array[1] = array[3];
				array[3] = vector;
			}
			return array;
		}

		private static void CalculateTerrainVertices(this Mesh mesh, Vector3[] displacementMap, int numSideTriangles)
		{
			int num = numSideTriangles + 1;
			Vector3[] array = new Vector3[num * num];
			Vector3[] vertices = mesh.vertices;
			Vector2[] array2 = new Vector2[num * num];
			Vector2[] uv = mesh.uv;
			Vector2[] array3 = new Vector2[num * num];
			Vector2[] uv2 = mesh.uv2;
			for (int i = 0; i < num; i++)
			{
				float t = (float)i / (float)numSideTriangles;
				Vector3 a = Vector3.Lerp(vertices[0], vertices[1], t);
				Vector3 b = Vector3.Lerp(vertices[2], vertices[3], t);
				Vector2 a2 = Vector2.Lerp(uv[0], uv[1], t);
				Vector2 b2 = Vector2.Lerp(uv[2], uv[3], t);
				Vector2 a3 = Vector2.Lerp(uv2[0], uv2[1], t);
				Vector2 b3 = Vector2.Lerp(uv2[2], uv2[3], t);
				for (int j = 0; j < num; j++)
				{
					int num2 = i * num + j;
					float t2 = (float)j / (float)numSideTriangles;
					array[num2] = Vector3.Lerp(a, b, t2) + displacementMap[num2];
					array2[num2] = Vector2.Lerp(a2, b2, t2);
					array3[num2] = Vector2.Lerp(a3, b3, t2);
				}
			}
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.uv2 = array3;
		}

		private static int[] BuildDisplacementTriangles(int numSideTriangles)
		{
			int[] array = new int[numSideTriangles * numSideTriangles * 6];
			int num = numSideTriangles + 1;
			for (int i = 0; i < numSideTriangles; i++)
			{
				for (int j = 0; j < numSideTriangles; j++)
				{
					array[i * numSideTriangles * 6 + j * 6] = i * num + j;
					array[i * numSideTriangles * 6 + j * 6 + 5] = (i + 1) * num + j + 1;
					array[i * numSideTriangles * 6 + j * 6 + 2] = i * num + j + 1;
					array[i * numSideTriangles * 6 + j * 6 + 4] = (i + 1) * num + j;
					if ((i + j) % 2 == 0)
					{
						array[i * numSideTriangles * 6 + j * 6 + 1] = (i + 1) * num + j + 1;
						array[i * numSideTriangles * 6 + j * 6 + 3] = i * num + j;
					}
					else
					{
						array[i * numSideTriangles * 6 + j * 6 + 1] = (i + 1) * num + j;
						array[i * numSideTriangles * 6 + j * 6 + 3] = i * num + j + 1;
					}
				}
			}
			return array;
		}

		public static Mesh CreatePatchMesh(BSP bsp, Face face, int curveTessellationLevel)
		{
			List<Mesh> list = new List<Mesh>();
			List<UIVertex> referencedObjects = bsp.GetReferencedObjects<UIVertex>(face, "Vertices");
			Vector2 patchSize = face.PatchSize;
			int num = (int)Mathf.Round(patchSize[0]);
			for (int i = 0; (float)i < patchSize[1] - 2f; i += 2)
			{
				for (int j = 0; (float)j < patchSize[0] - 2f; j += 2)
				{
					int num2 = i * num;
					UIVertex[] array = new UIVertex[9]
					{
						referencedObjects[num2 + j],
						referencedObjects[num2 + j + 1],
						referencedObjects[num2 + j + 2],
						default(UIVertex),
						default(UIVertex),
						default(UIVertex),
						default(UIVertex),
						default(UIVertex),
						default(UIVertex)
					};
					num2 += num;
					array[3] = referencedObjects[num2 + j];
					array[4] = referencedObjects[num2 + j + 1];
					array[5] = referencedObjects[num2 + j + 2];
					num2 += num;
					array[6] = referencedObjects[num2 + j];
					array[7] = referencedObjects[num2 + j + 1];
					array[8] = referencedObjects[num2 + j + 2];
					list.Add(CreateQuadraticBezierMesh(array, curveTessellationLevel));
				}
			}
			return CombineAllMeshes(list.ToArray(), mergeSubMeshes: true, useMatrices: false);
		}

		public static Mesh CreateQuadraticBezierMesh(UIVertex[] bezierControls, int curveTessellationLevel)
		{
			Mesh mesh = LoadVertices(TessellateCurveVertices(bezierControls, curveTessellationLevel));
			mesh.triangles = BuildCurveTriangles(curveTessellationLevel);
			return mesh;
		}

		private static UIVertex[] TessellateCurveVertices(UIVertex[] bezierControls, int curveTessellationLevel)
		{
			UIVertex[] array = new UIVertex[(curveTessellationLevel + 1) * (curveTessellationLevel + 1)];
			for (int i = 0; i <= curveTessellationLevel; i++)
			{
				float t = (float)i / (float)curveTessellationLevel;
				Vector3[] array2 = new Vector3[3];
				Vector2[] array3 = new Vector2[3];
				Vector2[] array4 = new Vector2[3];
				for (int j = 0; j < 3; j++)
				{
					array2[j] = InterpolateCurve(bezierControls[3 * j].position, bezierControls[3 * j + 1].position, bezierControls[3 * j + 2].position, t);
					array3[j] = InterpolateCurve(bezierControls[3 * j].uv0, bezierControls[3 * j + 1].uv0, bezierControls[3 * j + 2].uv0, t);
					array4[j] = InterpolateCurve(bezierControls[3 * j].uv1, bezierControls[3 * j + 1].uv1, bezierControls[3 * j + 2].uv1, t);
				}
				for (int k = 0; k <= curveTessellationLevel; k++)
				{
					float t2 = (float)k / (float)curveTessellationLevel;
					array[i * (curveTessellationLevel + 1) + k].position = InterpolateCurve(array2[0], array2[1], array2[2], t2);
					array[i * (curveTessellationLevel + 1) + k].uv0 = InterpolateCurve(array3[0], array3[1], array3[2], t2);
					array[i * (curveTessellationLevel + 1) + k].uv1 = InterpolateCurve(array4[0], array4[1], array4[2], t2);
				}
			}
			return array;
		}

		private static int[] BuildCurveTriangles(int curveTessellationLevel)
		{
			int[] array = new int[curveTessellationLevel * curveTessellationLevel * 6];
			for (int i = 0; i < curveTessellationLevel; i++)
			{
				for (int j = 0; j < curveTessellationLevel; j++)
				{
					array[(i * curveTessellationLevel + j) * 6] = i * (curveTessellationLevel + 1) + j;
					array[(i * curveTessellationLevel + j) * 6 + 1] = i * (curveTessellationLevel + 1) + j + 1;
					array[(i * curveTessellationLevel + j) * 6 + 2] = i * (curveTessellationLevel + 1) + j + (curveTessellationLevel + 1);
					array[(i * curveTessellationLevel + j) * 6 + 3] = i * (curveTessellationLevel + 1) + j + 1;
					array[(i * curveTessellationLevel + j) * 6 + 4] = i * (curveTessellationLevel + 1) + j + (curveTessellationLevel + 1) + 1;
					array[(i * curveTessellationLevel + j) * 6 + 5] = i * (curveTessellationLevel + 1) + j + (curveTessellationLevel + 1);
				}
			}
			return array;
		}

		private static Vector3 InterpolateCurve(Vector3 v1, Vector3 v2, Vector3 v3, float t)
		{
			float num = 1f - t;
			return v1 * (num * num) + v2 * (2f * num * t) + v3 * (t * t);
		}
	}
}
