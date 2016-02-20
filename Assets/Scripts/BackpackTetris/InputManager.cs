using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public Shape currentShape = null;

	float lastFall = 0;
	void Update()
	{
		if (currentShape == null)
			return;
		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			currentShape.transform.position += Vector3.left;
			if (currentShape.IsInValidPosition())
				Grid.UpdateCells(currentShape);
			else
				currentShape.transform.position -= Vector3.left;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			currentShape.transform.position += Vector3.right;
			if (currentShape.IsInValidPosition())
				Grid.UpdateCells(currentShape);
			else
				currentShape.transform.position -= Vector3.right;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			currentShape.transform.Rotate(0, 0, -90);
			if (currentShape.IsInValidPosition())
				Grid.UpdateCells(currentShape);
			else
				currentShape.transform.Rotate(0, 0, 90);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) /*||
			Time.time - lastFall >= 1f*/)
		{
			currentShape.transform.position += Vector3.down;
			if (currentShape.IsInValidPosition()) 
				Grid.UpdateCells(currentShape);
			else
			{
				currentShape.transform.position -= Vector3.down;
				currentShape = null;
			}

			lastFall = Time.time;
		}
	}
}
