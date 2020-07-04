using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Basic user music content player (c) Justin Mills 7th March 2020
// Simple script to play user music content in game in wav or ogg format
// If using the folder browser option you must create an Assets\ExternalFiles folder in the build directory and copy the folderbrowser.exe to it
// You can use the arrow keys and enter button
// If you use this script in your game please credit me.

public class UserMusicPlayer : MonoBehaviour
{
    // Create a static instance of the music player & do not destroy it
    public static UserMusicPlayer instance;

    #region Music Player Variables

    #region UI Stuff
    [Header("Music Player Variables")]

    // Music list dropdown box
    public Dropdown musicListBox;

    //  Folder path input field
    public InputField folderPath;

    // The on screen keyboard if required
    public OnScreenKeyboard onScreenKeyboard;

    // The ui canvas to disable if using the osk
    public Canvas uiCanvas;

    [Header("Windows Builds Only")]
    // Option to use the external folder browser app for windows (Copy the Assets\ExternalFiles\FolderBrowser.exe into an Assets\ExternalFiles folder in your builds root folder for release)
    public bool useFolderBrowser = false;

    // Animator for the on screen keyboard
    private Animator animator;
    #endregion

    #region Essential Music Player Variables
    // Option to not loop through the song list if required & play the song once (make public if not needed for your project)
    private bool playOnce = false;

    // Option to play the one track but loop it (make publicif not needed for your project)
    private bool loopMusic = false;

    // Option to play wav or ogg files (make public if needed for your project)
    private bool playWav = false;

    // Bool to set if song is playing or not
    private bool IsSongPlaying = false;

    // Static bool to pass to other scripts to tell them that the music player is handling the muusic
    public static bool isMusicPlaying = false;

    // Audio source attached to the game object
    private AudioSource audioSource;

    // Audio clip to store the associated music track into the audio clips list
    private AudioClip audioClip;

    // List to store the music track names in for the music list dropdown
    private List<string> songNames = new List<string>();

    // List to store the full music track file path to pass to the audio clip list when adding tracks
    private List<string> songList = new List<string>();

    // List to store the audio clips in
    private List<AudioClip> audioClips = new List<AudioClip>();

    // String to store the music folder path in
    private string musicFolderPath;

    // Int to store and reset playback of the music when it reaches the last song in the music list
    private int listLength = 0;

    // Float to store the current song length in
    private float songLength = 0;
    #endregion

    #endregion

