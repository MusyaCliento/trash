using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TabFade : MonoBehaviour
{
	private Image sprite;

	private TMP_Text text;

	private float speed = 6f;

	public float delayTime;

	private float minOpacity;

	private float maxOpacity = 1f;

	private void Start()
	{
		sprite = base.gameObject.GetComponent<Image>();
		text = base.gameObject.GetComponent<TMP_Text>();
	}

	private void Update()
	{
		if (delayTime > 0f)
		{
			delayTime -= Time.deltaTime;
		}
		if ((bool)sprite)
		{
			if (Input.GetKey(KeyCode.Tab))
			{
				Color color = sprite.color;
				color.a = Mathf.Lerp(color.a, maxOpacity, Time.deltaTime * speed);
				sprite.color = color;
			}
			else if (delayTime <= 0f)
			{
				Color color2 = sprite.color;
				color2.a = Mathf.Lerp(color2.a, minOpacity, Time.deltaTime * speed);
				sprite.color = color2;
			}
		}
		else if ((bool)text)
		{
			if (Input.GetKey(KeyCode.Tab))
			{
				Color color3 = text.color;
				color3.a = Mathf.Lerp(color3.a, maxOpacity, Time.deltaTime * speed);
				text.color = color3;
			}
			else if (delayTime <= 0f)
			{
				Color color4 = text.color;
				color4.a = Mathf.Lerp(color4.a, minOpacity, Time.deltaTime * speed);
				text.color = color4;
			}
		}
	}

	public void SetMinimumOpacity(float f)
	{
		minOpacity = f;
	}

	public void SetMaximumOpacity(float f)
	{
		maxOpacity = f;
	}
}
