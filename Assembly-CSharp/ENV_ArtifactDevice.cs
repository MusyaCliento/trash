using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ENV_ArtifactDevice : MonoBehaviour
{
	public List<Item_Object> artifacts;

	public List<Transform> artifactSpawners;

	private List<Item_Object> spawnedArtifacts = new List<Item_Object>();

	public GameObject zapEffect;

	public UnityEvent eventOnPickup;

	private void Start()
	{
		List<Item_Object> list = new List<Item_Object>();
		if (ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans"))
		{
			list.Add(CL_AssetManager.GetItemObjectPrefab("Item_Beans"));
			list.Add(CL_AssetManager.GetItemObjectPrefab("Item_Piton"));
		}
		else
		{
			list.AddRange(artifacts);
		}
		for (int i = 0; i < artifactSpawners.Count; i++)
		{
			Item_Object item_Object = list[UnityEngine.Random.Range(0, list.Count)];
			list.Remove(item_Object);
			Item_Object item_Object2 = UnityEngine.Object.Instantiate(item_Object, artifactSpawners[i].position, artifactSpawners[i].rotation);
			ObjectTagger objectTagger = item_Object2.GetComponent<ObjectTagger>();
			if (objectTagger == null)
			{
				objectTagger = item_Object2.AddComponent<ObjectTagger>();
			}
			objectTagger.AddTag("DontRemove");
			objectTagger.AddTag("ItemLocked");
			item_Object2.onFirstPickup = (Action<Item_Object>)Delegate.Combine(item_Object2.onFirstPickup, new Action<Item_Object>(OnPickup));
			item_Object2.GetComponent<Rigidbody>().isKinematic = true;
			item_Object2.transform.parent = base.transform;
			spawnedArtifacts.Add(item_Object2);
		}
	}

	private void OnPickup(Item_Object o)
	{
		Debug.Log("Picked up artifact: " + o.name);
		foreach (Item_Object spawnedArtifact in spawnedArtifacts)
		{
			if (!(o == spawnedArtifact))
			{
				spawnedArtifact.canPickup = false;
			}
		}
		StartCoroutine(Zap());
		ObjectTagger tagger = o.GetTagger();
		if (tagger != null)
		{
			tagger.RemoveTag("ItemLocked");
		}
		eventOnPickup.Invoke();
		IEnumerator Zap()
		{
			yield return new WaitForSeconds(1f);
			foreach (Item_Object spawnedArtifact2 in spawnedArtifacts)
			{
				if (!(o == spawnedArtifact2))
				{
					UnityEngine.Object.Instantiate(zapEffect, spawnedArtifact2.transform.position, spawnedArtifact2.transform.rotation);
					UnityEngine.Object.Destroy(spawnedArtifact2.gameObject);
					yield return new WaitForSeconds(0.3f);
				}
			}
		}
	}

	public void RemoveArtifacts()
	{
		foreach (Item_Object spawnedArtifact in spawnedArtifacts)
		{
			UnityEngine.Object.Destroy(spawnedArtifact.gameObject);
		}
		spawnedArtifacts.Clear();
	}
}
