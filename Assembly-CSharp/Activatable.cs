using UnityEngine;

public interface Activatable
{
	void Deactivate();

	void Activate();

	void ToggleActivated();

	bool GetActiveState()
	{
		return false;
	}

	GameObject GetGameObject();
}
