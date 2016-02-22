using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeColorOverlay : MonoBehaviour
{
    public Slider timeSlider;
    public Gradient timeGrad;
    public Image overlaySprite;

    void Update()
    {
        if (null != timeSlider && null != overlaySprite)
            overlaySprite.color = timeGrad.Evaluate(timeSlider.normalizedValue);
    }
}
