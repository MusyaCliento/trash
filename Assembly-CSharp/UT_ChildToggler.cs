using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_ChildToggler : MonoBehaviour
{
	public float groupDelay;

	public bool randomizeEnable;

	public void SetChildActive(bool b)
	{
		List<GameObject> childrenObjects = new List<GameObject>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			childrenObjects.Add(base.transform.GetChild(i).gameObject);
		}
		if (randomizeEnable)
		{
			List<GameObject> list = new List<GameObject>();
			while (childrenObjects.Count > 0)
			{
				int index = Random.Range(0, childrenObjects.Count);
				list.Add(childrenObjects[index]);
				childrenObjects.RemoveAt(index);
			}
			childrenObjects.AddRange(list);
		}
		if (groupDelay > 0f)
		{
			StartCoroutine(ActiveSetter());
			return;
		}
		for (int j = 0; j < base.transform.childCount; j++)
		{
			base.transform.GetChild(j).gameObject.SetActive(b);
		}
		IEnumerator ActiveSetter()
		{
			foreach (GameObject item in childrenObjects)
			{
				item.SetActive(b);
				yield return new WaitForSeconds(groupDelay);
			}
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
