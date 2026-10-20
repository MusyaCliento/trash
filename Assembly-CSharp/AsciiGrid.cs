using System.Text;
using TMPro;
using UnityEngine;

public class AsciiGrid : MonoBehaviour
{
	[Header("Grid Dimensions")]
	public int width = 40;

	public int height = 20;

	[Header("TextMeshPro Settings")]
	public TextMeshProUGUI asciiText;

	public float fontSize = 16f;

	public float lineSpacing = 1f;

	public float characterSpacing;

	private char[,] grid;

	private void Awake()
	{
		width = Mathf.Max(1, width);
		height = Mathf.Max(1, height);
		grid = new char[height, width];
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				grid[i, j] = ' ';
			}
		}
		if (asciiText != null)
		{
			asciiText.enableWordWrapping = false;
			asciiText.fontSize = fontSize;
			asciiText.lineSpacing = lineSpacing;
			asciiText.characterSpacing = characterSpacing;
		}
		RebuildText();
	}

	public void SetChar(int x, int y, char c)
	{
		if (x >= 0 && x < width && y >= 0 && y < height)
		{
			grid[y, x] = c;
			RebuildText();
		}
	}

	public void AddString(int startX, int startY, string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		int num = startX;
		for (int i = 0; i < text.Length; i++)
		{
			if (num < 0)
			{
				break;
			}
			if (num >= width)
			{
				break;
			}
			if (startY < 0)
			{
				break;
			}
			if (startY >= height)
			{
				break;
			}
			grid[startY, num] = text[i];
			num++;
		}
		RebuildText();
	}

	public void FillRect(int x1, int y1, int x2, int y2, char c)
	{
		int num = Mathf.Min(x1, x2);
		int num2 = Mathf.Max(x1, x2);
		int num3 = Mathf.Min(y1, y2);
		int num4 = Mathf.Max(y1, y2);
		for (int i = num3; i <= num4; i++)
		{
			for (int j = num; j <= num2; j++)
			{
				if (j >= 0 && j < width && i >= 0 && i < height)
				{
					grid[i, j] = c;
				}
			}
		}
		RebuildText();
	}

	private void RebuildText()
	{
		if (asciiText == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder(height * (width + 1));
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				stringBuilder.Append(grid[i, j]);
			}
			if (i < height - 1)
			{
				stringBuilder.AppendLine();
			}
		}
		asciiText.text = stringBuilder.ToString();
	}
}
