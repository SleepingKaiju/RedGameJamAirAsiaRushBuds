using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Rigidbody2D rb;

    public bool isPicked;

    public Sprite clickedSprite;
    public Sprite originalSprite;

    public AudioSource pickAudioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;  // Ensure Rigidbody2D is kinematic initially
        }
    }

    void OnMouseDown()
    {
        // Start dragging
        isDragging = true;

        isPicked = true;

        // Detach from parent if any
        transform.SetParent(null);

        // Enable Rigidbody2D
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        GetComponent<SpriteRenderer>().sprite = clickedSprite;

        GetComponent<SpriteRenderer>().sortingOrder = 10;

        pickAudioSource.Play();

    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = originalSprite;
        // Stop dragging
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {

            // Update object's position to follow the mouse cursor
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z position is zero for 2D objects
            transform.position = mousePosition;
        }
    }
}