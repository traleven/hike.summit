using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Hike
{
	[Serializable]
	public class PlayerStatistic
	{
		[SerializeField] public float MinValue = 0f;
		[SerializeField] public float MaxValue = 1f;

		[SerializeField] private float currentValue = 0f;
		[SerializeField] public ValueUpdateEvent OnValueChanged = new ValueUpdateEvent();

		public float Value
		{
			get { return currentValue; }
			set
			{
				value = Mathf.Clamp(value, MinValue, MaxValue);
				if (value != currentValue)
				{
					currentValue = value;
					OnValueChanged.Invoke(this);
				}
			}
		}
		public float NormalizedValue
		{
			get { return (currentValue - MinValue) / (MaxValue - MinValue); }
		}

		public static implicit operator float (PlayerStatistic stat)
		{
			return stat.Value;
		}

		[Serializable]
		public class ValueUpdateEvent : UnityEngine.Events.UnityEvent<PlayerStatistic>
		{
		}
	}
}
