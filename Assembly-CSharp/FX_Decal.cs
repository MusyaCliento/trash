using Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class FX_Decal : MonoBehaviourGizmos
{
	public FXManager.DecalPriority priority;

	public Color color = Color.white;

	public FXManager.DecalHandle handle;

	public FX_DecalShared shared;

	public Vector2 scale = Vector2.one;

	private void OnEnable()
	{
		FXManager.DecalDestroy(handle);
		handle = FXManager.DecalCreate(priority);
		UpdateDecal();
	}

	private void OnDisable()
	{
		FXManager.DecalDestroy(handle);
	}

	private void Update()
	{
		UpdateDecal();
	}

	private void UpdateDecal()
	{
		FXManager.DecalSharedOutput decalSharedOutput = FXManager.DecalSharedData(shared);
		decalSharedOutput.extents = new Vector3(decalSharedOutput.extents.x * scale.x, decalSharedOutput.extents.y * scale.y, decalSharedOutput.extents.z);
		FXManager.DecalSharedApply(handle, decalSharedOutput);
		FXManager.DecalParentWithOffset(handle, base.transform, Matrix4x4.identity);
		FXManager.DecalColor(handle, color);
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.PushColor(color);
		Draw.PushMatrix(base.transform.worldToLocalMatrix);
		FXManager.DecalSharedOutput decalSharedOutput = FXManager.DecalSharedData(shared);
		decalSharedOutput.extents = new Vector3(decalSharedOutput.extents.x * scale.x, decalSharedOutput.extents.y * scale.y, decalSharedOutput.extents.z);
		Draw.WireBox(Vector3.zero, decalSharedOutput.extents);
		Draw.PopMatrix();
		Draw.PopColor();
	}
}
