using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk_New", menuName = "White Knuckle/Perk")]
public class Perk : ScriptableObject
{
	[Serializable]
	public class PerkSaveData
	{
		public string id;

		public int stackAmount;

		public string guid;

		public List<PerkModule.PerkModuleSaveInfo> modules;

		public static PerkSaveData GetPerkSaveData(Perk p)
		{
			return new PerkSaveData
			{
				id = p.id,
				guid = p.guid.ToString(),
				stackAmount = p.GetStackAmount(),
				modules = p.GetPerkModuleSaveInfos()
			};
		}

		public static void SetPerkSaveData(Perk p, PerkSaveData data)
		{
			Debug.Log("Setting Perk Save Data: " + p.name);
			p.stackAmount = data.stackAmount;
			if (Guid.TryParse(data.guid, out var result))
			{
				p.guid = result;
			}
			if (p.modules == null || p.modules.Count <= 0 || data.modules == null || data.modules.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < Mathf.Min(p.modules.Count, data.modules.Count); i++)
			{
				if (p.modules[i] != null && data.modules[i] != null)
				{
					p.modules[i].LoadSaveData(data.modules[i]);
				}
			}
		}
	}

	public enum PerkPool
	{
		standard = 0,
		unstable = 1,
		never = 2
	}

	public enum PerkType
	{
		standard = 0,
		orange = 1,
		red = 2,
		unstable = 3,
		peripheral = 4,
		delta = 5,
		rho = 6,
		kappa = 7,
		trinket = 8,
		binding = 9
	}

	public List<string> tags = new List<string> { "basic" };

	public string title;

	public string id;

	public string description;

	public string flavorText;

	public PerkType perkType;

	public int sortingCategory = 1;

	public bool competitive = true;

	[Tooltip("Should this perk be removed in some circumstances (Rho Chambers, etc)")]
	public bool removeOnCleanse = true;

	[Space]
	public int cost;

	[Space]
	public PerkPool spawnPool;

	public bool spawnInEndless = true;

	public bool canStack = true;

	[Space]
	public int stackMax;

	public AnimationCurve multiplierCurve;

	[Space]
	public bool useBuff = true;

	public BuffContainer buff;

	public bool useBaseBuff;

	public BuffContainer baseBuff;

	public float buffMultiplier = 1f;

	public List<string> flags;

	public List<string> playerTag;

	[SerializeReference]
	public List<PerkModule> modules;

	public Sprite icon;

	public Material iconMat;

	public Sprite perkCard;

	public Sprite perkFrame;

	public SpawnTable.SpawnSettings spawnSettings;

	public int stackAmount;

	private BuffContainer currentBuff;

	private BuffContainer currentBaseBuff;

	internal ENT_Player player;

	public string unlockProgressionID;

	public int unlockXP;

	private float barValue = 1f;

	public Action<Perk> _OnPerkDestroy;

	private bool isActive = true;

	internal Guid guid;

	public void Initialize(ENT_Player p, bool firstTime = true)
	{
		player = p;
		if (useBuff)
		{
			if (buff.id != "")
			{
				currentBuff = player.curBuffs.GetBuffContainer(buff.id);
				if (useBaseBuff)
				{
					currentBaseBuff = player.curBuffs.GetBuffContainer(baseBuff.id);
				}
			}
			if (currentBuff == null)
			{
				player.curBuffs.AddBuff(buff);
				if (useBaseBuff)
				{
					player.curBuffs.AddBuff(baseBuff);
				}
				currentBuff = player.curBuffs.GetBuffContainer(buff.id);
				if (useBaseBuff)
				{
					currentBaseBuff = player.curBuffs.GetBuffContainer(baseBuff.id);
				}
			}
			currentBuff.SetMultiplier(1f * buffMultiplier);
		}
		if (stackAmount <= 0)
		{
			stackAmount = 1;
		}
		if (flags != null)
		{
			foreach (string flag in flags)
			{
				CL_GameManager.SetGameFlag(flag, state: true);
			}
		}
		foreach (string item in playerTag)
		{
			player.GetTagger().AddTag(item);
		}
		if (modules != null && modules.Count > 0)
		{
			for (int num = modules.Count - 1; num >= 0; num--)
			{
				modules[num].Initialize(this, firstTime);
				modules[num].AddModule(stackAmount, firstTime);
			}
		}
		if (guid == Guid.Empty)
		{
			guid = Guid.NewGuid();
		}
	}

