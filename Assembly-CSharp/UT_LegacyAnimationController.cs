using UnityEngine;

public class UT_LegacyAnimationController : MonoBehaviour
{
	private Animation anim;

	public bool playOnStart;

	private void Start()
	{
		anim = GetComponent<Animation>();
		if (playOnStart)
		{
			Play();
		}
	}

	public void Play()
	{
		if (anim == null)
		{
			anim = GetComponent<Animation>();
		}
		anim.Play();
	}
}
