using System;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator
{
	public class Triangulator : IDisposable
	{
		private readonly Triangulator<double2> impl;

		public TriangulationSettings Settings => impl.Settings;

		public InputData<double2> Input
		{
			get
			{
				return impl.Input;
			}
			set
			{
				impl.Input = value;
			}
		}

		public OutputData<double2> Output => impl.Output;

		public Triangulator(int capacity, Allocator allocator)
		{
			impl = new Triangulator<double2>(capacity, allocator);
		}

		public Triangulator(Allocator allocator)
		{
			impl = new Triangulator<double2>(allocator);
		}

		public void Dispose()
		{
			impl.Dispose();
		}

		public void Run()
		{
			impl.Run();
		}

		public JobHandle Schedule(JobHandle dependencies = default(JobHandle))
		{
			return impl.Schedule(dependencies);
		}
	}
	public class Triangulator<T2> : IDisposable where T2 : unmanaged
	{
		internal NativeList<T2> outputPositions;

		internal NativeList<int> triangles;

		internal NativeList<int> halfedges;

		internal NativeList<HalfedgeState> constrainedHalfedges;

		internal NativeReference<Status> status;

		public TriangulationSettings Settings { get; } = new TriangulationSettings();

		public InputData<T2> Input { get; set; } = new InputData<T2>();

		public OutputData<T2> Output { get; }

		public Triangulator(int capacity, Allocator allocator)
		{
			outputPositions = new NativeList<T2>(capacity, allocator);
			triangles = new NativeList<int>(6 * capacity, allocator);
			status = new NativeReference<Status>(Status.Ok, allocator);
			halfedges = new NativeList<int>(6 * capacity, allocator);
			constrainedHalfedges = new NativeList<HalfedgeState>(6 * capacity, allocator);
			Output = new OutputData<T2>(this);
		}

		public Triangulator(Allocator allocator)
			: this(16384, allocator)
		{
		}

		public void Dispose()
		{
			outputPositions.Dispose();
			triangles.Dispose();
			status.Dispose();
			halfedges.Dispose();
			constrainedHalfedges.Dispose();
		}
	}
}
