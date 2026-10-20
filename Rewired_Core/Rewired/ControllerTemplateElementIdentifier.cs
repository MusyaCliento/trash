using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, DzzQrjVWSCjbqegfjedxfSiuYAafA, BMeYXymsuXMDMyjfaaClzmryYLZG, JuFkXsalDOaAKOpTxQgcsoqPQLtO, hxyHkVRkANnbOzerwOAYbNkvukwJ, DDLiMrEdceQRXQSrNifvymIZIsut, OVWyLszztvvrzKClxAtUJKzpOUTc
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class BibULoAmIOddeIJeHciKEDdvpRhDA
		{
			public int id;

			public string name;

			public string positiveName;

			public string negativeName;

			public string key;

			public string positiveKey;

			public string negativeKey;

			public ControllerTemplateElementType elementType;
		}

		private class qgatCMEjYSYEggQcuJySFFgDlRrt
		{
			[SerializeField]
			private string IGPOymzTpsPsuxEOvvFmzpaZIfHcA;

			[SerializeField]
			private string pGeyblPQBNtwBulNEnfMYNIclQvJ;

			public string CTUIhcYvQQJvlBIzblBVMtmGFPzh
			{
				get
				{
					return IGPOymzTpsPsuxEOvvFmzpaZIfHcA;
				}
				set
				{
					IGPOymzTpsPsuxEOvvFmzpaZIfHcA = iGPOymzTpsPsuxEOvvFmzpaZIfHcA;
				}
			}

			public string pcGHZMBotgtoWmaASwbRatKLqbiYA
			{
				get
				{
					return pGeyblPQBNtwBulNEnfMYNIclQvJ;
				}
				set
				{
					pGeyblPQBNtwBulNEnfMYNIclQvJ = text;
				}
			}

			public qgatCMEjYSYEggQcuJySFFgDlRrt()
			{
			}

			public qgatCMEjYSYEggQcuJySFFgDlRrt(qgatCMEjYSYEggQcuJySFFgDlRrt P_0)
			{
				IGPOymzTpsPsuxEOvvFmzpaZIfHcA = P_0.IGPOymzTpsPsuxEOvvFmzpaZIfHcA;
				pGeyblPQBNtwBulNEnfMYNIclQvJ = P_0.pGeyblPQBNtwBulNEnfMYNIclQvJ;
			}
		}

		private const string EWmaTaPDPYrLswqbLycdPRQZRThA = "controller/template";

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementType _elementType;

		[NonSerialized]
		private HMtLwHHjltZtNIbnthVxPUFsBHUt acePkHkgOQmRMUsdfHgivUyosiUM;

		[NonSerialized]
		private kdCbPgNHzwxhSYFkXdphdJmXawOiA eCaHYjfShETfgSWLjmTgDiybDZIf;

		[NonSerialized]
		private qmMKYKokLjiebkvHxJRGIKsndxpJ uYjrjbOsYSsjCiqmXDwTuxKkDmtb;

		[NonSerialized]
		private ovKidfwQWZSKcpUFWfOyBvtrdXiC VSDtCwNqtpjMhspfWqGlMcIpWFRb;

		[NonSerialized]
		private DeviceLocalizationInfo KlXJCGfMFmQUyutQhRnxHyzDrMuS;

		[NonSerialized]
		private int JInjXLMqxdmkEakUQvbgiNEvHxiG;

		[NonSerialized]
		private List<qgatCMEjYSYEggQcuJySFFgDlRrt> sdDkMBnkYFgSnFjPpCBNKKrTpmGdA;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || acePkHkgOQmRMUsdfHgivUyosiUM == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return acePkHkgOQmRMUsdfHgivUyosiUM.aWxJJrCnpmeqmclTDPTQjepbcypsA;
			}
			internal set
			{
				nonLocalizedName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.positiveName
		{
			get
			{
				if (!ReInput.isReady || acePkHkgOQmRMUsdfHgivUyosiUM == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return acePkHkgOQmRMUsdfHgivUyosiUM.EEuoRgtKImedZPiNQVMolgeLffPDA;
			}
			internal set
			{
				nonLocalizedPositiveName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.negativeName
		{
			get
			{
				if (!ReInput.isReady || acePkHkgOQmRMUsdfHgivUyosiUM == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return acePkHkgOQmRMUsdfHgivUyosiUM.kxSnSpIstDFbCpDAiIvuXMlhjOQS;
			}
			internal set
			{
				nonLocalizedNegativeName = value;
			}
		}

		ControllerTemplateElementType IControllerTemplateElementIdentifier.elementType => _elementType;

		internal virtual bool useEditorElementTypeOverride => false;

		internal virtual ControllerElementType editorElementTypeOverride
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public object glyph
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.bhSBkAGjBkwrSuotBdJqikBDACFz;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.ADoOuWufrjYrDGSlORWdVoeMHdak;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.OTOMVMINJVAJOKlxRDIdsAusLkRf;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.uqOSJTjgWeByxITpQQGTxpnSBQrr;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.gZFChBwzudLPJLdrMbaXcfNOIyLdb;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return uYjrjbOsYSsjCiqmXDwTuxKkDmtb.vfFEAsamvNlmREKhRLVMKqRMWwCGA;
			}
		}

		internal string nonLocalizedName
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				if (ReInput.isReady && acePkHkgOQmRMUsdfHgivUyosiUM != null)
				{
					acePkHkgOQmRMUsdfHgivUyosiUM.cwUahnpqwmWpOYgoibmoVeKGCqrw();
				}
			}
		}

		internal string nonLocalizedPositiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				_positiveName = value;
				if (ReInput.isReady && acePkHkgOQmRMUsdfHgivUyosiUM != null)
				{
					acePkHkgOQmRMUsdfHgivUyosiUM.RudRXeYiHFFjXzgHKxPoIxXTmRYr();
				}
			}
		}

		internal string nonLocalizedNegativeName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				_negativeName = value;
				if (ReInput.isReady && acePkHkgOQmRMUsdfHgivUyosiUM != null)
				{
					acePkHkgOQmRMUsdfHgivUyosiUM.excdINExMQaKmgmHUZjbMKMBvKbkA();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (JInjXLMqxdmkEakUQvbgiNEvHxiG & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (JInjXLMqxdmkEakUQvbgiNEvHxiG & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (JInjXLMqxdmkEakUQvbgiNEvHxiG & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (JInjXLMqxdmkEakUQvbgiNEvHxiG & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => KlXJCGfMFmQUyutQhRnxHyzDrMuS;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.keyCategory => "controller/template";

		string BMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName => _name;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				_positiveName = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				_negativeName = value;
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.key => _key;

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				_positiveKey = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				_negativeKey = value;
			}
		}

		int BMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags
		{
			get
			{
				return JInjXLMqxdmkEakUQvbgiNEvHxiG;
			}
			set
			{
				JInjXLMqxdmkEakUQvbgiNEvHxiG = value;
			}
		}

		string hxyHkVRkANnbOzerwOAYbNkvukwJ.keyCategory => "controller/template";

		string hxyHkVRkANnbOzerwOAYbNkvukwJ.key => _key;

		int hxyHkVRkANnbOzerwOAYbNkvukwJ.autoGeneratedValueFlags
		{
			get
			{
				return JInjXLMqxdmkEakUQvbgiNEvHxiG;
			}
			set
			{
				JInjXLMqxdmkEakUQvbgiNEvHxiG = value;
			}
		}

		string JuFkXsalDOaAKOpTxQgcsoqPQLtO.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				_positiveKey = value;
			}
		}

		string JuFkXsalDOaAKOpTxQgcsoqPQLtO.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || eCaHYjfShETfgSWLjmTgDiybDZIf == null)
			{
				return string.Empty;
			}
			return eCaHYjfShETfgSWLjmTgDiybDZIf.kFzfybRGnaUscpxnrbLobRBoNEQE(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || VSDtCwNqtpjMhspfWqGlMcIpWFRb == null)
			{
				return null;
			}
			return VSDtCwNqtpjMhspfWqGlMcIpWFRb.pHbwkHqjdrxbcNvqfQCHRdZGBIoW(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || (uint)index >= (uint)sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				return null;
			}
			return sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].pcGHZMBotgtoWmaASwbRatKLqbiYA;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || (uint)index >= (uint)sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				return null;
			}
			return sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].CTUIhcYvQQJvlBIzblBVMtmGFPzh;
		}

		public ControllerTemplateElementIdentifier()
		{
		}

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0)
		{
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_elementType = P_0._elementType;
			if (P_0.sdDkMBnkYFgSnFjPpCBNKKrTpmGdA != null)
			{
				int count = P_0.sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count;
				sdDkMBnkYFgSnFjPpCBNKKrTpmGdA = new List<qgatCMEjYSYEggQcuJySFFgDlRrt>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[i] != null)
					{
						sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Add(new qgatCMEjYSYEggQcuJySFFgDlRrt(P_0.sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[i]));
					}
				}
			}
			JInjXLMqxdmkEakUQvbgiNEvHxiG = P_0.JInjXLMqxdmkEakUQvbgiNEvHxiG;
		}

		internal ControllerTemplateElementIdentifier(BibULoAmIOddeIJeHciKEDdvpRhDA P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			_id = P_0.id;
			_name = P_0.name;
			_positiveName = P_0.positiveName;
			_negativeName = P_0.negativeName;
			_key = P_0.key;
			_positiveKey = P_0.positiveKey;
			_negativeKey = P_0.negativeKey;
			_elementType = P_0.elementType;
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementType P_1, bool P_2)
			: this(P_0)
		{
			_elementType = P_1;
		}

		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, 
					AxisRange.Positive => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName, 
					AxisRange.Negative => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, 
			};
		}

		public object GetGlyph(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => glyph, 
					AxisRange.Positive => positiveGlyph, 
					AxisRange.Negative => negativeGlyph, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => glyph, 
			};
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => finalGlyphKey, 
					AxisRange.Positive => finalPositiveGlyphKey, 
					AxisRange.Negative => finalNegativeGlyphKey, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => finalGlyphKey, 
			};
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier(IHardwareControllerMap_Internal hardwareControllerMap)
		{
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.VXmmTGAAzomJKBrXugkdiHgqkBUP
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.XTubskdhyjfpRAcauUNRKbGLSlaR(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && KlXJCGfMFmQUyutQhRnxHyzDrMuS != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			XKLduTBSCJnSXvsxvDBHEPmffddSc(_elementType, out var kMtjipaOdFdYovyjrhBVREbSUYnh, out var jgYXfxdxpkTgDbqAHkfiZaHWlWIS);
			int num = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.pKmJnPnIjYFsvlVnstcPJZTOEgjA(kMtjipaOdFdYovyjrhBVREbSUYnh, jgYXfxdxpkTgDbqAHkfiZaHWlWIS);
			if (num > 0)
			{
				sdDkMBnkYFgSnFjPpCBNKKrTpmGdA = new List<qgatCMEjYSYEggQcuJySFFgDlRrt>(num);
				for (int i = 0; i < num; i++)
				{
					sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Add(new qgatCMEjYSYEggQcuJySFFgDlRrt());
				}
			}
			KlXJCGfMFmQUyutQhRnxHyzDrMuS = deviceLocalizationInfo;
			if (acePkHkgOQmRMUsdfHgivUyosiUM == null)
			{
				acePkHkgOQmRMUsdfHgivUyosiUM = HMtLwHHjltZtNIbnthVxPUFsBHUt.MEBHftAWTUvgXkAIHhPxhIWnVeDh(this, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, kMtjipaOdFdYovyjrhBVREbSUYnh, jgYXfxdxpkTgDbqAHkfiZaHWlWIS, _id, deviceLocalizationInfo);
			}
			if (uYjrjbOsYSsjCiqmXDwTuxKkDmtb == null)
			{
				uYjrjbOsYSsjCiqmXDwTuxKkDmtb = qmMKYKokLjiebkvHxJRGIKsndxpJ.aSGXEgcwBJwTSnAcigXqjNAyzIyF(this, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, kMtjipaOdFdYovyjrhBVREbSUYnh, jgYXfxdxpkTgDbqAHkfiZaHWlWIS, _id, deviceLocalizationInfo);
			}
			if (kMtjipaOdFdYovyjrhBVREbSUYnh == rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement)
			{
				eCaHYjfShETfgSWLjmTgDiybDZIf = kdCbPgNHzwxhSYFkXdphdJmXawOiA.RezTTLveYwLxiDxrlApgcqZRzhfd(this, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, kMtjipaOdFdYovyjrhBVREbSUYnh, jgYXfxdxpkTgDbqAHkfiZaHWlWIS, _id, deviceLocalizationInfo);
				VSDtCwNqtpjMhspfWqGlMcIpWFRb = ovKidfwQWZSKcpUFWfOyBvtrdXiC.ccKrWFeyLoOwNJADBiaRxMsrxFVy(this, QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, kMtjipaOdFdYovyjrhBVREbSUYnh, jgYXfxdxpkTgDbqAHkfiZaHWlWIS, _id, deviceLocalizationInfo);
			}
		}

		string DDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || index >= sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				return null;
			}
			return sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].pcGHZMBotgtoWmaASwbRatKLqbiYA;
		}

		void DDLiMrEdceQRXQSrNifvymIZIsut.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA != null && index < sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].pcGHZMBotgtoWmaASwbRatKLqbiYA = value;
			}
		}

		string DDLiMrEdceQRXQSrNifvymIZIsut.GetSpecialElementKey(int index)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || index >= sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				return null;
			}
			return sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].CTUIhcYvQQJvlBIzblBVMtmGFPzh;
		}

		void DDLiMrEdceQRXQSrNifvymIZIsut.SetSpecialElementKey(int index, string value)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA != null && index < sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].CTUIhcYvQQJvlBIzblBVMtmGFPzh = value;
			}
		}

		string OVWyLszztvvrzKClxAtUJKzpOUTc.GetSpecialElementKey(int index)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA == null || index >= sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				return null;
			}
			return sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].CTUIhcYvQQJvlBIzblBVMtmGFPzh;
		}

		void OVWyLszztvvrzKClxAtUJKzpOUTc.SetSpecialElementKey(int index, string value)
		{
			if (sdDkMBnkYFgSnFjPpCBNKKrTpmGdA != null && index < sdDkMBnkYFgSnFjPpCBNKKrTpmGdA.Count)
			{
				sdDkMBnkYFgSnFjPpCBNKKrTpmGdA[index].CTUIhcYvQQJvlBIzblBVMtmGFPzh = value;
			}
		}

		private static void XKLduTBSCJnSXvsxvDBHEPmffddSc(ControllerTemplateElementType P_0, out rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh P_1, out rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS P_2)
		{
			P_2 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				P_2 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				P_2 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				P_2 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.CompoundElement;
				P_2 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.Stick6D;
				break;
			default:
				P_1 = rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown;
				break;
			}
		}
	}
}
