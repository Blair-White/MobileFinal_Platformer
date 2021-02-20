using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHazard : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.SendMessage("HitFast");
        }
    }
}
