using UnityEngine;

public class UT_BadgeGiver : MonoBehaviour
{
	public Sprite badgeSprite;

	[TextArea]
	public string badgeText;

	public AudioClip audioClip;

	public float delay = 0.5f;

	public void ShowBadge()
	{
		UI_Badge.GetBadge(badgeSprite, badgeText, delay);
		AudioManager.PlayUISound(audioClip);
	}
}
