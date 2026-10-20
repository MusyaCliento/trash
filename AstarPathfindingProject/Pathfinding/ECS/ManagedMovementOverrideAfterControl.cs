namespace Pathfinding.ECS
{
	public class ManagedMovementOverrideAfterControl : ManagedMovementOverride<AfterControlDelegate>
	{
		public object Clone()
		{
			return new ManagedMovementOverrideAfterControl();
		}
	}
}
