using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerChecker : MonoBehaviour
{
    // This script is to check if an audio manger exists and if not create one.

    public GameObject audioManager;

    void Awake()
    {
        if (FindObjectOfType<AudioManager>())
            return;
        else
            Instantiate(audioManager, transform.position, Quaternion.identity);
    }

}
