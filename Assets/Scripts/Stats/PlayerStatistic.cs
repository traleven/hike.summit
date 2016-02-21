using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Hike
{
	[SerializeField]
	public class PlayerStatistic
	{
		[SerializeField] public float MinValue = 0f;
		[SerializeField] public float MaxValue = 1f;

		private float currentValue = 0f;
		[SerializeField] private Slider progressBar;

		public float Value
		{
			get { return currentValue; }
			set
			{
				value = Mathf.Clamp(value, MinValue, MaxValue);
				if (value != currentValue)
				{
					currentValue = value;
					UpdateHud();
				}
			}
		}
		public float NormalizedValue
		{
			get { return (currentValue - MinValue) / (MaxValue - MinValue); }
		}

		public virtual void UpdateHud ()
		{
			progressBar.normalizedValue = NormalizedValue;
		}

		public static implicit operator float (PlayerStatistic stat)
		{
			return stat.Value;
		}
	}
}
