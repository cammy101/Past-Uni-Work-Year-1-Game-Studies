using UnityEngine;
using System.Collections;

public class PickUpSpawn : MonoBehaviour
{
    bool isSpawning = false;
    public float MinSpawnTime = 40f;
    public float MaxSpawnTime = 60f;
    public GameObject[] pickups; // an array to hold all the enemys, including the hazards (meteor)

    IEnumerator SpawnObject(int index, float seconds)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        yield return new WaitForSeconds(seconds);
        GameObject enemys = Instantiate(pickups[index]);
        enemys.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int enemyIndex = Random.Range(0, pickups.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(MinSpawnTime, MaxSpawnTime)));
        }
    }
}
