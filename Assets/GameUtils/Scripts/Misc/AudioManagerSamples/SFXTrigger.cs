using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    // Sfx audio clip & bool to set trigger behavior
    public AudioClip sfx;
    public bool playOnce = false;

    private bool sfxPlayed = false;
    private AudioManager audioManager;


    // Reset the play once trigger
    public void ResetTrigger()
    {
        sfxPlayed = false;
    }

    // Trigger the sfx
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the audio manager
        audioManager = FindObjectOfType<AudioManager>();

        if (collision.tag == "Player")
        {
            // Play sfx when entering trigger zone
            if (!playOnce)
            {
                if (sfx != null)
                    audioManager.PlaySFXOneShot(sfx);
            }
            // Play sfx when entering trigger zone once only
            else if (playOnce && !sfxPlayed)
            {
                if (sfx != null)
                    audioManager.PlaySFXOneShot(sfx);
                sfxPlayed = true;
            }
        }
    }
}