	public void Update()
	{
		float stackEvaluationMultiplier = GetStackEvaluationMultiplier();
		if (useBuff)
		{
			currentBuff.SetMultiplier(stackEvaluationMultiplier);
		}
		if (!CL_GameManager.gMan.isPaused)
		{
			for (int num = modules.Count - 1; num >= 0; num--)
			{
				modules[num].Update();
			}
		}
	}

	public void AddStack(int amount = 1, bool firstTime = true)
	{
		stackAmount += amount;
		foreach (PerkModule module in modules)
		{
			module.AddModule(amount, firstTime);
		}
	}

	internal void RemoveStack(int amount = 1)
	{
		stackAmount -= amount;
	}

	public void SetStackAmount(int amount)
	{
		stackAmount = amount;
		if (stackAmount <= 0)
		{
			RemoveFromPlayer();
		}
	}

	public int GetStackAmount()
	{
		return stackAmount;
	}

	public float GetStackEvaluationMultiplier()
	{
		float num = 1f;
		if (stackAmount > 1)
		{
			for (int i = 1; i < Mathf.Min(stackAmount, stackMax); i++)
			{
				num += multiplierCurve.Evaluate((float)i / (float)stackMax);
			}
		}
		return num;
	}

	public bool CanSpawn()
	{
		Debug.Log("Checking Perk: " + base.name + " - " + unlockProgressionID);
		if (!spawnInEndless && CL_GameManager.gamemode.isEndless)
		{
			return false;
		}
		if (CL_GameManager.GetCurrentGamemode().IsCompetitive() && !competitive)
		{
			return false;
		}
		if (ENT_Player.GetPlayer().HasPerk(id))
		{
			if (!canStack)
			{
				Debug.Log("Blocking stack: Already has " + id);
				return false;
			}
			Perk perk = ENT_Player.GetPlayer().GetPerk(id);
			if (perk.stackMax <= perk.stackAmount)
			{
				Debug.Log("Blocking stack: Has enough " + id);
				return false;
			}
		}
		if (!canStack && ENT_Player.GetPlayer().HasPerk(id))
		{
			return false;
		}
		if (unlockProgressionID != "" && !CL_ProgressionManager.HasProgressionUnlock(unlockProgressionID))
		{
			return false;
		}
		if (CL_ProgressionManager.playerExperience < unlockXP)
		{
			return false;
		}
		return true;
	}

	public void RemoveFromPlayer()
	{
		Debug.Log("Removing Perk: " + id);
		OnDestroy();
		player.RemovePerk(this);
		isActive = false;
	}

	public void OnDestroy()
	{
		foreach (PerkModule module in modules)
		{
			module.OnDestroy(this);
		}
		_OnPerkDestroy?.Invoke(this);
	}

	public void ClearPerkEffects()
	{
		if (useBuff)
		{
			player.curBuffs.RemoveBuffContainer(currentBuff.id);
		}
		if (useBaseBuff)
		{
			player.curBuffs.RemoveBuffContainer(currentBaseBuff.id);
		}
		OnDestroy();
		if (flags != null)
		{
			foreach (string flag in flags)
			{
				CL_GameManager.SetGameFlag(flag, state: false);
			}
		}
		foreach (string item in playerTag)
		{
			player.GetTagger().RemoveTag(item);
		}
	}

	public float GetBarValue()
	{
		return barValue;
	}

	public void SetBarValue(float f)
	{
		barValue = f;
	}

	public bool IsActive()
	{
		return isActive;
	}

	internal void RemoveModule(PerkModule module)
	{
		modules.Remove(module);
	}

