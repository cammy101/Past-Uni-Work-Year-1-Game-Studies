using UnityEngine;
using System.Collections;

public class EnemyBlackShip : MonoBehaviour
{
    public float velocityEnemy;
    public int scoreValue;
    public ScoreManager1 scoreManager;
    public GameObject ExplosionMain;

    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        scoreManager = FindObjectOfType<ScoreManager1>();
	}
	
     void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShip Tag") || (col.tag == "PlayerBullet Tag"))
        {        
            Destroy(gameObject);           
            scoreManager.score += scoreValue = 50;
            Instantiate(ExplosionMain, transform.position, transform.rotation);     
        }
    }
}
