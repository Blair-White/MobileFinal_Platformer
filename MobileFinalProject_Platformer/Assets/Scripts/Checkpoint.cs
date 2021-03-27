using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject Saver;
    private GameObject Score;
    public float PlayerLoadRotation;
    // Start is called before the first frame update
    void Start()
    {
        Saver = GameObject.Find("SaveLoad");
        Score = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointReached()
    {
        float x, y, z, rot;
        x = this.transform.position.x; y = this.transform.position.y; z = this.transform.position.z;
        rot = PlayerLoadRotation;
        int s = Score.GetComponent<PlayerMobileController>().mScore;
        
        SaveBehaviour.instance.SaveAll(x, y, z, rot, s);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            CheckpointReached();
            Debug.Log("CheckPoint Hit");
        }
    }
}
