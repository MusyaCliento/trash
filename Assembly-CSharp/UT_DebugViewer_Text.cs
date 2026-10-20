using Drawing;
using UnityEngine;

public class UT_DebugViewer_Text : MonoBehaviour
{
	public string text = "Debug Text";

	public float size = 14f;

	public Color color = Color.white;

	public Vector3 offset;

	public bool alignToCenter = true;

	public bool alwaysShow;

	private void Update()
	{
		if (CL_UIManager.debug || alwaysShow)
		{
			CL_DebugView.draw.Label2D(base.transform.position + offset, text, size, alignToCenter ? LabelAlignment.Center : LabelAlignment.BottomLeft, color);
		}
	}

	public void SetText(string t)
	{
		text = t;
	}

	public void SetColor(string c)
	{
		ColorUtility.TryParseHtmlString(c, out color);
	}

	public void SetColor(Color c)
	{
		color = c;
	}

	public void SetSize(float s)
	{
		size = s;
	}
}
