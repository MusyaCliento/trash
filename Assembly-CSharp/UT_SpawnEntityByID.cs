using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[DefaultExecutionOrder(5)]
public class UT_SpawnEntityByID : MonoBehaviourGizmos, SaveableObject
{
	public bool spawnOnStart;

	public string idToSpawn;

	public string customDatabase;

	public Transform customParent;

	public bool forceKinematicIfRigidbody;

	public bool useCustomEntityData;

	public bool saveSpawnedObject = true;

	[TextArea]
	public List<string> entityData;

	public SpawnTable.SpawnSettings spawnSettings;

	private GameObject objectToSpawn;

	private Mesh gizmoMesh;

	private Matrix4x4 gizmoMeshTransformationMatrix;

	private Quaternion gizmoMeshRotation;

	private Vector3 gizmoMeshOffset;

	[HideInInspector]
	public bool hasSpawned;

	private bool spawning;

	public bool saveState;

	public string saveStateID = "";

	public bool loadStateIfDisk;

	public int respawnLimit = -1;

	public string respawnLimitFlagID = "";

	public float randomSpawnDelay = 0.5f;

	private void Start()
	{
		if (spawnOnStart && !hasSpawned)
		{
			Spawn();
		}
	}

	private void OnEnable()
	{
		if (spawning && !hasSpawned)
		{
			StopAllCoroutines();
			Spawn();
		}
	}

	public void Spawn()
	{
		if (spawnSettings.RandomCheck())
		{
			SpawnCustom(idToSpawn);
		}
	}

	public void SpawnCustom(string id)
	{
		spawning = true;
		StartCoroutine(WaitToSpawn());
		IEnumerator WaitToSpawn()
		{
			yield return new WaitForSeconds(Random.value * randomSpawnDelay);
			GameObject assetGameObject = CL_AssetManager.GetAssetGameObject(id, customDatabase);
			Transform parent = base.transform;
			if ((bool)customParent)
			{
				parent = customParent;
			}
			GameObject gameObject = Object.Instantiate(assetGameObject, base.transform.position, base.transform.rotation, parent);
			if (forceKinematicIfRigidbody)
			{
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				if (component != null)
				{
					component.isKinematic = true;
				}
			}
			if (gameObject.TryGetComponent<Item_Object>(out var component2))
			{
				if (useCustomEntityData)
				{
					component2.itemData.data = entityData;
				}
				component2.itemData.respawnLimitFlagID = respawnLimitFlagID;
				component2.itemData.respawnLimit = respawnLimit;
			}
			if (saveSpawnedObject)
			{
				GameEntity component3 = gameObject.GetComponent<GameEntity>();
				if (component3 != null)
				{
					component3.canSave = true;
				}
			}
			hasSpawned = true;
		}
	}

	public void RefreshGizmo()
	{
		if (CL_AssetManager.baseDatabase == null)
		{
			return;
		}
		objectToSpawn = CL_AssetManager.GetAssetGameObject(idToSpawn, customDatabase);
		if (objectToSpawn == null)
		{
			gizmoMesh = null;
			gizmoMeshTransformationMatrix = default(Matrix4x4);
			gizmoMeshOffset = Vector3.zero;
			gizmoMeshRotation = Quaternion.identity;
			return;
		}
		SkinnedMeshRenderer componentInChildren = objectToSpawn.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			if (componentInChildren != null)
			{
				gizmoMesh = componentInChildren.sharedMesh;
				gizmoMeshTransformationMatrix = componentInChildren.transform.worldToLocalMatrix;
				gizmoMeshOffset = objectToSpawn.transform.InverseTransformPoint(componentInChildren.transform.position);
				gizmoMeshRotation = Quaternion.Inverse(objectToSpawn.transform.rotation) * componentInChildren.transform.rotation;
			}
			else
			{
				gizmoMesh = null;
			}
		}
		else
		{
			MeshFilter componentInChildren2 = objectToSpawn.GetComponentInChildren<MeshFilter>();
			gizmoMesh = componentInChildren2.sharedMesh;
			gizmoMeshTransformationMatrix = componentInChildren2.transform.worldToLocalMatrix;
			gizmoMeshOffset = objectToSpawn.transform.InverseTransformPoint(componentInChildren2.transform.position);
			gizmoMeshRotation = Quaternion.Inverse(objectToSpawn.transform.rotation) * componentInChildren2.transform.rotation;
		}
	}

	private void OnDrawGizmos()
	{
		if ((object)gizmoMesh == null)
		{
			gizmoMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
		}
		Gizmos.color = Color.yellow;
		if (!(objectToSpawn == null))
		{
			if ((bool)objectToSpawn?.GetComponent<Item_Object>())
			{
				Gizmos.color = Color.magenta;
			}
			_ = gizmoMeshRotation;
			if (gizmoMesh != null)
			{
				Gizmos.DrawMesh(gizmoMesh, base.transform.TransformPoint(gizmoMeshOffset), base.transform.rotation * gizmoMeshRotation);
			}
		}
	}

	public override void DrawGizmos()
	{
		if (!(objectToSpawn == null))
		{
			bool flag = objectToSpawn?.GetComponent<Item_Object>();
			Color color = (flag ? Color.magenta : Color.yellow);
			if (GizmoContext.InSelection(this))
			{
				Draw.Label2D(base.transform.position + -Camera.current.transform.up * 0.3f, idToSpawn ?? "", 16f, LabelAlignment.TopCenter, color);
			}
			if (GizmoContext.InSelection(this) || DebugCore.showSpawnChances)
			{
				Draw.Label2D(base.transform.position + -Camera.current.transform.up * 0.7f, $"{spawnSettings.spawnChance * 100f}%", 16f, LabelAlignment.TopCenter, color);
			}
			if (DebugCore.showItems && flag)
			{
				Draw.SphereOutline(base.transform.position, 0.3f, Color.grey);
				Draw.SphereOutline(base.transform.position, 0.5f, Color.magenta);
			}
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.forward, color);
		}
	}

	public bool CanSave(string[] flags = null)
	{
		return saveState;
	}

	public string GetSaveID()
	{
		return saveStateID;
	}

	public SaveableInfo GetSaveInfo()
	{
		SaveableInfo result = new SaveableInfo
		{
			id = saveStateID,
			data = hasSpawned.ToString()
		};
		Debug.Log("Grabbing Save info from " + base.name + " :: " + saveStateID);
		return result;
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		if (loadStateIfDisk || flags == null || !flags.Contains("loadtype-disk"))
		{
			bool.TryParse(info.data, out hasSpawned);
			Debug.Log("Pushing save data into " + base.name + " Setting HasSpawned: " + info.data);
		}
	}
}
