using TMPro;
using UnityEngine;

public class UT_TMPTextInputController : MonoBehaviour
{
	public string prepend;

	public string append;

	public TMP_Text text;

	private void Start()
	{
		if (text == null)
		{
			text = GetComponent<TMP_Text>();
		}
	}

	public void SetPercent(float f)
	{
		text.text = prepend + Mathf.RoundToInt(f * 100f) + "%" + append;
	}
}
