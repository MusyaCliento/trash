namespace Pathfinding.ECS
{
	public struct MovementTarget
	{
		internal bool isReached;

		public bool reached => isReached;

		public MovementTarget(bool isReached)
		{
			this.isReached = isReached;
		}
	}
}
