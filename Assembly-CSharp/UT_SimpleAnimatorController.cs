using UnityEngine;

public class UT_SimpleAnimatorController : MonoBehaviour
{
	private Animator animator;

	public float animatorSpeed = 1f;

	private void Start()
	{
		animator = GetComponent<Animator>();
		if (!(animator == null))
		{
			animator.keepAnimatorStateOnDisable = true;
			animator.speed = animatorSpeed;
		}
	}

	public void SetAnimatorBool(string s)
	{
		if (animator == null)
		{
			animator = GetComponent<Animator>();
			if (animator == null)
			{
				return;
			}
		}
		string[] array = s.Split(":");
		animator.SetBool(array[0], bool.Parse(array[1]));
	}
}
