using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	internal struct VertexPool
	{
		private Stack<Vertex> stack;

		public VertexPool(int capacity)
		{
			stack = new Stack<Vertex>(capacity);
		}

		public Vertex GetNew(Point64 pt, VertexFlags flags, Vertex? prev)
		{
			if (stack.Count > 0)
			{
				Vertex vertex = stack.Pop();
				vertex.pt = pt;
				vertex.next = null;
				vertex.prev = prev;
				vertex.flags = flags;
				return vertex;
			}
			return new Vertex(pt, flags, prev);
		}

		public void Pool(Vertex v)
		{
			v.prev = null;
			v.next = null;
			stack.Push(v);
		}
	}
}
