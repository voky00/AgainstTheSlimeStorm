using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{

    public Slider slider;
    public Image fill;
    public TMP_Text currentValue;
    public void SetMax(float value)
    {
        slider.maxValue = value;
        //slider.transform.localScale = new Vector3(value / 100, 1, 1);   
    }
    public void Set(float value)
    {
        slider.value = value;
        if (currentValue != null)
        currentValue.text = value.ToString();
    }
}
