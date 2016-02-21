using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hike
{
	public class StatsManager : MonoBehaviour
	{
		public const float vitalsMax = 100f;
		public const float conditionsMax = 100f;

		public const float tempMin = -50f;
		public const float tempMax = 70f;

		#region VITALS

		[SerializeField] private PlayerStatistic stamina = new PlayerStatistic() { MaxValue = vitalsMax };
		public float Stamina
		{
			get { return stamina; }
			set { stamina.Value = value; }
		}

		[SerializeField] private PlayerStatistic fillFood = new PlayerStatistic() { MaxValue = vitalsMax };
		public float FillFood
		{
			get { return fillFood; }
			set { fillFood.Value = value; }
		}

		[SerializeField] private PlayerStatistic fillWater = new PlayerStatistic() { MaxValue = vitalsMax };
		public float FillWater
		{
			get { return fillWater; }
			set { fillWater.Value = value; }
		}

		#endregion

		#region CONDITIONS

		[SerializeField] private PlayerStatistic painBody = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PainBody
		{
			get { return painBody; }
			set { painBody.Value = value; }
		}

		[SerializeField] private PlayerStatistic painFeet = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PainFeet
		{
			get { return painFeet; }
			set { painFeet.Value = value; }
		}

		[SerializeField] private PlayerStatistic wetnessBody = new PlayerStatistic() { MaxValue = conditionsMax };
		public float WetnessBody
		{
			get { return wetnessBody; }
			set { wetnessBody.Value = value; }
		}

		[SerializeField] private PlayerStatistic wetnessFeet = new PlayerStatistic() { MaxValue = conditionsMax };
		public float WetnessFeet
		{
			get { return wetnessFeet; }
			set { wetnessFeet.Value = value; }
		}

		[SerializeField] private PlayerStatistic playerTemperature = new PlayerStatistic() { MaxValue = conditionsMax };
		public float PlayerTemperature
		{
			get { return playerTemperature; }
			set { playerTemperature.Value = value; }
		}

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

		private void RecalculateDerivedStats ()
		{

		}

		public void TickWalking(float deltaTime)
		{
		}

		public void UpdateStats ()
		{
			RecalculateDerivedStats ();
			if (null != HUD.Instance)
				HUD.Instance.UpdateStatsHud (this);
		}
	}
}
