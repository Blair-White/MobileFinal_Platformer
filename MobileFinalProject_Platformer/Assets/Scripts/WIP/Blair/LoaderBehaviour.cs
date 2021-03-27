using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SaveBehaviour.instance.isLoading)
        {
            SaveBehaviour.instance.LoadAll();
            SaveBehaviour.instance.isLoading = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
