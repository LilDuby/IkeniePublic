using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputPad : MonoBehaviour
{           
    public GameObject keyPadUI;
    public Image backgroud;
    public TMP_InputField inputField;
    public string password;
    public bool success=false;

    public DoorOpenSound sound;

    public void OnPasswordChack()
    {        
        if(password==inputField.text.ToString())
        {
            StartCoroutine(Success());
        }
        else
        {
            StartCoroutine(NoMatch());
        }
    }

    IEnumerator Success()
    {   
        backgroud.color = Color.green;
        yield return new WaitForSeconds(1.0f);
        success=true;
        keyPadUI.SetActive(false);
        PlayerManager.Instance.Player.controller.ToggleCursor();
        sound.OpenSound();
    }
    IEnumerator NoMatch()
    {   
        Color BG=backgroud.color; 
        backgroud.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        inputField.text ="";
        backgroud.color=BG;
    } 
    public void passwordReset()
    {
        inputField.text="Password";
    }  
}
