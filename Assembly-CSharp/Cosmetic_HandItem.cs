using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Hand Item Cosmetic", menuName = "White Knuckle/Cosmetic/Hand Item")]
public class Cosmetic_HandItem : Cosmetic_Base
{
	[Serializable]
	public class Cosmetic_HandItem_Data
	{
		[Serializable]
		public class ColorPalette
		{
			public string id;

			public string title;

			public string unlock;

			public Texture2D texture;

			public string materialName = "";

			public Material material;

			public Vector3 staminaHSV;
		}

		[Serializable]
		public class HandEmote
		{
			public string id;

			public string name;

			public string spriteName;

			public Sprite sprite;

			public Vector3 position;
		}

		public string id;

		public string author;

		public string description;

		public string cosmeticName;

		public string unlock;

		public List<string> flags;

		public List<HandEmote> emotes;

		public List<ColorPalette> palettes = new List<ColorPalette>();

		public List<string> allowedSpecialtyPoses;

		public bool useGlobalSecondary;

		public List<SwapSprite.SecondaryTextures> globalSecondary;

		public Vector3 hsv;

		internal Material globalMaterialSwap;

		public string globalMaterialBase;

		public bool forceGlobalMaterialOntoHands;

		public bool useCustomStaminaColor;

		public Color customStaminaColor = Color.red;

		public bool useCustomStaminaIconColor;

		public Color customStaminaIconColor = Color.red;

		public bool useCustomStaminaOutlineColor;

		public Color customStaminaOutlineColor = Color.red;

		public Color outlineMaskColor = Color.clear;

		public List<SwapSprite> swapSprites;

		public List<InteractSwap> interactSwaps;
	}

	[Serializable]
	public class SwapSprite
	{
		[Serializable]
		public class SecondaryTextures
		{
			public string name;

			public List<string> secondaryTextureNames;

			public List<Sprite> secondaryTextureSprites;

			public float framerate = 1f;

			public bool seperateAnimation;
		}

		[Serializable]
		public class ItemTransformation
		{
			public List<string> itemIDs;

			public Vector4 transformation;
		}

		public string spriteName;

		public List<string> replacementSpriteNames;

		public List<Sprite> replacementSprites;

		public List<SecondaryTextures> secondaryTextures;

		public float framerate = 1f;

		public float loopTimeOffset;

		public int hand = -1;

		public Vector2 offset;

		public float scale = 1f;

		public float rotation;

		public bool usePalette = true;

		public float opacity = 1f;

		public Material material;

		public string materialBase;

		public List<ItemTransformation> itemTransformations;

		public List<string> requiredItemNames;

		public List<string> requiredStateTags;
	}

	[Serializable]
	public class InteractSwap
	{
		public string spriteName;

		public string replacementSpriteName;

		public Sprite replacementSprite;
	}

	public class HandMaterials
	{
		public int hand;

		public Dictionary<string, Material> handMaterialDict;

		public Dictionary<Material, string> materialBaseDict;

		private int baseMaterialCounter;

		private bool initialized;

		public Material GetMaterial(Material sourceMaterial, int h, string rendererName, Cosmetic_HandItem cosmetic)
		{
			if (!initialized)
			{
				initialized = true;
				handMaterialDict = new Dictionary<string, Material>();
				materialBaseDict = new Dictionary<Material, string>();
				hand = h;
			}
			if (sourceMaterial == null)
			{
				Debug.LogError("NO MATERIAL FOUND: " + rendererName);
				return null;
			}
			if (handMaterialDict == null)
			{
				handMaterialDict = new Dictionary<string, Material>();
			}
			if (materialBaseDict == null)
			{
				materialBaseDict = new Dictionary<Material, string>();
			}
			string text = "";
			if (materialBaseDict.ContainsKey(sourceMaterial))
			{
				text = materialBaseDict[sourceMaterial];
			}
			else
			{
				text = baseMaterialCounter.ToString() ?? "";
				baseMaterialCounter++;
				materialBaseDict.Add(sourceMaterial, text);
			}
			string key = text + "_" + h;
			if (!handMaterialDict.ContainsKey(key))
			{
				Material material = new Material(sourceMaterial);
				material.name += "-checkmat";
				Debug.Log("Adding new material: " + material?.ToString() + " :: " + material.GetInstanceID());
				handMaterialDict.Add(key, material);
				materialBaseDict.Add(material, text);
			}
			if (handMaterialDict.ContainsKey(key))
			{
				return handMaterialDict[key];
			}
			return null;
		}
	}

