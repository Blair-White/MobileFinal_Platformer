using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject uiController, player;

    public enum GameStates { EnterInit, Init, EnterGameplay, Gameplay, EnterLevelComplete, LevelComplete, EnterDeath, Death, Paused}
    public GameStates State;
    private float gameStartCountdown = 4f;
    public int score;
    private void Start()
    {
        score = 0;
        player = GameObject.Find("Player");
        State = GameStates.EnterInit;
    }
    private void Update()
    {
        switch (State)
        {
            case GameStates.EnterInit:
                gameStartCountdown-=Time.deltaTime;
                // casting to int truncates the float so it'll just count 3 2 1 
                uiController.GetComponent<UiControllerBehaviour>().UpdateCountdown((int)gameStartCountdown);
                if (gameStartCountdown < 1) State = GameStates.Init;
                break;
            case GameStates.Init:
                player.SendMessage("GameStart");
                State = GameStates.EnterGameplay;
                break;
            case GameStates.EnterGameplay:
                Debug.Log("Game Initialized, Starting Gameplay");
                State = GameStates.Gameplay;
                break;
            case GameStates.Gameplay:
                break;
            case GameStates.EnterLevelComplete:
                break;
            case GameStates.LevelComplete:
                break;
            case GameStates.EnterDeath:
                break;
            case GameStates.Death:
                break;
            case GameStates.Paused:
                break;
            default:
                break;
        }
    }

    private void PlayerDied()
    {

    }

    private void LevelCompleted()
    { 
    
    }

    private void GamePaused()
    {

    }

}
