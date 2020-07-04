using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static PlayerPrefsManager instance;

    #region PlayerPref Keys
    const string Master_Volume_Key = "Master_Volume";
    const string Music_Volume_Key = "Music_Volume";
    const string Sound_Effects_Volume_Key = "SoundEffects_Volume";
    const string Screen_Resoltion_Key = "Screen_Resoltion";
    const string Graphics_Quality_Key = "Graphics_Quality";
    const string Shadow_Quality_Key = "Shadow_Quality";
    const string Anti_Aliasing_Quality = "Anti_Alias_Quality";
    const string Player_Lives = "Player_Lives";
    const string Player_Score = "Player_Score";
    const string Game_HighScore = "Game_HighScore";
    const string FullScreen_Enabled = "FullScreen_Enabled";
    const string VSync_Enabled = "VSync_Enabled";
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
    }
    #endregion

    #region Music Volume Options
    public void SetMasterVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(Master_Volume_Key, volume);
        }
    }

    public void SetSoundEffectsVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(Sound_Effects_Volume_Key, volume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (volume >= -80f && volume <= 0f)
        {
            PlayerPrefs.SetFloat(Sound_Effects_Volume_Key, volume);
        }
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(Master_Volume_Key);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(Music_Volume_Key);
    }

    public float GetSoundEffectsVolume()
    {
        return PlayerPrefs.GetFloat(Sound_Effects_Volume_Key);
    }
    #endregion

    #region Video Options
    public void SetResoultionIndex(int index)
    {
        PlayerPrefs.SetInt(Screen_Resoltion_Key, index);
    }

    public void SetGraphicsIndex(int index)
    {
        PlayerPrefs.SetInt(Graphics_Quality_Key, index);
    }

    public void SetShadowsIndex(int index)
    {
        PlayerPrefs.SetInt(Shadow_Quality_Key, index);
    }

    public void SetAntiAliasingIndex(int index)
    {
        PlayerPrefs.SetInt(Anti_Aliasing_Quality, index);
    }

    public void SetFullScreenBool(bool isEnabled)
    {
        PlayerPrefs.SetInt(FullScreen_Enabled, (isEnabled ? 1 : 0));
    }

    public void SetFullScreenInt(int index)
    {
        PlayerPrefs.SetInt(FullScreen_Enabled, index);
    }

    public void SetVsyncBool(bool isEnabled)
    {
        PlayerPrefs.SetInt(VSync_Enabled, (isEnabled ? 1 : 0));
    }

    public void SetVsyncInt(int index)
    {
        PlayerPrefs.SetInt(VSync_Enabled, index);
    }

    public int GetResoultionIndex()
    {
        return PlayerPrefs.GetInt(Screen_Resoltion_Key);
    }

    public int GetGraphicsIndex()
    {
        return PlayerPrefs.GetInt(Graphics_Quality_Key);
    }

    public int GetShadowsIndex()
    {
        return PlayerPrefs.GetInt(Shadow_Quality_Key);
    }

    public int GetAntiAliasingIndex()
    {
        return PlayerPrefs.GetInt(Anti_Aliasing_Quality);
    }

    public bool GetFullScreenBool()
    {
        return PlayerPrefs.GetInt(FullScreen_Enabled) != 0;
    }

    public int GetFullScreenInt()
    {
        return PlayerPrefs.GetInt(FullScreen_Enabled);
    }

    public bool GetVsyncBool()
    {
        return PlayerPrefs.GetInt(VSync_Enabled) != 0;
    }

    public int GetVsyncInt()
    {
        return PlayerPrefs.GetInt(VSync_Enabled);
    }
    #endregion

    #region Game Options
    public void SetPlayerLives(int playerLives)
    {
        PlayerPrefs.SetInt(Player_Lives, playerLives);
    }

    public void SetScore(int playerScore)
    {
        PlayerPrefs.SetInt(Player_Score, playerScore);
    }

    public void SetHighScore(int gameHighScore)
    {
        PlayerPrefs.SetInt(Game_HighScore, gameHighScore);
    }

    public int GetPlayerLives()
    {
        return PlayerPrefs.GetInt(Player_Lives);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt(Player_Score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(Game_HighScore);
    }
    #endregion
}
