using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class DeviceLocalizationInfo
	{
		public readonly Guid guid;

		public readonly ControllerType controllerType;

		public readonly bool isControllerTemplate;

		private readonly ReadOnlyList<string> AUGBqRkUDEHqPHoTXMAjNFHtWapgA;

		private readonly IList<string> sPMYRLeeizFYwyoqQijPdombKSHL;

		private readonly ReadOnlyList<Guid> MZmEZheylyIwHgDLrmwsCkDBmzCeA;

		private string AxUdvRbKsgubaSBJrzOxsZigUPxn;

		private Bytes20 DOgxlZjdaYjZHYkXIOozrQPRHrdh;

		private bool QjnruDSogCHUkGRhWPgkivsBSRgsb;

		public ReadOnlyList<string> parentKeys => AUGBqRkUDEHqPHoTXMAjNFHtWapgA;

		public ReadOnlyList<Guid> controllerTemplateGuids => MZmEZheylyIwHgDLrmwsCkDBmzCeA;

		public string additionalIdentifyingInformation
		{
			get
			{
				return AxUdvRbKsgubaSBJrzOxsZigUPxn;
			}
			set
			{
				YbhTqNXEVLIqUvipfisxqHHCXlOm();
				AxUdvRbKsgubaSBJrzOxsZigUPxn = value;
			}
		}

		public Bytes20 hash => DOgxlZjdaYjZHYkXIOozrQPRHrdh;

		public DeviceLocalizationInfo()
		{
			sPMYRLeeizFYwyoqQijPdombKSHL = new List<string>();
			AUGBqRkUDEHqPHoTXMAjNFHtWapgA = new ReadOnlyList<string>(sPMYRLeeizFYwyoqQijPdombKSHL);
		}

		public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
		{
			controllerType = P_0;
			isControllerTemplate = P_1;
			guid = P_2;
			IList<string> list2;
			if (P_3 == null)
			{
				IList<string> list = new List<string>();
				list2 = list;
			}
			else
			{
				list2 = P_3;
			}
			sPMYRLeeizFYwyoqQijPdombKSHL = list2;
			AUGBqRkUDEHqPHoTXMAjNFHtWapgA = new ReadOnlyList<string>(sPMYRLeeizFYwyoqQijPdombKSHL);
			if (P_4 != null)
			{
				MZmEZheylyIwHgDLrmwsCkDBmzCeA = new ReadOnlyList<Guid>(P_4);
			}
		}

		public DeviceLocalizationInfo(DeviceLocalizationInfo P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			guid = P_0.guid;
			controllerType = P_0.controllerType;
			isControllerTemplate = P_0.isControllerTemplate;
			sPMYRLeeizFYwyoqQijPdombKSHL = ((P_0.sPMYRLeeizFYwyoqQijPdombKSHL != null) ? new List<string>(P_0.sPMYRLeeizFYwyoqQijPdombKSHL) : new List<string>());
			AUGBqRkUDEHqPHoTXMAjNFHtWapgA = new ReadOnlyList<string>(sPMYRLeeizFYwyoqQijPdombKSHL);
			if (P_0.controllerTemplateGuids != null)
			{
				MZmEZheylyIwHgDLrmwsCkDBmzCeA = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
			}
			QjnruDSogCHUkGRhWPgkivsBSRgsb = P_0.QjnruDSogCHUkGRhWPgkivsBSRgsb;
		}

		public void InsertParentKey(int index, string key)
		{
			YbhTqNXEVLIqUvipfisxqHHCXlOm();
			if (!string.IsNullOrEmpty(key))
			{
				sPMYRLeeizFYwyoqQijPdombKSHL.Insert(index, key);
			}
		}

		public void FinishRuntimeSetup()
		{
			ComputeHash();
			ONgYWDXJihhByZZsyoEcSewvVLJf();
		}

		public Bytes20 ComputeHash()
		{
			StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
			sharedStringBuilder.Append(controllerType.ToString());
			bool flag = isControllerTemplate;
			sharedStringBuilder.Append(flag.ToString());
			sharedStringBuilder.Append(guid.ToString());
			int count = sPMYRLeeizFYwyoqQijPdombKSHL.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.IsNullOrEmpty(sPMYRLeeizFYwyoqQijPdombKSHL[i]))
				{
					sharedStringBuilder.Append(sPMYRLeeizFYwyoqQijPdombKSHL[i]);
				}
			}
			sharedStringBuilder.Append(AxUdvRbKsgubaSBJrzOxsZigUPxn);
			DOgxlZjdaYjZHYkXIOozrQPRHrdh = MiscTools.HashSHA1(sharedStringBuilder.ToString());
			return DOgxlZjdaYjZHYkXIOozrQPRHrdh;
		}

		private void ONgYWDXJihhByZZsyoEcSewvVLJf()
		{
			QjnruDSogCHUkGRhWPgkivsBSRgsb = true;
		}

		private void YbhTqNXEVLIqUvipfisxqHHCXlOm()
		{
			if (QjnruDSogCHUkGRhWPgkivsBSRgsb)
			{
				throw new Exception("Cannot modify a read-only object.");
			}
		}

		public static bool DataMatches(DeviceLocalizationInfo a, DeviceLocalizationInfo b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.sPMYRLeeizFYwyoqQijPdombKSHL.Count != b.sPMYRLeeizFYwyoqQijPdombKSHL.Count)
			{
				return false;
			}
			int count = a.sPMYRLeeizFYwyoqQijPdombKSHL.Count;
			for (int i = 0; i < count; i++)
			{
				if (!string.Equals(a.sPMYRLeeizFYwyoqQijPdombKSHL[i], b.sPMYRLeeizFYwyoqQijPdombKSHL[i], StringComparison.Ordinal))
				{
					return false;
				}
			}
			int num = ((a.MZmEZheylyIwHgDLrmwsCkDBmzCeA != null) ? a.MZmEZheylyIwHgDLrmwsCkDBmzCeA.Count : 0);
			int num2 = ((b.MZmEZheylyIwHgDLrmwsCkDBmzCeA != null) ? b.MZmEZheylyIwHgDLrmwsCkDBmzCeA.Count : 0);
			if (num != num2)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (a.MZmEZheylyIwHgDLrmwsCkDBmzCeA[j] != b.MZmEZheylyIwHgDLrmwsCkDBmzCeA[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
