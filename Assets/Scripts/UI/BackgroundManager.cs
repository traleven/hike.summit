using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Hike
{
	public class BackgroundManager : MonoBehaviour
	{
		[SerializeField] private Image[] layers = new Image[2];

		private int currentLayer;
		private int nextLayer
		{
			get { return (currentLayer + 1) % 2; }
		}

		protected void Awake()
		{
			layers[nextLayer].canvasRenderer.SetAlpha(0f);
		}

		public void SetBackground(Sprite bg)
		{
			if (layers[currentLayer].sprite == null)
			{
				layers[currentLayer].sprite = bg;
				return;
			}

			layers[currentLayer].transform.SetSiblingIndex(0);

			layers[nextLayer].sprite = bg;
			layers[nextLayer].CrossFadeAlpha(1f, WindowManager.TransitionTime, true);
			layers[currentLayer].CrossFadeAlpha(0f, WindowManager.TransitionTime, true);
			currentLayer = nextLayer;
		}
	}
}
