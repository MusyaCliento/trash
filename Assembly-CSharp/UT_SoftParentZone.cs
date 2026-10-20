using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[DefaultExecutionOrder(-50)]
public class UT_SoftParentZone : MonoBehaviourGizmos
{
	public enum UpdateType
	{
		FixedUpdate = 0,
		Update = 1,
		LateUpdate = 2,
		FixedAnimationUpdate = 3,
		AfterFrameRender = 4
	}

	public Bounds bounds;

	private Vector3 lastPosition;

	private Quaternion lastRotation;

	private Matrix4x4 lastWorldMatrix;

	private Matrix4x4 currentWorldMatrix;

	public LayerMask scanMask;

	public bool preventExitVelocityTransfer;

	public UpdateType updateType;

	public bool useRigidbodyMovement;

	private void OnEnable()
	{
		currentWorldMatrix = base.transform.worldToLocalMatrix;
		lastWorldMatrix = currentWorldMatrix;
		StartCoroutine(AnimationUpdate());
	}

	private void LateUpdate()
	{
		if (updateType == UpdateType.LateUpdate)
		{
			UpdateMovement();
		}
	}

	private void Update()
	{
		if (updateType == UpdateType.Update)
		{
			UpdateMovement();
		}
	}

	private void FixedUpdate()
	{
		if (updateType == UpdateType.FixedUpdate)
		{
			UpdateMovement();
		}
	}

	private IEnumerator AnimationUpdate()
	{
		while (true)
		{
			if (updateType == UpdateType.FixedAnimationUpdate)
			{
				yield return new WaitForFixedUpdate();
				UpdateMovement();
			}
			else if (updateType == UpdateType.AfterFrameRender)
			{
				yield return new WaitForEndOfFrame();
				UpdateMovement();
			}
			else
			{
				yield return null;
			}
		}
	}

	public void UpdateMovement()
	{
		Quaternion quaternion2 = base.transform.rotation * Quaternion.Inverse(lastRotation);
		lastRotation = base.transform.rotation;
		lastWorldMatrix = currentWorldMatrix;
		currentWorldMatrix = base.transform.worldToLocalMatrix;
		Collider[] array = Physics.OverlapBox(base.transform.TransformPoint(bounds.center), bounds.extents, base.transform.rotation, scanMask);
		if (array == null || array.Length == 0 || !(Time.timeScale > 0f))
		{
			return;
		}
		HashSet<GameEntity> hashSet = new HashSet<GameEntity>();
		bool flag = false;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider == null)
			{
				return;
			}
			if (!collider.TryGetComponent<GameEntity>(out var component) || hashSet.Contains(component))
			{
				continue;
			}
			hashSet.Add(component);
			Vector3 vector = lastWorldMatrix.MultiplyPoint3x4(component.transform.position);
			Vector3 vector2 = currentWorldMatrix.MultiplyPoint3x4(component.transform.position) - vector;
			if (component == ENT_Player.GetPlayer())
			{
				ENT_Player.GetPlayer().ForceSoftParent(base.transform, preventExitVelocityTransfer);
				ENT_Player.GetPlayer().hands[0].UpdateHandPosition();
				ENT_Player.GetPlayer().hands[1].UpdateHandPosition();
				continue;
			}
			component.TryGetComponent<Rigidbody>(out var component2);
			if (useRigidbodyMovement && component2 != null)
			{
				if (!component2.isKinematic)
				{
					if (component2.interpolation == RigidbodyInterpolation.Interpolate)
					{
						flag = true;
					}
					component2.MovePosition(component2.transform.position - base.transform.TransformVector(vector2));
					component2.MoveRotation(quaternion2 * component.transform.rotation);
				}
			}
			else
			{
				if (component2 != null && component2.isKinematic)
				{
					continue;
				}
				if (component2 != null)
				{
					component.transform.position -= base.transform.TransformVector(vector2);
					component.transform.rotation = quaternion2 * component.transform.rotation;
					if (component2.interpolation == RigidbodyInterpolation.Interpolate)
					{
						flag = true;
					}
				}
				else
				{
					component.transform.position -= base.transform.TransformVector(vector2);
					component.transform.rotation = quaternion2 * component.transform.rotation;
				}
			}
		}
		if (flag)
		{
			Physics.SyncTransforms();
		}
	}

	public bool IsPositionInBounds(Vector3 position)
	{
		return bounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.blue);
			Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(0f, 0f, 1f, 0.01f));
		}
		else
		{
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(0f, 0f, 1f, 0.1f));
		}
	}
}
