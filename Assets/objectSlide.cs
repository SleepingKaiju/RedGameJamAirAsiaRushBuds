using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSlide : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the movement
    private bool isPaused = false; // Flag to check if the movement is paused

    void Update()
    {
        if (!isPaused)
        {
            // Move the object from right to left
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    // Function to pause the movement
    public void Pause()
    {
        isPaused = true;
    }

    // Function to resume the movement
    public void Resume()
    {
        isPaused = false;
    }
}