    #region Unity Base Methods
    private void Awake()
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
    }

    private void Start()
    {
        // You can remove if not needed for your project and do not want to use the attached audio source
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Set the is music playing static bool to the same as the is song playing value 
        isMusicPlaying = IsSongPlaying;

        // Check if a song is playing
        if (IsSongPlaying)
        {
            // Subtract the current time from the current music track time
            songLength -= Time.unscaledDeltaTime;

            // Check if the current song time left is less than zero
            if (songLength < 0)
            {
                // If loop music bool set reset the song length to the audio clip length
                if (loopMusic)
                {
                    songLength = audioSource.clip.length;
                    return;
                }
                // If the play once bool is set stop the current song
                else if (playOnce)
                {
                    audioSource.Stop();
                    IsSongPlaying = false;
                }
                // Check if the list length value is less that the number of songs in the music list box and increment the music and list length values and play the next song in the list
                else if (listLength < musicListBox.options.Count)
                {
                    musicListBox.value++;
                    listLength++;
                    PlaySong();
                }
                // If the list length is greater than the music list value reset and play the 1st song
                else
                {
                    listLength = 0;
                    musicListBox.value = 0;
                    PlaySong();
                }
            }
        }
    }
    #endregion

    #region Music Player Methods
    // Fill the list box
    public void AddToList()
    {
        // Clear all music data
        songNames.Clear();
        songList.Clear();
        audioClips.Clear();
        musicListBox.ClearOptions();
        musicListBox.RefreshShownValue();

        // Check if using the external folder broswer and use it if enabled
        if (useFolderBrowser)
        {
            try
            {
                // Get the current directory
                string AppPath = Directory.GetCurrentDirectory();

                // Create a new process to start an exe
                ProcessStartInfo start = new ProcessStartInfo();

                // Set the exe file path
                start.FileName = AppPath + "\\Assets\\ExternalFiles\\UnityFolderBrowser.exe";

                // Open the exe
                using (Process proc = Process.Start(start))
                {
                    proc.WaitForExit();
                }

                // Get the music fokder path from the text file created by the folder browser exe
                musicFolderPath = File.ReadAllText(AppPath + "\\Assets\\ExternalFiles\\FolderPath.txt");

                // Check if the music folder path is empty if not start the fill dropdown method
                if (musicFolderPath != null)
                {
                    // Start to fill the music data
                    FillDropdown();
                }
            }
            catch (System.Exception)
            {

                UnityEngine.Debug.Log("Selection Cancelled");
            }
        }
        else
        {
            // Open the on screen keyboard
            onScreenKeyboard.gameObject.SetActive(true);

            // Get the osk animator
            animator = onScreenKeyboard.GetComponent<Animator>();

            //Trigger the on screen keyboard fade in animation
            animator.SetTrigger("FadeInOSK");

            // Disable the required canvas elements in the UI canvas
            uiCanvas.GetComponentInChildren<CanvasGroup>().interactable = false;
        }
    }

    // Set the music folder path from the input field from the on screen keyboard
    public void SetFolderPath()
    {
        //Trigger the on screen keyboard fade out animation
        animator.SetTrigger("FadeOutOSK");

        // Satrt the close the on screen keyboard coroutine
        StartCoroutine(FadeOut());

        // Enable the required canvas elements in the UI canvas
        uiCanvas.GetComponentInChildren<CanvasGroup>().interactable = true;

        try
        {
            // Set the music folder path
            musicFolderPath = folderPath.text;

            // Check if the music folder path is empty if not start the fill dropdown method
            if (musicFolderPath != null)
            {
                // Start to fill the music data
                FillDropdown();
            }
        }
        catch (System.Exception)
        {
            UnityEngine.Debug.Log("Can not find the music folder path did you enter it correctly or close the on screen keyboard ?");
        }
    }

    // Fill the list/audio data
    private void FillDropdown()
    {
        // Get the audio type and search the directory & sub directory's for the media type
        if (playWav)
        {
            // Get the audio data with out the file path or file extension used to populate the listbox
            songNames.AddRange(Directory.GetFiles(musicFolderPath, "*.wav", SearchOption.AllDirectories).Select(f => System.IO.Path.GetFileNameWithoutExtension(f)).ToList());

            // Get the audio data with the file path or file extension to pass to the audio clip list
            songList.AddRange(Directory.GetFiles(musicFolderPath, "*.wav", SearchOption.AllDirectories));
        }
        else
        {
            // Get the audio data with out the file path or file extension used to populate the listbox
            songNames.AddRange(Directory.GetFiles(musicFolderPath, "*.ogg", SearchOption.AllDirectories).Select(f => System.IO.Path.GetFileNameWithoutExtension(f)).ToList());

            // Get the audio data with the file path or file extension to pass to the audio clip list
            songList.AddRange(Directory.GetFiles(musicFolderPath, "*.ogg", SearchOption.AllDirectories));
        }

        // Set the listbox data
        foreach (string s in songNames)
        {
            musicListBox.options.Add(new Dropdown.OptionData() { text = s });
        }

        // Get each song in the song list and convert it to an audio clip 
        if (playWav)
        {
            foreach (string s in songList)
            {
                if (s.EndsWith(".wav"))
                {
                    audioClips.Add(new WWW(s).GetAudioClip(false, true, AudioType.WAV));
                }
            }
        }
        else
        {
            foreach (string s in songList)
            {
                if (s.EndsWith(".ogg"))
                {
                    audioClips.Add(new WWW(s).GetAudioClip(false, true, AudioType.OGGVORBIS));
                }
            }
        }

        // Refresh the listbox data
        musicListBox.RefreshShownValue();
    }

    // Play the audio clip
    public void PlaySong()
    {
        try
        {
            IsSongPlaying = false;
            audioClip = audioClips[musicListBox.value];
            audioSource.clip = audioClip;
            songLength = audioSource.clip.length;
            audioSource.loop = loopMusic;
            audioSource.Play();
            IsSongPlaying = true;
            listLength = musicListBox.value + 1;
        }
        catch (System.Exception)
        {
            UnityEngine.Debug.Log("No Audio Selected List Is Blank");
        }
    }

    // Stop the audio clip
    public void StopSong()
    {
        audioSource.Stop();
        IsSongPlaying = false;
        listLength = 0;
    }

    // Set the audio type
    public void SetAudioType(int audioType)
    {
        StopSong();

        switch (audioType)
        {
            case 0:
                playWav = false;
                break;
            case 1:
                playWav = true;
                break;
            default:
                break;
        }
    }

    // Close the on screen keyboard
    IEnumerator FadeOut()
    {
        // Wait for the animation to finish
        yield return new WaitForSecondsRealtime(1.5f);

        // Reset the on screen keyboard layout
        onScreenKeyboard.ResetLayout();

        // Close the on screen keyboard
        onScreenKeyboard.gameObject.SetActive(false);
    }
    #endregion
}
