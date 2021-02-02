using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{

    public GameObject Endpoint;
    private Vector3 start, end;
    private bool leftRight;
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
        if(!leftRight)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, end, 15 * Time.deltaTime);
            if(Vector3.Distance(this.transform.position, end) < 0.0001f)
            {
                leftRight = true;
            }
        }

        if (leftRight)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, start, 15 * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, start) < 0.0001f)
            {
                leftRight = false;
            }
        }

    }
}
