using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public float FallingSpeed = 0.8f;
	float lastMovementUpdate = 0;
	private BackpackManager backpackManager;

	void Start()
	{
		backpackManager = GetComponent<BackpackManager>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			HandleClick();
		}
			
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			backpackManager.Move(BackpackManager.EMovementType.Left);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			backpackManager.Move(BackpackManager.EMovementType.Right);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			backpackManager.Move(BackpackManager.EMovementType.Rotate);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
			Time.time - lastMovementUpdate >= FallingSpeed)
		{
			backpackManager.Move(BackpackManager.EMovementType.Down);
			lastMovementUpdate = Time.time;
		}
	}

	protected void HandleClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, 1 << LayerMask.NameToLayer("Selectable"));

		if (hit.collider != null)
		{
			GameObject hitGO = hit.collider.gameObject;
			if (null != hitGO && null != hitGO.GetComponent<ItemShape>())
			{
				backpackManager.HandleClick(hitGO);
			}
		}
	}
}
