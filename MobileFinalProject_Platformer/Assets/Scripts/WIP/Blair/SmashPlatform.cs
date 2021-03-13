using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPlatform : MonoBehaviour
{
    GameObject mPlayer;
    public GameObject toDestroy;
    private bool isDestroying;
    private float count;
    public float destroyDelay;
    public bool SlowOnContact;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDestroying)
        {
            count += Time.deltaTime;
            if(count > destroyDelay)
            {
                Destroy(toDestroy);
                mPlayer.GetComponent<PlayerMobileController>().TakeDamage(0.1f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(SlowOnContact)
            collision.gameObject.SendMessage("HitSlow");
            
            isDestroying = true;
        }
    }
}
