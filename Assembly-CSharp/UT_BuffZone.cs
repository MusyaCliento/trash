using Drawing;
using UnityEngine;

public class UT_BuffZone : MonoBehaviourGizmos
{
	public Bounds bounds;

	public FXManager.FXData fxData;

	public float blendDistance = 0.1f;

	public bool buffPlayer;

	public BuffContainer buffContainer;

	private void Update()
	{
		CheckForPlayer();
	}

	private void CheckForPlayer()
	{
		if (!(ENT_Player.playerObject == null))
		{
			if (IsPositionInZone(ENT_Player.GetPlayer().transform.position) && buffPlayer && buffContainer != null)
			{
				buffContainer.buffTime = 1f;
				ENT_Player.GetPlayer().Buff(buffContainer);
			}
			float num = Mathf.Sqrt(bounds.SqrDistance(base.transform.InverseTransformPoint(ENT_Player.GetPlayer().cam.transform.position))) + blendDistance / 2f;
			float blend = 1f - Mathf.Clamp01(num / blendDistance);
			FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
			fXZoneStore.blend = blend;
			fXZoneStore.priority = 15;
			fXZoneStore.data = fxData;
			FXManager.fxZones.Enqueue(fXZoneStore, 50);
			_ = ENT_Player.GetPlayer().transform.position - new Vector3(0f, ENT_Player.GetPlayer().cCon.height / 2f, 0f);
		}
	}

	public bool IsPositionInZone(Vector3 position)
	{
		return bounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.red);
		Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(1f, 0f, 0f, 0.01f));
	}

	public Vector3 ClampPositionToSwimZone(Vector3 position)
	{
		return base.transform.TransformPoint(bounds.ClosestPoint(base.transform.InverseTransformPoint(position)));
	}
}
