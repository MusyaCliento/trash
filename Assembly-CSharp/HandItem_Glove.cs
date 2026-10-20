using UnityEngine;
using UnityEngine.Events;

public class HandItem_Glove : HandItem
{
	public bool usePassiveBuffs;

	public BuffContainer passiveBuffs;

	public bool useActiveBuffs;

	public BuffContainer activeBuffs;

	public float activeBuffHoldTime;

	public float activeBuffMinimumCharge = 10f;

	private bool lowCharge;

	public GameObject activeBuffEffects;

	private float holdTime;

	public bool activeBuffUsesCharge;

	private UT_AudioClipHandler clipHandler;

	private bool activated;

	private bool activating;

	public UnityEvent activationEvent;

	public UnityEvent deactivationEvent;

	public UnityEvent lowChargeEvent;

	public UnityEvent noChargeEvent;

	public UnityEvent rechargeEvent;

	public UnityEvent chargeEvent;

	private ItemExecutionModule_RechargeAmount rechargeAmountModule;

	private bool wasLmbPressedLastFrame;

	public override void Start()
	{
		base.Start();
		clipHandler = GetComponent<UT_AudioClipHandler>();
		passiveBuffs.id += GetDirection();
		activeBuffs.id += GetDirection();
		ENT_Player.playerObject.curBuffs.RemoveBuffContainer(activeBuffs.id);
		wasLmbPressedLastFrame = false;
		foreach (ItemExecutionModule executionModule in item.executionModules)
		{
			if (executionModule.GetType() == typeof(ItemExecutionModule_RechargeAmount))
			{
				rechargeAmountModule = (ItemExecutionModule_RechargeAmount)executionModule;
				break;
			}
		}
	}

	public override void Initialize(Item i, ENT_Player.Hand hand)
	{
		base.Initialize(i, hand);
		float.TryParse(item.GetFirstDataStringByType("charge"), out var result);
		allowInteract = result < activeBuffMinimumCharge;
	}

	public override void OnEnable()
	{
		SetActivationState(b: false);
		if (usePassiveBuffs)
		{
			ENT_Player.playerObject.curBuffs.AddBuff(passiveBuffs);
		}
		float.TryParse(item.GetFirstDataStringByType("charge"), out var result);
		if (result < activeBuffMinimumCharge)
		{
			noChargeEvent.Invoke();
			lowCharge = true;
		}
		else
		{
			chargeEvent.Invoke();
		}
		wasLmbPressedLastFrame = false;
	}

	private void OnDisable()
	{
		SetActivationState(b: false);
		if (rechargeAmountModule != null)
		{
			rechargeAmountModule.charging = true;
		}
		if (usePassiveBuffs)
		{
			ENT_Player.playerObject.curBuffs.RemoveBuffContainer(passiveBuffs.id);
		}
		ENT_Player.playerObject.curBuffs.RemoveBuffContainer(activeBuffs.id);
	}

	public override void Update()
	{
		if (CL_GameManager.gMan.isPaused)
		{
			return;
		}
		float result = 0f;
		float.TryParse(item.GetFirstDataStringByType("charge"), out result);
		if (activated)
		{
			if (result > 0f)
			{
				if (rechargeAmountModule != null)
				{
					rechargeAmountModule.charging = false;
				}
				result -= Time.deltaTime;
			}
			else if (activated)
			{
				SetActivationState(b: false);
				noChargeEvent.Invoke();
				if (rechargeAmountModule != null)
				{
					rechargeAmountModule.charging = true;
				}
			}
			item.SetFirstDataStringsofType("charge", result.ToString());
		}
		else if (rechargeAmountModule != null)
		{
			if (hand.interactState != ENT_Player.InteractType.hanging)
			{
				rechargeAmountModule.charging = true;
			}
			else
			{
				rechargeAmountModule.charging = false;
			}
		}
		if (hand.currentInteract != null)
		{
			anim.SetBool("Open", value: false);
			anim.SetBool("Hanging", value: true);
		}
		else if ((useActiveBuffs && activated) || !useActiveBuffs || result < activeBuffMinimumCharge)
		{
			if (wasLmbPressedLastFrame)
			{
				anim.SetBool("Open", value: true);
				anim.SetBool("Hanging", value: false);
			}
			else
			{
				anim.SetBool("Open", value: false);
				anim.SetBool("Hanging", value: false);
			}
			allowInteract = true;
		}
		else
		{
			anim.SetBool("Open", value: false);
			anim.SetBool("Hanging", value: false);
			allowInteract = false;
		}
		wasLmbPressedLastFrame = InputManager.GetButton(hand.fireButton).Pressed;
		if (useActiveBuffs)
		{
			if (result > activeBuffMinimumCharge)
			{
				if (ENT_Player.IsNullOrDestroyed(hand.currentInteract) && !activated && !activating)
				{
					if (InputManager.GetButton(hand.fireButton).Pressed)
					{
						holdTime += Time.deltaTime;
					}
					else
					{
						holdTime = 0f;
					}
					if (holdTime > activeBuffHoldTime)
					{
						anim.SetTrigger("Activate");
						activating = true;
					}
				}
				if (lowCharge)
				{
					lowCharge = false;
					rechargeEvent.Invoke();
					clipHandler.PlaySound("glove:recharged");
				}
			}
			else if (activated && !lowCharge)
			{
				lowCharge = true;
				lowChargeEvent.Invoke();
				clipHandler.PlaySound("glove:lowcharge");
			}
		}
		base.Update();
	}

	public void SetActivationState(bool b)
	{
		if (useActiveBuffs)
		{
			if (b && !activated)
			{
				clipHandler.PlaySound("glove:activate");
				activeBuffEffects.SetActive(value: true);
				ENT_Player.playerObject.curBuffs.AddBuff(activeBuffs);
				holdTime = 0f;
				activating = false;
				activationEvent.Invoke();
				lowCharge = false;
			}
			else if (!b && activated)
			{
				activeBuffEffects.SetActive(value: false);
				ENT_Player.playerObject.curBuffs.RemoveBuffContainer(activeBuffs.id);
				holdTime = 0f;
				activating = false;
				deactivationEvent.Invoke();
				clipHandler.PlaySound("glove:deactivate");
			}
			activated = b;
		}
	}

	public void ActivateGlove()
	{
		SetActivationState(b: true);
	}

	public override bool CanDrop(bool pocket = false)
	{
		return hand.interactState == ENT_Player.InteractType.none;
	}
}
