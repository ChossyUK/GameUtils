using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // The current check point
    public GameObject currentCheckPoint;

    // The respawn particle
    //public GameObject respawnParticle;

    // The death Particle
    //public GameObject deathParticle;

    // The respawn delay
    public float respawnDelay;

    // The player controller
    public SimplePlatformController2D player;


    // Respawn the player
    public void Respawn()
    {
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        // Activate the death particle
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        // Deactivate the player
        player.gameObject.SetActive(false);

        // Reset the player velocity
        player.rb.velocity = Vector2.zero;

        // Check the direction the player is facing and flip it to face right
        if (!player.facingRight)
        {
            player.Flip();
        }

        // wait for the spawn delay
        yield return new WaitForSeconds(respawnDelay);

        // Set the players position to the current check point
        player.transform.position = currentCheckPoint.transform.position;

        // Activate the player
        player.gameObject.SetActive(true);

        // Activate the respawn particle
        //Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
    }
}
