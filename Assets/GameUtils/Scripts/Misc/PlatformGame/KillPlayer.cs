using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Deduct point from the player if killed ?
    //public int pointDeduction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Respawn the player
            FindObjectOfType<PlayerRespawn>().Respawn();
            // Play sound
            // Remove a life
            // Remove points ?
        }
    }
}
