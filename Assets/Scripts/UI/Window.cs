using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

namespace Hike
{
	public class Window : MonoBehaviour
	{
		[SerializeField] private Sprite Background = null;
		private BackgroundManager bgManager;

		private Graphic[] graphics;
		private Selectable[] selectables;

		protected void Awake()
		{
			graphics = GetComponentsInChildren<Graphic>(true);
			bgManager = FindObjectOfType<BackgroundManager>();
		}

		public void Show()
		{
			if (null == graphics)
				graphics = GetComponentsInChildren<Graphic>(true);
			if (null == bgManager)
				bgManager = FindObjectOfType<BackgroundManager>();

			//graphics.ForEach((g) => g.canvasRenderer.SetAlpha(0f));
			bgManager.SetBackground(Background);

			gameObject.SetActive(true);

			//graphics.ForEach((g) => g.CrossFadeAlpha(1f, WindowManager.TransitionTime, true));
		}
		public IEnumerator ShowCoroutine()
		{
			yield return new WaitForSeconds(WindowManager.TransitionTime);

			//graphics.ForEach((g) => g.SetAllDirty());
		}

		public void Hide()
		{
			//graphics.ForEach((g) => g.CrossFadeAlpha(0f, WindowManager.TransitionTime, true));
			StartCoroutine(HideCoroutine());
		}

		private IEnumerator HideCoroutine()
		{
			//yield return new WaitForSeconds(WindowManager.TransitionTime);
			gameObject.SetActive(false);
			yield return null;
		}
	}
}
