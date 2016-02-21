using UnityEngine;
using System.Collections;

public class ItemShape : MonoBehaviour
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
}
