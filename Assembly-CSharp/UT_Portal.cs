using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_Portal : MonoBehaviourGizmos
{
	public Bounds bounds;

	private Bounds currentBounds;

	public List<GameObject> internalObjects;

	public List<GameObject> externalObjects;

	public List<UT_Portal> connectedPortals;

	private int updateTick;

	private void Start()
	{
		updateTick = Random.Range(0, 20);
		currentBounds = bounds;
	}

	private void Update()
	{
		currentBounds.center = base.transform.position;
		updateTick--;
		if (updateTick > 0)
		{
			return;
		}
		bool num = currentBounds.Contains(ENT_Player.GetPlayer().transform.position);
		updateTick = 10;
		if (num)
		{
			foreach (GameObject internalObject in internalObjects)
			{
				if (!internalObject.activeSelf)
				{
					internalObject.SetActive(value: true);
				}
			}
			{
				foreach (GameObject externalObject in externalObjects)
				{
					if (externalObject.activeSelf)
					{
						externalObject.SetActive(value: false);
					}
				}
				return;
			}
		}
		foreach (GameObject internalObject2 in internalObjects)
		{
			if (internalObject2.activeSelf)
			{
				internalObject2.SetActive(value: false);
			}
		}
		foreach (GameObject externalObject2 in externalObjects)
		{
			if (!externalObject2.activeSelf)
			{
				externalObject2.SetActive(value: true);
			}
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		GizmoContext.InSelection(this);
		bounds.center = base.transform.position;
		Draw.WireBox(bounds, Color.white);
		foreach (UT_Portal connectedPortal in connectedPortals)
		{
			Draw.Line(connectedPortal.transform.position, base.transform.position);
		}
	}
}
