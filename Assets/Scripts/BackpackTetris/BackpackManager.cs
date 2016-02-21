using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackpackManager : MonoBehaviour
{
	private Item currentShape = null;
	private LinkedList<Item> items = new LinkedList<Item>();

	public enum EMovementType
	{
		Left,
		Right,
		Down,
		Rotate,
	}

	public void Move(EMovementType type)
	{
		if (currentShape == null || Backpack.HasExcessItems)
			return;

		switch(type)
		{
		case EMovementType.Left:
			currentShape.Move(Vector3.left);
			break;

		case EMovementType.Right:
			currentShape.Move(Vector3.right);
			break;

		case EMovementType.Down:
			if(!currentShape.Move(Vector3.down))
			{
				if (!currentShape.IsInside())
					Backpack.HasExcessItems = true;

				items.AddLast(currentShape);
				currentShape = null;
			}
			break;

		case EMovementType.Rotate:
			currentShape.Rotate();
			break;

		default:
			Debug.LogError("Unknown movement type!");
			break;
		}
	}

	public void HandleClick(GameObject hitGO)
	{
		Item hitItem = hitGO.GetComponent<Item>();
		if (hitItem == null)
			return;

		if (hitItem.IsInside() && hitItem.IsTopMost())
		{
			items.Remove(hitItem);
			GameObject.DestroyImmediate(hitItem.gameObject);
		}
		else if (!Backpack.HasExcessItems && !hitItem.IsInside() && currentShape == null)
		{
			currentShape = (Object.Instantiate(hitGO) as GameObject).GetComponent<Item>();
			currentShape.transform.position = Backpack.GetStartPosition();
		}
	}

}
