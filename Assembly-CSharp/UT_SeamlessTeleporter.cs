using System.Collections;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_SeamlessTeleporter : MonoBehaviourGizmos
{
	public Transform destinationTransform;

	public Bounds bounds;

	public UnityEvent eventOnTeleport;

	public void Teleport()
	{
		StartCoroutine(TeleportRoutine());
		eventOnTeleport.Invoke();
		IEnumerator TeleportRoutine()
		{
			yield return new WaitForEndOfFrame();
			InstantTeleport();
		}
	}

	public void InstantTeleport()
	{
		foreach (GameEntity entity in GameEntity.entities)
		{
			if (entity != null && entity.gameObject.activeSelf && IsPositionInBounds(entity.transform.position))
			{
				Vector3 pos = destinationTransform.TransformPoint(base.transform.InverseTransformPoint(entity.transform.position));
				Quaternion rot = base.transform.rotation * Quaternion.Inverse(destinationTransform.rotation) * entity.transform.rotation;
				entity.Teleport(pos, rot, keepVelocity: true);
			}
		}
	}

	public bool IsPositionInBounds(Vector3 position)
	{
		return bounds.Contains(base.transform.InverseTransformPoint(position));
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.red);
		Draw.SolidBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, new Color(0f, 0f, 1f, 0.01f));
		Draw.Arrow(base.transform.position, destinationTransform.position, Color.yellow);
		Draw.WireBox(destinationTransform.position + bounds.center, destinationTransform.rotation, bounds.size, Color.red);
		Draw.SolidBox(destinationTransform.position + bounds.center, destinationTransform.rotation, bounds.size, new Color(0f, 0f, 1f, 0.01f));
	}
}
