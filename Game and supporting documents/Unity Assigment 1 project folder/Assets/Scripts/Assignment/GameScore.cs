using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour
{
    Text textScoreUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdatetextScoreUI();
        }
    }

	// Use this for initialization
	void Start ()
    {
        textScoreUI = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void UpdatetextScoreUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        textScoreUI.text = scoreStr;
    }
}
