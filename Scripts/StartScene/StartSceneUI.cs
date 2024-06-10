using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public GameObject title;
    public GameObject menuButton;
    public GameObject manualPanel;
    public StareSceneButtonSound buttonSound;

    public void ClickStartButton()
    {
        buttonSound.ButtonSound();
        Invoke("LoadMainScene", 0.5f);
    }

    public void ClickManualButton()
    {
        buttonSound.ButtonSound();
        menuButton.SetActive(false);
        title.SetActive(false);
        manualPanel.SetActive(true);
    }

    public void ClickManualCloseButton()
    {
        buttonSound.ButtonSound();
        menuButton.SetActive(true);
        title.SetActive(true);
        manualPanel.SetActive(false);
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
