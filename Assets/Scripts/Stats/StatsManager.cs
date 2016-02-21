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
        private float stamina;
        public float Stamina
        {
            get { return stamina; }
            set { stamina = Mathf.Clamp(value, 0f, vitalsMax); }
        }

        private float fillFood;
        public float FillFood
        {
            get { return fillFood; }
            set { fillFood = Mathf.Clamp(value, 0f, vitalsMax); }
        }

        private float fillWater;
        public float FillWater
        {
            get { return fillWater; }
            set { fillWater = Mathf.Clamp(value, 0f, vitalsMax); }
        }

        #endregion

        #region CONDITIONS
        private float painBody;
        public float PainBody
        {
            get { return painBody; }
            set { painBody = Mathf.Clamp(value, 0f, conditionsMax); }
        }

        private float painFeet;
        public float PainFeet
        {
            get { return painFeet; }
            set { painFeet = Mathf.Clamp(value, 0f, conditionsMax); }
        }

        private float wetnessBody;
        public float WetnessBody
        {
            get { return wetnessBody; }
            set { wetnessBody = Mathf.Clamp(value, 0f, conditionsMax); }
        }

        private float wetnessFeet;
        public float WetnessFeet
        {
            get { return wetnessFeet; }
            set { wetnessFeet = Mathf.Clamp(value, 0f, conditionsMax); }
        }

        private float playerTemperature;
        public float PlayerTemperature
        {
            get { return playerTemperature; }
            set { playerTemperature = Mathf.Clamp(value, tempMin, tempMax); }
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


        public void Init()
        {
        }

        private void RecalculateDerivedStats()
        {

        }

        public void UpdateStats()
        {
            RecalculateDerivedStats();
            if (null != HUD.Instance)
                HUD.Instance.UpdateStatsHud(this);
        }
    }
}
