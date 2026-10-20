using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_LookatPlayer : MonoBehaviourGizmos, Activatable
{
	public bool active = true;

	public float lookSpeed = 1f;

	public bool limitAngle;

	public float maxAngle = 90f;

	public float maxRange = 15f;

	public UnityEvent onPlayerLeaveCone;

	public UnityEvent onPlayerEnterCone;

	public Vector3 parentUpVector = Vector3.up;

	private bool canSeePlayer;

	public bool useLateUpdate;

	private Vector3 forwardStart;

	private void Start()
	{
		forwardStart = base.transform.parent.InverseTransformDirection(base.transform.forward);
	}

	private void Update()
	{
		if (!useLateUpdate)
		{
			LookatMovement();
		}
	}

	private void LateUpdate()
	{
		if (useLateUpdate)
		{
			LookatMovement();
		}
	}

	public void LookatMovement()
	{
		if (!active || ENT_Player.playerObject == null)
		{
			return;
		}
		Quaternion b = Quaternion.LookRotation(ENT_Player.playerObject.transform.position - base.transform.position, base.transform.parent.TransformVector(parentUpVector));
		if (limitAngle)
		{
			Vector3 vector = base.transform.parent.TransformDirection(forwardStart);
			if (Vector3.Angle((ENT_Player.playerObject.transform.position - base.transform.position).normalized, vector) < maxAngle)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * lookSpeed);
				if (!canSeePlayer)
				{
					onPlayerEnterCone.Invoke();
					canSeePlayer = true;
				}
			}
			else
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * lookSpeed);
				if (canSeePlayer)
				{
					onPlayerLeaveCone.Invoke();
					canSeePlayer = false;
				}
			}
		}
		else
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * lookSpeed);
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			float num = Mathf.Cos(maxAngle * 0.00872665f);
			float num2 = Mathf.Sin(maxAngle * 0.00872665f);
			Draw.Line(base.transform.position, base.transform.position + base.transform.forward * maxRange, Color.red);
			float num3 = 0.25f;
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.up * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.up * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.right * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.right * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.Arrow(base.transform.position, base.transform.position + base.transform.parent.TransformVector(parentUpVector), Color.green);
		}
	}

	public void Deactivate()
	{
		active = false;
	}

	public void Activate()
	{
		active = true;
	}

	public void ToggleActivated()
	{
		active = !active;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}
}
