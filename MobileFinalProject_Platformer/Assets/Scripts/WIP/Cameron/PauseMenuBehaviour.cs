using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    private GameObject UiController;
    void Start()
    {
        UiController = GameObject.FindWithTag("UiController");
    }

    public void OnPressedInGamePauseButton()
    {
        UiController.GetComponent<UiControllerBehaviour>().PauseGame();
    }

    public void OnPressedInGameResumeButton()
    {
        UiController.GetComponent<UiControllerBehaviour>().ResumeGame();
    }

    public void OnPressedMainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
