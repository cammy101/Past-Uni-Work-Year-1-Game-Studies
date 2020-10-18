using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public float speed; //the speed the star moves

	void Start ()
    {
	
	}
	

	void Update ()
    {
        Vector2 position = transform.position; //will check for the star's current position

        position = new Vector2(position.x, position.y + speed * Time.deltaTime); //will figure out the stars new position

        transform.position = position; //will update the star's position

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }	
	}
}
