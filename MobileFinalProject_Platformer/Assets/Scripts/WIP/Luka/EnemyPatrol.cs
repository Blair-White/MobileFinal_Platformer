using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    public float range; //for checking how close the AI is to the waypoint
    public Animator animatorController;


    private int waypointIndex;
    private float distance;

    void Start()
    {
        animatorController = GetComponent<Animator>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        
        if (distance < range)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        animatorController.SetInteger("Walk", 1);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
