using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    private GameObject mPlayer;
    private bool isChasing, doneChasing;
    private float count;
    void Start()
    {
        mPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneChasing)
        {

            if (!isChasing)
                if (Vector3.Distance(transform.position, mPlayer.transform.position) < 75f)
                {
                    isChasing = true;
                }

            if (isChasing)
            {
                count += Time.deltaTime;
                if(count > 3) { doneChasing = true; }
                transform.LookAt(mPlayer.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, mPlayer.transform.position, 0.11f);
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }

        }
      
    }
}
