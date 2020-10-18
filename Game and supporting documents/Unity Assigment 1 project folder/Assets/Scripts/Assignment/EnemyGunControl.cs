using UnityEngine;
using System.Collections;

public class EnemyGunControl : MonoBehaviour
{
    public GameObject EnemyBulletMain;

	// Use this for initialization
	void Start ()
    {
        Invoke("FireEnemyBullet", 1f);
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerShipBody");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletMain);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBulletBehavour1>().SetDirection(direction);
        }
    }
}
