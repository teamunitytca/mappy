using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class PlayModeButton : EditorWindow
{
    /*static PlayModeButton instance;
    static SerializedProperty pmb_isOn;

    PlayModeButton()
    {
        instance = this;
        EditorApplication.playModeStateChanged += OnModeChange;
    }

    [MenuItem("Xenose/Popup Example")]
    static void Init()
    {
        bool isPressed = pmb_isOn.FindPropertyRelative("pmb_isOn").boolValue;

        if (isPressed)
        {
            isPressed = false;
        }
        else
        {
            isPressed = true;
        }

        
        Debug.Log(isPressed);
    }

    private static void OnModeChange(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {

            Debug.Log("Playing...  " + pmb_isOn.FindPropertyRelative("pmb_isOn").boolValue);
            if (pmb_isOn.FindPropertyRelative("pmb_isOn").boolValue)
            {
                EditorWindow.FocusWindowIfItsOpen(typeof(SceneView));
            }
        }
    }*/
}
