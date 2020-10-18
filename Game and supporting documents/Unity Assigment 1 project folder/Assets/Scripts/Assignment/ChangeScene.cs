using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public ScoreManager1 sc;

	// Use this for initialization
	public void LoadScene (string levelToLoad)
    {       
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;
        
    }
	
	// Update is called once per frame
	public void Quit ()
    {
        Application.Quit();
        sc.OnPlayerDestory();
    }
}
