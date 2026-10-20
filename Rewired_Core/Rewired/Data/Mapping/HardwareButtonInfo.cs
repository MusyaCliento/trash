using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HardwareButtonInfo : IDeepCloneable
	{
		[SerializeField]
		internal bool _excludeFromPolling;

		[SerializeField]
		internal bool _isPressureSensitive;

		public bool excludeFromPolling
		{
			get
			{
				return _excludeFromPolling;
			}
			internal set
			{
				_excludeFromPolling = value;
			}
		}

		public bool isPressureSensitive
		{
			get
			{
				return _isPressureSensitive;
			}
			internal set
			{
				_isPressureSensitive = value;
			}
		}

		public HardwareButtonInfo()
		{
			_excludeFromPolling = false;
			_isPressureSensitive = false;
		}

		[CustomObfuscation(rename = false)]
		internal HardwareButtonInfo(bool P_0, bool P_1)
		{
			_excludeFromPolling = P_0;
			_isPressureSensitive = P_1;
		}

		public object DeepClone()
		{
			return new HardwareButtonInfo(_excludeFromPolling, _isPressureSensitive);
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DeepClone
			return this.DeepClone();
		}
	}
}
