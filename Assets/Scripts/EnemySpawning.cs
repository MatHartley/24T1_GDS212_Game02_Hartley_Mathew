using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Spawn Objects")]
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject enemyBigSpawn;

    [Header("Spawning Options")]
    [SerializeField] private float spawnTime;
    [SerializeField] private float speedUpTime;
    [SerializeField] private float spawnCount;
    [SerializeField] private float speedCount;
    [SerializeField] private float bigSpawnTime;
    [SerializeField] private float bigSpawnCount;

    private int spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnCount = spawnTime;
        speedCount = speedUpTime;
        bigSpawnCount = bigSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        speedCount -= Time.deltaTime;
        Debug.Log("Spawn Speed Up: " + speedCount);

        spawnCount -= Time.deltaTime;
        Debug.Log("New Spawn: " + spawnCount);

        bigSpawnCount -= Time.deltaTime;
        Debug.Log("Big Spawn: " + bigSpawnCount);

        if (speedCount <= 0)
        {
            spawnTime = spawnTime * 0.75f;
            bigSpawnTime = bigSpawnTime * 0.75f;

            speedCount = speedUpTime;
        }

        if (spawnCount <= 0)
        {
            spawnLocation = (int)Random.Range(1, 5);
            Debug.Log("Spawn Location: " + spawnLocation);
            GameObject spawn = Instantiate(enemySpawn) as GameObject;

            //Zone 1 is Up. Zone 2 is Left. Zone 3 is Right. Zone 4 is Bottom.
            switch (spawnLocation)
            {
                case 1:
                    spawn.transform.position = new Vector2(Random.Range(-10, 10), 6);
                    break;
                case 2:
                    spawn.transform.position = new Vector2(Random.Range(-6, 6), -10);
                    break;
                case 3:
                    spawn.transform.position = new Vector2(Random.Range(-6, 6), 10);
                    break;
                case 4:
                    spawn.transform.position = new Vector2(Random.Range(-10, 10), -6);
                    break;
                default:
                    break;
            }

            spawnCount = spawnTime;
        }

        if (bigSpawnCount <= 0)
        {
            spawnLocation = (int)Random.Range(1, 5);
            Debug.Log("Spawn Location: " + spawnLocation);
            GameObject bigSpawn = Instantiate(enemyBigSpawn) as GameObject;

            //Zone 1 is Up. Zone 2 is Left. Zone 3 is Right. Zone 4 is Bottom.
            switch (spawnLocation)
            {
                case 1:
                    bigSpawn.transform.position = new Vector2(Random.Range(-10, 10), 6);
                    break;
                case 2:
                    bigSpawn.transform.position = new Vector2(Random.Range(-6, 6), -10);
                    break;
                case 3:
                    bigSpawn.transform.position = new Vector2(Random.Range(-6, 6), 10);
                    break;
                case 4:
                    bigSpawn.transform.position = new Vector2(Random.Range(-10, 10), -6);
                    break;
                default:
                    break;
            }

            bigSpawnCount = bigSpawnTime;
        }
    }
}
