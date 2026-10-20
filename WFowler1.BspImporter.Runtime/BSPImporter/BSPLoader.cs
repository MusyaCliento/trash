using System;
using System.Collections.Generic;
using System.IO;
using LibBSP;
using Paloma;
using UnityEngine;

namespace BSPImporter
{
	public class BSPLoader
	{
		public enum MeshCombineOptions
		{
			None = 0,
			PerMaterial = 1,
			PerEntity = 2
		}

		[Flags]
		public enum AssetSavingOptions
		{
			None = 0,
			Materials = 1,
			Meshes = 2,
			MaterialsAndMeshes = 3,
			Prefab = 4,
			MaterialsAndPrefab = 5,
			MeshesAndPrefab = 6,
			MaterialsMeshesAndPrefab = 7
		}

		[Serializable]
		public struct Settings
		{
			public string path;

			public string texturePath;

			public MeshCombineOptions meshCombineOptions;

			public AssetSavingOptions assetSavingOptions;

			public string materialPath;

			public string meshPath;

			public int curveTessellationLevel;

			public Action<EntityInstance, List<EntityInstance>> entityCreatedCallback;
		}

		public struct EntityInstance
		{
			public Entity entity;

			public GameObject gameObject;
		}

		public Settings settings;

		private BSP bsp;

		private GameObject root;

		private List<EntityInstance> entityInstances = new List<EntityInstance>();

		private Dictionary<string, List<EntityInstance>> namedEntities = new Dictionary<string, List<EntityInstance>>();

		private Dictionary<string, Material> materialDirectory = new Dictionary<string, Material>();

		public static bool IsRuntime => true;

