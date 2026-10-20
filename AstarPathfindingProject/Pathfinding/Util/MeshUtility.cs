using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding.Util
{
	[BurstCompile]
	internal static class MeshUtility
	{
		[BurstCompile]
		public struct JobRemoveDuplicateVertices : IJob
		{
			public NativeList<Int3> vertices;

			public NativeList<int> triangles;

			public NativeList<int> tags;

			public static int3 cross(int3 x, int3 y)
			{
				return (x * y.yzx - x.yzx * y).yzx;
			}

			public void Execute()
			{
				int num = 0;
				NativeHashMap<Int3, int> nativeHashMap = new NativeHashMap<Int3, int>(vertices.Length, Allocator.Temp);
				NativeArray<int> nativeArray = new NativeArray<int>(vertices.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				UnsafeSpan<int3> unsafeSpan = triangles.AsUnsafeSpan().Reinterpret<int3>(4);
				UnsafeSpan<Int3> unsafeSpan2 = vertices.AsUnsafeSpan();
				UnsafeSpan<int> unsafeSpan3 = tags.AsUnsafeSpan();
				int num2 = 0;
				for (int i = 0; i < unsafeSpan2.length; i++)
				{
					if (nativeHashMap.TryAdd(unsafeSpan2[i], num2))
					{
						nativeArray[i] = num2;
						unsafeSpan2[num2++] = unsafeSpan2[i];
					}
					else
					{
						nativeArray[i] = nativeHashMap[vertices[i]];
					}
				}
				vertices.Length = num2;
				UnsafeSpan<int3> unsafeSpan4 = vertices.AsUnsafeSpan().Reinterpret<int3>();
				uint num3 = 0u;
				for (uint num4 = 0u; num4 < unsafeSpan.length; num4++)
				{
					int3 int5 = unsafeSpan[num4];
					int5 = new int3(nativeArray[int5.x], nativeArray[int5.y], nativeArray[int5.z]);
					if (math.all(cross(unsafeSpan4[int5.y] - unsafeSpan4[int5.x], unsafeSpan4[int5.z] - unsafeSpan4[int5.x]) == 0))
					{
						num++;
						continue;
					}
					unsafeSpan[num3] = int5;
					unsafeSpan3[num3] = unsafeSpan3[num4];
					num3++;
				}
				triangles.Length = (int)(num3 * 3);
				tags.Length = (int)num3;
				if (num > 0)
				{
					Debug.LogWarning($"Input mesh contained {num} degenerate triangles. These have been removed.\nA degenerate triangle is a triangle with zero area. It resembles a line or a point.");
				}
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void MakeTrianglesClockwise_000012F3_0024PostfixBurstDelegate(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles);

		internal static class MakeTrianglesClockwise_000012F3_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<MakeTrianglesClockwise_000012F3_0024PostfixBurstDelegate>(MakeTrianglesClockwise).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<Int3>, ref UnsafeSpan<int>, void>)functionPointer)(ref vertices, ref triangles);
						return;
					}
				}
				MakeTrianglesClockwise_0024BurstManaged(ref vertices, ref triangles);
			}
		}

		public static void GetMeshData(Mesh.MeshDataArray meshData, int meshIndex, out NativeArray<Vector3> vertices, out NativeArray<int> indices)
		{
			Mesh.MeshData meshData2 = meshData[meshIndex];
			vertices = new NativeArray<Vector3>(meshData2.vertexCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			meshData2.GetVertices(vertices);
			int num = 0;
			for (int i = 0; i < meshData2.subMeshCount; i++)
			{
				num += meshData2.GetSubMesh(i).indexCount;
			}
			indices = new NativeArray<int>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			int num2 = 0;
			for (int j = 0; j < meshData2.subMeshCount; j++)
			{
				SubMeshDescriptor subMesh = meshData2.GetSubMesh(j);
				meshData2.GetIndices(indices.GetSubArray(num2, subMesh.indexCount), j);
				num2 += subMesh.indexCount;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pathfinding_002EUtil_002EMakeTrianglesClockwise_000012F3_0024PostfixBurstDelegate))]
		public static void MakeTrianglesClockwise(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
			MakeTrianglesClockwise_000012F3_0024BurstDirectCall.Invoke(ref vertices, ref triangles);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void MakeTrianglesClockwise_0024BurstManaged(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
			for (int i = 0; i < triangles.Length; i += 3)
			{
				if (!VectorMath.IsClockwiseXZ(vertices[triangles[i]], vertices[triangles[i + 1]], vertices[triangles[i + 2]]))
				{
					int num = triangles[i];
					triangles[i] = triangles[i + 2];
					triangles[i + 2] = num;
				}
			}
		}
	}
}
