using System.Collections.Generic;
using UnityEngine;

public class Sample_DataManager : MonoBehaviour
{
	[SerializeField]
	private List<DataClass> dataClasses;

	private void Start()
	{
		for (int i = 0; i < 100; i++)
		{
			GetRandomDataClass();
		}
	}

	public DataClass GetRandomDataClass()
	{
		float num = 0f;
		foreach (DataClass dataClass in dataClasses)
		{
			num += dataClass.chance;
		}
		float num2 = Random.Range(0f, num);
		float num3 = 0f;
		foreach (DataClass dataClass2 in dataClasses)
		{
			num3 += dataClass2.chance;
			if (num2 <= num3)
			{
				Debug.Log(dataClass2.name);
				return dataClass2;
			}
		}
		return null;
	}
}
