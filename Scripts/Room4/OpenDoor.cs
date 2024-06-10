using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public AudioClip openDoorSound;
    AudioSource audioSource;

    public GameObject password4;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenDoorSituation()
    {
        animator.SetInteger("Open", 5);
        audioSource.PlayOneShot(openDoorSound);
        password4.SetActive(true);
    }
}
