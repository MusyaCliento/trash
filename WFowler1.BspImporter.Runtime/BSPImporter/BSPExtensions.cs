using System.Collections.Generic;
using LibBSP;

namespace BSPImporter
{
	public static class BSPExtensions
	{
		public static List<Leaf> GetLeavesInModel(this BSP bsp, Model model)
		{
			List<Leaf> list = null;
			if (model.FirstLeafIndex < 0)
			{
				if (model.HeadNodeIndex >= 0)
				{
					list = bsp.GetLeavesInNode(bsp.Nodes[model.HeadNodeIndex]);
				}
			}
			else
			{
				list = new List<Leaf>(model.NumLeaves);
				for (int i = 0; i < model.NumLeaves; i++)
				{
					list.Add(bsp.Leaves[model.FirstLeafIndex + i]);
				}
			}
			return list;
		}

		public static List<Leaf> GetLeavesInNode(this BSP bsp, Node node)
		{
			List<Leaf> list = new List<Leaf>();
			Stack<Node> stack = new Stack<Node>();
			stack.Push(node);
			while (stack.Count != 0)
			{
				Node node2 = stack.Pop();
				int child2Index = node2.Child2Index;
				if (child2Index >= 0)
				{
					stack.Push(bsp.Nodes[child2Index]);
				}
				else
				{
					list.Add(bsp.Leaves[child2Index * -1 - 1]);
				}
				int child1Index = node2.Child1Index;
				if (child1Index >= 0)
				{
					stack.Push(bsp.Nodes[child1Index]);
				}
				else
				{
					list.Add(bsp.Leaves[child1Index * -1 - 1]);
				}
			}
			return list;
		}

		public static List<Face> GetFacesInModel(this BSP bsp, Model model)
		{
			List<Face> list = null;
			if (model.FirstFaceIndex >= 0)
			{
				if (list == null)
				{
					list = new List<Face>();
				}
				for (int i = 0; i < model.NumFaces; i++)
				{
					list.Add(bsp.Faces[model.FirstFaceIndex + i]);
				}
			}
			else
			{
				bool[] array = new bool[bsp.Faces.Count];
				foreach (Leaf item in bsp.GetLeavesInModel(model))
				{
					if (item.FirstMarkFaceIndex < 0)
					{
						continue;
					}
					if (list == null)
					{
						list = new List<Face>();
					}
					for (int j = 0; j < item.NumMarkFaceIndices; j++)
					{
						int num = (int)bsp.LeafFaces[item.FirstMarkFaceIndex + j];
						if (!array[num])
						{
							array[num] = true;
							list.Add(bsp.Faces[num]);
						}
					}
				}
			}
			return list;
		}

		public static int FindTexDataWithTexture(this BSP bsp, string texture)
		{
			for (int i = 0; i < bsp.TextureData.Count; i++)
			{
				if (bsp.Textures.GetTextureAtOffset((uint)bsp.TextureTable[bsp.TextureData[i].TextureStringOffsetIndex]).Equals(texture))
				{
					return i;
				}
			}
			return -1;
		}

		public static int GetTextureIndex(this BSP bspObject, Face face)
		{
			if (face.TextureIndex >= 0)
			{
				return face.TextureIndex;
			}
			if (face.TextureInfoIndex >= 0)
			{
				if (bspObject.TextureData != null)
				{
					return bspObject.TextureData[bspObject.TextureInfo[face.TextureInfoIndex].TextureIndex].TextureStringOffsetIndex;
				}
				return bspObject.TextureInfo[face.TextureInfoIndex].TextureIndex;
			}
			return -1;
		}

		public static TextureInfo GetTextureInfo(this BSP bsp, Face face)
		{
			if (face.TextureIndex >= 0 && bsp.Textures[face.TextureIndex].TextureInfo.Data != null && bsp.Textures[face.TextureIndex].TextureInfo.Data.Length != 0)
			{
				return bsp.Textures[face.TextureIndex].TextureInfo;
			}
			if (face.TextureInfoIndex >= 0)
			{
				return bsp.TextureInfo[face.TextureInfoIndex];
			}
			return default(TextureInfo);
		}
	}
}
