using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    #region Menu UI Variables
    [Header("Sliders")]
    // Volume sliders
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    [Header("Dropdowns")]
    // Screen option dro[downs
    public Dropdown resolutionDropdown;             
    public Dropdown qualityDropdown;
    public Dropdown shadowsDropdown;
    public Dropdown antiAliasingDropdown;

    [Header("Toggles")]
    public Toggle fullScreen;
    public Toggle vSync;
    #endregion

    #region Generic Menu Variables
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    // Choice of data manager comment out the one you do not wish to use
    [Header("Data Manager")]
    public DataManager dataManager;
    //public GameDataManager gameDataManager;

    private Resolution[] resolutions;
    #endregion

    #region Unity Base Methods
    private void Start()
    {
        #region Game Data Manager Settings
        //masterVolumeSlider.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].masterVolume;
        //musicVolumeSlider.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume;
        //sfxVolumeSlider.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].sfxVolume;
        //resolutionDropdown.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].screenResoltion;
        //qualityDropdown.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].graphicsQuality;
        //shadowsDropdown.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].shadowQuality;
        //antiAliasingDropdown.value = gameDataManager.optionsData[gameDataManager.selectedGameIndex].antiAliasingQuality;
        //fullScreen.isOn = gameDataManager.optionsData[gameDataManager.selectedGameIndex].isFullscreen;
        //vSync.isOn = gameDataManager.optionsData[gameDataManager.selectedGameIndex].vSyncEnabled;
        #endregion

        #region Data Manager Settings
        masterVolumeSlider.value = dataManager.masterVolumeSlider.value;
        musicVolumeSlider.value = dataManager.musicVolumeSlider.value;
        sfxVolumeSlider.value = dataManager.sfxVolumeSlider.value;
        resolutionDropdown.value = dataManager.resolutionDropdown.value;
        qualityDropdown.value = dataManager.qualityDropdown.value;
        shadowsDropdown.value = dataManager.shadowsDropdown.value;
        antiAliasingDropdown.value = dataManager.antiAliasingDropdown.value;
        fullScreen = dataManager.fullScreen;
        vSync = dataManager.vSync;
        #endregion

        AudioManager.instance.SetMusicVolume(musicVolumeSlider.value);
        //AudioManager.instance.musicVolume = gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume;
        AudioManager.instance.musicVolume = dataManager.musicVolumeSlider.value;
    }
    #endregion

    #region Screen Options
    // Dynamic screen resolution method
    public void PopulateResolution(int resolutionIndex)
    {
        resolutions = Screen.resolutions;
        Array.Reverse(resolutions, 0, resolutions.Length);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        
        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].screenResoltion = resolutionIndex;
        dataManager.resolutionDropdown.value = resolutionIndex;
    }

    // Fixed screen resolution method
    public void SetScreenResolution(int resolutionIndex)
    {
        switch (resolutionIndex)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            default:
                break;
        }

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].screenResoltion = resolutionIndex;
        dataManager.resolutionDropdown.value = resolutionIndex;
    }

    // Untested Method
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].graphicsQuality = qualityIndex;
        dataManager.qualityDropdown.value = qualityIndex;
    }

    // Untested Method
    public void SetShadows(int qualityIndex)
    {
        switch (qualityIndex)
        {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.High;
                break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            default:
                break;
        }

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].shadowQuality = qualityIndex;
        dataManager.shadowsDropdown.value = qualityIndex;
    }

    // Untested Method
    public void SetAntiAliasing(int qualityIndex)
    {
        switch (qualityIndex)
        {
            case 0:
                QualitySettings.antiAliasing = 8;
                break;
            case 1:
                QualitySettings.antiAliasing = 4;
                break;
            case 2:
                QualitySettings.antiAliasing = 2; ;
                break;
            default:
                break;
        }

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].antiAliasingQuality = qualityIndex;
        dataManager.antiAliasingDropdown.value = qualityIndex;
    }

    //
    public void SetFullScreen(bool fullScreenEnabled)
    {
        Screen.fullScreen = fullScreenEnabled;

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].isFullscreen = fullScreenEnabled;
        dataManager.fullScreen.isOn = fullScreenEnabled;
    }

    //
    public void SetVsync(bool setVsync)
    {
        if (setVsync)
        {
            QualitySettings.vSyncCount = 1;                 // Set the vsync rate 1 = 60fps
        }
        else
        {
            QualitySettings.vSyncCount = 0;                 // Disable vsync
        }

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].vSyncEnabled = setVsync;
        dataManager.vSync.isOn = setVsync;
    }

    //
    public void SetVsync(int i)
    {
        switch(i)
        {
            // 60 fps
            case 0:
                QualitySettings.vSyncCount = 1;
                break;
            // 30 fps
            case 1:
                QualitySettings.vSyncCount = 2;
                break;
            // No vSync
            case 2:
                QualitySettings.vSyncCount = 0;
                break;

            default:
                break;
        }
        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].vSync = i;
        //dataManager.vSyncInt = i;
    }
    #endregion

    #region Audio Options
    //
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].masterVolume = volume;
        dataManager.masterVolumeSlider.value = volume;
    }

    //
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume = volume;
        dataManager.musicVolumeSlider.value = volume;
    }

    //
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);

        //gameDataManager.optionsData[gameDataManager.selectedGameIndex].sfxVolume = volume;
        dataManager.sfxVolumeSlider.value = volume;
    }
    #endregion

    #region User Methods
    // Comment out the options you do not wish to use
    public void ApplySettings()
    {
        PopulateResolution(resolutionDropdown.value);
        //SetScreenResolution(resolutionDropdown.value);
        SetQuality(qualityDropdown.value);
        SetShadows(shadowsDropdown.value);
        SetAntiAliasing(antiAliasingDropdown.value);
        //SetVsync(vsyncDropdown.value);
        SetFullScreen(fullScreen.isOn);
        SetVsync(vSync.isOn);

        //gameDataManager.SaveOptionsData();
        dataManager.SaveOptionsData();
    }
    #endregion

}