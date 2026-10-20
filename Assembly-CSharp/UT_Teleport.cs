using UnityEngine;

public class UT_Teleport : MonoBehaviour
{
	public bool useTargetLocator;

	public string targetLocatorID;

	public Transform target;

	public Vector3 offset;

	public bool adjustPlayerTravelCheckpoint;

	public void Teleport(Transform t)
	{
		Transform transform = target;
		Debug.Log("Teleporting: " + t.name);
		if (useTargetLocator)
		{
			UT_Locator locator = UT_Locator.GetLocator(targetLocatorID);
			if (locator != null)
			{
				transform = locator.transform;
				locator.RunEvent();
			}
		}
		if (ObjectTagger.TagCheck(t.gameObject, "Player"))
		{
			ENT_Player component = t.GetComponent<ENT_Player>();
			if (component != null)
			{
				component.Teleport(transform.position, transform.rotation, keepVelocity: true);
				if (adjustPlayerTravelCheckpoint)
				{
					CL_GameManager.gMan.SetPlayerDistanceCheckPosition(transform.position, 1f);
				}
				return;
			}
		}
		t.position = transform.position + offset;
		t.rotation = transform.rotation;
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}
}
