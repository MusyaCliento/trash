using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HandholdManager : MonoBehaviour
{
	[Serializable]
	public class HandholdType
	{
		public string name;

		public GameObject prefab;

		public bool spawnPrefab;
	}

	public List<HandholdType> handholdTypes;

	private Dictionary<string, HandholdType> handholdDict = new Dictionary<string, HandholdType>();

	public List<CL_Handhold> handholds;

	public static HandholdManager instance;

	private void Start()
	{
		handholds = new List<CL_Handhold>();
		handholdDict = new Dictionary<string, HandholdType>();
		LoadHandholds(base.gameObject);
		instance = this;
	}

	public void LoadHandholdTypes()
	{
		foreach (HandholdType handholdType in handholdTypes)
		{
			handholdDict.Add(handholdType.name, handholdType);
		}
	}

	public void LoadHandholds(GameObject g)
	{
		if (handholdDict.Count == 0)
		{
			LoadHandholdTypes();
		}
		List<Transform> list = TraverseHierarchy(g.transform);
		List<Transform> list2 = new List<Transform>();
		foreach (Transform item in list)
		{
			string text = item.name;
			if (!text.Contains("handhold"))
			{
				continue;
			}
			string[] array = text.Split(':');
			GameObject gameObject = item.gameObject;
			HandholdType handholdType = handholdTypes[0];
			if (array != null && array.Length > 1)
			{
				if (!handholdDict.ContainsKey(array[1].Split('.')[0]))
				{
					continue;
				}
				handholdType = handholdDict[array[1].Split('.')[0]];
			}
			GameObject prefab = handholdType.prefab;
			if (handholdType.spawnPrefab)
			{
				UnityEngine.Object.Instantiate(handholdType.prefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform).transform.localRotation *= Quaternion.Euler(90f, 0f, 0f);
				continue;
			}
			gameObject.layer = prefab.layer;
			CopyComponents(prefab, gameObject);
			list2.Add(item);
		}
	}

	private List<Transform> TraverseHierarchy(Transform root)
	{
		List<Transform> list = new List<Transform>();
		list.Add(root);
		List<Transform> list2 = new List<Transform>();
		while (list.Count > 0)
		{
			Transform transform = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			foreach (Transform item in transform)
			{
				list.Add(item);
				list2.Add(item);
			}
		}
		return list2;
	}

	private void CopyComponents(GameObject source, GameObject target)
	{
		Component[] components = source.GetComponents<Component>();
		foreach (Component component in components)
		{
			if (!(component is Transform))
			{
				Component target2 = target.AddComponent(component.GetType());
				CopyFields(component, target2);
				CopyProperties(component, target2);
			}
		}
	}

	private void CopyFields(Component source, Component target)
	{
		FieldInfo[] fields = source.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			fieldInfo.SetValue(target, fieldInfo.GetValue(source));
		}
	}

	private void CopyProperties(Component source, Component target)
	{
		PropertyInfo[] properties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.CanWrite && propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
			{
				propertyInfo.SetValue(target, propertyInfo.GetValue(source, null), null);
			}
		}
	}

	private void Update()
	{
	}
}
