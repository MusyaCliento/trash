using UnityEngine;
using UnityEngine.Events;

public class CL_ToggleButton : CL_Button
{
	public bool state;

	public UnityEvent onEvent;

	public UnityEvent offEvent;

	[Header("Audio")]
	public AudioClip onSound;

	public AudioClip offSound;

	[Header("Materials")]
	public Material offMaterial;

	public override void Interact()
	{
		if (CanInteract())
		{
			Toggle();
		}
		base.Interact();
	}

	public override void Interact(Clickable.InteractionInfo info)
	{
		base.Interact(info);
	}

	private void Toggle()
	{
		state = !state;
		if (state)
		{
			onEvent.Invoke();
			AudioManager.PlaySound(onSound, base.transform.position);
		}
		else
		{
			offEvent.Invoke();
			AudioManager.PlaySound(offSound, base.transform.position);
		}
		ChooseMaterial();
	}

	internal override void ChooseMaterial()
	{
		if (active && (!cooldown || !inactiveMaterialOnCooldown))
		{
			if (!state)
			{
				SetMaterial(offMaterial);
			}
			else
			{
				SetMaterial(activeMaterial);
			}
		}
		else
		{
			SetMaterial(inactiveMaterial);
		}
	}

	public void SetState(bool b)
	{
		state = b;
		if (state)
		{
			onEvent.Invoke();
			AudioManager.PlaySound(onSound, base.transform.position);
		}
		else
		{
			offEvent.Invoke();
			AudioManager.PlaySound(offSound, base.transform.position);
		}
		ChooseMaterial();
	}

	public void SetStateWithoutEvent(bool b)
	{
		state = b;
		ChooseMaterial();
	}
}
