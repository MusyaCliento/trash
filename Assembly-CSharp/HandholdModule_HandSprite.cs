using UnityEngine;

public class HandholdModule_HandSprite : HandholdModule
{
	public Sprite handBackgroundSprite;

	public Sprite handForegroundSprite;

	public override void LateUpdate()
	{
		base.LateUpdate();
		foreach (ENT_Player.Hand hand in handhold.hands)
		{
			hand.SetSprite(handBackgroundSprite, handForegroundSprite);
		}
	}
}
