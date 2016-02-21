using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackpackManager : MonoBehaviour
{
	private BackpackItem currentFallingItem = null;
	private LinkedList<BackpackItem> items = new LinkedList<BackpackItem>();
	private BackpackItem selectedItem = null;

	public enum EMovementType
	{
		Left,
		Right,
		Down,
		Rotate,
	}

	void Start()
	{
		BackpackUIManager.Instance.ApplyButtonClicked += OnApplyButtonClicked;
	}

	public void Move(EMovementType type)
	{
		if (currentFallingItem == null || Backpack.HasExcessItems)
			return;

		switch(type)
		{
		case EMovementType.Left:
			currentFallingItem.Move(Vector3.left);
			break;

		case EMovementType.Right:
			currentFallingItem.Move(Vector3.right);
			break;

		case EMovementType.Down:
			if(!currentFallingItem.Move(Vector3.down))
			{
				if (!currentFallingItem.IsInside())
					Backpack.HasExcessItems = true;

				items.AddLast(currentFallingItem);
				currentFallingItem = null;
			}
			break;

		case EMovementType.Rotate:
			currentFallingItem.Rotate();
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
			selectedItem = hitItem;
		}
		else if (!Backpack.HasExcessItems && !hitItem.IsInside() && currentFallingItem == null)
		{
			currentFallingItem = (Object.Instantiate(hitItem.gameObject) as GameObject).GetComponent<BackpackItem>();
			currentFallingItem.transform.position = Backpack.GetStartPosition();
		}
	}

	private void OnApplyButtonClicked()
	{
		Debug.Log("Apply");

		if (selectedItem != null)
		{
			items.Remove(selectedItem);
			GameObject.DestroyImmediate(selectedItem.gameObject);
		}
	}
}
