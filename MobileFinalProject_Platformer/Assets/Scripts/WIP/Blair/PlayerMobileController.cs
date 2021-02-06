using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileController : MonoBehaviour
{
    public float baseMovementSpeed, swipeForce;
    private float movementSpeed;
    private bool isSlowed, isMoving, isIdle, isSliding, isGrounded;
    public bool isRotating;
    private float slowCount, rotateCount;
    public SpawnManager spawnManager;
    public enum MoveDirections { forward, left, back, right  }//based on starting position + Z is forward
    public MoveDirections moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = baseMovementSpeed;
        moveDirection = MoveDirections.forward;
        isGrounded = true;
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
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.Space))) { Swiped("up"); }

            Move();
        }

    }


    private void FixedUpdate()
    {
       
        if (isRotating)
        {
            rotateCount += Time.deltaTime;
            if (rotateCount > .89f) { isRotating = false; rotateCount = 0; }
            transform.Rotate(0.0f, -2f, 0.0f, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
   
    }

    private void Move()
    {
         transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
    private void Swiped(string Direction)
    {
        if (isSliding) return;
        
        switch (Direction)
        {
            case "left":
                transform.Translate(Vector3.left * 20);
                break;
            case "right":
                transform.Translate(Vector3.right * 20);
                break;
            case "up":
                if(isGrounded)
                    this.GetComponent<Rigidbody>().AddForce(0, 222, 0, ForceMode.Impulse);
                break;
            default:
                break;
        }
    }

    private void ChangeDirection(MoveDirections current)
    {
        switch (current)
        {
            case MoveDirections.forward:
                moveDirection = MoveDirections.left;
                break;
            case MoveDirections.left:
                moveDirection = MoveDirections.back;
                break;
            case MoveDirections.back:
                moveDirection = MoveDirections.right;
                break;
            case MoveDirections.right:
                moveDirection = MoveDirections.forward;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "TurnCollider")
        {
            //temp
            if (!isRotating) { isRotating = true; ChangeDirection(moveDirection); }
        }
        if (collision.gameObject.tag == "Platform")
            if (!isGrounded) isGrounded = true;

    }


    private void GameStart() { isMoving = true; }
    private void HitSlow() { if (isSlowed) return; isSlowed = true; movementSpeed = baseMovementSpeed / 2; }
    private void EndSlow() { isSlowed = false; movementSpeed = baseMovementSpeed; slowCount = 0; }
}
