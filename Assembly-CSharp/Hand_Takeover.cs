using UnityEngine;

[DefaultExecutionOrder(100)]
public class Hand_Takeover : MonoBehaviour
{
	public Hand_Base handBase;

	public ViewSway handSway;

	public bool oppositeHand;

	public bool disableWhenNotGrounded = true;

	public bool disableWhenGrasping;

	public bool disableWhenSprinting;

	public SpriteRenderer backgroundRenderer;

	public SpriteRenderer foregroundRenderer;

	public bool slowTakeover;

	public float takeoverSpeed = 1f;

	[Range(0f, 1f)]
	public float blend;

	private float curBlend;

	private void Start()
	{
	}

	public void LateUpdate()
	{
		if (slowTakeover && blend > 0.01f)
		{
			curBlend = Mathf.Lerp(curBlend, blend, takeoverSpeed * Time.deltaTime);
		}
		else
		{
			curBlend = blend;
		}
		if (curBlend > 0f)
		{
			ENT_Player.Hand hand = handBase.hand;
			bool flag = true;
			if (oppositeHand)
			{
				flag = hand.GetOtherHand().IsFree();
				hand = hand.GetOtherHand();
			}
			if (disableWhenNotGrounded && !ENT_Player.GetPlayer().IsGrounded())
			{
				flag = false;
			}
			if (disableWhenGrasping && InputManager.GetButton(hand.fireButton).Pressed)
			{
				flag = false;
			}
			if (disableWhenSprinting && ENT_Player.GetPlayer().IsInFullSprint())
			{
				flag = false;
			}
			if (flag)
			{
				Sprite background = null;
				Sprite foreground = null;
				if (backgroundRenderer != null)
				{
					if (backgroundRenderer.enabled)
					{
						background = backgroundRenderer.sprite;
						hand.SetSortingOrder(backgroundRenderer.sortingOrder);
					}
					hand.MoveTo(backgroundRenderer.transform.position, new Vector3(Mathf.Abs(base.transform.localScale.x), Mathf.Abs(base.transform.localScale.y), Mathf.Abs(base.transform.localScale.z)), backgroundRenderer.transform.rotation, curBlend);
				}
				if (foregroundRenderer != null && foregroundRenderer.enabled)
				{
					foreground = foregroundRenderer.sprite;
				}
				if ((bool)backgroundRenderer && (bool)foregroundRenderer)
				{
					hand.SetSortingOrder(backgroundRenderer.sortingOrder, foregroundRenderer.sortingOrder);
				}
				hand.SetSprite(background, foreground);
			}
			else
			{
				curBlend = 0f;
			}
		}
		if (backgroundRenderer != null)
		{
			backgroundRenderer.gameObject.SetActive(value: false);
		}
		if (foregroundRenderer != null)
		{
			foregroundRenderer.gameObject.SetActive(value: false);
		}
	}
}
