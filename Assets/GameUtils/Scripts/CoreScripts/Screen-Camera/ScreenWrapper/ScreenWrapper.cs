using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

    // The screen boundries
    [Header("ScreenWrap Bounds")]
    public float top;
    public float bottom;
    public float left;
    public float right;

	void Update ()
    {
        // Get the current position
        Vector2 currentPosition = transform.position;

        // If our current position is greater than the top boundry move us to the bottom boundry
        if (transform.position.y > top)
        {
            currentPosition.y = bottom;
        }

        // If our current position is less than the bottom boundry move us to the top boundry
        if (transform.position.y < bottom)
        {
            currentPosition.y = top;
        }

        // If our current position is greater than the right boundry move us to the left boundry
        if (transform.position.x > right)
        {
            currentPosition.x = left;
        }

        // If our current position is less than the left boundry move us to the right boundry
        if (transform.position.x < left)
        {
            currentPosition.x = right;
        }

        // Set the current position
        transform.position = currentPosition;
    }
}
