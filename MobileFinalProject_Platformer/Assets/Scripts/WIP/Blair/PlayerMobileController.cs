using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileController : MonoBehaviour
{
    public float baseMovementSpeed = 14f;
    private float movementSpeed;
    private bool isSlowed, isMoving, isIdle, isSliding;
    private float slowCount;
    public SpawnManager spawnManager;
    private enum MoveDirections { forward, left, right, back  }//based on starting position + Z is forward
    private MoveDirections moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = baseMovementSpeed;
        moveDirection = MoveDirections.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle) return;

        if (isSlowed)
        {
            slowCount += Time.deltaTime;
            if (slowCount > 3) { EndSlow(); }
        }

        if (isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A))) { Swiped("left"); }
            if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D))) { Swiped("right"); }
            Move();
        }
            
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
   
    }

    private void Move()
    {
        switch (moveDirection)
        {
            case MoveDirections.forward:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementSpeed * Time.deltaTime);
                break;
            case MoveDirections.left:
                transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                break;
            case MoveDirections.right:
                transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                break;
            case MoveDirections.back:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movementSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
        
    }
    private void Swiped(string Direction)
    {
        if (isSliding) return;
        
        switch (Direction)
        {
            case "left":
                this.gameObject.GetComponent<Rigidbody>().AddForce(-10f, 0, 0, ForceMode.Impulse);
                break;
            case "right":
                this.gameObject.GetComponent<Rigidbody>().AddForce(10f, 0, 0, ForceMode.Impulse );
                break;
            default:
                break;
        }
    }


    private void GameStart() { isMoving = true; }
    private void HitSlow() { if (isSlowed) return; isSlowed = true; movementSpeed = baseMovementSpeed / 2; }
    private void EndSlow() { isSlowed = false; movementSpeed = baseMovementSpeed; slowCount = 0; }
}