	private class ReturnSprite
	{
		private bool initialized;

		public SpriteRenderer spriteRenderer;

		public Sprite returnSprite;

		public Vector3 localposition;

		public Material material;

		public Color color;

		public bool Initialize(SpriteRenderer rend, Sprite s, Material m)
		{
			spriteRenderer = rend;
			returnSprite = s;
			material = m;
			color = rend.color;
			initialized = true;
			return true;
		}

		public void Return()
		{
			if (!(spriteRenderer != null) || !(spriteRenderer.transform != null))
			{
				return;
			}
			spriteRenderer.sprite = returnSprite;
			spriteRenderer.transform.localPosition = localposition;
			if (material != null)
			{
				if (spriteRenderer.sharedMaterial != null)
				{
					UnityEngine.Object.Destroy(spriteRenderer.sharedMaterial);
				}
				spriteRenderer.sharedMaterial = material;
			}
			spriteRenderer.color = color;
		}
	}

	public Cosmetic_HandItem_Data cosmeticData;

	private Dictionary<string, Material> materialDict;

	public int currentPaletteId;

	public List<int> currentEmoteIds = new List<int> { 0, 0 };

	private Sprite handSettingsSprite;

	public Material testMaterial;

	private Dictionary<int, HandMaterials> hands;

	private Dictionary<Sprite, string> spriteNames;

	private Dictionary<string, List<SwapSprite>> swapDict;

	private static List<ReturnSprite> returnSprites;

	private Material swapUIMaterial;

	private Material defaultUIMaterial;

	public override string GetCosmeticType()
	{
		return "hand";
	}

