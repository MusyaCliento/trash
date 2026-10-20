using UnityEngine;

public class UT_InstantDeath : MonoBehaviour
{
	public string[] triggerTags = new string[1] { "Player" };

	public string type;

	private void OnTriggerEnter(Collider other)
	{
		string[] array = triggerTags;
		foreach (string text in array)
		{
			if (other.tag == text)
			{
				GameEntity component = other.GetComponent<GameEntity>();
				if (component != null)
				{
					component.Kill(type);
				}
			}
		}
	}
}
