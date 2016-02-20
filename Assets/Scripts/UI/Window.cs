using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Hike
{
	public class Window : MonoBehaviour
	{
		private Graphic[] graphics;

		protected void Awake()
		{
			graphics = GetComponentsInChildren<Graphic>(true);
		}

		public void Show()
		{
			if (null == graphics)
				graphics = GetComponentsInChildren<Graphic>(true);

			graphics.ForEach((g) => g.canvasRenderer.SetAlpha(0f));

			gameObject.SetActive(true);

			graphics.ForEach((g) => g.CrossFadeAlpha(1f, WindowManager.TransitionTime, true));
		}
		public IEnumerator ShowCoroutine()
		{
			yield return new WaitForSeconds(WindowManager.TransitionTime);

			graphics.ForEach((g) => g.SetAllDirty());
		}

		public void Hide()
		{
			graphics.ForEach((g) => g.CrossFadeAlpha(0f, WindowManager.TransitionTime, true));
			StartCoroutine(HideCoroutine());
		}

		private IEnumerator HideCoroutine()
		{
			yield return new WaitForSeconds(WindowManager.TransitionTime);
			gameObject.SetActive(false);
		}
	}
}
