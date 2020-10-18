using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public bool canPause;
    public bool canSound;
    public GameObject pausePanel;
    //public string leveltoLoad;
	// Use this for initialization
	void Start ()
    {
        canPause = true;
        canSound = true;
        pausePanel.SetActive(false);
        AudioListener.pause = false;         	
	}

    // Update is called once per frame
    public void Pause()
    {
        if (canPause)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            canPause = false;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            canPause = true;
            pausePanel.SetActive(false);
        }
    }
}
