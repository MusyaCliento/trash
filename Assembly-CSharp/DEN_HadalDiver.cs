using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DEN_HadalDiver : MonoBehaviourGizmos
{
	[Serializable]
	public class SegmentGroup
	{
		public string id;

		public bool randomOrder = true;

		public List<DEN_HadalDiver_Segment> segmentPrefabs;

		public int length;
	}

	public List<SegmentGroup> segmentGroups;

	public List<DEN_HadalDiver_Segment> segments = new List<DEN_HadalDiver_Segment>();

	[Range(0f, 1f)]
	public float noiseBlend = 1f;

	public float swimSinFrequency;

	public float swimSinAmplitude;

	public float swimSinOffset;

	public float rollSinFrequency;

	public float rollSinAmplitude;

	public float rollSinOffset;

	public float yawSinFrequency;

	public float yawSinAmplitude;

	public float yawSinOffset;

	public float finSinFrequency;

	public float finSinAmplitude;

	public float finSinOffset;

	public float finOffset = -75f;

	[Header("Targets")]
	public float pitchTarget;

	public float yawTarget;

	public float rollTarget;

	public Transform targetTransform;

	private List<Quaternion> targetRotation;

	public Mesh debugMesh;

	private UT_SoftParentZone[] softParentZones;

	private UT_Locator tailLocator;

	public static DEN_HadalDiver instance;

	public bool startSoftParentEnabled = true;

	public bool startBodyBlockers = true;

	public UnityEvent exitEvent;

	private void Start()
	{
		GenerateDiver();
		targetRotation = new List<Quaternion>();
		for (int i = 0; i < segments.Count; i++)
		{
			targetRotation.Add(Quaternion.identity);
		}
		softParentZones = GetComponentsInChildren<UT_SoftParentZone>();
		tailLocator = UT_Locator.GetLocator("hadaldiver_entrymover");
		instance = this;
		if (!startBodyBlockers)
		{
			DisableBodySkipBlockers();
		}
		base.transform.parent = null;
		StartCoroutine(SnapWaitForEndOFFrame());
		IEnumerator SnapWaitForEndOFFrame()
		{
			ToggleSoftParentZones(b: false);
			yield return new WaitForEndOfFrame();
			GetComponent<Animator>().Update(Time.fixedDeltaTime * 5f);
			yield return null;
			segments[0].transform.rotation = targetTransform.rotation;
			segments[0].transform.position = targetTransform.position;
			Movement();
			targetRotation[0] = Quaternion.Euler(pitchTarget, yawTarget, rollTarget) * targetTransform.localRotation;
			for (int j = 1; j < targetRotation.Count; j++)
			{
				targetRotation[j] = targetRotation[j - 1];
			}
			yield return null;
			ToggleSoftParentZones(startSoftParentEnabled);
		}
	}

	private void FixedUpdate()
	{
		targetRotation[0] = Quaternion.Euler(pitchTarget, yawTarget, rollTarget) * targetTransform.localRotation;
		for (int num = targetRotation.Count - 1; num > 0; num--)
		{
			targetRotation[num] = Quaternion.Lerp(targetRotation[num], targetRotation[num - 1], Time.fixedDeltaTime);
		}
	}

	private void Update()
	{
		Movement();
		if (CL_GameManager.gMan.IsReviving())
		{
			DestroyDiver();
		}
	}

	private void Movement()
	{
		if (segments == null || segments.Count == 0)
		{
			return;
		}
		segments[0].transform.localRotation = Quaternion.Lerp(segments[0].transform.localRotation, targetRotation[0], Time.deltaTime * 2f);
		segments[0].transform.position = Vector3.Lerp(segments[0].transform.position, targetTransform.position, Time.deltaTime * 2f);
		for (int i = 0; i < segments.Count; i++)
		{
			if (i > 0)
			{
				segments[i].transform.position = segments[i - 1].endLocator.position;
				float x = Mathf.Sin(swimSinFrequency * Time.time + swimSinOffset * (float)i) * swimSinAmplitude * noiseBlend;
				float z = Mathf.Cos(rollSinFrequency * Time.time + rollSinOffset * (float)i) * rollSinAmplitude * noiseBlend;
				float y = Mathf.Cos(yawSinFrequency * Time.time + yawSinOffset * (float)i) * yawSinAmplitude * noiseBlend;
				segments[i].transform.localRotation = Quaternion.Euler(x, y, z) * targetRotation[i];
				float num = Mathf.Cos(finSinFrequency * Time.time + finSinOffset * (float)i) * finSinAmplitude;
				if (segments[i].flipperLeft != null)
				{
					segments[i].flipperLeft.localRotation = Quaternion.Euler(0f, 0f, num + finOffset);
				}
				if (segments[i].flipperRight != null)
				{
					segments[i].flipperRight.localRotation = Quaternion.Euler(0f, 0f, num + finOffset);
				}
			}
		}
	}

	public void SnapSegmentsToFinalPosition()
	{
		StartCoroutine(SnapWaitForEndOFFrame());
		IEnumerator SnapWaitForEndOFFrame()
		{
			yield return new WaitForEndOfFrame();
			ENT_Player.GetPlayer().transform.parent = tailLocator.transform;
			GetComponent<Animator>().Update(Time.fixedDeltaTime);
			targetRotation[0] = Quaternion.Euler(pitchTarget, yawTarget, rollTarget) * targetTransform.localRotation;
			for (int i = 1; i < targetRotation.Count; i++)
			{
				targetRotation[i] = targetRotation[i - 1];
			}
			Movement();
			ENT_Player.GetPlayer().GetSoftParent().Unparent();
			ENT_Player.GetPlayer().ScaleVelocityMagnitude(0f);
			yield return null;
			ENT_Player.GetPlayer().ScaleVelocityMagnitude(0f);
			ENT_Player.GetPlayer().transform.parent = null;
			ENT_Player.GetPlayer().transform.rotation = Quaternion.Euler(0f, ENT_Player.GetPlayer().transform.rotation.eulerAngles.y, 0f);
		}
	}

	public void GenerateDiver()
	{
		foreach (SegmentGroup segmentGroup in segmentGroups)
		{
			List<DEN_HadalDiver_Segment> list = new List<DEN_HadalDiver_Segment>();
			list.AddRange(segmentGroup.segmentPrefabs);
			for (int i = 0; i < segmentGroup.length; i++)
			{
				if (list.Count == 0)
				{
					list.AddRange(segmentGroup.segmentPrefabs);
				}
				int index = 0;
				if (segmentGroup.randomOrder)
				{
					index = UnityEngine.Random.Range(0, list.Count);
				}
				DEN_HadalDiver_Segment dEN_HadalDiver_Segment = list[index];
				list.Remove(dEN_HadalDiver_Segment);
				segments.Add(UnityEngine.Object.Instantiate(dEN_HadalDiver_Segment, base.transform));
			}
		}
		HandholdManager.instance.LoadHandholds(base.gameObject);
		CL_Handhold[] componentsInChildren = GetComponentsInChildren<CL_Handhold>();
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			componentsInChildren[j].velocityMult = 0f;
		}
		FX_RunningLightFlare[] componentsInChildren2 = GetComponentsInChildren<FX_RunningLightFlare>();
		float num = 0f;
		FX_RunningLightFlare[] array = componentsInChildren2;
		foreach (FX_RunningLightFlare obj in array)
		{
			num = (obj.blinkOffset = num + 0.1f);
			obj.ResetBlinkTimer();
		}
	}

	public void ToggleSoftParentZones(bool b)
	{
		UT_SoftParentZone[] array = softParentZones;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = b;
		}
	}

	public void DisableBodySkipBlockers()
	{
		foreach (UT_Locator allLocator in UT_Locator.GetLocatorGroup("hadal_blocker").GetAllLocators())
		{
			allLocator.gameObject.SetActive(value: false);
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireCapsule(targetTransform.position, targetTransform.position + targetTransform.forward * 20f, 20f, Color.red);
		if (debugMesh != null)
		{
			using (Draw.InLocalSpace(targetTransform))
			{
				Draw.WireMesh(debugMesh, Color.red);
			}
		}
	}

	public void PullPlayerToTail()
	{
		if (tailLocator != null)
		{
			tailLocator.RunEvent();
		}
	}

	public void BeginDive()
	{
		foreach (DEN_HadalDiver_Segment segment in segments)
		{
			segment.OnEnterDiveEvent.Invoke();
		}
	}

	public void ExitDiver()
	{
		exitEvent.Invoke();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void DestroyDiver()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
