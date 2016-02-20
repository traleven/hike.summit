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
}
