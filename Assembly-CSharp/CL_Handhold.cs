using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectTagger))]
public class CL_Handhold : MonoBehaviourGizmos, Clickable
{
	public bool active = true;

	internal List<ENT_Player.Hand> hands = new List<ENT_Player.Hand>();

	private ENT_Player player;

	public ColorSetting.ColorType handholdColorType;

	private bool holding;

	private bool inUse;

	public UnityEvent activeEvent;

	public UnityEvent stopEvent;

	public bool canHammer;

	public bool secure = true;

	public float secureAmount = 1f;

	public float secureMoveMax = 0.45f;

	public GameObject breakObject;

	public UnityEvent hammerEvent;

	public float dragMult = 10f;

	public float velocityMult = 1f;

	public float climbMult = 1f;

	public float climbGrav;

	public float strainRate = 1f;

	public float jumpMult = 1f;

	public float jumpStrainMult = 1f;

	public float speedMult = 1f;

	public float hangVelAdjust = 1f;

	public bool dropOnJump = true;

	public bool allowAirbornJump = true;

	[SerializeReference]
	public List<HandholdModule> modules;

	private bool hasBeenDestroyed;

	private float offsetAmount;

	private UT_SoftParent softParent;

	public Renderer handholdRenderer;

	private bool initialized;

	private bool skipFixedUpdate;

	public bool dropOnInactive;

	public bool useSharedHandholdMaterial = true;

	private bool hasJumped;

