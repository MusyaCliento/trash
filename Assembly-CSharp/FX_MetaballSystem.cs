using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class FX_MetaballSystem : MonoBehaviourGizmos
{
	public Vector3Int dimensions = new Vector3Int(100, 100, 100);

	public float cellsPerMeter = 1f;

	public int maxBalls = 150;

	public List<FX_Metaball> balls;

	public Material material;

	[HideInInspector]
	public FX_MetaballManager.System system;

	private void OnEnable()
	{
		Refresh();
	}

	private void OnDisable()
	{
		FX_MetaballManager.SystemDestroy(system);
	}

	public Bounds LocalBoundsMeter()
	{
		return new Bounds(Vector3.zero, (Vector3)dimensions * cellsPerMeter);
	}

	public void Refresh()
	{
		FX_MetaballManager.SystemDestroy(system);
		system = FX_MetaballManager.SystemCreate(dimensions, cellsPerMeter, base.transform, material, Mathf.Max(balls.Count, maxBalls));
		for (int i = 0; i < balls.Count; i++)
		{
			balls[i].system = system;
			balls[i].Refresh();
		}
	}

	public override void DrawGizmos()
	{
		Vector3 vector = dimensions;
		for (int i = 0; i < 3; i++)
		{
			vector[i] *= cellsPerMeter;
		}
		Draw.editor.PushMatrix(base.transform.localToWorldMatrix);
		Draw.editor.WireBox(Vector3.zero, vector);
		Draw.editor.PopMatrix();
	}
}
