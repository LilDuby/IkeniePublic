using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    public void OnEndButton()
    {
        // Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
