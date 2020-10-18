using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

    public GameObject shotPrefab;

    void Update() {

        if (Input.GetKeyDown("space"))
{
            GameObject x = Instantiate(shotPrefab);
            Rigidbody2D rbNew = x.GetComponent<Rigidbody2D>();
            Rigidbody2D rbThis = GetComponent<Rigidbody2D>();
            rbNew.velocity = new Vector2(8, 0);
            rbNew.position = rbThis.position;
            x.transform.position = gameObject.transform.position;
        }
    }
}