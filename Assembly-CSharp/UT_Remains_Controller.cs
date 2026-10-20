using UnityEngine;

public class UT_Remains_Controller : MonoBehaviour
{
	public void SetRemainsActive(bool b)
	{
		foreach (GameEntity entity in GameEntity.entities)
		{
			if (!(entity == null) && entity is DEN_Remains_Active dEN_Remains_Active)
			{
				dEN_Remains_Active.active = b;
				if (!b)
				{
					dEN_Remains_Active.proximityLoop.volume = 0f;
				}
			}
		}
	}
}
