using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
	public static int height = 10;
	public static int width = 6;
	[SerializeField] GameObject cellPrefab;

	private static Cell[,] cells;

	void Start()
	{
		cells = new Cell[width, height];
	}

	public static bool IsInside(Vector2 position)
	{
		return (Mathf.RoundToInt(position.x) >= 0 && Mathf.RoundToInt(position.x) < width
			&& Mathf.RoundToInt(position.y) >= 0 /*&& (int)position.y < height*/);
	}

	public static bool IsValidPosition(Vector2 position, Transform parentTransform)
	{
		if (!Grid.IsInside(position))
			return false;

		if (cells[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] != null 
			&& cells[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)].transform.parent != parentTransform)
			return false;
		return true;
	}

	public static void UpdateCells(Shape shape)
	{
		for (int y = 0; y < height; ++y)
		{
			for (int x = 0; x < width; ++x)
			{
				if (cells[x, y] != null && cells[x, y].transform.parent == shape.transform)
					cells[x, y] = null;
			}
		}

		foreach (Cell child in shape.CellBlocks)
		{
			cells[Mathf.RoundToInt(child.transform.position.x), Mathf.RoundToInt(child.transform.position.y)] = child;
		}     
	}
}
