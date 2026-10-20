using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint bOxdUqxHKHRCObPCwiuJzQdKAOQgA;

		private uint aCaBuhLJlRTmbVEdoYTVqAVgxjNu;

		private string PavzxSngDYrmEKJgXgoqIXCQrVEK;

		private bool olwFmRoqxaYBceDAeQtmwqFNizYE;

		public bool hasCachedValue => olwFmRoqxaYBceDAeQtmwqFNizYE;

		public string cachedValue
		{
			get
			{
				return PavzxSngDYrmEKJgXgoqIXCQrVEK;
			}
			set
			{
				olwFmRoqxaYBceDAeQtmwqFNizYE = true;
				PavzxSngDYrmEKJgXgoqIXCQrVEK = value;
			}
		}

		public LocalizedString()
		{
			bOxdUqxHKHRCObPCwiuJzQdKAOQgA = 0u;
			aCaBuhLJlRTmbVEdoYTVqAVgxjNu = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			bOxdUqxHKHRCObPCwiuJzQdKAOQgA = P_0.bOxdUqxHKHRCObPCwiuJzQdKAOQgA;
			aCaBuhLJlRTmbVEdoYTVqAVgxjNu = P_0.aCaBuhLJlRTmbVEdoYTVqAVgxjNu;
			PavzxSngDYrmEKJgXgoqIXCQrVEK = P_0.PavzxSngDYrmEKJgXgoqIXCQrVEK;
			olwFmRoqxaYBceDAeQtmwqFNizYE = P_0.olwFmRoqxaYBceDAeQtmwqFNizYE;
		}

		public void Clear()
		{
			bOxdUqxHKHRCObPCwiuJzQdKAOQgA = 0u;
			aCaBuhLJlRTmbVEdoYTVqAVgxjNu = 0u;
			PavzxSngDYrmEKJgXgoqIXCQrVEK = null;
			olwFmRoqxaYBceDAeQtmwqFNizYE = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = bOxdUqxHKHRCObPCwiuJzQdKAOQgA != ((localizer != null) ? localizerVersion : 0) || userVersion != aCaBuhLJlRTmbVEdoYTVqAVgxjNu;
			if (versionChanged)
			{
				Clear();
				bOxdUqxHKHRCObPCwiuJzQdKAOQgA = localizerVersion;
				aCaBuhLJlRTmbVEdoYTVqAVgxjNu = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (olwFmRoqxaYBceDAeQtmwqFNizYE ? PavzxSngDYrmEKJgXgoqIXCQrVEK : null);
				return olwFmRoqxaYBceDAeQtmwqFNizYE;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				olwFmRoqxaYBceDAeQtmwqFNizYE = localizer.TryGetLocalizedString(key, out PavzxSngDYrmEKJgXgoqIXCQrVEK) && !string.IsNullOrEmpty(PavzxSngDYrmEKJgXgoqIXCQrVEK);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (olwFmRoqxaYBceDAeQtmwqFNizYE ? PavzxSngDYrmEKJgXgoqIXCQrVEK : null);
			return olwFmRoqxaYBceDAeQtmwqFNizYE;
		}
	}
}
