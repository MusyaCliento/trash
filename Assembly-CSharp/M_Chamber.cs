using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class M_Chamber : MonoBehaviourGizmos
{
	public Transform playerSpawn;

	public List<CL_GameManager.RichPresencePair> richPresenceOverride;

	private UT_ChamberLoader parentLoader;

	private CL_GameManager.RichPresenceMarker richPresence;

	private void OnEnable()
	{
		CL_GameManager._onPlayerDeath = (Action)Delegate.Combine(CL_GameManager._onPlayerDeath, new Action(LeaveChamber));
	}

	private void OnDisable()
	{
		CL_GameManager._onPlayerDeath = (Action)Delegate.Remove(CL_GameManager._onPlayerDeath, new Action(LeaveChamber));
	}

	public void SetParentLoader(UT_ChamberLoader p)
	{
		parentLoader = p;
	}

	public void EnterChamber()
	{
		WorldLoader.SetCurrentNonLevelParent(base.transform);
		if (richPresenceOverride != null && richPresenceOverride.Count > 0)
		{
			richPresence = CL_GameManager.RichPresencePush();
			for (int i = 0; i < richPresenceOverride.Count; i++)
			{
				CL_GameManager.RichPresencePair richPresencePair = richPresenceOverride[i];
				CL_GameManager.RichPresenceSet(richPresence, richPresencePair.key, richPresencePair.value);
			}
		}
	}

	public void LeaveChamber()
	{
		CL_GameManager.RichPresencePop(richPresence);
		if (parentLoader != null)
		{
			parentLoader.LeaveChamber();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public override void DrawGizmos()
	{
		if ((bool)playerSpawn)
		{
			Draw.WireCapsule(playerSpawn.position - Vector3.up * 0.75f, playerSpawn.position + Vector3.up * 0.75f, 0.5f, Color.red);
		}
	}
}
