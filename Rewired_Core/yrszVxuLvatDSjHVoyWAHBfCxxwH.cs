using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class yrszVxuLvatDSjHVoyWAHBfCxxwH
{
	[Flags]
	public enum MiVthGLYeiiScQYdRZMlfzaTAgzL
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class kZfiQOmeKpzEHIpSalfCPwYXJCqr
	{
		public bool moqthEQGuiziQGkRAgGBHAvVfGDAb;

		public bool LPwXHiTNPKCdhjXuNkVtfgqYBXdK;

		public bool lLtyRUZZoCPIYtbKSqpwjdrViUQS;
	}

	private Dictionary<int, kZfiQOmeKpzEHIpSalfCPwYXJCqr> wlhGnBFoBEgaBKrwLwfMpGbNnfUF;

	public MiVthGLYeiiScQYdRZMlfzaTAgzL cbzOtEOfYnIubgtJgRmrmAUrOZtc;

	private bool zeiULcRSVxvyQXzBdtIoUJAwqYkB => UnityTools.supportsUnityUIGraphicRaycastTarget;

	public yrszVxuLvatDSjHVoyWAHBfCxxwH()
		: this(MiVthGLYeiiScQYdRZMlfzaTAgzL.Self | MiVthGLYeiiScQYdRZMlfzaTAgzL.Children)
	{
	}

	public yrszVxuLvatDSjHVoyWAHBfCxxwH(MiVthGLYeiiScQYdRZMlfzaTAgzL P_0)
	{
		cbzOtEOfYnIubgtJgRmrmAUrOZtc = P_0;
		wlhGnBFoBEgaBKrwLwfMpGbNnfUF = new Dictionary<int, kZfiQOmeKpzEHIpSalfCPwYXJCqr>();
	}

	public void PWwmpVscPWxZbNbZbLHtHYwunjoM(Transform P_0, bool P_1)
	{
		if (!zeiULcRSVxvyQXzBdtIoUJAwqYkB)
		{
			return;
		}
		if ((cbzOtEOfYnIubgtJgRmrmAUrOZtc & MiVthGLYeiiScQYdRZMlfzaTAgzL.Self) != MiVthGLYeiiScQYdRZMlfzaTAgzL.None)
		{
			if ((cbzOtEOfYnIubgtJgRmrmAUrOZtc & MiVthGLYeiiScQYdRZMlfzaTAgzL.Children) != MiVthGLYeiiScQYdRZMlfzaTAgzL.None)
			{
				jDzxRgXspZEpAuOmRqsYoqviCJoK(P_0, P_1, wlhGnBFoBEgaBKrwLwfMpGbNnfUF);
			}
			else
			{
				ZNNbGaCxrazidqwiIDRKnOnjhKyg(P_0, P_1, wlhGnBFoBEgaBKrwLwfMpGbNnfUF);
			}
		}
		else if ((cbzOtEOfYnIubgtJgRmrmAUrOZtc & MiVthGLYeiiScQYdRZMlfzaTAgzL.Children) != MiVthGLYeiiScQYdRZMlfzaTAgzL.None)
		{
			BWiajWGjJepkocQninbSWVCNjulSb(P_0, P_1, wlhGnBFoBEgaBKrwLwfMpGbNnfUF);
		}
	}

	public void qycJsgxamcLeWpFuAXBFFVqsWjiy()
	{
		if (zeiULcRSVxvyQXzBdtIoUJAwqYkB)
		{
			wlhGnBFoBEgaBKrwLwfMpGbNnfUF.Clear();
		}
	}

	private static void jDzxRgXspZEpAuOmRqsYoqviCJoK(Transform P_0, bool P_1, Dictionary<int, kZfiQOmeKpzEHIpSalfCPwYXJCqr> P_2)
	{
		if (!(P_0 == null))
		{
			ZNNbGaCxrazidqwiIDRKnOnjhKyg(P_0, P_1, P_2);
			BWiajWGjJepkocQninbSWVCNjulSb(P_0, P_1, P_2);
		}
	}

	private static void BWiajWGjJepkocQninbSWVCNjulSb(Transform P_0, bool P_1, Dictionary<int, kZfiQOmeKpzEHIpSalfCPwYXJCqr> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				jDzxRgXspZEpAuOmRqsYoqviCJoK(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void ZNNbGaCxrazidqwiIDRKnOnjhKyg(Transform P_0, bool P_1, Dictionary<int, kZfiQOmeKpzEHIpSalfCPwYXJCqr> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		Graphic component = P_0.GetComponent<Graphic>();
		if (component == null)
		{
			return;
		}
		bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
		int instanceID = component.GetInstanceID();
		if (!P_2.TryGetValue(instanceID, out var value))
		{
			if (!flag)
			{
				return;
			}
			value = new kZfiQOmeKpzEHIpSalfCPwYXJCqr();
			value.moqthEQGuiziQGkRAgGBHAvVfGDAb = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.LPwXHiTNPKCdhjXuNkVtfgqYBXdK && flag == value.moqthEQGuiziQGkRAgGBHAvVfGDAb) || (!value.LPwXHiTNPKCdhjXuNkVtfgqYBXdK && flag != value.moqthEQGuiziQGkRAgGBHAvVfGDAb))
		{
			value.LPwXHiTNPKCdhjXuNkVtfgqYBXdK = false;
			value.lLtyRUZZoCPIYtbKSqpwjdrViUQS = false;
			value.moqthEQGuiziQGkRAgGBHAvVfGDAb = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.moqthEQGuiziQGkRAgGBHAvVfGDAb)
		{
			if (value.moqthEQGuiziQGkRAgGBHAvVfGDAb == P_1)
			{
				value.LPwXHiTNPKCdhjXuNkVtfgqYBXdK = false;
				value.lLtyRUZZoCPIYtbKSqpwjdrViUQS = false;
			}
			else
			{
				value.LPwXHiTNPKCdhjXuNkVtfgqYBXdK = true;
				value.lLtyRUZZoCPIYtbKSqpwjdrViUQS = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
