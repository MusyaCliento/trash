using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class CL_OverlayUIManager : MonoBehaviour
{
	public static CL_OverlayUIManager instance;

	public Message_Manager messageManager;

	public OS_Tooltip_Manager tooltipManager;

	private CanvasScaler canvas;

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		canvas = GetComponent<CanvasScaler>();
		instance = this;
	}

	public Vector2 GetScreenScale()
	{
		return new Vector2((float)Screen.currentResolution.width / canvas.referenceResolution.x, (float)Screen.currentResolution.height / canvas.referenceResolution.y);
	}
}
