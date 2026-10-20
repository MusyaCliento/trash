using System.Collections.Generic;
using System.Linq;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class CL_HoldButton : MonoBehaviourGizmos, Clickable, ValueControl
{
	public bool active = true;

	public bool canUse = true;

	public bool canTwoHand;

	public UnityEvent activeEvent;

	public UnityEvent stopEvent;

	public UnityEvent finishEvent;

	public UnityEvent failEvent;

	public UnityEvent<float> progressEvent;

	[HideInInspector]
	public bool hasBeenPressed;

	public int maxPresses;

	private int presses;

	public bool projectilesCanPress = true;

	internal bool cooldown;

	[Header("Audio")]
	public AudioClip pressSound;

	public AudioClip letgoSound;

	public float pressVolume = 0.8f;

	[Header("Materials")]
	public int materialIndex;

	public Material unpressedMaterial;

	public Material pressedMaterial;

	public Material inactiveMaterial;

	private MeshRenderer rendererComponent;

	public bool holdUntil;

	public float curValue;

	public float minValue;

	public float maxValue = 1f;

	public float useSpeed = 1f;

	private bool holding;

	private float direction = 1f;

	private ENT_Player player;

	public bool resetOnStop;

	public bool flipFlop;

	public bool disableOnFinish;

	[HideInInspector]
	public bool hasFinished;

	internal List<ENT_Player.Hand> hands = new List<ENT_Player.Hand>();

	internal virtual void Start()
	{
		rendererComponent = GetComponent<MeshRenderer>();
		ChooseMaterial();
	}

	public virtual void Update()
	{
		if (!holding || !holdUntil)
		{
			return;
		}
		if (curValue > maxValue)
		{
			if (disableOnFinish)
			{
				canUse = false;
			}
			finishEvent.Invoke();
			stopEvent.Invoke();
			hasFinished = true;
			Stop();
			curValue = maxValue;
		}
		if (curValue < minValue)
		{
			if (disableOnFinish)
			{
				canUse = false;
			}
			finishEvent.Invoke();
			stopEvent.Invoke();
			hasFinished = true;
			Stop();
			curValue = minValue;
		}
		progressEvent.Invoke(curValue);
		curValue += Time.deltaTime * direction * useSpeed;
	}

	public virtual void Interact()
	{
		if ((maxPresses <= 0 || presses < maxPresses) && active)
		{
			if (flipFlop)
			{
				direction *= -1f;
			}
			presses++;
			hasBeenPressed = true;
			holding = true;
			AudioManager.PlaySound(pressSound, base.transform.position, pressVolume);
			ChooseMaterial();
			activeEvent.Invoke();
		}
	}

	public virtual void Interact(Clickable.InteractionInfo info)
	{
		Interact();
		player = info.player;
		if (!hands.Contains(info.hand))
		{
			hands.Add(info.hand);
		}
	}

	public virtual void StopInteract(ENT_Player p, ENT_Player.Hand hand = null, string s = "")
	{
		if (hands.Contains(hand))
		{
			hands.Remove(hand);
		}
		if (hands.Count == 0)
		{
			Stop();
		}
		player = null;
		if (curValue <= maxValue)
		{
			failEvent.Invoke();
		}
		if (resetOnStop)
		{
			curValue = 0f;
		}
	}

	internal virtual void Stop()
	{
		if (holding)
		{
			presses++;
			AudioManager.PlaySound(letgoSound, base.transform.position, pressVolume);
			hands.Clear();
			holding = false;
			ChooseMaterial();
			stopEvent.Invoke();
		}
	}

	public void SetValue(float v)
	{
		curValue = v;
	}

	public void SetInteractable(bool b)
	{
		active = b;
		if (!active)
		{
			DropAllHands();
		}
		ChooseMaterial();
	}

	public ObjectTagger GetTagger()
	{
		return base.gameObject.GetComponent<ObjectTagger>();
	}

	public bool CanInteract(Interaction info)
	{
		if (!canUse || (holding && !canTwoHand))
		{
			return false;
		}
		if (presses >= maxPresses && maxPresses > 0)
		{
			return false;
		}
		return active;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	internal virtual void ChooseMaterial()
	{
		if (active && (maxPresses <= 0 || presses < maxPresses))
		{
			if (holding)
			{
				SetMaterial(pressedMaterial);
			}
			else
			{
				SetMaterial(unpressedMaterial);
			}
		}
		else
		{
			SetMaterial(inactiveMaterial);
		}
	}

	public void SetMaterial(Material mat)
	{
		if (rendererComponent != null && mat != null)
		{
			Material[] materials = rendererComponent.materials;
			materials[materialIndex] = mat;
			rendererComponent.SetMaterials(materials.ToList());
		}
	}

	public override void DrawGizmos()
	{
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = activeEvent,
				prependString = "On Start Press: ",
				color = Color.green
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = stopEvent,
				prependString = "On Stop Press: ",
				color = Color.red
			}
		});
	}

	public void DropAllHands()
	{
		if (hands != null && hands.Count != 0)
		{
			for (int num = hands.Count - 1; num >= 0; num--)
			{
				hands[num].DropHand();
			}
		}
	}
}
