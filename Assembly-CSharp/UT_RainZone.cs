using Drawing;
using UnityEngine;

public class UT_RainZone : MonoBehaviourGizmos
{
	public Vector3 size = Vector3.one * 5f;

	private Bounds bounds = new Bounds(Vector3.zero, Vector3.one * 5f);

	public float wetAmount = 1f;

	private void Start()
	{
	}

	private void Update()
	{
		if (IsPlayerInZone())
		{
			ENT_Player.GetPlayer().AddEffect("wet", wetAmount);
		}
	}

	private bool IsPlayerInZone()
	{
		if (ENT_Player.GetPlayer() != null)
		{
			bounds.size = size;
			return bounds.Contains(base.transform.InverseTransformPoint(ENT_Player.GetPlayer().transform.position));
		}
		return false;
	}

	public float GetLowestPointInZone()
	{
		return base.transform.position.y - size.y / 2f;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			bounds.size = size;
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.yellow);
			Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(0.7f, 0.3f, 0.2f, 0.01f));
		}
		else
		{
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.yellow * 0.1f);
		}
	}
}
