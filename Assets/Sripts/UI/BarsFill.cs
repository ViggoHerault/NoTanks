using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsFill : MonoBehaviour
{
    private Slider slider;

    public float sliderValue = 0f;
    public int matchingPlayer = 0;

    [SerializeField]
    private AudioSource ShotCharging;
    private bool tankCharging = false;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = sliderValue;

        if (sliderValue <= 0.1 && tankCharging == false) 
        {
            tankCharging = true;
            StartCoroutine(TankIsCharging());
            tankCharging = false;
        }
    }

    public IEnumerator TankIsCharging()
    {
        yield return new WaitForSeconds(0.4f);
        ShotCharging.Play();
        yield return new WaitForSeconds(1f);
    }
}