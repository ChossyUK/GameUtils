using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateResolutions : MonoBehaviour {

    [Header("Load Data Settings")]
    // Comment out the type of data manager you do not want to use
    public DataManager dataManager;
    //public GameDataManager dataManager;
    public Dropdown screenResoltion;
    public bool showRefreshRate = false;

    // Array for the screen resoultions
    private Resolution[] resolutions;

    public void Awake()
    {
        // Get the screen resolutions and fill the array
        resolutions = Screen.resolutions;

        // Reverse the array as it get the lowest resolution 1st
        Array.Reverse(resolutions, 0, resolutions.Length);

        // Clear the dropdown box values
        screenResoltion.ClearOptions();

        // Create a new list of strings to store the resolutions in
        List<string> options = new List<string>();

        // Set the resolution index to 0
        int currentResolutionIndex = 0;

        // Loop through the array and add the resolutions to the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Use this mode if not building for UWP
            if (showRefreshRate)
            {               
                string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
                options.Add(option);
                if (resolutions[i].Equals(Screen.currentResolution) && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                {
                    currentResolutionIndex = i;
                }
            }
            else
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].Equals(Screen.currentResolution))
                {
                    currentResolutionIndex = i;
                }
            }
        }

        // Add the list of resolutions to the dropdown
        screenResoltion.AddOptions(options);

        // Refresh the dropdown box
        screenResoltion.RefreshShownValue();

        // Load the options data
        dataManager.LoadOptionsData();
    }
}
