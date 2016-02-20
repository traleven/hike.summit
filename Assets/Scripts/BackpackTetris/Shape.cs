using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{
	public IEnumerable CellBlocks { get { return transform; } }

	public bool IsInValidPosition()
	{        
		foreach (Transform child in transform)
		{
			if (!Grid.IsValidPosition(child.position, this.transform))
				return false;
		}
		return true;
	}

	public bool Move(Vector3 direction)
	{
		transform.position += direction;
		if (IsInValidPosition())
		{
			Grid.UpdateCells(this);
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
		if (IsInValidPosition())
			Grid.UpdateCells(this);
		else
			transform.Rotate(0, 0, 90);
	}
}
