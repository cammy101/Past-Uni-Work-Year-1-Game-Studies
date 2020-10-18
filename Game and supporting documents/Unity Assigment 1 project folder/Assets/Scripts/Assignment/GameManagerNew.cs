using UnityEngine;
using System.Collections;

public class GameManagerNew : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawn;
    public GameObject GameOverUI;
    public GameObject TextScoreUIControl;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start ()
    {
        GMState = GameManagerState.Opening;	
	}

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                //Hide GameOver
                GameOverUI.SetActive(false);

                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                TextScoreUIControl.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerShipControl2>().Init();

                //will start enemy spawner
                enemySpawn.GetComponent<EnemySpawn>().ScheduleEnemySpawner();

                break;

            case GameManagerState.GameOver:

                //Stop Enemy Spawner
                enemySpawn.GetComponent<EnemySpawn>().UnscheduleEnemySpawner();

                Invoke("ChangeToOpeningState", 8f);

                GameOverUI.SetActive(true);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
