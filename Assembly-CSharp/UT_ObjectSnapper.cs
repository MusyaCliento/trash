using System.Collections;
using UnityEngine;

public class UT_ObjectSnapper : MonoBehaviour
{
	[SerializeField]
	private string targetTag = "Draggable";

	[SerializeField]
	private Transform snapPoint;

	[SerializeField]
	private float detectionRadius = 1f;

	[SerializeField]
	private float snapSpeed = 5f;

	private Collider[] colliders;

	private GameObject objectToSnap;

	private Rigidbody objectRigidbody;

	private CL_Prop objectProp;

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			DetectAndSnapObject();
		}
	}

	private void DetectAndSnapObject()
	{
		colliders = Physics.OverlapSphere(base.transform.position, detectionRadius);
		objectToSnap = null;
		Collider[] array = colliders;
		foreach (Collider collider in array)
		{
			if (collider.CompareTag(targetTag))
			{
				objectToSnap = collider.gameObject;
				break;
			}
		}
		if (objectToSnap != null)
		{
			objectProp = objectToSnap.GetComponent<CL_Prop>();
			objectRigidbody = objectToSnap.GetComponent<Rigidbody>();
			if (objectProp != null && objectRigidbody != null)
			{
				StartCoroutine(SnapObject());
			}
		}
	}

	private IEnumerator SnapObject()
	{
		objectProp.enabled = false;
		objectRigidbody.isKinematic = true;
		while (Vector3.Distance(objectToSnap.transform.position, snapPoint.position) > 0.01f)
		{
			objectToSnap.transform.position = Vector3.Lerp(objectToSnap.transform.position, snapPoint.position, Time.deltaTime * snapSpeed);
			objectToSnap.transform.rotation = Quaternion.Lerp(objectToSnap.transform.rotation, snapPoint.rotation, Time.deltaTime * snapSpeed);
			yield return null;
		}
		objectToSnap.transform.position = snapPoint.position;
		objectToSnap.transform.rotation = snapPoint.rotation;
	}
}
