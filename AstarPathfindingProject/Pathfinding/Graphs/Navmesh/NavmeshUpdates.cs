using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Sync;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[Serializable]
	public class NavmeshUpdates
	{
		public class NavmeshUpdateSettings : IDisposable
		{
			internal readonly NavmeshBase graph;

			public GridLookup<NavmeshClipper> clipperLookup;

			public TileLayout tileLayout;

			private UnsafeBitArray dirtyTiles;

			private List<Vector2Int> dirtyTileCoordinates = new List<Vector2Int>();

			public bool attachedToGraph { get; private set; }

			public bool enabled => clipperLookup != null;

			public bool anyTilesDirty => dirtyTileCoordinates.Count > 0;

			private void AssertEnabled()
			{
				if (!enabled)
				{
					throw new InvalidOperationException("This method cannot be called when the NavmeshUpdateSettings is disabled");
				}
			}

			public NavmeshUpdateSettings(NavmeshBase graph)
			{
				this.graph = graph;
				dirtyTiles = new UnsafeBitArray(0, Allocator.Persistent);
			}

			public NavmeshUpdateSettings(NavmeshBase graph, TileLayout tileLayout)
			{
				this.graph = graph;
				if (graph.enableNavmeshCutting)
				{
					SetLayout(tileLayout);
				}
			}

			public void UpdateLayoutFromGraph()
			{
				if (enabled)
				{
					ForceUpdateLayoutFromGraph();
				}
			}

			private void ForceUpdateLayoutFromGraph()
			{
				if (graph is NavMeshGraph navMeshGraph)
				{
					SetLayout(new TileLayout(navMeshGraph));
				}
				else if (graph is RecastGraph recastGraph)
				{
					SetLayout(new TileLayout(recastGraph));
				}
			}

			private void SetLayout(TileLayout tileLayout)
			{
				Dispose();
				this.tileLayout = tileLayout;
				clipperLookup = new GridLookup<NavmeshClipper>(tileLayout.tileCount);
				dirtyTiles = new UnsafeBitArray(tileLayout.tileCount.x * tileLayout.tileCount.y, Allocator.Persistent);
				graph.active.navmeshUpdates.AddListener(this);
			}

			internal void MarkTilesDirty(IntRect rect)
			{
				if (!enabled)
				{
					return;
				}
				rect = IntRect.Intersection(rect, new IntRect(0, 0, tileLayout.tileCount.x - 1, tileLayout.tileCount.y - 1));
				for (int i = rect.ymin; i <= rect.ymax; i++)
				{
					for (int j = rect.xmin; j <= rect.xmax; j++)
					{
						int pos = j + i * tileLayout.tileCount.x;
						if (!dirtyTiles.IsSet(pos))
						{
							dirtyTiles.Set(pos, value: true);
							dirtyTileCoordinates.Add(new Vector2Int(j, i));
						}
					}
				}
			}

			public void ReloadAllTiles()
			{
				if (enabled)
				{
					MarkTilesDirty(new IntRect(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue));
					ScheduleDirtyTilesReload();
				}
			}

			public void AttachToGraph()
			{
				if (graph.navmeshUpdateData != null)
				{
					graph.navmeshUpdateData.Dispose();
					graph.navmeshUpdateData.attachedToGraph = false;
				}
				graph.navmeshUpdateData = this;
				attachedToGraph = true;
			}

			public void Enable()
			{
				if (enabled)
				{
					throw new InvalidOperationException("Already enabled");
				}
				ForceUpdateLayoutFromGraph();
				ReloadAllTiles();
			}

			public void Disable()
			{
				if (enabled)
				{
					clipperLookup.Clear();
					ReloadAllTiles();
					graph.active.FlushWorkItems();
					Dispose();
				}
			}

			public void Dispose()
			{
				clipperLookup = null;
				if (dirtyTiles.IsCreated)
				{
					dirtyTiles.Dispose();
				}
				dirtyTiles = default(UnsafeBitArray);
				if (graph.active != null)
				{
					graph.active.navmeshUpdates.RemoveListener(this);
				}
			}

			public void DiscardPending()
			{
				if (!enabled)
				{
					return;
				}
				for (int i = 0; i < NavmeshClipper.allEnabled.Count; i++)
				{
					NavmeshClipper navmeshClipper = NavmeshClipper.allEnabled[i];
					GridLookup<NavmeshClipper>.Root root = clipperLookup.GetRoot(navmeshClipper);
					if (root != null)
					{
						navmeshClipper.NotifyUpdated(root);
					}
				}
				dirtyTileCoordinates.Clear();
				dirtyTiles.Clear();
			}

			public void OnResized(IntRect newTileBounds, TileLayout tileLayout)
			{
				if (!enabled)
				{
					return;
				}
				clipperLookup.Resize(newTileBounds);
				this.tileLayout = tileLayout;
				float navmeshCuttingCharacterRadius = graph.NavmeshCuttingCharacterRadius;
				for (GridLookup<NavmeshClipper>.Root root = clipperLookup.AllItems; root != null; root = root.next)
				{
					Rect bounds = root.obj.GetBounds(tileLayout.transform, navmeshCuttingCharacterRadius);
					IntRect touchingTilesInGraphSpace = tileLayout.GetTouchingTilesInGraphSpace(bounds);
					if (root.previousBounds != touchingTilesInGraphSpace)
					{
						clipperLookup.Dirty(root.obj);
						clipperLookup.Move(root.obj, touchingTilesInGraphSpace);
					}
				}
				for (int i = 0; i < dirtyTileCoordinates.Count; i++)
				{
					Vector2Int vector2Int = dirtyTileCoordinates[i];
					if (newTileBounds.Contains(vector2Int.x, vector2Int.y))
					{
						dirtyTileCoordinates[i] = new Vector2Int(vector2Int.x - newTileBounds.xmin, vector2Int.y - newTileBounds.ymin);
						continue;
					}
					dirtyTileCoordinates.RemoveAtSwapBack(i);
					i--;
				}
				dirtyTiles.Resize(newTileBounds.Width * newTileBounds.Height);
				dirtyTiles.Clear();
				for (int j = 0; j < dirtyTileCoordinates.Count; j++)
				{
					dirtyTiles.Set(dirtyTileCoordinates[j].x + dirtyTileCoordinates[j].y * newTileBounds.Width, value: true);
				}
			}

			public void Dirty(NavmeshClipper obj)
			{
				if (enabled)
				{
					clipperLookup.Dirty(obj);
				}
			}

			public void AddClipper(NavmeshClipper obj)
			{
				AssertEnabled();
				if (obj.graphMask.Contains((int)graph.graphIndex))
				{
					float navmeshCuttingCharacterRadius = graph.NavmeshCuttingCharacterRadius;
					Rect bounds = obj.GetBounds(tileLayout.transform, navmeshCuttingCharacterRadius);
					IntRect touchingTilesInGraphSpace = tileLayout.GetTouchingTilesInGraphSpace(bounds);
					clipperLookup.Add(obj, touchingTilesInGraphSpace);
				}
			}

			public void RemoveClipper(NavmeshClipper obj)
			{
				AssertEnabled();
				GridLookup<NavmeshClipper>.Root root = clipperLookup.GetRoot(obj);
				if (root != null)
				{
					MarkTilesDirty(root.previousBounds);
					clipperLookup.Remove(obj);
				}
			}

			public void ScheduleDirtyTilesReload()
			{
				AssertEnabled();
				if (dirtyTileCoordinates.Count != 0)
				{
					_ = tileLayout;
					graph.active.AddWorkItem(delegate(IWorkItemContext ctx)
					{
						ctx.PreUpdate();
						ReloadDirtyTilesImmediately();
					});
				}
			}

			public void ReloadDirtyTilesImmediately()
			{
				if (!enabled || dirtyTileCoordinates.Count == 0)
				{
					return;
				}
				Promise<TileCutter.TileCutterOutput> promise = RecastBuilder.CutTiles(graph, clipperLookup, tileLayout).Schedule(dirtyTileCoordinates);
				promise.Complete();
				TileCutter.TileCutterOutput value = promise.GetValue();
				graph.StartBatchTileUpdate();
				if (!value.tileMeshes.tileMeshes.IsCreated)
				{
					for (int i = 0; i < dirtyTileCoordinates.Count; i++)
					{
						NavmeshTile tile = graph.GetTile(dirtyTileCoordinates[i].x, dirtyTileCoordinates[i].y);
						if (tile.isCut)
						{
							graph.ReplaceTilePostCut(tile.x, tile.z, tile.preCutVertsInTileSpace, tile.preCutTris, tile.preCutTags, tryPreserveExistingTagsAndPenalties: true, preservePreCutData: true);
						}
					}
				}
				else
				{
					for (int j = 0; j < value.tileMeshes.tileMeshes.Length; j++)
					{
						TileMesh.TileMeshUnsafe tileMeshUnsafe = value.tileMeshes.tileMeshes[j];
						graph.ReplaceTilePostCut(dirtyTileCoordinates[j].x, dirtyTileCoordinates[j].y, tileMeshUnsafe.verticesInTileSpace, tileMeshUnsafe.triangles, tileMeshUnsafe.tags, tryPreserveExistingTagsAndPenalties: true, preservePreCutData: true);
					}
				}
				value.Dispose();
				graph.EndBatchTileUpdate();
				dirtyTileCoordinates.Clear();
				dirtyTiles.Clear();
			}
		}

		public float updateInterval;

		internal AstarPath astar;

		private List<NavmeshUpdateSettings> listeners = new List<NavmeshUpdateSettings>();

		private float lastUpdateTime = float.NegativeInfinity;

		internal void OnEnable()
		{
			lastUpdateTime = float.NegativeInfinity;
			NavmeshClipper.RefreshEnabledList();
			NavmeshClipper.AddEnableCallback(HandleOnEnableCallback, HandleOnDisableCallback);
		}

		internal void OnDisable()
		{
			NavmeshClipper.RemoveEnableCallback(HandleOnEnableCallback, HandleOnDisableCallback);
		}

		public void ForceUpdateAround(NavmeshClipper clipper)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].Dirty(clipper);
			}
		}

		public void DiscardPending()
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].DiscardPending();
			}
		}

		private void HandleOnEnableCallback(NavmeshClipper obj)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].AddClipper(obj);
			}
		}

		private void HandleOnDisableCallback(NavmeshClipper obj)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].RemoveClipper(obj);
			}
			lastUpdateTime = float.NegativeInfinity;
		}

		private void AddListener(NavmeshUpdateSettings listener)
		{
			listeners.Add(listener);
			for (int i = 0; i < NavmeshClipper.allEnabled.Count; i++)
			{
				listener.AddClipper(NavmeshClipper.allEnabled[i]);
			}
		}

		private void RemoveListener(NavmeshUpdateSettings listener)
		{
			listeners.Remove(listener);
		}

		internal void Update()
		{
			if (!astar.isScanning)
			{
				bool flag = false;
				RefreshEnabledState();
				for (int i = 0; i < listeners.Count; i++)
				{
					flag |= listeners[i].anyTilesDirty;
				}
				if ((updateInterval >= 0f && Time.realtimeSinceStartup - lastUpdateTime > updateInterval) || flag)
				{
					ScheduleTileUpdates();
				}
			}
		}

		public void ForceUpdate()
		{
			RefreshEnabledState();
			ScheduleTileUpdates();
		}

		private void RefreshEnabledState()
		{
			NavGraph[] graphs = astar.graphs;
			for (int i = 0; i < graphs.Length; i++)
			{
				if (!(graphs[i] is NavmeshBase navmeshBase))
				{
					continue;
				}
				bool flag = navmeshBase.enableNavmeshCutting && navmeshBase.isScanned;
				if (navmeshBase.navmeshUpdateData.enabled != flag)
				{
					if (flag)
					{
						navmeshBase.navmeshUpdateData.Enable();
					}
					else
					{
						navmeshBase.navmeshUpdateData.Disable();
					}
				}
			}
		}

		private void ScheduleTileUpdates()
		{
			lastUpdateTime = Time.realtimeSinceStartup;
			foreach (NavmeshUpdateSettings listener in listeners)
			{
				if (!listener.attachedToGraph)
				{
					continue;
				}
				GridLookup<NavmeshClipper>.Root allItems = listener.clipperLookup.AllItems;
				if (!listener.anyTilesDirty)
				{
					bool flag = false;
					for (GridLookup<NavmeshClipper>.Root root = allItems; root != null; root = root.next)
					{
						if (root.obj.RequiresUpdate(root))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				float navmeshCuttingCharacterRadius = listener.graph.NavmeshCuttingCharacterRadius;
				for (GridLookup<NavmeshClipper>.Root root2 = allItems; root2 != null; root2 = root2.next)
				{
					if (root2.obj.RequiresUpdate(root2))
					{
						listener.MarkTilesDirty(root2.previousBounds);
						Rect bounds = root2.obj.GetBounds(listener.tileLayout.transform, navmeshCuttingCharacterRadius);
						IntRect touchingTilesInGraphSpace = listener.tileLayout.GetTouchingTilesInGraphSpace(bounds);
						listener.clipperLookup.Move(root2.obj, touchingTilesInGraphSpace);
						listener.MarkTilesDirty(touchingTilesInGraphSpace);
						root2.obj.NotifyUpdated(root2);
					}
				}
				listener.ScheduleDirtyTilesReload();
			}
		}
	}
}
