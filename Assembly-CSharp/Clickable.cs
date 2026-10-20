using System.Collections.Generic;
using UnityEngine;

public interface Clickable
{
	public class InteractionInfo
	{
		public ENT_Player player;

		public ENT_Player.Hand hand;

		public string interactionString;

		public List<string> interactionData;

		public Vector3 interactionPoint;

		public Vector3 interactionNormal;

		public Vector3 interactionDirection;

		public static InteractionInfo CreateNewInfo(ENT_Player p, string s = "")
		{
			return new InteractionInfo
			{
				player = p,
				interactionString = s
			};
		}

		public static InteractionInfo CreateNewInfo(ENT_Player p, ENT_Player.Hand hand, string s = "")
		{
			return new InteractionInfo
			{
				player = p,
				hand = hand,
				interactionString = s
			};
		}
	}

	void Interact(InteractionInfo info)
	{
	}

	void StartInteract(ENT_Player p, string s)
	{
	}

	void StopInteract(ENT_Player p, string s)
	{
	}

	void StopInteract(ENT_Player p, ENT_Player.Hand hand, string s)
	{
	}

	bool CanInteract(Interaction info)
	{
		return true;
	}

	ObjectTagger GetTagger()
	{
		return null;
	}

	GameObject GetGameObject()
	{
		return null;
	}

	Sprite GetSprite()
	{
		return null;
	}
}
