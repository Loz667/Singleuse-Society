using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WasteLevel : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxWaste(int waste)
    {
        slider.maxValue = waste;
        slider.value = waste;
    }

    public void SetWaste(int waste)
    {
        slider.value = waste;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
