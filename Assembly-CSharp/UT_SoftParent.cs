using System;
using Unity.VisualScripting;
using UnityEngine;

public class UT_SoftParent : MonoBehaviour
{
	public Transform parent;

	private Vector3 parentPosition;

	private Vector3 parentInitialWorldOffset;

	private Vector3 parentLookVector;

	private Vector3 rotationOffset;

	public bool parentOnlyOffsetInWorldSpace;

	public GameObject destroyEffect;

	private UT_SoftParentTarget target;

	public bool disableOnNoParent;

	public bool moveOnUpdate;

	public Action _OnDisableWhenNoParent;

	public Action _OnLoseParent;

	public bool UseLateUpdate;

	public void Initialize(Transform p)
	{
		ObjectTagger component = p.GetComponent<ObjectTagger>();
		if (component != null && component.HasTag("Player"))
		{
			p = ENT_Player.GetPlayer().camRoot.transform;
		}
		parent = p;
		parentPosition = parent.InverseTransformPoint(base.transform.position);
		parentInitialWorldOffset = base.transform.position - parent.position;
		rotationOffset = (Quaternion.Inverse(parent.rotation) * base.transform.rotation).eulerAngles;
		if (component != null && !component.HasTag("ignoresoftparent"))
		{
			target = parent.AddComponent<UT_SoftParentTarget>();
			target.AddChild(this);
		}
	}

	public void ClearParent()
	{
		if (parent != null)
		{
			if (target != null)
			{
				target.RemoveChild(this);
			}
			parent = null;
		}
	}

	public void SoftMove(Vector3 moveVec)
	{
		parentPosition = parent.InverseTransformPoint(base.transform.position + moveVec);
	}

	private void Update()
	{
		if (!UseLateUpdate)
		{
			CheckEnable();
		}
	}

	private void LateUpdate()
	{
		if (UseLateUpdate)
		{
			CheckEnable();
		}
	}

	internal void CheckEnable()
	{
		if (parent != null && parent.gameObject.activeInHierarchy)
		{
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (parentOnlyOffsetInWorldSpace)
			{
				base.transform.position = parent.position + parentInitialWorldOffset;
				return;
			}
			base.transform.position = parent.TransformPoint(parentPosition);
			base.transform.rotation = parent.rotation * Quaternion.Euler(rotationOffset);
		}
		else if (parent != null && !parent.gameObject.activeInHierarchy)
		{
			_OnLoseParent?.Invoke();
			if (disableOnNoParent && base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: false);
				_OnDisableWhenNoParent?.Invoke();
			}
		}
		else
		{
			if (!(parent == null))
			{
				return;
			}
			if (disableOnNoParent)
			{
				base.gameObject.SetActive(value: false);
				if ((bool)destroyEffect)
				{
					UnityEngine.Object.Instantiate(destroyEffect, base.transform.position, base.transform.rotation);
				}
				_OnDisableWhenNoParent?.Invoke();
			}
			else
			{
				parent = null;
			}
		}
	}

	internal void DestroySelf()
	{
		_OnLoseParent?.Invoke();
		if (disableOnNoParent)
		{
			if ((bool)destroyEffect)
			{
				UnityEngine.Object.Instantiate(destroyEffect, base.transform.position, base.transform.rotation);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			parent = null;
		}
	}
}
