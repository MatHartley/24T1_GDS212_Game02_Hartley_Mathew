using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Object Reference")]
    private GameObject player;
    public GameObject bloodDrop;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 2f;

    [Header("Health & Damage Variables")]
    [SerializeField] private int enemyHealthMax;
    public int enemyHealthCurrent;
    [SerializeField] private int enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        enemyHealthCurrent = enemyHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (enemyHealthCurrent <= 0)
        {
            Instantiate(bloodDrop, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void TakeDamage(int damageTaken)
    {
        enemyHealthCurrent = enemyHealthCurrent - damageTaken;
    }
}
