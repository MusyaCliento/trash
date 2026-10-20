using Drawing;
using UnityEngine;

public class CL_DebugView : MonoBehaviour
{
	public static bool initialized;

	public static CL_DebugView instance;

	public static CommandBuilder draw;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			draw = DrawingManager.GetBuilder(renderInGame: true);
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
		draw.Dispose();
		draw = DrawingManager.GetBuilder(renderInGame: true);
		draw.cameraTargets = new Camera[1] { Camera.main };
	}

	public static void SetCameraTarget(Camera camera)
	{
		draw.cameraTargets = new Camera[1] { camera };
	}
}
