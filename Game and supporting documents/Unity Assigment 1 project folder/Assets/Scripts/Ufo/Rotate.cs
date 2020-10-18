using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
