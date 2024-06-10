using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public GameObject missingWall;
    public AudioClip MissingWallClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MissingWwall()
    {
        Destroy(missingWall.gameObject);
        audioSource.PlayOneShot(MissingWallClip);
    }

}
