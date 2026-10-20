using Drawing;
using UnityEngine;

public class UT_ForceZone : UT_TriggerBase<UT_TriggerComponent<GameEntity>>
{
	public Vector3 force;

	private Vector3 curForce;

	public bool active = true;

	public bool radialForce;

	public string forceType = "";

	public bool fadeByDistance;

	public float distanceFadeAmount;

	public AnimationCurve fadeCurve;

	private float forceMult = 1f;

	public float forceLerpAcceleration = 1f;

	public bool preventPlayerGrab;

	public bool allowDropHangResist = true;

	public float preventPlayerGrabCooldown;

	public bool useAudio;

	public AudioSource audioSource;

	public float audioVolume;

	internal override void Start()
	{
		curForce = force;
		base.Start();
	}

	internal override void FixedUpdate()
	{
		if (CL_GameManager.gMan.isPaused || !active)
		{
			return;
		}
		bool flag = false;
		curForce = Vector3.Lerp(curForce, force * forceMult, forceLerpAcceleration * Time.fixedDeltaTime);
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			GameEntity other = triggerObjects[i].other;
			if (other == null)
			{
				triggerObjects.RemoveAt(i--);
				continue;
			}
			ObjectTagger tagger = other.GetTagger();
			if (tagger.HasTag("IgnoreForce") || !tagger.HasTagInList(triggerTags))
			{
				continue;
			}
			float num = Vector3.Distance(other.transform.position, base.transform.position);
			float num2 = 1f;
			if (fadeByDistance)
			{
				num2 = 1f - num / distanceFadeAmount;
				num2 = fadeCurve.Evaluate(num2);
			}
			Vector3 vector = base.transform.TransformVector(curForce) * Time.fixedDeltaTime * num2;
			if (radialForce)
			{
				vector = (base.transform.position - other.transform.position) * curForce.y * Time.fixedDeltaTime * num2;
			}
			if (tagger.HasTag("Player"))
			{
				other.AddForce(vector, forceType);
				if (preventPlayerGrab)
				{
					other.GetComponent<ENT_Player>().DropHang(preventPlayerGrabCooldown, 0f, cooldownOnlyOnHangingHands: false, "drop", allowDropHangResist);
				}
				flag = true;
			}
			else if (tagger.HasTag("Entity") || tagger.HasTag("Prop"))
			{
				other.AddForce(vector * 30f, forceType);
			}
		}
		if (flag && (bool)audioSource)
		{
			audioSource.volume = Mathf.Lerp(audioSource.volume, audioVolume * forceMult, Time.deltaTime);
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else if ((bool)audioSource)
		{
			audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime);
			if (audioSource.volume == 0f && audioSource.isPlaying)
			{
				audioSource.Pause();
			}
		}
		base.FixedUpdate();
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.TransformDirection(force), Vector3.up, 0.1f, new Color(1f, 0.92f, 0.016f, 1f));
			if (fadeByDistance)
			{
				Draw.Cross(base.transform.position - base.transform.TransformDirection(force.normalized) * distanceFadeAmount, Color.yellow);
				Draw.Cross(base.transform.position + base.transform.TransformDirection(force.normalized) * distanceFadeAmount, Color.yellow);
			}
		}
		else
		{
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.TransformDirection(force), Vector3.up, 0.1f, new Color(1f, 0.92f, 0.016f, 0.1f));
		}
	}

	public void SetForce(Vector3 f)
	{
		force = f;
	}

	public void MultForce(float m)
	{
		forceMult = m;
	}
}
