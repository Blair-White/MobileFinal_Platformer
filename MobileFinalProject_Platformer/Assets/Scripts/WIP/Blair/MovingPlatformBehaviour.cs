using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{

    public GameObject Endpoint;
    private Vector3 start, end;
    private bool isMovingRight = false;

    [SerializeField]
    private float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        start = this.transform.position;
        end = Endpoint.transform.position;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Endpoint.transform.position, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, end) < Mathf.Epsilon)
            {
                isMovingRight = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, start) < Mathf.Epsilon)
            {
                isMovingRight = false;
            }
        }
    }
}
