using System.Collections.Generic;
using UnityEngine;

public class UT_EnvironmentPanningRepeater : MonoBehaviour
{
	public float speed;

	private List<Transform> segments;

	private float startHeight;

	private float endHeight;

	private void Start()
	{
		segments = new List<Transform>();
		segments.AddRange(base.transform.GetComponentsInChildren<Transform>());
		segments.Remove(base.transform);
		startHeight = float.PositiveInfinity;
		endHeight = float.NegativeInfinity;
		for (int i = 0; i < segments.Count; i++)
		{
			if (segments[i].localPosition.y < startHeight)
			{
				startHeight = segments[i].localPosition.y;
			}
			if (segments[i].localPosition.y > endHeight)
			{
				endHeight = segments[i].localPosition.y;
			}
		}
	}

	private void Update()
	{
		for (int i = 0; i < segments.Count; i++)
		{
			segments[i].localPosition += Vector3.up * Time.deltaTime * speed;
			float y = segments[i].localPosition.y;
			if (speed > 0f)
			{
				if (y > endHeight)
				{
					segments[i].localPosition = new Vector3(segments[i].localPosition.x, startHeight + (y - endHeight), segments[i].localPosition.z);
				}
			}
			else if (y < startHeight)
			{
				segments[i].localPosition = new Vector3(segments[i].localPosition.x, endHeight + (y - startHeight), segments[i].localPosition.z);
			}
		}
	}
}
