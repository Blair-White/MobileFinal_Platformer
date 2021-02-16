using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMobileController : MonoBehaviour
{
    public float baseMovementSpeed, swipeForce;
    private float movementSpeed, health;
    public GameObject healthbar, score, hscore, currentTurnCollider, mushroomPrefab, gemPrefab, mushroomAmount, gemAmount;
    private int mScore, swipePosition, slideCount, mushroomInt, gemInt;
    private bool isSlowed, isMoving, isIdle, isSlidingLeft, isSlidingRight, isGrounded;
    public bool isRotating;
    private float slowCount, rotateCount;
    public SpawnManager spawnManager;
    public enum MoveDirections { forward, left, back, right  }//based on starting position + Z is forward
    public MoveDirections moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        movementSpeed = baseMovementSpeed;
        moveDirection = MoveDirections.forward;
        isGrounded = true;
        hscore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mScore++;
        score.GetComponent<TextMeshProUGUI>().text = mScore.ToString();
        healthbar.transform.localScale = new Vector3(health, 1, 1);
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
        if(isSlidingLeft) 
        {
            slideCount++;
            if (slideCount == 19)
            {
                isSlidingLeft = false; slideCount = 0;
            }
            transform.Translate(Vector3.left * 1);
        }

        if (isSlidingRight)
        {
            slideCount++;
            if (slideCount == 19)
            {
                isSlidingRight = false; slideCount = 0;
            }
            transform.Translate(Vector3.right * 1);
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
        
        if (isRotating || isSlidingLeft || isSlidingRight) return;
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.SwipeMove, .5f);
        switch (Direction)
        {
            case "left":
                if (swipePosition == -2) return;
                isSlidingLeft = true;
                swipePosition--;
                break;
            case "right":
                if (swipePosition == 2) return;
                isSlidingRight = true;
                swipePosition++;
                break;
            case "up":
                if(isGrounded)
                {
                this.GetComponent<Rigidbody>().AddForce(0, 222, 0, ForceMode.Impulse);
                isGrounded = false;
                }
                
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
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.SwipeMove, .5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "TurnCollider")
        {
            if (collision.gameObject == currentTurnCollider) return;
            //temp
            if (!isRotating) { isRotating = true; ChangeDirection(moveDirection); }
            swipePosition = 0;
            currentTurnCollider = collision.gameObject;
        }
        if (collision.gameObject.tag == "Platform")
        {
            //temp
            health -= 0.1f;
            if (!isGrounded) isGrounded = true;

        }

        if (collision.gameObject.tag == "mushroom")
        {
            Destroy(collision.gameObject);
            mushroomInt++;
            mushroomAmount.GetComponent<TextMeshProUGUI>().text = mushroomInt.ToString();
        }
        
        if(collision.gameObject.tag == "gem")
        {
            Destroy(collision.gameObject);
            gemInt++;
            gemAmount.GetComponent<TextMeshProUGUI>().text = gemInt.ToString();
        }

        if(collision.gameObject.tag == "goal")
        {
            SceneManager.LoadScene(4);
        }

    }


    

    public void SetScore() 
    {
        int sc = PlayerPrefs.GetInt("HighScore");
        if(sc < mScore)
        PlayerPrefs.SetInt("HighScore", mScore); 
    }
    private void GameStart() { isMoving = true; }
    private void HitSlow() 
    {
        if (isSlowed) return; 
        isSlowed = true;
        movementSpeed = baseMovementSpeed / 2;
        Soundmanager.instance.PlaySoundOneShot(Soundmanager.instance.Slowed, .5f);
    }
    private void EndSlow() { isSlowed = false; movementSpeed = baseMovementSpeed; slowCount = 0; }
}
