﻿using UnityEngine;
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
		BackpackUIManager.Instance.RemoveButtonClicked += OnRemoveButtonClicked;
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
			if (selectedItem != null)
				selectedItem.transform.localScale /= 1.2f;

			if (selectedItem == hitItem)
				selectedItem = null;
			else
			{
				selectedItem = hitItem;
				selectedItem.transform.localScale *= 1.2f;
			}
		}
		else if (!Backpack.HasExcessItems && !hitItem.IsInside() && currentFallingItem == null)
		{
			currentFallingItem = (Object.Instantiate(hitItem.gameObject) as GameObject).GetComponent<BackpackItem>();
			currentFallingItem.transform.position = Backpack.GetStartPosition();
		}
	}

	private void OnApplyButtonClicked()
	{
		if (selectedItem != null)
		{
			//TODO if item applied it must affect some stats

			items.Remove(selectedItem);
			GameObject.DestroyImmediate(selectedItem.gameObject);
			selectedItem = null;
		}
	}

	private void OnRemoveButtonClicked()
	{
		if (selectedItem != null)
		{
			//TODO recalculate store items count

			items.Remove(selectedItem);
			GameObject.DestroyImmediate(selectedItem.gameObject);
			selectedItem = null;
		}
	}
}
