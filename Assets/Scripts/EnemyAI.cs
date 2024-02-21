using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Object Reference")]
    private GameObject player;
    public GameObject bloodDrop;
    private Rigidbody2D rigidBody;

    [Header("Script References")]
    private HealthManager healthManager;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 2f;

    [Header("Health & Damage Variables")]
    [SerializeField] private int enemyHealthMax = 10;
    public int enemyHealthCurrent;
    [SerializeField] private int enemyDamage;

    [Header("Stun Timers")]
    [SerializeField] private float stunCounter;
    [SerializeField] private float stunTotalTime;

    [Header("Kill Count")]
    private int killCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        rigidBody = GetComponent<Rigidbody2D>();
        healthManager = FindObjectOfType<HealthManager>();

        enemyHealthCurrent = enemyHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        stunCounter -= Time.deltaTime;

        if (stunCounter <= 0) //if not stunned they can move
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (enemyHealthCurrent <= 0)
        {
            //add to the kill count for the end screen
            killCount = PlayerPrefs.GetInt("Kills", 0);
            killCount++;
            PlayerPrefs.SetInt("Kills", killCount);

            //drops a blood pool on death
            Instantiate(bloodDrop, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// TakeDamage is called from whatever is causing damage to the enemy
    /// </summary>
    /// <param name="damageTaken"></param>
    /// <param name="knockFromRight"></param>
    public void TakeDamage(int damageTaken)
    {

        stunTotalTime = (damageTaken / 10f);
        stunCounter = stunTotalTime;

        enemyHealthCurrent = enemyHealthCurrent - damageTaken;
    }

    /// <summary>
    /// This deals damage to the player if they come into contact with them, and also stuns the enemy allowing the player to move away
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthManager.healthCurrent = healthManager.healthCurrent - enemyDamage;

            stunTotalTime = 1;
            stunCounter = stunTotalTime;
        }
    }
}
