using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_Recycler : MonoBehaviour
{
	[Serializable]
	public class RecycleEvent
	{
		public List<string> eventTags;

		public UnityEvent recycleUnityEvent;
	}

	public bool active;

	public BoxCollider recycleZone;

	public float destroyRate = 1f;

	public float bounceRate = 0.5f;

	private float destroyTimer = 1f;

	private float bounceTimer;

	public float bounceForce = 5f;

	public float bounceSpin = 5f;

	public float addRoachWait = 3f;

	public float recycleRatio = 0.5f;

	public float roachRecycleRatio = 1.5f;

	public LayerMask mask;

	public UnityEvent recycleEvent;

	public UnityEvent cashEvent;

	public List<RecycleEvent> recycleEvents;

	private void Start()
	{
		destroyTimer = destroyRate;
	}

	private void Update()
	{
		if (!active)
		{
			return;
		}
		destroyTimer -= Time.deltaTime;
		bool flag = false;
		bool flag2 = false;
		Collider[] array = Physics.OverlapBox(recycleZone.transform.position, recycleZone.size / 2f, recycleZone.transform.rotation, mask);
		if (destroyTimer < 0f)
		{
			flag = true;
			destroyTimer = destroyRate;
		}
		bounceTimer -= Time.deltaTime;
		if (bounceTimer <= 0f)
		{
			bounceTimer = bounceRate;
			flag2 = true;
		}
		Collider[] array2;
		if (array.Length != 0)
		{
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].TryGetComponent<DEN_BasicDenizen_Flier>(out var component))
				{
					component.enabled = false;
				}
			}
		}
		bool flag3 = false;
		if (!flag && !flag2)
		{
			return;
		}
		Debug.Log(array.Length);
		if (array.Length == 0)
		{
			return;
		}
		array2 = array;
		foreach (Collider collider in array2)
		{
			Debug.Log(collider.gameObject.name);
			Rigidbody component2 = collider.GetComponent<Rigidbody>();
			ObjectTagger component3 = collider.GetComponent<ObjectTagger>();
			if (component3 != null && component3.HasTag("RecycleFit"))
			{
				if (component2 != null)
				{
					component2.isKinematic = true;
				}
				collider.transform.position = recycleZone.transform.position;
				collider.transform.rotation = recycleZone.transform.rotation;
			}
			if (flag)
			{
				Item_Object component4 = collider.GetComponent<Item_Object>();
				if (component4 != null)
				{
					if (!flag3)
					{
						int amount = Mathf.CeilToInt((float)component4.itemData.worth * recycleRatio);
						if (component4.itemData.HasTag("currency"))
						{
							amount = Mathf.CeilToInt((float)component4.itemData.worth * roachRecycleRatio);
							CL_ScoreManager.sessionScore.AddScore("Roaches Banked", "Roaches Banked", component4.itemData.worth * 20, 0f, component4.itemData.worth);
						}
						else if (component4.itemData.HasTag("disk"))
						{
							amount = Mathf.CeilToInt(component4.itemData.worth);
						}
						if (component3 != null && component3.HasTag("Can"))
						{
							CL_ScoreManager.sessionScore.AddScore("Cans Recycled", "Cans Recycled", 50f, 0f, 1);
						}
						StartCoroutine(WaitToAddRoaches(amount));
						component4.itemData.Destroy();
						recycleEvent.Invoke();
						flag3 = true;
						TriggerRecycleEventsFor(component3);
					}
				}
				else
				{
					GameEntity component5 = collider.GetComponent<GameEntity>();
					if (component5 != null && !flag3 && component5.Damage(Damageable.DamageInfo.CreateDamageInfo(5f, "recycler")))
					{
						recycleEvent.Invoke();
						flag3 = true;
						TriggerRecycleEventsFor(component3);
					}
				}
			}
			if (flag2 && component2 != null)
			{
				component2.AddForce(UnityEngine.Random.insideUnitSphere * bounceForce);
				component2.AddTorque(UnityEngine.Random.insideUnitSphere * bounceSpin);
			}
		}
		IEnumerator WaitToAddRoaches(int i2)
		{
			yield return new WaitForSeconds(addRoachWait);
			CL_GameManager.AddRoaches(i2);
			cashEvent.Invoke();
		}
	}

	private void TriggerRecycleEventsFor(ObjectTagger targetTagger)
	{
		foreach (RecycleEvent recycleEvent in recycleEvents)
		{
			if (targetTagger != null && targetTagger.HasTagInList(recycleEvent.eventTags.ToArray()))
			{
				recycleEvent.recycleUnityEvent.Invoke();
			}
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
