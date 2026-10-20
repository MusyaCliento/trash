using System;
using UnityEngine;

public class ViewSway : MonoBehaviour
{
	[Serializable]
	public class ViewSwayParameters
	{
		public float impulseRecoveryMult = 1f;

		public float bobFrequencyMultiplier = 1f;

		public float bobOffsetMult = 1f;

		public float bobSmoothing = 5f;

		public Vector3 bobPositionOffset = Vector3.zero;

		public float bobBaseRotation;

		public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public float bobHorizontalFrequency = 2f;

		public float bobVerticalFrequency = 4f;

		[Space]
		public float bobHorizontalOffset;

		public float bobHorizontalAmplitude = 0.005f;

		public float bobVerticalAmplitude = 0.01f;

		public float bobSway;

		public float bobSwayFrequency = 4f;

		public float bobSwayOffset;

		public bool useHandBobSetting = true;

		public float GetHandBobMultiplier()
		{
			if (!useHandBobSetting)
			{
				return 1f;
			}
			return SettingsManager.settings.handbobMultiplier;
		}
	}

	public ViewSwayParameters parameters;

	private ViewSwayParameters baseParameters;

	public float animationOffset;

	public float impulseRecoveryRate = 5f;

	private float shakeAmount;

	private float rockAmount;

	public float scale = 1f;

	private Vector3 initialPosition;

	[HideInInspector]
	public Vector3 targetOffset = Vector3.down * 0.4f;

	public Vector3 offset;

	private Vector3 impulse;

	private float bobTimer;

	private Quaternion swayRot;

	private ENT_Player.Hand hand;

	internal Hand_Base handBase;

	public bool changeInitialScale = true;

	public static Action<Vector3> RecieveGlobalImpulse;

	private void Awake()
	{
		baseParameters = parameters;
	}

	private void Start()
	{
		initialPosition = base.transform.localPosition;
		if (changeInitialScale)
		{
			base.transform.localScale = base.transform.localScale * scale;
		}
		if (handBase == null)
		{
			handBase = GetComponent<Hand_Base>();
		}
		if (handBase != null)
		{
			hand = handBase.hand;
		}
	}

	private void OnEnable()
	{
		RecieveGlobalImpulse = (Action<Vector3>)Delegate.Combine(RecieveGlobalImpulse, new Action<Vector3>(AddImpulse));
	}

	private void OnDisable()
	{
		RecieveGlobalImpulse = (Action<Vector3>)Delegate.Remove(RecieveGlobalImpulse, new Action<Vector3>(AddImpulse));
	}

	public void Initialize(ENT_Player.Hand h)
	{
		hand = h;
	}

	private void Update()
	{
		if (CL_GameManager.gMan.isPaused || (hand != null && hand.IsLocked()))
		{
			return;
		}
		shakeAmount = Mathf.Lerp(shakeAmount, 0f, Time.deltaTime * 8f);
		rockAmount = Mathf.Lerp(shakeAmount, 0f, Time.deltaTime * 4f);
		float value = ENT_Player.playerObject.cCon.velocity.magnitude;
		if (ENT_Player.GetPlayer().noclip || ENT_Player.GetPlayer().isFrozen())
		{
			value = 0f;
		}
		Vector3 vector = offset + parameters.bobPositionOffset * parameters.GetHandBobMultiplier();
		float num = 1f;
		if (hand != null)
		{
			num = ((hand.id != 0) ? 1 : (-1));
			vector.x *= num;
		}
		value = Mathf.Clamp(value, 0f, 8f);
		bobTimer = Time.time + parameters.bobOffsetMult * animationOffset;
		if (value > 0.1f && !ENT_Player.GetPlayer().noclip)
		{
			float num2 = Mathf.Sin(bobTimer * parameters.bobHorizontalFrequency * parameters.bobFrequencyMultiplier);
			num2 = (parameters.curve.Evaluate(num2 / 2f + 0.5f) - 0.5f) * 2f;
			float num3 = num2 * parameters.bobHorizontalAmplitude * value * parameters.GetHandBobMultiplier();
			if (num < 0f)
			{
				num3 = 0f - num3;
			}
			float time = Mathf.Abs(Mathf.Sin(bobTimer * parameters.bobVerticalFrequency * parameters.bobFrequencyMultiplier));
			time = parameters.curve.Evaluate(time);
			float num4 = time * parameters.bobVerticalAmplitude * value * parameters.GetHandBobMultiplier();
			float num5 = Mathf.Sin(bobTimer * parameters.bobSwayFrequency * parameters.bobFrequencyMultiplier + parameters.bobSwayOffset) * value * parameters.bobSway;
			Vector3 vector2 = new Vector3(initialPosition.x + num3, initialPosition.y + num4, initialPosition.z) + impulse;
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, vector2 + targetOffset + vector, CL_GameManager.GetPlayerPerceivedDeltaTime() * parameters.bobSmoothing) + Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * shakeAmount, 0.5f);
			swayRot = Quaternion.Lerp(swayRot, Quaternion.Euler(0f, 0f, num5 * parameters.bobSway * (0f - num) * parameters.bobFrequencyMultiplier * parameters.GetHandBobMultiplier()), Time.time * 1f);
		}
		else
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, initialPosition + targetOffset + vector + impulse, CL_GameManager.GetPlayerPerceivedDeltaTime() * parameters.bobSmoothing) + Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * shakeAmount, 0.5f);
			swayRot = Quaternion.Lerp(swayRot, Quaternion.identity, Time.time * 1f);
		}
		base.transform.rotation = Quaternion.LookRotation(ENT_Player.playerObject.cam.transform.forward, base.transform.up);
		base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, swayRot * Quaternion.Euler(Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * shakeAmount * 30f, 20.5f)) * Quaternion.Euler(0f, 0f, Mathf.Sin(rockAmount + Time.time) + parameters.bobBaseRotation * num), Time.deltaTime * 6f);
		impulse = Vector3.Lerp(impulse, Vector3.zero, Time.deltaTime * impulseRecoveryRate * parameters.impulseRecoveryMult);
	}

	public Vector3 GetAdjustedInitialPosition()
	{
		return initialPosition + targetOffset + offset + parameters.bobPositionOffset + impulse;
	}

	public void Shake(float amount)
	{
		shakeAmount += amount;
	}

	public void Rock(float amount)
	{
		rockAmount += amount;
	}

	public float GetShake()
	{
		return shakeAmount;
	}

	public void OffsetInitialPosition(Vector3 offset)
	{
		initialPosition += offset;
	}

	public void SetCustomParameters(ViewSwayParameters p)
	{
		parameters = p;
	}

	public void UnsetCustomParameters()
	{
		parameters = baseParameters;
	}

	public void AddImpulse(Vector3 i)
	{
		impulse += i;
	}
}
