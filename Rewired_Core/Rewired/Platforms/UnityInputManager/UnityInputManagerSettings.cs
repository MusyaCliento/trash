using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Rewired.Utils;

namespace Rewired.Platforms.UnityInputManager
{
	public sealed class UnityInputManagerSettings
	{
		public struct DeviceIdentifier : IEquatable<DeviceIdentifier>
		{
			public string name;

			public bool useRegex;

			public override bool Equals(object obj)
			{
				if (!(obj is DeviceIdentifier deviceIdentifier))
				{
					return false;
				}
				if (string.Equals(deviceIdentifier.name, name, StringComparison.Ordinal))
				{
					return deviceIdentifier.useRegex == useRegex;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (17 * 29 + name.GetHashCode()) * 29 + useRegex.GetHashCode();
			}

			public bool Equals(DeviceIdentifier other)
			{
				if (string.Equals(name, other.name, StringComparison.Ordinal))
				{
					return useRegex == other.useRegex;
				}
				return false;
			}

			bool IEquatable<DeviceIdentifier>.Equals(DeviceIdentifier other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Equals
				return this.Equals(other);
			}

			public static bool operator ==(DeviceIdentifier lhs, DeviceIdentifier rhs)
			{
				return lhs.Equals(rhs);
			}

			public static bool operator !=(DeviceIdentifier lhs, DeviceIdentifier rhs)
			{
				return !lhs.Equals(rhs);
			}
		}

		private static UnityInputManagerSettings GpTIdVoPNWTGlMtJhXJNFcQbhzxp;

		internal static Action wkSBvelwJOAgAtvQejrRTllIsvur;

		private bool KDAQDrbPKZnGJMNrzbMFcROYnxlfb;

		private readonly List<DeviceIdentifier> OugqyzemIZvcOBPgIABMhvqgatcZA;

		private readonly ReadOnlyCollection<DeviceIdentifier> BKqVYOUoTmRsLhzcsOzpCBaFCycP;

		private static UnityInputManagerSettings YsLlizmlFeLjcftKzILAivfIbVMf
		{
			get
			{
				if (GpTIdVoPNWTGlMtJhXJNFcQbhzxp == null)
				{
					return GpTIdVoPNWTGlMtJhXJNFcQbhzxp = new UnityInputManagerSettings();
				}
				return GpTIdVoPNWTGlMtJhXJNFcQbhzxp;
			}
		}

		public static IList<DeviceIdentifier> disallowedJoysticks
		{
			get
			{
				return YsLlizmlFeLjcftKzILAivfIbVMf.BKqVYOUoTmRsLhzcsOzpCBaFCycP;
			}
			set
			{
				int count = YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Count;
				YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Clear();
				if (value == null)
				{
					if (count > 0)
					{
						obWzmmwyeBshbcrSVyXeROsSLgOA();
					}
					return;
				}
				for (int i = 0; i < value.Count; i++)
				{
					YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Add(value[i]);
				}
				if (YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Count > 0)
				{
					obWzmmwyeBshbcrSVyXeROsSLgOA();
				}
			}
		}

		internal static void GfOeXtjAckQnvFFFAVnavhxrYkwC()
		{
			if (!YsLlizmlFeLjcftKzILAivfIbVMf.KDAQDrbPKZnGJMNrzbMFcROYnxlfb)
			{
				if (UnityTools.isAndroidPlatform)
				{
					gsEUiTnBkoIdfaelfJgoSvFQrmfHA(new DeviceIdentifier
					{
						name = "Amazon Fire TV Remote"
					});
					gsEUiTnBkoIdfaelfJgoSvFQrmfHA(new DeviceIdentifier
					{
						name = ".*Nexus Remote.*",
						useRegex = true
					});
				}
				YsLlizmlFeLjcftKzILAivfIbVMf.KDAQDrbPKZnGJMNrzbMFcROYnxlfb = true;
			}
		}

		private static void gsEUiTnBkoIdfaelfJgoSvFQrmfHA(DeviceIdentifier P_0)
		{
			if (!YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Contains(P_0))
			{
				YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA.Add(P_0);
			}
		}

		internal static bool QlCXBAmKPkYBRufluhMnGPBirkFZA(string P_0)
		{
			List<DeviceIdentifier> ougqyzemIZvcOBPgIABMhvqgatcZA = YsLlizmlFeLjcftKzILAivfIbVMf.OugqyzemIZvcOBPgIABMhvqgatcZA;
			int count = ougqyzemIZvcOBPgIABMhvqgatcZA.Count;
			for (int i = 0; i < count; i++)
			{
				if (ougqyzemIZvcOBPgIABMhvqgatcZA[i].useRegex)
				{
					if (Regex.IsMatch(P_0, ougqyzemIZvcOBPgIABMhvqgatcZA[i].name))
					{
						return false;
					}
				}
				else if (string.Equals(P_0, ougqyzemIZvcOBPgIABMhvqgatcZA[i].name, StringComparison.Ordinal))
				{
					return false;
				}
			}
			return true;
		}

		private static void obWzmmwyeBshbcrSVyXeROsSLgOA()
		{
			wkSBvelwJOAgAtvQejrRTllIsvur?.Invoke();
		}

		private UnityInputManagerSettings()
		{
			OugqyzemIZvcOBPgIABMhvqgatcZA = new List<DeviceIdentifier>();
			BKqVYOUoTmRsLhzcsOzpCBaFCycP = new ReadOnlyCollection<DeviceIdentifier>(OugqyzemIZvcOBPgIABMhvqgatcZA);
		}
	}
}
