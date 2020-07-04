using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    // This class allows you to store your optins data in a list so if you had a load of mini games you could load and save the data using this method

    #region Public Variables
    public static GameDataManager instance;     // Static reference of the game data manager
    [Header("Options Data To Store")]
    public string saveFileName;                 // Save file name
    public List<GameDataManagerOptionsData> optionsData = new List<GameDataManagerOptionsData>();   // List to store the save data in
    public int selectedGameIndex = 0;           // List selected index
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
        DontDestroyOnLoad(gameObject);
        // Load options data
        LoadOptionsData();
    }
    #endregion

    #region Load And Save The Data
    public void LoadOptionsData()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName + ".cws";      // Set the name and file path of our save file
  
        if (File.Exists(filePath))                                                           // Check if save file exists
        {
            BinaryFormatter bf = new BinaryFormatter();                                      // Create a binary formater
            FileStream file = File.Open(filePath, FileMode.Open);                            // Open the save file
            optionsData = (List<GameDataManagerOptionsData>)bf.Deserialize(file);            // Deserialize and read the data from file
            file.Close();                                                                    // Close the file  
        }
        else
        {
            SaveOptionsData();                                                               // If no save data exits create a new one
        }
    }

    public void SaveOptionsData()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName + ".cws";      // Set the name and file path of our save file
        BinaryFormatter bf = new BinaryFormatter();                                          // Create a binary formater 
        FileStream file = File.Create(filePath);                                             // Create the save file
        bf.Serialize(file, optionsData);                                                     // Serialize and write the data to file
        file.Close();                                                                        // Close the file
    }
    #endregion

    #region Unlock Game
    public void unlockGame()
    {
        // Unlock the next game, for some reason ++ is not working so went with + 1.
        optionsData[selectedGameIndex + 1].isLocked = false;
        // Save the new data so we can load it when ever we need it again
        SaveOptionsData();
    }
    #endregion
}

