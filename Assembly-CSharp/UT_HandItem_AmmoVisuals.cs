using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_HandItem_AmmoVisuals : MonoBehaviour
{
	[Serializable]
	public class AmmoStage
	{
		public int maxAmount;

		public UnityEvent enterEvent;

		public List<GameObject> visualGameObjects;
	}

	public HandItem_Shoot shooter;

	public List<AmmoStage> ammoStages;

	private AmmoStage currentStage;

	private void Start()
	{
		UpdateAmmoVisual(runEvents: false);
	}

	public void UpdateAmmoVisual()
	{
		UpdateAmmoVisual(true);
	}

	public void UpdateAmmoVisual(bool runEvents = true)
	{
		int ammo = shooter.GetAmmo();
		bool flag = false;
		foreach (AmmoStage ammoStage in ammoStages)
		{
			if (!flag && ammo <= ammoStage.maxAmount)
			{
				if (currentStage != ammoStage)
				{
					currentStage = ammoStage;
					if (runEvents)
					{
						currentStage.enterEvent.Invoke();
					}
				}
				flag = true;
				foreach (GameObject visualGameObject in ammoStage.visualGameObjects)
				{
					visualGameObject.SetActive(value: true);
				}
				continue;
			}
			foreach (GameObject visualGameObject2 in ammoStage.visualGameObjects)
			{
				visualGameObject2.SetActive(value: false);
			}
		}
	}
}
