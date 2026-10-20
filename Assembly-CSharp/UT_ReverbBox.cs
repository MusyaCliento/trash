using Drawing;
using UnityEngine;

[RequireComponent(typeof(AudioReverbZone))]
public class UT_ReverbBox : MonoBehaviourGizmos
{
	public Vector3 size = Vector3.one * 5f;

	private Bounds bounds = new Bounds(Vector3.zero, Vector3.one * 5f);

	public float blendDistance = 5f;

	private AudioReverbZone reverbZone;

	private void Start()
	{
		reverbZone = GetComponent<AudioReverbZone>();
	}

	private void Update()
	{
		if (Camera.main != null)
		{
			bounds.size = size;
			float num = DistanceToBounds(Camera.main.transform.position, bounds);
			float a = Vector3.Distance(base.transform.InverseTransformPoint(Camera.main.transform.position), bounds.center);
			a = Mathf.Max(a, Mathf.Min(size.x, size.y, size.z) / 2f);
			reverbZone.minDistance = a - num;
			reverbZone.maxDistance = a - num + blendDistance;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(base.transform.position, $"MinDist: {reverbZone.minDistance:F1}\nMaxDist: {reverbZone.maxDistance:F1}" + "\nDistance: " + num, Color.white);
			}
		}
	}

	private float DistanceToBounds(Vector3 point, Bounds bounds)
	{
		Vector3 vector = base.transform.InverseTransformPoint(point);
		Vector3 b = bounds.ClosestPoint(vector);
		if (bounds.Contains(vector))
		{
			return 0f;
		}
		return Vector3.Distance(vector, b);
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		if (GizmoContext.InSelection(this))
		{
			this.bounds.size = size;
			Draw.WireBox(base.transform.position + this.bounds.center, base.transform.rotation, this.bounds.size, Color.yellow);
			Draw.SolidBox(base.transform.position + this.bounds.center, base.transform.rotation, this.bounds.size, new Color(0.7f, 0.3f, 0.2f, 0.01f));
			Bounds bounds = new Bounds(this.bounds.center, this.bounds.size + Vector3.one * blendDistance * 2f);
			Draw.WireBox(base.transform.position + bounds.center, base.transform.rotation, bounds.size, Color.cyan);
		}
	}
}
