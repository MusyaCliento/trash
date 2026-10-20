using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UI_ObjectiveViewer : MonoBehaviour
{
	public class Objective
	{
		public string id;

		public string title;

		public string desc;

		public GameObject assetObject;

		public void SpawnAssetObject()
		{
			assetObject = Object.Instantiate(instance.objectiveAsset, instance.objectiveParent);
			assetObject.transform.DOPunchScale(Vector3.one * 0.1f, 0.5f);
		}

		public void PunchAssetObject()
		{
			DOTween.Complete(assetObject.transform);
			assetObject.transform.DOPunchScale(Vector3.one * 0.1f, 0.5f);
		}
	}

	private static Dictionary<string, Objective> objectiveDict;

	public Transform objectiveParent;

	public GameObject objectiveAsset;

	private static UI_ObjectiveViewer instance;

	public AudioClip objectiveEarnSound;

	public TMP_Text objectiveViewerTitle;

	private void Awake()
	{
		instance = this;
		objectiveDict = new Dictionary<string, Objective>();
		base.gameObject.SetActive(value: false);
	}

	public void ShowViewer()
	{
		base.gameObject.SetActive(value: true);
	}

	public void HideViewer()
	{
		base.gameObject.SetActive(value: false);
	}

	public static void CreateOrUpdateObjective(string id, string title, string desc, bool punch = false)
	{
		if (!(instance == null))
		{
			if (!objectiveDict.ContainsKey(id))
			{
				Objective objective = new Objective();
				objective.id = id;
				objective.title = title;
				objective.desc = desc;
				objective.assetObject = Object.Instantiate(instance.objectiveAsset, instance.objectiveParent);
				objectiveDict.Add(id, objective);
			}
			string text = title + "\n";
			objectiveDict[id].assetObject.GetComponent<TMP_Text>().text = text + desc;
			instance.ShowViewer();
			if (punch)
			{
				objectiveDict[id].PunchAssetObject();
			}
			instance.GetComponent<RectTransform>().sizeDelta = instance.objectiveParent.GetComponent<RectTransform>().sizeDelta;
		}
	}

	public static void RemoveObjective(string id)
	{
		if (!(instance == null) && objectiveDict.ContainsKey(id))
		{
			Object.Destroy(objectiveDict[id].assetObject);
			objectiveDict.Remove(id);
		}
	}

	public static void ClearAllObjectives()
	{
		KeyValuePair<string, Objective>[] array = objectiveDict.ToArray();
		foreach (KeyValuePair<string, Objective> keyValuePair in array)
		{
			RemoveObjective(keyValuePair.Key);
		}
	}

	public static void PlayEarnSound()
	{
		if (!(instance == null))
		{
			AudioManager.PlayUISound(instance.objectiveEarnSound);
		}
	}

	public static void SetTitle(string s)
	{
		Debug.Log("Setting Title: " + s + " :: " + instance);
		if (!(instance == null))
		{
			instance.objectiveViewerTitle.text = s;
		}
	}
}
