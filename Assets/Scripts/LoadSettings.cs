using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettings : MonoBehaviour
{
    void Start()
    {
        Slider slider = (Slider)FindAnyObjectByType(typeof(Slider));
        slider.value = PlayerPrefs.GetFloat("volume");
    }
}
