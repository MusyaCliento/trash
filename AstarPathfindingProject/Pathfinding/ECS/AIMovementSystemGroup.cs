using System;
using Pathfinding.Sync;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	[UpdateAfter(typeof(TransformSystemGroup))]
	public class AIMovementSystemGroup : ComponentSystemGroup
	{
		public class TimeScaledRateManager : IRateManager, IDisposable
		{
			private int numUpdatesThisFrame;

			private int updateIndex;

			private float stepDt;

			private float maximumDt = 1f / 30f;

			private NativeList<TimeData> cheapTimeDataQueue;

			private NativeList<TimeData> timeDataQueue;

			private double lastFullSimulation;

			private double lastCheapSimulation;

			private static bool cheapSimulationOnly;

			private static bool isLastSubstep;

			private static bool inGroup;

			private static TimeData cheapTimeData;

			public static bool CheapSimulationOnly
			{
				get
				{
					if (!inGroup)
					{
						throw new InvalidOperationException("Cannot call this method outside of a simulation group using TimeScaledRateManager");
					}
					return cheapSimulationOnly;
				}
			}

			public static float CheapStepDeltaTime
			{
				get
				{
					if (!inGroup)
					{
						throw new InvalidOperationException("Cannot call this method outside of a simulation group using TimeScaledRateManager");
					}
					return cheapTimeData.DeltaTime;
				}
			}

			public static bool IsLastSubstep
			{
				get
				{
					if (!inGroup)
					{
						throw new InvalidOperationException("Cannot call this method outside of a simulation group using TimeScaledRateManager");
					}
					return isLastSubstep;
				}
			}

			public float Timestep
			{
				get
				{
					return maximumDt;
				}
				set
				{
					maximumDt = value;
				}
			}

			public TimeScaledRateManager()
			{
				cheapTimeDataQueue = new NativeList<TimeData>(Allocator.Persistent);
				timeDataQueue = new NativeList<TimeData>(Allocator.Persistent);
			}

			public void Dispose()
			{
				cheapTimeDataQueue.Dispose();
				timeDataQueue.Dispose();
			}

			public bool ShouldGroupUpdate(ComponentSystemGroup group)
			{
				if (inGroup)
				{
					group.World.PopTime();
					updateIndex++;
					if (updateIndex >= numUpdatesThisFrame)
					{
						inGroup = false;
						return false;
					}
				}
				else
				{
					cheapTimeDataQueue.Clear();
					timeDataQueue.Clear();
					if (inGroup)
					{
						throw new InvalidOperationException("Cannot nest simulation groups using TimeScaledRateManager");
					}
					float num = (float)(group.World.Time.ElapsedTime - lastFullSimulation);
					if (num < 0f)
					{
						num = 0f;
					}
					numUpdatesThisFrame = Mathf.FloorToInt(Mathf.Pow(num / maximumDt, 0.8f));
					double elapsedTime = group.World.Time.ElapsedTime;
					cheapSimulationOnly = numUpdatesThisFrame == 0;
					if (cheapSimulationOnly)
					{
						timeDataQueue.Add(new TimeData(lastFullSimulation, 0f));
						cheapTimeDataQueue.Add(new TimeData(elapsedTime, (float)(elapsedTime - lastCheapSimulation)));
						lastCheapSimulation = elapsedTime;
					}
					else
					{
						stepDt = num / (float)numUpdatesThisFrame;
						for (int i = 0; i < numUpdatesThisFrame; i++)
						{
							double num2 = lastFullSimulation + (double)((float)(i + 1) * stepDt);
							timeDataQueue.Add(new TimeData(num2, stepDt));
							cheapTimeDataQueue.Add(new TimeData(num2, (float)(num2 - lastCheapSimulation)));
							lastCheapSimulation = num2;
						}
						lastFullSimulation = elapsedTime;
					}
					numUpdatesThisFrame = Mathf.Max(1, numUpdatesThisFrame);
					inGroup = true;
					updateIndex = 0;
				}
				group.World.PushTime(timeDataQueue[updateIndex]);
				cheapTimeData = cheapTimeDataQueue[updateIndex];
				isLastSubstep = updateIndex + 1 >= numUpdatesThisFrame;
				return true;
			}
		}

		[Preserve]
		protected override void OnUpdate()
		{
			RWLock.ReadLockAsync readLockAsync = ((AstarPath.active != null) ? AstarPath.active.LockGraphDataForReading() : default(RWLock.ReadLockAsync));
			NativeList<SystemHandle> unmanagedSystems = GetUnmanagedSystems();
			WorldUnmanaged unmanaged;
			for (int i = 0; i < unmanagedSystems.Length; i++)
			{
				unmanaged = base.World.Unmanaged;
				ref SystemState reference = ref unmanaged.ResolveSystemStateRef(unmanagedSystems[i]);
				reference.Dependency = JobHandle.CombineDependencies(reference.Dependency, readLockAsync.dependency);
			}
			base.OnUpdate();
			JobHandle jobHandle = default(JobHandle);
			for (int j = 0; j < unmanagedSystems.Length; j++)
			{
				unmanaged = base.World.Unmanaged;
				jobHandle = JobHandle.CombineDependencies(jobHandle, unmanaged.ResolveSystemStateRef(unmanagedSystems[j]).Dependency);
			}
			unmanagedSystems.Dispose();
			readLockAsync.UnlockAfter(jobHandle);
		}

		[Preserve]
		protected override void OnDestroy()
		{
			base.OnDestroy();
			(base.RateManager as TimeScaledRateManager).Dispose();
		}

		[Preserve]
		protected override void OnCreate()
		{
			base.OnCreate();
			base.RateManager = new TimeScaledRateManager();
		}

		[Preserve]
		public AIMovementSystemGroup()
		{
		}
	}
}