	internal void Initialize()
	{
		materialDict = new Dictionary<string, Material>();
		hands = new Dictionary<int, HandMaterials>();
		Material material = Resources.Load<Material>("Cosmetics/Materials/" + cosmeticData.globalMaterialBase);
		if (material != null)
		{
			materialDict.Add(cosmeticData.globalMaterialBase, UnityEngine.Object.Instantiate(material));
		}
		cosmeticData.globalMaterialSwap = material;
		if (cosmeticData.palettes == null)
		{
			cosmeticData.palettes = new List<Cosmetic_HandItem_Data.ColorPalette>();
		}
		swapDict = new Dictionary<string, List<SwapSprite>>();
		returnSprites = new List<ReturnSprite>();
		foreach (SwapSprite swapSprite in cosmeticData.swapSprites)
		{
			if (!swapDict.TryGetValue(swapSprite.spriteName, out var value))
			{
				value = new List<SwapSprite>();
				swapDict.Add(swapSprite.spriteName, value);
			}
			value.Add(swapSprite);
			if (!string.IsNullOrEmpty(swapSprite.materialBase))
			{
				Material material2 = UnityEngine.Object.Instantiate(Resources.Load<Material>("Cosmetics/Materials/" + swapSprite.materialBase));
				if (material2 != null)
				{
					materialDict.Add(swapSprite.materialBase, material2);
				}
				swapSprite.material = material2;
			}
		}
		spriteNames = new Dictionary<Sprite, string>();
		CL_CosmeticManager.CosmeticSaveData.GetCosmeticSaveData().LoadDataIntoCosmetic(this);
		CL_GameManager.gMan.StartCoroutine(PrepareIcons());
		IEnumerator PrepareIcons()
		{
			yield return null;
			if (swapDict.ContainsKey("HND_B1A1") && swapDict["HND_B1A1"][0].replacementSprites != null && swapDict["HND_B1A1"][0].replacementSprites.Count > 0)
			{
				Texture2D texture = swapDict["HND_B1A1"][0].replacementSprites[0].texture;
				bool flag = (cosmeticData.palettes != null) & (cosmeticData.palettes.Count > 0);
				Texture2D texture2D = DarkMachineFunctions.ResizeNearest(texture, 512, 512, !flag, (!flag) ? FilterMode.Bilinear : FilterMode.Point, TextureWrapMode.Clamp, mipmap: true);
				Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
				handSettingsSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.FullRect);
			}
		}
	}

	public override List<string> GetCosmeticSaveData()
	{
		return new List<string>
		{
			"palette:" + currentPaletteId,
			"emote-l:" + currentEmoteIds[0],
			"emote-r:" + currentEmoteIds[1],
			"accessory-opacity:" + accessoryOpacity,
			"hue:" + cosmeticData.hsv.x,
			"saturation:" + cosmeticData.hsv.y,
			"value:" + cosmeticData.hsv.z
		};
	}

	public override void SetCosmeticSaveData(List<string> data)
	{
		if (data == null || data.Count == 0)
		{
			return;
		}
		foreach (string datum in data)
		{
			Dictionary<string, string> dictionary = DarkMachineFunctions.ParseKeyValueString(datum);
			if (dictionary.ContainsKey("palette"))
			{
				int.TryParse(dictionary["palette"], out currentPaletteId);
			}
			if (dictionary.ContainsKey("emote-l"))
			{
				int result = 0;
				int.TryParse(dictionary["emote-l"], out result);
				currentEmoteIds[0] = result;
			}
			if (dictionary.ContainsKey("emote-r"))
			{
				int result2 = 0;
				int.TryParse(dictionary["emote-r"], out result2);
				currentEmoteIds[1] = result2;
			}
			if (dictionary.ContainsKey("accessory-opacity"))
			{
				float.TryParse(dictionary["accessory-opacity"], out accessoryOpacity);
			}
			if (dictionary.ContainsKey("hue"))
			{
				float.TryParse(dictionary["hue"], out cosmeticData.hsv.x);
			}
			if (dictionary.ContainsKey("saturation"))
			{
				float.TryParse(dictionary["saturation"], out cosmeticData.hsv.y);
			}
			if (dictionary.ContainsKey("value"))
			{
				float.TryParse(dictionary["value"], out cosmeticData.hsv.z);
			}
		}
		base.SetCosmeticSaveData(data);
	}

	public void SwapPalette()
	{
		if (cosmeticData.palettes != null && cosmeticData.palettes.Count > 0)
		{
			currentPaletteId++;
			if (currentPaletteId >= cosmeticData.palettes.Count)
			{
				currentPaletteId = 0;
			}
		}
	}

	public static void ReturnSprites()
	{
		if (returnSprites != null && returnSprites.Count > 0)
		{
			for (int num = returnSprites.Count - 1; num >= 0; num--)
			{
				returnSprites[num].Return();
			}
			returnSprites.Clear();
		}
	}

	public void ClearCosmetic()
	{
		ReturnSprites();
	}

	public void SpriteSwap(GameObject root, ENT_Player.Hand hand)
	{
		if (hands == null)
		{
			hands = new Dictionary<int, HandMaterials>();
		}
		if (!hands.ContainsKey(hand.id))
		{
			HandMaterials value = new HandMaterials();
			hands.Add(hand.id, value);
		}
		else
		{
			HandMaterials value = hands[hand.id];
		}
		SpriteRenderer[] componentsInChildren = root.GetComponentsInChildren<SpriteRenderer>();
		if (componentsInChildren == null)
		{
			return;
		}
		int num = 0;
		SpriteRenderer[] array = componentsInChildren;
		foreach (SpriteRenderer checkRenderer in array)
		{
			if (!checkRenderer.enabled || !checkRenderer.gameObject.activeInHierarchy)
			{
				continue;
			}
			num++;
			Material sharedMaterial = checkRenderer.sharedMaterial;
			ReturnSprite returnSprite = new ReturnSprite();
			returnSprite.Initialize(checkRenderer, checkRenderer.sprite, sharedMaterial);
			returnSprite.localposition = checkRenderer.transform.localPosition;
			returnSprites.Add(returnSprite);
			Material tempMaterial = new Material(sharedMaterial);
			checkRenderer.sharedMaterial = tempMaterial;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			Hand_SpriteController component = checkRenderer.gameObject.GetComponent<Hand_SpriteController>();
			if (component != null && cosmeticData.forceGlobalMaterialOntoHands && component.allowGlobalMaterialAssignments)
			{
				if (cosmeticData.globalMaterialSwap != null && cosmeticData.forceGlobalMaterialOntoHands)
				{
					SetTempMaterial(new Material(cosmeticData.globalMaterialSwap));
					flag3 = true;
				}
				if (cosmeticData.useGlobalSecondary && cosmeticData.globalSecondary != null && cosmeticData.globalSecondary.Count > 0)
				{
					flag3 = true;
					foreach (SwapSprite.SecondaryTextures item2 in cosmeticData.globalSecondary)
					{
						if (item2.secondaryTextureSprites.Count > 0)
						{
							int index = Mathf.FloorToInt(Mathf.Repeat(Time.time * item2.framerate, item2.secondaryTextureSprites.Count));
							checkRenderer.sharedMaterial.SetTexture(item2.name, item2.secondaryTextureSprites[index].texture);
							flag2 = true;
						}
					}
				}
			}
			string text = "";
			bool flag4 = checkRenderer != null && checkRenderer.sprite != null;
			float num2 = 1f;
			if (swapDict == null)
			{
				swapDict = new Dictionary<string, List<SwapSprite>>();
			}
			if (flag4 && spriteNames != null)
			{
				if (!spriteNames.ContainsKey(checkRenderer.sprite))
				{
					spriteNames.Add(checkRenderer.sprite, checkRenderer.sprite.name);
				}
				else
				{
					text = spriteNames[checkRenderer.sprite];
				}
			}
			else
			{
				UT_AccessoryRenderer component2 = checkRenderer.GetComponent<UT_AccessoryRenderer>();
				if (component2 != null)
				{
					text = component2.cosmeticID;
					flag4 = true;
					num2 *= accessoryOpacity;
				}
			}
			if (flag4)
			{
				string item = "";
				if (hand.GetHandItem() != null)
				{
					item = hand.GetHandItem().item.handItemAsset.name;
				}
				SwapSprite swapSprite = null;
				if (swapDict.TryGetValue(text, out var value2))
				{
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					foreach (SwapSprite item3 in value2)
					{
						if (item3.hand != -1)
						{
							if (hand.id != item3.hand)
							{
								continue;
							}
							flag5 = true;
						}
						else if (flag5)
						{
							continue;
						}
						if (item3.requiredItemNames != null && item3.requiredItemNames.Count > 0)
						{
							if (!(hand.GetHandItem() != null) || (!item3.requiredItemNames.Contains(item) && !item3.requiredItemNames.Contains(hand.GetHandItem().item.itemName)))
							{
								continue;
							}
							flag6 = true;
						}
						else if (flag6)
						{
							continue;
						}
						if (item3.requiredStateTags != null && item3.requiredStateTags.Count > 0)
						{
							if (!hand.GetPlayer().HasPlayerStateInFlagList(item3.requiredStateTags, hand.id))
							{
								continue;
							}
							flag7 = true;
						}
						else if (flag7)
						{
							continue;
						}
						swapSprite = item3;
					}
				}
				if (swapSprite != null)
				{
					if (swapSprite.hand != -1 && swapSprite.hand != hand.id)
					{
						continue;
					}
					if (text == swapSprite.spriteName)
					{
						int num3 = 0;
						if (swapSprite.replacementSprites != null && swapSprite.replacementSprites.Count > 0)
						{
							if (swapSprite.replacementSprites.Count > 0)
							{
								num3 = Mathf.FloorToInt(Mathf.Repeat(Time.time * swapSprite.framerate + ((hand.id == 0) ? swapSprite.loopTimeOffset : 0f), swapSprite.replacementSprites.Count));
							}
							Sprite sprite = swapSprite.replacementSprites[num3];
							if (checkRenderer.sprite != sprite)
							{
								checkRenderer.sprite = sprite;
								checkRenderer.color *= new Color(1f, 1f, 1f, swapSprite.opacity * num2);
							}
						}
						if (swapSprite.secondaryTextures != null && !flag3)
						{
							if (swapSprite.material != null)
							{
								SetTempMaterial(new Material(swapSprite.material));
								flag3 = true;
							}
							else if (cosmeticData.globalMaterialSwap != null && !flag3)
							{
								SetTempMaterial(new Material(cosmeticData.globalMaterialSwap));
								flag3 = true;
							}
						}
						if (cosmeticData.palettes != null && cosmeticData.palettes.Count > currentPaletteId && cosmeticData.palettes[currentPaletteId].texture != null)
						{
							if (cosmeticData.palettes[currentPaletteId].material != null)
							{
								SetTempMaterial(new Material(cosmeticData.palettes[currentPaletteId].material));
							}
							else if (cosmeticData.palettes[currentPaletteId].materialName != "")
							{
								cosmeticData.palettes[currentPaletteId].material = new Material(Resources.Load<Material>("Cosmetics/Materials/" + cosmeticData.palettes[currentPaletteId].materialName));
							}
							checkRenderer.sharedMaterial.SetTexture("_PaletteBase", cosmeticData.palettes[currentPaletteId].texture);
							checkRenderer.sharedMaterial.SetFloat("_PaletteBaseBlend", 1f);
							checkRenderer.sharedMaterial.SetVector("_StaminaHSV", cosmeticData.palettes[currentPaletteId].staminaHSV);
						}
						checkRenderer.sharedMaterial.SetVector("_HSV", cosmeticData.hsv);
						if (swapSprite.secondaryTextures != null && swapSprite.secondaryTextures.Count > 0)
						{
							foreach (SwapSprite.SecondaryTextures secondaryTexture in swapSprite.secondaryTextures)
							{
								int num4 = num3;
								if (secondaryTexture.seperateAnimation)
								{
									num4 = Mathf.FloorToInt(Mathf.Repeat(Time.time * secondaryTexture.framerate, secondaryTexture.secondaryTextureSprites.Count));
								}
								if (secondaryTexture != null && secondaryTexture.secondaryTextureSprites.Count > 0 && (secondaryTexture.secondaryTextureSprites.Count > num4 || num4 == 0) && secondaryTexture.secondaryTextureSprites[num4].texture != null)
								{
									checkRenderer.sharedMaterial.SetTexture(secondaryTexture.name, secondaryTexture.secondaryTextureSprites[num4].texture);
								}
							}
						}
						flag = true;
						Vector2 vector = new Vector2(swapSprite.offset.x, swapSprite.offset.y);
						float num5 = swapSprite.rotation;
						if (checkRenderer.sharedMaterial.HasVector("_Transformation"))
						{
							if (vector.x == 0f || vector.y == 0f)
							{
								Vector4 vector2 = checkRenderer.sharedMaterial.GetVector("_Transformation");
								if (vector.x == 0f)
								{
									vector.x = vector2.x;
								}
								if (vector.y == 0f)
								{
									vector.y = vector2.y;
								}
							}
							float num6 = swapSprite.scale;
							if (swapSprite.itemTransformations != null && swapSprite.itemTransformations.Count > 0)
							{
								foreach (SwapSprite.ItemTransformation itemTransformation in swapSprite.itemTransformations)
								{
									if (itemTransformation.itemIDs.Contains(item))
									{
										vector.x += itemTransformation.transformation.x;
										vector.y += itemTransformation.transformation.y;
										num6 *= itemTransformation.transformation.z;
										num5 += itemTransformation.transformation.w;
										break;
									}
								}
							}
							checkRenderer.sharedMaterial.SetVector("_Transformation", new Vector4(vector.x, vector.y, num6, num5));
						}
						if (cosmeticData.palettes != null && cosmeticData.palettes.Count > currentPaletteId && cosmeticData.palettes[currentPaletteId].texture != null && !swapSprite.usePalette)
						{
							checkRenderer.sharedMaterial.SetFloat("_PaletteBaseBlend", 0f);
						}
					}
				}
			}
			if ((flag || flag2) && checkRenderer.sprite != null && checkRenderer.sharedMaterial.HasVector("_OverlayRect"))
			{
				Vector4 value3 = new Vector4(checkRenderer.sprite.textureRect.x, checkRenderer.sprite.textureRect.y, checkRenderer.sprite.textureRect.width, checkRenderer.sprite.textureRect.height);
				value3.x /= checkRenderer.sprite.texture.width;
				value3.y /= checkRenderer.sprite.texture.height;
				value3.z /= checkRenderer.sprite.texture.width;
				value3.w /= checkRenderer.sprite.texture.height;
				checkRenderer.sharedMaterial.SetVector("_OverlayRect", value3);
			}
			void SetTempMaterial(Material newTempMat)
			{
				UnityEngine.Object.Destroy(tempMaterial);
				tempMaterial = newTempMat;
				checkRenderer.sharedMaterial = tempMaterial;
				testMaterial = checkRenderer.sharedMaterial;
			}
		}
	}

	public void SwapUISprite(Image image)
	{
		if (defaultUIMaterial == null)
		{
			defaultUIMaterial = Resources.Load<Material>("Cosmetics/Materials/Item_Hand_Material");
		}
		if (!(image != null))
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		Material material = defaultUIMaterial;
		if (cosmeticData.globalMaterialSwap != null && cosmeticData.forceGlobalMaterialOntoHands)
		{
			material = cosmeticData.globalMaterialSwap;
		}
		if (cosmeticData.palettes != null && currentPaletteId >= cosmeticData.palettes.Count)
		{
			currentPaletteId = 0;
		}
		if (cosmeticData.palettes != null && cosmeticData.palettes.Count > 0 && cosmeticData.palettes[currentPaletteId].materialName != "")
		{
			material = Resources.Load<Material>("Cosmetics/Materials/" + cosmeticData.palettes[currentPaletteId].materialName);
		}
		if (material != null)
		{
			if (swapUIMaterial != null)
			{
				UnityEngine.Object.Destroy(swapUIMaterial);
			}
			swapUIMaterial = UnityEngine.Object.Instantiate(material);
			image.material = swapUIMaterial;
		}
		if (cosmeticData.useGlobalSecondary && cosmeticData.globalSecondary != null && cosmeticData.globalSecondary.Count > 0)
		{
			foreach (SwapSprite.SecondaryTextures item in cosmeticData.globalSecondary)
			{
				if (item.secondaryTextureSprites.Count > 0)
				{
					image.material.SetTexture(item.name, item.secondaryTextureSprites[0].texture);
					flag2 = true;
				}
			}
		}
		string text = image.sprite.name;
		if (image.sprite != null)
		{
			Debug.Log("Setting Sprite: " + text);
			SwapSprite swapSprite = null;
			if (swapDict != null && swapDict.ContainsKey(text))
			{
				swapSprite = swapDict[text][0];
			}
			if (swapSprite != null)
			{
				Debug.Log("Swap found!");
				if (text == swapSprite.spriteName)
				{
					int num = 0;
					if (swapSprite.replacementSprites != null && swapSprite.replacementSprites.Count > 0)
					{
						if (swapSprite.replacementSprites.Count > 0)
						{
							num = Mathf.FloorToInt(Mathf.Repeat(Time.time * swapSprite.framerate, swapSprite.replacementSprites.Count));
						}
						Sprite sprite = swapSprite.replacementSprites[num];
						if (image.sprite != sprite)
						{
							image.sprite = sprite;
						}
					}
					if (swapSprite.secondaryTextures != null && swapSprite.material != null)
					{
						if (swapUIMaterial != null)
						{
							UnityEngine.Object.Destroy(swapUIMaterial);
						}
						swapUIMaterial = UnityEngine.Object.Instantiate(swapSprite.material);
						swapUIMaterial.CopyPropertiesFromMaterial(swapSprite.material);
						image.material = swapUIMaterial;
					}
					if (swapSprite.secondaryTextures != null && swapSprite.secondaryTextures.Count > 0)
					{
						foreach (SwapSprite.SecondaryTextures secondaryTexture in swapSprite.secondaryTextures)
						{
							if (secondaryTexture != null && secondaryTexture.secondaryTextureSprites.Count > 0 && (secondaryTexture.secondaryTextureSprites.Count > num || num == 0) && secondaryTexture.secondaryTextureSprites[num].texture != null)
							{
								image.material.SetTexture(secondaryTexture.name, secondaryTexture.secondaryTextureSprites[num].texture);
							}
						}
					}
					flag = true;
				}
			}
		}
		if (cosmeticData.palettes != null && cosmeticData.palettes.Count > 0)
		{
			image.material.SetTexture("_PaletteBase", cosmeticData.palettes[currentPaletteId].texture);
			image.material.SetFloat("_PaletteBaseBlend", 1f);
			image.material.SetVector("_StaminaHSV", cosmeticData.palettes[currentPaletteId].staminaHSV);
		}
		image.material.SetVector("_HSV", cosmeticData.hsv);
		image.material.SetColor("_OutlineMaskColor", GetOutlineMaskColor());
		if ((flag || flag2) && image.sprite != null && image.material.HasVector("_OverlayRect"))
		{
			Vector4 value = new Vector4(image.sprite.textureRect.x, image.sprite.textureRect.y, image.sprite.textureRect.width, image.sprite.textureRect.height);
			value.x /= image.sprite.texture.width;
			value.y /= image.sprite.texture.height;
			value.z /= image.sprite.texture.width;
			value.w /= image.sprite.texture.height;
			image.material.SetVector("_OverlayRect", value);
		}
	}

	public Sprite GetInteractSwap(Sprite sprite)
	{
		foreach (InteractSwap interactSwap in cosmeticData.interactSwaps)
		{
			if (interactSwap.spriteName == sprite.name)
			{
				return interactSwap.replacementSprite;
			}
		}
		return null;
	}

	public Color GetCustomStaminaColor()
	{
		return cosmeticData.customStaminaColor;
	}

	public Color GetCustomStaminaIconColor()
	{
		if (cosmeticData.useCustomStaminaIconColor)
		{
			return cosmeticData.customStaminaIconColor;
		}
		return cosmeticData.customStaminaColor;
	}

	public Color GetCustomStaminaOutlineColor()
	{
		if (cosmeticData.useCustomStaminaOutlineColor)
		{
			return cosmeticData.customStaminaOutlineColor;
		}
		return cosmeticData.customStaminaColor;
	}

	public Color GetOutlineMaskColor()
	{
		return cosmeticData.outlineMaskColor;
	}

	public Sprite GetHandSettingsSprite()
	{
		return handSettingsSprite;
	}

	public void AddPalette(string id, Texture2D tex)
	{
		Cosmetic_HandItem_Data.ColorPalette colorPalette = new Cosmetic_HandItem_Data.ColorPalette();
		colorPalette.id = id.ToLower();
		colorPalette.title = id.FirstCharacterToUpper();
		colorPalette.texture = tex;
		foreach (Cosmetic_HandItem_Data.ColorPalette palette in cosmeticData.palettes)
		{
			if (palette.id.ToLower() == id.ToLower())
			{
				return;
			}
		}
		cosmeticData.palettes.Add(colorPalette);
	}

	public Cosmetic_HandItem_Data.HandEmote GetEmoteForHand(ENT_Player.Hand hand)
	{
		if (currentEmoteIds != null && currentEmoteIds.Count > hand.id && cosmeticData.emotes != null && currentEmoteIds[hand.id] < cosmeticData.emotes.Count)
		{
			return cosmeticData.emotes[currentEmoteIds[hand.id]];
		}
		return null;
	}
}
