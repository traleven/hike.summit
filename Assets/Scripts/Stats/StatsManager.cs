using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hike
{
    public class StatsManager : MonoBehaviour
    {
        public enum EStat
        {
            Stamina,
            FillFood,
            FillWater,

            HealthGeneral,
            HealthFeet,

            BodyTemp,

            WetnessGeneral,
            WetnessFeet,

            ResistWind,
            ResistWeather,
            ResistFeet,
            ResistWaterFeet,
            ResistTemp,

            PackLoad,
            PackBalance,
        }

        private float stamina;
        public float Stamina
        {
            get { return stamina; }
            set { stamina = value; }

        public void Init()
        {

        }

        public void RecalculateStats()
        {

        }

        public void UpdateStats()
        {
            RecalculateStats();
            UpdateHUD();
        }


        public void UpdateHUD()
        {

        }
    }
}
