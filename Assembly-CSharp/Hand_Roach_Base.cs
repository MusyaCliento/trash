using System;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Roach_Base : MonoBehaviour
{
	[Serializable]
	public class Personality
	{
		public string animBool;
	}

	public Animator animator;

	public HandItem handItem;

	public List<Personality> personalities;

	private void Start()
	{
		if (handItem == null)
		{
			handItem = GetComponent<HandItem>();
		}
		if (animator == null)
		{
			animator = GetComponent<Animator>();
		}
		string firstDataStringByType = handItem.item.GetFirstDataStringByType("personality");
		if (string.IsNullOrEmpty(firstDataStringByType))
		{
			Personality personality = personalities[UnityEngine.Random.Range(0, personalities.Count)];
			animator.SetBool(personality.animBool, value: true);
			handItem.item.SetFirstDataStringsofType("personality", personality.animBool);
		}
		else
		{
			animator.SetBool(firstDataStringByType, value: true);
		}
	}

	private void Update()
	{
		if (SettingsManager.settings.entomophobia && !animator.GetBool("Entomophobia"))
		{
			animator.SetBool("Entomophobia", value: true);
		}
		else if (!SettingsManager.settings.entomophobia && animator.GetBool("Entomophobia"))
		{
			animator.SetBool("Entomophobia", value: false);
		}
	}
}
