using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_SteeringObstacle : MonoBehaviourGizmos
{
	private Steering.SteeringEntity thisObstacle;

	public List<string> tags = new List<string> { "obstacle" };

	public float radius = 10f;

	private void OnEnable()
	{
		thisObstacle = Steering.AddSteeringEntity(base.gameObject.GetInstanceID().ToString(), tags, base.transform.position, radius);
	}

	private void OnDisable()
	{
		Steering.RemoveSteeringEntity(thisObstacle.id);
	}

	private void Update()
	{
		thisObstacle?.SetPosition(base.transform.position);
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.WireSphere(base.transform.position, radius, Color.yellow);
		}
		else
		{
			Draw.WireSphere(base.transform.position, radius, new Color(0.5f, 0.5f, 0.5f, 0.2f));
		}
	}
}