	public List<PerkModule.PerkModuleSaveInfo> GetPerkModuleSaveInfos()
	{
		List<PerkModule.PerkModuleSaveInfo> list = new List<PerkModule.PerkModuleSaveInfo>();
		foreach (PerkModule module in modules)
		{
			PerkModule.PerkModuleSaveInfo perkModuleSaveInfo = new PerkModule.PerkModuleSaveInfo();
			perkModuleSaveInfo.perkModuleType = module.GetType().ToString();
			perkModuleSaveInfo.data = module.GetSaveData();
			Debug.Log("PM Type: " + perkModuleSaveInfo.perkModuleType);
			list.Add(perkModuleSaveInfo);
		}
		return list;
	}

	public string GetTitle(bool includeColor = false)
	{
		if (includeColor)
		{
			if (perkType == PerkType.orange)
			{
				return "<color=#FFD454><shimmer s=0.1>" + title + "</shimmer></color>";
			}
			if (perkType == PerkType.red)
			{
				return "<color=#ED4040>" + title + "</color>";
			}
			if (perkType == PerkType.rho)
			{
				return "<color=#ED4040><shimmer s=0.1><shake a=0.02>" + title + "</shake></shimmer></color>";
			}
			if (perkType == PerkType.unstable)
			{
				return "<color=#ff61a3><shake a=0.003>" + title + "</shake></color>";
			}
			if (perkType == PerkType.delta)
			{
				return "<color=#54FFBD><shimmer s=0.1>" + title + "</shimmer></color>";
			}
			if (perkType == PerkType.kappa)
			{
				return "<color=#c2edff><shimmer s=0.1><shake a=0.005>" + title + "</shake></shimmer></color>";
			}
			if (perkType == PerkType.trinket)
			{
				return "<color=#FF8AFF>Trinket\n<shimmer s=0.1>" + title + "</shimmer></color>";
			}
			if (perkType == PerkType.binding)
			{
				return "<color=#808080>Binding\n<shimmer s=0.1><shake a=0.01>" + title + "</shake></shimmer></color>";
			}
			return "<color=\"white\">" + title + "</color>";
		}
		return title;
	}

