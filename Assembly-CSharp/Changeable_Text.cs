using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Changeable_Text : MonoBehaviour
{
	public bool canDoubleClick;

	public float dClickTime = 0.5f;

	private float cTime;

	private InputField inputField;

	public UnityEvent<string> updateEvent;

	private void Start()
	{
		inputField = GetComponent<InputField>();
	}

	private void Update()
	{
	}

	public void UpdateText()
	{
		inputField.DeactivateInputField();
		inputField.interactable = false;
		updateEvent.Invoke(inputField.text);
	}

	public void SetEditable()
	{
		inputField.text = inputField.textComponent.text;
		inputField.interactable = true;
		inputField.ActivateInputField();
	}

	public void TypeSound()
	{
		OS_Manager.soundPlayer.PlaySound("tap");
	}
}
