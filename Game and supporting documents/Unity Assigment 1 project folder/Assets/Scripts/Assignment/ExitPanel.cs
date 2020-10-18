using UnityEngine;
using System.Collections;

public class ExitPanel : MonoBehaviour
{
    public GameObject exitPanel;

	// Use this for initialization
	void Start ()
    {
        exitPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {	
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
	}
}
