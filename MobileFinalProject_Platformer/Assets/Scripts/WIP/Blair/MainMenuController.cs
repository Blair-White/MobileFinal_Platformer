using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{

    public enum MainMenuStates { EnterInit, Init, Options, Credits, EnterStartGame, StartGame }
    MainMenuStates State;

    void Start()
    {
        State = MainMenuStates.EnterInit;
    }

    private void Update()
    {
        switch (State)
        {
            case MainMenuStates.EnterInit:
                
                break;
            case MainMenuStates.Init:
                
                break;
            case MainMenuStates.Options:
                
                break;
            case MainMenuStates.Credits:
                
                break;
            case MainMenuStates.EnterStartGame:
                
                break;
            case MainMenuStates.StartGame:
                
                break;
            default:
                break;
        }
    }

    public void StartButtonPushed()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsButtonPushed()
    {
        
    }

    public void CloseGameButtonPushed()
    { 
    
    }

    public void CreditsButtonPushed()
    {

    }
}
