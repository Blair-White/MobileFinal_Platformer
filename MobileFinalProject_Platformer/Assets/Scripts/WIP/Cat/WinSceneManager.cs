using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSceneManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreAmount;
    private void Start()
    {
        if (scoreAmount)
        {
            scoreAmount.SetText(PlayerPrefs.GetInt("HighScore").ToString());
        }
    }

}
