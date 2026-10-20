using UnityEngine;

public class UT_PlayerTakeOver : MonoBehaviour
{
	public bool active;

	private bool activeLastFrame;

	public float blendSpeed = 1f;

	private float blendTime;

	private Vector3 playerStartPosition;

	public bool takeoverRotation;

	public bool hideHands = true;

	private void Start()
	{
	}

	private void LateUpdate()
	{
		if (active)
		{
			if (!activeLastFrame)
			{
				playerStartPosition = ENT_Player.GetPlayer().transform.position;
			}
			ENT_Player.GetPlayer().LockInteraction();
			blendTime += Time.deltaTime * blendSpeed;
			ENT_Player.GetPlayer().transform.parent = base.transform;
			ENT_Player.GetPlayer().transform.position = Vector3.Lerp(playerStartPosition, base.transform.position, blendTime);
			if (takeoverRotation)
			{
				ENT_Player.GetPlayer().transform.rotation = Quaternion.Lerp(ENT_Player.GetPlayer().transform.rotation, base.transform.rotation, Time.deltaTime * 2f);
			}
			activeLastFrame = true;
		}
		else if (activeLastFrame)
		{
			ENT_Player.GetPlayer().transform.parent = null;
			ENT_Player.GetPlayer().UnlockInteraction();
			blendTime = 0f;
			activeLastFrame = false;
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
