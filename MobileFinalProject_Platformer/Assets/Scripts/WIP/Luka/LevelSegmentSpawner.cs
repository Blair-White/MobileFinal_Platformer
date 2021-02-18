using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelSegmentSpawner : MonoBehaviour
{
    public List<GameObject> levelSegment;
    private float offset = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        if(levelSegment != null && levelSegment.Count > 0)
        {
            levelSegment = levelSegment.OrderBy(l => l.transform.position.z).ToList();
        }
    }

    public void MoveSegment()
    {
        GameObject moveSegement = levelSegment[0];
        levelSegment.Remove(moveSegement);
        float newZ = levelSegment[levelSegment.Count - 1].transform.position.z + offset;
        moveSegement.transform.position = new Vector3(0, 0, newZ);
        levelSegment.Add(moveSegement);
    }
}
