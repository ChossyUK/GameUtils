using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour

{
    // Attach this to any object to make a frames/second indicator.
    //
    // It calculates frames/second over each updateInterval,
    // so the display does not keep changing wildly.
    //
    // It is also fairly accurate at very low FPS counts (<10).
    // We do this not by simply counting frames per interval, but
    // by accumulating FPS for each frame. This way we end up with
    // corstartRect overall FPS even if the interval renders something like
    // 5.5 frames.


    public Rect startRect = new Rect(30, 10, 75, 50); // The rect the window is initially displayed at.
    public bool updateColor = true; // Do you want the color to change if the FPS gets low
    //public bool allowDrag = true; // Do you want to allow the dragging of the FPS window
    public float frequency = 0.5F; // The update frequency of the fps
    public int nbDecimal = 1; // How many decimal do you want to display

    private Rect labelFPSRect = new Rect(0, -7, 75, 50);
    private Rect labelMemRect = new Rect(0, 7, 75, 50);
    private float accum; // FPS accumulated over the interval
    private int frames; // Frames drawn over the interval
    private Color color = Color.white; // The color of the GUI, depending of the FPS ( R < 10, Y < 30, G >= 30 )
    private string sFPS = string.Empty; // The fps formatted into a string.
    private string sMem = string.Empty; // The fps formatted into a string.
    private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.

    void Start()
    {
        StartCoroutine(FPS());
        labelFPSRect = new Rect(0, -7, 75, 50);
        labelMemRect = new Rect(0, 7, 75, 50);
    }

    void Update()
    {
        accum += 1 / Time.unscaledDeltaTime;
        ++frames;
    }

    IEnumerator FPS()
    {
        // Infinite loop executed every "frenquency" secondes.
        while (true)
        {
            // Update the FPS
            float fps = accum / frames;
            sFPS = string.Format("{0} FPS", fps.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10)));
            float mem = System.GC.GetTotalMemory(false) / (1024f * 1024f);
            sMem = string.Format("{0} MB", mem.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10)));

            //Update the color
            color = (fps >= 30 && mem < 400) ? Color.green : ((fps > 10 || mem > 500) ? Color.red : Color.yellow);


            accum = 0.0F;
            frames = 0;

            yield return new WaitForSecondsRealtime(frequency);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    void OnGUI()
    {
        // Copy the default label skin, change the color and the alignement
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label) { normal = { textColor = Color.white }, alignment = TextAnchor.MiddleCenter };
        }

        GUI.color = updateColor ? color : Color.white;
        startRect = GUI.Window(0, startRect, DoMyWindow, "");
    }

    void DoMyWindow(int windowID)
    {
        GUI.Label(labelFPSRect, sFPS, style);
        GUI.Label(labelMemRect, sMem, style);
        //if (allowDrag) GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
    }
}