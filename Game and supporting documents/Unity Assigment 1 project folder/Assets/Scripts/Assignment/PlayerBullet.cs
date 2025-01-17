﻿using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    float speed;

	void Start ()
    {
        speed = 6f;
	}
	
	
	void Update ()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShip Tag")
        {
            Destroy(gameObject);
        }
    }
}
