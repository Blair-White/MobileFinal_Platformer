using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedUiCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Soundmanager.instance.InvertedControls)
            this.gameObject.SetActive(false);
    }
}
