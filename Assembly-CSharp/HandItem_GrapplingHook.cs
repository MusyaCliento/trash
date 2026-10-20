using System.Collections.Generic;
using UnityEngine;

public class HandItem_GrapplingHook : HandItem
{
	public float grappleDistance = 20f;

	public LayerMask grappleMask;

	public Transform startRoot;

	public float grappleForce = 1f;

	public Vector3 grappleForceMult = Vector3.one;

	public AnimationCurve grappleForceCurve = AnimationCurve.Linear(1f, 1f, 1f, 1f);

	public float grappleDeadzone = 3f;

	public float grappleForceTime = 5f;

	public float grappleJumpForce = 1f;

	private float curGrapplingTime;

	private bool isGrappling;

	private bool hasGrappledPoint;

	public Vector3 grapplePoint;

	public List<SpriteRenderer> staminaRenderers;

	public AnimationCurve staminaRendererCurve;

	public List<Transform> grappleHeadObject;

	public float grappleHeadRotationMult = 1f;

	public float grappleHeadMaxRotation = 10f;

	public float grappleHeadTranslationMult = 1f;

	public float grappleheadMaxTranslation = 0.2f;

	public float maxStamina = 10f;

	public float staminaRecoveryRate = 0.5f;

	public float minimumRecoveryStamina = 2f;

	public float jumpStaminaDrain = 1f;

	private bool recovering;

	private float curStamina;

	private UT_AudioClipHandler clipHandler;

	public string[] foodTags;

	public string[] lesserFoodTags;

	public string[] foodBlacklistTags;

	public float rigidbodyWhipForce = 5f;

	public float rigidbodyVerticalWhipForce = 2f;

	public float rigidbodyWhipRandomTorque = 20f;

	public MeshRenderer hookMesh;

	public float hookMeshLerpSpeed = 5f;

	private float hookWiggle;

	public float hookWiggleSpeed = 5f;

	public float reachWiggleAmount = 1f;

	public float yoinkWiggleAmount = 1f;

	private float hookVisualLatchTime;

	private float readyTime;

	private bool isUsing;

	public float tempStaminaBoost;

	private bool canJump = true;

	public override void Start()
	{
		base.Start();
		clipHandler = GetComponent<UT_AudioClipHandler>();
		string firstDataStringByType = item.GetFirstDataStringByType("stamina");
		if (string.IsNullOrEmpty(firstDataStringByType))
		{
			curStamina = maxStamina;
		}
		else
		{
			float.TryParse(firstDataStringByType, out curStamina);
		}
	}

