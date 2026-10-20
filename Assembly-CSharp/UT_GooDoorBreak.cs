using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_GooDoorBreak : MonoBehaviourGizmos
{
	[Serializable]
	public class GooBreakStage
	{
		public List<GameObject> stageObject;

		public float breakHeight;

		public AudioClip breakSound;

		public float shakeAmount;

		public UnityEvent onBreakEvent;
	}

	public float gooBreakDistance = 1f;

	public List<GooBreakStage> gooBreakStages;

	private int currentBreakStage;

	private void Update()
	{
		if (DEN_DeathFloor.instance == null)
		{
			return;
		}
		float num = DEN_DeathFloor.instance.transform.position.y - base.transform.position.y;
		if (!(num > 0f - gooBreakDistance) || currentBreakStage >= gooBreakStages.Count - 1)
		{
			return;
		}
		float num2 = 0f - gooBreakDistance + gooBreakStages[currentBreakStage + 1].breakHeight;
		if (num > num2)
		{
			currentBreakStage++;
			if (gooBreakStages[currentBreakStage].breakSound != null)
			{
				AudioManager.PlaySound(gooBreakStages[currentBreakStage].breakSound, base.transform.position);
			}
			CL_CameraControl.ShakeAtPosition(base.transform.position, gooBreakStages[currentBreakStage].shakeAmount, 20f);
			gooBreakStages[currentBreakStage].onBreakEvent.Invoke();
		}
		for (int i = 0; i < gooBreakStages.Count; i++)
		{
			if (gooBreakStages[i] == null)
			{
				continue;
			}
			foreach (GameObject item in gooBreakStages[i].stageObject)
			{
				item.SetActive(i == currentBreakStage);
			}
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.Line(base.transform.position, base.transform.position + Vector3.down * gooBreakDistance, Color.green);
		for (int i = 0; i < gooBreakStages.Count; i++)
		{
			if (gooBreakStages[i] != null)
			{
				Draw.Cross(base.transform.position + Vector3.down * gooBreakDistance + Vector3.up * gooBreakStages[i].breakHeight, 0.5f, Color.red);
			}
		}
	}
}
