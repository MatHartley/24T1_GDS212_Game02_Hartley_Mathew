using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Health Variable")]
    public int healthMax = 100;
    public int healthCurrent;
    public int bloodMax = 100;
    public int bloodCurrent;

    [Header("UI References")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public Slider bloodSlider;
    public TextMeshProUGUI bloodText;

    [Header("Script References")]
    public SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
        bloodCurrent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCurrent > healthMax)
        {
            healthCurrent = healthMax;
        }
        if (bloodCurrent > bloodMax)
        {
            bloodCurrent = bloodMax;
        }

        //update the UI elements
        healthSlider.value = healthCurrent;
        healthText.text = "Health: " + healthCurrent + "/100";
        bloodSlider.value = bloodCurrent;
        bloodText.text = "Blood: " + bloodCurrent + "/100";

        //loads the end game screen if the player runs out of health
        if (healthCurrent <= 0)
        {
            sceneController.LoadLoseScreen();
        }

    }
}
