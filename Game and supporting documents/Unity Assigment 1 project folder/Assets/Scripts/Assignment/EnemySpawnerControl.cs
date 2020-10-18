using UnityEngine;
using System.Collections;

public class EnemySpawnerControl : MonoBehaviour
{
    public GameObject EnemyShip;

    float maxSpawnRateInSeconds = 6f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject aEnemy = (GameObject)Instantiate(EnemyShip);
        aEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;
        Invoke("spawnEnemy", spawnInNSeconds);
    }
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }

    public void ScheduleEnemySpawn()
    {
        maxSpawnRateInSeconds = 6f;

        Invoke("spawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }


}


