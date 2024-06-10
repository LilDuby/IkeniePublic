using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endKeyPadUI : MonoBehaviour
{
    public GameObject keyPadUI;    

    void Start()
    {
        PlayerManager.Instance.Player.Interaction2 += OnKeyPadUI;
    }
    public void OnKeyPadUI()
    {   
        PlayerManager.Instance.Player.controller.ToggleCursor();
        keyPadUI.SetActive(true); 
    }
}
