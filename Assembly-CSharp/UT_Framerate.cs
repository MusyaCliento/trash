using TMPro;
using UnityEngine;

public class UT_Framerate : MonoBehaviour
{
	private TMP_Text counter;

	public bool hidden = true;

	private float updateTime;

	private void Start()
	{
		counter = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		updateTime -= Time.deltaTime;
		if (!(updateTime > 0f))
		{
			updateTime = 0.25f;
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				hidden = !hidden;
			}
			if (hidden)
			{
				counter.text = "";
				return;
			}
			float num = Mathf.RoundToInt(1f / Time.unscaledDeltaTime);
			counter.text = num + " FPS";
		}
	}
}
