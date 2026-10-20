using Drawing;
using UnityEngine;

public class UT_Heater : MonoBehaviourGizmos
{
	private ENT_Player player;

	public float playerVicinity = 10f;

	public float heatRate = 0.5f;

	private BuffContainer freezingBuff;

	private void FixedUpdate()
	{
		if (!(CL_GameManager.gMan == null) && !(CL_GameManager.gMan.localPlayer == null))
		{
			if (player == null)
			{
				player = CL_GameManager.gMan.localPlayer;
			}
			if (!(DarkMachineFunctions.GetManhattanDistance(base.transform.position, ENT_Player.GetPlayer().transform.position) > playerVicinity))
			{
				Heat();
			}
		}
	}

	public void Heat()
	{
		if (freezingBuff == null)
		{
			if (player.curBuffs.HasBuffContainer("freezing"))
			{
				freezingBuff = player.curBuffs.GetBuffContainer("freezing");
			}
		}
		else
		{
			freezingBuff.SetMultiplier(Mathf.Clamp01(freezingBuff.GetMultiplier() - Time.deltaTime * heatRate));
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.2f, 0f, 0.25f));
		}
		else
		{
			Draw.SphereOutline(base.transform.position, playerVicinity, new Color(1f, 0.2f, 0f, 0.003f));
		}
	}
}
