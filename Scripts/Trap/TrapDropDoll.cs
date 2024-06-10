using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDropDoll : MonoBehaviour
{
    public GameObject Dools;
    public AudioClip doolClip;

    AudioSource audioSource;

    BoxCollider collider;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Dools.SetActive(true);
            audioSource.PlayOneShot(doolClip);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(this.collider);
    }
}
