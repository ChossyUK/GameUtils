using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour {

    // The music track you want to play
    public AudioClip music;

    // The fade in duration
    public float fadeDuration = 1.5f;

    // Set to loop the music track
    public bool loopMuisc = false;

    // Set to use the fade effect
    public bool useFade;

    // Audio manager reference
    private AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the audio manager
        audioManager = FindObjectOfType<AudioManager>();

        // Set the loop music option
        audioManager.loopMusic = loopMuisc;

        if (collision.tag == "Player")
        {
            // Check if the audio clip is blank
            if (music != null)
            {
                if (useFade)
                {
                    // If using fade run the audio mangager fade bgm method
                    audioManager.FadeBGM(music, fadeDuration / 2);
                }
                else
                {
                    // If not using fade just swap the music track
                    audioManager.ChangeBGM(music);
                }
            }
        }
    }
}
