using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameMenuOptions : MonoBehaviour
{
    [Header("Menu Elements")]
    public Slider masterVolumeSlider;                   // Slider for music volume level
    public Slider musicVolumeSlider;                    // Slider for music volume level
    public Slider sfxVolumeSlider;                      // Slider for sound effects volume level
    public Dropdown resolutionDropdown;                 // Resolution quality dropdown box
    public Dropdown qualityDropdown;                    // Graphics quality dropdown box
    public Dropdown shadowsDropdown;                    // Shadow quality dropdown box
    public Dropdown antiAliasingDropdown;               // AntiAliasing quality dropdown box
    public Toggle fullScreen;                           // Fullscreen toggle
    public Toggle vSync;                                // Vsync toggle 

    [Header("DataManager")]
    public DataManager dataManager;

    public void SetObjects()
    {
        dataManager.masterVolumeSlider = masterVolumeSlider;
        dataManager.musicVolumeSlider = musicVolumeSlider;
        dataManager.sfxVolumeSlider = sfxVolumeSlider;
        dataManager.resolutionDropdown = resolutionDropdown;
        dataManager.qualityDropdown = qualityDropdown;
        dataManager.shadowsDropdown = shadowsDropdown;
        dataManager.antiAliasingDropdown = antiAliasingDropdown;
        dataManager.fullScreen = fullScreen;
        dataManager.vSync = vSync;
    }

}
