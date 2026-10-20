using Drawing;
using UnityEngine;

public class UT_GravityZone : MonoBehaviourGizmos
{
	public float gravity;

	public float radius = 10f;

	public AnimationCurve falloff;

	private ENT_Player player;

	private bool playerInField;

	private void Update()
	{
		if (!(ENT_Player.playerObject == null))
		{
			if (player == null)
			{
				player = ENT_Player.playerObject;
			}
			float num = Vector3.Distance(base.transform.position, player.transform.position);
			if (!playerInField && num < radius)
			{
				playerInField = true;
			}
			else if (playerInField && num > radius)
			{
				player.SetGravityMult(1f);
				playerInField = false;
			}
			if (playerInField)
			{
				player.SetGravityMult(Mathf.Lerp(gravity, 1f, falloff.Evaluate(num / radius)));
			}
		}
	}

	public override void DrawGizmos()
	{
		Draw.SphereOutline(base.transform.position, 0.2f, Color.blue);
		if (GizmoContext.InSelection(this))
		{
			Draw.WireSphere(base.transform.position, radius, Color.cyan);
		}
		else
		{
			Draw.WireSphere(base.transform.position, radius, Color.cyan * new Color(1f, 1f, 1f, 0.05f));
		}
	}
}
