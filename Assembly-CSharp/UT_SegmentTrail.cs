using System.Collections.Generic;
using UnityEngine;

public class UT_SegmentTrail : MonoBehaviour
{
	public List<Transform> segmentPrefab;

	public int initialSegments = 8;

	public float segmentSpacing = 0.35f;

	public float segmentGap = 0.35f;

	public float segmentRotationOffset = 115f;

	private List<Transform> segments = new List<Transform>();

	private List<Vector3> positionHistory = new List<Vector3>();

	public AnimationCurve bodyScaleCurve;

	private Transform bodyRoot;

	public float bodyScale = 1f;

	private Vector3 lastPos;

	private void Awake()
	{
		bodyRoot = new GameObject("Body Root").transform;
		segments = new List<Transform>();
		for (int i = 0; i < initialSegments; i++)
		{
			Grow();
		}
	}

	private void Update()
	{
		AnimateSegments();
	}

	private void FixedUpdate()
	{
		UpdateSegments();
	}

	private void OnDisable()
	{
		if (bodyRoot != null)
		{
			bodyRoot.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if (bodyRoot != null)
		{
			bodyRoot.gameObject.SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		if (bodyRoot != null)
		{
			Object.Destroy(bodyRoot.gameObject);
		}
	}

	public void ResetHistory()
	{
		positionHistory.Clear();
	}

	private void AnimateSegments()
	{
		float a = Time.fixedDeltaTime * segmentGap;
		int num = Mathf.RoundToInt(segmentSpacing / Mathf.Max(a, 0.0001f));
		for (int i = 0; i < initialSegments; i++)
		{
			int num2 = i * num;
			Transform transform = segments[i];
			if (num2 >= positionHistory.Count)
			{
				transform.localScale = Vector3.zero;
				transform.position = base.transform.position;
				continue;
			}
			Vector3 vector = positionHistory[num2];
			transform.position = Vector3.Lerp(transform.position, vector, Time.deltaTime * 5f);
			transform.localScale = Vector3.one * bodyScaleCurve.Evaluate((float)i / (float)initialSegments) * bodyScale;
			Vector3 forward = vector - transform.position;
			Quaternion quaternion = Quaternion.Euler((Vector3.right * Mathf.Sin((float)i * segmentRotationOffset) + Vector3.up * Mathf.Cos((float)i * segmentRotationOffset)) * 360f);
			if (forward.sqrMagnitude > 0.0001f)
			{
				transform.rotation = Quaternion.LookRotation(forward, Vector3.up) * quaternion;
			}
		}
	}

	private void UpdateSegments()
	{
		float a = Time.fixedDeltaTime * segmentGap;
		int num = Mathf.RoundToInt(segmentSpacing / Mathf.Max(a, 0.0001f));
		if (Vector3.Distance(base.transform.position, lastPos) > segmentSpacing)
		{
			positionHistory.Insert(0, base.transform.position);
			lastPos = base.transform.position;
		}
		int num2 = initialSegments * num + 1;
		if (positionHistory.Count > num2)
		{
			positionHistory.RemoveRange(num2, positionHistory.Count - num2);
		}
	}

	public void Grow()
	{
		Transform transform;
		if (segments.Count > 0)
		{
			List<Transform> list = segments;
			transform = list[list.Count - 1];
		}
		else
		{
			transform = base.transform;
		}
		Transform item = Object.Instantiate(segmentPrefab[Random.Range(0, segmentPrefab.Count)], transform.position, transform.rotation, bodyRoot);
		segments.Add(item);
	}

	public List<Transform> GetSegments()
	{
		return segments;
	}
}
