using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerPrefs : MonoBehaviour
{
    public Text livesText;
    public Toggle fullScreen;

    private int lives = 3;

    void Start()
    {
        // Set the fullscreen toggle from the playerpref settings
        fullScreen.isOn = PlayerPrefsManager.instance.GetFullScreenBool();
    }

    void Update()
    {
        // Update the lives amount
        livesText.text = lives.ToString();
    }

    public void SetLives(int index)
    {
        // Set the lives in the playerprefs (We are adding 1 to the value as the 1st item dropdown box index is 0 & we want it to match the text value in it)
        PlayerPrefsManager.instance.SetPlayerLives(index + 1);
        lives = index + 1;
    }

    public void SetFullScreen()
    {
        // Set the fullscreen mode depending on the toggle status
        PlayerPrefsManager.instance.SetFullScreenBool(fullScreen.isOn);
    }

    public void GetFullScreen()
    {
        // Set the fullscreen toggle from the playerpref settings
        fullScreen.isOn = PlayerPrefsManager.instance.GetFullScreenBool();
    }

    public void GetLives()
    {
        // Get the lives from the playerpref settings
        lives = PlayerPrefsManager.instance.GetPlayerLives();
    }

    public void ResetLives()
    {
        // Reset the lives value
        lives = 3;
    }
}