		public void LoadBSP()
		{
			if (string.IsNullOrEmpty(settings.path) || !File.Exists(settings.path))
			{
				Debug.LogError("Cannot import " + settings.path + ": The path is invalid.");
				return;
			}
			BSP bSP = new BSP(new FileInfo(settings.path));
			try
			{
				LoadBSP(bSP);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void LoadBSP(BSP bsp)
		{
			if (bsp == null)
			{
				Debug.LogError("Cannot import BSP: The object was null.");
				return;
			}
			this.bsp = bsp;
			for (int i = 0; i < bsp.Entities.Count; i++)
			{
				Entity entity = bsp.Entities[i];
				EntityInstance entityInstance = CreateEntityInstance(entity);
				entityInstances.Add(entityInstance);
				namedEntities[entity.Name].Add(entityInstance);
				if (entity.ModelNumber >= 0)
				{
					BuildMesh(entityInstance);
				}
				else
				{
					Vector3 angles = entity.Angles;
					entityInstance.gameObject.transform.rotation = Quaternion.Euler(0f - angles.x, angles.y, angles.z);
				}
				entityInstance.gameObject.transform.position = entity.Origin.SwizzleYZ().ScaleInch2Meter();
			}
			root = new GameObject(bsp.MapName);
			foreach (KeyValuePair<string, List<EntityInstance>> namedEntity in namedEntities)
			{
				SetUpEntityHierarchy(namedEntity.Value);
			}
			if (settings.entityCreatedCallback == null)
			{
				return;
			}
			foreach (EntityInstance entityInstance2 in entityInstances)
			{
				string text = entityInstance2.entity["target"];
				if (namedEntities.ContainsKey(text) && !string.IsNullOrEmpty(text))
				{
					settings.entityCreatedCallback(entityInstance2, namedEntities[text]);
				}
				else
				{
					settings.entityCreatedCallback(entityInstance2, new List<EntityInstance>(0));
				}
			}
		}

		private Texture2D LoadTextureAtPath(string texturePath, bool textureIsAsset)
		{
			if (texturePath.EndsWith(".tga"))
			{
				return TargaImage.LoadTargaImage(texturePath);
			}
			if (texturePath.EndsWith(".ftx"))
			{
				return FTXLoader.LoadFTX(texturePath);
			}
			Texture2D texture2D = new Texture2D(0, 0);
			texture2D.LoadImage(File.ReadAllBytes(texturePath));
			return texture2D;
		}

		public void LoadMaterial(string textureName)
		{
			Shader shader = Shader.Find("Standard");
			Shader shader2 = Shader.Find("VR/SpatialMapping/Wireframe");
			bool textureIsAsset = false;
			string text = ((!settings.texturePath.Contains(":")) ? Path.Combine(settings.texturePath, textureName).Replace('\\', '/') : Path.Combine(settings.texturePath, textureName).Replace('\\', '/'));
			Texture2D texture2D = null;
			try
			{
				if (File.Exists(text + ".png"))
				{
					texture2D = LoadTextureAtPath(text + ".png", textureIsAsset);
				}
				else if (File.Exists(text + ".jpg"))
				{
					texture2D = LoadTextureAtPath(text + ".jpg", textureIsAsset);
				}
				else if (File.Exists(text + ".tga"))
				{
					texture2D = LoadTextureAtPath(text + ".tga", textureIsAsset);
				}
				else if (File.Exists(text + ".ftx"))
				{
					texture2D = LoadTextureAtPath(text + ".ftx", textureIsAsset);
				}
			}
			catch
			{
			}
			if (texture2D == null)
			{
				Debug.LogWarning("Texture " + textureName + " could not be loaded (does the file exist?)");
			}
			Material material = null;
			material = new Material(shader)
			{
				name = textureName
			};
			if (0 == 0)
			{
				if (texture2D != null)
				{
					material.mainTexture = texture2D;
				}
				else if (shader2 != null)
				{
					material = new Material(shader2);
				}
			}
			materialDirectory[textureName] = material;
		}

		protected EntityInstance CreateEntityInstance(Entity entity)
		{
			if (!namedEntities.ContainsKey(entity.Name) || namedEntities[entity.Name] == null)
			{
				namedEntities[entity.Name] = new List<EntityInstance>();
			}
			return new EntityInstance
			{
				entity = entity,
				gameObject = new GameObject(entity.ClassName + ((!string.IsNullOrEmpty(entity.Name)) ? (" " + entity.Name) : string.Empty))
			};
		}

		protected void SetUpEntityHierarchy(List<EntityInstance> instances)
		{
			foreach (EntityInstance instance in instances)
			{
				SetUpEntityHierarchy(instance);
			}
		}

		protected void SetUpEntityHierarchy(EntityInstance instance)
		{
			if (!instance.entity.ContainsKey("parentname"))
			{
				instance.gameObject.transform.parent = root.transform;
			}
			else if (namedEntities.ContainsKey(instance.entity["parentname"]))
			{
				if (namedEntities[instance.entity["parentname"]].Count > 1)
				{
					Debug.LogWarning(string.Format("Entity \"{0}\" claims to have parent \"{1}\" but more than one matching entity exists.", instance.gameObject.name, instance.entity["parentname"]), instance.gameObject);
				}
				instance.gameObject.transform.parent = namedEntities[instance.entity["parentname"]][0].gameObject.transform;
			}
			else
			{
				Debug.LogWarning(string.Format("Entity \"{0}\" claims to have parent \"{1}\" but no such entity exists.", instance.gameObject.name, instance.entity["parentname"]), instance.gameObject);
			}
		}

		protected void BuildMesh(EntityInstance instance)
		{
			int modelNumber = instance.entity.ModelNumber;
			Model model = bsp.Models[modelNumber];
			Dictionary<string, List<Mesh>> dictionary = new Dictionary<string, List<Mesh>>();
			GameObject gameObject = instance.gameObject;
			List<Face> facesInModel = bsp.GetFacesInModel(model);
			int num = 0;
			for (num = 0; num < facesInModel.Count; num++)
			{
				Face face = facesInModel[num];
				if (face.NumEdgeIndices <= 0 && face.NumVertices <= 0)
				{
					continue;
				}
				int textureIndex = bsp.GetTextureIndex(face);
				string text = "";
				if (textureIndex >= 0)
				{
					text = LibBSP.Texture.SanitizeName(bsp.Textures[textureIndex].Name, bsp.MapType);
					if (!dictionary.ContainsKey(text) || dictionary[text] == null)
					{
						dictionary[text] = new List<Mesh>();
					}
					dictionary[text].Add(CreateFaceMesh(face, text));
				}
			}
			if (modelNumber == 0 && bsp.LODTerrains != null)
			{
				foreach (LODTerrain lODTerrain in bsp.LODTerrains)
				{
					if (lODTerrain.TextureIndex >= 0)
					{
						string name = bsp.Textures[lODTerrain.TextureIndex].Name;
						if (!dictionary.ContainsKey(name) || dictionary[name] == null)
						{
							dictionary[name] = new List<Mesh>();
						}
						dictionary[name].Add(CreateLoDTerrainMesh(lODTerrain, name));
					}
				}
			}
			if (settings.meshCombineOptions != MeshCombineOptions.None)
			{
				Mesh[] array = new Mesh[dictionary.Count];
				Material[] array2 = new Material[array.Length];
				num = 0;
				foreach (KeyValuePair<string, List<Mesh>> item in dictionary)
				{
					array[num] = MeshUtils.CombineAllMeshes(item.Value.ToArray(), mergeSubMeshes: true, useMatrices: false);
					if (array[num].vertices.Length == 0)
					{
						continue;
					}
					if (materialDirectory.ContainsKey(item.Key))
					{
						array2[num] = materialDirectory[item.Key];
					}
					if (settings.meshCombineOptions == MeshCombineOptions.PerMaterial)
					{
						GameObject gameObject2 = new GameObject(item.Key);
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = Vector3.zero;
						if (array[num].normals.Length == 0 || array[num].normals[0] == Vector3.zero)
						{
							array[num].RecalculateNormals();
						}
						array[num].AddMeshToGameObject(new Material[1] { array2[num] }, gameObject2);
					}
					num++;
				}
				if (settings.meshCombineOptions == MeshCombineOptions.PerMaterial)
				{
					return;
				}
				Mesh mesh = MeshUtils.CombineAllMeshes(array, mergeSubMeshes: false, useMatrices: false);
				if (mesh.vertices.Length != 0)
				{
					mesh.TransformVertices(gameObject.transform.localToWorldMatrix);
					if (mesh.normals.Length == 0 || mesh.normals[0] == Vector3.zero)
					{
						mesh.RecalculateNormals();
					}
					mesh.AddMeshToGameObject(array2, gameObject);
				}
				return;
			}
			num = 0;
			foreach (KeyValuePair<string, List<Mesh>> item2 in dictionary)
			{
				GameObject gameObject3 = new GameObject(item2.Key);
				gameObject3.transform.parent = gameObject.transform;
				gameObject3.transform.localPosition = Vector3.zero;
				Material material = materialDirectory[item2.Key];
				foreach (Mesh item3 in item2.Value)
				{
					if (item3.vertices.Length != 0)
					{
						GameObject gameObject4 = new GameObject("Face");
						gameObject4.transform.parent = gameObject3.transform;
						gameObject4.transform.localPosition = Vector3.zero;
						if (item3.normals.Length == 0 || item3.normals[0] == Vector3.zero)
						{
							item3.RecalculateNormals();
						}
						item3.AddMeshToGameObject(new Material[1] { material }, gameObject4);
					}
				}
				num++;
			}
		}

		protected Mesh CreateFaceMesh(Face face, string textureName)
		{
			if (!materialDirectory.ContainsKey(textureName))
			{
				LoadMaterial(textureName);
			}
			Vector2 dims = ((!materialDirectory[textureName].HasProperty("_MainTex") || !(materialDirectory[textureName].mainTexture != null)) ? new Vector2(128f, 128f) : new Vector2(materialDirectory[textureName].mainTexture.width, materialDirectory[textureName].mainTexture.height));
			if (face.DisplacementIndex >= 0)
			{
				return MeshUtils.CreateDisplacementMesh(bsp, face, dims);
			}
			return MeshUtils.CreateFaceMesh(bsp, face, dims, settings.curveTessellationLevel);
		}

		protected Mesh CreateLoDTerrainMesh(LODTerrain lodTerrain, string textureName)
		{
			if (!materialDirectory.ContainsKey(textureName))
			{
				LoadMaterial(textureName);
			}
			return MeshUtils.CreateMoHAATerrainMesh(bsp, lodTerrain);
		}
	}
}
