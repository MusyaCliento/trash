using System.Collections.Generic;
using UnityEngine;

public class UT_SpawnEntity : MonoBehaviour
{
	public bool spawnOnStart;

	public GameObject spawnObject;

	public Transform customParent;

	public bool parentToThis = true;

	private Mesh gizmoMesh;

	public bool forceKinematicIfRigidbody;

	[Header("Randomizer")]
	public float randomizeOffset;

	public float randomizeRotation;

	public List<GameObject> randomizeObjects;

	private void Start()
	{
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		if (randomizeObjects != null && randomizeObjects.Count > 0)
		{
			SpawnCustom(randomizeObjects[Random.Range(0, randomizeObjects.Count)]);
		}
		else
		{
			SpawnCustom(spawnObject);
		}
	}

	public void SpawnCustom(GameObject g)
	{
		Transform parent = base.transform;
		if (!parentToThis)
		{
			parent = null;
		}
		if ((bool)customParent)
		{
			parent = customParent;
		}
		Vector3 vector = Random.insideUnitSphere * randomizeOffset;
		Quaternion quaternion = Quaternion.Euler(Random.insideUnitSphere * randomizeRotation);
		GameObject gameObject = Object.Instantiate(g, base.transform.position + vector, base.transform.rotation * quaternion, parent);
		if (forceKinematicIfRigidbody)
		{
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
			}
		}
	}

	private void OnValidate()
	{
		if (spawnObject == null)
		{
			gizmoMesh = null;
			return;
		}
		if (spawnObject.GetComponentInChildren<MeshFilter>() != null)
		{
			gizmoMesh = spawnObject.GetComponentInChildren<MeshFilter>().sharedMesh;
			return;
		}
		SkinnedMeshRenderer componentInChildren = spawnObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			gizmoMesh = componentInChildren.sharedMesh;
		}
		else
		{
			gizmoMesh = null;
		}
	}

	private void OnDrawGizmos()
	{
		if ((object)gizmoMesh == null)
		{
			gizmoMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
		}
		Gizmos.color = Color.yellow;
		Gizmos.DrawMesh(gizmoMesh, base.transform.position, base.transform.rotation);
		Gizmos.DrawWireSphere(base.transform.position, randomizeOffset);
	}
}
