using UnityEngine;
using System.Collections;

namespace Hike
{
	public class WindowManager : MonoBehaviour
	{
		[SerializeField] private Window mainMenu;
		[SerializeField] private Window levelSelect;
		[SerializeField] private Window levelInfo;
		[SerializeField] private Window prepare;
		[SerializeField] private Window gameplay;
		[SerializeField] private Window result;

		private Window currentWindow;

		public static readonly float TransitionTime = 0.3f;

		protected void Awake()
		{
			ShowWindow(mainMenu);
		}

		public void ShowWindow(Window window)
		{
			if (null != currentWindow)
			{
				currentWindow.Hide();
			}
			if (null != window)
			{
				window.Show();
				currentWindow = window;
			}
		}
	}
}