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
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.Click, .75f);
    }

    public void OnPressedInGameResumeButton()
    {
        UiController.GetComponent<UiControllerBehaviour>().ResumeGame();
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.Click, .75f);
    }

    public void OnPressedMainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.Click, .75f);
    }
}
