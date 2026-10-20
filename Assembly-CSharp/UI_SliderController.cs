using UnityEngine;
using UnityEngine.UI;

public class UI_SliderController : MonoBehaviour
{
	private Slider slider;

	public bool primed;

	private void Start()
	{
		slider = GetComponent<Slider>();
	}

	private void Update()
	{
	}
}
