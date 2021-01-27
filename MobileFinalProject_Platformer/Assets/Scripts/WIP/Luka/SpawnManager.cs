using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    LevelSegmentSpawner levelSegmentSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        levelSegmentSpawner = GetComponent<LevelSegmentSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        levelSegmentSpawner.MoveSegment();
    }
}