	public override void Update()
	{
		base.Update();
		if (tempStaminaBoost > 0f)
		{
			tempStaminaBoost -= Time.deltaTime;
		}
		if (isUsing && !isGrappling && readyTime <= 0f && curStamina > minimumRecoveryStamina)
		{
			curGrapplingTime = 0f;
			isGrappling = true;
			anim.SetBool("Primed", value: true);
			clipHandler.PlaySound("grapple:prime");
		}
		canJump = !hasGrappledPoint;
		readyTime -= Time.deltaTime;
		if (isGrappling)
		{
			Grapple();
		}
		else
		{
			curStamina = Mathf.Clamp(curStamina + Time.deltaTime * staminaRecoveryRate, 0f, maxStamina);
		}
		for (int i = 0; i < staminaRenderers.Count; i++)
		{
			staminaRenderers[i].color = Color.Lerp(b: Color.Lerp(Color.Lerp(Color.white, Color.red, staminaRendererCurve.Evaluate((float)(i + 1) / (float)staminaRenderers.Count)), Color.white, curStamina / maxStamina), a: DarkMachineCrayons.skyBlue, t: 1f - tempStaminaBoost * (Mathf.Sin(Time.time * 2f) / 2f + 0.5f));
		}
		if (!isGrappling && curStamina < minimumRecoveryStamina)
		{
			anim.SetBool("Drained", value: true);
		}
		else
		{
			anim.SetBool("Drained", value: false);
		}
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		hookWiggle = Mathf.Lerp(hookWiggle, 0f, Time.deltaTime * hookWiggleSpeed);
		hookMesh.material.SetFloat("_Wiggle", hookWiggle);
		if (hasGrappledPoint)
		{
			hookMesh.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(hookMesh.transform.position, grapplePoint) / base.transform.lossyScale.y);
			hookMesh.transform.rotation = Quaternion.LookRotation(grapplePoint - hookMesh.transform.position);
		}
		else if (hookVisualLatchTime <= 0f)
		{
			hookMesh.transform.localScale = Vector3.Lerp(hookMesh.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * hookMeshLerpSpeed);
			hookMesh.transform.rotation = Quaternion.Lerp(hookMesh.transform.rotation, Quaternion.LookRotation(base.transform.forward), Time.deltaTime * hookMeshLerpSpeed);
		}
		hookVisualLatchTime -= Time.deltaTime;
		Animate();
	}

	public override void Use()
	{
		base.Use();
		isUsing = true;
	}

	public override void StopUse()
	{
		base.StopUse();
		if (isGrappling)
		{
			LetGo();
		}
		isUsing = false;
	}

	public override void OnEnable()
	{
	}

	private void OnDisable()
	{
		item.SetFirstDataStringsofType("stamina", curStamina.ToString());
	}

	private void OnJump()
	{
		Debug.Log("Recieved Jump Instruction!");
		if (hasGrappledPoint && isGrappling)
		{
			LetGo();
			if (curStamina > 1f)
			{
				ENT_Player.GetPlayer().ForceJump();
				ENT_Player.GetPlayer().AddForce(Vector3.up * grappleJumpForce);
			}
			anim.SetBool("Primed", value: false);
			anim.SetBool("Latched", value: false);
			if (tempStaminaBoost <= 0f)
			{
				curStamina -= jumpStaminaDrain;
			}
		}
	}

	private void Grapple()
	{
		if (!hasGrappledPoint)
		{
			if (!Physics.SphereCast(Camera.main.transform.position, 0.1f, Camera.main.transform.forward, out var hitInfo, grappleDistance, grappleMask))
			{
				return;
			}
			hookWiggle = reachWiggleAmount;
			ScaleHookToPosition(hitInfo.point);
			GameObject gameObject = hitInfo.collider.gameObject;
			Item_Object component = hitInfo.collider.gameObject.GetComponent<Item_Object>();
			float num = 0f;
			float num2 = 0f;
			bool flag = false;
			bool flag2 = true;
			if (component != null)
			{
				if (component.itemData.HasTag("inLocker"))
				{
					flag2 = false;
				}
				if (flag2)
				{
					bool flag3 = component.itemData.HasTag("staminabooster");
					bool flag4 = component.itemData.HasTag("pills");
					if (flag3)
					{
						num2 += 5f;
						if (flag4)
						{
							num2 += 5f;
						}
					}
					if (component.itemData.HasTag("food") || flag3)
					{
						flag = true;
						num = maxStamina;
					}
				}
			}
			if (flag2)
			{
				ObjectTagger component2 = hitInfo.collider.gameObject.GetComponent<ObjectTagger>();
				bool flag5 = component2 != null && component2.HasTagInList(foodBlacklistTags);
				if (component2 != null)
				{
					if (component2.HasTagInList(foodTags))
					{
						flag = true;
						num = maxStamina;
					}
					else if (component2.HasTagInList(lesserFoodTags))
					{
						flag = true;
						num = maxStamina / 4f;
					}
				}
				if (flag && !flag5)
				{
					Object.Destroy(gameObject.gameObject);
					tempStaminaBoost += num2;
				}
				if (flag && num > 0f)
				{
					clipHandler.PlaySound("grapple:eat");
					clipHandler.PlaySound("grapple:latch");
					clipHandler.PlaySound("grapple:latchhit", hitInfo.point);
					hookWiggle = yoinkWiggleAmount;
					isGrappling = false;
					anim.SetTrigger("Yoink");
					LetGo();
					curStamina = Mathf.Clamp(curStamina + num, 0f, maxStamina);
					return;
				}
				Rigidbody component3 = gameObject.GetComponent<Rigidbody>();
				if (component3 != null && !flag5)
				{
					component3.isKinematic = false;
					component3.AddForce((startRoot.position - hitInfo.point).normalized * rigidbodyWhipForce + Vector3.up * rigidbodyVerticalWhipForce);
					component3.AddTorque(Random.insideUnitSphere * rigidbodyWhipRandomTorque);
					clipHandler.PlaySound("grapple:latch");
					clipHandler.PlaySound("grapple:latchhit", hitInfo.point);
					anim.SetTrigger("Yoink");
					LetGo();
					isGrappling = false;
					hookWiggle = yoinkWiggleAmount;
					return;
				}
				CL_Button component4 = gameObject.GetComponent<CL_Button>();
				if (component4 != null && component4.projectilesCanPress && !flag5)
				{
					component4.Interact();
					clipHandler.PlaySound("grapple:latch");
					clipHandler.PlaySound("grapple:latchhit", hitInfo.point);
					anim.SetTrigger("Yoink");
					hookWiggle = yoinkWiggleAmount;
					LetGo();
					return;
				}
			}
			hasGrappledPoint = true;
			grapplePoint = hitInfo.point;
			anim.SetBool("Latched", value: true);
			clipHandler.PlaySound("grapple:latch");
			clipHandler.PlaySound("grapple:latchhit", hitInfo.point);
		}
		else if (InputManager.GetButton("Jump").Down)
		{
			OnJump();
		}
		else
		{
			Vector3 vector = grapplePoint - startRoot.position;
			float magnitude = vector.magnitude;
			if (magnitude < grappleDeadzone)
			{
				vector *= magnitude / grappleDeadzone;
			}
			curGrapplingTime += Time.deltaTime;
			float num3 = grappleForceCurve.Evaluate(Mathf.Clamp01(curGrapplingTime / grappleForceTime));
			Vector3 a = vector;
			if (Vector3.ProjectOnPlane(vector, Vector3.up).magnitude > Mathf.Abs(a.y))
			{
				a.y *= 0.3f;
				a.x *= 0.75f;
				a.z *= 0.75f;
			}
			a = Vector3.Scale(a, grappleForceMult);
			ENT_Player.GetPlayer().AddForce(Vector3.ClampMagnitude(a, grappleForce) * num3 * Time.deltaTime);
			if (!ENT_Player.GetPlayer().IsGrounded() && !ENT_Player.GetPlayer().IsHanging() && tempStaminaBoost <= 0f)
			{
				curStamina = Mathf.Clamp(curStamina - Time.deltaTime, 0f, maxStamina);
			}
			if (curStamina <= 0f)
			{
				LetGo();
			}
		}
	}

	private void Animate()
	{
		Vector3 vector = base.transform.InverseTransformPoint(grapplePoint);
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(Camera.main.transform.position + base.transform.forward, $"relative: {vector}", Color.red);
			CL_DebugView.draw.WireSphere(grapplePoint, 0.15f, Color.red);
		}
		Vector3 b = Vector3.zero;
		Quaternion b2 = Quaternion.identity;
		if (hasGrappledPoint && isGrappling)
		{
			b = Vector3.ClampMagnitude(new Vector3(0f - vector.x, 0f - vector.y, 0f) * grappleHeadTranslationMult, grappleheadMaxTranslation);
			b2 = Quaternion.Euler(Vector3.ClampMagnitude(new Vector3(0f, 0f, (0f - vector.x + (0f - vector.y)) * grappleHeadRotationMult), grappleHeadMaxRotation));
		}
		foreach (Transform item in grappleHeadObject)
		{
			item.localRotation = Quaternion.Lerp(item.localRotation, b2, Time.deltaTime * 8f);
			item.localPosition = Vector3.Lerp(item.localPosition, b, Time.deltaTime * 8f);
		}
	}

	public void LetGo()
	{
		hasGrappledPoint = false;
		isGrappling = false;
		anim.SetBool("Primed", value: false);
		anim.SetBool("Latched", value: false);
		if (curStamina < minimumRecoveryStamina)
		{
			clipHandler.PlaySound("grapple:hungry");
		}
		else
		{
			clipHandler.PlaySound("grapple:letgo");
		}
		hookWiggle = reachWiggleAmount;
		readyTime = 0.5f;
	}

	public void ScaleHookToPosition(Vector3 pos)
	{
		float y = base.transform.lossyScale.y;
		hookMesh.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(hookMesh.transform.position, pos) / y);
		hookMesh.transform.rotation = Quaternion.LookRotation(pos - hookMesh.transform.position);
		hookVisualLatchTime = 0.15f;
	}

	public override bool AllowJump()
	{
		return canJump;
	}
}
