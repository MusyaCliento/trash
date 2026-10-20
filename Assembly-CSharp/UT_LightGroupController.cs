using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_LightGroupController : MonoBehaviour
{
	[Serializable]
	public class LightGroupAnimation
	{
		public enum EndEvent
		{
			none = 0,
			deactivate = 1
		}

		public string name;

		public float animationTime = 1f;

		public AnimationCurve animation;

		public EndEvent endEvent;
	}

	public List<LightGroupAnimation> lightGroupAnimations;

	private CL_Lamp[] lamps;

	public bool setOffAtStart;

	private void Start()
	{
		lamps = base.gameObject.GetComponentsInChildren<CL_Lamp>();
		if (setOffAtStart)
		{
			CL_Lamp[] array = lamps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].lampActive = false;
			}
		}
	}

	private void Update()
	{
	}

	public void PlayAnimation(string anim)
	{
		foreach (LightGroupAnimation lightGroupAnimation in lightGroupAnimations)
		{
			if (lightGroupAnimation.name == anim)
			{
				StartCoroutine(AnimationPlayer(lightGroupAnimation));
				break;
			}
		}
	}

	private IEnumerator AnimationPlayer(LightGroupAnimation animation)
	{
		float playbackTime = 0f;
		CL_Lamp[] array = lamps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].lampActive = true;
		}
		while (playbackTime < 1f)
		{
			playbackTime += Time.deltaTime / animation.animationTime;
			array = lamps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetIntensityMultiplier(animation.animation.Evaluate(playbackTime));
			}
			yield return null;
		}
		if (animation.endEvent == LightGroupAnimation.EndEvent.deactivate)
		{
			array = lamps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].lampActive = false;
			}
		}
	}
}
