using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshBlood : MonoBehaviour
{
    [Header("ScriptReference")]
    private HealthManager healthManager;

    [Header("Audio Reference")]
    private AudioSource bloodSFX;

    [Header("Blood Variables")]
    [SerializeField] private int bloodValue;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        bloodSFX = GameObject.Find("BloodSFX").GetComponent<AudioSource>();
    }

    /// <summary>
    /// If the player character moves over the blood, it adds to either the health pool if possible, then the blood pool if possible, then is destroyed
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bloodSFX.Play();

            if (healthManager.healthCurrent < healthManager.healthMax)
            {
                healthManager.healthCurrent += bloodValue;
            }
            else if (healthManager.bloodCurrent < healthManager.bloodMax)
            {
                healthManager.bloodCurrent += bloodValue;
            }

            Destroy(this.gameObject);
        }
    }
}
