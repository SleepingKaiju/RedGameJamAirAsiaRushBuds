using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlideStop : MonoBehaviour
{
    public float moveDistance = 5f;  // Distance to move in one cycle
    public float moveSpeed = 2f;     // Speed of movement
    public float stopDuration = 2f;  // Duration to stop before moving again

    private Vector3 startPos;
    private Vector3 targetPos;
    public bool moving = true;
    private float stopTimer = 0f;

    public AudioSource swooshSFX;

    



    void Start()
    {
        if(gameManager.playerLevel == 1)
        {
            moveSpeed = 6f;
        }
        if (gameManager.playerLevel == 2)
        {
            moveSpeed = 10f;
        }
        if (gameManager.playerLevel == 3)
        {
            moveSpeed = 15f;
        }


        startPos = transform.position;
        targetPos = startPos - transform.right * moveDistance; // Move left
    }

    void Update()
    {
        if (moving)
        {
            MoveObjectLeft();
        }
        else
        {
            StopObject();
        }

        if (!moving) { StopObject(); }

    }

    void MoveObjectLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            swooshSFX.Play();
            moving = false;
            stopTimer = 0f;
        }
    }

    void StopObject()
    {
        stopTimer += Time.deltaTime;

        if (stopTimer >= stopDuration)
        {
            moving = true;

            // Update start and target positions for the next move
            startPos = targetPos;
            targetPos = startPos - transform.right * moveDistance;
        }
    }
}