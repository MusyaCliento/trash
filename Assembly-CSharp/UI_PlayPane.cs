using UnityEngine;

public class UI_PlayPane : MonoBehaviour
{
	public class PlayModeTab
	{
		public GameObject tabAsset;

		public bool useCustomTabButton;

		public GameObject tabButtonAsset;
	}

	public GameObject tabButtonAsset;

	public UI_TabGroup tabGroup;

	public Transform tabRoot;

	private void Start()
	{
	}
}
