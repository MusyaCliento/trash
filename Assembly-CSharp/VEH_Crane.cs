using Drawing;
using UnityEngine;

public class VEH_Crane : MonoBehaviourGizmos
{
	public float turnSpeed = 1f;

	private float curTurn;

	private float turnVelocity;

	public SpringJoint tether;

	public float reelSpeed = 2f;

	public float minDistance;

	public float maxDistance;

	private float curReel;

	private float tetherDistanceTarget;

	public AudioSource reelAudio;

	public AudioSource turnAudio;

	public bool limitTurn;

	public float minTurn;

	public float maxTurn;

	private float startAngle;

	private float curAngle;

	private Quaternion startRot;

	private void Start()
	{
		float num = Vector3.Distance(tether.transform.position, tether.connectedBody.transform.position);
		tether.minDistance = num;
		tether.maxDistance = num;
		tetherDistanceTarget = num;
		startAngle = base.transform.localRotation.eulerAngles.z;
		startRot = base.transform.localRotation;
		curAngle = 0f;
	}

	private void Update()
	{
		turnVelocity = Mathf.Lerp(turnVelocity, curTurn, Time.deltaTime * 2f);
		curAngle += turnVelocity * turnSpeed * Time.deltaTime;
		if (limitTurn)
		{
			curAngle = Mathf.Clamp(curAngle, minTurn, maxTurn);
		}
		Quaternion quaternion2 = Quaternion.Euler(0f, 0f, curAngle);
		base.transform.localRotation = startRot * quaternion2;
		tetherDistanceTarget += curReel * Time.deltaTime * reelSpeed;
		tetherDistanceTarget = Mathf.Clamp(tetherDistanceTarget, minDistance, maxDistance);
		tether.minDistance = tetherDistanceTarget;
		tether.maxDistance = tetherDistanceTarget;
		reelAudio.volume = Mathf.Lerp(reelAudio.volume, Mathf.Abs(curReel), Time.deltaTime);
		turnAudio.volume = Mathf.Lerp(turnAudio.volume, Mathf.Abs(curTurn), Time.deltaTime);
	}

	public void SetTurn(float f)
	{
		curTurn += f;
	}

	public void SetReel(float f)
	{
		curReel += f;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this) && limitTurn)
		{
			float num = Mathf.Cos(minTurn * 2f * 0.00872665f);
			float num2 = Mathf.Sin(minTurn * 2f * 0.00872665f);
			float num3 = Mathf.Cos(maxTurn * 2f * 0.00872665f);
			float num4 = Mathf.Sin(maxTurn * 2f * 0.00872665f);
			Draw.Line(base.transform.position, base.transform.position + base.transform.forward * 10f, Color.green);
			float num5 = 0.25f;
			Draw.DashedLine(base.transform.position, base.transform.position + (-base.transform.up * num + base.transform.right * num2).normalized * 10f, num5, num5, Color.yellow);
			Draw.DashedLine(base.transform.position, base.transform.position + (-base.transform.up * num3 + base.transform.right * num4).normalized * 10f, num5, num5, Color.yellow);
		}
	}
}
