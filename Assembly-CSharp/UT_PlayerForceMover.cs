using Drawing;
using UnityEngine;

public class UT_PlayerForceMover : MonoBehaviourGizmos
{
	public bool active;

	public float activePlayerGravity = 1f;

	public float playerPullForce = 0.5f;

	public float playerDragMultiplier = 1f;

	public bool resetFallingDistance;

	public Transform targetPoint;

	public bool limitByDistance;

	public float distanceLimit = 10f;

	private void Start()
	{
		if (targetPoint == null)
		{
			targetPoint = base.transform;
		}
	}

	private void FixedUpdate()
	{
		if (active && (!limitByDistance || !(Vector3.Distance(targetPoint.position, ENT_Player.GetPlayer().transform.position) > distanceLimit)))
		{
			ENT_Player.GetPlayer().SetTempGravityMult(activePlayerGravity);
			ENT_Player.GetPlayer().SetTempFrictionMultiplier(playerDragMultiplier);
			ENT_Player.GetPlayer().AddForce(Vector3.ClampMagnitude(targetPoint.position - ENT_Player.GetPlayer().transform.position, 1f) * playerPullForce * Time.fixedDeltaTime);
			if (resetFallingDistance)
			{
				ENT_Player.GetPlayer().ResetFallingHeight();
			}
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			Vector3 position = base.transform.position;
			if (targetPoint != null)
			{
				position = targetPoint.position;
			}
			if (limitByDistance)
			{
				Draw.SphereOutline(position, distanceLimit);
			}
		}
	}
}
