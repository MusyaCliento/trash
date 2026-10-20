using System;
using System.Collections.Generic;
using UnityEngine;

public class FX_BeamSystem : MonoBehaviour
{
	[Serializable]
	public struct TaskSurfaces
	{
		public string tag;

		public List<FX_BeamSurface> surfaces;
	}

	[HideInInspector]
	public FX_BeamManager.System system;

	public int maxBeams = 16;

	public List<FX_BeamManager.SystemTask> tasks;

	public List<TaskSurfaces> taggedSurfaces = new List<TaskSurfaces>();

	private void OnEnable()
	{
		CreateSystem();
	}

	private void OnDisable()
	{
		FX_BeamManager.SystemDestroy(system);
	}

	public void Refresh()
	{
		CreateSystem();
	}

	public void SetEmissionRate(float rate)
	{
		tasks[0].emissionRate = rate;
	}

	public void SetTaskActive(int id, bool active)
	{
		tasks[id].active = active;
	}

	public void SetAllTasksActive(bool active)
	{
		foreach (FX_BeamManager.SystemTask task in tasks)
		{
			task.active = active;
		}
	}

	private void CreateSystem()
	{
		FX_BeamManager.SystemDestroy(system);
		system = FX_BeamManager.SystemCreate(maxBeams, base.transform);
		for (int i = 0; i < tasks.Count; i++)
		{
			FX_BeamManager.SystemTaskAdd(system, tasks[i]);
		}
		for (int j = 0; j < taggedSurfaces.Count; j++)
		{
			List<FX_BeamSurface> surfaces = taggedSurfaces[j].surfaces;
			List<FX_BeamManager.Surface> list = new List<FX_BeamManager.Surface>(surfaces.Count);
			for (int k = 0; k < surfaces.Count; k++)
			{
				FX_BeamSurface fX_BeamSurface = surfaces[k];
				if (!FX_BeamManager.SurfaceExists(fX_BeamSurface.surface))
				{
					fX_BeamSurface.surface = FX_BeamManager.SurfaceCreate(system);
					fX_BeamSurface.Refresh();
				}
				list.Add(fX_BeamSurface.surface);
			}
			FX_BeamManager.SystemSurfaceTagsAdd(system, taggedSurfaces[j].tag, list);
		}
	}

	public void PrintHits(FX_BeamManager.BeamHit hit)
	{
		Debug.Log($"Ray hit target: {hit.ray.collider}");
	}
}
