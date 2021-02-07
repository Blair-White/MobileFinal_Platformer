﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }
}
