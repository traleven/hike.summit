using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public IEnumerable CellBlocks { get { return transform; } }

	public bool IsValidPosition()
	{
		foreach (Transform child in transform)
		{
			if (!Backpack.IsValidPosition(child.position, this.transform))
				return false;
		}
		return true;
	}

	public bool IsTopMost()
	{
		Bounds bounds = GetComponent<BoxCollider2D>().bounds;
		return !Backpack.HasItemAbove(Mathf.CeilToInt(bounds.min.x), Mathf.FloorToInt(bounds.max.x), Mathf.FloorToInt(bounds.max.y), this.transform);
	}

	public bool IsInside()
	{
		foreach (Transform child in transform)
		{
			if (!Backpack.IsCompletelyInside(child.position))
				return false;
		}
		return true;
	}

	public bool Move(Vector3 direction)
	{
		transform.position += direction;
		if (IsValidPosition())
		{
			Backpack.UpdateCells(this);
			return true;
		}
		else
		{
			transform.position -= direction;
			return false;
		}
	}

	public void Rotate()
	{
		transform.Rotate(0, 0, -90);
		if (IsValidPosition())
			Backpack.UpdateCells(this);
		else
			transform.Rotate(0, 0, 90);
	}
}
