using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Unity.Burst;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct DrawGizmosJobUtils
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void DrawPath_00000E21_0024PostfixBurstDelegate(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape);

		internal static class DrawPath_00000E21_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<DrawPath_00000E21_0024PostfixBurstDelegate>(DrawPath).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref CommandBuilder, ref UnsafeSpan<float3>, ref AgentCylinderShape, void>)functionPointer)(ref draw, ref vertices, ref shape);
						return;
					}
				}
				DrawPath_0024BurstManaged(ref draw, ref vertices, ref shape);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Pathfinding_002EECS_002EDrawPath_00000E21_0024PostfixBurstDelegate))]
		internal static void DrawPath(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
		{
			DrawPath_00000E21_0024BurstDirectCall.Invoke(ref draw, ref vertices, ref shape);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void DrawPath_0024BurstManaged(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
		{
			draw.PushColor(Palette.Colorbrewer.Set1.Orange);
			if (shape.radius > 0.01f)
			{
				CommandBuilder.PolylineWithSymbol polylineWithSymbol = new CommandBuilder.PolylineWithSymbol(CommandBuilder.SymbolDecoration.ArrowHead, shape.radius * 0.5f, shape.radius * 0f, shape.radius * 4f, reverseSymbols: true);
				for (int num = vertices.Length - 1; num >= 0; num--)
				{
					polylineWithSymbol.MoveTo(ref draw, vertices[num]);
				}
			}
			else
			{
				for (int i = 0; i < vertices.Length - 1; i++)
				{
					draw.Line(vertices[i], vertices[i + 1]);
				}
			}
			draw.PopColor();
		}
	}
}
