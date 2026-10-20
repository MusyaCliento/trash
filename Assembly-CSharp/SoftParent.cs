using UnityEngine;

public class SoftParent
{
	public Transform parent;

	public Transform transform;

	private Vector3 parentPosition;

	private Vector3 parentLookVector;

	private Vector3 rotationOffset;

	private Vector3 lastParentPosition;

	private Vector3 parentWorldPosition;

	private Vector3 lastRotation;

	private Vector3 velocity;

	private Vector3 worldVelocity;

	public GameObject destroyEffect;

	public Vector3 lockAngles = Vector3.one;

	private bool initialized;

	private Vector3 lastPosition;

	private Matrix4x4 lastParentWorldMatrix;

	private Matrix4x4 currentParentWorldMatrix;

	public void Initialize(Transform target, Transform parentTarget)
	{
		transform = target;
		Parent(parentTarget);
	}

	public Vector3 GetUpdatedPosition()
	{
		return parent.TransformPoint(parentPosition);
	}

	public Vector3 GetParentPosition()
	{
		return parentPosition;
	}

	public Vector3 GetPositionDifference()
	{
		if (parent == null)
		{
			return Vector3.zero;
		}
		lastParentPosition = parentPosition;
		return parent.TransformPoint(parentPosition) - transform.position;
	}

	public Quaternion GetRotationalDifference()
	{
		return Quaternion.Euler(Vector3.Scale((parent.rotation * Quaternion.Euler(rotationOffset) * Quaternion.Inverse(transform.rotation)).eulerAngles, lockAngles));
	}

	public Vector3 GetDeltaVelocity()
	{
		return parentPosition - lastPosition;
	}

	public Vector3 GetDeltaWorldVelocity()
	{
		return worldVelocity;
	}

	public Vector3 GetPositionDeltaWorldDifference()
	{
		return parent.TransformPoint(parentPosition) - parentWorldPosition;
	}

	public void UpdateInfo()
	{
		if (!(parent == null))
		{
			UpdatePositionInfo();
			UpdateRotationInfo();
		}
	}

	public void UpdatePositionInfo()
	{
		if (!(parent == null))
		{
			lastPosition = parentPosition;
			parentWorldPosition = transform.position;
			lastParentWorldMatrix = transform.worldToLocalMatrix;
			parentPosition = parent.InverseTransformPoint(transform.position);
			lastParentWorldMatrix = currentParentWorldMatrix;
			currentParentWorldMatrix = parent.localToWorldMatrix;
			Vector3 vector = lastParentWorldMatrix.MultiplyPoint3x4(parentPosition);
			Vector3 vector2 = currentParentWorldMatrix.MultiplyPoint3x4(parentPosition);
			velocity = GetDeltaVelocity() / Time.deltaTime;
			worldVelocity = (vector2 - vector) / Time.deltaTime;
		}
	}

	public void UpdateRotationInfo()
	{
		if (!(parent == null))
		{
			rotationOffset = (Quaternion.Inverse(parent.rotation) * transform.rotation).eulerAngles;
		}
	}

	public void UpdatePosition()
	{
		if (!(parent == null) && parent != null && parent.gameObject.activeInHierarchy)
		{
			transform.gameObject.SetActive(value: true);
			transform.position = parent.TransformPoint(parentPosition);
			Debug.Log("Moving " + transform);
		}
	}

	public void Parent(Transform parentTarget)
	{
		if (!(parentTarget == null) && !(parentTarget == parent))
		{
			parent = parentTarget;
			parentPosition = parent.InverseTransformPoint(transform.position);
			lastPosition = parentPosition;
			parentWorldPosition = transform.position;
			rotationOffset = (Quaternion.Inverse(parent.rotation) * transform.rotation).eulerAngles;
			currentParentWorldMatrix = parent.localToWorldMatrix;
			lastParentWorldMatrix = currentParentWorldMatrix;
		}
	}

	public Vector3 GetVelocity()
	{
		return velocity;
	}

	public void Unparent()
	{
		parent = null;
	}

	public bool IsParented()
	{
		return parent != null;
	}

	public Transform GetParent()
	{
		return parent;
	}
}
