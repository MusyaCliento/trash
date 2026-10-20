using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UT_ProceduralHandholdGenerator : MonoBehaviour
{
	public string geoAffix;

	public float maxAngle = 70f;

	public string handholdName = "handhold:basic:generated-collider";

	public bool allAxis;

	public bool handholdDirectionalLimiters;

	public float directionalLimiterMaxAngle = 90f;

	public LayerMask generationLayers;

	public List<MeshCollider> meshColliders = new List<MeshCollider>();

	public List<CL_Handhold> handholdComponents = new List<CL_Handhold>();

	public void GenerateHandholds()
	{
		foreach (MeshCollider meshCollider in meshColliders)
		{
			if (meshCollider != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(meshCollider.gameObject);
				}
				else
				{
					Object.DestroyImmediate(meshCollider.gameObject);
				}
			}
		}
		meshColliders = new List<MeshCollider>();
		handholdComponents = new List<CL_Handhold>();
		if (allAxis)
		{
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, Vector3.up, generationLayers, maxAngle, geoAffix + "_up", saveGeneratedData: true, handholdName));
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, -Vector3.up, generationLayers, maxAngle, geoAffix + "_down", saveGeneratedData: true, handholdName));
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, Vector3.right, generationLayers, maxAngle, geoAffix + "_right", saveGeneratedData: true, handholdName));
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, -Vector3.right, generationLayers, maxAngle, geoAffix + "_left", saveGeneratedData: true, handholdName));
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, Vector3.forward, generationLayers, maxAngle, geoAffix + "_forward", saveGeneratedData: true, handholdName));
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, -Vector3.forward, generationLayers, maxAngle, geoAffix + "_backwards", saveGeneratedData: true, handholdName));
		}
		else
		{
			meshColliders.Add(HandholdGenerator.Generate(base.gameObject, Vector3.up, generationLayers, maxAngle, geoAffix));
		}
		for (int i = 0; i < meshColliders.Count; i++)
		{
			handholdComponents.Add(meshColliders[i].AddComponent<CL_Handhold>());
			if (!handholdDirectionalLimiters)
			{
				continue;
			}
			HandholdModule_LimitDirection handholdModule_LimitDirection = new HandholdModule_LimitDirection();
			Vector3 normal = Vector3.up;
			if (allAxis)
			{
				switch (i)
				{
				case 0:
					normal = Vector3.up;
					break;
				case 1:
					normal = -Vector3.up;
					break;
				case 2:
					normal = Vector3.right;
					break;
				case 3:
					normal = -Vector3.right;
					break;
				case 4:
					normal = Vector3.forward;
					break;
				case 5:
					normal = -Vector3.forward;
					break;
				}
			}
			handholdModule_LimitDirection.normal = normal;
			handholdModule_LimitDirection.maxAngle = directionalLimiterMaxAngle;
			handholdComponents[i].modules = new List<HandholdModule> { handholdModule_LimitDirection };
		}
	}
}
