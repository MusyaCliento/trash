using Drawing;
using UnityEngine;

public class FX_BeamSurface : MonoBehaviourGizmos
{
	[HideInInspector]
	public FX_BeamManager.Surface surface;

	[HideInInspector]
	public FX_BeamManager.System parentSystem;

	[SerializeField]
	private bool isActive = true;

	public FX_BeamManager.SurfaceShapeData shape;

	public void Refresh()
	{
		FX_BeamManager.SurfaceXForm(surface, base.transform, Matrix4x4.identity);
		FX_BeamManager.SurfaceShape(surface, in shape);
		FX_BeamManager.SurfaceEnabled(surface, isActive);
	}

	public void SetActive(bool active)
	{
		FX_BeamManager.SurfaceEnabled(surface, active);
		isActive = active;
	}

	private void OnEnable()
	{
		FX_BeamManager.SurfaceEnabled(surface, enabled: true);
	}

	private void OnDisable()
	{
		FX_BeamManager.SurfaceEnabled(surface, enabled: false);
	}

	public override void DrawGizmos()
	{
		FX_BeamManager.SurfaceShapeDraw(ref Draw.editor, in shape, base.transform.localToWorldMatrix);
	}
}
