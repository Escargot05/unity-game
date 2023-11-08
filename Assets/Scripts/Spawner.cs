using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject coin;

    [SerializeField] private float spawnOffset = 35;
    [SerializeField] private float enemySpawnRate = 5;
    [SerializeField] private float coinSpawnRate = 5;

    private float enemyTimer = 0;
    private float coinTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnEnemy();
            spawnCoin();
        }
    }

    void Update()
    {
        if (enemyTimer < enemySpawnRate)
        {
            enemyTimer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            enemyTimer = 0;
        }

        if (coinTimer < coinSpawnRate)
        {
            coinTimer += Time.deltaTime;
        }
        else
        {
            spawnCoin();
            coinTimer = 0;
        }

    }

    void spawnEnemy()
    {
        float xPos = Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset);
        float zPos = Random.Range(transform.position.z - spawnOffset, transform.position.z + spawnOffset);
        Instantiate(enemy, new Vector3(xPos, transform.position.y, zPos), transform.rotation);
    }

    void spawnCoin()
    {
        float xPos = Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset);
        float zPos = Random.Range(transform.position.z - spawnOffset, transform.position.z + spawnOffset);
        Instantiate(coin, new Vector3(xPos, transform.position.y, zPos), transform.rotation);
    }
}
