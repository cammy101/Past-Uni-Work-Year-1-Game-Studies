using UnityEngine;
using System.Collections;

public class EnemyLaserControll : MonoBehaviour
{
    public float moveSpeed;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * moveSpeed;  	
	}
	
	// Update is called once per frame
	void Update ()
    {
        	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShip Tag")
        {
            Destroy(gameObject);
        }
    }
}
