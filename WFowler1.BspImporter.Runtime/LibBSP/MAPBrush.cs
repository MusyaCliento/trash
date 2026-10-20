using System;
using System.Collections.Generic;

namespace LibBSP
{
	[Serializable]
	public class MAPBrush
	{
		public List<MAPBrushSide> sides = new List<MAPBrushSide>(6);

		public MAPPatch patch;

		public MAPTerrainEF2 ef2Terrain;

		public MAPTerrainMoHAA mohTerrain;

		public bool isDetail;

		public bool isWater;

		public bool isManVis;

		public MAPBrush()
		{
		}

		public MAPBrush(IList<string> lines)
		{
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			List<string> list = new List<string>();
			for (int i = 0; i < lines.Count; i++)
			{
				string text = lines[i];
				if (text[0] == '{')
				{
					num++;
					if (num == 1 || flag)
					{
						continue;
					}
				}
				else if (text[0] == '}')
				{
					num--;
					if (num == 0 || flag)
					{
						continue;
					}
				}
				if (num == 1 || flag)
				{
					if (text.Length < "side".Length || !(text.Substring(0, "side".Length) == "side"))
					{
						if (text.Length >= "patch".Length && text.Substring(0, "patch".Length) == "patch")
						{
							flag2 = true;
							list.Add(text);
						}
						else if (flag2)
						{
							list.Add(text);
							flag2 = false;
							patch = new MAPPatch(list.ToArray());
							list = new List<string>();
						}
						else if (text.Length >= "terrainDef".Length && text.Substring(0, "terrainDef".Length) == "terrainDef")
						{
							flag3 = true;
							list.Add(text);
						}
						else if (flag3)
						{
							list.Add(text);
							flag3 = false;
							ef2Terrain = new MAPTerrainEF2(list.ToArray());
							list = new List<string>();
						}
						else if (text.Length >= "brushDef3".Length && text.Substring(0, "brushDef3".Length) == "brushDef3")
						{
							flag = true;
						}
						else if (text == "\"BRUSHFLAGS\" \"DETAIL\"")
						{
							isDetail = true;
						}
						else if (text.Length < "\"id\"".Length || !(text.Substring(0, "\"id\"".Length) == "\"id\""))
						{
							list.Add(text);
							sides.Add(new MAPBrushSide(list.ToArray()));
							list = new List<string>();
						}
					}
				}
				else if (num > 1)
				{
					list.Add(text);
				}
			}
		}
	}
}
