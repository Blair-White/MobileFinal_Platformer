using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject uiController, player;

    public enum GameStates { EnterInit, Init, EnterGameplay, Gameplay, EnterLevelComplete, LevelComplete, EnterDeath, Death, Paused}
    public GameStates State;
    private float countA, countB;
    private void Start()
    {
        player = GameObject.Find("Player");
        State = GameStates.EnterInit;
    }
    private void Update()
    {
        switch (State)
        {
            case GameStates.EnterInit:
                countA+=Time.deltaTime;
                if (countA > 3) State = GameStates.Init;
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