	public string GetDescription(bool adjusted = false, bool total = false, bool includeFlavor = true, bool includeColorTags = true)
	{
		if (ENT_Player.GetPlayer() != null)
		{
			this = ENT_Player.GetPlayer().GetPerk(id);
		}
		if (this == null)
		{
			stackAmount = 0;
			this = this;
		}
		string text = description;
		if (includeColorTags)
		{
			text = text.Replace("(+)", "<color=\"grey\">+ </color>");
			text = text.Replace("(-)", "<color=#915757>- </color>");
		}
		string input = FillData(text, "\\[(.*?)\\]", (string content) => content.Contains("$") ? ((player == null) ? "" : content.Replace("$", "")) : content);
		input = FillData(input, "\\{(.*?)\\}", delegate(string content)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (content.Contains("/%"))
			{
				flag2 = true;
				content = content.Replace("/%", "");
			}
			else if (content.Contains("%"))
			{
				flag = true;
				content = content.Replace("%", "");
			}
			else if (content.Contains("^s"))
			{
				flag3 = true;
				content = content.Replace("^s", "");
			}
			else if (content.Contains("@"))
			{
				flag = true;
				content = content.Replace("@", "");
				foreach (PerkModule module in modules)
				{
					string descriptionFromKey = module.GetDescriptionFromKey(content);
					if (descriptionFromKey != "")
					{
						return descriptionFromKey;
					}
				}
			}
			int num = Mathf.Clamp(stackAmount, 0, stackMax);
			if (this == null)
			{
				foreach (BuffContainer.Buff buff in buff.buffs)
				{
					if (content == buff.id)
					{
						Debug.Log(buff.id + " " + buff.maxAmount);
						if (flag)
						{
							return Mathf.Round(buff.maxAmount * 100f).ToString();
						}
						if (flag2)
						{
							return (100f - Mathf.Round(1f / (buff.maxAmount + 1f) * 100f)).ToString();
						}
						if (flag3)
						{
							return (buff.maxAmount == 1f) ? (Math.Round(buff.maxAmount, 2) + " Second") : (Mathf.Round(buff.maxAmount) + " Seconds");
						}
						return Math.Round(buff.maxAmount, 2).ToString();
					}
				}
				foreach (BuffContainer.Buff buff2 in this.buff.buffs)
				{
					if (content == buff2.id)
					{
						if (flag)
						{
							return Mathf.Round(buff2.maxAmount * 100f).ToString();
						}
						if (flag2)
						{
							return (100f - Mathf.Round(1f / (1f - (buff2.maxAmount + 1f)) * 100f)).ToString();
						}
						if (flag3)
						{
							return (buff2.maxAmount == 1f) ? (Math.Round(buff2.maxAmount, 2) + " Second") : (Mathf.Round(buff2.maxAmount) + " Seconds");
						}
						return Math.Round(buff2.maxAmount, 2).ToString();
					}
				}
				return "?";
			}
			foreach (BuffContainer.Buff buff3 in this.buff.buffs)
			{
				int num2 = Mathf.Clamp(stackAmount, 0, stackMax);
				if (content == buff3.id)
				{
					if (adjusted)
					{
						if (total)
						{
							float num3 = 0f;
							for (int i = 0; i < num2; i++)
							{
								num3 += multiplierCurve.Evaluate((float)i / (float)stackMax);
							}
							if (flag)
							{
								return Mathf.Round(buff3.maxAmount * 100f * num3).ToString();
							}
							if (flag2)
							{
								return (100f - Mathf.Round(1f / (buff3.maxAmount * num3 + 1f) * 100f)).ToString();
							}
							if (flag3)
							{
								return (buff3.maxAmount == 1f) ? (Math.Round(buff3.maxAmount * num3, 2) + " Second") : (Math.Round(buff3.maxAmount * num3, 2) + " Seconds");
							}
							return Math.Round(buff3.maxAmount * num3, 2).ToString();
						}
						float num4 = multiplierCurve.Evaluate((float)num2 / (float)stackMax);
						if (flag)
						{
							return Mathf.Round(buff3.maxAmount * 100f * num4).ToString();
						}
						if (flag2)
						{
							return (100f - Mathf.Round(1f / (buff3.maxAmount * num4 + 1f) * 100f)).ToString();
						}
						if (flag3)
						{
							return (buff3.maxAmount == 1f) ? (Math.Round(buff3.maxAmount * num4, 2) + " Second") : (Math.Round(buff3.maxAmount * num4, 2) + " Seconds");
						}
						return Math.Round(buff3.maxAmount * num4, 2).ToString();
					}
					return Mathf.Round(buff3.maxAmount * 100f).ToString();
				}
			}
			bool flag4 = false;
			float num5 = 0f;
			foreach (PerkModule module2 in modules)
			{
				float statBuff = module2.GetStatBuff(content, total);
				if (!float.IsNaN(statBuff))
				{
					num5 += statBuff;
					flag4 = true;
				}
			}
			if (flag4)
			{
				if (total)
				{
					if (flag)
					{
						return Math.Round(num5 * 100f, 2).ToString();
					}
					if (flag2)
					{
						return (100.0 - Math.Round(1f / (num5 + 1f) * 100f, 2)).ToString();
					}
					return Math.Round(num5, 2).ToString();
				}
				multiplierCurve.Evaluate((float)num / (float)stackMax);
				if (flag)
				{
					return Math.Round(num5 * 100f, 2).ToString();
				}
				if (flag2)
				{
					return (100.0 - Math.Round(0.1f / (num5 + 1f) * 100f, 2)).ToString();
				}
				return Math.Round(num5, 2).ToString();
			}
			return "?";
		});
		if (includeFlavor && !string.IsNullOrEmpty(flavorText) && includeColorTags)
		{
			input += "<color=\"grey\"><size=12><i>\n<i>";
		}
		if (includeFlavor && !string.IsNullOrEmpty(flavorText))
		{
			input += flavorText;
		}
		return input;
		static string FillData(string input2, string regex, Func<string, string> replacer)
		{
			return Regex.Replace(input2, regex, delegate(Match match)
			{
				string value = match.Groups[1].Value;
				return replacer(value);
			});
		}
	}

	public string GetPerkModuleCounterText()
	{
		string text = "";
		foreach (PerkModule module in modules)
		{
			text += module.GetCounterString();
		}
		return text;
	}
}
