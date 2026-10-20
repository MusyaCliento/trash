using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CL_CosmeticManager
{
	[Serializable]
	public class CosmeticSaveData
	{
		[Serializable]
		public class CosmeticInfo
		{
			public string tag;

			public string id;

			public List<string> data;
		}

		public CosmeticInfo leftHandCosmetic = new CosmeticInfo
		{
			tag = "hand",
			id = "default"
		};

		public CosmeticInfo rightHandCosmetic = new CosmeticInfo
		{
			tag = "hand",
			id = "default"
		};

		public List<CosmeticInfo> activeCosmetics;

		public List<CosmeticInfo> cosmeticsSaveInfo;

		public void FillNewCosmeticInfo(Cosmetic_Base cosmetic)
		{
			if (cosmeticsSaveInfo == null)
			{
				cosmeticsSaveInfo = new List<CosmeticInfo>();
			}
			foreach (CosmeticInfo item2 in cosmeticsSaveInfo)
			{
				if (cosmetic.cosmeticInfo.id == item2.id)
				{
					return;
				}
			}
			CosmeticInfo item = new CosmeticInfo
			{
				tag = cosmetic.cosmeticInfo.tag,
				id = cosmetic.cosmeticInfo.id
			};
			cosmeticsSaveInfo.Add(item);
		}

		public void UpdateCosmeticData(Cosmetic_Base cosmetic, List<string> data)
		{
			if (cosmeticsSaveInfo == null)
			{
				cosmeticsSaveInfo = new List<CosmeticInfo>();
			}
			foreach (CosmeticInfo item in cosmeticsSaveInfo)
			{
				if (cosmetic.cosmeticInfo.id == item.id)
				{
					item.data = data;
				}
			}
		}

		public void LoadDataIntoCosmetic(Cosmetic_Base cosmetic)
		{
			if (cosmeticsSaveInfo == null)
			{
				cosmeticsSaveInfo = new List<CosmeticInfo>();
			}
			foreach (CosmeticInfo item in cosmeticsSaveInfo)
			{
				if (cosmetic.cosmeticInfo.id == item.id)
				{
					cosmetic.SetCosmeticSaveData(item.data);
				}
			}
		}

		public void ToggleHandCosmetic(Cosmetic_HandItem handCosmetic, int hand)
		{
			if (hand == 0)
			{
				if (leftHandCosmetic.id == handCosmetic.cosmeticData.id)
				{
					leftHandCosmetic = new CosmeticInfo
					{
						tag = "hand",
						id = "default"
					};
				}
				else
				{
					leftHandCosmetic = new CosmeticInfo
					{
						tag = "hand",
						id = handCosmetic.cosmeticData.id
					};
				}
			}
			else if (rightHandCosmetic.id == handCosmetic.cosmeticData.id)
			{
				rightHandCosmetic = new CosmeticInfo
				{
					tag = "hand",
					id = "default"
				};
			}
			else
			{
				rightHandCosmetic = new CosmeticInfo
				{
					tag = "hand",
					id = handCosmetic.cosmeticData.id
				};
			}
		}

		public void ActivateHandCosmetic(Cosmetic_HandItem handCosmetic, int hand, bool state)
		{
			if (hand == 0)
			{
				if (!state)
				{
					leftHandCosmetic = new CosmeticInfo
					{
						tag = "hand",
						id = "default"
					};
				}
				else
				{
					leftHandCosmetic = new CosmeticInfo
					{
						tag = "hand",
						id = handCosmetic.cosmeticData.id
					};
				}
			}
			else if (!state)
			{
				rightHandCosmetic = new CosmeticInfo
				{
					tag = "hand",
					id = "default"
				};
			}
			else
			{
				rightHandCosmetic = new CosmeticInfo
				{
					tag = "hand",
					id = handCosmetic.cosmeticData.id
				};
			}
		}

		public void ActivateCosmetic(Cosmetic_Base cosmetic, bool state)
		{
			if (activeCosmetics == null)
			{
				activeItemCosmetics = new List<Cosmetic_Base>();
			}
			CosmeticInfo cosmeticWithTag = GetCosmeticWithTag(cosmetic.cosmeticInfo.tag);
			Debug.Log("Activating Cosmetic: " + cosmetic.cosmeticInfo.id + " :: " + state);
			if (state)
			{
				if (cosmeticWithTag == null)
				{
					CosmeticInfo cosmeticInfo = new CosmeticInfo();
					cosmeticInfo.id = cosmetic.cosmeticInfo.id;
					cosmeticInfo.tag = cosmetic.cosmeticInfo.tag;
					activeCosmetics.Add(cosmeticInfo);
					Debug.Log("Adding new Cosmetic: " + cosmetic.cosmeticInfo.id);
				}
				else
				{
					cosmeticWithTag.id = cosmetic.cosmeticInfo.id;
				}
			}
			else if (cosmeticWithTag != null)
			{
				Debug.Log("Removing Cosmetic from Active: " + cosmetic.cosmeticInfo.id);
				activeCosmetics.Remove(cosmeticWithTag);
				if (cosmeticWithTag.tag == "hammer")
				{
					CosmeticInfo item = new CosmeticInfo
					{
						id = "hammer",
						tag = "hammer"
					};
					activeCosmetics.Add(item);
				}
				if (cosmeticWithTag.tag == "voice")
				{
					CosmeticInfo item2 = new CosmeticInfo
					{
						id = "climber_01",
						tag = "voice"
					};
					activeCosmetics.Add(item2);
				}
			}
		}

		public CosmeticInfo GetCosmeticWithTag(string tag)
		{
			if (activeCosmetics == null)
			{
				activeCosmetics = new List<CosmeticInfo>();
			}
			if (activeCosmetics.Count == 0)
			{
				return null;
			}
			for (int num = activeCosmetics.Count - 1; num >= 0; num--)
			{
				if (activeCosmetics[num].tag == tag)
				{
					return activeCosmetics[num];
				}
			}
			return null;
		}

		public bool CosmeticIsActive(string id)
		{
			if (activeCosmetics == null)
			{
				activeCosmetics = new List<CosmeticInfo>();
			}
			for (int num = activeCosmetics.Count - 1; num >= 0; num--)
			{
				if (activeCosmetics[num].id == id)
				{
					return true;
				}
			}
			return false;
		}

		public static CosmeticSaveData GetCosmeticSaveData()
		{
			return SettingsManager.settings.cosmeticSaveData;
		}
	}

	public static bool initialized;

	internal static List<Cosmetic_HandItem> cosmeticHands;

	private static Dictionary<string, Cosmetic_HandItem> cosmeticHandDict;

	private static List<Cosmetic_Item> cosmeticItems;

	private static Dictionary<string, Cosmetic_Item> cosmeticItemDict;

	private static List<Cosmetic_Voice> cosmeticVoices;

	private static Dictionary<string, Cosmetic_Voice> cosmeticVoiceDict;

	private static List<Cosmetic_Base> loadedCosmetics;

	public static List<Cosmetic_Base> activeItemCosmetics;

	public static void Initialize()
	{
		if (initialized)
		{
			return;
		}
		initialized = true;
		cosmeticHands = new List<Cosmetic_HandItem>();
		cosmeticHandDict = new Dictionary<string, Cosmetic_HandItem>();
		Cosmetic_HandItem cosmetic_HandItem = Resources.Load<Cosmetic_HandItem>("Cosmetics/Hand Items/Cosmetic_Hand_Default");
		cosmeticHands.Add(cosmetic_HandItem);
		cosmeticHandDict.Add(cosmetic_HandItem.cosmeticInfo.id, cosmetic_HandItem);
		Debug.Log("Cosmetic Items: " + CL_AssetManager.GetFullCombinedAssetDatabase().cosmeticItems.Count);
		foreach (Cosmetic_HandItem cosmeticHand in CL_AssetManager.GetFullCombinedAssetDatabase().cosmeticHands)
		{
			if (!cosmeticHandDict.ContainsKey(cosmeticHand.cosmeticInfo.id))
			{
				cosmeticHands.Add(cosmeticHand);
				cosmeticHandDict.Add(cosmeticHand.cosmeticInfo.id, cosmeticHand);
				cosmeticHand.Initialize();
			}
		}
		cosmeticItems = new List<Cosmetic_Item>();
		cosmeticItemDict = new Dictionary<string, Cosmetic_Item>();
		foreach (Cosmetic_Item cosmeticItem in CL_AssetManager.GetFullCombinedAssetDatabase().cosmeticItems)
		{
			if (!cosmeticItemDict.ContainsKey(cosmeticItem.cosmeticInfo.id))
			{
				cosmeticItems.Add(cosmeticItem);
				cosmeticItemDict.Add(cosmeticItem.cosmeticInfo.id, cosmeticItem);
				cosmeticItem.Initialize();
			}
		}
		cosmeticVoices = new List<Cosmetic_Voice>();
		cosmeticVoiceDict = new Dictionary<string, Cosmetic_Voice>();
		foreach (Cosmetic_Voice cosmeticVoice in CL_AssetManager.GetFullCombinedAssetDatabase().cosmeticVoices)
		{
			if (!cosmeticVoiceDict.ContainsKey(cosmeticVoice.cosmeticInfo.id))
			{
				cosmeticVoices.Add(cosmeticVoice);
				cosmeticVoiceDict.Add(cosmeticVoice.cosmeticInfo.id, cosmeticVoice);
				cosmeticVoice.Initialize();
			}
		}
		ScanForCosmetics();
		loadedCosmetics = new List<Cosmetic_Base>();
		loadedCosmetics.AddRange(cosmeticHands);
		loadedCosmetics.AddRange(cosmeticItems);
		loadedCosmetics.AddRange(cosmeticVoices);
		activeItemCosmetics = new List<Cosmetic_Base>();
		foreach (Cosmetic_Base loadedCosmetic in loadedCosmetics)
		{
			SettingsManager.settings.cosmeticSaveData.FillNewCosmeticInfo(loadedCosmetic);
		}
	}

	private static void ScanForCosmetics()
	{
		string cosmeticFolderPath = CosmeticUtilities.GetCosmeticFolderPath();
		Directory.CreateDirectory(cosmeticFolderPath);
		Directory.CreateDirectory(Path.Combine(cosmeticFolderPath, "Hands"));
		Debug.Log("Scanning For Hand Cosmetics: " + ScanSubfoldersForJson(Path.Combine(cosmeticFolderPath, "Hands"), CreateHandCosmetics, "cosmetic-handitem-settings.json"));
		Debug.Log("Scanning For Voice Cosmetics: " + ScanSubfoldersForJson(Path.Combine(cosmeticFolderPath, "Voices"), CreateVoiceCosmetics, "cosmetic-voice-settings.json"));
	}

	private static void CreateVoiceCosmetics(string subdir, List<string> jsonList)
	{
		if (jsonList == null || jsonList.Count == 0)
		{
			Debug.Log("No cosmetics found in " + subdir + ". Aborting.");
		}
		foreach (string json in jsonList)
		{
			Cosmetic_Voice cosmetic_Voice = Cosmetic_Voice.BuildVoiceCosmetic(subdir, json);
			cosmeticVoiceDict.Add(cosmetic_Voice.cosmeticData.id, cosmetic_Voice);
			cosmeticVoices.Add(cosmetic_Voice);
			Debug.Log("Loading Voice From Disk: " + cosmetic_Voice.name);
		}
	}

	private static void CreateHandCosmetics(string subdir, List<string> jsonList)
	{
		if (jsonList == null || jsonList.Count == 0)
		{
			Debug.Log("No cosmetics found in " + subdir + ". Aborting.");
		}
		foreach (string json2 in jsonList)
		{
			string json = File.ReadAllText(json2);
			Cosmetic_HandItem cosmetic_HandItem = new Cosmetic_HandItem();
			Cosmetic_HandItem.Cosmetic_HandItem_Data cosmetic_HandItem_Data = JsonUtility.FromJson<Cosmetic_HandItem.Cosmetic_HandItem_Data>(json);
			cosmetic_HandItem.cosmeticInfo = new Cosmetic_Info
			{
				id = cosmetic_HandItem_Data.id,
				cosmeticName = cosmetic_HandItem_Data.cosmeticName,
				tag = "hand",
				author = cosmetic_HandItem_Data.author,
				description = cosmetic_HandItem_Data.description,
				unlock = cosmetic_HandItem_Data.unlock,
				flags = cosmetic_HandItem_Data.flags
			};
			Debug.Log("IMPORTING FLAG: " + cosmetic_HandItem_Data.flags);
			bool flag = false;
			if (cosmeticHandDict.ContainsKey(cosmetic_HandItem_Data.id))
			{
				flag = true;
				cosmetic_HandItem = cosmeticHandDict[cosmetic_HandItem_Data.id];
			}
			cosmetic_HandItem.cosmeticData = cosmetic_HandItem_Data;
			cosmetic_HandItem.cosmeticData.globalMaterialSwap = null;
			cosmetic_HandItem.cosmeticInfo.cardBackground = RuntimeSpriteImporter.LoadSpriteFromFile(Path.Combine(subdir, "card-background.png"), 100f, FilterMode.Bilinear, mipmap: true);
			cosmetic_HandItem.cosmeticInfo.cardForeground = RuntimeSpriteImporter.LoadSpriteFromFile(Path.Combine(subdir, "card-foreground.png"), 100f, FilterMode.Bilinear, mipmap: true);
			cosmetic_HandItem.Initialize();
			(List<Sprite>, Dictionary<string, Sprite>) tuple = RuntimeSpriteImporter.LoadSpritesFromFolder(Path.Combine(subdir, "Palettes"), pathIsRelativeToPersistentData: true, 100f, FilterMode.Point, loadLinear: false, recursive: false, toLower: true);
			List<Sprite> item = tuple.Item1;
			bool loadLinear = (cosmetic_HandItem.cosmeticData.palettes != null && cosmetic_HandItem.cosmeticData.palettes.Count > 0) || (item != null && item.Count > 0);
			Dictionary<string, Sprite> item2 = RuntimeSpriteImporter.LoadSpritesFromFolder(Path.Combine(subdir, "Sprites"), pathIsRelativeToPersistentData: true, 100f, FilterMode.Point, loadLinear).spriteDict;
			foreach (Cosmetic_HandItem.Cosmetic_HandItem_Data.ColorPalette palette in cosmetic_HandItem.cosmeticData.palettes)
			{
				palette.id = palette.id.ToLower();
				if (tuple.Item2.ContainsKey(palette.id))
				{
					palette.texture = tuple.Item2[palette.id].texture;
					item.Remove(tuple.Item2[palette.id]);
				}
			}
			if (item != null && item.Count > 0)
			{
				foreach (Sprite item3 in item)
				{
					cosmetic_HandItem.AddPalette(item3.name, item3.texture);
				}
			}
			foreach (Cosmetic_HandItem.SwapSprite swapSprite in cosmetic_HandItem.cosmeticData.swapSprites)
			{
				swapSprite.replacementSprites = new List<Sprite>();
				swapSprite.material = null;
				foreach (string replacementSpriteName in swapSprite.replacementSpriteNames)
				{
					if (item2.ContainsKey(replacementSpriteName))
					{
						swapSprite.replacementSprites.Add(item2[replacementSpriteName]);
					}
				}
				foreach (Cosmetic_HandItem.SwapSprite.SecondaryTextures secondaryTexture in swapSprite.secondaryTextures)
				{
					foreach (string secondaryTextureName in secondaryTexture.secondaryTextureNames)
					{
						if (item2.ContainsKey(secondaryTextureName))
						{
							secondaryTexture.secondaryTextureSprites.Add(item2[secondaryTextureName]);
						}
					}
				}
			}
			foreach (Cosmetic_HandItem.SwapSprite.SecondaryTextures item4 in cosmetic_HandItem.cosmeticData.globalSecondary)
			{
				foreach (string secondaryTextureName2 in item4.secondaryTextureNames)
				{
					if (item2.ContainsKey(secondaryTextureName2))
					{
						item4.secondaryTextureSprites.Add(item2[secondaryTextureName2]);
					}
				}
			}
			Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();
			dictionary = RuntimeSpriteImporter.LoadSpritesFromFolder(Path.Combine(subdir, "Interacts")).spriteDict;
			foreach (Cosmetic_HandItem.InteractSwap interactSwap in cosmetic_HandItem.cosmeticData.interactSwaps)
			{
				interactSwap.replacementSprite = null;
				if (dictionary.ContainsKey(interactSwap.replacementSpriteName))
				{
					interactSwap.replacementSprite = dictionary[interactSwap.replacementSpriteName];
				}
			}
			if (!flag)
			{
				cosmeticHands.Add(cosmetic_HandItem);
				cosmeticHandDict.Add(cosmetic_HandItem.cosmeticData.id, cosmetic_HandItem);
			}
		}
	}

	public static List<string> ScanSubfoldersForJson(string rootFolderPath, Action<string, List<string>> onValidFolder, string targetJson = "settings.json")
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(rootFolderPath))
		{
			Debug.LogError("[FolderJsonScanner] rootFolderPath is null or empty.");
			return list;
		}
		if (!Directory.Exists(rootFolderPath))
		{
			Debug.LogWarning("[FolderJsonScanner] Directory does not exist: " + rootFolderPath);
			return list;
		}
		string[] directories = Directory.GetDirectories(rootFolderPath);
		foreach (string text in directories)
		{
			try
			{
				string[] files = Directory.GetFiles(text, targetJson, SearchOption.TopDirectoryOnly);
				if (files != null && files.Length != 0)
				{
					List<string> arg = new List<string>(files);
					list.Add(text);
					onValidFolder?.Invoke(text, arg);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("[FolderJsonScanner] Error scanning subDir: " + text + "\n" + ex);
			}
		}
		return list;
	}

	internal static void LoadHandCosmetic(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.LogError("You must provide a cosmetic ID.");
			return;
		}
		if (!cosmeticHandDict.ContainsKey(args[0]))
		{
			CommandConsole.LogError("No Cosmetic Found.");
			return;
		}
		bool flag = true;
		bool flag2 = true;
		if (args.Length > 1)
		{
			if (args[1] == "left")
			{
				flag2 = false;
			}
			else if (args[1] == "right")
			{
				flag = false;
			}
			else
			{
				if (!(args[1] == "both"))
				{
					CommandConsole.LogError("Options: left, right, or both.");
					return;
				}
				flag = true;
			}
		}
		if (flag)
		{
			if (ENT_Player.GetPlayer().hands[0].currentCosmetics == null)
			{
				ENT_Player.GetPlayer().hands[0].currentCosmetics = new List<Cosmetic_HandItem>();
			}
			ENT_Player.GetPlayer().hands[0].currentCosmetics.Add(cosmeticHandDict[args[0]]);
		}
		if (flag2)
		{
			if (ENT_Player.GetPlayer().hands[1].currentCosmetics == null)
			{
				ENT_Player.GetPlayer().hands[1].currentCosmetics = new List<Cosmetic_HandItem>();
			}
			ENT_Player.GetPlayer().hands[1].currentCosmetics.Add(cosmeticHandDict[args[0]]);
		}
		CommandConsole.Log("Loaded Cosmetic: " + args[0]);
	}

	internal static void ListHandCosmetics(string[] obj)
	{
		foreach (Cosmetic_HandItem cosmeticHand in cosmeticHands)
		{
			CommandConsole.Log("Hand Cosmetic: " + cosmeticHand.cosmeticData.id + " :: " + cosmeticHand.cosmeticInfo.cosmeticName);
		}
	}

	internal static void RefreshCosmetics(string[] obj)
	{
		ScanForCosmetics();
		CommandConsole.Log("Cosmetics Refreshed");
	}

	public static List<Cosmetic_Base> GetAllLoadedCosmetics()
	{
		Initialize();
		return loadedCosmetics;
	}

	public static Cosmetic_HandItem GetCosmeticInHand(int i)
	{
		Cosmetic_HandItem result = null;
		if (i == 0)
		{
			if (SettingsManager.settings.cosmeticSaveData.leftHandCosmetic != null && cosmeticHandDict.ContainsKey(SettingsManager.settings.cosmeticSaveData.leftHandCosmetic.id))
			{
				result = cosmeticHandDict[SettingsManager.settings.cosmeticSaveData.leftHandCosmetic.id];
			}
		}
		else if (SettingsManager.settings.cosmeticSaveData.rightHandCosmetic != null && cosmeticHandDict.ContainsKey(SettingsManager.settings.cosmeticSaveData.rightHandCosmetic.id))
		{
			result = cosmeticHandDict[SettingsManager.settings.cosmeticSaveData.rightHandCosmetic.id];
		}
		return result;
	}

	public static Cosmetic_Item GetActiveItemCosmetic(string itemid)
	{
		foreach (Cosmetic_Item cosmeticItem in cosmeticItems)
		{
			if (cosmeticItem.cosmeticData.itemName == itemid && SettingsManager.settings.cosmeticSaveData.CosmeticIsActive(cosmeticItem.cosmeticInfo.id))
			{
				return cosmeticItem;
			}
		}
		return null;
	}

	public static List<Cosmetic_Voice> GetActiveVoiceCosmetics()
	{
		List<Cosmetic_Voice> list = new List<Cosmetic_Voice>();
		foreach (Cosmetic_Voice cosmeticVoice in cosmeticVoices)
		{
			if (SettingsManager.settings.cosmeticSaveData.CosmeticIsActive(cosmeticVoice.cosmeticInfo.id))
			{
				list.Add(cosmeticVoice);
			}
		}
		return list;
	}
}
