using UnityEngine;
using System.Collections;

public class CameraController2D : MonoBehaviour {

    #region Public Variables
    // The player game object
    public GameObject player;

    // Offsets if you wish to of set the camera from the player
    public float xOffset, yOffset;

    // The camera min & max screen bounds values
    public Vector3 minCameraPosition, maxCameraPosition;

    // Lock the camera to the screen boundries
    public bool lockTobounds;

    // Set to get the camera to follow the player
    public bool isFollowing;
    #endregion

    #region Unity Base Methods
    void Update ()
    {
        // Check if set to follow the player and follow it
        if(isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
        }

        // Lock the camera screen bounds
        if(lockTobounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x), 
                                             Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y), 
                                             Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
        }        
	}
    #endregion

    #region User Methods
    public void SetMinCameraPosition()
    {
        // Set the camera minimum screen position
        minCameraPosition = gameObject.transform.position;
    }

    public void SetMaxCameraPosition()
    {
        // Set the camera maximum screen position
        maxCameraPosition = gameObject.transform.position;
    }
    #endregion
}
