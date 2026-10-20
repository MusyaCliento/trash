using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_HandDetectionZone : MonoBehaviourGizmos
{
	public Bounds bounds;

	public bool onlyDetectGrabbing;

	private List<ENT_Player.Hand> handsInZone = new List<ENT_Player.Hand>();

	public UnityEvent<ENT_Player.Hand> onHandEnter;

	public UnityEvent<ENT_Player.Hand> onHandExit;

	public UnityEvent onFirstHandEnter;

	public UnityEvent onLastHandExit;

	public bool canEffectHands;

	public float effectRate = 0.5f;

	private float effectTimer;

	public bool canDamagePlayer;

	public Damageable.DamageInfo damageInfo;

	public bool forceDropHand;

	public float forceDropHandStaminaThreshhold;

	public float handStaminaDamage;

	public float handStaminaRepair;

	private void Update()
	{
		CheckForPlayer();
	}

	private void CheckForPlayer()
	{
		if (ENT_Player.playerObject == null)
		{
			return;
		}
		bool flag = false;
		int count = handsInZone.Count;
		ENT_Player.Hand[] hands = ENT_Player.GetPlayer().hands;
		foreach (ENT_Player.Hand hand in hands)
		{
			if (IsPositionInZone(hand.handBase.transform.position) && (!onlyDetectGrabbing || hand.IsHolding()))
			{
				if (!handsInZone.Contains(hand))
				{
					handsInZone.Add(hand);
					onHandEnter.Invoke(hand);
					flag = true;
				}
			}
			else if (handsInZone.Contains(hand))
			{
				handsInZone.Remove(hand);
				onHandExit.Invoke(hand);
				flag = true;
			}
		}
		if (flag)
		{
			if (handsInZone.Count == 0 && count > 0)
			{
				onLastHandExit.Invoke();
			}
			else if (handsInZone.Count > 0 && count == 0)
			{
				onFirstHandEnter.Invoke();
			}
		}
		if (!canEffectHands)
		{
			return;
		}
		if (handsInZone.Count > 0)
		{
			effectTimer -= Time.deltaTime;
			if (!(effectTimer <= 0f))
			{
				return;
			}
			effectTimer = effectRate;
			if (canDamagePlayer)
			{
				ENT_Player.GetPlayer().Damage(damageInfo);
			}
			{
				foreach (ENT_Player.Hand item in handsInZone)
				{
					if (forceDropHand && (item.GetGripStrength() < forceDropHandStaminaThreshhold || forceDropHandStaminaThreshhold <= 0f))
					{
						item.DropHand();
						item.AddHandWait(0.2f);
					}
					if (handStaminaDamage > 0f)
					{
						item.DamageGripStrength(handStaminaDamage);
					}
					if (handStaminaRepair > 0f)
					{
						item.AddGripStrength(handStaminaRepair);
					}
				}
				return;
			}
		}
		effectTimer = 0f;
	}

	public bool IsPositionInZone(Vector3 position)
	{
		return bounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.red);
			Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(1f, 0f, 0f, 0.01f));
		}
		else
		{
			Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(1f, 0f, 0f, 0.002f));
		}
	}

	public Vector3 ClampPositionToSwimZone(Vector3 position)
	{
		return base.transform.TransformPoint(bounds.ClosestPoint(base.transform.InverseTransformPoint(position)));
	}
}
