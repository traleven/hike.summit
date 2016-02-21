using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private static HUD instance;
    public static HUD Instance { get { if (null == instance) instance = FindObjectOfType<HUD>(); return instance; } }

    public Slider sldStamina;
    public Slider sldFood;
    public Slider sldThirst;

    public Slider sldHealthBody;
    public Slider sldHealthFeet;
    public Slider sldWetBody;
    public Slider sldWetFeet;

    public Text lblTempResist;
    public Text lblWeatherResist;
    public Text lblWindResist;
    public Text lblFeetPhysResist;
    public Text lblFeetWetResist;

    public Slider sldTemperature;
    public Text lblTemperature;

    public Text lblPackWeight;
    public Text lblPackBalance;
}
