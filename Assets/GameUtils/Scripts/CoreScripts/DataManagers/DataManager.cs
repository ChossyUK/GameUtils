using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    // Note i am using 2 options screens in the menu test screen as an example of using multiple options menus in a single scene
    // You can add/delete your save data options below in the CreateOptionsSave method & LoadOptionsData() method
    // Dont forget if adding new options you also need to add them to the DataManagerSaveOptions class file

    #region Public Variables
    public static DataManager instance;                 // Static reference of the data manager
    [Header("Options Data To Store")]
    public OptionsMenu optionsMenuMain;                 // Options menu to set the vsync status in not need if not using the set vysc options
    public OptionsMenu optionsMenuGame;                 // Options menu to set the vsync status in not need if not using the set vysc options
    public Slider masterVolumeSlider;                   // Slider for music volume level
    public Slider musicVolumeSlider;                    // Slider for music volume level
    public Slider sfxVolumeSlider;                      // Slider for sound effects volume level
    public Dropdown resolutionDropdown;                 // Resolution quality dropdown box
    public Dropdown qualityDropdown;                    // Graphics quality dropdown box
    public Dropdown shadowsDropdown;                    // Shadow quality dropdown box
    public Dropdown antiAliasingDropdown;               // AntiAliasing quality dropdown box
    public Toggle fullScreen;                           // Fullscreen toggle
    public Toggle vSync;                                // Vsync toggle

    [Header("Save Data Type")]
    public string saveFileName;                         // Save file name
    public bool saveAsJSON;                             // Save as JSON file type
    #endregion

    #region Unity Base Methods
    void Awake()
    {
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(this.gameObject);

        // Load options data
        LoadOptionsData();

        // Set the vsync status in the options menus not need if not using the set vysc options
        optionsMenuMain.SetVsync(optionsMenuMain.vSync);
        optionsMenuGame.SetVsync(optionsMenuGame.vSync);
    }
    #endregion

    #region Create The Save File Options
    private DataManagerSaveOptions CreateOptionsSave()                      // Create the options data to be saved to json file
    {
        DataManagerSaveOptions save = new DataManagerSaveOptions();         // Create a new save object

        save.masterVolume = masterVolumeSlider.value;                       // Set the master volume level
        save.musicVolume = musicVolumeSlider.value;                         // Set the music volume level
        save.sfxVolume = sfxVolumeSlider.value;                             // Set the sfx volume level
        save.screenResoltion = resolutionDropdown.value;                    // Set the screen resolution index
        save.graphicsQuality = qualityDropdown.value;                       // Set the graphical quality index
        save.shadowQuality = shadowsDropdown.value;                         // Set the shadow quality index
        save.antiAliasingQuality = antiAliasingDropdown.value;              // Set the antialiasing quality index
        save.isFullscreen = fullScreen.isOn;                                // Set the fullscreen toggle
        save.vSyncEnabled = vSync.isOn;                                     // Set the vSync toggle

        return save;                                                        // Return the above data to be saved to a file
    }
    #endregion

    #region Load And Save The Data
    public void LoadOptionsData()
    {
        if(saveAsJSON)
        {
            string filePath = Application.persistentDataPath + "/" + saveFileName + ".json";      // Set the name and file path of our save file

            // Check is save data exists
            if (File.Exists(filePath))                                                               
            {                
                string dataAsJson = File.ReadAllText(filePath);                                             // Read the data from the save file
                DataManagerSaveOptions save = JsonUtility.FromJson<DataManagerSaveOptions>(dataAsJson);     // Pass the save data to a new save data object to read from and set the options varibles
           
                masterVolumeSlider.value = save.masterVolume;                                               // Set the master volume level
                musicVolumeSlider.value = save.musicVolume;                                                 // Set the music slider value
                sfxVolumeSlider.value = save.sfxVolume;                                                     // Set the sfx volume level
                resolutionDropdown.value = save.screenResoltion;                                            // Set the screen resolution value
                qualityDropdown.value = save.graphicsQuality;                                               // Set the graphical quality value
                shadowsDropdown.value = save.shadowQuality;                                                 // Set the shadow quality value
                antiAliasingDropdown.value = save.antiAliasingQuality;                                      // Set the antialiasing quality value
                fullScreen.isOn = save.isFullscreen;                                                        // Set the fullscreen toggle
                vSync.isOn = save.vSyncEnabled;                                                             // Set the vSync toggle             
            }
            else
            {
                SaveOptionsData();      // If no save data exits create a new one
            }
        }
        else
        {
            string filePath = Application.persistentDataPath + "/" + saveFileName + ".bin";         // Set the name and file path of our save file

            if (File.Exists(filePath))
            {
                BinaryFormatter bf = new BinaryFormatter();                                         // Create a binary formater
                FileStream file = File.Open(filePath, FileMode.Open);                               // Open the save file
                DataManagerSaveOptions save = (DataManagerSaveOptions)bf.Deserialize(file);         // Deserialize and read the data from file
                file.Close();                                                                       // Close the file

                masterVolumeSlider.value = save.masterVolume;                                       // Set the master volume level
                musicVolumeSlider.value = save.musicVolume;                                         // Set the music slider value
                sfxVolumeSlider.value = save.sfxVolume;                                             // Set the sfx volume level
                resolutionDropdown.value = save.screenResoltion;                                    // Set the screen resolution value
                qualityDropdown.value = save.graphicsQuality;                                       // Set the graphical quality value
                shadowsDropdown.value = save.shadowQuality;                                         // Set the shadow quality value
                antiAliasingDropdown.value = save.antiAliasingQuality;                              // Set the antialiasing quality value
                fullScreen.isOn = save.isFullscreen;                                                // Set the fullscreen toggle
                vSync.isOn = save.vSyncEnabled;                                                     // Set the vSync toggle
            }
            else
            {
                SaveOptionsData();      // If no save data exits create a new one
            }
        }
    }

    public void SaveOptionsData()
    {
        if (saveAsJSON)
        {
            string filePath = Application.persistentDataPath + "/" + saveFileName + ".json";     // Set the name and file path of our save file
            DataManagerSaveOptions save = CreateOptionsSave();                                   // Get the save data required
            string dataAsJson = JsonUtility.ToJson(save);                                        // Convert save data to json format
            File.WriteAllText(filePath, dataAsJson);                                             // Save the data to file
        }
        else
        {
            string filePath = Application.persistentDataPath + "/" + saveFileName + ".bin";      // Set the name and file path of our save file
            DataManagerSaveOptions save = CreateOptionsSave();                                   // Get the save data required
            BinaryFormatter bf = new BinaryFormatter();                                          // Create a binary formater 
            FileStream file = File.Create(filePath);                                             // Create the save file
            bf.Serialize(file, save);                                                            // Serialize and write the data to file
            file.Close();                                                                        // Close the file
        }
    }
    #endregion

}
