using UnityEngine;

public class Interaction
{
	public class InteractSettings
	{
		public bool allowPressHoldInteract;

		public bool allowMemorySave = true;
	}

	public ENT_Player player;

	public ENT_Player.Hand curhand;

	public string fireButton;

	public Collider hitCollider;

	public ObjectTagger tagger;

	public Clickable clickable;

	public Item item;

	public InteractSettings interactSettings;

	public InteractHit interactHit;

	public Sprite interactOverlaySprite;
}
