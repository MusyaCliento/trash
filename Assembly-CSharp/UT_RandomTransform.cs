using UnityEngine;

public class UT_RandomTransform : MonoBehaviour
{
	public bool randomizeAtStart = true;

	public float randomizeOffset = 1f;

	public float randomizeRotate = 360f;

	private void Start()
	{
		if (randomizeAtStart)
		{
			Randomize();
		}
	}

	public void Randomize()
	{
		Vector3 vector = Random.insideUnitSphere * randomizeOffset;
		Quaternion quaternion = Quaternion.Euler(Random.insideUnitSphere * randomizeRotate);
		base.transform.position += vector;
		base.transform.rotation *= quaternion;
	}
}
