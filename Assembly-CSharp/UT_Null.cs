using System;
using System.Collections.Generic;
using UnityEngine;

public class UT_Null : MonoBehaviour
{
	public static Action<UT_Null> _OnAwake;

	public static Action<UT_Null> _OnDestroy;

	public string id;

	public List<string> data;

	private void Awake()
	{
		_OnAwake?.Invoke(this);
	}

	private void OnDestroy()
	{
		_OnDestroy?.Invoke(this);
	}
}
