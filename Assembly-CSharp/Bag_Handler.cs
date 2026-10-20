using System;
using System.Collections.Generic;
using DG.Tweening;
using Drawing;
using UnityEngine;

public class Bag_Handler : MonoBehaviourGizmos
{
	public GameObject leftPocketGameObject;

	public GameObject rightPocketGameObject;

	public SpriteRenderer backgroundCircle;

	public SpriteRenderer leftPocketSprite;

	public SpriteRenderer rightPocketSprite;

	public Camera bagCamera;

	public float backgroundCircleSize = -1.4f;

	public int maxPouches = 4;

	public Bag_Pouch pouchAsset;

	public Transform pouchRoot;

	public List<Bag_Pouch> extraPouches = new List<Bag_Pouch>();

	public float pouchStartingPosition;

	public float pouchPositionOffset = 0.1f;

	public Transform[] pockets;

	public SpriteRenderer encumberanceCircle;

	public AnimationCurve encumberanceCircleScaleCurve;

	public Gradient encumberanceCircleColorGradient;

	private Color bagColor = Color.white;

	private float currentEncumberanceValue;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdatePositions()
	{
		leftPocketGameObject.transform.position = backgroundCircle.transform.position - backgroundCircle.transform.right * backgroundCircleSize;
		rightPocketGameObject.transform.position = backgroundCircle.transform.position + backgroundCircle.transform.right * backgroundCircleSize;
		leftPocketGameObject.transform.rotation = Quaternion.LookRotation(leftPocketGameObject.transform.position - bagCamera.transform.position, bagCamera.transform.up);
		rightPocketGameObject.transform.rotation = Quaternion.LookRotation(rightPocketGameObject.transform.position - bagCamera.transform.position, bagCamera.transform.up);
	}

	public void CreatePouches()
	{
		foreach (Bag_Pouch extraPouch in extraPouches)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(extraPouch.gameObject);
			}
		}
		extraPouches.Clear();
		_ = 1f / (float)(maxPouches + 1);
		for (int i = 0; i < maxPouches; i++)
		{
			Vector3 positionAlongCircleFromDegrees = GetPositionAlongCircleFromDegrees(GetPouchPosition(i));
			Bag_Pouch bag_Pouch = UnityEngine.Object.Instantiate(pouchAsset, positionAlongCircleFromDegrees, Quaternion.identity, pouchRoot);
			bag_Pouch.gameObject.SetActive(value: true);
			bag_Pouch.transform.rotation = Quaternion.LookRotation(bag_Pouch.transform.position - bagCamera.transform.position, bagCamera.transform.up);
			extraPouches.Add(bag_Pouch);
		}
	}

	public Bag_Pouch CreateCustomPouch(Vector3 position, Bag_Pouch asset)
	{
		Bag_Pouch bag_Pouch = UnityEngine.Object.Instantiate(asset, position, Quaternion.identity, pouchRoot);
		bag_Pouch.gameObject.SetActive(value: true);
		bag_Pouch.transform.rotation = Quaternion.LookRotation(bag_Pouch.transform.position - bagCamera.transform.position, bagCamera.transform.up);
		return bag_Pouch;
	}

	private float GetPouchPosition(int pouchIndex)
	{
		float num = ((pouchIndex % 2 == 0) ? 1 : (-1));
		float num2 = ((maxPouches % 2 != 0) ? ((pouchIndex % 2 == 0) ? pouchIndex : (pouchIndex + 1)) : ((pouchIndex % 2 == 0) ? pouchIndex : (pouchIndex - 1)));
		num2 += (float)((maxPouches % 2 == 0) ? 1 : 0);
		num2 *= pouchPositionOffset;
		return pouchStartingPosition + num * num2;
	}

	private Vector3 GetPositionAlongCircleFromDegrees(float t)
	{
		Vector3 position = backgroundCircle.transform.localPosition + Vector3.right * Mathf.Cos(t * (MathF.PI / 180f)) * backgroundCircleSize + Vector3.up * Mathf.Sin(t * (MathF.PI / 180f)) * backgroundCircleSize;
		return base.transform.TransformPoint(position);
	}

	public void SetEncumberance(float encumberanceAmount, float overEncumberance)
	{
		if (encumberanceAmount != currentEncumberanceValue)
		{
			bool flag = false;
			if (currentEncumberanceValue != encumberanceAmount)
			{
				flag = true;
			}
			currentEncumberanceValue = encumberanceAmount;
			float num = Mathf.Clamp01(encumberanceAmount);
			DOTween.Complete(backgroundCircle.material);
			if (flag)
			{
				backgroundCircle.material.DOFloat(num, "_EncumberanceValue", 0.25f).SetEase(Ease.OutBounce).SetUpdate(UpdateType.Normal, isIndependentUpdate: true);
			}
			Color b = encumberanceCircleColorGradient.Evaluate(num);
			b = Color.Lerp(Color.red, b, Mathf.Clamp01(overEncumberance));
			backgroundCircle.material.DOColor(b, "_EncumberanceCircleColor", 0.25f).SetEase(Ease.OutBounce).SetUpdate(UpdateType.Normal, isIndependentUpdate: true);
		}
	}

	public void SetBagColor(Color c, float overEncumberance)
	{
		bagColor = c;
		Color color = Color.Lerp(Color.red, bagColor, Mathf.Clamp01(overEncumberance));
		backgroundCircle.color = color;
		leftPocketSprite.color = color;
		rightPocketSprite.color = color;
		foreach (Inventory.Pouch pouch in Inventory.instance.pouches)
		{
			if (pouch.pouchVisual == null || pouch.pouchVisual.pouchSpriteRenderer == null)
			{
				break;
			}
			pouch.pouchVisual.pouchSpriteRenderer.color = color;
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.Circle(backgroundCircle.transform.position, Vector3.forward, backgroundCircleSize, Color.white * 0.5f);
		for (int i = 0; i < maxPouches; i++)
		{
			Draw.Circle(GetPositionAlongCircleFromDegrees(GetPouchPosition(i)), Vector3.forward, 0.1f, Color.yellow);
		}
	}
}
