using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int GaggysRRbiJMmeOjngXoScKfQIJo;

		private ControllerType HlUAgyJbUlabnWGDMeSNJfKWBRqOA;

		private Guid nDtUheTDVvYyJWIKFnkSOjZvFknk;

		private string iXUOsDlpyDebgKWeNWReUZFNBqoiA;

		private Guid kOgepxSdOnrWXpAQrviEAVRJAYzd;

		public int controllerId
		{
			get
			{
				return GaggysRRbiJMmeOjngXoScKfQIJo;
			}
			set
			{
				GaggysRRbiJMmeOjngXoScKfQIJo = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return HlUAgyJbUlabnWGDMeSNJfKWBRqOA;
			}
			set
			{
				HlUAgyJbUlabnWGDMeSNJfKWBRqOA = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return nDtUheTDVvYyJWIKFnkSOjZvFknk;
			}
			set
			{
				nDtUheTDVvYyJWIKFnkSOjZvFknk = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return iXUOsDlpyDebgKWeNWReUZFNBqoiA;
			}
			set
			{
				iXUOsDlpyDebgKWeNWReUZFNBqoiA = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return kOgepxSdOnrWXpAQrviEAVRJAYzd;
			}
			set
			{
				kOgepxSdOnrWXpAQrviEAVRJAYzd = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			GaggysRRbiJMmeOjngXoScKfQIJo = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			GaggysRRbiJMmeOjngXoScKfQIJo = P_0.id;
			HlUAgyJbUlabnWGDMeSNJfKWBRqOA = P_0.type;
			nDtUheTDVvYyJWIKFnkSOjZvFknk = P_0.ZOYuKGMDLcxmBxqUbjaMwovvvKxG;
			iXUOsDlpyDebgKWeNWReUZFNBqoiA = P_0.hardwareIdentifier;
			kOgepxSdOnrWXpAQrviEAVRJAYzd = P_0.deviceInstanceGuid;
		}
	}
}
