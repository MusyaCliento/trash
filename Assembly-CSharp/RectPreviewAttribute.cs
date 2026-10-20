using UnityEngine;

public class RectPreviewAttribute : PropertyAttribute
{
	public readonly float width;

	public readonly float height;

	public float interiorWidth;

	public float interiorHeight;

	public bool flipX;

	public bool flipY;

	public RectPreviewAttribute(float width, float height)
	{
		this.width = width;
		this.height = height;
	}
}
