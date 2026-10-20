using System.Collections.Generic;
using UnityEngine;

public class UT_SoftParentTarget : MonoBehaviour
{
	private List<UT_SoftParent> children;

	private void OnEnable()
	{
		if (children == null)
		{
			return;
		}
		foreach (UT_SoftParent child in children)
		{
			if (!(child == null))
			{
				child.CheckEnable();
			}
		}
	}

	public void OnDestroy()
	{
		ClearChildren();
	}

	public void AddChild(UT_SoftParent sp)
	{
		if (children == null)
		{
			children = new List<UT_SoftParent>();
		}
		children.Add(sp);
	}

	public void RemoveChild(UT_SoftParent sp)
	{
		children.Remove(sp);
	}

	public void ClearChildren()
	{
		if (children == null)
		{
			return;
		}
		foreach (UT_SoftParent child in children)
		{
			if (!(child == null))
			{
				child.DestroySelf();
			}
		}
	}
}
