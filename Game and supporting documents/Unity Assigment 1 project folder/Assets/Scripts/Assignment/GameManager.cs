using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
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
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //Hide game over
                GameOverUI.SetActive(false);

                //Set play button visible
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                TextScoreUIControl.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false); // this is here to hide the play button when in Play state

                playerShip.GetComponent<PlayerShipControl2>().Init();

                enemySpawner.GetComponent<EnemySpawnerControl>().ScheduleEnemySpawn();

                break;

            case GameManagerState.GameOver:

                //will stop enemy spawner
                enemySpawner.GetComponent<EnemySpawnerControl>().UnscheduleEnemySpawner();

                //Disply the gameover image
                GameOverUI.SetActive(true);
                enemySpawner.SetActive(false);                //Change game manager state to Opening state
                Invoke("ChangeToOpeningState", 8f);

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
