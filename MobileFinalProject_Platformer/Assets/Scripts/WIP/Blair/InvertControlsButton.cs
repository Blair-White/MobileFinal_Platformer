using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControlsButton : MonoBehaviour
{
    public GameObject CheckMark;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPushed()
    {
        if(Soundmanager.instance.InvertedControls)
        {
            Soundmanager.instance.InvertedControls = false;
            CheckMark.SetActive(false);
        }
        else
        {
            Soundmanager.instance.InvertedControls = true;
            CheckMark.SetActive(true);
        }
    }
}
