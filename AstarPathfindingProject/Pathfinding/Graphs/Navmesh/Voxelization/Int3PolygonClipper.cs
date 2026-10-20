using Pathfinding.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization
{
	internal struct Int3PolygonClipper
	{
		private unsafe fixed float clipPolygonCache[21];

		public unsafe int ClipPolygon(UnsafeSpan<Int3> vIn, int n, UnsafeSpan<Int3> vOut, int multi, int offset, int axis)
		{
			for (int i = 0; i < n; i++)
			{
				clipPolygonCache[i] = multi * vIn[i][axis] + offset;
			}
			int num = 0;
			int j = 0;
			int num2 = n - 1;
			for (; j < n; j++)
			{
				bool num3 = clipPolygonCache[num2] >= 0f;
				bool flag = clipPolygonCache[j] >= 0f;
				if (num3 != flag)
				{
					double num4 = (double)clipPolygonCache[num2] / (double)(clipPolygonCache[num2] - clipPolygonCache[j]);
					vOut[num] = vIn[num2] + (vIn[j] - vIn[num2]) * num4;
					num++;
				}
				if (flag)
				{
					vOut[num] = vIn[j];
					num++;
				}
				num2 = j;
			}
			return num;
		}
	}
}
