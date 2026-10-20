using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandItem_Crafter : HandItem
{
	public LayerMask pickupMask;

	public List<Craft_Base> craftables;

	private bool isPickingUp;

	private List<GameEntity> pickedupEntities = new List<GameEntity>();

	public float pickupRadius = 0.25f;

	public float pickupDistance = 3f;

	public float pickupForce = 1f;

	public float holdDistance = 2f;

	public float holdOffset = 0.2f;

	public bool limitToItems;

	public List<string> tagWhitelist;

	public List<string> tagBlacklist;

	public bool allowCrafting = true;

	public float craftTimer = 1f;

	private float curCraftTime;

	public ParticleSystem craftParticles;

	public UT_AudioClipHandler clipHandler;

	public AudioSource audioCraftLoop;

	private float recoveryTime;

	public float tossForce = 20f;

	public override void Update()
	{
		base.Update();
		anim.SetBool("Activated", isPickingUp);
		recoveryTime -= Time.deltaTime;
		if (isPickingUp)
		{
			if (Inventory.IsShowingInventory())
			{
				StopUse();
				return;
			}
			Transform transform = hand.GetPlayer().cam.transform;
			RaycastHit[] array = Physics.SphereCastAll(transform.position, pickupRadius, transform.forward, pickupDistance, pickupMask);
			foreach (RaycastHit raycastHit in array)
			{
				GameEntity componentInParent = raycastHit.collider.GetComponentInParent<GameEntity>();
				if (componentInParent != null && !pickedupEntities.Contains(componentInParent))
				{
					ObjectTagger tagger = componentInParent.GetTagger();
					if (tagger != null && (tagWhitelist.Count == 0 || tagger.HasTagInList(tagWhitelist.ToArray())) && (tagBlacklist.Count == 0 || !tagger.HasTagInList(tagBlacklist.ToArray())) && (!limitToItems || (bool)componentInParent.GetComponent<Item_Object>()) && (!componentInParent.TryGetComponent<Item_Object>(out var component) || (!component.itemData.HasTag("inLocker") && !component.itemData.HasTag("unpurchased"))))
					{
						pickedupEntities.Add(componentInParent);
						clipHandler.PlaySound("item:pickupitem");
						curCraftTime = 0f;
						anim.SetTrigger("Use");
					}
				}
			}
			Vector3 vector = transform.position + transform.forward * holdDistance;
			if (pickedupEntities.Count <= 0)
			{
				return;
			}
			Vector3[] array2 = DarkMachineFunctions.GenerateEquidistantVectors(pickedupEntities.Count);
			int num = 0;
			foreach (GameEntity pickedupEntity in pickedupEntities)
			{
				Vector3 vector2 = vector;
				if (array2.Length > num && num > 0)
				{
					vector2 += array2[num] * holdOffset * num;
				}
				Vector3 vector3 = (vector2 - pickedupEntity.transform.position) * pickupForce;
				Rigidbody component2 = pickedupEntity.GetComponent<Rigidbody>();
				if (component2 != null)
				{
					component2.linearVelocity = vector3;
					component2.isKinematic = false;
					if (component2.TryGetComponent<UT_SoftParent>(out var component3))
					{
						component3.ClearParent();
						Object.Destroy(component3);
					}
				}
				else
				{
					pickedupEntity.SetForce(vector3);
				}
				num++;
				if (!pickedupEntity.gameObject.activeSelf)
				{
					pickedupEntities.Remove(pickedupEntity);
					return;
				}
			}
			TryCraft();
		}
		else
		{
			audioCraftLoop.volume = Mathf.Lerp(audioCraftLoop.volume, 0f, Time.deltaTime * 2f);
		}
	}

	private void TryCraft()
	{
		List<Item> list = new List<Item>();
		foreach (GameEntity pickedupEntity in pickedupEntities)
		{
			if (!(pickedupEntity == null) && pickedupEntity.TryGetComponent<Item_Object>(out var component))
			{
				list.Add(component.itemData);
			}
		}
		if (list.Count > 0)
		{
			if (curCraftTime > craftTimer)
			{
				curCraftTime = 0f;
				{
					foreach (Craft_Base craftable in craftables)
					{
						Transform transform = hand.GetPlayer().cam.transform;
						Vector3 position = transform.position + transform.forward * holdDistance;
						List<GameEntity> list2 = craftable.CraftObjectFromItems(list);
						if (list2 == null || list2.Count <= 0)
						{
							continue;
						}
						foreach (GameEntity item in list2)
						{
							GameEntity gameEntity = Object.Instantiate(item, position, Quaternion.identity, WorldLoader.GetCurrentLevelParentRoot());
							gameEntity.transform.localScale = Vector3.one * 0.05f;
							gameEntity.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad);
							craftParticles.transform.position = gameEntity.transform.position;
						}
						craftParticles.Play();
						clipHandler.PlaySound("item:craft");
						pickedupEntities.Clear();
						break;
					}
					return;
				}
			}
			if (!allowCrafting)
			{
				return;
			}
			bool flag = false;
			foreach (Craft_Base craftable2 in craftables)
			{
				if (craftable2.CanCraftFromItems(list).canCraft)
				{
					curCraftTime += Time.deltaTime;
					audioCraftLoop.volume = Mathf.Lerp(audioCraftLoop.volume, curCraftTime / craftTimer, Time.deltaTime * 2f);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				audioCraftLoop.volume = Mathf.Lerp(audioCraftLoop.volume, 0f, Time.deltaTime * 4f);
			}
		}
		else
		{
			curCraftTime = 0f;
			audioCraftLoop.volume = Mathf.Lerp(audioCraftLoop.volume, 0f, Time.deltaTime * 2f);
		}
	}

	public override void Use()
	{
		base.Use();
		isPickingUp = true;
		clipHandler.PlaySound("item:activate");
	}

	public override void StopUse()
	{
		base.StopUse();
		if (isPickingUp)
		{
			pickedupEntities.Clear();
			isPickingUp = false;
			curCraftTime = 0f;
			clipHandler.PlaySound("item:deactivate");
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		if (isPickingUp || recoveryTime > 0f)
		{
			return false;
		}
		return base.CanDrop(pocket);
	}

	public void PrintAllCrafts()
	{
		string text = "";
		foreach (Craft_Base craftable in craftables)
		{
			text = text + "# " + craftable.name + "\n";
			foreach (Craft_Base.CraftObject craft in craftable.crafts)
			{
				text = text + "### CRAFT ID: " + craft.craftID + "\n";
				text += "#### INPUTS\n";
				foreach (Craft_Base.CraftGroup requiredGroup in craft.requiredGroups)
				{
					text = text + "##### INPUT GROUP: " + requiredGroup.desc + "\n";
					text += $"*Required Item Count: {requiredGroup.requiredCount}*\n\n";
					text += "**Optional Tag Sets**\n";
					foreach (Craft_Base.CraftGroup.TagCombination possibleInputTag in requiredGroup.possibleInputTags)
					{
						text += $"Index: {requiredGroup.possibleInputTags.IndexOf(possibleInputTag)}\n";
						foreach (string item in possibleInputTag.tagComboSet)
						{
							text = text + "  - " + item + "\n";
						}
						text += "\n";
					}
					text += "\n";
					if (requiredGroup.inputBlacklistTags != null && requiredGroup.inputBlacklistTags.Count > 0)
					{
						text += $"**Tag Blacklist:** {requiredGroup.inputBlacklistTags.Count}\n";
						foreach (string inputBlacklistTag in requiredGroup.inputBlacklistTags)
						{
							text = text + "  - " + inputBlacklistTag + "\n";
						}
					}
					else
					{
						text += "**Tag Blacklist:** N/A\n";
					}
					text += "\n";
				}
				text += "#### OUTPUTS</b>\n";
				foreach (Craft_Base.CraftOutput output in craft.outputs)
				{
					text += $"**OUTPUT SET** {craft.outputs.IndexOf(output)}:\n";
					foreach (GameEntity outputEntity in output.outputEntities)
					{
						text = text + "- " + outputEntity.name + "\n";
					}
				}
				text += "- - - - \n\n";
			}
			text += "\n";
		}
		Debug.Log(text);
	}

	public override void OnTryDrop()
	{
		if (isPickingUp)
		{
			foreach (GameEntity pickedupEntity in pickedupEntities)
			{
				if (!(pickedupEntity == null) && pickedupEntity.TryGetComponent<Rigidbody>(out var component))
				{
					component.linearVelocity = base.transform.forward * tossForce;
				}
			}
			StopUse();
			recoveryTime = 0.25f;
		}
		base.OnTryDrop();
	}
}
