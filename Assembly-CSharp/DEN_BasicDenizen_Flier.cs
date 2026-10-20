using UnityEngine;

public class DEN_BasicDenizen_Flier : DEN_BasicDenizen
{
	public AudioSource flyAudio;

	private float flyAudioTarget;

	public bool disableRotationOnDeath;

	public bool disableIfGrabbed;

	private CL_Handhold[] childHandholds;

	private Vector3 upVector;

	public override void Start()
	{
		base.Start();
		if (flyAudio != null)
		{
			flyAudioTarget = flyAudio.volume;
		}
		childHandholds = GetComponentsInChildren<CL_Handhold>();
	}

	public override void Update()
	{
		base.Update();
		upVector = Vector3.Lerp(upVector, base.transform.up, Time.deltaTime * 5f);
		if (dead && !disableRotationOnDeath)
		{
			if (movementModule.IsGrounded())
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(Vector3.ProjectOnPlane(base.transform.forward, Vector3.up), Vector3.up), Time.fixedDeltaTime * 5f);
				rigid.linearDamping = 1f;
				if (animator != null)
				{
					animator.SetBool(animGroundedBool, value: true);
				}
			}
			else if (rigid.linearVelocity.magnitude > 0.1f)
			{
				rigid.linearDamping = 0f;
				if (animator != null)
				{
					animator.SetBool(animGroundedBool, value: false);
				}
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(rigid.linearVelocity, Vector3.up), Time.fixedDeltaTime * 0.5f * rigid.linearVelocity.magnitude);
			}
		}
		else
		{
			bool flag = movementModule.IsGrounded();
			if (flyAudio != null)
			{
				flyAudio.volume = Mathf.Lerp(flyAudio.volume, flag ? 0f : flyAudioTarget, Time.fixedDeltaTime * 3f);
			}
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (flyAudio != null)
		{
			flyAudio.Stop();
		}
		base.Kill(type, damageInfo);
	}
}
