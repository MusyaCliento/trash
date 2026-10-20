using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class CL_Button : MonoBehaviourGizmos, Clickable
{
	public bool active = true;

	[Header("Events")]
	public UnityEvent activeEvent;

	[HideInInspector]
	public bool hasBeenPressed;

	public int maxPresses;

	public float pressCooldown = 0.05f;

	private int presses;

	public bool projectilesCanPress = true;

	public bool hammerCanPress = true;

	internal bool cooldown;

	[Header("Audio")]
	public AudioClip pressSound;

	public AudioClip cooldownEndSound;

	[Header("Materials")]
	public int materialIndex;

	public bool inactiveMaterialOnCooldown;

	public Material activeMaterial;

	public Material inactiveMaterial;

	private MeshRenderer rendererComponent;

	private Coroutine cooldownRoutine;

	private void Start()
	{
		rendererComponent = GetComponent<MeshRenderer>();
		ChooseMaterial();
	}

	private void OnEnable()
	{
		if (cooldown)
		{
			cooldownRoutine = StartCoroutine(Cooldown());
		}
	}

	public virtual void Interact()
	{
		if (!cooldown && (maxPresses <= 0 || presses < maxPresses) && active)
		{
			presses++;
			cooldownRoutine = StartCoroutine(Cooldown());
			activeEvent.Invoke();
			hasBeenPressed = true;
			AudioManager.PlaySound(pressSound, base.transform.position);
		}
	}

	public virtual void Interact(Clickable.InteractionInfo info)
	{
		Interact();
	}

	private IEnumerator Cooldown()
	{
		cooldown = true;
		ChooseMaterial();
		yield return new WaitForSeconds(pressCooldown);
		cooldown = false;
		ChooseMaterial();
		AudioManager.PlaySound(cooldownEndSound, base.transform.position);
		cooldownRoutine = null;
	}

	public void Reset()
	{
		hasBeenPressed = false;
		presses = 0;
		ChooseMaterial();
	}

	public bool CanInteract(Interaction info)
	{
		if (cooldown)
		{
			return false;
		}
		if (presses >= maxPresses && maxPresses > 0)
		{
			return false;
		}
		return active;
	}

	public bool CanInteract()
	{
		if (cooldown)
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

	public ObjectTagger GetTagger()
	{
		return base.gameObject.GetComponent<ObjectTagger>();
	}

	public void SetInteractable(bool b)
	{
		active = b;
		ChooseMaterial();
	}

	internal virtual void ChooseMaterial()
	{
		if (active && (!cooldown || !inactiveMaterialOnCooldown) && (maxPresses <= 0 || presses < maxPresses))
		{
			SetMaterial(activeMaterial);
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
				prependString = "On Press: ",
				color = Color.green
			}
		});
	}
}
