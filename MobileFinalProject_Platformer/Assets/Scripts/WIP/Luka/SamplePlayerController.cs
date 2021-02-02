using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerController : MonoBehaviour
{
    public float baseMovementSpeed = 4f;
    private float movementSpeed;
    private bool isSlowed;
    private float slowCount;
    public SpawnManager spawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = baseMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSlowed)
        {
            slowCount += Time.deltaTime;
            if(slowCount > 3) { EndSlow(); }
        }
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalMovement, 0, verticalMovement));
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }

    private void HitSlow() { if (isSlowed) return;  isSlowed = true; movementSpeed = baseMovementSpeed / 2; }
    private void EndSlow() { isSlowed = false; movementSpeed = baseMovementSpeed; slowCount = 0; }
}
