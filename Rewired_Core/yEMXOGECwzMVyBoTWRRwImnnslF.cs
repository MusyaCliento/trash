using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class yEMXOGECwzMVyBoTWRRwImnnslF : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct tQseYbwDfITaJytTWkFAsBqVLyXd : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal mIyvxpQWCaELTiPgfhJCKKTFroLHA;

		public tQseYbwDfITaJytTWkFAsBqVLyXd(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			mIyvxpQWCaELTiPgfhJCKKTFroLHA = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return mIyvxpQWCaELTiPgfhJCKKTFroLHA.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap OlUhUCDDuaQBOKAZqAKPiKZzdNQTA;

	private string cPwisUvegnUvBoeKvWqwBkiCMqVA;

	private string bTaqSRHUqjKfFAEtyDjSJsWsKkqk;

	private string sWnccaFBMPdvBekHmzYDfbGiKPZRA;

	private readonly Guid KUkQWbcQoQbXfFCMKBuYbIDIIOyUA;

	private readonly List<HardwareJoystickTemplateMap.Entry> UnXunYngRkKsZruRLUpDexfGGvrT;

	private readonly ControllerTemplateElementIdentifier[] nMjVuhsmTgmgzvMlVJxmWbIAaJRL;

	private readonly DeviceLocalizationInfo nXDeNPEPUgeUBfvEKxgPPsZfDkmEb;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> BOZVYesjnnPCyZOafucyeaPdCiEEA;

	public string name => cPwisUvegnUvBoeKvWqwBkiCMqVA;

	public string UGtDpZJobIRXKMYZuTpxgiAqjMTCA => bTaqSRHUqjKfFAEtyDjSJsWsKkqk;

	public string wZdxCYpxCUgZtQhkNsNMYOkuXVrI => sWnccaFBMPdvBekHmzYDfbGiKPZRA;

	public Guid mgsDlvjaDxOYcoSCNaVVGdeUXRfl => KUkQWbcQoQbXfFCMKBuYbIDIIOyUA;

	string IHardwareControllerTemplateMap_Internal.name => cPwisUvegnUvBoeKvWqwBkiCMqVA;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => KUkQWbcQoQbXfFCMKBuYbIDIIOyUA;

	string IHardwareControllerTemplateMap_Internal.typeKey => sWnccaFBMPdvBekHmzYDfbGiKPZRA;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> qvLsKHLUBzNZRNwEMWdtKBMgpbCk => hnaDDYkjEySgGwmsuJYpkLeoWYqe;

	public yEMXOGECwzMVyBoTWRRwImnnslF(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException();
		}
		OlUhUCDDuaQBOKAZqAKPiKZzdNQTA = P_0;
		cPwisUvegnUvBoeKvWqwBkiCMqVA = P_0.name;
		bTaqSRHUqjKfFAEtyDjSJsWsKkqk = P_0.ClassName;
		KUkQWbcQoQbXfFCMKBuYbIDIIOyUA = P_0.Guid;
		sWnccaFBMPdvBekHmzYDfbGiKPZRA = P_0.Key;
		UnXunYngRkKsZruRLUpDexfGGvrT = P_1;
		nMjVuhsmTgmgzvMlVJxmWbIAaJRL = P_2;
		nXDeNPEPUgeUBfvEKxgPPsZfDkmEb = new DeviceLocalizationInfo(ControllerType.Joystick, true, mgsDlvjaDxOYcoSCNaVVGdeUXRfl, new AList<string> { sWnccaFBMPdvBekHmzYDfbGiKPZRA }, null);
		nXDeNPEPUgeUBfvEKxgPPsZfDkmEb.FinishRuntimeSetup();
		for (int i = 0; i < nMjVuhsmTgmgzvMlVJxmWbIAaJRL.Length; i++)
		{
			if (nMjVuhsmTgmgzvMlVJxmWbIAaJRL[i] != null)
			{
				nMjVuhsmTgmgzvMlVJxmWbIAaJRL[i].FinishRuntimeSetup(nXDeNPEPUgeUBfvEKxgPPsZfDkmEb);
			}
		}
	}

	public ControllerTemplateElementIdentifier WtHkdoOkGravxGeYYjdHCJYADMM(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (UnXunYngRkKsZruRLUpDexfGGvrT == null)
		{
			return null;
		}
		int num = -1;
		int count = UnXunYngRkKsZruRLUpDexfGGvrT.Count;
		for (int i = 0; i < count; i++)
		{
			if (UnXunYngRkKsZruRLUpDexfGGvrT[i] != null && UnXunYngRkKsZruRLUpDexfGGvrT[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = UnXunYngRkKsZruRLUpDexfGGvrT[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.AsctJGnbmphNmBFmZSmNpgcKOxynA(nMjVuhsmTgmgzvMlVJxmWbIAaJRL, templateElementId);
	}

	public int qDneOGMacNaIsAIdxMSJeiOEAhAKc(Guid P_0, int P_1, List<HardwareControllerTemplateMap.FDkLHcyMJQXVwOVdNsLdHOXsVLxN> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (UnXunYngRkKsZruRLUpDexfGGvrT == null)
		{
			return 0;
		}
		int num = -1;
		int count = UnXunYngRkKsZruRLUpDexfGGvrT.Count;
		for (int i = 0; i < count; i++)
		{
			if (UnXunYngRkKsZruRLUpDexfGGvrT[i] != null && UnXunYngRkKsZruRLUpDexfGGvrT[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = UnXunYngRkKsZruRLUpDexfGGvrT[num];
		if (entry == null)
		{
			return 0;
		}
		int count2 = P_2.Count;
		int num2 = ((entry.elementIdentifierMappings != null) ? entry.elementIdentifierMappings.Count : 0);
		for (int j = 0; j < num2; j++)
		{
			if (entry.elementIdentifierMappings == null)
			{
				continue;
			}
			HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = entry.elementIdentifierMappings[j];
			if (elementIdentifierMap == null)
			{
				continue;
			}
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = kskkgHhFPSCzRfsSXgXVjRfABqDeb(nMjVuhsmTgmgzvMlVJxmWbIAaJRL, elementIdentifierMap.templateId);
			if (controllerTemplateElementIdentifier == null)
			{
				continue;
			}
			if (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis)
			{
				if (elementIdentifierMap.splitAxis)
				{
					if (elementIdentifierMap.joystickId != P_1 && elementIdentifierMap.joystickId2 != P_1)
					{
						continue;
					}
				}
				else if (elementIdentifierMap.joystickId != P_1)
				{
					continue;
				}
			}
			else if (elementIdentifierMap.joystickId != P_1)
			{
				continue;
			}
			P_2.Add(new HardwareControllerTemplateMap.FDkLHcyMJQXVwOVdNsLdHOXsVLxN
			{
				uYlpHdQqHbhkQzdakIExfyUehggd = elementIdentifierMap.templateId,
				GnKkDAUuiTQYRFVKZCVutduVvUnL = elementIdentifierMap.joystickId,
				JuaGuptHRdxCqxjrYgafDzWZgGoLA = elementIdentifierMap.joystickId2,
				TwwxYuopeGBjPgqbZXffCInWdzlo = (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry hnaDDYkjEySgGwmsuJYpkLeoWYqe(Guid P_0)
	{
		if (UnXunYngRkKsZruRLUpDexfGGvrT == null)
		{
			return null;
		}
		for (int i = 0; i < UnXunYngRkKsZruRLUpDexfGGvrT.Count; i++)
		{
			if (UnXunYngRkKsZruRLUpDexfGGvrT[i].JoystickGuid == P_0)
			{
				return UnXunYngRkKsZruRLUpDexfGGvrT[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier kskkgHhFPSCzRfsSXgXVjRfABqDeb(ControllerTemplateElementIdentifier[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_1)
			{
				return P_0[i];
			}
		}
		return null;
	}

	int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
	{
		if (nMjVuhsmTgmgzvMlVJxmWbIAaJRL == null)
		{
			return 0;
		}
		return nMjVuhsmTgmgzvMlVJxmWbIAaJRL.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (nMjVuhsmTgmgzvMlVJxmWbIAaJRL == null)
		{
			return null;
		}
		return nMjVuhsmTgmgzvMlVJxmWbIAaJRL[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.AsctJGnbmphNmBFmZSmNpgcKOxynA(nMjVuhsmTgmgzvMlVJxmWbIAaJRL, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new tQseYbwDfITaJytTWkFAsBqVLyXd(((IHardwareControllerTemplateMap_Internal)OlUhUCDDuaQBOKAZqAKPiKZzdNQTA).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	ZjsvgUMHkMFRcjnXfMJoZEAVgouqA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.tJSPXTmhAihClMgshUUshlTUfQzN(this, controller, elementIdentifierId, qvLsKHLUBzNZRNwEMWdtKBMgpbCk);
	}

	ZjsvgUMHkMFRcjnXfMJoZEAVgouqA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.AvHVoFrbZscuDKpAdqtiKensLhvr(this, controller, elementIdentifierId, qvLsKHLUBzNZRNwEMWdtKBMgpbCk);
	}
}
