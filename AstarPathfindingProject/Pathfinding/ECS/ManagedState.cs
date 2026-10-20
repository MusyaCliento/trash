using System;
using Pathfinding.ECS.RVO;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace Pathfinding.ECS
{
	[Serializable]
	public class ManagedState : IComponentData, IQueryTypeParameter, IDisposable, ICloneable
	{
		public PathTracer pathTracer;

		[FormerlySerializedAs("rvoAgent")]
		public RVOAgent rvoSettings = RVOAgent.Default;

		[NonSerialized]
		public IOffMeshLinkHandler onTraverseOffMeshLink;

		public PathRequestSettings pathfindingSettings = PathRequestSettings.Default;

		[FormerlySerializedAs("rvoEnabled")]
		public bool enableLocalAvoidance;

		public bool enableGravity = true;

		[Obsolete("Use FollowerEntity.autoRepath, or the Pathfinding.ECS.AutoRepathPolicy component instead", true)]
		public Pathfinding.AutoRepathPolicy autoRepath => null;

		public Path pendingPath { get; private set; }

		public Path activePath { get; private set; }

		public static void SetPath(Path path, ManagedState state, in AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
			if (path == null)
			{
				state.CancelCurrentPathRequest();
				state.ClearPath();
				return;
			}
			if (path.PipelineState == PathState.Created)
			{
				state.CancelCurrentPathRequest();
				state.pendingPath = path;
				path.Claim(state);
				AstarPath.StartPath(path);
				return;
			}
			if (path.PipelineState >= PathState.ReturnQueue)
			{
				if (state.pendingPath == path)
				{
					state.pendingPath = null;
				}
				else
				{
					state.CancelCurrentPathRequest();
					path.Claim(state);
				}
				if (!(path is ABPath aBPath))
				{
					throw new ArgumentException("This function only works with ABPaths, or paths inheriting from ABPath");
				}
				if (!aBPath.error)
				{
					try
					{
						state.pathTracer.SetPath(aBPath, movementPlane.value);
						if (state.activePath != null)
						{
							state.activePath.Release(state);
						}
						state.activePath = aBPath;
					}
					catch (Exception exception)
					{
						aBPath.Release(state);
						state.ClearPath();
						Debug.LogException(exception);
					}
					if (!aBPath.endPointKnownBeforeCalculation)
					{
						destination = new DestinationPoint
						{
							destination = aBPath.originalEndPoint,
							facingDirection = default(float3)
						};
					}
				}
				else
				{
					aBPath.Release(state);
				}
				return;
			}
			throw new ArgumentException("You must call the SetPath method with a path that either has been completely calculated or one whose path calculation has not been started at all. It looks like the path calculation for the path you tried to use has been started, but is not yet finished.");
		}

		public void ClearPath()
		{
			pathTracer.Clear();
			if (activePath != null)
			{
				activePath.Release(this);
				activePath = null;
			}
		}

		public void CancelCurrentPathRequest()
		{
			if (pendingPath != null)
			{
				pendingPath.FailWithError("Canceled by script");
				pendingPath.Release(this);
				pendingPath = null;
			}
		}

		public void Dispose()
		{
			pathTracer.Dispose();
			if (pendingPath != null)
			{
				pendingPath.FailWithError("Canceled because entity was destroyed");
				pendingPath.Release(this);
				pendingPath = null;
			}
			if (activePath != null)
			{
				activePath.Release(this);
				activePath = null;
			}
		}

		public void PopNextLinkFromPath()
		{
			if (pathTracer.partCount < 2 && pathTracer.GetPartType(1) != Funnel.PartType.OffMeshLink)
			{
				throw new InvalidOperationException("The next part in the path is not an off-mesh link.");
			}
			pathTracer.PopParts(2, pathfindingSettings.traversalProvider, activePath);
		}

		object ICloneable.Clone()
		{
			return new ManagedState
			{
				pathTracer = pathTracer.Clone(),
				rvoSettings = rvoSettings,
				pathfindingSettings = new PathRequestSettings
				{
					graphMask = pathfindingSettings.graphMask,
					tagPenalties = ((pathfindingSettings.tagPenalties != null) ? ((int[])pathfindingSettings.tagPenalties.Clone()) : null),
					traversableTags = pathfindingSettings.traversableTags,
					traversalProvider = null
				},
				enableLocalAvoidance = enableLocalAvoidance,
				enableGravity = enableGravity,
				onTraverseOffMeshLink = null,
				pendingPath = null,
				activePath = null
			};
		}

		[Preserve]
		public ManagedState()
		{
		}
	}
}
