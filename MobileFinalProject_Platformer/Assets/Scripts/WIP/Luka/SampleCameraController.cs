using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCameraController : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player);
        if(player.GetComponent<PlayerMobileController>().isRotating)
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
