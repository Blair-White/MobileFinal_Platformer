using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiControllerBehaviour : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject hudCanvas;
    public TextMeshProUGUI countdown;

    
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

    public void UpdateCountdown(int secondsLeft)
    {
        int countdownShown = secondsLeft;
        countdown.SetText(secondsLeft.ToString());
        
        if (secondsLeft == 0)
        {
            countdown.gameObject.SetActive(false);
        }
    }
}
