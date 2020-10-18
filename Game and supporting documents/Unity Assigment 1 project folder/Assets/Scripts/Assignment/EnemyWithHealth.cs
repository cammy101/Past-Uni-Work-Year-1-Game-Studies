using UnityEngine;
using System.Collections;

public class EnemyWithHealth : MonoBehaviour
{
    public int Health;
    public float velocityEnemy;
    public int scoreValue;
    public ScoreManager1 scoreManager;
    public GameObject ExplosionMain;
    public Animator anim;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        scoreManager = FindObjectOfType<ScoreManager1>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShip Tag") || (col.tag == "PlayerBullet Tag"))
        {
            scoreManager.score += scoreValue = 50;

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