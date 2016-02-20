using UnityEngine;
using System.Collections;

public class Backpack : MonoBehaviour
{
	public struct Coordinate
	{
		public int x;
		public int y;

		public Coordinate(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int height = 10;
	public static int width = 6;

	private static Transform[,] cells;

	void Start()
	{
		cells = new Transform[width, height];
	}

	public static Coordinate ConvertPositionToCoordinate(Vector2 position)
	{
		return new Coordinate(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));	
	}

	public static bool IsInside(Coordinate coord)
	{
		return (coord.x >= 0 && coord.x < width
			&& coord.y >= 0);
	}

	public static bool IsCompletelyInside(Coordinate coord)
	{
		return IsInside(coord) && coord.y < height;
	}

	public static bool IsValidPosition(Vector3 position, Transform parentTransform)
	{
		Coordinate coord = ConvertPositionToCoordinate(position);

		if (!Backpack.IsInside(coord))
			return false;

		if (coord.y >= height)
			return true;
		
		if (cells[coord.x, coord.y] != null 
			&& cells[coord.x, coord.y].parent != parentTransform)
			return false;
		return true;
	}

	public static void UpdateCells(Item shape)
	{
		for (int y = 0; y < height; ++y)
		{
			for (int x = 0; x < width; ++x)
			{
				if (cells[x, y] != null && cells[x, y].parent == shape.transform)
					cells[x, y] = null;
			}
		}

		foreach (Transform child in shape.CellBlocks)
		{
			Coordinate coord = ConvertPositionToCoordinate(child.position);
			if (IsCompletelyInside(coord))
				cells[coord.x, coord.y] = child;
		}     
	}

	public static Vector2 GetStartPosition()
	{
		return new Vector2(Random.Range(0, width - 1), height);
	}
}
