using UnityEngine;

[ExecuteAlways]
public class UI_ElementScaler : MonoBehaviour
{
	[Header("Scale Settings")]
	[Tooltip("Minimum scale factor for the UI element.")]
	public float minScale = 0.8f;

	[Tooltip("Maximum scale factor for the UI element.")]
	public float maxScale = 1.2f;

	[Header("Resolution Settings")]
	[Tooltip("Minimum window width resolution.")]
	public float minResolution = 800f;

	[Tooltip("Maximum window width resolution.")]
	public float maxResolution = 1920f;

	private RectTransform rectTransform;

	private Vector2 lastWindowSize;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		UpdateScale();
	}

	private void Update()
	{
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (vector != lastWindowSize)
		{
			UpdateScale();
			lastWindowSize = vector;
		}
	}

	private void UpdateScale()
	{
		float t = (Mathf.Clamp(Screen.width, minResolution, maxResolution) - minResolution) / (maxResolution - minResolution);
		float num = Mathf.Lerp(minScale, maxScale, t);
		rectTransform.localScale = new Vector3(num, num, 1f);
	}
}
