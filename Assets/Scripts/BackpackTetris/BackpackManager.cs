using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackpackManager : MonoBehaviour
{
	private Item currentShape = null;
	private Item lastShape = null;

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

				lastShape = currentShape;
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
		if (hitGO.GetComponent<Item>().IsInValidPosition())
		{
			GameObject.DestroyImmediate(lastShape.gameObject);
			lastShape = null;
			Debug.Log("Destroy");
		}
		else if (!Backpack.HasExcessItems)
		{
			currentShape = (Object.Instantiate(hitGO) as GameObject).GetComponent<Item>();
			currentShape.transform.position = Backpack.GetStartPosition();
		}
	}

}
