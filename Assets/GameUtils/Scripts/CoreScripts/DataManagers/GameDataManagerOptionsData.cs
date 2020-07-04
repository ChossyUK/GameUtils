using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataManagerOptionsData
{
    // You can not serialize vector3 as binary format this method uses binary format to save the data

    public string name;                         // Game name
    public string sceneName;                    // Scene name
    public int lives;                           // Lives value
    public int score;                           // Score value
    public int highScore;                       // HighScore value
    public float masterVolume;                  // Music volume slider value
    public float musicVolume;                   // Music volume slider value
    public float sfxVolume;                     // Sound effects volume slider value
    public int selectedIndex;                   // The list selected index
    public int screenResoltion;                 // Screen resoultion dropdown index
    public int graphicsQuality;                 // Graphics quality dropdown index
    public int shadowQuality;                   // Shadow quality dropdown index
    public int antiAliasingQuality;             // Anti aliasing quality dropdown index
    public int vSync;                           // Int to set vSync to 0ff / 60 fps/ 30 fps
    public bool isFullscreen;                   // Fullscreen toggle
    public bool vSyncEnabled;                   // Vsync toggle
    public bool isLocked;                       // bool to lock/unlock levels
}
