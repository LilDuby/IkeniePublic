using UnityEngine;

public class KeypadUI : MonoBehaviour
{       
    public GameObject keyPadUI;    

    void Start()
    {
        PlayerManager.Instance.Player.Interaction += OnKeyPadUI;
    }
    public void OnKeyPadUI()
    {   
        PlayerManager.Instance.Player.controller.ToggleCursor();
        keyPadUI.SetActive(true); 
    }
    
}
