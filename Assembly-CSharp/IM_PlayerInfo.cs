using UnityEngine;

public class IM_PlayerInfo : MonoBehaviour
{
	private Rect windowRect = new Rect(20f, 20f, 250f, 200f);

	private Vector2 scrollPosition;

	private void OnGUI()
	{
		windowRect = GUILayout.Window(0, windowRect, WindowFunction, "Player Info");
	}

	private void WindowFunction(int windowID)
	{
		GUILayout.BeginVertical();
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);
		GUILayout.Label($"Position: {ENT_Player.GetPlayer().transform.position}");
		GUILayout.Label($"Rotation: {ENT_Player.GetPlayer().GetCameraTargetRotation()}");
		GUILayout.Label("<b>States</b>");
		GUILayout.Label($"Health: {ENT_Player.GetPlayer().health} / {ENT_Player.GetPlayer().maxHealth}");
		GUILayout.Label($"Breath: {ENT_Player.GetPlayer().breathMax} / {ENT_Player.GetPlayer().breathMax}");
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}
}
