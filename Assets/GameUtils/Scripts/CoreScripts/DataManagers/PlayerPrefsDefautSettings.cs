using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDefautSettings : MonoBehaviour
{
    // Set your default player pref options below
    void Start()
    {      
        #region Audio Options
        if (!PlayerPrefs.HasKey("Master_Volume"))
        {
            // Set the master volume level to max volume
            PlayerPrefsManager.instance.SetMasterVolume(0);
        }

        if (!PlayerPrefs.HasKey("Music_Volume"))
        {
            // Set the music volume level to max volume
            PlayerPrefsManager.instance.SetMusicVolume(0);
        }

        if (!PlayerPrefs.HasKey("SoundEffects Volume"))
        {
            // Set the sound effects volume level to max volume
            PlayerPrefsManager.instance.SetSoundEffectsVolume(0);
        }
        #endregion

        #region Video Options
        if (!PlayerPrefs.HasKey("Screen Resoltion"))
        {
            // Set the screen resoultion to the 1st item in the dropdown
            PlayerPrefsManager.instance.SetResoultionIndex(0);
        }

        if (!PlayerPrefs.HasKey("Graphics Quality"))
        {
            // Set the grapical quality to the 1st item in the dropdown
            PlayerPrefsManager.instance.SetGraphicsIndex(0);
        }

        if (!PlayerPrefs.HasKey("Shadow Quality"))
        {
            // Set the shadow quality to the 1st item in the dropdown
            PlayerPrefsManager.instance.SetShadowsIndex(0);
        }

        if (!PlayerPrefs.HasKey("Anti Alias Quality"))
        {
            // Set the antialiasing quality to the 1st item in the dropdown
            PlayerPrefsManager.instance.SetAntiAliasingIndex(0);
        }

        if (!PlayerPrefs.HasKey("FullScreen_Enabled"))
        {
            // Use if using a toggle for the fullscreen option this will set it to true by default
            PlayerPrefsManager.instance.SetFullScreenBool(true);

            // Use if using a dropdown for the fullscreen option this will set it to true by default
            //PlayerPrefsManager.instance.SetFullScreenInt(0);
        }

        if (!PlayerPrefs.HasKey("VSync_Enabled"))
        {
            // Use if using a toggle for the vsync option this will set it to true by default
            PlayerPrefsManager.instance.SetVsyncBool(true);

            // Use if using a dropdown for the vsync option this will set it to true by default
            //PlayerPrefsManager.instance.SetVsyncInt(0);
        }
        #endregion

        #region Game Options
        if (!PlayerPrefs.HasKey("Player_Lives"))
        {
            // Set the player lives you should get this value from your game controller and dont use 0
            PlayerPrefsManager.instance.SetPlayerLives(0);
        }

        if (!PlayerPrefs.HasKey("Player_Score"))
        {
            // Set the default score to 0
            PlayerPrefsManager.instance.SetScore(0);
        }

        if (!PlayerPrefs.HasKey("Game_HighScore"))
        {
            // Set the default highscore 0
            PlayerPrefsManager.instance.SetHighScore(0);
        }
        #endregion
    }
}
