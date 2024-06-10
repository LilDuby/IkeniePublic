using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSound : MonoBehaviour
{
    public AudioClip doorOpenSound;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenSound()
    {
        audioSource.PlayOneShot(doorOpenSound);
    }
}
