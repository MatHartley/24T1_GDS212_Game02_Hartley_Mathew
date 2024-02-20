using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Object Reference")]
    private GameObject player;
    public GameObject bloodDrop;
    private Rigidbody2D rigidBody;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 2f;

    [Header("Health & Damage Variables")]
    [SerializeField] private int enemyHealthMax = 10;
    public int enemyHealthCurrent;
    [SerializeField] private int enemyDamage;

    [Header("Stun Timers")]
    [SerializeField] private float stunCounter;
    [SerializeField] private float stunTotalTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        enemyHealthCurrent = enemyHealthMax;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stunCounter -= Time.deltaTime;

        if (stunCounter <= 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (enemyHealthCurrent <= 0)
        {
            Instantiate(bloodDrop, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damageTaken, bool knockFromRight)
    {
        stunTotalTime = (damageTaken / 10f);
        stunCounter = stunTotalTime;

        enemyHealthCurrent = enemyHealthCurrent - damageTaken;
    }
}
