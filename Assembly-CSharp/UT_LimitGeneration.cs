using UnityEngine;

public class UT_LimitGeneration : MonoBehaviour
{
	public class LimitGroup
	{
	}

	public enum LimitDomain
	{
		perRegion = 0,
		perSubregion = 1,
		perLevel = 2,
		perRun = 3
	}

	public string limitID;

	public int limitCount;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
