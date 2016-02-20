using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public Shape currentShape = null;
	public float FallingSpeed = 0.8f;

	float lastMovementUpdate = 0;
	void Update()
	{
		// for test sake
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
		{
			HandleClick();
		}


		if (currentShape == null)
			return;
		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			currentShape.Move(Vector3.left);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			currentShape.Move(Vector3.right);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			currentShape.Rotate();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
			Time.time - lastMovementUpdate >= FallingSpeed)
		{
			if(!currentShape.Move(Vector3.down))
				currentShape = null;
			lastMovementUpdate = Time.time;
		}
	}

	// for test sake
	protected void HandleClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, 1 << LayerMask.NameToLayer("Selectable"));

		if (hit.collider != null)
		{
			GameObject hitGO = hit.collider.gameObject;
			if (null != hitGO && null != hitGO.GetComponent<Shape>() && currentShape == null)
			{
				currentShape = (Object.Instantiate(hitGO) as GameObject).GetComponent<Shape>();
				currentShape.transform.position = Grid.GetStartPosition();
			}
		}
	}
}
