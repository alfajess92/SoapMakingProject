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

        //if (slider.value > 0.1f&& slider.value< 0.2f)
        //{
        //    print(addedVolume);
        //}
    }

}
