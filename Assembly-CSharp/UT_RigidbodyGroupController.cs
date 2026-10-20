using System.Collections;
using UnityEngine;

public class UT_RigidbodyGroupController : MonoBehaviour
{
	public float groupDelay;

	public void SetKinematic(bool b)
	{
		Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
		if (groupDelay > 0f)
		{
			StartCoroutine(KinematicSetter());
			return;
		}
		Rigidbody[] array = rigidbodies;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].isKinematic = b;
		}
		IEnumerator KinematicSetter()
		{
			Rigidbody[] array2 = rigidbodies;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].isKinematic = b;
				yield return new WaitForSeconds(groupDelay);
			}
		}
	}

	public void AddRandomForce(float amount)
	{
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].AddForce(Random.insideUnitSphere * amount);
		}
	}

	public void AddRandomTorque(float amount)
	{
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].AddTorque(Random.insideUnitSphere * amount);
		}
	}
}
