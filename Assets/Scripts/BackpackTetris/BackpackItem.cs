using UnityEngine;
using System.Collections;

public class BackpackItem : MonoBehaviour
{
	public ItemInfo Info;

	private ItemShape shape = null;

	void Start()
	{
		shape = GetComponentInChildren<ItemShape>();
		if (shape == null)
		{
			shape = (Object.Instantiate(Info.Shape) as GameObject).GetComponent<ItemShape>();
			shape.transform.parent = this.transform;
			shape.transform.localPosition = Vector3.zero;
		}
	}

	public bool Move(Vector3 direction)
	{
		transform.position += direction;
		if (shape.IsValidPosition())
		{
			Backpack.UpdateCells(shape);
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
		if (shape.IsValidPosition())
			Backpack.UpdateCells(shape);
		else
			transform.Rotate(0, 0, 90);
	}

	public bool IsInside()
	{
		return shape.IsInside();
	}

	public bool IsTopMost()
	{
		return shape.IsTopMost();
	}
}
