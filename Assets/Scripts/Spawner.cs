using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnOffset = 10;
    public float spawnRate = 7;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0;
        }

    }

    void spawnEnemy()
    {
        float xPos = Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset);
        float zPos = Random.Range(transform.position.z - spawnOffset, transform.position.z + spawnOffset);
        Instantiate(enemy, new Vector3(xPos, transform.position.y, zPos), transform.rotation);
    }
}
