using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager1 : MonoBehaviour
{
    public int score;
    public int BestScore;
    public int health;
    public Text ScoreText;

	
	void Awake ()
    {
        ScoreText = GetComponent<Text>();
        BestScore = PlayerPrefs.GetInt("bestScore");
        score = 0;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ScoreText.text = "Score:" + score;
        if(score>BestScore)
        {
            BestScore=score;
        }
        GameObject.Find("Best").GetComponent<Text>().text = "Best:" + PlayerPrefs.GetInt("bestScore");
        GameObject.Find("Score").GetComponent<Text>().text="Score:" + score;   
	}
   public void OnPlayerDestory()
    {
        Debug.Log(BestScore);
        PlayerPrefs.SetInt("bestScore", BestScore);
        Debug.Log("High Score is " + BestScore);
        PlayerPrefs.Save();
    }
    public void changeScene()
    {
        Debug.Log(BestScore);
        PlayerPrefs.SetInt("bestScore", BestScore);
        PlayerPrefs.Save();
    }
}
