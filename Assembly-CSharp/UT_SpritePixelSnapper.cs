using UnityEngine;

public class UT_SpritePixelSnapper : MonoBehaviour
{
	public float snapScale = 0.01f;

	private bool editorSnapping;

	[ExecuteInEditMode]
	public void LateUpdate()
	{
		if (editorSnapping || Application.isPlaying)
		{
			Snap();
		}
	}

	public void Snap()
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition /= snapScale;
		localPosition.x = Mathf.Round(localPosition.x);
		localPosition.y = Mathf.Round(localPosition.y);
		localPosition.z = Mathf.Round(localPosition.z);
		localPosition *= snapScale;
		base.transform.localPosition = localPosition;
	}

	public void ToggleEditorSnapping()
	{
		editorSnapping = !editorSnapping;
	}
}
