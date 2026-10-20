using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_ChamberLoader : MonoBehaviourGizmos
{
	public List<M_Chamber> chambers;

	public bool hideWorldOnLoad = true;

	private M_Chamber spawnedChamber;

	private Vector3 exitPlayerPosition;

	private Quaternion exitPlayerRotation;

	public UnityEvent enterEvent;

	public UnityEvent leaveEvent;

	public bool destroyChamberOnExit = true;

	public bool teleportPlayerToChamberSpawn = true;

	private void OnDestroy()
	{
		if (spawnedChamber != null)
		{
			Object.Destroy(spawnedChamber.gameObject);
		}
	}

	public void LoadChamber()
	{
		spawnedChamber = Object.Instantiate(chambers[Random.Range(0, chambers.Count)], base.transform.position, Quaternion.identity, null);
		spawnedChamber.SetParentLoader(this);
		spawnedChamber.gameObject.SetActive(value: false);
		WorldLoader.instance?.GetHandholdManager()?.LoadHandholds(spawnedChamber.gameObject);
	}

	public void EnterChamber()
	{
		exitPlayerPosition = ENT_Player.playerObject.transform.position;
		exitPlayerRotation = ENT_Player.playerObject.transform.rotation;
		if (spawnedChamber == null)
		{
			LoadChamber();
		}
		if (spawnedChamber.playerSpawn != null)
		{
			Debug.Log(spawnedChamber.playerSpawn.position);
			if (teleportPlayerToChamberSpawn)
			{
				ENT_Player.playerObject.Teleport(spawnedChamber.playerSpawn.position, spawnedChamber.playerSpawn.rotation);
			}
		}
		Debug.Log(ENT_Player.playerObject.transform.position);
		spawnedChamber.EnterChamber();
		WorldLoader.HideWorld();
		spawnedChamber.gameObject.SetActive(value: true);
		enterEvent.Invoke();
	}

	public void LeaveChamber()
	{
		WorldLoader.ShowWorld();
		ENT_Player.playerObject.Teleport(exitPlayerPosition, exitPlayerRotation);
		leaveEvent.Invoke();
		if (destroyChamberOnExit)
		{
			Object.Destroy(spawnedChamber.gameObject);
		}
		else
		{
			spawnedChamber.gameObject.SetActive(value: false);
		}
	}
}
