using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Damage Variables")]
    [SerializeField] private int swordDamage = 5;
    private bool knockFromRight;

    [Header("Script References")]
    private HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // sword damage is based on the current blood stockpile
        switch (healthManager.bloodCurrent)
        {
            case <= 10:
                swordDamage = 10;
                break;
            case <= 20:
                swordDamage = 20;
                break;
            case <= 30:
                swordDamage = 30;
                break;
            case <= 40:
                swordDamage = 40;
                break;
            case <= 50:
                swordDamage = 50;
                break;
            case <= 60:
                swordDamage = 60;
                break;
            case <= 70:
                swordDamage = 70;
                break;
            case <= 80:
                swordDamage = 80;
                break;
            case <= 90:
                swordDamage = 90;
                break;
            case <= 100:
                swordDamage = 100;
                break;
            default:
                swordDamage = 5;
                break;
        }
    }

    /// <summary>
    /// Calls the TakeDamage function on the EnemyAI script and applies the damage value of this weapon
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyAI>().TakeDamage(swordDamage);
        }
    }
}
