using System.Collections;
using UnityEngine;

public class ENV_ArtifactDevice_FX : MonoBehaviour
{
	public GameObject shardRoot;

	public float shardDropDelay = 0.05f;

	public void DropShards()
	{
		Rigidbody[] rigidbodies = shardRoot.GetComponentsInChildren<Rigidbody>();
		StartCoroutine(KinematicSetter());
		UT_Wiggle[] componentsInChildren = shardRoot.GetComponentsInChildren<UT_Wiggle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		IEnumerator KinematicSetter()
		{
			Rigidbody[] array = rigidbodies;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].isKinematic = false;
				yield return new WaitForSeconds(shardDropDelay);
			}
		}
	}
}
