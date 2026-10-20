using System;
using Unity.Entities;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	public class ManagedMovementOverride<T> : IComponentData, IQueryTypeParameter where T : class, Delegate
	{
		public T callback;

		public void AddCallback(T callback)
		{
			this.callback = (T)Delegate.Combine(this.callback, callback);
		}

		public bool RemoveCallback(T callback)
		{
			return (this.callback = (T)Delegate.Remove(this.callback, callback)) != null;
		}

		[Preserve]
		public ManagedMovementOverride()
		{
		}
	}
}
