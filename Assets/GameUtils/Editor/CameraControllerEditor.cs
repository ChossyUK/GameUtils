using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraController2D))]
public class CameraControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraController2D cf = (CameraController2D)target;

        if(GUILayout.Button("Set Minimum Camera Position"))
          {
            cf.SetMinCameraPosition();
          }

        if (GUILayout.Button("Set Maximum Camera Position"))
        {
            cf.SetMaxCameraPosition();
        }
    }
}
