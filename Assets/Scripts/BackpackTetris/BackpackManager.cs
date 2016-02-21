using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackpackManager : MonoBehaviour
{
	private BackpackItem currentItem = null;
	private LinkedList<BackpackItem> items = new LinkedList<BackpackItem>();

	public enum EMovementType
	{
		Left,
		Right,
		Down,
		Rotate,
	}

	public void Move(EMovementType type)
	{
		if (currentItem == null || Backpack.HasExcessItems)
			return;

		switch(type)
		{
		case EMovementType.Left:
			currentItem.Move(Vector3.left);
			break;

		case EMovementType.Right:
			currentItem.Move(Vector3.right);
			break;

		case EMovementType.Down:
			if(!currentItem.Move(Vector3.down))
			{
				if (!currentItem.IsInside())
					Backpack.HasExcessItems = true;

				items.AddLast(currentItem);
				currentItem = null;
			}
			break;

		case EMovementType.Rotate:
			currentItem.Rotate();
			break;

		default:
			Debug.LogError("Unknown movement type!");
			break;
		}
	}

	public void HandleClick(GameObject hitGO)
	{
		BackpackItem hitItem = hitGO.GetComponentInParent<BackpackItem>();
		if (hitItem == null)
			return;

		if (hitItem.IsInside() && hitItem.IsTopMost())
		{
			items.Remove(hitItem);
			GameObject.DestroyImmediate(hitItem.gameObject);
		}
		else if (!Backpack.HasExcessItems && !hitItem.IsInside() && currentItem == null)
		{
			currentItem = (Object.Instantiate(hitItem.gameObject) as GameObject).GetComponent<BackpackItem>();
			currentItem.transform.position = Backpack.GetStartPosition();
		}
	}
}
