using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction : DzzQrjVWSCjbqegfjedxfSiuYAafA, BMeYXymsuXMDMyjfaaClzmryYLZG
	{
		private const string keyCategory = "action";

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputActionType _type;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveDescriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeDescriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _behaviorId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _userAssignable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		[NonSerialized]
		private LYVDNDgmaixUBrFsNSKwAeHneVgTA rSTSmPyOAFWChYWrNpRBYICxcilU;

		[NonSerialized]
		private int cfeLcDildXdizDmRtBPaafZHqCixb;

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = num;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = text;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.WFhSGNWPafnDBVFrKcYWKWWaVrjl();
				}
			}
		}

		public InputActionType type
		{
			get
			{
				return _type;
			}
			internal set
			{
				_type = inputActionType;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.DAOKSnnHuTDqugiPODKjezPOSdlnA = GmqZWvsXsIGcBmSAIgreWSTZePmO(_type);
				}
			}
		}

		public string descriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || rSTSmPyOAFWChYWrNpRBYICxcilU == null)
				{
					return _descriptiveName;
				}
				return rSTSmPyOAFWChYWrNpRBYICxcilU.aWxJJrCnpmeqmclTDPTQjepbcypsA;
			}
			internal set
			{
				nonLocalizedDescriptiveName = text;
			}
		}

		public string positiveDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || rSTSmPyOAFWChYWrNpRBYICxcilU == null)
				{
					return _positiveDescriptiveName;
				}
				return rSTSmPyOAFWChYWrNpRBYICxcilU.EEuoRgtKImedZPiNQVMolgeLffPDA;
			}
			internal set
			{
				nonLocalizedPositiveDescriptiveName = text;
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || rSTSmPyOAFWChYWrNpRBYICxcilU == null)
				{
					return _negativeDescriptiveName;
				}
				return rSTSmPyOAFWChYWrNpRBYICxcilU.kxSnSpIstDFbCpDAiIvuXMlhjOQS;
			}
			internal set
			{
				nonLocalizedNegativeDescriptiveName = text;
			}
		}

		public int behaviorId
		{
			get
			{
				return _behaviorId;
			}
			internal set
			{
				_behaviorId = num;
			}
		}

		public int categoryId
		{
			get
			{
				return _categoryId;
			}
			internal set
			{
				_categoryId = num;
			}
		}

		public bool userAssignable
		{
			get
			{
				return _userAssignable;
			}
			internal set
			{
				_userAssignable = flag;
			}
		}

		[CustomObfuscation(rename = false)]
		internal string key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.HeIcdCCpZhLydGytFlnbSIDefvCBb();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				_positiveKey = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.XQQXTKewrylkfnALfeMsHElkpKpWA();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				_negativeKey = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.yaGWtHgcwfzrtJlzGaPfiBrLJojEA();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			set
			{
				_descriptiveName = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.cwUahnpqwmWpOYgoibmoVeKGCqrw();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveDescriptiveName;
			}
			set
			{
				_positiveDescriptiveName = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.RudRXeYiHFFjXzgHKxPoIxXTmRYr();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeDescriptiveName;
			}
			set
			{
				_negativeDescriptiveName = value;
				if (ReInput.isReady && rSTSmPyOAFWChYWrNpRBYICxcilU != null)
				{
					rSTSmPyOAFWChYWrNpRBYICxcilU.excdINExMQaKmgmHUZjbMKMBvKbkA();
				}
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.keyCategory => "action";

		string BMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName => _name;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			set
			{
				_descriptiveName = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveDescriptiveName;
			}
			set
			{
				_positiveDescriptiveName = value;
			}
		}

		string DzzQrjVWSCjbqegfjedxfSiuYAafA.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeDescriptiveName;
			}
			set
			{
				_negativeDescriptiveName = value;
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
				return cfeLcDildXdizDmRtBPaafZHqCixb;
			}
			set
			{
				cfeLcDildXdizDmRtBPaafZHqCixb = value;
			}
		}

		public InputAction()
		{
		}

		public InputAction(InputAction P_0)
		{
			_id = P_0._id;
			_name = P_0._name;
			_type = P_0._type;
			_descriptiveName = P_0._descriptiveName;
			_positiveDescriptiveName = P_0._positiveDescriptiveName;
			_negativeDescriptiveName = P_0._negativeDescriptiveName;
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_behaviorId = P_0._behaviorId;
			_userAssignable = P_0._userAssignable;
			_categoryId = P_0.categoryId;
			cfeLcDildXdizDmRtBPaafZHqCixb = P_0.cfeLcDildXdizDmRtBPaafZHqCixb;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return axisRange switch
			{
				AxisRange.Full => descriptiveName, 
				AxisRange.Positive => positiveDescriptiveName, 
				AxisRange.Negative => negativeDescriptiveName, 
				_ => throw new NotImplementedException(), 
			};
		}

		internal void gfqCcGFaAfhdLvBVmDOatxfcZLpN()
		{
			if (rSTSmPyOAFWChYWrNpRBYICxcilU == null)
			{
				rSTSmPyOAFWChYWrNpRBYICxcilU = LYVDNDgmaixUBrFsNSKwAeHneVgTA.lqgDkgkyrPvRRdtfajTjJkDCgnNl(this, GmqZWvsXsIGcBmSAIgreWSTZePmO(_type), rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None);
			}
		}

		internal void BUYsjprDzPbdOufUlKOYpCwprWoC()
		{
			if (rSTSmPyOAFWChYWrNpRBYICxcilU != null)
			{
				rSTSmPyOAFWChYWrNpRBYICxcilU = null;
			}
		}

		private static rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh GmqZWvsXsIGcBmSAIgreWSTZePmO(InputActionType P_0)
		{
			return P_0 switch
			{
				InputActionType.Axis => rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Axis, 
				InputActionType.Button => rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Button, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
