using Drawing;
using UnityEngine;

public class FX_Metaball : MonoBehaviourGizmos
{
	[HideInInspector]
	public FX_MetaballManager.Ball ball;

	[HideInInspector]
	public FX_MetaballManager.System system;

	public float radius = 1f;

	private void OnEnable()
	{
		Refresh();
	}

	private void OnDisable()
	{
		FX_MetaballManager.BallDestroy(system, ball);
	}

	public void Refresh()
	{
		FX_MetaballManager.BallDestroy(system, ball);
		ball = FX_MetaballManager.BallCreate(system);
		FX_MetaballManager.BallXForm(system, ball, base.transform, Vector3.zero);
		FX_MetaballManager.BallRadius(system, ball, radius);
	}

	public override void DrawGizmos()
	{
		Draw.editor.WireSphere(base.transform.position, radius);
	}
}
