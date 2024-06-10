using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGhost : MonoBehaviour
{
    public AudioClip trapClip;
    public GameObject Ghost;
    Transform transform;
    BoxCollider collider;
    AudioSource audioSource;

    public int soundCount;
    int count = 0;

    private void Start()
    {
        transform = Ghost.transform;
        collider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Ghost.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            MoveGhost();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent <Player>() != null)
        {
            Destroy(Ghost);
            Destroy(collider);
        }
    }

    void MoveGhost()
    {
        count++;
        transform.position += new Vector3(-0.2f, 0, 0);
        if(count == soundCount)
        {
            audioSource.PlayOneShot(trapClip);
        }
    }
}
