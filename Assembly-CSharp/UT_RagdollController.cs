using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_RagdollController : MonoBehaviour
{
	private List<Rigidbody> ragdollRigidbodies = new List<Rigidbody>();

	private void Start()
	{
		ragdollRigidbodies.AddRange(GetComponentsInChildren<Rigidbody>());
		ragdollRigidbodies.ForEach(delegate(Rigidbody rb)
		{
			rb.isKinematic = true;
		});
	}

	public void ActivateRagdoll()
	{
		StartCoroutine(WaitOneFrame());
		IEnumerator WaitOneFrame()
		{
			yield return null;
			foreach (Rigidbody ragdollRigidbody in ragdollRigidbodies)
			{
				ragdollRigidbody.isKinematic = false;
			}
		}
	}
}
