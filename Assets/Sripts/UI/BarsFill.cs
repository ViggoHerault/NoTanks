using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsFill : MonoBehaviour
{
    private Slider slider;

    public float sliderValue = 0f;

    public int matchingPlayer = 0;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = sliderValue;
    }
}