using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareSceneButtonSound : MonoBehaviour
{
    public AudioClip buttonClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonSound()
    {
        audioSource.PlayOneShot(buttonClip);
    }
}
