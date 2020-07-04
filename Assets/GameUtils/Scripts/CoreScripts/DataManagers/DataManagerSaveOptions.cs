using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataManagerSaveOptions
{
    // You can not serialize vector3 as binary format but can as JSON

    public int lives;                           // Lives value
    public int score;                           // Score value
    public int highScore;                       // HighScore value
    public float masterVolume;                  // Music volume slider value
    public float musicVolume;                   // Music volume slider value
    public float sfxVolume;                     // Sound effects volume slider value
    public int screenResoltion;                 // Screen resoultion dropdown index
    public int graphicsQuality;                 // Graphics quality dropdown index
    public int shadowQuality;                   // Shadow quality dropdown index
    public int antiAliasingQuality;             // Anti aliasing quality dropdown index
    public int vSyncInt;                           // Int to set vSync to 0ff / 60 fps/ 30 fps
    public bool isFullscreen;                   // Fullscreen toggle
    public bool vSyncEnabled;                   // Vsync toggle
}
