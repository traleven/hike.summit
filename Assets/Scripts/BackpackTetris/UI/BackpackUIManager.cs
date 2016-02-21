using UnityEngine;
using System.Collections;

public class BackpackUIManager : MonoBehaviour
{
	public System.Action ApplyButtonClicked;
	public System.Action RemoveButtonClicked;

	private static BackpackUIManager instance;
	public static BackpackUIManager Instance 
	{ 
		get 
		{ 
			if (null == instance) 
				instance = FindObjectOfType<BackpackUIManager>(); 
			return instance; 
		} 
	}

	public void OnApplyButtonClicked()
	{
		if (null != ApplyButtonClicked)
			ApplyButtonClicked();
	}

	public void OnRemoveButtonClicked()
	{
		if (null != RemoveButtonClicked)
			RemoveButtonClicked();
	}
}
