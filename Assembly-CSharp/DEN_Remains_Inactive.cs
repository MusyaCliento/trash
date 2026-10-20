using UnityEngine;

public class DEN_Remains_Inactive : MonoBehaviour
{
	public Animator anim;

	[Range(0f, 15f)]
	public int clip;

	public bool onlyPlayWhenInInventory;

	public bool onlyPlayWhenLookingAway;

	public float minimumPlayDistance;

	public bool canLookAtPlayer;

	public UT_LookatPlayer lookatPlayer;

	public AvatarMask mask;

	private void Start()
	{
		SetPoseToClip();
	}

	private void Update()
	{
		bool flag = true;
		if (onlyPlayWhenInInventory && !Inventory.instance.showingInventory)
		{
			flag = false;
		}
		if (onlyPlayWhenLookingAway && !ENT_Player.GetPlayer().camRoot.CanSeeTarget(base.transform))
		{
			flag = false;
		}
		if (flag)
		{
			anim.speed = 1f;
			if (canLookAtPlayer)
			{
				anim.SetLayerWeight(2, 0f);
			}
			else
			{
				anim.SetLayerWeight(2, 1f);
			}
		}
		else
		{
			anim.speed = 0f;
		}
	}

	public void SetPoseToClip()
	{
		if (anim == null)
		{
			anim = GetComponent<Animator>();
		}
		AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
		if (clip >= animationClips.Length)
		{
			clip = animationClips.Length - 1;
		}
		anim.Play(animationClips[clip].name, 1);
		anim.Play(animationClips[clip].name, 2);
		anim.Update(0.1f);
	}
}
