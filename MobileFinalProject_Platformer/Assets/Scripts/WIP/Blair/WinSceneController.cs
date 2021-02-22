using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
 public void BackToMain()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

}
