using System;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using andywiecko.BurstTriangulator.LowLevel.Unsafe;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__7274761993000005315
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<TriangulationJob<float, float2, float, TransformFloat, FloatUtils>>();
			IJobExtensions.EarlyJobInit<TriangulationJob<double, double2, double, TransformDouble, DoubleUtils>>();
			IJobExtensions.EarlyJobInit<TriangulationJob<int, int2, long, TransformInt, IntUtils>>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
