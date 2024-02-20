using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Health Variable")]
    [SerializeField] private int healthMax = 100;
    public int healthCurrent;
    [SerializeField] private int bloodMax = 100;
    public int bloodCurrent;

    [Header("UI References")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public Slider bloodSlider;
    public TextMeshProUGUI bloodText;

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
        healthText.text = "Health: " + healthCurrent + "/100";
        bloodSlider.value = bloodCurrent;
        bloodText.text = "Blood: " + bloodCurrent + "/100";
    }
}
