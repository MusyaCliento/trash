using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_ATM : MonoBehaviour
{
	public List<DEN_Roach> roaches;

	public Transform spawnPosition;

	public float worthMultiplier = 2f;

	public float spawnForce = 2f;

	public float spawnRandomForce = 0.1f;

	public float spawnDelayMin = 0.3f;

	public float spawnDelayMax = 1f;

	public UnityEvent dispenseEvent;

	public UnityEvent finishEvent;

	public List<AudioClip> paySounds;

	public AudioClip startSound;

	public UT_InsertableFloppy inserter;

	public AudioClip finishSound;

	private int platRoaches;

	private int goldRoaches;

	private bool isRunningCoroutine;

	private void Update()
	{
		UpdateMayInsert();
	}

	private void UpdateMayInsert()
	{
		int num = platRoaches * 5 + goldRoaches;
		int num2 = CL_GameManager.GetRoaches(global: true) - num;
		bool flag = false;
		M_Gamemode currentGamemode = CL_GameManager.GetCurrentGamemode();
		if (currentGamemode != null)
		{
			flag = currentGamemode.IsCompetitive();
		}
		bool active = flag || num2 > 0;
		inserter.active = active;
	}

	public void PrepareInsertion(Item disk)
	{
		int num = Mathf.CeilToInt((float)disk.worth * worthMultiplier);
		if (!CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			num = Mathf.Min(num, CL_GameManager.GetRoaches(global: true));
		}
		while (num > 0)
		{
			if (Random.value > 0.25f && num > 5)
			{
				platRoaches++;
				num -= 5;
			}
			else
			{
				goldRoaches++;
				num--;
			}
		}
		UpdateMayInsert();
	}

	public void OnInserted()
	{
		if (!isRunningCoroutine)
		{
			isRunningCoroutine = true;
			StartCoroutine(SpawnRoach());
		}
		IEnumerator SpawnRoach()
		{
			yield return new WaitForSeconds(0.4f);
			AudioManager.PlaySound(startSound, spawnPosition.position);
			yield return new WaitForSeconds(1f);
			while (goldRoaches > 0 || platRoaches > 0)
			{
				yield return new WaitForSeconds(Random.Range(spawnDelayMin, spawnDelayMax));
				int num = CL_GameManager.GetRoaches(global: true);
				if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
				{
					num = 9999;
				}
				int num2 = 0;
				int num3 = 0;
				bool flag = Random.value > 0.5f;
				if (num2 == 0 && flag && platRoaches > 0 && num >= 5)
				{
					num2 = 2;
					num3 = 5;
					platRoaches--;
				}
				if (num2 == 0 && goldRoaches > 0 && num >= 1)
				{
					num2 = 1;
					num3 = 1;
					goldRoaches--;
				}
				if (num2 == 0)
				{
					goldRoaches = Mathf.Max(goldRoaches - 1, 0);
					platRoaches = Mathf.Max(platRoaches - 1, 0);
				}
				if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
				{
					num3 = 0;
				}
				CL_GameManager.AddRoaches(-num3, global: true);
				DEN_Roach dEN_Roach = Object.Instantiate(roaches[num2], spawnPosition);
				dEN_Roach.transform.position = spawnPosition.position;
				dEN_Roach.AddForce((spawnPosition.forward + Random.insideUnitSphere * spawnRandomForce).normalized * spawnForce);
				AudioManager.PlaySound(paySounds[Random.Range(0, paySounds.Count)], spawnPosition.position);
				dispenseEvent.Invoke();
			}
			yield return new WaitForSeconds(1f);
			AudioManager.PlaySound(finishSound, spawnPosition.position);
			isRunningCoroutine = false;
		}
	}
}
