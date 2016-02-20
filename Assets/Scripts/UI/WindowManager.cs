using UnityEngine;
using System.Collections;

namespace Hike
{
	public class WindowManager : MonoBehaviour
	{
		[SerializeField] private GameObject mainMenu;
		[SerializeField] private GameObject levelSelect;
		[SerializeField] private GameObject levelInfo;
		[SerializeField] private GameObject prepare;
		[SerializeField] private GameObject gameplay;
		[SerializeField] private GameObject result;

		private GameObject currentWindow;

		protected void Awake()
		{
			ShowWindow(mainMenu);
		}

		public void ShowWindow(GameObject window)
		{
			if (null != currentWindow)
			{
				currentWindow.SetActive(false);
			}
			if (null != window)
			{
				window.SetActive(true);
				currentWindow = window;
			}
		}
	}
}