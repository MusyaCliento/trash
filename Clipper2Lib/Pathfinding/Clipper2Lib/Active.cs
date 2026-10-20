using System;

namespace Pathfinding.Clipper2Lib
{
	internal class Active : IDisposable
	{
		public Point64 bot;

		public Point64 top;

		public long curX;

		public double dx;

		public int windDx;

		public int windCount;

		public int windCount2;

		public OutRec? outrec;

		public Active? prevInAEL;

		public Active? nextInAEL;

		public Active? prevInSEL;

		public Active? nextInSEL;

		public Active? jump;

		public Vertex? vertexTop;

		public LocalMinima localMin;

		internal bool isLeftBound;

		internal JoinWith joinWith;

		public void Dispose()
		{
			bot = default(Point64);
			top = default(Point64);
			curX = 0L;
			dx = 0.0;
			windDx = 0;
			windCount = 0;
			windCount2 = 0;
			outrec = null;
			prevInAEL = null;
			nextInAEL = null;
			prevInSEL = null;
			nextInSEL = null;
			jump = null;
			vertexTop = null;
			localMin = default(LocalMinima);
			isLeftBound = false;
			joinWith = JoinWith.None;
		}
	}
}
