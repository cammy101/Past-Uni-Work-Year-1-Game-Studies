using UnityEngine;
using System.Collections;

public class StartWave : MonoBehaviour
{
   
    bool isSpawning = false;
    public float MinSpawnTime = 5f;
    public float MaxSpawnTime = 10f;
    public GameObject[] enemies; // an array to hold all the enemys, including the hazards (meteor)

    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemys = Instantiate(enemies[index]);
        enemys.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, enemies.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(MinSpawnTime, MaxSpawnTime)));
        }
    }
}
