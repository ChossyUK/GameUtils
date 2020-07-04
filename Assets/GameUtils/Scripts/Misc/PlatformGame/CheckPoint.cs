using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // New image to show when the check point has been triggered
    public Sprite triggeredSprite;

    // Bool to check if the check point has been triggered
    public bool isTriggered = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            // If the check point has not been triggered
            if (!isTriggered)
            {
                // Set the current check point in the PlayerRespawn object
                FindObjectOfType<PlayerRespawn>().currentCheckPoint = gameObject;

                // Get the sprite renderer attached to the game object
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();

                // Set the new triggered image
                sprite.sprite = triggeredSprite;

                // Set the check poin as triggered so we dont keep reseting it everytime we pass through a check point
                isTriggered = true;

                // Play Sound ?
            }
        }
    }
}
