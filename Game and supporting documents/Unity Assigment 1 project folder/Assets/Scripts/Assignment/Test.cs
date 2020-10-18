using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject boss;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time >= 120)
        {
            boss.SetActive(true);
        }
    }


}
