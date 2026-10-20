using UnityEngine;

public class UT_AudioOffset : MonoBehaviour
{
	public float minOffset;

	public float maxOffset;

	public float minPitch = 1f;

	public float maxPitch = 1f;

	private void OnEnable()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (component != null)
		{
			component.pitch = Random.Range(minPitch, maxPitch);
			component.time = Random.Range(minOffset, Mathf.Min(maxOffset, component.clip.length));
		}
	}
}
