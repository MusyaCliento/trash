using Drawing;
using UnityEngine;

public class UT_AddForceToPlayer : MonoBehaviourGizmos
{
	public Vector3 force;

	public void AddForce()
	{
		ENT_Player.playerObject.AddForce(base.transform.InverseTransformVector(force));
	}

	public override void DrawGizmos()
	{
		Draw.SphereOutline(base.transform.position, 0.2f, Color.yellow);
		if (GizmoContext.InSelection(this))
		{
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.InverseTransformVector(force), Color.yellow);
		}
	}
}
