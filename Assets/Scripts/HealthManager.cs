using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health Variable")]
    [SerializeField] private int healthMax = 100;
    public int healthCurrent;
    [SerializeField] private int bloodMax = 100;
    public int bloodCurrent;

    [Header("Slider References")]
    public Slider healthSlider;
    public Slider bloodSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
        bloodCurrent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = healthCurrent;
        bloodSlider.value = bloodCurrent;
    }
}
