using System.Collections.Generic;
using UnityEngine;

public class HandholdModule_VineFlower : HandholdModule
{
	public ENV_SignalOrchid_VineFlower vineOrchid;

	private Dictionary<ENT_Player.Hand, float> positionDictionary;

	public override void Initialize(CL_Handhold h)
	{
		base.Initialize(h);
		positionDictionary = new Dictionary<ENT_Player.Hand, float>();
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		handhold.hands.ForEach(delegate(ENT_Player.Hand hand)
		{
			if (positionDictionary.ContainsKey(hand))
			{
				float t = positionDictionary[hand];
				Vector3 worldPositionOnCurrentSpline = vineOrchid.GetWorldPositionOnCurrentSpline(t);
				hand.SetWorldHoldPosition(worldPositionOnCurrentSpline);
			}
		});
	}

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
		float closestPositionOnSpline = vineOrchid.GetClosestPositionOnSpline(info.interactionPoint);
		if (positionDictionary.ContainsKey(hand))
		{
			positionDictionary[hand] = closestPositionOnSpline;
		}
		else
		{
			positionDictionary.Add(hand, closestPositionOnSpline);
		}
	}

	public override void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
		base.OnRelease(p, hand);
		if (positionDictionary.ContainsKey(hand))
		{
			positionDictionary.Remove(hand);
		}
	}
}
