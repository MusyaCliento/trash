using System;
using System.Collections.Generic;

[Serializable]
public class SlotSystem
{
	public class Slot
	{
		public string id;

		public bool filled;

		public string data;
	}

	public int width = 4;

	public int height = 4;

	public Slot[,] slots;

	public void Initialize()
	{
		slots = new Slot[width, height];
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				slots[i, j] = new Slot();
			}
		}
	}

	public bool HasEmptySlots(int xSlot, int ySlot, int getWidth, int getHeight)
	{
		if (xSlot + getWidth >= width || ySlot + getHeight >= height)
		{
			return false;
		}
		foreach (Slot slot in GetSlots(xSlot, ySlot, getWidth, getHeight))
		{
			if (slot.filled)
			{
				return false;
			}
		}
		return true;
	}

	public List<Slot> GetSlots(int xSlot, int ySlot, int getWidth, int getHeight)
	{
		List<Slot> list = new List<Slot>();
		for (int i = 0; i < getWidth; i++)
		{
			int num = i + xSlot;
			if (num >= width)
			{
				continue;
			}
			for (int j = 0; j < getHeight; j++)
			{
				int num2 = j + ySlot;
				if (num2 < height)
				{
					list.Add(slots[num, num2]);
				}
			}
		}
		return list;
	}

	public bool TryFindFreeRect(int rectW, int rectH, out int foundX, out int foundY)
	{
		int length = slots.GetLength(0);
		for (int num = slots.GetLength(1) - rectH; num >= 0; num--)
		{
			for (int i = 0; i <= length - rectW; i++)
			{
				if (IsRectFree(slots, i, num, rectW, rectH))
				{
					foundX = i;
					foundY = num;
					return true;
				}
			}
		}
		foundX = (foundY = -1);
		return false;
	}

	private static bool IsRectFree(Slot[,] grid, int startX, int startY, int w, int h)
	{
		for (int i = 0; i < h; i++)
		{
			for (int j = 0; j < w; j++)
			{
				if (grid[startX + j, startY + i].filled)
				{
					return false;
				}
			}
		}
		return true;
	}
}
