using UnityEngine;
using System.Collections;

public class EnemyRedShip : MonoBehaviour
{
    public float velocityEnemy;
    public int Health;
    public int scoreValue;
    public ScoreManager1 scoreManager;
    public GameObject ExplosionMain;
    public GameObject Laser;
    public GameObject LaserSpawn;
    public bool canShoot;
    public float fireRate = 0.5f;

    private float nextFire = 0.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        scoreManager = FindObjectOfType<ScoreManager1>();
    }

    void Update()
    {
        if(Time.time > nextFire)
        {
            if(canShoot)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Laser, LaserSpawn.transform.position, LaserSpawn.transform.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShip Tag") || (col.tag == "PlayerBullet Tag"))
        {
            scoreManager.score += scoreValue;

            if (Health >= 0)
            {
                Health--;
            }

            if (Health <= 0)
            {
                Destroy(gameObject);
                Instantiate(ExplosionMain, transform.position, transform.rotation);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Damage");
            }
        }
    }
}