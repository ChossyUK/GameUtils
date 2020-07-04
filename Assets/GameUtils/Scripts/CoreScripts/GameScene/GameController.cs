using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Sample game controller class to handle the game logic like lives, scores ect..

    #region Public Variables
    public MenuSwitcher menuSwitcher;
    public DataManager dataManager;
    //public GameDataManager gameDataManager;

    // Use this to disable any input or spawning ect.. before the game starts or delay input after exiting menus
    public static bool inMenu;
    #endregion

    #region Unity Base Methods
    private void Start()
    {
        //AudioManager.instance.SetMasterVolume(gameDataManager.optionsData[gameDataManager.selectedGameIndex].masterVolume);
        //AudioManager.instance.SetMusicVolume(gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume);
        //AudioManager.instance.SetSFXVolume(gameDataManager.optionsData[gameDataManager.selectedGameIndex].sfxVolume);
        //AudioManager.instance.musicVolume = gameDataManager.optionsData[gameDataManager.selectedGameIndex].musicVolume;

        AudioManager.instance.SetMasterVolume(dataManager.masterVolumeSlider.value);
        AudioManager.instance.SetMusicVolume(dataManager.musicVolumeSlider.value);
        AudioManager.instance.SetSFXVolume(dataManager.sfxVolumeSlider.value);
        AudioManager.instance.musicVolume = dataManager.musicVolumeSlider.value;

        OpenMainMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenPauseMenu();
        }
    }

    private void FixedUpdate()
    {

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }
    #endregion

    #region Core Gameplay Methods
    // Add your core game play methods below



    public void QuitGame()
    {
        Application.Quit();
    }

    private void ResetMenuBool()
    {
        inMenu = false;
    }
    #endregion

    #region Menu Methods
    // Add or remove open/close menu methods below
    public void OpenMainMenu()
    {
        inMenu = true;
        menuSwitcher.OpenMainMenu();
        Time.timeScale = 0;
    }

    public void CloseMainMenu()
    {
        menuSwitcher.CloseMainMenu();
        Time.timeScale = 1;
    }

    public void OpenPauseMenu()
    {
        inMenu = true;
        menuSwitcher.OpenPauseMenu();
        Time.timeScale = 0;
    }

    public void ClosePauseMenu()
    {
        menuSwitcher.ClosePauseMenu();
        Time.timeScale = 1;
    }

    public void OpenOptionsMain()
    {
        inMenu = true;
        menuSwitcher.OpenOptionsMenu();
        Time.timeScale = 0;
    }

    public void CloseOptionsMain()
    {
        menuSwitcher.CloseOptionsMenu();
        Time.timeScale = 1;
    }

    public void OpenOptionsGame()
    {
        inMenu = true;
        menuSwitcher.OpenOptionsGame();
        Time.timeScale = 0;
    }

    public void CloseOptionsGame()
    {
        menuSwitcher.CloseOptionsGame();
        Time.timeScale = 1;
    }

    public void ResetMenu()
    {
        Invoke("ResetMenuBool", 0.5f);
    }

    #endregion
}
