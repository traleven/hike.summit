using UnityEngine;
using System.Collections;
using System;

namespace Hike
{
	[CreateAssetMenu]
	public class WeatherInfo : ScriptableObject
	{
		[SerializeField] private WeatherEffect[] Effects;

		public WeatherEffect GetWeather(float time)
		{
			for (int i = 0, n = Effects.Length; i < n; ++i)
			{
				time -= Effects[i].Duration;
				if (time < 0)
					return Effects[i];
			}
			return Effects[Effects.Length - 1];
		}

		[Serializable]
		public class WeatherEffect
		{
			public float Duration;

			public float Light;
			public float Temperature;
			public float Humidity;
			public float SunHeat;
		}
	}
}
