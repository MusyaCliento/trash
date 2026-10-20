using System.Collections.Generic;
using UnityEngine;

public class UT_RandomChildActivator : MonoBehaviour
{
	public int minActive;

	public int maxActive = 1;

	private void Start()
	{
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			list.Add(base.transform.GetChild(i));
			base.transform.GetChild(i).gameObject.SetActive(value: false);
		}
		int a = Random.Range(minActive, maxActive + 1);
		a = Mathf.Min(a, list.Count);
		while (a > 0)
		{
			a--;
			int index = Random.Range(0, list.Count);
			list[index].gameObject.SetActive(value: true);
			list.RemoveAt(index);
		}
	}
}
