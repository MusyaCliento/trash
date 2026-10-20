using UnityEngine;
using UnityEngine.Events;

public class UT_LevelAdjacencyEvents : MonoBehaviour
{
	public M_Level targetLevel;

	public UnityEvent<M_Level> onHasPreviousLevelEvent;

	public UnityEvent<M_Level> onHasNoPreviousLevelEvent;

	public UnityEvent<M_Level> onHasNextLevelEvent;

	public UnityEvent<M_Level> onHasNoNextLevelEvent;

	private void Start()
	{
		M_Level adjacentLevel = targetLevel.GetAdjacentLevel(-1);
		M_Level adjacentLevel2 = targetLevel.GetAdjacentLevel();
		if (adjacentLevel != null)
		{
			onHasPreviousLevelEvent.Invoke(adjacentLevel);
		}
		else
		{
			onHasNoPreviousLevelEvent.Invoke(adjacentLevel);
		}
		if (adjacentLevel2 != null)
		{
			onHasNextLevelEvent.Invoke(adjacentLevel2);
		}
		else
		{
			onHasNoNextLevelEvent.Invoke(adjacentLevel2);
		}
	}
}
