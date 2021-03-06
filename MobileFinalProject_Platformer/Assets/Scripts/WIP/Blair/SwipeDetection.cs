﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = true;
    private GameObject player;
    public float SWIPE_THRESHOLD = 20f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

  
    void OnSwipeUp()
    {
        if (!Soundmanager.instance.InvertedControls)
        {
            player.SendMessage("Swiped", "up");
        }
        
    }

    void OnSwipeDown()
    {
        if (Soundmanager.instance.InvertedControls)
        {
            player.SendMessage("Swiped", "up");
        }
     
        Debug.Log("Swipe Down");
    }

    void OnSwipeLeft()
    {
       
        if (!Soundmanager.instance.InvertedControls)
        {
            Debug.Log("Swipe Left");
            player.SendMessage("Swiped", "left");
        }
        else
        {
            Debug.Log("Swipe Right");
            player.SendMessage("Swiped", "right");
        }
            
    }

    void OnSwipeRight()
    {
       
        if (Soundmanager.instance.InvertedControls)
        {
            Debug.Log("Swipe Right");
            player.SendMessage("Swiped", "left");
        }
        else
        {
            Debug.Log("Swipe Left");
            player.SendMessage("Swiped", "right");
        }
        Debug.Log("Swipe Right");
    }
}
