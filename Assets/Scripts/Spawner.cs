using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject potion;

    [SerializeField] private float spawnOffset = 35;
    [SerializeField] private float enemySpawnRate = 5;
    [SerializeField] private float coinSpawnRate = 5;
    [SerializeField] private float potionSpawnRate = 8;

    float enemyTimer = 0;
    float coinTimer = 0;
    float potionTimer = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnEnemy();
            spawnCoin();
        }
        spawnPotion();
        spawnPotion();
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

        if (potionTimer < potionSpawnRate)
        {
            potionTimer += Time.deltaTime;
        }
        else
        {
            spawnPotion();
            potionTimer = 0;
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
        Ray ray = new Ray(new Vector3(xPos, 0, zPos), transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            Vector3 pos = hit.point;
            pos.y += 1.0f;
            GameObject c = Instantiate(coin, pos, transform.rotation);
            c.transform.SetParent(hit.collider.transform);
        }
    }

    void spawnPotion()
    {
        float xPos = Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset);
        float zPos = Random.Range(transform.position.z - spawnOffset, transform.position.z + spawnOffset);
        Ray ray = new Ray(new Vector3(xPos, 0, zPos), transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 pos = hit.point;
            pos.y += 0.5f;
            GameObject c = Instantiate(potion, pos, transform.rotation);
            c.transform.SetParent(hit.collider.transform);
        }
    }
}
