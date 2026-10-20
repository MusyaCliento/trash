using Pathfinding;
using UnityEngine;

public class UT_Navmesh : MonoBehaviour
{
	private MeshCollider meshCollider;

	private NavMeshGraph navmesh = new NavMeshGraph();

	private void Initialize()
	{
		if (meshCollider == null)
		{
			meshCollider = GetComponent<MeshCollider>();
		}
		navmesh.recalculateNormals = false;
		navmesh.sourceMesh = meshCollider.sharedMesh;
		navmesh.offset = base.transform.position;
		navmesh.rotation = base.transform.rotation.eulerAngles;
	}

	private void OnEnable()
	{
		Initialize();
		AstarPath.active.data.AddGraph(navmesh);
		AstarPath.active.Scan();
	}

	private void OnDisable()
	{
		if ((Object)(object)AstarPath.active != null && AstarPath.active.data != null)
		{
			AstarPath.active.data.RemoveGraph(navmesh);
			AstarPath.active.Scan();
		}
	}
}
