using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Hike
{
    public class HUD : MonoBehaviour
    {
        private static HUD instance;
        public static HUD Instance { get { if (null == instance) instance = FindObjectOfType<HUD>(); return instance; } }

        public Slider sldStamina;
        public Slider sldFood;
        public Slider sldThirst;

        public Slider sldPainBody;
        public Slider sldPainFeet;
        public Slider sldWetBody;
        public Slider sldWetFeet;

        public Text lblTempResist;
        public Text lblWindResist;
        public Text lblBodyWetResist;
        public Text lblFeetPhysResist;
        public Text lblFeetWetResist;

        public Slider sldTemperature;
        public Text lblTemperature;

        public Text lblPackWeight;
        public Text lblPackBalance;

        private bool initialized = false;
        public void InitHUD(StatsManager sm)
        {
        	if (initialized)
        		return;

            sldStamina.minValue = 0f;
            sldStamina.maxValue = StatsManager.vitalsMax;
			sm.OnStaminaChanged.AddListener((stat) => sldStamina.normalizedValue = stat.NormalizedValue);

            sldFood.minValue = 0f;
            sldFood.maxValue = StatsManager.vitalsMax;
            sm.OnFillFoodChanged.AddListener((stat) => sldFood.normalizedValue = stat.NormalizedValue);

            sldThirst.minValue = 0f;
            sldThirst.maxValue = StatsManager.vitalsMax;
            sm.OnFillWaterChanged.AddListener((stat) => sldThirst.normalizedValue = stat.NormalizedValue);


            sldPainBody.minValue = 0f;
            sldPainBody.maxValue = StatsManager.conditionsMax;

            sldPainFeet.minValue = 0f;
            sldPainFeet.maxValue = StatsManager.conditionsMax;

            sldWetBody.minValue = 0f;
            sldWetBody.maxValue = StatsManager.conditionsMax;

            sldWetFeet.minValue = 0f;
            sldWetFeet.maxValue = StatsManager.conditionsMax;


            sldTemperature.minValue = StatsManager.tempMin;
            sldTemperature.maxValue = StatsManager.tempMax;
            sldTemperature.onValueChanged.AddListener((v) => lblTemperature.text = v.ToString("0.0") + " C");
            sm.OnPlayerTemperatureChanged.AddListener((stat) => sldTemperature.normalizedValue = stat.NormalizedValue);

            initialized = true;
        }

        public void UpdateStatsHud(StatsManager sm)
        {
            sldStamina.value = sm.Stamina;
            sldFood.value = sm.FillFood;
            sldThirst.value = sm.FillWater;

            sldPainBody.value = sm.PainBody;
            sldPainFeet.value = sm.PainFeet;
            sldWetBody.value = sm.WetnessBody;
            sldWetFeet.value = sm.WetnessFeet;
        }
    }
}
