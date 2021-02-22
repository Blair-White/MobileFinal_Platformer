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
          AudioListener.volume = AudioListener.volume > 0 ?  0 : lastVolume;
    }

    public void OnVolumeValueChanged(float newValue)
    {
        AudioListener.volume = newValue;
        lastVolume = newValue;
    }
}
