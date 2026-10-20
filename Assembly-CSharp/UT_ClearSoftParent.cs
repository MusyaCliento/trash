using System.Collections.Generic;
using UnityEngine;

public class UT_ClearSoftParent : MonoBehaviour
{
	public void Clear()
	{
		foreach (UT_SoftParentTarget item in new List<UT_SoftParentTarget>(GetComponentsInChildren<UT_SoftParentTarget>(includeInactive: true)))
		{
			item.ClearChildren();
		}
	}
}
