﻿using UnityEngine;
using System.Collections;

public class PickUpDestory : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
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
