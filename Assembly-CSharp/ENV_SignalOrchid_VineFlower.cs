using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class ENV_SignalOrchid_VineFlower : MonoBehaviour
{
	public SplineExtrude targetSplineExtrude;

	public GameObject headGameObject;

	public float growSpeed = 1f;

	public AnimationCurve growCurve;

	public List<GameObject> bloomObjects;

	private List<GameObject> instantiatedBlooms = new List<GameObject>();

	private List<float> bloomPositions = new List<float>();

	public float bloomDensity = 0.3f;

	private MeshRenderer meshRenderer;

	public float uvOffsetMultiplier = 1f;

	public UnityEvent growEvent;

	public float growDelay = 0.5f;

	public UnityEvent finishGrowEvent;

	public AudioSource growAudioSource;

	private float growAmount;

	private void Start()
	{
		headGameObject.transform.localPosition = targetSplineExtrude.Spline.EvaluatePosition(0f);
		targetSplineExtrude.Range = new Vector2(0f, 0f);
		headGameObject.transform.localPosition = targetSplineExtrude.Spline.EvaluatePosition(0f);
		Vector3 forward = targetSplineExtrude.Spline.EvaluateTangent(0f);
		headGameObject.transform.localRotation = Quaternion.LookRotation(forward);
		targetSplineExtrude.Rebuild();
		meshRenderer = targetSplineExtrude.GetComponent<MeshRenderer>();
	}

	private void Update()
	{
	}

	public void GrowAlongSpline()
	{
		float splineLength = targetSplineExtrude.Spline.GetLength();
		Debug.Log("Spline Length: " + splineLength);
		float bloomInterval = 1f / bloomDensity;
		growEvent.Invoke();
		StartCoroutine(GrowSpline());
		IEnumerator GrowSpline()
		{
			yield return new WaitForSeconds(growDelay);
			if (growAudioSource != null)
			{
				growAudioSource.Play();
				growAudioSource.volume = 0f;
			}
			growAudioSource.volume = Mathf.Lerp(growAudioSource.volume, 1f, 0.5f);
			float currentLength = 0f;
			while (currentLength < splineLength)
			{
				currentLength += growSpeed * Time.deltaTime;
				float time = Mathf.Clamp01(currentLength / splineLength);
				growAmount = time;
				time = growCurve.Evaluate(time);
				targetSplineExtrude.Range = new Vector2(0f, time);
				headGameObject.transform.localPosition = targetSplineExtrude.Spline.EvaluatePosition(time);
				Vector3 forward = targetSplineExtrude.Spline.EvaluateTangent(time);
				headGameObject.transform.localRotation = Quaternion.LookRotation(forward);
				meshRenderer.material.mainTextureOffset = new Vector2(0f, time * splineLength * uvOffsetMultiplier);
				if (splineLength * time >= (float)bloomPositions.Count * bloomInterval)
				{
					float item = time;
					GameObject item2 = Object.Instantiate(bloomObjects[Random.Range(0, bloomObjects.Count)], targetSplineExtrude.Spline.EvaluatePosition(0f), Quaternion.identity, targetSplineExtrude.transform);
					instantiatedBlooms.Add(item2);
					bloomPositions.Add(item);
				}
				for (int i = 0; i < instantiatedBlooms.Count; i++)
				{
					float t = time - bloomPositions[i];
					instantiatedBlooms[i].transform.localPosition = targetSplineExtrude.Spline.EvaluatePosition(t);
					instantiatedBlooms[i].transform.localRotation = Quaternion.LookRotation(targetSplineExtrude.Spline.EvaluateTangent(t));
				}
				targetSplineExtrude.Rebuild();
				yield return null;
			}
			finishGrowEvent.Invoke();
			if (growAudioSource != null)
			{
				while (growAudioSource.volume > 0.01f)
				{
					growAudioSource.volume = Mathf.Lerp(growAudioSource.volume, 0f, CL_GameManager.GetPlayerPerceivedDeltaTime());
					yield return null;
				}
			}
		}
	}

	public float GetClosestPositionOnSpline(Vector3 worldPosition)
	{
		SplineUtility.GetNearestPoint(targetSplineExtrude.Spline, targetSplineExtrude.transform.InverseTransformPoint(worldPosition), out var _, out var t, 32, 6);
		return growCurve.Evaluate(growAmount) - t;
	}

	public Vector3 GetWorldPositionOnCurrentSpline(float t)
	{
		return targetSplineExtrude.transform.TransformPoint(targetSplineExtrude.Spline.EvaluatePosition(growCurve.Evaluate(growAmount) - t));
	}
}
