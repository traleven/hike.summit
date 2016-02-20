using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{
	private Cell[] cellBlocks;
	public Cell[] CellBlocks { get { return cellBlocks; } }

	void Start()
	{
		cellBlocks = GetComponentsInChildren<Cell>();
	}
	
	public bool IsInValidPosition()
	{        
		foreach (Cell child in cellBlocks)
		{
			Debug.Log("Child: " + child.name + " position: " + child.transform.position);

			if (!Grid.IsValidPosition(child.transform.position, this.transform))
				return false;
		}
		return true;
	}
}
