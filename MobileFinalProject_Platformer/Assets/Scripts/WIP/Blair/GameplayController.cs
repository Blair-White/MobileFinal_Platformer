using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject uiController, player;

    public enum GameStates { EnterInit, Init, EnterGameplay, Gameplay, EnterLevelComplete, LevelComplete, EnterDeath, Death, Paused}
    public GameStates State;

    private void Start()
    {
        State = GameStates.EnterInit;
    }
    private void Update()
    {
        switch (State)
        {
            case GameStates.EnterInit:
                break;
            case GameStates.Init:
                break;
            case GameStates.EnterGameplay:
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
