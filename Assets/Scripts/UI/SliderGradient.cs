using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderGradient : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private Color min;
	[SerializeField] private Color med;
	[SerializeField] private Color max;
	[SerializeField] private Image[] images;

	protected void Start()
	{
		UpdateColor();
	}

	public void UpdateColor()
	{
		var t = slider.normalizedValue;
		var color = t < 0.5f ? Color.Lerp(min, med, t * 2) : Color.Lerp(med, max, (t - 0.5f) * 2);
		for (int i = 0, n = images.Length; i < n; ++i)
		{
			images[i].color = color;
		}
	}
}
