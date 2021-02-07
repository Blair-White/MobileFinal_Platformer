using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControllerBehaviour : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject hudCanvas;
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        hudCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        hudCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        
    }
}
