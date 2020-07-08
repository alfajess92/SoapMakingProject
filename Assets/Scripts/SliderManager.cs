using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;

   float addedVolume;

    public void selectVolume()
    {
        addedVolume = slider.value;

    }

    public void ResetValue()
    {
        slider.value = 0;
    }

}
