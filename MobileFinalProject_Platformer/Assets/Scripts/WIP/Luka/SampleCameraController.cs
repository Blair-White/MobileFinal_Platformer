using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float yOffset = 12f;
    [SerializeField]
    private float zOffset = -7f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);
    }
}
