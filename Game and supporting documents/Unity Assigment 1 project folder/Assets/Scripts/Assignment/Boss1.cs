using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public float velocityEnemy;
    public int Health;
    public int scoreValue;
    public Slider HealthEnemy;
    public ScoreManager1 scoreManager;
    public GameObject ExplosionMain;
    public GameObject Laser;
    public GameObject LaserSpawn;
    public GameObject LaserSpawn2;
    public GameObject LaserSpawn3;
    public GameObject WinnerPanel;
    public bool canShoot;
    public bool defeated;
    public float fireRate = 0.5f;

    private float nextFire = 0.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        scoreManager = FindObjectOfType<ScoreManager1>();
        defeated = false;
    }

    void Update()
    {
        HealthEnemy.value = Health;
        if (Time.time > nextFire)
        {
            if (canShoot)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Laser, LaserSpawn.transform.position, LaserSpawn.transform.rotation);
                Instantiate(Laser, LaserSpawn2.transform.position, LaserSpawn.transform.rotation);
                Instantiate(Laser, LaserSpawn3.transform.position, LaserSpawn.transform.rotation);
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
                defeated = true;
                WinnerPanel.SetActive(true);
                Instantiate(ExplosionMain, transform.position, transform.rotation);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Damage");
            }
        }
    }
}