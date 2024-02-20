using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshBlood : MonoBehaviour
{
    [Header("ScriptReference")]
    private HealthManager healthManager;

    [Header("Blood Variables")]
    [SerializeField] private int bloodValue;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }
}
