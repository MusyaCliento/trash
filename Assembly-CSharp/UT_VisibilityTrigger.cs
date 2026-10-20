public class UT_VisibilityTrigger : UT_TriggerBase<UT_TriggerComponent<GameEntity>>
{
	public float visibilityModifier = 1f;

	private void Update()
	{
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			if (triggerObjects[i].other == null)
			{
				triggerObjects.RemoveAt(i--);
			}
			else
			{
				triggerObjects[i].other.AdjustFrameVisibilityCoefficient(visibilityModifier);
			}
		}
	}
}
