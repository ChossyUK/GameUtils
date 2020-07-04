using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusicSlider : MonoBehaviour
{
    public Slider slider;
    
    // Use the list type data manager
    public GameDataManager gameDataManager;

    private void Start()
    {
        try
        {
            // Set the slider value to the value stored in the lists selected game index 
            slider.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume;

            // Set the volume level and the audio manager music volume variable
            AudioManager.instance.SetMusicVolume(slider.value);
            AudioManager.instance.musicVolume = slider.value;         
        }
        catch
        {
            Debug.Log("Something went wrong !!!");
        }
    }

    public void SetMusicVolume(float value)
    {
        // Set the slider value
        slider.value = value;

        // Set the volume level and the audio manager music volume variable
        AudioManager.instance.SetMusicVolume(value);
        AudioManager.instance.musicVolume = value;

        // Set the volume level in the data manager list and save it
        gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume = slider.value;
        gameDataManager.SaveOptionsData();
    }


    // As we are not using a menu to set the volume level we will enable/disable the slider on mouse pointer events
    // In the slider via the inspector
    public void SelectSlider()
    {
        slider.enabled = true;
    }

    public void DeselectSlider()
    {
        slider.enabled = false;
    }
}
