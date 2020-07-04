using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class UserVideoPlayer : MonoBehaviour
{
    #region Variables
    // The video player game object
    public VideoPlayer videoPlayer;

    // The video clip
    public VideoClip videoClip;

    // The video audio source
    public AudioSource audioSource;

    public Slider sliderBar;

    public GameObject loadingBar;

    // Variable to store the video clip length in
    private double videoLength;

    public bool playFromWeb = false;

    public string url;

    // Bool to control playback from this ot another scripit
    public static bool isPlaying = false;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        if(playFromWeb)
        {
            PlayUrl();
        }
        else
        {
            PlayVideoClip();
        }
    }

    void Update()
    {
        // Check if video clip is playing
        if(isPlaying)
        {
            // Subtract the time from the video clip length
            videoLength -= Time.unscaledDeltaTime;

            // Check if the video clip thats playing time left is greater than 0
            if (videoLength < 0)
            {
                // If the video clip length is less than 0 stop all playback and set the isPlaying bool to false
                isPlaying = false;
                videoPlayer.Stop();
                audioSource.Stop();

                // Load your scene or do what ever here
                Debug.Log("Load Scene");
            }
        }
    }
    #endregion

    #region Video Player Methods
    private void PlayVideoClip()
    {
        // Set the video audio source so can be controlled via the audio manager just set the audio source output option
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Get the video clip length
        videoLength = videoClip.length;

        // Set the video source
        videoPlayer.source = VideoSource.VideoClip;

        // Set the video clip
        videoPlayer.clip = videoClip;

        // Play the video clip and enable the audio source
        videoPlayer.Play();
        audioSource.Play();

        // Set the isPlaying bool to control when the video ends load the next scene 
        isPlaying = true;
    }

    public void PlayVideo(VideoClip videoClip)
    {
        // Set the video audio source so can be controlled via the audio manager just set the audio source output option
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Get the video clip length
        videoLength = videoClip.length;

        // Set the video source
        videoPlayer.source = VideoSource.VideoClip;

        // Set the video clip
        videoPlayer.clip = videoClip;

        // Play the video clip and enable the audio source
        videoPlayer.Play();
        audioSource.Play();

        // Set the isPlaying bool to control when the video ends load the next scene 
        isPlaying = true;
    }

    void PlayUrl()
    {
        StartCoroutine(DownloadVideo(url));
    }
    #endregion

    #region Coroutine to download from web
    IEnumerator DownloadVideo(string url)
    {
        loadingBar.SetActive(true);
        var www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "videoFile.mp4");
        www.downloadHandler = new DownloadHandlerFile(path);
        www.SendWebRequest();

        while (!www.isDone)
        {
            sliderBar.value = www.downloadProgress;
            yield return null;
        }

        if (www.isNetworkError || www.isHttpError)
            Debug.LogError(www.error);
        else
        loadingBar.SetActive(false);
        videoPlayer.url = Application.persistentDataPath + "/videoFile.mp4";
        videoPlayer.source = VideoSource.Url;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        audioSource.Play();
        videoPlayer.Play();
    }
    #endregion
}
