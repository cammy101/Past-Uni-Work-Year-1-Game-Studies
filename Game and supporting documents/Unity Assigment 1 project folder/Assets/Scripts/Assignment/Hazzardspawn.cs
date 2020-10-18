using UnityEngine;
using System.Collections;

public class Hazzardspawn : MonoBehaviour
{
    bool isSpawning = false;
    public float MinSpawnTime = 10f;
    public float MaxSpawnTime = 20f;
    public GameObject[] hazards; // an array to hold all the enemys, including the hazards (meteor)

    IEnumerator SpawnObject(int index, float seconds)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        yield return new WaitForSeconds(seconds);
        new Vector2(Random.Range(min.x, max.x), max.y);
        Instantiate(hazards[index], transform.position, transform.rotation);
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, hazards.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(MinSpawnTime, MaxSpawnTime)));
        }
    }
}

