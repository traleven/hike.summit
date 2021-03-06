﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Hike
{
	public class StatsManager : MonoBehaviour
	{
		public const float vitalsMax = 100f;
		public const float conditionsMax = 100f;

		public const float tempMin = -50f;
		public const float tempMax = 70f;

		[SerializeField] private UnityEvent OnStatOut = new UnityEvent();

		[SerializeField] private PlayerStatistic time = new PlayerStatistic() { MaxValue = 100f };
		public float Time
		{
			get { return time; }
			set { time.Value = value; if (value > time.MaxValue) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnTimeChanged { get { return time.OnValueChanged; } }

		#region VITALS

		[SerializeField] private PlayerStatistic stamina = new PlayerStatistic() { MaxValue = vitalsMax };
		public float Stamina
		{
			get { return stamina; }
			set { stamina.Value = value; if (value < 0f) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnStaminaChanged { get { return stamina.OnValueChanged; } }

		[SerializeField] private PlayerStatistic fillFood = new PlayerStatistic() { MaxValue = vitalsMax };
		public float FillFood
		{
			get { return fillFood; }
			set { fillFood.Value = value; if (value < 0f) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnFillFoodChanged { get { return fillFood.OnValueChanged; } }

		[SerializeField] private PlayerStatistic fillWater = new PlayerStatistic() { MaxValue = vitalsMax };
		public float FillWater
		{
			get { return fillWater; }
			set { fillWater.Value = value; if (value < 0f) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnFillWaterChanged { get { return fillWater.OnValueChanged; } }

		#endregion

		#region CONDITIONS

		[SerializeField] private PlayerStatistic painBody = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PainBody
		{
			get { return painBody; }
			set { painBody.Value = value; if (value < 0f) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnPainBodyChanged { get { return painBody.OnValueChanged; } }

		[SerializeField] private PlayerStatistic painFeet = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PainFeet
		{
			get { return painFeet; }
			set { painFeet.Value = value; if (value < 0f) OnStatOut.Invoke(); }
		}
		public PlayerStatistic.ValueUpdateEvent OnPainFeetChanged { get { return painFeet.OnValueChanged; } }

		[SerializeField] private PlayerStatistic wetnessBody = new PlayerStatistic() { MaxValue = conditionsMax };
		public float WetnessBody
		{
			get { return wetnessBody; }
			set { wetnessBody.Value = value; }
		}
		public PlayerStatistic.ValueUpdateEvent OnWetnessBodyChanged { get { return wetnessBody.OnValueChanged; } }

		[SerializeField] private PlayerStatistic wetnessFeet = new PlayerStatistic() { MaxValue = conditionsMax };
		public float WetnessFeet
		{
			get { return wetnessFeet; }
			set { wetnessFeet.Value = value; }
		}
		public PlayerStatistic.ValueUpdateEvent OnWetnessFeetChanged { get { return wetnessFeet.OnValueChanged; } }

		[SerializeField] private PlayerStatistic playerTemperature = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PlayerTemperature
		{
			get { return playerTemperature; }
			set { playerTemperature.Value = value; }
		}
		public PlayerStatistic.ValueUpdateEvent OnPlayerTemperatureChanged { get { return playerTemperature.OnValueChanged; } }

		#endregion

		#region BACKPACK

		private float loadWeight;
		public float LoadWeight
		{
			get { return loadWeight; }
			set { loadWeight = value; }
		}

		private float packBalance;
		public float LoadBalance
		{
			get { return packBalance; }
			set { packBalance = value; }
		}

		#endregion

		#region RESISTS

		private float resWind;
		public float ResWind
		{
			get { return resWind; }
			set { resWind = value; }
		}

		private float resTemperature;
		public float ResTemperature
		{
			get { return resTemperature; }
			set { resTemperature = value; }
		}

		private float resFeetWetness;
		public float ResFeetWetness
		{
			get { return resFeetWetness; }
			set { resFeetWetness = value; }
		}

		private float resBodyWetness;
		public float ResBodyWetness
		{
			get { return resBodyWetness; }
			set { resBodyWetness = value; }
		}

		private float resFeetPhysical;
		public float ResFeetPhysical
		{
			get { return resFeetPhysical; }
			set { resFeetPhysical = value; }
		}

		#endregion

		public void Init ()
		{
		}

		public void Reset()
		{
			Time = 0f;

			Stamina = stamina.MaxValue;
			FillFood = fillFood.MaxValue;
			FillWater = fillWater.MaxValue;

			PainBody = painBody.MaxValue;
			WetnessBody = wetnessBody.MinValue;
			PainFeet = painFeet.MaxValue;
			WetnessFeet = wetnessFeet.MinValue;
		}

		private void RecalculateDerivedStats ()
		{
		}

		public void TickWalking(float deltaTime, Player player)
		{
			Time += 0.65f * deltaTime;

			float slope = player.CurrentBlock.Slope * player.TrekDirection;
			slope = 0.0025f * slope * slope + 0.05f * slope + 1f;
			Stamina -= 0.5f * slope * deltaTime;

			float sqrtSlope = Mathf.Sqrt(slope);
			FillFood -= 0.25f * sqrtSlope * deltaTime;
			FillWater -= 0.25f * sqrtSlope * player.CurrentBlock.SunModifier * deltaTime;

			WetnessFeet += 0.3f * (player.CurrentBlock.HumidityModifier - 0.5f) * deltaTime;
			WetnessBody += PlayerTemperature / 10 * deltaTime;

			PainFeet -= 0.1f * (Mathf.Sqrt(WetnessFeet) + 1f) * deltaTime;

			player.CurrentSpeed = (0.75f * Mathf.Sqrt(Stamina / 100f) * Mathf.Sqrt(PainFeet / 100f)) / sqrtSlope;
		}

		public void TickCamping(float deltaTime, Player player)
		{
			Time += 0.65f * deltaTime;
			Stamina += 0.5f * Mathf.Sqrt(FillFood) * Mathf.Sqrt(FillWater) * deltaTime;

			FillFood -= 0.1f * deltaTime;
			FillWater -= 0.1f * player.CurrentBlock.SunModifier * deltaTime;

			WetnessFeet += 2 * 0.3f * (player.CurrentBlock.HumidityModifier - 1.2f) * deltaTime;
			WetnessBody += PlayerTemperature / 10 * deltaTime;
		}

		public void UpdateStats ()
		{
			RecalculateDerivedStats ();
			if (null != HUD.Instance)
				HUD.Instance.UpdateStatsHud (this);
		}
	}
}
