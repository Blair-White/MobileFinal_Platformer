using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    float lastVolume;

    private void Start()
    {
        lastVolume = 1;
    }

    public void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = lastVolume;
        }

          //  AudioListener.volume > 0 ? AudioListener.volume = 0 : AudioListener.volume = lastVolume;
    }

    public void OnVolumeValueChanged(float newValue)
    {
        AudioListener.volume = newValue;
        lastVolume = newValue;
    }
}
