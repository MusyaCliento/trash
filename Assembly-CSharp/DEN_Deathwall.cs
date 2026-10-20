using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Deathwall : MonoBehaviourGizmos
{
	[Serializable]
	public class PathPoint
	{
		public Transform transform;

		public float speedMult = 1f;

		public List<DEN_Deathwall> nextDeathwalls;

		public UnityEvent onReached;
	}

	public float speed = 1f;

	public List<PathPoint> points;

	public override void DrawGizmos()
	{
		DrawPath(ref Draw.editor);
	}

	private void DrawPath(ref CommandBuilder builder)
	{
		Vector3 position = base.transform.position;
		float headSize = 0.5f;
		int num = 0;
		while (points != null && num < points.Count)
		{
			PathPoint pathPoint = points[num];
			if (!(pathPoint.transform == null))
			{
				Vector3 position2 = pathPoint.transform.position;
				float num2 = Vector3.Distance(position, position2) / (speed * pathPoint.speedMult);
				builder.Arrow(position, position2, Vector3.up, headSize);
				builder.Label2D((position + position2) / 2f + Vector3.up, $"{num2:N3}s");
				foreach (DEN_Deathwall nextDeathwall in pathPoint.nextDeathwalls)
				{
					if (nextDeathwall != null)
					{
						builder.DashedLine(position2, nextDeathwall.transform.position, 0.3f, 0.3f);
					}
				}
				DarkMachineFunctions.RenderUnityEvent(ref builder, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
				{
					new DarkMachineFunctions.RenderUnityEventDesc
					{
						ev = pathPoint.onReached
					}
				});
			}
			num++;
		}
	}
}
