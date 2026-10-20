using System;
using System.Collections.Generic;
using Drawing;
using EditorCools;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class UT_PathMover : MonoBehaviourGizmos
{
	[Serializable]
	public class PathPoint
	{
		public Transform node;

		public float speed = 1f;

		public float waitTime;

		public bool stopOnArrival;

		public bool useCustomCurve;

		public AnimationCurve movementCurve;

		public AudioClip startSound;

		public AudioClip endSound;

		public string startSoundSubtitle = "";

		public string endSoundSubtitle = "";

		public UnityEvent startEvent;

		public UnityEvent endEvent;
	}

	public Transform moveObject;

	public float speed = 5f;

	public float offset;

	public float startWait;

	public bool active = true;

	public bool loop;

	public AnimationCurve movementCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public List<PathPoint> pathPoints;

	private int currentPointIndex;

	private bool isMovingForward = true;

	private float currentLerpTime;

	private float currentSegmentDistance;

	private float currentWaitTime;

	private Vector3 segmentStartPosition;

	private Quaternion segmentStartRotation;

	public AudioSource aud;

	private bool hasPlayedStartSound;

	private void Awake()
	{
		moveObject.position = pathPoints[0].node.position;
		moveObject.rotation = pathPoints[0].node.rotation;
		segmentStartRotation = pathPoints[0].node.rotation;
		float num = 0f;
		for (int i = 0; i < pathPoints.Count; i++)
		{
			PathPoint pathPoint = pathPoints[i];
			PathPoint p = pathPoints[Mathf.FloorToInt(Mathf.Repeat(i + 1, pathPoints.Count))];
			float num2 = GetSegmentDistance(pathPoint, p) / (pathPoint.speed * speed) + pathPoint.waitTime;
			num += num2;
		}
		float num3 = Mathf.Repeat(offset, num);
		float num4 = 0f;
		for (int j = 0; j < pathPoints.Count; j++)
		{
			PathPoint pathPoint2 = pathPoints[j];
			PathPoint pathPoint3 = pathPoints[Mathf.FloorToInt(Mathf.Repeat(j + 1, pathPoints.Count))];
			float num5 = GetSegmentDistance(pathPoint2, pathPoint3) / (pathPoint2.speed * speed);
			float num6 = num5 + pathPoint2.waitTime;
			num4 += num6;
			if (num3 < num6)
			{
				float num7 = num4 - num3;
				if (num7 < num5)
				{
					currentLerpTime = num7 / num5;
					currentPointIndex = j;
				}
				else
				{
					currentLerpTime = 0f;
					currentWaitTime = (num7 - num5) / pathPoint2.waitTime;
				}
				float num8 = 0f;
				num8 = ((!pathPoints[currentPointIndex].useCustomCurve) ? movementCurve.Evaluate(currentLerpTime) : pathPoints[currentPointIndex].movementCurve.Evaluate(currentLerpTime));
				moveObject.position = Vector3.Lerp(pathPoint2.node.position, pathPoint3.node.position, num8);
				moveObject.rotation = pathPoint2.node.rotation;
				break;
			}
		}
		currentWaitTime += startWait;
		Transform node = pathPoints[currentPointIndex].node;
		currentSegmentDistance = Vector3.Distance(moveObject.position, node.position);
		segmentStartPosition = moveObject.position;
		segmentStartRotation = moveObject.rotation;
		if (aud == null)
		{
			aud = GetComponent<AudioSource>();
		}
	}

	private void OnEnable()
	{
		DarkMachineFunctions.offsetAction = (Action<float>)Delegate.Combine(DarkMachineFunctions.offsetAction, new Action<float>(WorldOffset));
	}

	private void OnDisable()
	{
		DarkMachineFunctions.offsetAction = (Action<float>)Delegate.Remove(DarkMachineFunctions.offsetAction, new Action<float>(WorldOffset));
	}

	private void Update()
	{
		if (pathPoints == null || pathPoints.Count == 0)
		{
			Debug.LogWarning("Path points not set or empty.");
		}
		else if (active && Application.isPlaying)
		{
			MoveAlongPath();
		}
	}

	[Button("Generate Path Points", null, 0f)]
	private void GeneratePathPoints()
	{
		pathPoints = new List<PathPoint>();
		foreach (Transform item in base.transform)
		{
			if (item.name.Contains("pathpoint-node"))
			{
				PathPoint pathPoint = new PathPoint();
				pathPoint.node = item;
				pathPoint.speed = 1f;
				pathPoint.waitTime = 0f;
				pathPoints.Add(pathPoint);
			}
		}
		if (pathPoints.Count == 0)
		{
			Debug.LogWarning("No path points found with 'pathpoint-node' in their name.");
		}
	}

	private void MoveAlongPath()
	{
		if (currentWaitTime >= 0f)
		{
			currentWaitTime -= Time.deltaTime;
			return;
		}
		if (!hasPlayedStartSound)
		{
			if (aud != null && pathPoints[currentPointIndex].endSound != null)
			{
				aud.clip = pathPoints[currentPointIndex].startSound;
				aud.Play();
				if (pathPoints[currentPointIndex].startSoundSubtitle != "")
				{
					CL_UIManager.SubtitleSimpleCreate(CL_LocalizationManager.GetLocalization(pathPoints[currentPointIndex].startSoundSubtitle), "", CL_UIManager.SubtitleFlags.Ambient, base.transform);
				}
			}
			hasPlayedStartSound = true;
			pathPoints[currentPointIndex].startEvent.Invoke();
		}
		Transform node = pathPoints[currentPointIndex].node;
		float num = speed * Time.deltaTime * pathPoints[currentPointIndex].speed;
		currentLerpTime += num / currentSegmentDistance;
		float num2 = 0f;
		num2 = ((!pathPoints[currentPointIndex].useCustomCurve) ? movementCurve.Evaluate(currentLerpTime) : pathPoints[currentPointIndex].movementCurve.Evaluate(currentLerpTime));
		if (!float.IsNaN(num2) && node != null)
		{
			moveObject.position = Vector3.Lerp(segmentStartPosition, node.position, num2);
			Quaternion rotation = node.rotation;
			moveObject.rotation = Quaternion.Lerp(segmentStartRotation, rotation, num2);
		}
		if (currentLerpTime >= 1f)
		{
			ArriveAtNode();
		}
	}

	private void ArriveAtNode()
	{
		currentWaitTime = pathPoints[currentPointIndex].waitTime;
		pathPoints[currentPointIndex].endEvent.Invoke();
		if (pathPoints[currentPointIndex].stopOnArrival)
		{
			active = false;
		}
		if (aud != null && pathPoints[currentPointIndex].endSound != null)
		{
			aud.clip = pathPoints[currentPointIndex].endSound;
			aud.Play();
			if (pathPoints[currentPointIndex].endSoundSubtitle != "")
			{
				CL_UIManager.SubtitleSimpleCreate(CL_LocalizationManager.GetLocalization(pathPoints[currentPointIndex].endSoundSubtitle), "", CL_UIManager.SubtitleFlags.Ambient, base.transform);
			}
		}
		hasPlayedStartSound = false;
		currentLerpTime = 0f;
		segmentStartPosition = moveObject.position;
		segmentStartRotation = moveObject.rotation;
		if (loop)
		{
			currentPointIndex = (currentPointIndex + 1) % pathPoints.Count;
		}
		else if (isMovingForward)
		{
			if (currentPointIndex < pathPoints.Count - 1)
			{
				currentPointIndex++;
			}
			else
			{
				isMovingForward = false;
				currentPointIndex--;
			}
		}
		else if (currentPointIndex > 0)
		{
			currentPointIndex--;
		}
		else
		{
			isMovingForward = true;
			currentPointIndex++;
		}
		Transform node = pathPoints[currentPointIndex].node;
		currentSegmentDistance = Vector3.Distance(moveObject.position, node.position);
	}

	private float GetSegmentDistance(PathPoint p1, PathPoint p2)
	{
		return Vector3.Distance(p1.node.position, p2.node.position);
	}

	public override void DrawGizmos()
	{
		if (pathPoints.Count == 0)
		{
			return;
		}
		Draw.Arrow(moveObject.position, moveObject.position + moveObject.forward, Vector3.up, 0.1f, Color.cyan);
		Draw.Arrow(moveObject.position, moveObject.position + moveObject.up, Vector3.up, 0.1f, Color.green);
		Draw.Label2D(base.transform.position + Vector3.up * 0.5f, "OFFSET: " + offset + "\n WAIT: " + startWait, Color.yellow);
		for (int i = 0; i < pathPoints.Count; i++)
		{
			Draw.Arrow(pathPoints[i].node.position, pathPoints[i].node.position + pathPoints[i].node.forward, Vector3.up, 0.1f, Color.blue);
			Draw.Arrow(pathPoints[i].node.position, pathPoints[i].node.position + pathPoints[i].node.up, Vector3.up, 0.1f, Color.green);
			Draw.Label2D(pathPoints[i].node.position + Vector3.up * 0.25f, pathPoints[i].node.name + "\nS:" + pathPoints[i].speed + " W:" + pathPoints[i].waitTime);
			if (pathPoints.Count > i + 1)
			{
				Draw.Arrow(pathPoints[i].node.position, pathPoints[i + 1].node.position, Vector3.up, speed * 0.1f, Color.magenta);
			}
			else if (loop)
			{
				Draw.Arrow(pathPoints[i].node.position, pathPoints[0].node.position, Vector3.up, speed * 0.1f, Color.magenta);
			}
		}
	}

	public void StartMove()
	{
		active = true;
	}

	public void StopMove()
	{
		active = false;
	}

	public void WorldOffset(float f)
	{
		segmentStartPosition += Vector3.up * f;
	}
}
