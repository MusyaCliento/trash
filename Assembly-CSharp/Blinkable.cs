using UnityEngine;

internal interface Blinkable
{
	void OnBlinkStart()
	{
	}

	void OnBlinkEnd()
	{
	}

	void OnBlinkTeleport()
	{
	}

	bool CanBlinkFrag()
	{
		return false;
	}

	GameObject GetBlinkableGameObject()
	{
		return null;
	}
}