	public virtual void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		if (initialized)
		{
			return;
		}
		initialized = true;
		softParent = GetComponent<UT_SoftParent>();
		if (handholdRenderer == null)
		{
			handholdRenderer = GetComponent<Renderer>();
		}
		if (handholdRenderer != null && useSharedHandholdMaterial)
		{
			handholdRenderer.material = FXManager.GetSharedHandholdMaterial(handholdRenderer.material, handholdColorType);
		}
		if (modules == null)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			module.Initialize(this);
		}
	}

	internal virtual void Update()
	{
		if (!holding && hands.Count > 0)
		{
			holding = true;
			player = hands[0].GetPlayer();
		}
		if (modules != null)
		{
			foreach (HandholdModule module in modules)
			{
				if (module.enabled)
				{
					module.Update();
				}
			}
		}
		if (hasJumped)
		{
			hasJumped = false;
		}
	}

	private void LateUpdate()
	{
		if (modules == null)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			if (module.enabled)
			{
				module.LateUpdate();
			}
		}
	}

	private void FixedUpdate()
	{
		if (!secure && inUse && !skipFixedUpdate)
		{
			if (secureAmount < 0f)
			{
				Object.Instantiate(breakObject, base.transform.position, base.transform.rotation);
				while (hands.Count > 0)
				{
					hands[0].DropHand();
				}
				UT_AudioClipHandler component = GetComponent<UT_AudioClipHandler>();
				if (component != null)
				{
					component.GetGroup("piton").PlayAudioSetAtPoint("break", base.transform.position);
				}
				OnLetGo();
				Object.Destroy(base.gameObject);
			}
			if ((bool)softParent)
			{
				softParent.SoftMove(base.transform.forward * Time.fixedDeltaTime * 0.05f);
			}
			else
			{
				base.transform.position += base.transform.forward * Time.fixedDeltaTime * 0.05f;
			}
			secureAmount -= Time.deltaTime * 0.115f;
			offsetAmount += Time.fixedDeltaTime * 0.05f;
		}
		skipFixedUpdate = false;
	}

	private void OnDestroy()
	{
		hasBeenDestroyed = true;
		ForceDropHands();
	}

	public void Reset()
	{
	}

	public bool CanInteract(Interaction info)
	{
		bool flag = active && base.enabled;
		if (flag && modules != null && modules.Count > 0)
		{
			foreach (HandholdModule module in modules)
			{
				if (module.enabled && !module.CanInteract(info.player, info.curhand))
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	internal virtual void Stop()
	{
		holding = false;
		stopEvent.Invoke();
	}

	public virtual void Interact(Clickable.InteractionInfo info)
	{
		activeEvent.Invoke();
		holding = true;
		player = info.player;
		inUse = true;
		if (!hands.Contains(info.hand))
		{
			hands.Add(info.hand);
		}
		if (modules == null)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			module.OnGrab(info.player, info.hand, info);
		}
	}

	public virtual void StopInteract(ENT_Player p, ENT_Player.Hand dropHand, string s = "")
	{
		OnLetGo(dropHand);
		if (hands.Count == 0)
		{
			player = null;
			Stop();
		}
		if (modules == null)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			module.OnRelease(p, dropHand);
		}
	}

	public ObjectTagger GetTagger()
	{
		return base.gameObject.GetComponent<ObjectTagger>();
	}

	public GameObject GetGameObject()
	{
		if (hasBeenDestroyed)
		{
			return null;
		}
		return base.gameObject;
	}

	public virtual void HammerIn(float amount = 0.35f)
	{
		hammerEvent.Invoke();
		if (secure)
		{
			return;
		}
		skipFixedUpdate = true;
		secureAmount += amount;
		float num = -0.45f * amount;
		if (offsetAmount + num < 0f - secureMoveMax)
		{
			num = 0f - secureMoveMax - offsetAmount;
		}
		if ((bool)softParent)
		{
			softParent.SoftMove(base.transform.forward * num);
			offsetAmount += num;
		}
		else
		{
			base.transform.position += base.transform.forward * num;
			offsetAmount += num;
		}
		if (secureAmount >= 1f)
		{
			UT_Highlight component = GetComponent<UT_Highlight>();
			if (component != null)
			{
				component.active = false;
			}
			secure = true;
		}
	}

	internal void OnLetGo(ENT_Player.Hand dropHand = null)
	{
		if (dropHand != null)
		{
			hands.Remove(dropHand);
		}
		else
		{
			hands.Clear();
		}
		if (hands.Count == 0)
		{
			inUse = false;
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}

	public void ForceDropHands()
	{
		while (hands.Count > 0)
		{
			hands[0].DropHand();
		}
	}

	public virtual void OnPlayerJump(ENT_Player.Hand jumpHand = null, bool doubleJump = false)
	{
		if (modules != null)
		{
			foreach (HandholdModule module in modules)
			{
				if (module.enabled)
				{
					if (!doubleJump)
					{
						module.OnJump(jumpHand.GetPlayer(), jumpHand, hasJumped);
					}
					else
					{
						module.OnDoubleJump(jumpHand.GetPlayer(), jumpHand, hasJumped);
					}
				}
			}
		}
		hasJumped = true;
	}

	public bool GetHolding()
	{
		return holding;
	}

	public bool GetInUse()
	{
		return inUse;
	}

	public ENT_Player GetPlayer()
	{
		return player;
	}

	public virtual float GetClimbMult()
	{
		return climbMult;
	}

	public virtual float GetJumpMult()
	{
		return jumpMult;
	}

	public void SetSecure(bool b)
	{
		secure = b;
	}

	internal float GetGravity()
	{
		return climbGrav;
	}

	public string GetMaterialType()
	{
		ObjectMaterial component = GetComponent<ObjectMaterial>();
		if (component == null)
		{
			return "standard";
		}
		return component.GetMaterialType().ToString().ToLower();
	}

	public override void DrawGizmos()
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			_ = module;
		}
	}

	public virtual void SendMessageToModules(string message)
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			if (module.enabled)
			{
				module.SendMessage(message);
			}
		}
	}

	public virtual void DisableModules()
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			module.enabled = false;
		}
	}

	public virtual void EnableModules()
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			module.enabled = true;
		}
	}

	public virtual void EnableModule(string id)
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			if (module.id == id)
			{
				module.enabled = true;
			}
		}
	}

	public virtual void DisableModule(string id)
	{
		if (modules == null || modules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule module in modules)
		{
			if (module.id == id)
			{
				module.enabled = false;
			}
		}
	}

	public void SetMaterial(Material m)
	{
		if (handholdRenderer != null)
		{
			if (useSharedHandholdMaterial)
			{
				handholdRenderer.material = FXManager.GetSharedHandholdMaterial(m, handholdColorType);
			}
			else
			{
				handholdRenderer.material = m;
			}
		}
	}
}
