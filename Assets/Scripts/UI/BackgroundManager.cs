using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Hike
{
	public class BackgroundManager : MonoBehaviour
	{
		[SerializeField] private RawImage[] layers = new RawImage[2];

        public static BackgroundManager Instance { get { return SingletonUtils<BackgroundManager>.Instance; } }

        public RawImage ActiveBG { get { return layers[currentLayer]; } }

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
			if (bg == null || bg == layers[currentLayer].texture)
				return;

			if (layers[currentLayer].texture == null)
			{
				layers[currentLayer].texture = bg.texture;
				return;
			}

			layers[currentLayer].transform.SetSiblingIndex(0);

			layers[nextLayer].texture = bg.texture;
			layers[nextLayer].CrossFadeAlpha(1f, WindowManager.TransitionTime, true);
			layers[currentLayer].CrossFadeAlpha(0f, WindowManager.TransitionTime, true);

            var screenAspect = Screen.width / Screen.height;
            var textureAspect = bg.textureRect.width / bg.textureRect.height;

            if (textureAspect >= screenAspect)
                layers[nextLayer].rectTransform.sizeDelta = new Vector2(Screen.height * textureAspect, Screen.height);
            else
                layers[nextLayer].rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width / textureAspect);

            layers[nextLayer].uvRect = new Rect(0f, 0f, 1f, 1f);

			currentLayer = nextLayer;
		}
	}
}
