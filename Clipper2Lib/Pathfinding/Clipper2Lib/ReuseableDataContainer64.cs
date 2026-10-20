using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	public class ReuseableDataContainer64
	{
		internal readonly List<LocalMinima> _minimaList;

		internal readonly List<Vertex> _vertexList;

		internal readonly VertexPool _vertexPool;

		public ReuseableDataContainer64()
		{
			_minimaList = new List<LocalMinima>();
			_vertexList = new List<Vertex>();
			_vertexPool = default(VertexPool);
		}

		public void Clear()
		{
			foreach (Vertex vertex in _vertexList)
			{
				_vertexPool.Pool(vertex);
			}
			_minimaList.Clear();
			_vertexList.Clear();
		}

		public void AddPaths(List<List<Point64>> paths, PathType pt, bool isOpen)
		{
			ClipperEngine.AddPathsToVertexList(paths, pt, isOpen, _minimaList, _vertexList, _vertexPool);
		}
	}
}
